CREATE TABLE [{AuditSchema}].[{tableName}](

	/*-----------CONSTRAINT for the Audit Table-----------*/

	CONSTRAINT [PK_Log_{tableName}_SubjectID_UpdateVersion] PRIMARY KEY NONCLUSTERED 

	(

		  [SubjectID] ASC,
		  
		  [SubjectQuestionnaireInstanceID] ASC, 

		  [UpdateVersion] ASC

	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],


	/*------------ Columns For Audit Trail ---------------*/
	
	[UpdateVersion] [int] NOT NULL,
	[LogUser] [nvarchar](20) NOT NULL CONSTRAINT [DF_Log_{tableName}_LogUser]  DEFAULT (suser_sname()),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_Log_{tableName}_LogDate]  DEFAULT (getdate()),
	[LogMsg] [nvarchar](255) NULL,
	[DBModifDate] [datetime] NOT NULL,
	[DBModifUser] [nvarchar](20) NOT NULL,
	[DBModifMsg] [nvarchar](255) NULL,
	[forDeletion] [int] NOT NULL CONSTRAINT [DF__Log_{tableName}__forDelet__0E4EF685]  DEFAULT ((0)),
    
    /*----- End Of Columns Audit Trail -------------------*/
    
    
    /* --------- We Have to remove the constraint to the SubjectID--------------*/
    
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
