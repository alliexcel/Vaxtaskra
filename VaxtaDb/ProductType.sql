CREATE TABLE [dbo].[ProductType]
(
	[ProductTypeID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Type] VARCHAR(150) NOT NULL, 
    [Has_downpayment] BIT NOT NULL, 
    [Has_collateral] BIT NOT NULL
)
