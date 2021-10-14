CREATE TABLE [dbo].[bs_Ocurrence_Report]
(
	[RPT_Id] INT NOT NULL,
	[USRGD_Owner_fk] INT NOT NULL,
	[Title] VARCHAR(200) NOT NULL,
	[Kind_Id] INT NOT NULL,
	[Place] VARCHAR (200) NOT NULL,
	[CityZone_Id] INT NOT NULL,
	[Moment] DATETIME NOT NULL,
	[Photo] VARBINARY(MAX),  
	PRIMARY KEY ([RPT_Id]),
	FOREIGN KEY ([USRGD_Owner_fk]) REFERENCES bs_User_Resgistered([USRGD_Id]),
	FOREIGN KEY ([Kind_Id]) REFERENCES kd_Ocurrences([kd_Oc_Id]),
	FOREIGN KEY ([CityZone_Id]) REFERENCES [kd_City_Zones]([Kd_Ct_Zn_Id])
)
