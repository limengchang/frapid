using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;
using Frapid.WebApi.DataAccess;
using Newtonsoft.Json.Linq;

namespace Frapid.WebApi.Service
{
    public class ViewApiController: FrapidApiController
    {
        [AcceptVerbs("GET", "HEAD")]
        [Route("~/api/views/{schemaName}/{tableName}/count")]
        [RestAuthorize]
        public async Task<long> CountAsync(string schemaName, string tableName)
        {
            try
            {
                var repository = new ViewRepository(schemaName, tableName, this.AppUser.Tenant, this.AppUser.LoginId, this.AppUser.UserId);
                return await repository.CountAsync().ConfigureAwait(false);
            }
            catch(UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch(DataAccessException ex)
            {
                throw new HttpResponseException
                    (
                    new HttpResponseMessage
                    {
                        Content = new StringContent(ex.Message),
                        StatusCode = HttpStatusCode.InternalServerError
                    });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        [AcceptVerbs("GET", "HEAD")]
        [Route("~/api/views/{schemaName}/{tableName}/all")]
        [Route("~/api/views/{schemaName}/{tableName}/export")]
        [RestAuthorize]
        public async Task<IEnumerable<dynamic>> GetAllAsync(string schemaName, string tableName)
        {
            try
            {
                var repository = new ViewRepository(schemaName, tableName, this.AppUser.Tenant, this.AppUser.LoginId, this.AppUser.UserId);
                return await repository.GetAsync().ConfigureAwait(false);
            }
            catch(UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch(DataAccessException ex)
            {
                throw new HttpResponseException
                    (
                    new HttpResponseMessage
                    {
                        Content = new StringContent(ex.Message),
                        StatusCode = HttpStatusCode.InternalServerError
                    });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        [AcceptVerbs("GET", "HEAD")]
        [Route("~/api/views/{schemaName}/{tableName}")]
        [RestAuthorize]
        public async Task<IEnumerable<dynamic>> GetPaginatedResultAsync(string schemaName, string tableName)
        {
            try
            {
                var repository = new ViewRepository(schemaName, tableName, this.AppUser.Tenant, this.AppUser.LoginId, this.AppUser.UserId);
                return await repository.GetPaginatedResultAsync().ConfigureAwait(false);
            }
            catch(UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch(DataAccessException ex)
            {
                throw new HttpResponseException
                    (
                    new HttpResponseMessage
                    {
                        Content = new StringContent(ex.Message),
                        StatusCode = HttpStatusCode.InternalServerError
                    });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        [AcceptVerbs("GET", "HEAD")]
        [Route("~/api/views/{schemaName}/{tableName}/page/{pageNumber}")]
        [RestAuthorize]
        public async Task<IEnumerable<dynamic>> GetPaginatedResultAsync(string schemaName, string tableName, long pageNumber)
        {
            try
            {
                var repository = new ViewRepository(schemaName, tableName, this.AppUser.Tenant, this.AppUser.LoginId, this.AppUser.UserId);
                return await repository.GetPaginatedResultAsync(pageNumber).ConfigureAwait(false);
            }
            catch(UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch(DataAccessException ex)
            {
                throw new HttpResponseException
                    (
                    new HttpResponseMessage
                    {
                        Content = new StringContent(ex.Message),
                        StatusCode = HttpStatusCode.InternalServerError
                    });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        [AcceptVerbs("POST")]
        [Route("~/api/views/{schemaName}/{tableName}/count-where")]
        [RestAuthorize]
        public async Task<long> CountWhereAsync(string schemaName, string tableName, [FromBody] JArray filters)
        {
            try
            {
                var f = Filter.FromJArray(filters);
                var repository = new ViewRepository(schemaName, tableName, this.AppUser.Tenant, this.AppUser.LoginId, this.AppUser.UserId);
                return await repository.CountWhereAsync(f).ConfigureAwait(false);
            }
            catch(UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch(DataAccessException ex)
            {
                throw new HttpResponseException
                    (
                    new HttpResponseMessage
                    {
                        Content = new StringContent(ex.Message),
                        StatusCode = HttpStatusCode.InternalServerError
                    });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        [AcceptVerbs("POST")]
        [Route("~/api/views/{schemaName}/{tableName}/get-where/{pageNumber}")]
        [RestAuthorize]
        public async Task<IEnumerable<dynamic>> GetWhereAsync(string schemaName, string tableName, long pageNumber, [FromBody] JArray filters)
        {
            try
            {
                var f = Filter.FromJArray(filters);
                var repository = new ViewRepository(schemaName, tableName, this.AppUser.Tenant, this.AppUser.LoginId, this.AppUser.UserId);
                return await repository.GetWhereAsync(pageNumber, f).ConfigureAwait(false);
            }
            catch(UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch(DataAccessException ex)
            {
                throw new HttpResponseException
                    (
                    new HttpResponseMessage
                    {
                        Content = new StringContent(ex.Message),
                        StatusCode = HttpStatusCode.InternalServerError
                    });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        [AcceptVerbs("GET", "HEAD")]
        [Route("~/api/views/{schemaName}/{tableName}/count-filtered/{filterName}")]
        [RestAuthorize]
        public async Task<long> CountFilteredAsync(string schemaName, string tableName, string filterName)
        {
            try
            {
                var repository = new ViewRepository(schemaName, tableName, this.AppUser.Tenant, this.AppUser.LoginId, this.AppUser.UserId);
                return await repository.CountFilteredAsync(filterName).ConfigureAwait(false);
            }
            catch(UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch(DataAccessException ex)
            {
                throw new HttpResponseException
                    (
                    new HttpResponseMessage
                    {
                        Content = new StringContent(ex.Message),
                        StatusCode = HttpStatusCode.InternalServerError
                    });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        [AcceptVerbs("GET", "HEAD")]
        [Route("~/api/views/{schemaName}/{tableName}/get-filtered/{pageNumber}/{filterName}")]
        [RestAuthorize]
        public async Task<IEnumerable<dynamic>> GetFilteredAsync(string schemaName, string tableName, long pageNumber, string filterName)
        {
            try
            {
                var repository = new ViewRepository(schemaName, tableName, this.AppUser.Tenant, this.AppUser.LoginId, this.AppUser.UserId);
                return await repository.GetFilteredAsync(pageNumber, filterName).ConfigureAwait(false);
            }
            catch(UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch(DataAccessException ex)
            {
                throw new HttpResponseException
                    (
                    new HttpResponseMessage
                    {
                        Content = new StringContent(ex.Message),
                        StatusCode = HttpStatusCode.InternalServerError
                    });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        [AcceptVerbs("GET", "HEAD")]
        [Route("~/api/views/{schemaName}/{tableName}/display-fields")]
        [RestAuthorize]
        public async Task<IEnumerable<DisplayField>> GetDisplayFieldsAsync(string schemaName, string tableName)
        {
            try
            {
                var repository = new ViewRepository(schemaName, tableName, this.AppUser.Tenant, this.AppUser.LoginId, this.AppUser.UserId);
                return await repository.GetDisplayFieldsAsync().ConfigureAwait(false);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException
                    (
                    new HttpResponseMessage
                    {
                        Content = new StringContent(ex.Message),
                        StatusCode = HttpStatusCode.InternalServerError
                    });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        [AcceptVerbs("GET", "HEAD")]
        [Route("~/api/views/{schemaName}/{tableName}/display-fields/get-where")]
        [HttpPost]
        [RestAuthorize]
        public async Task<IEnumerable<DisplayField>> GetDisplayFieldsAsync(string schemaName, string tableName, [FromBody] JArray filters)
        {
            try
            {
                var f = Filter.FromJArray(filters);
                var repository = new ViewRepository(schemaName, tableName, this.AppUser.Tenant, this.AppUser.LoginId, this.AppUser.UserId);
                return await repository.GetDisplayFieldsAsync(f).ConfigureAwait(false);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException
                    (
                    new HttpResponseMessage
                    {
                        Content = new StringContent(ex.Message),
                        StatusCode = HttpStatusCode.InternalServerError
                    });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        [AcceptVerbs("GET", "HEAD")]
        [Route("~/api/views/{schemaName}/{tableName}/lookup-fields")]
        [RestAuthorize]
        public async Task<IEnumerable<DisplayField>> GetLookupFieldsAsync(string schemaName, string tableName)
        {
            try
            {
                var repository = new ViewRepository(schemaName, tableName, this.AppUser.Tenant, this.AppUser.LoginId, this.AppUser.UserId);
                return await repository.GetLookupFieldsAsync().ConfigureAwait(false);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException
                    (
                    new HttpResponseMessage
                    {
                        Content = new StringContent(ex.Message),
                        StatusCode = HttpStatusCode.InternalServerError
                    });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

        [AcceptVerbs("GET", "HEAD")]
        [Route("~/api/views/{schemaName}/{tableName}/lookup-fields/get-where")]
        [HttpPost]
        [RestAuthorize]
        public async Task<IEnumerable<DisplayField>> GetLookupFieldsAsync(string schemaName, string tableName, [FromBody] JArray filters)
        {
            try
            {
                var f = Filter.FromJArray(filters);
                var repository = new ViewRepository(schemaName, tableName, this.AppUser.Tenant, this.AppUser.LoginId, this.AppUser.UserId);
                return await repository.GetLookupFieldsAsync(f).ConfigureAwait(false);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (DataAccessException ex)
            {
                throw new HttpResponseException
                    (
                    new HttpResponseMessage
                    {
                        Content = new StringContent(ex.Message),
                        StatusCode = HttpStatusCode.InternalServerError
                    });
            }
#if !DEBUG
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
#endif
        }

    }
}