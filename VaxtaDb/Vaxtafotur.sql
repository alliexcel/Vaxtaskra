CREATE TABLE [dbo].[Vaxtafotur]
(
	[VaxtafoturID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Heiti] VARCHAR(250) NOT NULL, 
    [Is_Indexed] BIT NULL, 
    [is_active] BIT NULL 
)
