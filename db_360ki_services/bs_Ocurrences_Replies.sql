CREATE TABLE [dbo].[bs_Ocurrences_Replies]
(
	[RPT_Fk] INT NOT NULL,
	[USRGD_Fk] INT NOT NULL,
	[Kind_Id] INT NOT NULL,
	[Moment] DATETIME NOT NULL,
	PRIMARY KEY ([RPT_Fk], [USRGD_Fk]),
	FOREIGN KEY ([USRGD_Fk]) REFERENCES [bs_User_Resgistered]([USRGD_Id]),
	FOREIGN KEY ([RPT_Fk]) REFERENCES [bs_Ocurrence_Report]([RPT_Id])
)				
