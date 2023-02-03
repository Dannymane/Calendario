CREATE TABLE [dbo].[Events] (
   EventID INT IDENTITY(1,1) PRIMARY KEY,
   Title VARCHAR(100) NOT NULL,
   Day DATE NOT NULL,
   StartTime TIME NOT NULL,
   EndTime TIME NOT NULL,
   Location VARCHAR(100),
   Description TEXT
);

select * from events;