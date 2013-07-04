CREATE TABLE [dbo].[Study]
(
	[ShortName] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Version] [nvarchar](50) NOT NULL,
	[DesignerVersion] [nvarchar](50) NOT NULL,
	[GeneratorVersion] [nvarchar](50),
	[CreationDateTime] [datetime] NOT NULL,
	[LastModificationDateTime] [datetime] NOT NULL,
	[GenerationDateTime] [datetime] 
);
