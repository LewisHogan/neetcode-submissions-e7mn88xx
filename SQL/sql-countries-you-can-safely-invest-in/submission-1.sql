SELECT
    c1.name AS country
FROM person p
JOIN country c1 on LEFT(p.phone_number, 3) = c1.country_code
JOIN calls c2 ON p.id = c2.caller_id OR p.id = c2.callee_id
GROUP BY c1.name
HAVING AVG(c2.duration) > (SELECT AVG(duration) FROM calls)