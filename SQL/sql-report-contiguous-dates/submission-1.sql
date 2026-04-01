WITH all_dates AS (
    select fail_date as event_date, 'failed' as event
    from failed
    where fail_date between '2019-01-01' and '2019-12-31 23:59:59'
    union all
    select success_date as event_date, 'succeeded' as event
    from succeeded
    where success_date between '2019-01-01' and '2019-12-31 23:59:59'
), ranked as (
    select
        event_date,
        event,
        row_number() over (partition by event order by event_date) as event_rn,
        row_number() over (order by event_date) as rn
    from all_dates
), grped as (
    select
        event as period_state,
        MIN(event_date) as start_date,
        MAX(event_date) as end_date
    from ranked
    GROUP BY event, rn - event_rn
) select * from grped order by start_date, end_date