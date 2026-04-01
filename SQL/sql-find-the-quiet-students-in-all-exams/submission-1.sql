With ExamMetadata AS (
    SELECT
        exam_id,
        MIN(score) AS min_exam_score,
        MAX(score) as max_exam_score
    FROM exam
    GROUP BY exam_id
),
LoudStudents AS (
    SELECT DISTINCT student_id
    FROM Exam E
    JOIN ExamMetadata EM ON E.exam_id = EM.exam_id
    WHERE E.score = EM.min_exam_score OR E.score = EM.max_exam_score
)
SELECT DISTINCT
    E.student_id,
    S.student_name
FROM exam E
JOIN student S ON E.student_id = S.student_id
LEFT JOIN LoudStudents L ON E.student_id = L.student_id
WHERE L.student_id IS NULL