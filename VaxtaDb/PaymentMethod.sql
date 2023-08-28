CREATE TABLE [dbo].[PaymentMethod]
(
	[PaymentMethodID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PaymentMethodType] VARCHAR(250) NOT NULL
)
