/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [PostId]
      ,[Title]
      ,[PostDate]
      ,[EndDate]
      ,[Image]
      ,[Address]
      ,[Author]
      ,[Description]
      ,[Content]
      ,[Published]
  FROM [BlogConnection].[dbo].[Posts]

