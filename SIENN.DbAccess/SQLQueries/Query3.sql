--3.	Top 3 kategorie wraz z informacją o liczbie przypisanych, dostępnych produktów oraz średnią ceną produktów w kategorii 
--		(top 3 powinno pokazywać kategorie, których średnia cen produktów jest największa)

SELECT TOP 3 c.Code, COUNT(1) as 'Assigned', AVG(p.Price) as 'Average', SUM(CAST(p.IsAvailable as INT)) as 'Available' 
FROM Categories c
INNER JOIN ProductCategory pc ON c.Id =pc.CategoryId
INNER JOIN Products p ON p.Id = pc.ProductId
GROUP BY c.Code
ORDER BY AVG(p.Price) DESC