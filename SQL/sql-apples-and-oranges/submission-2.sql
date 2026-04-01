-- Write your query below
SELECT
    sale_date,
    SUM(case when fruit = 'apples' then sold_num else 0 end)
    - SUM(case when fruit = 'oranges' then sold_num else 0 end) AS diff
FROM sales
GROUP BY sale_date
ORDER BY sale_date