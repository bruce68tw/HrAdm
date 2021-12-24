if object_id('dbo.trc_User', 'TR') is not null
   drop trigger dbo.trc_User;  
go
   
create trigger dbo.trc_User
   on dbo.[User]
   after insert
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @crud char(1)
	set @now = getdate()
	set @table = 'User'
	set @crud = 'C'
	select @id=Id from inserted

	set nocount on;
	
	insert into dbo.XpLog(RowId, TableName, Crud, Created) values 
		(@id, @table, @crud, @now);
	
end