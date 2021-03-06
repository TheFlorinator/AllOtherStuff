USE [ForthDimension]
GO
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([PostId], [Title], [Image], [Author], [Content], [Published], [AddressId], [PostDate], [EndDate], [Description]) VALUES (3, N'Once upon a time at Chipotle', N'http://tinyurl.com/jp6c432', N'Jason Florin', N'This is the content for once upon a time in Chipotle', N'True      ', NULL, CAST(N'2016-11-30' AS Date), NULL, N'This is the story of my journey to and through chipotle                                             ')
INSERT [dbo].[Posts] ([PostId], [Title], [Image], [Author], [Content], [Published], [AddressId], [PostDate], [EndDate], [Description]) VALUES (4, N'The depths of Kudai', N'http://tinyurl.com/zr6qznh', N'John Cena', N'This is the content for the depths of Kudai', N'True      ', NULL, CAST(N'2016-11-30' AS Date), NULL, N'This is the story of my journey to and through Kudai                                                ')
INSERT [dbo].[Posts] ([PostId], [Title], [Image], [Author], [Content], [Published], [AddressId], [PostDate], [EndDate], [Description]) VALUES (5, N'The Heart of McDonalds', N'http://tinyurl.com/hsl7mdr', N'Zach Robinson', N'This is the content for the heart of Mcdonalds', N'True      ', NULL, CAST(N'2016-10-19' AS Date), NULL, N'This is the story of the Heart of McDonalds                                                         ')
INSERT [dbo].[Posts] ([PostId], [Title], [Image], [Author], [Content], [Published], [AddressId], [PostDate], [EndDate], [Description]) VALUES (6, N'The walk through Mirror of Korea', N'http://tinyurl.com/zf3qu83', N'Dorothy Blaike', N'This is the content for the Mirror of Korea', N'True      ', NULL, CAST(N'2016-10-23' AS Date), NULL, N'This is the story of the Mirror of Korea                                                            ')
INSERT [dbo].[Posts] ([PostId], [Title], [Image], [Author], [Content], [Published], [AddressId], [PostDate], [EndDate], [Description]) VALUES (7, N'The Ocean of India', N'http://tinyurl.com/hq7ll83', N'Randy Orton', N'This is the content for The Taste of India', N'True      ', NULL, CAST(N'2016-10-23' AS Date), NULL, N'This is the story of The Taste of India                                                             ')
INSERT [dbo].[Posts] ([PostId], [Title], [Image], [Author], [Content], [Published], [AddressId], [PostDate], [EndDate], [Description]) VALUES (8, N'The Deliciousness', N'http://tinyurl.com/znndqu2', N'Arnold', N'This is the content for a tasty place', N'True      ', NULL, CAST(N'2016-10-04' AS Date), NULL, N'This is the story a tasty place                                                                     ')
SET IDENTITY_INSERT [dbo].[Posts] OFF
SET IDENTITY_INSERT [dbo].[HashTags] ON 

INSERT [dbo].[HashTags] ([HashTagId], [HashTag]) VALUES (1, N'#FineDining         ')
INSERT [dbo].[HashTags] ([HashTagId], [HashTag]) VALUES (2, N'#Asian              ')
INSERT [dbo].[HashTags] ([HashTagId], [HashTag]) VALUES (3, N'#Indian             ')
INSERT [dbo].[HashTags] ([HashTagId], [HashTag]) VALUES (4, N'#American           ')
INSERT [dbo].[HashTags] ([HashTagId], [HashTag]) VALUES (5, N'#Mexican            ')
INSERT [dbo].[HashTags] ([HashTagId], [HashTag]) VALUES (6, N'#Delicious          ')
SET IDENTITY_INSERT [dbo].[HashTags] OFF
