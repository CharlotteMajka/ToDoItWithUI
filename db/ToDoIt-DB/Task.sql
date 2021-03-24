CREATE TABLE [dbo].[Task]
(
  [TaskId] INT NOT NULL,
  [Description] NVARCHAR(255) NOT NULL,
  [IsCompleted] BIT NOT NULL,
  [DueDate] DATETIME2, 
  [AssigneeId] INT  NOT NULL,
  CONSTRAINT [PK_Task] PRIMARY KEY (TaskId),
  CONSTRAINT [FK_AssigneeID]  FOREIGN KEY (AssigneeId) REFERENCES [dbo].[Assignee](Id)
  ON DELETE CASCADE
)


