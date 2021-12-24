if object_id('dbo.trd_User', 'TR') is not null
   drop trigger dbo.trd_User;  
go
   
create trigger dbo.trd_User
   on dbo.[User]
   after delete
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @crud char(1)
	set @now = getdate()
	set @table = 'User'
	set @crud = 'D'
	select @id=Id from deleted

	set nocount on;
	
	insert into dbo.XpLog(RowId, TableName, Crud, Created) values 
		(@id, @table, @crud, @now);
	
end