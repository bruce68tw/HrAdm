
declare @flowId varchar(10)
set @flowId = '5ZMDKNA0CA'

select * from Flow where Id=@flowId
select * from FlowNode where FlowId=@flowId
select * from FlowLine where FlowId=@flowId
