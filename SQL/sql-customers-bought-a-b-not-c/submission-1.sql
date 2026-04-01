With CustomersToAvoid AS (
    SELECT c.customer_id
    FROM customers c
    JOIN Orders o ON c.customer_id = o.customer_id
    WHERE product_name = 'C'
), PotentialTargets AS (SELECT
o.customer_id
FROM orders o
JOIN orders o2 ON o.customer_id = o2.customer_id AND o2.product_name = 'B'
JOIN customers c on o.customer_id = c.customer_id
WHERE o.product_name = 'A'

EXCEPT

SELECT customer_id FROM CustomersToAvoid
) SELECT p.customer_id, customer_name
FROM PotentialTargets p
JOIN customers c on p.customer_id = c.customer_id
ORDER BY customer_name