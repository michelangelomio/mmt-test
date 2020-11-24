/****** Object:  StoredProcedure [Repository].[spGetCategories]    Script Date: 24/11/2020 17:15:26 ******/
CREATE PROCEDURE [Repository].[spProduct]
	@CategoryName	varchar(50),
	@Sku			int,
	@Name			varchar(255),
	@Description	varchar(max),
	@Price			decimal
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @FeaturedProduct bit 
	
	IF @Sku LIKE '1%' OR @Sku LIKE '2%' OR @Sku LIKE '3%'
		SET @FeaturedProduct = 1

	DECLARE @CategoryId int
	SET @CategoryId = (SELECT [CategoryId] FROM [Categories] WHERE [Name] = @CategoryName)
	
	IF @CategoryId IS NOT NULL AND @Sku IS NOT NULL AND @Name IS NOT NULL AND @Description IS NOT NULL AND @Price IS NOT NULL
	BEGIN
		UPDATE 
			 [Repository].[Products]
		SET 
			 [CategoryId] = @CategoryId,
			 [Sku] = @Sku,
			 [Name] = @Name,
			 [Description] = @Description,
			 [Price] = @Price
		WHERE
			[CategoryId] = @CategoryId
			AND [Sku] = @Sku

		IF @@ROWCOUNT = 0
			INSERT INTO [Repository].[Products]
			(
				[CategoryId],
				[Sku],
				[Name],
				[Description],
				[Price],
				[FeaturedProduct],
				[Deleted]
			)
			VALUES
			(
				@CategoryId,
				@Sku,
				@Name,
				@Description,
				@Price,
				@FeaturedProduct,
				0
			)
	END
END