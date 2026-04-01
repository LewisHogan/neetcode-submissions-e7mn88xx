With TeamSize AS (
    SELECT team_id, COUNT(*) As team_size
    FROM employee
    GROUP BY team_id
) 
SELECT employee_id, team_size
FROM employee E JOIN TeamSize T ON E.team_id = T.team_id