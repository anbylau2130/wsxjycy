
--显示通知公告
Create PROCEDURE [dbo].[UP_ShowNotice] 
@PageIndex int = 1,      
@PageSize int = 10,   
@WhereStr nvarchar(200)='',   
@strOrder varchar(MAX) = 'ID',      
@strOrderType varchar(max) = 'ASC' 
AS
if @strOrder='' 
begin
	set @strOrder=' ID '
end

if @strOrderType='' 
begin
	set @strOrderType=' ASC '
end
DECLARE @sqlstr VARCHAR(max) 
SET @sqlstr='
SELECT * from(      
    select convert(bigint, ROW_NUMBER() OVER(order by '+@strOrder+' '+@strOrderType+')) as RowNo,      
    convert(bigint, COUNT(0) OVER()) as RowCnt, *      
    FROM(
	select * from (
        select  a.ID, a.Title, a.BroweCount, a.Content, 
        a.Reserve, a.Remark, creator.RealName Creator,
        a.CreateTime, auditor.RealName Auditor, a.AuditTime,
        canceler.RealName Canceler, a.CancelTime from dbo.WebNotice a
        left join dbo.SysOperator creator  on a.Creator=creator.ID
        left join dbo.SysOperator auditor  on a.Auditor=auditor.ID
        left join dbo.SysOperator canceler on a.Canceler=canceler.ID
		) tab
        where 1=1 '
         	IF @WhereStr<>''
			BEGIN
				SET @sqlstr+= @WhereStr
			END  
			SET @sqlstr+='
		) AS a   
	) AS temp
WHERE RowNo BETWEEN '+CONVERT(VARCHAR, (@PageIndex-1)*@PageSize+1) +' AND ' +CONVERT (VARCHAR,@PageIndex*@PageSize) 
PRINT(@sqlstr)
exec(@sqlstr)

go

Create PROCEDURE [dbo].[UP_ShowWebDeptDuty] 
@PageIndex int = 1,      
@PageSize int = 10,   
@WhereStr nvarchar(200)='',   
@strOrder varchar(MAX) = 'ID',      
@strOrderType varchar(max) = 'ASC' 
AS
if @strOrder='' 
begin
	set @strOrder=' ID '
end

if @strOrderType='' 
begin
	set @strOrderType=' ASC '
end
DECLARE @sqlstr VARCHAR(max) 
SET @sqlstr='
SELECT * from(      
    select convert(bigint, ROW_NUMBER() OVER(order by '+@strOrder+' '+@strOrderType+')) as RowNo,      
    convert(bigint, COUNT(0) OVER()) as RowCnt, *      
    FROM(
	select * from (
        select  a.ID, a.DeptName, a.DeptDuty,  
        a.Reserve, a.Remark, creator.RealName Creator,
        a.CreateTime, auditor.RealName Auditor, a.AuditTime,
        canceler.RealName Canceler, a.CancelTime
        from WebDeptDuty a
        left join dbo.SysOperator creator  on a.Creator=creator.ID
        left join dbo.SysOperator auditor  on a.Auditor=auditor.ID
        left join dbo.SysOperator canceler on a.Canceler=canceler.ID
		) tab
       where 1=1 '
         	IF @WhereStr<>''
			BEGIN
				SET @sqlstr+= @WhereStr
			END  
			SET @sqlstr+='
		) AS a   
	) AS temp
WHERE RowNo BETWEEN '+CONVERT(VARCHAR, (@PageIndex-1)*@PageSize+1) +' AND ' +CONVERT (VARCHAR,@PageIndex*@PageSize)

			
PRINT(@sqlstr)
exec(@sqlstr)
go

-- exec UP_ShowWebNews 1,10, 'and [Auditor] like ''%系统管理员%'' ','ID','ASC'
CREATE PROCEDURE [dbo].[UP_ShowWebNews] 
@PageIndex int = 1,      
@PageSize int = 10,   
@WhereStr nvarchar(200)='',   
@strOrder varchar(MAX) = '',      
@strOrderType varchar(max) = 'ASC' 
AS
if @strOrder='' 
begin
	set @strOrder=' ID '
end

if @strOrderType='' 
begin
	set @strOrderType=' ASC '
