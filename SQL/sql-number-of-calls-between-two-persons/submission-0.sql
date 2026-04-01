-- Write your query below
WITH sortedCalls AS (
    SELECT
        LEAST(from_id, to_id) AS person1,
        GREATEST(from_id, to_id) AS person2,
        duration
    FROM calls
)
SELECT
    person1,
    person2,
    COUNT(*) AS call_count,
    SUM(duration) AS total_duration
FROM sortedCalls
GROUP BY person1, person2
