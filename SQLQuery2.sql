/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [TagId]
      ,[HashTag]
  FROM [BlogConnection].[dbo].[Tags]

  Insert into Tags (HashTag)
  values ('#Korean'),
  ('#Thai'),
  ('#Americn'),
  ('#Indian'),
  ('#TexMex'),
  ('#FineDining'),
('#FoodTruck'),
  ('#Delicious')

  select * from Tags

  select * from Posts

  Insert into Posts (Title, Author, Description, Content, Published)
  values ('Test 2', 'Dorothy', 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, soluta, eligendi doloribus sunt minus amet sit debitis repellat. Consectetur, culpa itaque odio similique suscipit','ldjf;asdljl', 'false')

  Update Posts 
  set Disclaimer = 'false'
  
  where PostId = 2