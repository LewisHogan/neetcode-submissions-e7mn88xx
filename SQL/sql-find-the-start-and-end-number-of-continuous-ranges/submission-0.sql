-- Write your query below
WITH grouped_logs AS (
    SELECT
        log_id,
        log_id - ROW_NUMBER() OVER (ORDER BY log_id) AS grp
    FROM logs
) SELECT min(log_id) AS start_id, max(log_id) AS end_id FROM grouped_logs
GROUP by grp
ORDER BY start_id