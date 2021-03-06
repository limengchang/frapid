DO
$$
BEGIN
	DELETE FROM config.custom_field_data_types;
	
	IF NOT EXISTS(SELECT * FROM config.custom_field_data_types WHERE data_type='text') THEN
		INSERT INTO config.custom_field_data_types(data_type, underlying_type)
		SELECT 'Text', 'national character varying(500)';
	END IF;

	IF NOT EXISTS(SELECT * FROM config.custom_field_data_types WHERE data_type='Number') THEN
		INSERT INTO config.custom_field_data_types(data_type, underlying_type)
		SELECT 'Number', 'integer';
	END IF;

	IF NOT EXISTS(SELECT * FROM config.custom_field_data_types WHERE data_type='Positive Number') THEN
		INSERT INTO config.custom_field_data_types(data_type, underlying_type)
		SELECT 'Positive Number', 'dbo.integer_strict';
	END IF;

	IF NOT EXISTS(SELECT * FROM config.custom_field_data_types WHERE data_type='Money') THEN
		INSERT INTO config.custom_field_data_types(data_type, underlying_type)
		SELECT 'Money', 'decimal(24, 4)';
	END IF;

	IF NOT EXISTS(SELECT * FROM config.custom_field_data_types WHERE data_type='Money (Positive Value Only)') THEN
		INSERT INTO config.custom_field_data_types(data_type, underlying_type)
		SELECT 'Money (Positive Value Only)', 'dbo.money_strict';
	END IF;

	IF NOT EXISTS(SELECT * FROM config.custom_field_data_types WHERE data_type='Date') THEN
		INSERT INTO config.custom_field_data_types(data_type, underlying_type)
		SELECT 'Date', 'date';
	END IF;

	IF NOT EXISTS(SELECT * FROM config.custom_field_data_types WHERE data_type='Date & Time') THEN
		INSERT INTO config.custom_field_data_types(data_type, underlying_type)
		SELECT 'Date & Time', 'datetimeoffset';
	END IF;

	IF NOT EXISTS(SELECT * FROM config.custom_field_data_types WHERE data_type='Time') THEN
		INSERT INTO config.custom_field_data_types(data_type, underlying_type)
		SELECT 'Time', 'time';
	END IF;

	IF NOT EXISTS(SELECT * FROM config.custom_field_data_types WHERE data_type='True/False') THEN
		INSERT INTO config.custom_field_data_types(data_type, underlying_type)
		SELECT 'True/False', 'bit';
	END IF;

	IF NOT EXISTS(SELECT * FROM config.custom_field_data_types WHERE data_type='Long Text') THEN
		INSERT INTO config.custom_field_data_types(data_type, underlying_type)
		SELECT 'Long Text', 'national character varying(MAX)';
	END IF;
END
$$
LANGUAGE plpgsql;
