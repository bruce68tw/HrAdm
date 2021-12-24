if object_id('dbo.tru_User', 'TR') is not null
   drop trigger dbo.tru_User;  
go
   
create trigger dbo.tru_User
   on dbo.[User]
   after update
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @crud char(1)
	set @now = getdate()
	set @table = 'User'
	set @crud = 'U'
	select @id=Id from deleted

	set nocount on;
	
    if update(Id)
		insert into dbo.XpLog(RowId, TableName, ColName, OldValue, NewValue, Crud, Created) values 
			(@id, @table, 'Id', (select [Id] from deleted), (select [Id] from inserted), @crud, @now);
    if update(Name)
		insert into dbo.XpLog(RowId, TableName, ColName, OldValue, NewValue, Crud, Created) values 
			(@id, @table, 'Name', (select [Name] from deleted), (select [Name] from inserted), @crud, @now);
    if update(Account)
		insert into dbo.XpLog(RowId, TableName, ColName, OldValue, NewValue, Crud, Created) values 
			(@id, @table, 'Account', (select [Account] from deleted), (select [Account] from inserted), @crud, @now);
    if update(Pwd)
		insert into dbo.XpLog(RowId, TableName, ColName, OldValue, NewValue, Crud, Created) values 
			(@id, @table, 'Pwd', (select [Pwd] from deleted), (select [Pwd] from inserted), @crud, @now);
    if update(DeptId)
		insert into dbo.XpLog(RowId, TableName, ColName, OldValue, NewValue, Crud, Created) values 
			(@id, @table, 'DeptId', (select [DeptId] from deleted), (select [DeptId] from inserted), @crud, @now);
    if update(PhotoFile)
		insert into dbo.XpLog(RowId, TableName, ColName, OldValue, NewValue, Crud, Created) values 
			(@id, @table, 'PhotoFile', (select [PhotoFile] from deleted), (select [PhotoFile] from inserted), @crud, @now);
    if update(Status)
		insert into dbo.XpLog(RowId, TableName, ColName, OldValue, NewValue, Crud, Created) values 
			(@id, @table, 'Status', (select [Status] from deleted), (select [Status] from inserted), @crud, @now);
	
end