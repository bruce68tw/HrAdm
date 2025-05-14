
select a.*
--delete a
from dbo.XpUserRole a
left join dbo.XpUser u on a.UserId=u.Id
left join dbo.XpRole r on a.RoleId=r.Id
where u.Id is null or r.Id is null

select a.*
--delete a
from dbo.XpRoleProg a
left join dbo.XpRole r on a.RoleId=r.Id
left join dbo.XpProg p on a.ProgId=p.Id
where r.Id is null or p.Id is null

