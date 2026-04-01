-- Write your query below
SELECT DISTINCT sale_date, 

    (select sold_num from sales s2 where s2.fruit = 'apples' AND s.sale_date = s2.sale_date)
    - (select sold_num from sales s2 where s2.fruit = 'oranges' AND s.sale_date = s2.sale_date) AS diff
FROM sales S
ORDER BY sale_date