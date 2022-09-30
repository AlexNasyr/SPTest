USE [TestDb]
GO

/****** Object:  Trigger [dbo].[Product_Insert]    Script Date: 30.09.2022 15:14:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[Product_Insert] ON [dbo].[Product] 
AFTER INSERT
AS
INSERT INTO EventLog values(NEWID(), GETDATE(), 'Product Inserted')
GO

ALTER TABLE [dbo].[Product] ENABLE TRIGGER [Product_Insert]
GO

CREATE TRIGGER [dbo].[Product_Update] ON [dbo].[Product] 
AFTER UPDATE
AS
INSERT INTO EventLog values(NEWID(), GETDATE(), 'Product Updated')
GO

ALTER TABLE [dbo].[Product] ENABLE TRIGGER [Product_Update]
GO

CREATE TRIGGER [dbo].[Product_Delete] ON [dbo].[Product] 
AFTER DELETE
AS
INSERT INTO EventLog values(NEWID(), GETDATE(), 'Product Deleted')
GO

ALTER TABLE [dbo].[Product] ENABLE TRIGGER [Product_Delete]
GO

