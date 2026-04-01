WITH OrdersPerCustomer AS (
    SELECT
        order_id,
        customer_id,
        order_date,
        ROW_NUMBER() OVER (PARTITION BY customer_id ORDER BY order_date DESC) AS recency
    FROM orders
) SELECT
    c.name AS customer_name,
    c.customer_id,
    order_id,
    order_date
FROM OrdersPerCustomer o
JOIN customers c ON o.customer_id = c.customer_id
WHERE recency <= 3
ORDER BY customer_name, customer_id, order_date DESC