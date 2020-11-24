CREATE PROCEDURE [Repository].[spCategory]
      @Name varchar(50)
AS
BEGIN
	SET NOCOUNT ON

	IF @Name IS NOT NULL
	BEGIN
		UPDATE 
			 [Repository].[Categories]
		SET 
			 [Name] = @Name
		WHERE
			 [Name] = @Name

		IF @@ROWCOUNT = 0
			INSERT INTO [Repository].[Categories]
			(
				[Name],
				[Deleted]
			)
			VALUES
			(
				@Name,
				0
			)
	END
END