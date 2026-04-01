WITH RankedProductOrders AS (
    SELECT
        order_id,
        order_date,
        product_id,
        DENSE_RANK() OVER (PARTITION BY product_id ORDER BY order_date DESC) AS order_rank
    FROM orders
) SELECT
    p.product_name,
    p.product_id,
    o.order_id,
    o.order_date
FROM RankedProductOrders o
JOIN products p ON o.product_id = p.product_id
WHERE o.order_rank = 1
ORDER BY product_name, product_id, order_id