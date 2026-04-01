SELECT DISTINCT
    t.id,
    CASE
        when t.p_id is null THEN 'Root'
        when t2.p_id = t.id THEN 'Inner'
        else 'Leaf'
    END AS type
FROM tree t
LEFT JOIN tree t2 ON t.id = t2.p_id