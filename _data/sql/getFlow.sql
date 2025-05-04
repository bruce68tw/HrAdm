
declare @flowId varchar(10)
set @flowId = 'sR9paQmAdm'

select * from XpFlow where Id=@flowId
select * from XpFlowNode where FlowId=@flowId
select * from XpFlowLine where FlowId=@flowId
