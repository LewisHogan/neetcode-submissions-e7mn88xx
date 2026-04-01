WITH ranked_player_devices AS (
    SELECT player_id, device_id, RANK() OVER (PARTITION BY player_id ORDER BY event_date) as ranking
    FROM activity
) SELECT player_id, device_id
FROM ranked_player_devices
WHERE ranking = 1