end
DECLARE @sqlstr VARCHAR(max) 
SET @sqlstr='
SELECT * from(      
    select convert(bigint, ROW_NUMBER() OVER(order by '+@strOrder+' '+@strOrderType+')) as RowNo,      
    convert(bigint, COUNT(0) OVER()) as RowCnt, *      
    FROM(
	select * from (
        select  a.ID, a.Title, a.BroweCount, a.Content,  
        a.Reserve, a.Remark, creator.RealName Creator,
        a.CreateTime, auditor.RealName Auditor, a.AuditTime,
        canceler.RealName Canceler, a.CancelTime
        from WebNews a
        left join dbo.SysOperator creator  on a.Creator=creator.ID
        left join dbo.SysOperator auditor  on a.Auditor=auditor.ID
        left join dbo.SysOperator canceler on a.Canceler=canceler.ID
		) tab
       where 1=1 '
         	IF @WhereStr<>''
			BEGIN
				SET @sqlstr+= @WhereStr
			END  
			SET @sqlstr+='
		) AS a   
	) AS temp
WHERE RowNo BETWEEN '+CONVERT(VARCHAR, (@PageIndex-1)*@PageSize+1) +' AND ' +CONVERT (VARCHAR,@PageIndex*@PageSize)

			
PRINT(@sqlstr)
exec(@sqlstr)

go
-- exec UP_ShowTableDownLoad 1,10, '','ID','ASC'
Create PROCEDURE [dbo].[UP_ShowTableDownLoad] @PageIndex int = 1,      
@PageSize int = 10,   
@WhereStr nvarchar(200)='',   
@strOrder varchar(MAX) = 'ID',      
@strOrderType varchar(max) = 'ASC' 
AS
if @strOrder='' 
begin
	set @strOrder=' ID '
end

if @strOrderType='' 
begin
	set @strOrderType=' ASC '
end
DECLARE @sqlstr VARCHAR(max) 
SET @sqlstr='
SELECT * from(      
    select convert(bigint, ROW_NUMBER() OVER(order by '+@strOrder+' '+@strOrderType+')) as RowNo,      
    convert(bigint, COUNT(0) OVER()) as RowCnt, *      
    FROM(
	select * from (
			select a.ID
			,a.Title
			,a.TableUrl
			,a.DownLoadCount
			,a.Reserve
			,a.Remark
			,creator.RealName Creator
			,a.CreateTime
			,auditor.RealName Auditor
			,a.AuditTime
			,canceler.RealName  Canceler
			,a.CancelTime  from dbo.TableDownLoad a
			left join dbo.SysOperator creator  on a.Creator=creator.ID
		    left join dbo.SysOperator auditor  on a.Auditor=auditor.ID
		    left join dbo.SysOperator canceler on a.Canceler=canceler.ID
			) tab
       where 1=1 '
         	IF @WhereStr<>''
			BEGIN
				SET @sqlstr+= @WhereStr
			END  
			SET @sqlstr+='
		) AS a   
	) AS temp
WHERE RowNo BETWEEN '+CONVERT(VARCHAR, (@PageIndex-1)*@PageSize+1) +' AND ' +CONVERT (VARCHAR,@PageIndex*@PageSize)

			
PRINT(@sqlstr)
exec(@sqlstr)

go 


-- exec UP_ShowWebServiceGuide 1,10, ' ','ID','ASC'
Create PROCEDURE [dbo].[UP_ShowWebServiceGuide]
@PageIndex int = 1,      
@PageSize int = 10,   
@WhereStr nvarchar(200)='',   
@strOrder varchar(MAX) = 'ID',      
@strOrderType varchar(max) = 'ASC' 
AS
if @strOrder='' 
begin
	set @strOrder=' ID '
end

if @strOrderType='' 
begin
	set @strOrderType=' ASC '
end
DECLARE @sqlstr VARCHAR(max) 
SET @sqlstr='
SELECT * from(      
    select convert(bigint, ROW_NUMBER() OVER(order by '+@strOrder+' '+@strOrderType+')) as RowNo,      
    convert(bigint, COUNT(0) OVER()) as RowCnt, *      
    FROM(
	 select * from (
       select  
	 a.ID
	,a.Title
	,a.GuideName
	,a.DealDeptName
	,a.DealAddress
	,a.Contacts
	,a.PhoneNumber
	,a.DealTime
	,BaseEstablishment
	,a.EstablishmentCondition
	,a.ApplicationMaterials
	,a.ManagementProcess
	,a.FlowChart
	,a.BrowseCount
	,a.Reserve
	,a.Remark
	,creator.RealName Creator
	,a.CreateTime
	,auditor.RealName Auditor
	,a.AuditTime
	,canceler.RealName Canceler
	,a.CancelTime  from WebServiceGuide a
        left join dbo.SysOperator creator  on a.Creator=creator.ID
        left join dbo.SysOperator auditor  on a.Auditor=auditor.ID
        left join dbo.SysOperator canceler on a.Canceler=canceler.ID
		) tab
       where 1=1 '
         	IF @WhereStr<>''
			BEGIN
				SET @sqlstr+= @WhereStr
			END  
			SET @sqlstr+='
		) AS a   
	) AS temp
