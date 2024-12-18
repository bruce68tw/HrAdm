/*=== Leave table start ===*/
--trigger Create
if object_id('trc_Leave', 'TR') is not null
   drop trigger trc_Leave;  
go
   
create trigger trc_Leave
   on dbo.[Leave]
   after insert
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'Leave'
	set @act = 'Create'
	select @id=Id from inserted

	set nocount on;
	
	insert into dbo.XpTranLog(RowId, TableName, Act, Created) values 
		(@id, @table, @act, @now);
	
end
go

--trigger Update
if object_id('tru_Leave', 'TR') is not null
   drop trigger tru_Leave;  
go
   
create trigger tru_Leave
   on dbo.[Leave]
   after update
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'Leave'
	set @act = 'Update'
	select @id=Id from deleted

	set nocount on;	
	
    if update(Id)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Id', (select[Id] from deleted), (select[Id] from inserted), @act, @now);
    if update(UserId)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'UserId', (select[UserId] from deleted), (select[UserId] from inserted), @act, @now);
    if update(AgentId)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'AgentId', (select[AgentId] from deleted), (select[AgentId] from inserted), @act, @now);
    if update(LeaveType)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'LeaveType', (select[LeaveType] from deleted), (select[LeaveType] from inserted), @act, @now);
    if update(StartTime)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'StartTime', (select[StartTime] from deleted), (select[StartTime] from inserted), @act, @now);
    if update(EndTime)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'EndTime', (select[EndTime] from deleted), (select[EndTime] from inserted), @act, @now);
    if update(Hours)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Hours', (select[Hours] from deleted), (select[Hours] from inserted), @act, @now);
    if update(FlowLevel)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'FlowLevel', (select[FlowLevel] from deleted), (select[FlowLevel] from inserted), @act, @now);
    if update(FlowStatus)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'FlowStatus', (select[FlowStatus] from deleted), (select[FlowStatus] from inserted), @act, @now);
    if update(FileName)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'FileName', (select[FileName] from deleted), (select[FileName] from inserted), @act, @now);
    if update(Status)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Status', (select[Status] from deleted), (select[Status] from inserted), @act, @now);
	
end
go

--trigger Delete
if object_id('trd_Leave', 'TR') is not null
   drop trigger trd_Leave;  
go
   
create trigger trd_Leave
   on dbo.[Leave]
   after delete
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'Leave'
	set @act = 'Delete'
	select @id=Id from deleted

	set nocount on;
	
	insert into dbo.XpTranLog(RowId, TableName, Act, Created) values 
		(@id, @table, @act, @now);
	
end
go
/*=== Leave table end ===*/

/*=== User table start ===*/
--trigger Create
if object_id('trc_User', 'TR') is not null
   drop trigger trc_User;  
go
   
create trigger trc_User
   on dbo.XpUser
   after insert
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'XpUser'
	set @act = 'Create'
	select @id=Id from inserted

	set nocount on;
	
	insert into dbo.XpTranLog(RowId, TableName, Act, Created) values 
		(@id, @table, @act, @now);
	
end
go

--trigger Update
if object_id('tru_User', 'TR') is not null
   drop trigger tru_User;  
go
   
create trigger tru_User
   on dbo.XpUser
   after update
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'XpUser'
	set @act = 'Update'
	select @id=Id from deleted

	set nocount on;	
	
    if update(Id)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Id', (select[Id] from deleted), (select[Id] from inserted), @act, @now);
    if update(Name)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Name', (select[Name] from deleted), (select[Name] from inserted), @act, @now);
    if update(Account)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Account', (select[Account] from deleted), (select[Account] from inserted), @act, @now);
    if update(Pwd)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Pwd', (select[Pwd] from deleted), (select[Pwd] from inserted), @act, @now);
    if update(DeptId)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'DeptId', (select[DeptId] from deleted), (select[DeptId] from inserted), @act, @now);
    if update(PhotoFile)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'PhotoFile', (select[PhotoFile] from deleted), (select[PhotoFile] from inserted), @act, @now);
    if update(Status)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Status', (select[Status] from deleted), (select[Status] from inserted), @act, @now);
	
end
go

--trigger Delete
if object_id('trd_User', 'TR') is not null
   drop trigger trd_User;  
go
   
create trigger trd_User
   on dbo.XpUser
   after delete
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'XpUser'
	set @act = 'Delete'
	select @id=Id from deleted

	set nocount on;
	
	insert into dbo.XpTranLog(RowId, TableName, Act, Created) values 
		(@id, @table, @act, @now);
	
end
go
/*=== User table end ===*/

