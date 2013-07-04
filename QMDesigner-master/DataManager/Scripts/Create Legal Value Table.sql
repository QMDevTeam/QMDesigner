CREATE TABLE [{LegalValueSchema}].[{tableName}]
(
	[Value] [int] NULL
	,[Order] [int] NULL
	,[Text] [nvarchar](200) NULL
	,[ShortName] [nvarchar](50) NULL
	,[Group] [nvarchar](50) NULL
	,[Hidden] [bit] NULL
    ,[LegalValueItemGUID] UNIQUEIDENTIFIER NULL
);