/****** Object:  StoredProcedure [Repository].[spGetCategories]    Script Date: 24/11/2020 17:15:26 ******/
CREATE PROCEDURE [Repository].[spGetProducts]
AS
	BEGIN
		SET NOCOUNT ON
		SELECT * FROM [Repository].[Products]
		RETURN 
	END