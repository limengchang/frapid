﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Frapid.Account.DAL;
using Frapid.Account.DTO;
using Frapid.Account.Emails;
using Frapid.Account.InputModels;
using Frapid.Account.ViewModels;
using Frapid.Areas;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Frapid.Account.RemoteAuthentication
{
    public class GoogleAuthentication
    {
        public string Tenant { get; }
        private const string ProviderName = "Google";

        public GoogleAuthentication(string tenant)
        {
            this.Tenant = tenant;
            var profile = ConfigurationProfiles.GetActiveProfileAsync(tenant).Result;
            ClientId = profile.GoogleSigninClientId;
        }

        public string ClientId { get; set; }
        //https://developers.google.com/identity/sign-in/web/backend-auth
        private async Task<bool> ValidateAsync(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return false;
            }

            using (var client = new HttpClient())
            {
                string url = "https://www.googleapis.com";
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("/oauth2/v3/tokeninfo?id_token=" + token).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<JObject>(response.Content.ReadAsStringAsync().Result);
                    string aud = result["aud"].ToString();

                    if (aud == ClientId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public async Task<LoginResult> AuthenticateAsync(GoogleAccount account, RemoteUser user)
        {
            bool validationResult = Task.Run(() => ValidateAsync(account.Token)).Result;

            if (!validationResult)
            {
                return new LoginResult
                {
                    Status = false,
                    Message = "Access is denied"
                };
            }

            var gUser = new GoogleUserInfo
            {
                Email = account.Email,
                Name = account.Name
            };

            var result =
                await
                    GoogleSignIn.SignInAsync(this.Tenant, account.Email, account.OfficeId, account.Name, account.Token,
                        user.Browser,
                        user.IpAddress, account.Culture).ConfigureAwait(false);

            if (result.Status)
            {
                if (!await Registrations.HasAccountAsync(this.Tenant, account.Email).ConfigureAwait(false))
                {
                    string template = "~/Tenants/{tenant}/Areas/Frapid.Account/EmailTemplates/welcome-email-other.html";
                    var welcomeEmail = new WelcomeEmail(gUser, template, ProviderName);
                    await welcomeEmail.SendAsync(this.Tenant).ConfigureAwait(false);
                }
            }

            return result;
        }
    }
}