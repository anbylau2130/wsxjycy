
CREATE TABLE [dbo].[Area](
	[ID] [bigint] NOT NULL,
	[Code] [varchar](20) NULL,
	[Parent] [varchar](20) NULL,
	[Name] [varchar](100) NULL,
	[Type] [int] NOT NULL
) ON [PRIMARY]

CREATE TABLE [dbo].[SysBank](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Number] [bigint] NULL,
	[Url] [varchar](100) NULL,
	[Type] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[ShortName] [varchar](20) NULL,
	[NiceName] [varchar](20) NULL,
	[Status] [int] NULL,
	[Reserve] [varchar](250) NULL,
	[Remark] [varchar](250) NULL,
	[Creator] [bigint] NULL,
	[CreateTime] [datetime] NULL,
	[Auditor] [bigint] NULL,
	[AuditTime] [datetime] NULL,
	[Canceler] [bigint] NULL,
	[CancelTime] [datetime] NULL
) ON [PRIMARY]

GO

--drop table SysDictionary
create table SysDictionary(
ID bigint not null identity(0,1),--唯一标识
Name [varchar](255)  not NULL,
Parent bigint  default(0),
Reserve varchar(250) null,--保留
Remark varchar(250) null,--备注
Creator bigint not null,--创建人
Type varchar(50) null,--类型
CreateTime datetime not null default(getdate()),--创建时间
Auditor bigint,--审核人
AuditTime datetime,--审核时间
Canceler bigint,--注销人
CancelTime datetime,--注销时间
CONSTRAINT PK_SysDictionary_ID primary key(ID),
--CONSTRAINT UK_SysDictionary_Name unique(Name),
--constraint FK_SysDictionary_Parent foreign key(Parent) references SysDictionary(ID)
)

--通知公告
Create table WebNotice(
[ID] [bigint] IDENTITY(1,1) NOT NULL,
[Title] VARCHAR(500),  -- 标题
[BroweCount] bigint,   --浏览次数
[Content] text,		   --通知内容
[Reserve] [varchar](250) NULL, --说明
[Remark] [varchar](250) NULL,--备注
[Creator] [bigint] NULL, --创建人
[CreateTime] [datetime] NULL, --创建时间
[Auditor] [bigint] NULL, --审批人
[AuditTime] [datetime] NULL,-- 审核时间
[Canceler] [bigint] NULL,--禁用人
[CancelTime] [datetime] NULL --禁用时间
CONSTRAINT PK_WebNotice_ID primary key(ID),
)
 
--部门职能
Create table WebDeptDuty(
[ID] [bigint] IDENTITY(1,1) NOT NULL,
[DeptName] VARCHAR(500),  -- 部门名称
[DeptDuty] varchar(Max),		   --部门职能
[Reserve] [varchar](250) NULL, --说明
[Remark] [varchar](250) NULL,--备注
[Creator] [bigint] NULL, --创建人
[CreateTime] [datetime] NULL, --创建时间
[Auditor] [bigint] NULL, --审批人
[AuditTime] [datetime] NULL,-- 审核时间
[Canceler] [bigint] NULL,--禁用人
[CancelTime] [datetime] NULL --禁用时间
CONSTRAINT PK_WebInstitutional_ID primary key(ID),
)

--新闻中心
Create table WebNews(
[ID] [bigint] IDENTITY(1,1) NOT NULL,
[Title] VARCHAR(500),  -- 新闻标题
[Content] varchar(Max),		   --新闻内容
BroweCount bigint  DEFAULT(0), --浏览次数
[Reserve] [varchar](250) NULL, --说明
[Remark] [varchar](250) NULL,--备注
[Creator] [bigint] NULL, --创建人
[CreateTime] [datetime] NULL, --创建时间
[Auditor] [bigint] NULL, --审批人
[AuditTime] [datetime] NULL,-- 审核时间
[Canceler] [bigint] NULL,--禁用人
[CancelTime] [datetime] NULL --禁用时间
CONSTRAINT PK_WebNews_ID primary key(ID),
)
--办事指南
Create table WebServiceGuide(
[ID] [bigint] IDENTITY(1,1) ,
[Title] VARCHAR(500),  -- 业务标题
[GuideName] VARCHAR(250), --业务名称
[DealDeptName] varchar(250) ,--受理部门
[DealAddress] varchar(500),   --受理地址
[Contacts]    varchar(250), --联系人
[PhoneNumber] varchar(250), --联系电话
[DealTime] varchar(500), --受理时间
[BaseEstablishment] text ,--设立依据
[EstablishmentCondition] text ,--受理条件
[ApplicationMaterials] text ,--申请材料
[ManagementProcess] text ,--办理流程	
[FlowChart] text ,--办理流程图
[BrowseCount] bigint , --浏览次数
[Reserve] [varchar](250) NULL, --说明
[Remark] [varchar](250) NULL,--备注
[Creator] [bigint] NULL, --创建人
[CreateTime] [datetime] NULL, --创建时间
[Auditor] [bigint] NULL, --审批人
[AuditTime] [datetime] NULL,-- 审核时间
[Canceler] [bigint] NULL,--禁用人
[CancelTime] [datetime] NULL --禁用时间
CONSTRAINT PK_WebServiceGuide_ID primary key(ID),
)
--表格下载
create table TableDownLoad(
[ID] [bigint] IDENTITY(1,1) , --标识字段
Title varchar(500) ,           --标题
TableUrl  varchar(8000),       --文件URl
DownLoadCount bigint,		--下载次数
[Reserve] [varchar](250) NULL, --说明
[Remark] [varchar](250) NULL,--备注
[Creator] [bigint] NULL, --创建人
[CreateTime] [datetime] NULL, --创建时间
[Auditor] [bigint] NULL, --审批人
[AuditTime] [datetime] NULL,-- 审核时间
[Canceler] [bigint] NULL,--禁用人
[CancelTime] [datetime] NULL --禁用时间
CONSTRAINT PK_TableDownLoad_ID primary key(ID),
)


--视频列表
create table WebVedios(
[ID] [bigint] IDENTITY(1,1) ,  --标识字段
Title varchar(500) ,           --标题
Content text,                  --描述
VedioUrl  varchar(8000),       --文件URl
PictureUrl varchar(8000),	   --缩略图Url
BrowerCount bigint,            --下载次数
[Reserve] [varchar](250) NULL, --说明
[Remark] [varchar](250) NULL,  --备注
[Creator] [bigint] NULL,       --创建人
[CreateTime] [datetime] NULL, --创建时间
[Auditor] [bigint] NULL,      --审批人
[AuditTime] [datetime] NULL,   -- 审核时间
[Canceler] [bigint] NULL,--禁用人
[CancelTime] [datetime] NULL --禁用时间
CONSTRAINT PK_WebVedios_ID primary key(ID),
)


--政策法规
create table WebRegulations(
[ID] [bigint] IDENTITY(1,1) , --标识字段
Title varchar(500) ,           --标题
Content text,                  --描述
BrowerCount bigint,         --浏览次数
[Reserve] [varchar](250) NULL, --说明
[Remark] [varchar](250) NULL,  --备注
[Creator] [bigint] NULL,       --创建人
[CreateTime] [datetime] NULL, --创建时间
[Auditor] [bigint] NULL,      --审批人
[AuditTime] [datetime] NULL,-- 审核时间
[Canceler] [bigint] NULL,--禁用人
[CancelTime] [datetime] NULL --禁用时间
CONSTRAINT PK_WebRegulations_ID primary key(ID),
)