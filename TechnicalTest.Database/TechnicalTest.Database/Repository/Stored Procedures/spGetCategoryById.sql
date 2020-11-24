CREATE PROCEDURE [Repository].[spGetCategoryById]
	@CategoryId int
AS
	IF @CategoryId IS NOT NULL
	BEGIN
		SET NOCOUNT ON
		SELECT [Name] FROM [Repository].[Categories] WHERE [CategoryId] = @CategoryId
		RETURN 
	END
	GO