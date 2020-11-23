CREATE TABLE [Repository].[Categories]
(
	[CategoryId]	INT IDENTITY (1, 1) NOT NULL, 
    [Name]	VARCHAR(50) NOT NULL,
	[Deleted] BIT NOT NULL, 
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryId] ASC),
	CONSTRAINT [UK_Categories] UNIQUE NONCLUSTERED ([Name] ASC)
)
