create table events(
    event_id uuid not null primary key,
    event_payload varchar not null,
    aggregate_id uuid not null,
    event_type varchar not null
);