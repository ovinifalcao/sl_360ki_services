CREATE TABLE [dbo].[op_User_Services]
(
	[USRGD_FK] INT NOT NULL PRIMARY KEY
	,[Phone_Num] INT NOT NULL UNIQUE
	,[WSP] VARCHAR(100) NOT NULL
	,FOREIGN KEY ([USRGD_FK]) REFERENCES [bs_User_Resgistered]([USRGD_Id])
)
