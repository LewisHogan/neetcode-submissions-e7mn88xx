With IdToCountry AS (
    SELECT
        p.id,
        country_code
    FROM person p
    JOIN country c ON LEFT(phone_number, 3) = c.country_code
), CallsInvolvingCountry AS (
    SELECT
        i.country_code,
        AVG(duration) AS average_call_duration
    FROM calls c
    JOIN IdToCountry i ON c.caller_id = i.id OR c.callee_id = i.id
    GROUP BY i.country_code
) SELECT
    c2.name AS country
FROM CallsInvolvingCountry c1
JOIN country c2 ON c1.country_code = c2.country_code
WHERE average_call_duration > (SELECT AVG(duration) FROM calls)