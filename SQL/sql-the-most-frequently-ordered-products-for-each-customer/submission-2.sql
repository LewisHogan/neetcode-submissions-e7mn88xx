WITH CustomerOrders AS (SELECT
    customer_id,
    product_id,
    DENSE_RANK() OVER (PARTITION BY customer_id ORDER BY COUNT(product_id) DESC) AS ranked_order_count
FROM orders
GROUP BY customer_id, product_id
)
SELECT
    c.customer_id,
    co.product_id,
    p.product_name
FROM CustomerOrders co
JOIN customers c ON co.customer_id = c.customer_id
JOIN products p on co.product_id = p.product_id
WHERE ranked_order_count = 1