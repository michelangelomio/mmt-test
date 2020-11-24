/****** Object:  StoredProcedure [Repository].[spGetCategories]    Script Date: 24/11/2020 17:15:26 ******/
CREATE PROCEDURE [Repository].[spGetProductById]
	@ProductId int
AS
	IF @ProductId IS NOT NULL
	BEGIN
		SET NOCOUNT ON
		SELECT * FROM [Repository].[Products] WHERE [ProductId] = @ProductId
		RETURN 
	END
	GO