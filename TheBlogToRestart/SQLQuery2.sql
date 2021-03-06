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

  Update Posts
  set Description = 'American chef, author, and television personality. He is a 1978 graduate of the Culinary Institute of America and a veteran of numerous professional kitchens, including many years as executive chef at Brasserie Les Halles. He became widely known for his 2000 book Kitchen Confidential: Adventures in the Culinary Underbelly.'
  where PostId = 15

  Select * from Posts


  Update posts
  set [Image] = 'http://tinyurl.com/z4jwt8p'
  where PostId =19