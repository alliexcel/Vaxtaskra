CREATE TABLE [dbo].[Vaxtaruna]
(
	[VaxtarunaID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Heiti] VARCHAR(250) NOT NULL, 
    [Vextir_greidastID] INT NOT NULL, 
    [Is_deposit] BIT NOT NULL, 
    [Is_fixed] BIT NOT NULL, 
    [Is_indexed] BIT NOT NULL, 
    [VaxtafoturID] INT NOT NULL, 
    [Amount_from] NUMERIC NULL, 
    [Amount_to] NUMERIC NULL, 
    [Months_tied] NUMERIC NULL, 
    [is_Corp] BIT NULL, 
    CONSTRAINT [FK_Vaxtaruna_Vextir_greidast] FOREIGN KEY (Vextir_greidastID) REFERENCES Vextir_greidast(Vextir_greidastID), 
    CONSTRAINT [FK_Vaxtaruna_Vaxtafotur] FOREIGN KEY (VaxtafoturiD) REFERENCES Vaxtafotur(VaxtafoturID) 
)