WHERE RowNo BETWEEN '+CONVERT(VARCHAR, (@PageIndex-1)*@PageSize+1) +' AND ' +CONVERT (VARCHAR,@PageIndex*@PageSize)

PRINT(@sqlstr)
exec(@sqlstr)

go

-- exec UP_ShowWebVedios 1,10, ' ',,'ASC'
Create PROCEDURE [dbo].[UP_ShowWebVedios] @PageIndex int = 1,      
@PageSize int = 10,   
@WhereStr nvarchar(200)='',   
@strOrder varchar(MAX) = 'ID',      
@strOrderType varchar(max) = 'ASC' 
AS
if @strOrder='' 
begin
	set @strOrder=' ID '
end
if @strOrderType='' 
begin
	set @strOrderType=' ASC '
end
DECLARE @sqlstr VARCHAR(max) 
SET @sqlstr='
SELECT * from(      
    select convert(bigint, ROW_NUMBER() OVER(order by '+@strOrder+' '+@strOrderType+' )) as RowNo,      
    convert(bigint, COUNT(0) OVER()) as RowCnt, *      
    FROM(
	select * from (
			select a.ID
				,a.Title
				,a.Content
				,a.VedioUrl
				,a.PictureUrl
				,a.BrowerCount
				,a.Reserve
				,a.Remark
				,creator.RealName Creator
				,a.CreateTime
				,auditor.RealName Auditor
				,a.AuditTime
				,canceler.RealName Canceler
				,a.CancelTime from dbo.WebVedios a
				left join dbo.SysOperator creator  on a.Creator=creator.ID
			    left join dbo.SysOperator auditor  on a.Auditor=auditor.ID
			    left join dbo.SysOperator canceler on a.Canceler=canceler.ID
				) tab
				where 1=1 '
         	IF @WhereStr<>''
			BEGIN
				SET @sqlstr+= @WhereStr
			END  
			SET @sqlstr+='
		) AS a   
	) AS temp
WHERE RowNo BETWEEN '+CONVERT(VARCHAR, (@PageIndex-1)*@PageSize+1) +' AND ' +CONVERT (VARCHAR,@PageIndex*@PageSize)

			
PRINT(@sqlstr)
exec(@sqlstr)

go
-- exec UP_ShowWebRegulations 1,10, ' ','ID','ASC'
Create PROCEDURE [dbo].[UP_ShowWebRegulations] @PageIndex int = 1,      
@PageSize int = 10,   
@WhereStr nvarchar(200)='',   
@strOrder varchar(MAX) = 'ID',      
@strOrderType varchar(max) = 'ASC' 
AS
 if @strOrder='' 
begin
	set @strOrder=' ID '
end
if @strOrderType='' 
begin
	set @strOrderType=' ASC '
end
DECLARE @sqlstr VARCHAR(max) 
SET @sqlstr='
SELECT * from(      
    select convert(bigint, ROW_NUMBER() OVER(order by '+@strOrder+' '+@strOrderType+' )) as RowNo,      
    convert(bigint, COUNT(0) OVER()) as RowCnt, *      
    FROM(
	select * from (
			select a.ID
				,a.Title
				,a.Content
				,a.BrowerCount
				,a.Reserve
				,a.Remark
				,creator.RealName Creator
				,a.CreateTime
				,auditor.RealName Auditor
				,a.AuditTime
				,canceler.RealName Canceler
				,a.CancelTime from dbo.WebRegulations a
				left join dbo.SysOperator creator  on a.Creator=creator.ID
			    left join dbo.SysOperator auditor  on a.Auditor=auditor.ID
			    left join dbo.SysOperator canceler on a.Canceler=canceler.ID
				) tab
				where 1=1 '
         	IF @WhereStr<>''
			BEGIN
				SET @sqlstr+= @WhereStr
			END  
			SET @sqlstr+='
		) AS a   
	) AS temp
WHERE RowNo BETWEEN '+CONVERT(VARCHAR, (@PageIndex-1)*@PageSize+1) +' AND ' +CONVERT (VARCHAR,@PageIndex*@PageSize)

PRINT(@sqlstr)
exec(@sqlstr)
go