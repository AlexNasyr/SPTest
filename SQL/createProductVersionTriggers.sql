USE [TestDb]
GO

/****** Object:  Trigger [dbo].[Product_Insert]    Script Date: 30.09.2022 15:14:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[ProductVersion_Insert] ON [dbo].[ProductVersion] 
AFTER INSERT
AS
INSERT INTO EventLog values(NEWID(), GETDATE(), 'ProductVersion Inserted')
GO

ALTER TABLE [dbo].[ProductVersion] ENABLE TRIGGER [ProductVersion_Insert]
GO

CREATE TRIGGER [dbo].[ProductVersion_Update] ON [dbo].[ProductVersion] 
AFTER UPDATE
AS
INSERT INTO EventLog values(NEWID(), GETDATE(), 'ProductVersion Updated')
GO

ALTER TABLE [dbo].[ProductVersion] ENABLE TRIGGER [ProductVersion_Update]
GO

CREATE TRIGGER [dbo].[ProductVersion_Delete] ON [dbo].[ProductVersion] 
AFTER DELETE
AS
INSERT INTO EventLog values(NEWID(), GETDATE(), 'ProductVersion Deleted')
GO

ALTER TABLE [dbo].[ProductVersion] ENABLE TRIGGER [ProductVersion_Delete]
GO

