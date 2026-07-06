
insert into Early.dbo.XpCode(Type, Value, Name, Sort, Ext, Note)
select Type, Value, Name_zhTW, Sort, Ext, Note
from Hr.dbo.XpCode 
where Type in (
'AndOr',
'FlowStatus',
'LineFromType',
'LineOp',
'NodeLimitType',
'NodeType',
'PassType',
'SignerType',
'SignStatus'
)
