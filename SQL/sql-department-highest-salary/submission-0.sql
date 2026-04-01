-- Write your query below
WITH MaxSalaryPerDepartment AS (
    SELECT
    department_id,
    MAX(salary) as maxSalary
    FROM employee
    GROUP BY department_id
)
SELECT 
d.name as department,
e.name as employee,
e.salary
FROM MaxSalaryPerDepartment M
Join department d ON M.department_id = d.id
JOIN employee e
ON d.id = e.department_id
WHERE e.salary = maxSalary