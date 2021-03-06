USE [MateuszThomasZad5WebApi]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 11.12.2017 05:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](63) NOT NULL,
	[Surname] [nvarchar](63) NOT NULL,
	[Email] [nvarchar](127) NOT NULL,
	[PhoneNumber] [nchar](9) NOT NULL,
	[IndexNumber] [nchar](6) NOT NULL,
	[UniversityID] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 11.12.2017 05:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](127) NOT NULL,
	[Deadline] [datetime2](7) NOT NULL,
	[StudentID] [int] NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[University]    Script Date: 11.12.2017 05:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[University](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](63) NOT NULL,
 CONSTRAINT [PK_FieldOfStudy] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([ID], [Name], [Surname], [Email], [PhoneNumber], [IndexNumber], [UniversityID]) VALUES (1, N'Mateusz', N'Nowak', N'mateusz.nowak@gmail.com', N'123456789', N'226444', 1)
INSERT [dbo].[Students] ([ID], [Name], [Surname], [Email], [PhoneNumber], [IndexNumber], [UniversityID]) VALUES (2, N'Kamil', N'Kowalski', N'kamil.kowalski@gmail.com', N'234567890', N'225888', 1)
INSERT [dbo].[Students] ([ID], [Name], [Surname], [Email], [PhoneNumber], [IndexNumber], [UniversityID]) VALUES (4, N'Kamil', N'Nowak', N'kamil.nowak@gmail.com', N'566734978', N'226456', 1)
INSERT [dbo].[Students] ([ID], [Name], [Surname], [Email], [PhoneNumber], [IndexNumber], [UniversityID]) VALUES (5, N'Dominik', N'Wolny', N'dominik.wolny@gmail.com', N'678924554', N'225456', 1)
INSERT [dbo].[Students] ([ID], [Name], [Surname], [Email], [PhoneNumber], [IndexNumber], [UniversityID]) VALUES (6, N'Dawid', N'Kowal', N'dawid.kowal@gmail.com', N'243452345', N'199456', 2)
INSERT [dbo].[Students] ([ID], [Name], [Surname], [Email], [PhoneNumber], [IndexNumber], [UniversityID]) VALUES (7, N'Tomek', N'Brudny', N'tomek.brudny@gmail.com', N'432253345', N'225662', 2)
INSERT [dbo].[Students] ([ID], [Name], [Surname], [Email], [PhoneNumber], [IndexNumber], [UniversityID]) VALUES (8, N'Szymon', N'Nowakowski', N'szymon.nowakowski@gmail.com', N'655456789', N'226421', 3)
INSERT [dbo].[Students] ([ID], [Name], [Surname], [Email], [PhoneNumber], [IndexNumber], [UniversityID]) VALUES (9, N'Marta', N'Stroka', N'marta.stroka@gmail.com', N'567834176', N'225442', 3)
SET IDENTITY_INSERT [dbo].[Students] OFF
SET IDENTITY_INSERT [dbo].[Tasks] ON 

INSERT [dbo].[Tasks] ([ID], [Name], [Deadline], [StudentID]) VALUES (2, N'Program na grafike', CAST(N'2017-12-15 00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Tasks] ([ID], [Name], [Deadline], [StudentID]) VALUES (3, N'Sprawozdanie na grafike', CAST(N'2017-12-15 00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Tasks] ([ID], [Name], [Deadline], [StudentID]) VALUES (4, N'Projekt na sieci komputerowe', CAST(N'2017-12-16 00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Tasks] ([ID], [Name], [Deadline], [StudentID]) VALUES (5, N'Projekt z projektowania efektywnych algorytmow', CAST(N'2017-12-14 00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Tasks] ([ID], [Name], [Deadline], [StudentID]) VALUES (6, N'Program na bazy danych', CAST(N'2017-12-15 00:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[Tasks] ([ID], [Name], [Deadline], [StudentID]) VALUES (7, N'Projekt na grafike', CAST(N'2017-12-16 00:00:00.0000000' AS DateTime2), 5)
INSERT [dbo].[Tasks] ([ID], [Name], [Deadline], [StudentID]) VALUES (8, N'Sprawozdanie na grafike', CAST(N'2017-12-15 00:00:00.0000000' AS DateTime2), 5)
INSERT [dbo].[Tasks] ([ID], [Name], [Deadline], [StudentID]) VALUES (9, N'Referat anatomia', CAST(N'2017-12-20 00:00:00.0000000' AS DateTime2), 8)
INSERT [dbo].[Tasks] ([ID], [Name], [Deadline], [StudentID]) VALUES (10, N'Referat anatomia', CAST(N'2017-12-21 00:00:00.0000000' AS DateTime2), 9)
INSERT [dbo].[Tasks] ([ID], [Name], [Deadline], [StudentID]) VALUES (11, N'Projekt z projektowania efektywnych algorytmów', CAST(N'2017-12-20 00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Tasks] ([ID], [Name], [Deadline], [StudentID]) VALUES (12, N'Projekt z zarzadzania sieciami informatycznymi', CAST(N'2017-12-19 00:00:00.0000000' AS DateTime2), 6)
INSERT [dbo].[Tasks] ([ID], [Name], [Deadline], [StudentID]) VALUES (13, N'Aplikacja mobilna', CAST(N'2017-12-18 00:00:00.0000000' AS DateTime2), 7)
INSERT [dbo].[Tasks] ([ID], [Name], [Deadline], [StudentID]) VALUES (14, N'Sprawozdanie z fizyki', CAST(N'2017-12-18 00:00:00.0000000' AS DateTime2), 7)
INSERT [dbo].[Tasks] ([ID], [Name], [Deadline], [StudentID]) VALUES (15, N'Projekt bioinformatyka', CAST(N'2017-12-22 00:00:00.0000000' AS DateTime2), 9)
SET IDENTITY_INSERT [dbo].[Tasks] OFF
SET IDENTITY_INSERT [dbo].[University] ON 

INSERT [dbo].[University] ([ID], [Name]) VALUES (1, N'Politechnika Wrocławska')
INSERT [dbo].[University] ([ID], [Name]) VALUES (2, N'Uniwersytet Wrocławski')
INSERT [dbo].[University] ([ID], [Name]) VALUES (3, N'Uniwersytet Medyczny we Wrocławiu')
SET IDENTITY_INSERT [dbo].[University] OFF
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_University] FOREIGN KEY([UniversityID])
REFERENCES [dbo].[University] ([ID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_University]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([ID])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Students]
GO
