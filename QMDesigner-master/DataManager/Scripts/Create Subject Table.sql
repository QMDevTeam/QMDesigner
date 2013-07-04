CREATE TABLE [{DataSchema}].[{tableName}](
	/*------------ Columns For Audit Trail ---------------*/
	
	[UpdateVersion] [int] NOT NULL,
	[InsertUser] [nvarchar](50) NOT NULL CONSTRAINT [DF_{tableName}_InsertUser]  DEFAULT (suser_sname()),
	[InsertDate] [datetime] NOT NULL CONSTRAINT [DF_{tableName}_InsertDate]  DEFAULT (getdate()),
	[InsertMsg] [nvarchar](255) NULL,
	[DBModifDate] [datetime] NOT NULL,
	[DBModifUser] [nvarchar](50) NOT NULL,
	[DBModifMsg] [nvarchar](255) NULL,
	[forDeletion] [int] NOT NULL DEFAULT ((0)),
	
    /*----- End Of Columns Audit Trail -------------------*/
        
	CONSTRAINT [PK_{tableName}] PRIMARY KEY NONCLUSTERED (SubjectID),
    
	SubjectID				uniqueidentifier NOT NULL,
	SubjectSiteID			int NOT NULL,
	SubjectCompletedStudy	bit NOT NULL,

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
	PDALastUploadPDAName	nvarchar(50),

	SubjectLastScreenID	int,
	SubjectStack		nvarchar(500),

	SASubjectID	nvarchar(50)	--Study Assigned SubjectID


	/* Add Subject Record Data Columns here */

	/* Add flags, derived, calculated or asigned Columns here */
);


CREATE INDEX IX_SASubjectID ON [{DataSchema}].[{tableName}](SASubjectID);