SELECT
    o.customer_id,
    c.customer_name
FROM orders o
JOIN customers c ON c.customer_id = o.customer_id
GROUP BY o.customer_id, customer_name
HAVING COUNT(DISTINCT CASE WHEN product_name = 'A' THEN 1 END) > 0
AND COUNT(DISTINCT CASE WHEN product_name = 'B' THEN 1 END) > 0
AND COUNT(DISTINCT CASE WHEN product_name = 'C' THEN 1 END) = 0
ORDER BY customer_name