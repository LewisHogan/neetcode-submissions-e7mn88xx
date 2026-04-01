With event_states AS (
    -- 0 is failed, 1 is succeeded
    SELECT fail_date as event_date, 0 as state
    FROM failed
    WHERE fail_date BETWEEN '2019' AND '2020'

    UNION ALL

    SELECT success_date as event_date, 1 as state
    FROM succeeded
    WHERE success_date BETWEEN '2019' AND '2020'
),
grouped_events AS (
    SELECT *,
        ROW_NUMBER() OVER (ORDER BY event_date) - RANK() OVER (PARTITION BY state ORDER BY event_date) AS rnk
    FROM event_states
) 

SELECT 
    CASE WHEN state = 1 THEN 'succeeded' ELSE 'failed' END as period_state,
    MIN(event_date) AS start_date,
    MAX(event_date) AS end_date
FROM grouped_events
GROUP BY state, rnk
ORDER BY start_date