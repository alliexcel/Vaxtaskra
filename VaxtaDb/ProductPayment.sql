CREATE TABLE [dbo].[ProductPayment]
(
	[ProductPaymentID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductIndexationID] INT NOT NULL, 
    [PaymentMethodID] INT NOT NULL, 
    [TemplateID] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_ProductPayment_ProductIndexation] FOREIGN KEY (ProductIndexationID) REFERENCES Product_Indexation(ProductIndexationID)
)
