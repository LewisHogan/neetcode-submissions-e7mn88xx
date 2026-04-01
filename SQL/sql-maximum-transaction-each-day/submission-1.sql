With RankedTransactionsPerDay AS (
    SELECT
        transaction_id,
        DENSE_RANK() OVER (PARTITION BY day::DATE ORDER BY amount DESC) as rnk
    FROM transactions
) SELECT 
    transaction_id
FROM RankedTransactionsPerDay
WHERE rnk = 1
ORDER by transaction_id