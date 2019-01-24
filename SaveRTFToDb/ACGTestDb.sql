IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'ACGTestDb')
	DROP DATABASE [ACGTestDb]
GO

CREATE DATABASE [ACGTestDb]
GO

exec sp_dboption N'ACGTestDb', N'autoclose', N'false'
GO

exec sp_dboption N'ACGTestDb', N'bulkcopy', N'false'
GO

exec sp_dboption N'ACGTestDb', N'trunc. log', N'false'
GO

exec sp_dboption N'ACGTestDb', N'torn page detection', N'true'
GO

exec sp_dboption N'ACGTestDb', N'read only', N'false'
GO

exec sp_dboption N'ACGTestDb', N'dbo use', N'false'
GO

exec sp_dboption N'ACGTestDb', N'single', N'false'
GO

exec sp_dboption N'ACGTestDb', N'autoshrink', N'false'
GO

exec sp_dboption N'ACGTestDb', N'ANSI null default', N'false'
GO

exec sp_dboption N'ACGTestDb', N'recursive triggers', N'false'
GO

exec sp_dboption N'ACGTestDb', N'ANSI nulls', N'false'
GO

exec sp_dboption N'ACGTestDb', N'concat null yields null', N'false'
GO

exec sp_dboption N'ACGTestDb', N'cursor close on commit', N'false'
GO

exec sp_dboption N'ACGTestDb', N'default to local cursor', N'false'
GO

exec sp_dboption N'ACGTestDb', N'quoted identifier', N'false'
GO

exec sp_dboption N'ACGTestDb', N'ANSI warnings', N'false'
GO

exec sp_dboption N'ACGTestDb', N'auto create statistics', N'true'
GO

exec sp_dboption N'ACGTestDb', N'auto update statistics', N'true'
GO

use [ACGTestDb]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SaveRTFToDb]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SaveRTFToDb]
GO

CREATE TABLE [dbo].[SaveRTFToDb] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[RTFText] [image] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[SaveRTFToDb] WITH NOCHECK ADD 
	CONSTRAINT [PK_SaveRTFToDb] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO
