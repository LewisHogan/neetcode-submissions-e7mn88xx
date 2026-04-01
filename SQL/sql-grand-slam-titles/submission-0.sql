With PlayerScores AS (
    SELECT wimbledon AS player_id FROM championships
    UNION ALL SELECT fr_open FROM championships
    UNION ALL SELECT us_open FROM championships
    UNION ALL SELECT au_open FROM championships
) SELECT 
    ps.player_id,
    player_name,
    COUNT(*) AS grand_slams_count
FROM PlayerScores ps
JOIN players p on ps.player_id = p.player_id
GROUP BY ps.player_id, player_name