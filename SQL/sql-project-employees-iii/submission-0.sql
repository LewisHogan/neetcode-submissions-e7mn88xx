WITH Ranked AS (
    SELECT
        P.project_id,
        P.employee_id,
        DENSE_RANK() OVER (PARTITION BY project_id ORDER BY experience_years DESC) as rank_exp
    FROM project P
    JOIN employee E ON P.employee_id = E.employee_id
) SELECT project_id, employee_id
FROM Ranked WHERE rank_exp = 1 