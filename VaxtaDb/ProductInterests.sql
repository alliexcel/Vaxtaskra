CREATE TABLE [dbo].[ProductInterests]
(
	[ProductInterestsID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Product_indexationID] INT NOT NULL, 
    [VaxtaRunaIntID] INT NOT NULL, 
    CONSTRAINT [FK_ProductInterests_ProductIndexation] FOREIGN KEY ([Product_indexationID]) REFERENCES Product_indexation(ProductIndexationID), 
    CONSTRAINT [FK_ProductInterests_Vaxtaruna_interests] FOREIGN KEY ([VaxtaRunaIntID]) REFERENCES Vaxtaruna_interests(Vaxtaruna_interestsID)
)
