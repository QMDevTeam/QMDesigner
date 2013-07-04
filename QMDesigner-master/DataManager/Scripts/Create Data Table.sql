CREATE TABLE [{DataSchema}].[{tableName}](

	/*------------ Columns For Audit Trail ---------------*/
	
	[UpdateVersion] [int] NOT NULL,
	[InsertUser] [nvarchar](20) NOT NULL CONSTRAINT [DF_{tableName}_InsertUser]  DEFAULT (suser_sname()),
	[InsertDate] [datetime] NOT NULL CONSTRAINT [DF_{tableName}_InsertDate]  DEFAULT (getdate()),
	[InsertMsg] [nvarchar](255) NULL,
	[DBModifDate] [datetime] NOT NULL,
	[DBModifUser] [nvarchar](20) NOT NULL,
	[DBModifMsg] [nvarchar](255) NULL,
	[forDeletion] [bit] NOT NULL DEFAULT ((0)),
    
    /*----- End Of Columns Audit Trail -------------------*/
    

	CONSTRAINT [PK_{tableName}] PRIMARY KEY NONCLUSTERED (SubjectID,SubjectQuestionnaireInstanceID),
	
	
	SubjectID			uniqueidentifier NOT NULL,
	SubjectQuestionnaireInstanceID	tinyint NOT NULL,
	SubjectCompletedRecord	bit NOT NULL,

	PDAInsertUser		nvarchar(50) NOT NULL,
	PDAInsertDate		datetime NOT NULL,
	PDAInsertVersion	nvarchar(50) NOT NULL,
	PDAInsertSN			nvarchar(50) NOT NULL,
	PDAInsertPDAName	nvarchar(50) NOT NULL,

	PDALastModifUser	nvarchar(50),
	PDALastModifDate	datetime,
	PDALastModifVersion	nvarchar(50),
	PDALastModifSN		nvarchar(50),
	PDALastModifPDAName	nvarchar(50),

	PDALastUploadUser		nvarchar(50),
	PDALastUploadDate		datetime,
	PDALastUploadVersion	nvarchar(50),
	PDALastUploadSN			nvarchar(50),
	PDALastUploadPDAName	nvarchar(50)


	/* Add User Record Data Columns here */

	/* Add derived, calculated or asigned Columns here */

);
