SET IDENTITY_INSERT [dbo].[CarSale] ON
INSERT INTO [dbo].[CarSale] ([ID], [CustomerID], [SalePersonID]) VALUES (1, 1, 1)
INSERT INTO [dbo].[CarSale] ([ID], [CustomerID], [SalePersonID]) VALUES (2, 2, 2)
INSERT INTO [dbo].[CarSale] ([ID], [CustomerID], [SalePersonID]) VALUES (3, 3, 3)
INSERT INTO [dbo].[CarSale] ([ID], [CustomerID], [SalePersonID]) VALUES (4, 4, 4)
SET IDENTITY_INSERT [dbo].[CarSale] OFF

SET IDENTITY_INSERT [dbo].[Center] ON
INSERT INTO [dbo].[Center] ([CenterID], [CenterName], [Address], [OpeningDate]) VALUES (1, N'Terapa cars', N'65 Teraparoad', N'2018-08-07 00:00:00')
INSERT INTO [dbo].[Center] ([CenterID], [CenterName], [Address], [OpeningDate]) VALUES (2, N'Hamilton East', N'34 tearoha', N'2019-09-30 00:00:00')
INSERT INTO [dbo].[Center] ([CenterID], [CenterName], [Address], [OpeningDate]) VALUES (3, N'frankton', N'Newton road', N'2020-05-13 00:00:00')
INSERT INTO [dbo].[Center] ([CenterID], [CenterName], [Address], [OpeningDate]) VALUES (4, N'Dindsdale', N'Kilarney road', N'2021-01-01 00:00:00')
SET IDENTITY_INSERT [dbo].[Center] OFF

SET IDENTITY_INSERT [dbo].[Customer] ON
INSERT INTO [dbo].[Customer] ([CustomerID], [CustomerFName], [CustomerLName], [Address], [Phone]) VALUES (1, N'Lisa', N'Emye', N'pyespa tauranga tauranga', N'0225068196')
INSERT INTO [dbo].[Customer] ([CustomerID], [CustomerFName], [CustomerLName], [Address], [Phone]) VALUES (2, N'Kenny', N'Frank', N'83 waterside Dr', N'0221007473')
INSERT INTO [dbo].[Customer] ([CustomerID], [CustomerFName], [CustomerLName], [Address], [Phone]) VALUES (3, N'Linda', N'Lilly', N'55 maitland street ', N'0221232323')
INSERT INTO [dbo].[Customer] ([CustomerID], [CustomerFName], [CustomerLName], [Address], [Phone]) VALUES (4, N'Sunny', N'doel', N'34 tearoha', N'022345678')
SET IDENTITY_INSERT [dbo].[Customer] OFF

SET IDENTITY_INSERT [dbo].[SalePerson] ON
INSERT INTO [dbo].[SalePerson] ([SalePersonId], [SalePersonsName], [AgreedAmount], [SaleDate]) VALUES (1, N'Cerry', 55000, N'2021-01-26 00:00:00')
INSERT INTO [dbo].[SalePerson] ([SalePersonId], [SalePersonsName], [AgreedAmount], [SaleDate]) VALUES (2, N'jim', 45000, N'2021-01-08 00:00:00')
INSERT INTO [dbo].[SalePerson] ([SalePersonId], [SalePersonsName], [AgreedAmount], [SaleDate]) VALUES (3, N'Jack', 65000, N'2021-01-13 00:00:00')
INSERT INTO [dbo].[SalePerson] ([SalePersonId], [SalePersonsName], [AgreedAmount], [SaleDate]) VALUES (4, N'Sonal', 45000, N'2021-01-17 00:00:00')
SET IDENTITY_INSERT [dbo].[SalePerson] OFF


