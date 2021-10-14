CREATE TABLE [dbo].[bs_User_Resgistered]
(
	[USRGD_Id] INT NOT NULL PRIMARY KEY,
	[Name] varchar(500) NOT NULL,
	[BirthDate] date NOT NULL,
	[CityZone_Id] int NOT NULL
	FOREIGN KEY ([CityZone_Id]) REFERENCES [kd_City_Zones]([Kd_Ct_Zn_Id])
)
