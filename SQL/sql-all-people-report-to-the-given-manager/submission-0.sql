With Recursive EmployeeLookup AS (
    SELECT
        employee_id, 
        employee_name,
        manager_id
    FROM employees
    WHERE employee_id = 1

    UNION
    
    SELECT e2.employee_id,
        e2.employee_name,
        e2.manager_id
    FROM EmployeeLookup e
    JOIN Employees e2 on e.employee_id = e2.manager_id
) SELECT employee_id FROM EmployeeLookup where employee_id != 1