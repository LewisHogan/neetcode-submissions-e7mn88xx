-- Write your query below
SELECT name
FROM customers C LEFT JOIN
ORDERS O on C.Id = O.Customer_ID
WHERE Customer_ID IS NULL