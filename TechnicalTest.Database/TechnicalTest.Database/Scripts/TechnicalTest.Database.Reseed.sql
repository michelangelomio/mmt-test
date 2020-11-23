SET NOCOUNT ON

BEGIN TRAN

	DELETE FROM [Repository].[Categories]

	DBCC CHECKIDENT ('Repository.Categories', RESEED, 0)

	DELETE FROM [Repository].[Products]

	DBCC CHECKIDENT ('Repository.Products', RESEED, 0)


COMMIT TRAN