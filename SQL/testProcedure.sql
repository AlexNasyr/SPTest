USE [TestDb]
GO

declare 
@ProdName nvarchar(255), @VersionName nvarchar(255), @MinVolume decimal(18,0), @MaxVolume decimal(18,0)
set @ProdName = 't1' 
set @VersionName = 'd1' 
set @MinVolume = 0
set @MaxVolume = 100

exec searchProduct @ProdName, @VersionName, @MinVolume, @MaxVolume