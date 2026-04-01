With Friends AS (
    SELECT user2_id AS friend_id
    FROM friendship
    WHERE user1_id = 1

    UNION
    SELECT user1_id AS friend_id
    FROM friendship
    WHERE user2_id = 1
)
SELECT page_id AS recommended_page FROM Likes L
JOIN Friends F ON F.friend_id = L.user_id

EXCEPT
SELECT page_id FROM likes
WHERE user_id = 1