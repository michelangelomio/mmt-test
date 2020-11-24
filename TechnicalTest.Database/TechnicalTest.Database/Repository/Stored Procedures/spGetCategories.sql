CREATE PROCEDURE [Repository].[spGetCategories]
AS
	BEGIN
		SET NOCOUNT ON
		SELECT * FROM [Repository].[Categories]
		RETURN 
	END
	GO