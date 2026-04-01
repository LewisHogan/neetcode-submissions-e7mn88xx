WITH exam_rankings AS (
    SELECT
        student_id,
        DENSE_RANK() OVER (PARTITION BY exam_id ORDER BY score DESC) AS best_exam_rank,
        DENSE_RANK() OVER (PARTITION BY exam_id ORDER BY score) AS worst_exam_rank
    FROM exam
) SELECT e.student_id, student_name
FROM exam_rankings e
JOIN student s on e.student_id = s.student_id
GROUP BY e.student_id, student_name
HAVING MIN(best_exam_rank) != 1 AND MIN(worst_exam_rank) != 1
ORDER BY e.student_id