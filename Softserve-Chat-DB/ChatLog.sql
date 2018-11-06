CREATE TABLE [dbo].[ChatLog]
(
	[iChatLogID]		INT				NOT NULL PRIMARY KEY,
	[dtAdded]			DATETIME		NOT NULL,
	[iAddedBy]			INT				NOT NULL,
	[dtEdited]			DATETIME		NULL,
	[iEditedBy]			INT				NULL,
	[iUserID]			VARCHAR(50)		NOT NULL,
	[strFirstname]		VARCHAR(50)		NOT NULL,
	[strSurname]		VARCHAR(50)		NOT NULL,
	[strEmailAddress]	VARCHAR(250)	NOT NULL,
	[strRef]			VARCHAR(50)		NOT NULL,
	[iReasonForChatID]	INT				NULL,
	[iStatusID]			INT				NULL,
	[bIsDeleted]		BIT				NOT NULL,
)