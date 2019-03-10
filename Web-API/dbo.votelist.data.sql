SET IDENTITY_INSERT [dbo].[votelist] ON
INSERT INTO [dbo].[votelist] ([ItemId], [title], [Statue], [Username], [StopTime], [ItemNum]) VALUES (1, N'first title', 1, N'aa', NULL, 0)
INSERT INTO [dbo].[votelist] ([ItemId], [title], [Statue], [Username], [StopTime], [ItemNum]) VALUES (2, N'大', 1, N'cc', NULL, NULL)
SET IDENTITY_INSERT [dbo].[votelist] OFF
