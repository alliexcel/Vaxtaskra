CREATE TABLE [dbo].[Product_indexation]
(
	[ProductIndexationID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductID] INT NOT NULL, 
    [is_Indexed] BIT NOT NULL, 
    [MAX_number_payments] DECIMAL NOT NULL, 
    [MIN_number_payments] DECIMAL NOT NULL, 
    [Max_amount] NUMERIC NOT NULL, 
    [Min_amount] NUMERIC NOT NULL, 
    [Max_number_of_months_without_payment] NUMERIC NOT NULL, 
    [Max_number_months_between_payments] NUMERIC NOT NULL, 
    CONSTRAINT [FK_Product_indexation_Product] FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
)
