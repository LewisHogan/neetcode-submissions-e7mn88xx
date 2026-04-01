SELECT DISTINCT o.account_id FROM log_info o
JOIN log_info l ON l.login <= o.logout AND l.logout >= o.login 
    AND l.account_id = o.account_id AND l.ip_address != o.ip_address