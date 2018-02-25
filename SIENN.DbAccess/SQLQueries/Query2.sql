-- 2.	Dostępne produkty, które są przypisane do więcej niż jednej kategorii

SELECT p.Id, p.Code, COUNT(1) as 'In categories'
FROM Products p
INNER JOIN ProductCategory pc ON p.Id= pc.ProductId
WHERE p.IsAvailable = 1
GROUP BY p.Id, p.Code
HAVING COUNT(1) > 1