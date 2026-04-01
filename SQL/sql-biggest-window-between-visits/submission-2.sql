WITH ordered_visits AS (
    SELECT 
        user_id,
        COALESCE(LEAD(visit_date) OVER (PARTITION BY user_id ORDER BY visit_date) - visit_date, '2021-1-1' - visit_date) AS window_size
    FROM (SELECT DISTINCT user_id, visit_date FROM user_visits)
) SELECT
    user_id,
    MAX(window_size) AS biggest_window
FROM ordered_visits
GROUP BY user_id
ORDER BY user_id