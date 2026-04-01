-- Write your query below
WITH Res AS (
    SELECT
    *,
    ROW_NUMBER() OVER (PARTITION BY student_id ORDER BY score DESC, exam_id) AS r
    FROM exam_results
)
SELECT student_id, exam_id, score
FROM Res
WHERE r = 1