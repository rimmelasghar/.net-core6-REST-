USE [WE_SECA]
GO
/****** Object:  Table [dbo].[tbl_Course]    Script Date: 2/5/2023 7:06:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](255) NULL,
	[CourseFee] [float] NULL,
	[CreditHour] [varchar](10) NULL,
	[CourseCode] [varchar](10) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_tbl_Course] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Room]    Script Date: 2/5/2023 7:06:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Room](
	[RID] [int] IDENTITY(1,1) NOT NULL,
	[RoomName] [nvarchar](50) NOT NULL,
	[RoomDesc] [varchar](255) NOT NULL,
 CONSTRAINT [PK_tbl_Room] PRIMARY KEY CLUSTERED 
(
	[RID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TimeSlot]    Script Date: 2/5/2023 7:06:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TimeSlot](
	[TSId] [int] IDENTITY(1,1) NOT NULL,
	[TSCode] [varchar](50) NOT NULL,
	[StartTime] [varchar](50) NOT NULL,
	[EndTime] [varchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[RID] [int] NOT NULL,
 CONSTRAINT [PK_tbl_TimeSlot] PRIMARY KEY CLUSTERED 
(
	[TSId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Todo]    Script Date: 2/5/2023 7:06:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Todo](
	[TID] [int] IDENTITY(1,1) NOT NULL,
	[Todo] [varchar](255) NULL,
	[Category] [varchar](255) NULL,
	[priority] [varchar](255) NULL,
	[Status] [int] NULL,
	[Due_Date] [date] NULL,
 CONSTRAINT [PK_Todo] PRIMARY KEY CLUSTERED 
(
	[TID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_TimeSlot]  WITH CHECK ADD  CONSTRAINT [FK__tbl_TimeSlo__RID__60A75C0F] FOREIGN KEY([RID])
REFERENCES [dbo].[tbl_Room] ([RID])
GO
ALTER TABLE [dbo].[tbl_TimeSlot] CHECK CONSTRAINT [FK__tbl_TimeSlo__RID__60A75C0F]
GO
/****** Object:  StoredProcedure [dbo].[Course_GetAll]    Script Date: 2/5/2023 7:06:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Course_GetAll]
AS
SELECT * FROM tbl_Course
go;
GO
/****** Object:  StoredProcedure [dbo].[Course_Save]    Script Date: 2/5/2023 7:06:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Course_Save]
	@ParamTable1 varchar(50),
	@ParamTable2 varchar(50),
	@ParamTable3 varchar(50),
	@ParamTable4 varchar(50)
AS
BEGIN
	INSERT INTO tbl_Course(CourseName,CourseFee,CreditHour,CourseCode)
	VALUES(@ParamTable1,@ParamTable2,@ParamTable3,@ParamTable4)
END
GO
/****** Object:  StoredProcedure [dbo].[GetTimeSlotList]    Script Date: 2/5/2023 7:06:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetTimeSlotList]
AS
SELECT * FROM tbl_TimeSlot
go;
GO
/****** Object:  StoredProcedure [dbo].[TimeSlot_Save]    Script Date: 2/5/2023 7:06:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[TimeSlot_Save]
	@ParamTable1 varchar(50),
	@ParamTable2 varchar(50),
	@ParamTable3 varchar(50)
AS
BEGIN
	INSERT INTO tbl_TimeSlot(TSCode,StartTime,EndTime)
	VALUES(@ParamTable1,@ParamTable2,@ParamTable3)
END
GO
