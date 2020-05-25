use MyTrello

select * from Users

select * from Tasks

alter table Tasks add isArchived bit

EXEC sp_rename 'Tasks.isArchived', 'IsArchived', 'COLUMN';

