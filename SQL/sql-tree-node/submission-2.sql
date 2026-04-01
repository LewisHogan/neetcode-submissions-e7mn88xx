SELECT
    id,
    CASE
        when p_id is null THEN 'Root'
        when id IN (SELECT p_id FROM tree WHERE p_id IS NOT NULL) THEN 'Inner'
        else 'Leaf'
    END AS type
FROM tree