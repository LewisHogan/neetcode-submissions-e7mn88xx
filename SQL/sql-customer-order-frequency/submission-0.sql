WITH spend_per_month AS (
    select
        customer_id,
        SUM(quantity * price) AS price,
        date_part('month', order_date) as order_month
    FROM orders o
    JOIN product p on o.product_id = p.product_id
    WHERE o.order_date BETWEEN '1 June 2020' AND '1 Aug 2020'
    GROUP BY customer_id, date_part('month', order_date)
) SELECT s.customer_id, name from spend_per_month s
join customers c on s.customer_id = c.customer_id
GROUP BY s.customer_id, name
HAVING COUNT(*) >= 2 AND MIN(price) >= 100