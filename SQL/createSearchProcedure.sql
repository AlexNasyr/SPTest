USE [TestDb]
GO

/****** Object:  StoredProcedure [dbo].[searchProduct]    Script Date: 30.09.2022 16:28:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[searchProduct]
@ProdName nvarchar(255), @VersionName nvarchar(255), @MinVolume decimal(18,0) = 0, @MaxVolume decimal(18,0) = 999999999999999999
as
--CREATE VIEW search_result as
select ProductVersion.ID, Product.Name, ProductVersion.Name, ProductVersion.Width, ProductVersion.Length, ProductVersion.Height
from ProductVersion left join Product on ProductVersion.ProductID = Product.ID
where Product.Name like '%'+@ProdName+'%' and ProductVersion.Name like '%'+@VersionName+'%' 
and ProductVersion.Width * ProductVersion.Length * ProductVersion.Height > @MinVolume 
and ProductVersion.Width * ProductVersion.Length * ProductVersion.Height < @MaxVolume
GO


