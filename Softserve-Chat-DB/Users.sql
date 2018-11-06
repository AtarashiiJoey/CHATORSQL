CREATE TABLE [dbo].[Users]
(
	[iUserID]			INT				NOT NULL PRIMARY KEY,
	[dtAdded]			DATETIME		NOT NULL,
	[iAddedBy]			INT				NOT NULL,
	[dtEdited]			DATETIME		NULL,
	[iEditedBy]			INT				NULL,
	[strFirstName]		VARCHAR(50)		NOT NULL,
	[strSurname]		VARCHAR(50)		NOT NULL,
	[strEmailAddress]	VARCHAR(250)	NOT NULL,
	[strPassword]		VARCHAR(50)		NOT NULL,
	[bIsDeleted]		BIT				NOT NULL,
)
