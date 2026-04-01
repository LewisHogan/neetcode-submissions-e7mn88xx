-- Write your query below
WITH Mem AS (
    SELECT
    v1.value AS l,
    E.*,
    V2.value AS r
    FROM
    Variables V1
    JOIN Expressions E ON V1.name = E.left_operand
    JOIN Variables V2 ON V2.name = E.right_operand
)
SELECT
left_operand, operator, right_operand,
case
when operator = '=' then l = r
when operator = '>' then l > r
when operator = '<' then l < r
end as value

FROM
MEM