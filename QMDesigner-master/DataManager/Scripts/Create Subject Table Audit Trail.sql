CREATE TABLE [{AuditSchema}].[{tableName}](

	/*-----------CONSTRAINT for the Audit Table-----------*/

	CONSTRAINT [PK_Log_{tableName}_SubjectID_UpdateVersion] PRIMARY KEY NONCLUSTERED 

	(

		  [SubjectID] ASC,

		  [UpdateVersion] ASC

	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],


	/*------------ Columns For Audit Trail ---------------*/
	

	/*------------ Columns For Audit Trail ---------------*/
	
	[UpdateVersion] [int] NOT NULL,
	[LogUser] [nvarchar](50) NOT NULL CONSTRAINT [DF_Log_{tableName}_LogUser]  DEFAULT (suser_sname()),
	[LogDate] [datetime] NOT NULL CONSTRAINT [DF_Log_{tableName}_LogDate]  DEFAULT (getdate()),
	[LogMsg] [nvarchar](255) NULL,
	[DBModifDate] [datetime] NOT NULL,
	[DBModifUser] [nvarchar](50) NOT NULL,
	[DBModifMsg] [nvarchar](255) NULL,
	[forDeletion] [int] NOT NULL CONSTRAINT [DF__Log_{tableName}__forDelet__0E4EF685]  DEFAULT ((0)),
    
    /*----- End Of Columns Audit Trail -------------------*/


    /* --------- We Have to remove the constraint to the SubjectID--------------*/
    
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


CREATE INDEX IX_SASubjectID ON [{AuditSchema}].[{tableName}](SASubjectID);