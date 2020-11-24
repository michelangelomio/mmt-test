CREATE PROCEDURE [Repository].[spGetProductsByCategoryId]
	@CategoryId int
AS
	IF @CategoryId IS NOT NULL
	BEGIN
		SET NOCOUNT ON
		SELECT p.[ProductId], p.[Sku], p.[Name], c.[Name] AS [CategoryName] FROM [Repository].[Products] AS p
		INNER JOIN [Repository].[Categories] AS c ON p.CategoryId = c.CategoryId 
		WHERE p.[CategoryId] = @CategoryId
		RETURN 
	END
	GO