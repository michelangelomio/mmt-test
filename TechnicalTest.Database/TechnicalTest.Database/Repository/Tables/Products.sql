CREATE TABLE [Repository].[Products]
(
	[ProductId]         INT IDENTITY (1, 1) NOT NULL, 
    [CategoryId]        INT NOT NULL,
    [Sku]               INT NOT NULL, 
    [Name]              VARCHAR(MAX) NOT NULL, 
    [Description]       VARCHAR(MAX) NOT NULL, 
    [Price]             DECIMAL NOT NULL, 
    [FeaturedProduct]   BIT NULL, 
    [Deleted] BIT NOT NULL, 
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductId] ASC),
	CONSTRAINT [FK_Products_CategoryId] FOREIGN KEY ([CategoryId])  REFERENCES [Repository].[Categories]([CategoryId])
)
