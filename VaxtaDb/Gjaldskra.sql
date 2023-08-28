CREATE TABLE [dbo].[Gjaldskra]
(
	[GjaldskraID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Númer] VARCHAR(250) NOT NULL, 
    [Heiti] VARCHAR(250) NOT NULL, 
    [Fjárhæð] DECIMAL NOT NULL
)
