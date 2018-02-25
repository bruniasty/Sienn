-- 1.	Niedostępne produkty, których dostawa jest przewidywana w bieżącym miesiącu
SELECT * FROM [Products]
WHERE IsAvailable = 0 AND MONTH(DeliveryDate) = MONTH(GETDATE()) AND YEAR(DeliveryDate) = YEAR(GETDATE()) 