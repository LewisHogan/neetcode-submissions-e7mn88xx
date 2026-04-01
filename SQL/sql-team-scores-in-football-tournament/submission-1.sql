-- Write your query below
WITH points_per_match AS (
    SELECT
        match_id,
        host_team,
        guest_team,
        case
            when host_goals = guest_goals then 1
            when host_goals < guest_goals then 0
            else 3
        end as host_points,
        case
            when host_goals = guest_goals then 1
            when host_goals < guest_goals then 3
            else 0
        end as guest_points
    FROM matches
)
SELECT 
    team_id,
    team_name,
    COALESCE(
        SUM(case when team_id = host_team then host_points else guest_points end),
        0) as num_points
FROM teams t
LEFT JOIN points_per_match p ON t.team_id = p.host_team OR t.team_id = p.guest_team
GROUP BY team_id, team_name
ORDER BY num_points DESC, team_id