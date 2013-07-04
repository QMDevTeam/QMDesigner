IF NOT EXISTS(SELECT 1 FROM information_schema.schemata WHERE schema_name= '{SchemaName}')
EXEC ('CREATE SCHEMA [{SchemaName}] ');