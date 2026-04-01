WITH RECURSIVE Subtasks AS (
    SELECT 
        task_id,
        subtasks_count AS subtask_id
    FROM tasks

    UNION ALL

    SELECT
        task_id,
        subtask_id - 1 AS subtask_id
    FROM Subtasks
    WHERE subtask_id > 1
) SELECT * FROM Subtasks EXCEPT
SELECT * FROM executed