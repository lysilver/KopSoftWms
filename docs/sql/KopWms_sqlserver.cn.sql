/*
 Navicat Premium Data Transfer

 Source Server         : (local-sqlserver)
 Source Server Type    : SQL Server
 Source Server Version : 13001742
 Source Host           : localhost:1433
 Source Catalog        : KopWms
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 13001742
 File Encoding         : 65001

 Date: 05/03/2019 15:25:13
*/


-- ----------------------------
-- Table structure for Sys_dept
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Sys_dept]') AND type IN ('U'))
	DROP TABLE [dbo].[Sys_dept]
GO

CREATE TABLE [dbo].[Sys_dept] (
  [DeptId] bigint  NOT NULL,
  [DeptNo] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [DeptName] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDel] tinyint  NOT NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Sys_dept] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'1未删除   0删除',
'SCHEMA', N'dbo',
'TABLE', N'Sys_dept',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Sys_dept',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Sys_dept',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Sys_dept',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Sys_dept',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Sys_dept
-- ----------------------------
INSERT INTO [dbo].[Sys_dept] VALUES (N'492573722524254208', NULL, N'技术一部', N'1', N'负责机台1', N'491786087098744832', N'2018-09-22 09:36:33.000', N'491786087098744832', N'2018-09-22 10:01:39.000')
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'492616866888417280', NULL, N'技术二部', N'1', N'负责机台2', N'491786087098744832', N'2018-09-21 16:42:56.000', N'491786087098744832', N'2018-09-22 15:49:11.000')
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'492617342476353536', NULL, N'技术三部', N'1', N'负责机台3', N'491786087098744832', N'2018-09-21 16:44:19.000', N'491786087098744832', N'2018-09-22 15:48:28.000')
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'492967145194389504', NULL, N'技术四部', N'1', N'负责机台4', N'491786087098744832', N'2018-09-22 15:55:26.000', N'491786087098744832', N'2018-09-23 10:45:55.000')
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'493254990471626752', NULL, N'1111111111111111111111111111111', N'0', NULL, N'491786087098744832', N'2018-09-23 10:55:59.000', N'491786087098744832', N'2018-09-23 13:30:32.000')
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'493259536275079168', N'4', N'技术五部', N'1', N'机台5', N'491786087098744832', N'2018-09-23 11:15:10.000', N'504990858139926528', N'2019-02-17 17:06:22.713')
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'493293212589359104', NULL, N'asd', N'0', NULL, N'491786087098744832', N'2018-09-23 13:31:07.000', N'491786087098744832', N'2018-09-23 13:35:05.000')
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'493293262740652032', NULL, N'asdas', N'0', NULL, N'491786087098744832', N'2018-09-23 13:31:13.000', N'491786087098744832', N'2018-09-23 13:35:08.000')
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'518051525495357440', N'kt004', N'销售部门', N'1', N'销售部门', N'504990858139926528', N'2018-11-30 21:11:54.000', N'504990858139926528', N'2018-12-22 19:42:25.000')
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'518051575634067456', N'kt003', N'采购部门', N'1', N'采购部门', N'504990858139926528', N'2018-11-30 21:12:06.000', N'504990858139926528', N'2018-12-22 19:42:13.000')
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'518053174372728832', N'kt002', N'制造一部', N'1', N'制造一部', N'504990858139926528', N'2018-11-30 21:18:28.000', N'504990858139926528', N'2018-12-22 19:42:00.000')
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'518053238646243328', N'kt001', N'制造二部', N'1', N'制造二部', N'504990858139926528', N'2018-11-30 21:18:43.000', N'504990858139926528', N'2018-12-22 19:41:49.000')
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'528063722858479616', N'RD', N'RD', N'1', NULL, N'504990858139926528', N'2018-12-28 12:16:42.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'550212648847802368', N'12', N'12', N'0', N'12', N'504990858139926528', N'2019-02-27 15:08:36.463', N'504990858139926528', N'2019-02-27 17:01:56.560')
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'550244912524689408', N'333', N'333', N'0', N'333344', N'504990858139926528', N'2019-02-27 17:16:48.993', N'504990858139926528', N'2019-02-27 17:27:39.947')
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'550312768192905216', N'YBS', N'饮冰室', N'1', N'YBS', N'504990858139926528', N'2019-02-27 21:46:26.953', N'491786087098744832', N'2019-02-27 22:16:14.803')
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'551031800911101952', N'T001', N'天心堂', N'0', N'天心堂', N'504990858139926528', N'2019-03-01 21:23:38.457', N'504990858139926528', N'2019-03-01 21:24:17.697')
GO

INSERT INTO [dbo].[Sys_dept] VALUES (N'552087637804974080', N'89', N'89', N'1', N'89', N'504990858139926528', N'2019-03-04 19:14:00.640', NULL, NULL)
GO


-- ----------------------------
-- Table structure for Sys_dict
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Sys_dict]') AND type IN ('U'))
	DROP TABLE [dbo].[Sys_dict]
GO

CREATE TABLE [dbo].[Sys_dict] (
  [DictId] bigint  NOT NULL,
  [DictNo] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [DictName] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [DictType] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDel] tinyint  NOT NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Sys_dict] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'1未删除   0删除',
'SCHEMA', N'dbo',
'TABLE', N'Sys_dict',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Sys_dict',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Sys_dict',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Sys_dict',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Sys_dict',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Sys_dict
-- ----------------------------
INSERT INTO [dbo].[Sys_dict] VALUES (N'503747692996853760', NULL, N'件', N'1', N'1', NULL, N'491786087098744832', N'2018-10-22 09:53:29.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'503752972895780864', NULL, N'采购入库单', N'3', N'1', NULL, N'491786087098744832', N'2018-10-22 10:14:27.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'503753018307510272', NULL, N'成品出库单', N'4', N'1', NULL, N'491786087098744832', N'2018-10-22 10:14:39.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'507099447742693376', NULL, N'A级物料', N'2', N'1', N'A级物料', N'491786087098744832', N'2018-10-31 15:52:09.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'507099512351752192', NULL, N'普通材料', N'2', N'1', NULL, N'491786087098744832', N'2018-10-31 15:52:25.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'507099602579619840', NULL, N'耗材类', N'2', N'1', NULL, N'491786087098744832', N'2018-10-31 15:52:47.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'507100062879318016', NULL, N'包材料', N'2', N'1', NULL, N'491786087098744832', N'2018-10-31 15:54:36.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'507100561112301568', NULL, N'危险品料', N'2', N'1', NULL, N'491786087098744832', N'2018-10-31 15:56:35.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'507100596751302656', NULL, N'成品类', N'2', N'1', NULL, N'491786087098744832', N'2018-10-31 15:56:44.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'507100629949218816', NULL, N'冶工具 ', N'2', N'1', NULL, N'491786087098744832', N'2018-10-31 15:56:52.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'507100659967852544', NULL, N'设备', N'2', N'1', NULL, N'491786087098744832', N'2018-10-31 15:56:59.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'507452557040287744', NULL, N'台', N'1', N'1', N'台', N'491786087098744832', N'2018-11-01 15:15:17.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'507477339421016064', NULL, N'个', N'1', N'1', NULL, N'491786087098744832', N'2018-11-01 16:53:46.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'517162885743378432', NULL, N'自有', N'6', N'1', NULL, N'504990858139926528', N'2018-11-28 10:20:39.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'517162936238604288', NULL, N'租赁', N'6', N'1', NULL, N'504990858139926528', N'2018-11-28 10:20:52.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'517163878539329536', NULL, N'专业生产用设备', N'5', N'1', NULL, N'504990858139926528', N'2018-11-28 10:24:37.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'517163903772262400', NULL, N'动能发生设备', N'5', N'1', NULL, N'504990858139926528', N'2018-11-28 10:24:43.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'517163985334697984', NULL, N'电器设备', N'5', N'1', NULL, N'504990858139926528', N'2018-11-28 10:25:03.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'517164060874113024', NULL, N'锻压设备', N'5', N'1', N'1', N'504990858139926528', N'2018-11-28 10:25:21.000', N'491786087098744832', N'2018-11-28 16:23:44.000')
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'524588722197364736', NULL, N'A物料', N'2', N'1', NULL, N'504990858139926528', N'2018-12-18 22:08:18.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'524838103836262400', N'1', N'stockin', N'0', N'2', N'勿动，入库单编号', N'504990858139926528', N'2018-12-19 14:39:14.000', NULL, N'1900-01-01 00:00:00.000')
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'524838556393275392', N'1', N'stockout', N'0', N'2', N'勿动，出库单编号', N'504990858139926528', N'2018-12-19 14:41:03.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'525173270467575808', NULL, N'退货入库单', N'3', N'1', NULL, N'504990858139926528', N'2018-12-20 12:51:02.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'525175016191426560', NULL, N'试用入库', N'3', N'1', N'YOU SHEN ME YONG NE ?', N'504990858139926528', N'2018-12-20 12:58:01.000', N'504990858139926528', N'2018-12-28 12:17:18.000')
GO

INSERT INTO [dbo].[Sys_dict] VALUES (N'539715276204146688', NULL, N'光年', N'1', N'0', NULL, N'504990858139926528', N'2019-01-29 15:55:49.240', N'504990858139926528', N'2019-01-29 15:56:11.477')
GO


-- ----------------------------
-- Table structure for Sys_log
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Sys_log]') AND type IN ('U'))
	DROP TABLE [dbo].[Sys_log]
GO

CREATE TABLE [dbo].[Sys_log] (
  [LogId] bigint  NOT NULL,
  [LogType] nvarchar(10) COLLATE Chinese_PRC_CI_AS  NULL,
  [Description] nvarchar(1000) COLLATE Chinese_PRC_CI_AS  NULL,
  [Url] nvarchar(150) COLLATE Chinese_PRC_CI_AS  NULL,
  [Browser] nvarchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL,
  [LogIp] nvarchar(15) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Sys_log] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Sys_log',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Sys_log',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Sys_log',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Sys_log',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Table structure for Sys_menu_wms
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Sys_menu_wms]') AND type IN ('U'))
	DROP TABLE [dbo].[Sys_menu_wms]
GO

CREATE TABLE [dbo].[Sys_menu_wms] (
  [MenuId] bigint  NOT NULL,
  [MenuName] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [MenuUrl] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [MenuIcon] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [MenuParent] bigint  NULL,
  [Sort] int  NULL,
  [Status] tinyint  NULL,
  [MenuType] nvarchar(10) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDel] tinyint  NOT NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Sys_menu_wms] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'启用1 禁用0',
'SCHEMA', N'dbo',
'TABLE', N'Sys_menu_wms',
'COLUMN', N'Status'
GO

EXEC sp_addextendedproperty
'MS_Description', N'menu btn',
'SCHEMA', N'dbo',
'TABLE', N'Sys_menu_wms',
'COLUMN', N'MenuType'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1未删除   0删除',
'SCHEMA', N'dbo',
'TABLE', N'Sys_menu_wms',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Sys_menu_wms',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Sys_menu_wms',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Sys_menu_wms',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Sys_menu_wms',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Sys_menu_wms
-- ----------------------------
INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'1', N'系统管理', N'#', NULL, N'-1', N'1', N'1', N'menu', N'1', NULL, NULL, N'2018-09-24 12:10:42.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'2', N'用户管理', N'/User', NULL, N'1', N'4', N'1', N'menu', N'1', NULL, NULL, N'2018-09-24 12:12:56.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'3', N'部门管理', N'/Dept', NULL, N'1', N'3', N'1', N'menu', N'1', NULL, NULL, N'2018-09-24 12:14:38.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'4', N'角色管理', N'/Role', NULL, N'1', N'2', N'1', N'menu', N'1', NULL, NULL, N'2018-09-24 12:14:57.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'5', N'数据字典', N'/Dict', NULL, N'1', N'5', N'1', N'menu', N'1', NULL, NULL, N'2018-10-21 14:44:30.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'6', N'基础资料', N'#', NULL, N'-1', N'6', N'1', N'menu', N'1', NULL, NULL, N'2018-09-24 12:19:07.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'7', N'物料管理', N'/Material', NULL, N'6', N'7', N'1', N'menu', N'1', NULL, NULL, N'2018-10-09 08:50:37.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'8', N'客户管理', N'/Customer', NULL, N'6', N'8', N'1', N'menu', N'1', NULL, NULL, N'2018-10-09 08:50:44.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'9', N'供应商管理', N'/Supplier', NULL, N'6', N'9', N'1', N'menu', N'1', NULL, NULL, N'2018-10-21 10:25:53.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'10', N'承运商管理', N'/Carrier', NULL, N'6', N'10', N'1', N'menu', N'1', NULL, NULL, N'2018-10-21 10:25:58.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'11', N'仓库管理', N'#', NULL, N'-1', N'11', N'1', N'menu', N'1', NULL, NULL, N'2018-12-18 23:01:36.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'12', N'仓库管理', N'/Warehouse', NULL, N'11', N'12', N'1', N'menu', N'1', NULL, NULL, N'2018-10-09 08:48:09.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'13', N'库区管理', N'/ReservoirArea', NULL, N'11', N'13', N'1', N'menu', N'1', NULL, NULL, N'2018-10-09 08:49:11.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'14', N'货架管理', N'/StorageRack', N'&#xe61a;', N'11', N'14', N'1', N'menu', N'1', NULL, NULL, N'2018-10-09 08:49:14.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'22', N'日志管理', N'#', N'&#xe62e;', N'-1', N'22', N'1', N'menu', N'1', NULL, NULL, N'2018-10-09 08:50:51.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'23', N'系统日志', N'/Log', NULL, N'22', N'23', N'1', N'menu', N'1', NULL, NULL, N'2018-10-09 08:50:54.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'24', N'入库管理', N'/StockIn', NULL, N'11', N'24', N'1', N'menu', N'1', NULL, NULL, N'2018-12-19 14:09:08.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'27', N'出库管理', N'/StockOut', NULL, N'11', N'27', N'1', N'menu', N'1', NULL, NULL, N'2019-01-22 11:06:17.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'29', N'库存查询', N'/Inventory', NULL, N'11', N'29', N'1', N'menu', N'1', NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'30', N'库存记录', N'/InventoryRecord', NULL, N'11', N'30', N'1', N'menu', N'1', NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'31', N'登录统计', N'/Log/Bar', NULL, N'22', N'31', N'1', N'menu', N'1', NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'32', N'发货记录', N'/Delivery', NULL, N'11', N'32', N'1', N'menu', N'1', NULL, NULL, NULL, NULL, NULL)
GO

INSERT INTO [dbo].[Sys_menu_wms] VALUES (N'33', N'库存移动', N'/InventoryMove', NULL, N'11', N'33', N'1', N'menu', N'1', NULL, NULL, NULL, NULL, NULL)
GO


-- ----------------------------
-- Table structure for Sys_role
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Sys_role]') AND type IN ('U'))
	DROP TABLE [dbo].[Sys_role]
GO

CREATE TABLE [dbo].[Sys_role] (
  [RoleId] bigint  NOT NULL,
  [RoleName] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [RoleType] nvarchar(10) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDel] tinyint  NOT NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Sys_role] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'admin #',
'SCHEMA', N'dbo',
'TABLE', N'Sys_role',
'COLUMN', N'RoleType'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1未删除   0删除',
'SCHEMA', N'dbo',
'TABLE', N'Sys_role',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Sys_role',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Sys_role',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Sys_role',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Sys_role',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Sys_role
-- ----------------------------
INSERT INTO [dbo].[Sys_role] VALUES (N'494712986628259840', N'系统管理员', N'admin', N'1', N'系统管理员', N'491786087098744832', N'2018-09-27 11:32:43.000', N'504990858139926528', N'2019-03-05 14:48:04.943')
GO

INSERT INTO [dbo].[Sys_role] VALUES (N'518052696645697536', N'工艺工程师', N'#', N'0', N'工艺工程师', N'504990858139926528', N'2018-11-30 21:16:34.000', N'504990858139926528', N'2019-03-05 14:48:23.500')
GO

INSERT INTO [dbo].[Sys_role] VALUES (N'551034449270145024', N'1', N'#', N'0', N'12', N'504990858139926528', N'2019-03-01 21:33:50.523', N'504990858139926528', N'2019-03-03 20:45:46.683')
GO

INSERT INTO [dbo].[Sys_role] VALUES (N'551035289351487488', N'123', N'#', N'0', N'1231', N'504990858139926528', N'2019-03-01 21:37:20.683', N'504990858139926528', N'2019-03-03 20:45:43.800')
GO

INSERT INTO [dbo].[Sys_role] VALUES (N'518052825163366400', N'仓库管理员', N'#', N'1', N'仓库管理员', N'504990858139926528', N'2018-11-30 21:17:04.000', N'504990858139926528', N'2018-12-19 13:53:39.000')
GO

INSERT INTO [dbo].[Sys_role] VALUES (N'518052895468290048', N'设备工程师', N'#', N'0', N'设备工程师', N'504990858139926528', N'2018-11-30 21:17:21.000', N'504990858139926528', N'2019-03-05 14:48:31.507')
GO

INSERT INTO [dbo].[Sys_role] VALUES (N'551052717045317632', N'aaa', N'#', N'0', N'aaaa', N'504990858139926528', N'2019-03-01 22:46:45.737', N'504990858139926528', N'2019-03-03 20:45:40.733')
GO

INSERT INTO [dbo].[Sys_role] VALUES (N'551290503941849088', N'111111', N'#', N'0', N'111', N'504990858139926528', N'2019-03-02 14:29:43.520', N'504990858139926528', N'2019-03-03 20:45:37.883')
GO

INSERT INTO [dbo].[Sys_role] VALUES (N'552120536675647488', N'16', N'#', N'0', N'1', N'504990858139926528', N'2019-03-04 21:29:53.060', N'504990858139926528', N'2019-03-05 14:48:27.640')
GO

INSERT INTO [dbo].[Sys_role] VALUES (N'551291650308046848', N'3', N'#', N'0', N'3', N'504990858139926528', N'2019-03-02 14:34:12.690', N'504990858139926528', N'2019-03-03 20:45:35.030')
GO

INSERT INTO [dbo].[Sys_role] VALUES (N'551295610691518464', N'90io', N'#', N'0', N'8990', N'504990858139926528', N'2019-03-02 14:51:55.940', N'504990858139926528', N'2019-03-03 20:45:31.953')
GO


-- ----------------------------
-- Table structure for Sys_rolemenu
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Sys_rolemenu]') AND type IN ('U'))
	DROP TABLE [dbo].[Sys_rolemenu]
GO

CREATE TABLE [dbo].[Sys_rolemenu] (
  [RoleMenuId] bigint  NOT NULL,
  [RoleId] bigint  NULL,
  [MenuId] bigint  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Sys_rolemenu] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Sys_rolemenu',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Sys_rolemenu',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Sys_rolemenu',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Sys_rolemenu',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Sys_rolemenu
-- ----------------------------
INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'494712986762477568', N'494712986628259840', N'1', N'491786087098744832', N'2018-09-27 11:32:47.000', N'491786087098744832', N'2018-12-11 22:26:00.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'494712986762477569', N'494712986628259840', N'2', N'491786087098744832', N'2018-09-27 11:32:47.000', N'491786087098744832', N'2018-12-11 22:26:00.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'494712986762477570', N'494712986628259840', N'3', N'491786087098744832', N'2018-09-27 11:32:47.000', N'491786087098744832', N'2018-12-11 22:26:00.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'494712986762477571', N'494712986628259840', N'4', N'491786087098744832', N'2018-09-27 11:32:47.000', N'491786087098744832', N'2018-12-11 22:26:00.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'494712986762477572', N'494712986628259840', N'5', N'491786087098744832', N'2018-09-27 11:32:47.000', N'491786087098744832', N'2018-12-11 22:26:01.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'499030681041502208', N'494712986628259840', N'6', N'491786087098744832', N'2018-10-09 09:29:46.000', N'491786087098744832', N'2018-12-11 22:26:01.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'499030681083445248', N'494712986628259840', N'7', N'491786087098744832', N'2018-10-09 09:29:46.000', N'491786087098744832', N'2018-12-11 22:26:01.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'499030681137971200', N'494712986628259840', N'8', N'491786087098744832', N'2018-10-09 09:29:46.000', N'491786087098744832', N'2018-12-11 22:26:01.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'499030681158942720', N'494712986628259840', N'9', N'491786087098744832', N'2018-10-09 09:29:46.000', N'491786087098744832', N'2018-12-11 22:26:01.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'499030681188302848', N'494712986628259840', N'12', N'491786087098744832', N'2018-10-09 09:29:46.000', N'491786087098744832', N'2018-12-11 22:26:01.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'499030681217662976', N'494712986628259840', N'10', N'491786087098744832', N'2018-10-09 09:29:46.000', N'491786087098744832', N'2018-12-11 22:26:02.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'499030681247023104', N'494712986628259840', N'11', N'491786087098744832', N'2018-10-09 09:29:46.000', N'491786087098744832', N'2018-12-11 22:26:02.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'499030681272188928', N'494712986628259840', N'13', N'491786087098744832', N'2018-10-09 09:29:46.000', N'491786087098744832', N'2018-12-11 22:26:02.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'499030681427378176', N'494712986628259840', N'14', N'491786087098744832', N'2018-10-09 09:29:46.000', N'491786087098744832', N'2018-12-11 22:26:02.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'522056476315877376', N'494712986628259840', N'22', N'491786087098744832', N'2018-12-11 22:26:03.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'522056476953411584', N'494712986628259840', N'23', N'491786087098744832', N'2018-12-11 22:26:03.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'522056477603528704', N'494712986628259840', N'24', N'491786087098744832', N'2018-12-11 22:26:04.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'522229689423495168', N'522229689289277440', N'1', N'491786087098744832', N'2018-12-12 09:54:21.000', N'504990858139926528', N'2018-12-12 10:26:48.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'522229689423495169', N'522229689289277440', N'2', N'491786087098744832', N'2018-12-12 09:54:21.000', N'504990858139926528', N'2018-12-12 10:26:48.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'522229689423495171', N'522229689289277440', N'4', N'491786087098744832', N'2018-12-12 09:54:21.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'522229689423495172', N'522229689289277440', N'18', N'491786087098744832', N'2018-12-12 09:54:21.000', N'504990858139926528', N'2018-12-12 10:26:48.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'522229689423495173', N'522229689289277440', N'24', N'491786087098744832', N'2018-12-12 09:54:21.000', N'504990858139926528', N'2018-12-12 10:26:48.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'522229689423495174', N'522229689289277440', N'23', N'491786087098744832', N'2018-12-12 09:54:21.000', N'504990858139926528', N'2018-12-12 10:26:48.000')
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'522237859453730816', N'522229689289277440', N'6', N'504990858139926528', N'2018-12-12 10:26:48.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'522237859717971968', N'522229689289277440', N'5', N'504990858139926528', N'2018-12-12 10:26:48.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'522260001876606976', N'522229689289277440', N'3', N'504990858139926528', N'2018-12-12 11:54:48.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'522279678459772928', N'522229689289277440', N'7', N'504990858139926528', N'2018-12-12 13:12:59.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524810211492364288', N'522229689289277440', N'12', N'504990858139926528', N'2018-12-19 12:48:25.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524810211492364289', N'522229689289277440', N'13', N'504990858139926528', N'2018-12-19 12:48:25.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524810211492364290', N'522229689289277440', N'14', N'504990858139926528', N'2018-12-19 12:48:25.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524810211492364291', N'522229689289277440', N'15', N'504990858139926528', N'2018-12-19 12:48:25.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524810211492364292', N'522229689289277440', N'16', N'504990858139926528', N'2018-12-19 12:48:25.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524810211492364293', N'522229689289277440', N'17', N'504990858139926528', N'2018-12-19 12:48:25.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524810211492364294', N'522229689289277440', N'20', N'504990858139926528', N'2018-12-19 12:48:25.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524810211492364295', N'522229689289277440', N'19', N'504990858139926528', N'2018-12-19 12:48:25.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524810211492364296', N'522229689289277440', N'21', N'504990858139926528', N'2018-12-19 12:48:25.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524810211492364297', N'522229689289277440', N'22', N'504990858139926528', N'2018-12-19 12:48:25.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524810211492364298', N'522229689289277440', N'25', N'504990858139926528', N'2018-12-19 12:48:25.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524810211492364299', N'522229689289277440', N'8', N'504990858139926528', N'2018-12-19 12:48:25.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524810211492364300', N'522229689289277440', N'26', N'504990858139926528', N'2018-12-19 12:48:25.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524826629831131136', N'518052825163366400', N'11', N'504990858139926528', N'2018-12-19 13:53:39.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524826629831131137', N'518052825163366400', N'13', N'504990858139926528', N'2018-12-19 13:53:39.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524826629831131138', N'518052825163366400', N'12', N'504990858139926528', N'2018-12-19 13:53:39.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'524826629831131139', N'518052825163366400', N'14', N'504990858139926528', N'2018-12-19 13:53:39.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'527401452771999744', N'527401452621004800', N'2', N'504990858139926528', N'2018-12-26 16:25:05.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'527401452771999745', N'527401452621004800', N'3', N'504990858139926528', N'2018-12-26 16:25:05.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'527401452771999746', N'527401452621004800', N'4', N'504990858139926528', N'2018-12-26 16:25:05.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'527401452771999747', N'527401452621004800', N'5', N'504990858139926528', N'2018-12-26 16:25:05.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'527401452771999748', N'527401452621004800', N'12', N'504990858139926528', N'2018-12-26 16:25:05.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'527401452771999749', N'527401452621004800', N'13', N'504990858139926528', N'2018-12-26 16:25:05.000', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'537141837408763904', N'494712986628259840', N'29', N'504990858139926528', N'2019-01-22 13:29:53.670', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'537141837408763905', N'494712986628259840', N'30', N'504990858139926528', N'2019-01-22 13:29:53.670', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'537177594374651904', N'494712986628259840', N'27', N'504990858139926528', N'2019-01-22 15:51:58.783', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'537507366317326336', N'494712986628259840', N'31', N'504990858139926528', N'2019-01-23 13:42:22.520', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'548367997115301888', N'494712986628259840', N'32', N'504990858139926528', N'2019-02-22 12:58:38.973', NULL, NULL)
GO

INSERT INTO [dbo].[Sys_rolemenu] VALUES (N'551747124224589824', N'494712986628259840', N'33', N'504990858139926528', N'2019-03-03 20:46:05.387', NULL, NULL)
GO


-- ----------------------------
-- Table structure for Sys_serialnum
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Sys_serialnum]') AND type IN ('U'))
	DROP TABLE [dbo].[Sys_serialnum]
GO

CREATE TABLE [dbo].[Sys_serialnum] (
  [SerialNumberId] int  NOT NULL,
  [SerialNumber] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [SerialCount] int  NULL,
  [TableName] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Prefix] varchar(10) COLLATE Chinese_PRC_CI_AS  NULL,
  [Digit] int  NULL,
  [Mantissa] int  NULL,
  [IsDel] tinyint  NOT NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Sys_serialnum] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'表名',
'SCHEMA', N'dbo',
'TABLE', N'Sys_serialnum',
'COLUMN', N'TableName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'前缀',
'SCHEMA', N'dbo',
'TABLE', N'Sys_serialnum',
'COLUMN', N'Prefix'
GO

EXEC sp_addextendedproperty
'MS_Description', N'位数',
'SCHEMA', N'dbo',
'TABLE', N'Sys_serialnum',
'COLUMN', N'Digit'
GO

EXEC sp_addextendedproperty
'MS_Description', N'尾数',
'SCHEMA', N'dbo',
'TABLE', N'Sys_serialnum',
'COLUMN', N'Mantissa'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1未删除   0删除',
'SCHEMA', N'dbo',
'TABLE', N'Sys_serialnum',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Sys_serialnum',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Sys_serialnum',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Sys_serialnum',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Sys_serialnum',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Sys_serialnum
-- ----------------------------
INSERT INTO [dbo].[Sys_serialnum] VALUES (N'1', N'R20190301002520000001', N'1', N'Wms_stockin', N'R', N'22', N'6', N'1', N'入库单', N'1', N'2019-01-07 11:16:09.000', N'504990858139926528', N'2019-03-01 00:25:20.113')
GO

INSERT INTO [dbo].[Sys_serialnum] VALUES (N'2', N'C20190303212032000001', N'1', N'Wms_stockout', N'C', N'22', N'6', N'1', N'出库单', N'1', N'2019-02-13 09:24:58.000', N'504990858139926528', N'2019-03-03 21:20:32.283')
GO

INSERT INTO [dbo].[Sys_serialnum] VALUES (N'3', N'M20190304224033000002', N'2', N'Wms_inventorymove', N'M', N'22', N'6', N'1', N'库存移动', N'1', N'2019-03-03 13:16:43.000', N'504990858139926528', N'2019-03-04 22:40:33.597')
GO


-- ----------------------------
-- Table structure for Sys_user
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Sys_user]') AND type IN ('U'))
	DROP TABLE [dbo].[Sys_user]
GO

CREATE TABLE [dbo].[Sys_user] (
  [UserId] bigint  NOT NULL,
  [UserName] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [UserNickname] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Pwd] nvarchar(32) COLLATE Chinese_PRC_CI_AS  NULL,
  [Sort] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [Email] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Tel] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [Mobile] nvarchar(12) COLLATE Chinese_PRC_CI_AS  NULL,
  [Sex] tinyint  NULL,
  [DeptId] bigint  NULL,
  [LoginIp] nvarchar(15) COLLATE Chinese_PRC_CI_AS  NULL,
  [LoginDate] datetime  NULL,
  [LoginTime] int  NULL,
  [IsEabled] tinyint  NULL,
  [IsDel] tinyint  NOT NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL,
  [RoleId] bigint  NULL,
  [HeadImg] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Sys_user] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'0男 1女',
'SCHEMA', N'dbo',
'TABLE', N'Sys_user',
'COLUMN', N'Sex'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1 启用 0 禁用',
'SCHEMA', N'dbo',
'TABLE', N'Sys_user',
'COLUMN', N'IsEabled'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1未删除   0删除',
'SCHEMA', N'dbo',
'TABLE', N'Sys_user',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Sys_user',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Sys_user',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Sys_user',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Sys_user',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Sys_user
-- ----------------------------
INSERT INTO [dbo].[Sys_user] VALUES (N'491786087098744832', N'admin', N'admin', N'202cb962ac59075b964b07152d234b70', NULL, NULL, N'15678676789', NULL, N'1', N'0', N'127.0.0.1', N'2019-02-27 22:09:59.980', N'1060', N'1', N'1', N'系统管理员', N'491786087098744832', N'2018-09-19 09:42:20.000', NULL, NULL, N'494712986628259840', NULL)
GO

INSERT INTO [dbo].[Sys_user] VALUES (N'504990858139926528', N'william', N'william', N'670b14728ad9902aecba32e22fa4f6bd', NULL, N'william.yang@kopsoft.cn', N'13921987606', NULL, N'1', N'492573722524254208', N'127.0.0.1', N'2019-03-05 15:06:25.963', N'1256', N'1', N'1', NULL, N'491786087098744832', N'2018-10-25 20:13:22.000', N'504990858139926528', N'2019-02-20 15:44:50.013', N'494712986628259840', N'')
GO

INSERT INTO [dbo].[Sys_user] VALUES (N'516802046381260800', N'linux', N'linux', N'e206a54e97690cce50cc872dd70ee896', NULL, NULL, NULL, NULL, N'1', N'492573722524254208', NULL, NULL, N'0', N'1', N'1', NULL, N'504990858139926528', N'2018-11-27 10:26:49.000', N'504990858139926528', N'2018-11-30 14:34:49.000', N'494712986628259840', NULL)
GO

INSERT INTO [dbo].[Sys_user] VALUES (N'516804767092047872', N'windows', N'windows', N'0f4137ed1502b5045d6083aa258b5c42', NULL, NULL, NULL, NULL, N'1', N'492967145194389504', N'127.0.0.1', N'2018-11-27 11:07:11.000', N'1', N'1', N'1', NULL, N'491786087098744832', N'2018-11-27 10:37:31.000', N'504990858139926528', N'2018-11-28 10:45:18.000', N'494712986628259840', NULL)
GO


-- ----------------------------
-- Table structure for Wms_carrier
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Wms_carrier]') AND type IN ('U'))
	DROP TABLE [dbo].[Wms_carrier]
GO

CREATE TABLE [dbo].[Wms_carrier] (
  [CarrierId] bigint  NOT NULL,
  [CarrierNo] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CarrierName] nvarchar(60) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Address] nvarchar(80) COLLATE Chinese_PRC_CI_AS  NULL,
  [Tel] nvarchar(13) COLLATE Chinese_PRC_CI_AS  NULL,
  [CarrierPerson] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [CarrierLevel] nvarchar(10) COLLATE Chinese_PRC_CI_AS  NULL,
  [Email] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDel] tinyint  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Wms_carrier] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'承运商编号',
'SCHEMA', N'dbo',
'TABLE', N'Wms_carrier',
'COLUMN', N'CarrierNo'
GO

EXEC sp_addextendedproperty
'MS_Description', N'承运商名称',
'SCHEMA', N'dbo',
'TABLE', N'Wms_carrier',
'COLUMN', N'CarrierName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'承运商地址',
'SCHEMA', N'dbo',
'TABLE', N'Wms_carrier',
'COLUMN', N'Address'
GO

EXEC sp_addextendedproperty
'MS_Description', N'联系电话',
'SCHEMA', N'dbo',
'TABLE', N'Wms_carrier',
'COLUMN', N'Tel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'联系人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_carrier',
'COLUMN', N'CarrierPerson'
GO

EXEC sp_addextendedproperty
'MS_Description', N'级别',
'SCHEMA', N'dbo',
'TABLE', N'Wms_carrier',
'COLUMN', N'CarrierLevel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'Email',
'SCHEMA', N'dbo',
'TABLE', N'Wms_carrier',
'COLUMN', N'Email'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Wms_carrier',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1 0',
'SCHEMA', N'dbo',
'TABLE', N'Wms_carrier',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_carrier',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_carrier',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_carrier',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_carrier',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Wms_carrier
-- ----------------------------
INSERT INTO [dbo].[Wms_carrier] VALUES (N'506719708456681472', N'123456', N'承运商名称', N'这是地址', N'15346400808', N'联系人', N'1', N'1459607@qq.com', N'这是测试数据     备注', N'1', N'491786087098744832', N'2018-10-30 14:43:13.000', N'491786087098744832', N'2018-10-30 14:46:09.000')
GO

INSERT INTO [dbo].[Wms_carrier] VALUES (N'506721877532606464', N'11', N'11', N'11', N'11', N'11', N'3', N'11', N'11', N'0', N'491786087098744832', N'2018-10-30 14:51:50.000', N'491786087098744832', N'2018-10-30 14:51:58.000')
GO

INSERT INTO [dbo].[Wms_carrier] VALUES (N'506722066527944704', N'00000000', N'ycy', N'11地址', N'15300000000', N'11', N'2', N'11', N'11', N'1', N'491786087098744832', N'2018-10-30 14:52:35.000', N'491786087098744832', N'2018-10-31 16:04:23.000')
GO

INSERT INTO [dbo].[Wms_carrier] VALUES (N'517506395298332672', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'504990858139926528', N'2018-11-29 09:05:39.000', NULL, NULL)
GO


-- ----------------------------
-- Table structure for Wms_customer
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Wms_customer]') AND type IN ('U'))
	DROP TABLE [dbo].[Wms_customer]
GO

CREATE TABLE [dbo].[Wms_customer] (
  [CustomerId] bigint  NOT NULL,
  [CustomerNo] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CustomerName] nvarchar(60) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Address] nvarchar(200) COLLATE Chinese_PRC_CI_AS  NULL,
  [Tel] nvarchar(13) COLLATE Chinese_PRC_CI_AS  NULL,
  [CustomerPerson] nvarchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [CustomerLevel] nvarchar(10) COLLATE Chinese_PRC_CI_AS  NULL,
  [Email] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDel] tinyint  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Wms_customer] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'客户编号',
'SCHEMA', N'dbo',
'TABLE', N'Wms_customer',
'COLUMN', N'CustomerNo'
GO

EXEC sp_addextendedproperty
'MS_Description', N'客户名称',
'SCHEMA', N'dbo',
'TABLE', N'Wms_customer',
'COLUMN', N'CustomerName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'客户地址',
'SCHEMA', N'dbo',
'TABLE', N'Wms_customer',
'COLUMN', N'Address'
GO

EXEC sp_addextendedproperty
'MS_Description', N'联系电话',
'SCHEMA', N'dbo',
'TABLE', N'Wms_customer',
'COLUMN', N'Tel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'联系人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_customer',
'COLUMN', N'CustomerPerson'
GO

EXEC sp_addextendedproperty
'MS_Description', N'级别',
'SCHEMA', N'dbo',
'TABLE', N'Wms_customer',
'COLUMN', N'CustomerLevel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'Email',
'SCHEMA', N'dbo',
'TABLE', N'Wms_customer',
'COLUMN', N'Email'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Wms_customer',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1 0',
'SCHEMA', N'dbo',
'TABLE', N'Wms_customer',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_customer',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_customer',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_customer',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_customer',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Wms_customer
-- ----------------------------
INSERT INTO [dbo].[Wms_customer] VALUES (N'507101850562985984', N'客户编号', N'客户名称', N'地址', N'15346400800', N'联系人', N'2', N'1450000000@qq.com', N'备注', N'1', N'491786087098744832', N'2018-10-31 16:01:42.000', N'491786087098744832', N'2018-10-31 16:40:15.000')
GO

INSERT INTO [dbo].[Wms_customer] VALUES (N'511381500994781184', N'001', N'45', N'.', NULL, NULL, N'1', NULL, NULL, N'0', N'491786087098744832', N'2018-11-12 11:27:31.000', N'504990858139926528', N'2018-12-22 19:54:05.000')
GO

INSERT INTO [dbo].[Wms_customer] VALUES (N'525552041037135872', N'CP001', N'K', N'苏州', N'123456', N'开始', N'2', N'lol@163.com', NULL, N'1', N'504990858139926528', N'2018-12-21 13:56:11.000', N'504990858139926528', N'2018-12-22 19:50:25.000')
GO

INSERT INTO [dbo].[Wms_customer] VALUES (N'525994765464895488', N'CP002', N'K', N'苏州', N'123456', N'开始', N'1', N'lol@163.com', NULL, N'1', N'504990858139926528', N'2018-12-22 19:15:24.000', N'504990858139926528', N'2018-12-22 19:50:16.000')
GO

INSERT INTO [dbo].[Wms_customer] VALUES (N'527043444330201088', N'11', N'11', N'11', N'11', N'11', N'1', N'11', N'1111', N'0', N'504990858139926528', N'2018-12-25 16:42:29.000', N'504990858139926528', N'2019-02-13 14:53:05.020')
GO

INSERT INTO [dbo].[Wms_customer] VALUES (N'527043582989697024', N'111', N'111·', N'11', N'11', N'111', N'1', N'11', N'11', N'0', N'504990858139926528', N'2018-12-25 16:43:02.000', N'504990858139926528', N'2019-02-13 14:53:02.270')
GO

INSERT INTO [dbo].[Wms_customer] VALUES (N'527399666271125504', N'3', N'3', N'3', N'3', N'3', NULL, NULL, NULL, N'0', N'504990858139926528', N'2018-12-26 16:17:59.000', N'504990858139926528', N'2019-02-13 14:53:11.370')
GO

INSERT INTO [dbo].[Wms_customer] VALUES (N'527399816389459968', N'5', N'5', N'5', N'5', N'5', N'3', N'5', NULL, N'0', N'504990858139926528', N'2018-12-26 16:18:35.000', N'504990858139926528', N'2019-02-13 14:53:14.200')
GO

INSERT INTO [dbo].[Wms_customer] VALUES (N'527399860224131072', N'6', N'6', N'6', N'6', N'6', N'2', N'6', N'6', N'1', N'504990858139926528', N'2018-12-26 16:18:45.000', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_customer] VALUES (N'527399921968480256', N'7', N'7', N'7', N'7', N'7', N'1', N'7', N'7', N'1', N'504990858139926528', N'2018-12-26 16:19:00.000', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_customer] VALUES (N'527400052788822016', N'8', N'8', N'8', N'8', N'8', N'2', N'8', NULL, N'1', N'504990858139926528', N'2018-12-26 16:19:31.000', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_customer] VALUES (N'527400214684762112', N'545', N'454', N'545', N'454', N'545', NULL, N'454', N'45', N'0', N'504990858139926528', N'2018-12-26 16:20:10.000', N'504990858139926528', N'2019-02-13 14:52:52.283')
GO

INSERT INTO [dbo].[Wms_customer] VALUES (N'527400253612097536', N'6565', N'656', N'56', N'565', N'656', NULL, N'56', NULL, N'0', N'504990858139926528', N'2018-12-26 16:20:19.000', N'504990858139926528', N'2019-02-13 14:52:55.007')
GO

INSERT INTO [dbo].[Wms_customer] VALUES (N'545520460960366592', N'fsdfs', N'sfdsdf', N'sdfsdf', N'sdfsdf', N'sdfd', N'1', N'sdfdf', N'sdfsdfd', N'0', N'504990858139926528', N'2019-02-14 16:23:32.553', N'504990858139926528', N'2019-02-14 16:24:14.970')
GO


-- ----------------------------
-- Table structure for Wms_delivery
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Wms_delivery]') AND type IN ('U'))
	DROP TABLE [dbo].[Wms_delivery]
GO

CREATE TABLE [dbo].[Wms_delivery] (
  [DeliveryId] bigint  NOT NULL,
  [StockOutId] bigint  NULL,
  [CarrierId] bigint  NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDel] tinyint  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL,
  [DeliveryDate] datetime  NULL,
  [TrackingNo] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Wms_delivery] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'发货主键',
'SCHEMA', N'dbo',
'TABLE', N'Wms_delivery',
'COLUMN', N'DeliveryId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'出库单主表Id',
'SCHEMA', N'dbo',
'TABLE', N'Wms_delivery',
'COLUMN', N'StockOutId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'承运商Id',
'SCHEMA', N'dbo',
'TABLE', N'Wms_delivery',
'COLUMN', N'CarrierId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Wms_delivery',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1 0',
'SCHEMA', N'dbo',
'TABLE', N'Wms_delivery',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_delivery',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_delivery',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_delivery',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_delivery',
'COLUMN', N'ModifiedDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'发货日期',
'SCHEMA', N'dbo',
'TABLE', N'Wms_delivery',
'COLUMN', N'DeliveryDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'快递单号',
'SCHEMA', N'dbo',
'TABLE', N'Wms_delivery',
'COLUMN', N'TrackingNo'
GO


-- ----------------------------
-- Records of Wms_delivery
-- ----------------------------
INSERT INTO [dbo].[Wms_delivery] VALUES (N'548371079165378560', N'547623989808201728', N'506722066527944704', N'111111', N'1', N'504990858139926528', N'2019-02-22 13:10:52.017', NULL, NULL, N'2019-02-23 00:00:00.000', N'111111111')
GO

INSERT INTO [dbo].[Wms_delivery] VALUES (N'548372903721172992', N'547939801051955200', N'506722066527944704', N'q', N'1', N'504990858139926528', N'2019-02-22 13:18:08.823', N'504990858139926528', N'2019-02-25 13:55:34.177', N'2019-02-25 00:00:00.000', N'23232522')
GO


-- ----------------------------
-- Table structure for Wms_inventory
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Wms_inventory]') AND type IN ('U'))
	DROP TABLE [dbo].[Wms_inventory]
GO

CREATE TABLE [dbo].[Wms_inventory] (
  [InventoryId] bigint  NOT NULL,
  [MaterialId] bigint  NULL,
  [StoragerackId] bigint  NULL,
  [Qty] decimal(18,2)  NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDel] tinyint  NOT NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Wms_inventory] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventory',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1 0',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventory',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventory',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventory',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventory',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventory',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Wms_inventory
-- ----------------------------
INSERT INTO [dbo].[Wms_inventory] VALUES (N'537139717875957760', N'524427831757766656', N'524427598718042112', N'17.00', NULL, N'1', N'504990858139926528', N'2019-01-22 13:21:24.743', N'504990858139926528', N'2019-01-30 20:08:11.850')
GO

INSERT INTO [dbo].[Wms_inventory] VALUES (N'537800351957385216', N'524427831757766656', N'537155079308836864', N'11.00', NULL, N'1', N'504990858139926528', N'2019-01-24 09:06:35.710', N'504990858139926528', N'2019-02-13 16:27:53.153')
GO

INSERT INTO [dbo].[Wms_inventory] VALUES (N'546584097309327360', N'546583803775156224', N'537155079308836864', N'110.00', NULL, N'1', N'504990858139926528', N'2019-02-17 14:50:03.767', N'504990858139926528', N'2019-03-04 22:41:07.607')
GO

INSERT INTO [dbo].[Wms_inventory] VALUES (N'552138199883841536', N'546583803775156224', N'524427598718042112', N'17.00', NULL, N'1', N'504990858139926528', N'2019-03-04 22:40:05.097', N'504990858139926528', N'2019-03-04 22:41:07.923')
GO


-- ----------------------------
-- Table structure for Wms_inventorymove
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Wms_inventorymove]') AND type IN ('U'))
	DROP TABLE [dbo].[Wms_inventorymove]
GO

CREATE TABLE [dbo].[Wms_inventorymove] (
  [InventorymoveId] bigint  NOT NULL,
  [InventorymoveNo] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [SourceStoragerackId] bigint  NULL,
  [AimStoragerackId] bigint  NULL,
  [Status] tinyint  NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDel] tinyint  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Wms_inventorymove] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'库存移动主键',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventorymove',
'COLUMN', N'InventorymoveId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'库存移动编号',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventorymove',
'COLUMN', N'InventorymoveNo'
GO

EXEC sp_addextendedproperty
'MS_Description', N'原货架Id',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventorymove',
'COLUMN', N'SourceStoragerackId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'目标货架',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventorymove',
'COLUMN', N'AimStoragerackId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'状态',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventorymove',
'COLUMN', N'Status'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventorymove',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1 0',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventorymove',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventorymove',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventorymove',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventorymove',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventorymove',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Wms_inventorymove
-- ----------------------------
INSERT INTO [dbo].[Wms_inventorymove] VALUES (N'551753603845455872', N'M20190303211150000001', N'537155079308836864', N'524427598718042112', N'2', NULL, N'1', N'504990858139926528', N'2019-03-03 21:11:49.140', N'504990858139926528', N'2019-03-04 22:31:56.887')
GO

INSERT INTO [dbo].[Wms_inventorymove] VALUES (N'551754446187528192', N'M20190303211510000002', N'537155079308836864', N'524427598718042112', N'2', NULL, N'1', N'504990858139926528', N'2019-03-03 21:15:09.967', N'504990858139926528', N'2019-03-04 22:29:35.720')
GO

INSERT INTO [dbo].[Wms_inventorymove] VALUES (N'552136732728885248', N'M20190304223415000001', N'537155079308836864', N'524427598718042112', N'2', NULL, N'1', N'504990858139926528', N'2019-03-04 22:33:54.647', N'504990858139926528', N'2019-03-04 22:40:05.383')
GO

INSERT INTO [dbo].[Wms_inventorymove] VALUES (N'552138320176480256', N'M20190304224033000002', N'537155079308836864', N'524427598718042112', N'2', NULL, N'1', N'504990858139926528', N'2019-03-04 22:40:30.847', N'504990858139926528', N'2019-03-04 22:41:08.233')
GO


-- ----------------------------
-- Table structure for Wms_inventoryrecord
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Wms_inventoryrecord]') AND type IN ('U'))
	DROP TABLE [dbo].[Wms_inventoryrecord]
GO

CREATE TABLE [dbo].[Wms_inventoryrecord] (
  [InventoryrecordId] bigint  NOT NULL,
  [StockInDetailId] bigint  NULL,
  [Qty] decimal(18,2)  NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDel] tinyint  NOT NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Wms_inventoryrecord] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventoryrecord',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1 0',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventoryrecord',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventoryrecord',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventoryrecord',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventoryrecord',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_inventoryrecord',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Wms_inventoryrecord
-- ----------------------------
INSERT INTO [dbo].[Wms_inventoryrecord] VALUES (N'537139743784173568', N'537135004975628288', N'2.00', NULL, N'1', N'504990858139926528', N'2019-01-22 13:21:34.493', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_inventoryrecord] VALUES (N'537139853909819392', N'537135063733633024', N'3.00', NULL, N'1', N'504990858139926528', N'2019-01-22 13:22:00.753', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_inventoryrecord] VALUES (N'537140944793763840', N'537140846764490752', N'3.00', NULL, N'1', N'504990858139926528', N'2019-01-22 13:26:20.840', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_inventoryrecord] VALUES (N'537140945032839168', N'537140925772595200', N'2.00', NULL, N'1', N'504990858139926528', N'2019-01-22 13:26:20.897', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_inventoryrecord] VALUES (N'537189739795578880', N'537187999872450560', N'5.00', NULL, N'1', N'504990858139926528', N'2019-01-22 16:40:14.490', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_inventoryrecord] VALUES (N'537800352204849152', N'537800270038433792', N'5.00', NULL, N'1', N'504990858139926528', N'2019-01-24 09:06:35.817', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_inventoryrecord] VALUES (N'537800393669738496', N'537800318184849408', N'5.00', NULL, N'1', N'504990858139926528', N'2019-01-24 09:06:45.703', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_inventoryrecord] VALUES (N'540141176775245824', N'540141151437455360', N'2.00', NULL, N'1', N'504990858139926528', N'2019-01-30 20:08:11.883', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_inventoryrecord] VALUES (N'545159163773190144', N'545159143325958144', N'1.00', NULL, N'1', N'504990858139926528', N'2019-02-13 16:27:53.213', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_inventoryrecord] VALUES (N'546584097506459648', N'546583917986054144', N'99.00', NULL, N'1', N'504990858139926528', N'2019-02-17 14:50:03.890', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_inventoryrecord] VALUES (N'546585270565208064', N'546585243549696000', N'22.00', NULL, N'1', N'504990858139926528', N'2019-02-17 14:54:43.570', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_inventoryrecord] VALUES (N'547607042362179584', N'547595001488474112', N'6.00', NULL, N'1', N'504990858139926528', N'2019-02-20 10:34:52.947', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_inventoryrecord] VALUES (N'547607042513174528', N'547606991200059392', N'7.00', NULL, N'1', N'504990858139926528', N'2019-02-20 10:34:52.987', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_inventoryrecord] VALUES (N'547612919097982976', N'547607808099483648', N'6.00', NULL, N'1', N'504990858139926528', N'2019-02-20 10:58:13.317', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_inventoryrecord] VALUES (N'547612919303503872', N'547607855021162496', N'4.00', NULL, N'1', N'504990858139926528', N'2019-02-20 10:58:14.120', NULL, NULL)
GO


-- ----------------------------
-- Table structure for Wms_invmovedetail
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Wms_invmovedetail]') AND type IN ('U'))
	DROP TABLE [dbo].[Wms_invmovedetail]
GO

CREATE TABLE [dbo].[Wms_invmovedetail] (
  [MoveDetailId] bigint  NOT NULL,
  [InventorymoveId] bigint  NULL,
  [Status] tinyint  NULL,
  [MaterialId] bigint  NULL,
  [PlanQty] decimal(18)  NULL,
  [ActQty] decimal(18)  NULL,
  [AuditinId] bigint  NULL,
  [AuditinTime] datetime  NULL,
  [IsDel] tinyint  NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Wms_invmovedetail] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'Wms_invmovedetail',
'COLUMN', N'MoveDetailId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'库存移动Id',
'SCHEMA', N'dbo',
'TABLE', N'Wms_invmovedetail',
'COLUMN', N'InventorymoveId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'物料',
'SCHEMA', N'dbo',
'TABLE', N'Wms_invmovedetail',
'COLUMN', N'MaterialId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'计划数量',
'SCHEMA', N'dbo',
'TABLE', N'Wms_invmovedetail',
'COLUMN', N'PlanQty'
GO

EXEC sp_addextendedproperty
'MS_Description', N'实际数量',
'SCHEMA', N'dbo',
'TABLE', N'Wms_invmovedetail',
'COLUMN', N'ActQty'
GO

EXEC sp_addextendedproperty
'MS_Description', N'审核人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_invmovedetail',
'COLUMN', N'AuditinId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'审核时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_invmovedetail',
'COLUMN', N'AuditinTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1 0',
'SCHEMA', N'dbo',
'TABLE', N'Wms_invmovedetail',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_invmovedetail',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_invmovedetail',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_invmovedetail',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_invmovedetail',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Wms_invmovedetail
-- ----------------------------
INSERT INTO [dbo].[Wms_invmovedetail] VALUES (N'552098474703716352', N'551753603845455872', N'2', N'546583803775156224', NULL, N'9', N'504990858139926528', N'2019-03-04 22:31:48.743', N'1', N'000', N'504990858139926528', N'2019-03-04 20:01:57.057', N'504990858139926528', N'2019-03-04 22:31:48.823')
GO

INSERT INTO [dbo].[Wms_invmovedetail] VALUES (N'552098474737270784', N'551753603845455872', N'2', N'524427831757766656', NULL, N'9', N'504990858139926528', N'2019-03-04 22:31:48.743', N'1', N'000', N'504990858139926528', N'2019-03-04 20:01:57.067', N'504990858139926528', N'2019-03-04 22:31:48.823')
GO

INSERT INTO [dbo].[Wms_invmovedetail] VALUES (N'552099592179548160', N'551754446187528192', N'1', N'546583803775156224', NULL, N'8', NULL, NULL, N'0', N'ppp', N'504990858139926528', N'2019-03-04 20:06:39.417', N'504990858139926528', N'2019-03-04 21:11:00.470')
GO

INSERT INTO [dbo].[Wms_invmovedetail] VALUES (N'552115883426709504', N'551754446187528192', N'1', N'546583803775156224', NULL, N'6', NULL, NULL, N'0', N'6', N'504990858139926528', N'2019-03-04 21:11:24.433', N'504990858139926528', N'2019-03-04 22:27:52.833')
GO

INSERT INTO [dbo].[Wms_invmovedetail] VALUES (N'552128608588529664', NULL, N'1', N'524427831757766656', NULL, N'9', NULL, NULL, N'1', N'', N'504990858139926528', N'2019-03-04 22:01:58.397', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_invmovedetail] VALUES (N'552128608970211328', N'551754446187528192', N'1', N'546583803775156224', NULL, N'6', NULL, NULL, N'0', N'6', N'504990858139926528', N'2019-03-04 22:01:58.437', N'504990858139926528', N'2019-03-04 22:02:21.143')
GO

INSERT INTO [dbo].[Wms_invmovedetail] VALUES (N'552135175849377792', N'551754446187528192', N'2', N'546583803775156224', NULL, N'6', N'504990858139926528', N'2019-03-04 22:29:35.547', N'1', N'6', N'504990858139926528', N'2019-03-04 22:28:04.107', N'504990858139926528', N'2019-03-04 22:29:35.547')
GO

INSERT INTO [dbo].[Wms_invmovedetail] VALUES (N'552136855953342464', N'552136732728885248', N'2', N'546583803775156224', NULL, N'7', N'504990858139926528', N'2019-03-04 22:40:05.247', N'1', N'7', N'504990858139926528', N'2019-03-04 22:34:44.673', N'504990858139926528', N'2019-03-04 22:40:05.247')
GO

INSERT INTO [dbo].[Wms_invmovedetail] VALUES (N'552138437935759360', N'552138320176480256', N'2', N'546583803775156224', NULL, N'10', N'504990858139926528', N'2019-03-04 22:41:08.083', N'1', N'10', N'504990858139926528', N'2019-03-04 22:41:01.853', N'504990858139926528', N'2019-03-04 22:41:08.083')
GO


-- ----------------------------
-- Table structure for Wms_material
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Wms_material]') AND type IN ('U'))
	DROP TABLE [dbo].[Wms_material]
GO

CREATE TABLE [dbo].[Wms_material] (
  [MaterialId] bigint  NOT NULL,
  [MaterialNo] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [MaterialName] nvarchar(60) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [MaterialType] bigint  NULL,
  [Unit] bigint  NULL,
  [StoragerackId] bigint  NULL,
  [ReservoirAreaId] bigint  NULL,
  [WarehouseId] bigint  NULL,
  [Qty] decimal(18)  NULL,
  [ExpiryDate] decimal(18)  NULL,
  [IsDel] tinyint  NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Wms_material] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'产品编号',
'SCHEMA', N'dbo',
'TABLE', N'Wms_material',
'COLUMN', N'MaterialNo'
GO

EXEC sp_addextendedproperty
'MS_Description', N'产品名称',
'SCHEMA', N'dbo',
'TABLE', N'Wms_material',
'COLUMN', N'MaterialName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'产品类型',
'SCHEMA', N'dbo',
'TABLE', N'Wms_material',
'COLUMN', N'MaterialType'
GO

EXEC sp_addextendedproperty
'MS_Description', N'单位',
'SCHEMA', N'dbo',
'TABLE', N'Wms_material',
'COLUMN', N'Unit'
GO

EXEC sp_addextendedproperty
'MS_Description', N'默认所属货架',
'SCHEMA', N'dbo',
'TABLE', N'Wms_material',
'COLUMN', N'StoragerackId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'默认所属库区',
'SCHEMA', N'dbo',
'TABLE', N'Wms_material',
'COLUMN', N'ReservoirAreaId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'默认所属仓库',
'SCHEMA', N'dbo',
'TABLE', N'Wms_material',
'COLUMN', N'WarehouseId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'安全库存',
'SCHEMA', N'dbo',
'TABLE', N'Wms_material',
'COLUMN', N'Qty'
GO

EXEC sp_addextendedproperty
'MS_Description', N'有效期',
'SCHEMA', N'dbo',
'TABLE', N'Wms_material',
'COLUMN', N'ExpiryDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1 0',
'SCHEMA', N'dbo',
'TABLE', N'Wms_material',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_material',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_material',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_material',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_material',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Wms_material
-- ----------------------------
INSERT INTO [dbo].[Wms_material] VALUES (N'524427831757766656', N'CP001', N'电脑', N'507099512351752192', N'507452557040287744', N'524427598718042112', N'524427482141556736', N'524427389061562368', N'10', N'1000', N'1', NULL, N'504990858139926528', N'2018-12-18 11:28:58.000', N'504990858139926528', N'2019-01-22 14:37:38.967')
GO

INSERT INTO [dbo].[Wms_material] VALUES (N'527386502016008192', N'3', N'3', N'507099512351752192', N'503747692996853760', N'524427598718042112', N'524427482141556736', N'524427389061562368', N'4', N'4', N'1', N'4', N'504990858139926528', N'2018-12-26 15:25:40.000', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_material] VALUES (N'546583803775156224', N'a', N'双飞燕鼠标', N'524588722197364736', N'503747692996853760', N'537155079308836864', N'524427482141556736', N'524427389061562368', N'1', N'1', N'1', NULL, N'504990858139926528', N'2019-02-17 14:48:53.693', N'504990858139926528', N'2019-02-17 15:00:05.143')
GO

INSERT INTO [dbo].[Wms_material] VALUES (N'549870694884704256', N'ABC', N'ABC', N'507099447742693376', N'503747692996853760', N'537155079308836864', N'524427482141556736', N'524427389061562368', N'123', N'123', N'1', NULL, N'504990858139926528', N'2019-02-26 16:29:47.880', NULL, NULL)
GO


-- ----------------------------
-- Table structure for Wms_reservoirarea
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Wms_reservoirarea]') AND type IN ('U'))
	DROP TABLE [dbo].[Wms_reservoirarea]
GO

CREATE TABLE [dbo].[Wms_reservoirarea] (
  [ReservoirAreaId] bigint  NOT NULL,
  [ReservoirAreaNo] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [ReservoirAreaName] nvarchar(60) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [WarehouseId] bigint  NOT NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDel] tinyint  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Wms_reservoirarea] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'Wms_reservoirarea',
'COLUMN', N'ReservoirAreaId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'库区编号',
'SCHEMA', N'dbo',
'TABLE', N'Wms_reservoirarea',
'COLUMN', N'ReservoirAreaNo'
GO

EXEC sp_addextendedproperty
'MS_Description', N'库区名称',
'SCHEMA', N'dbo',
'TABLE', N'Wms_reservoirarea',
'COLUMN', N'ReservoirAreaName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'所属仓库ID',
'SCHEMA', N'dbo',
'TABLE', N'Wms_reservoirarea',
'COLUMN', N'WarehouseId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Wms_reservoirarea',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1 0',
'SCHEMA', N'dbo',
'TABLE', N'Wms_reservoirarea',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_reservoirarea',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_reservoirarea',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_reservoirarea',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_reservoirarea',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Wms_reservoirarea
-- ----------------------------
INSERT INTO [dbo].[Wms_reservoirarea] VALUES (N'524427482141556736', N'YA001', N'原材料库区', N'524427389061562368', N'原材料库区', N'1', N'504990858139926528', N'2018-12-18 11:27:35.000', NULL, NULL)
GO


-- ----------------------------
-- Table structure for Wms_stockin
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Wms_stockin]') AND type IN ('U'))
	DROP TABLE [dbo].[Wms_stockin]
GO

CREATE TABLE [dbo].[Wms_stockin] (
  [StockInId] bigint  NOT NULL,
  [StockInNo] nvarchar(32) COLLATE Chinese_PRC_CI_AS  NULL,
  [StockInType] bigint  NULL,
  [SupplierId] bigint  NULL,
  [OrderNo] nvarchar(32) COLLATE Chinese_PRC_CI_AS  NULL,
  [StockInStatus] tinyint  NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDel] tinyint  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Wms_stockin] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockin',
'COLUMN', N'StockInId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'入库单号',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockin',
'COLUMN', N'StockInNo'
GO

EXEC sp_addextendedproperty
'MS_Description', N'入库类型',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockin',
'COLUMN', N'StockInType'
GO

EXEC sp_addextendedproperty
'MS_Description', N'供应商',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockin',
'COLUMN', N'SupplierId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'订单号',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockin',
'COLUMN', N'OrderNo'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockin',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1 0',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockin',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockin',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockin',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockin',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockin',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Wms_stockin
-- ----------------------------
INSERT INTO [dbo].[Wms_stockin] VALUES (N'537108339251740672', N'R20190122111638000001', N'503752972895780864', N'516603607227826176', N'1', N'2', NULL, N'1', N'504990858139926528', N'2019-01-22 11:16:19.310', N'504990858139926528', N'2019-01-22 11:17:14.047')
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'537134955403149312', N'R20190122130232000002', N'503752972895780864', N'524934728818622464', N'2', N'2', NULL, N'1', N'504990858139926528', N'2019-01-22 13:02:22.187', N'504990858139926528', N'2019-01-22 13:22:07.270')
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'537140728858411008', N'R20190122132529000003', N'503752972895780864', N'516603607227826176', N'3', N'2', NULL, N'1', N'504990858139926528', N'2019-01-22 13:25:28.097', N'504990858139926528', N'2019-01-22 13:26:20.967')
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'537187938673360896', N'R20190122163305000004', N'503752972895780864', N'516603607227826176', N'4', N'2', NULL, N'1', N'504990858139926528', N'2019-01-22 16:33:04.287', N'504990858139926528', N'2019-01-22 16:40:14.550')
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'537800200954052608', N'R20190124090559000001', N'503752972895780864', N'524934728818622464', N'5', N'2', NULL, N'1', N'504990858139926528', N'2019-01-24 09:05:57.967', N'504990858139926528', N'2019-01-24 09:06:45.813')
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'537869335801102336', N'R20190124134042000002', N'503752972895780864', N'524934728818622464', N'6', N'1', NULL, N'1', N'504990858139926528', N'2019-01-24 13:40:41.420', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'539713158118375424', N'R20190129154724000001', N'503752972895780864', N'516603607227826176', N'12', N'1', NULL, N'1', N'504990858139926528', N'2019-01-29 15:47:23.720', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'539716994845376512', N'R20190129160239000002', N'503752972895780864', N'516603607227826176', N'11', N'1', NULL, N'1', N'504990858139926528', N'2019-01-29 16:02:37.100', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'539717642739515392', N'R20190129160513000003', N'503752972895780864', N'516603607227826176', N'13', N'1', NULL, N'1', N'504990858139926528', N'2019-01-29 16:05:13.390', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'539723783821328384', N'R20190129162937000004', N'503752972895780864', N'516603607227826176', N'14', N'1', N'14', N'1', N'504990858139926528', N'2019-01-29 16:29:36.967', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'540141040410034176', N'R20190130200739000001', N'503752972895780864', N'516603607227826176', N'fff', N'2', N'7777', N'0', N'504990858139926528', N'2019-01-30 20:07:38.757', N'504990858139926528', N'2019-02-13 16:33:39.503')
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'545155893105262592', N'R20190213161453000001', N'503752972895780864', N'516603607227826176', NULL, N'1', NULL, N'0', N'504990858139926528', N'2019-02-13 16:14:53.387', N'504990858139926528', N'2019-02-13 16:33:45.857')
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'545155924675788800', N'R20190213161500000001', N'525173270467575808', N'516603607227826176', NULL, N'1', NULL, N'0', N'504990858139926528', N'2019-02-13 16:15:00.897', N'504990858139926528', N'2019-02-13 16:33:48.493')
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'545156477673799680', N'R20190213161712000002', N'503752972895780864', N'516603607227826176', NULL, N'2', NULL, N'0', N'504990858139926528', N'2019-02-13 16:17:11.867', N'504990858139926528', N'2019-02-13 16:27:56.850')
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'546583490531950592', N'R20190217144739000001', N'503752972895780864', N'516603607227826176', N'a', N'2', N'a', N'1', N'504990858139926528', N'2019-02-17 14:47:38.207', N'504990858139926528', N'2019-02-17 14:50:03.983')
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'546585150750720000', N'R20190217145414000002', N'503752972895780864', N'524934728818622464', N'b', N'2', N'b', N'1', N'504990858139926528', N'2019-02-17 14:54:14.757', N'504990858139926528', N'2019-02-17 14:54:43.663')
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'547594949290360832', N'R20190220094649000001', N'503752972895780864', N'516603607227826176', N'ui', N'2', NULL, N'1', N'504990858139926528', N'2019-02-20 09:46:47.953', N'504990858139926528', N'2019-02-20 10:34:53.037')
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'547607738297876480', N'R20190220103738000002', N'503752972895780864', N'516603607227826176', N'7', N'2', NULL, N'1', N'504990858139926528', N'2019-02-20 10:37:37.277', N'504990858139926528', N'2019-02-20 10:58:14.203')
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'549524779011407872', N'R20190225173516000001', N'503752972895780864', N'516603607227826176', N'1211', N'1', NULL, N'1', N'504990858139926528', N'2019-02-25 17:35:16.037', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_stockin] VALUES (N'550715135702859776', N'R20190301002520000001', N'503752972895780864', N'516603607227826176', N'dfdfdfdf', N'1', N'dfsdfsdfsdf', N'0', N'504990858139926528', N'2019-03-01 00:25:19.600', N'504990858139926528', N'2019-03-03 20:44:19.000')
GO


-- ----------------------------
-- Table structure for Wms_stockindetail
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Wms_stockindetail]') AND type IN ('U'))
	DROP TABLE [dbo].[Wms_stockindetail]
GO

CREATE TABLE [dbo].[Wms_stockindetail] (
  [StockInDetailId] bigint  NOT NULL,
  [StockInId] bigint  NULL,
  [Status] tinyint  NULL,
  [MaterialId] bigint  NULL,
  [PlanInQty] decimal(18)  NULL,
  [ActInQty] decimal(18)  NULL,
  [StoragerackId] bigint  NULL,
  [AuditinId] bigint  NULL,
  [AuditinTime] datetime  NULL,
  [IsDel] tinyint  NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Wms_stockindetail] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockindetail',
'COLUMN', N'StockInDetailId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'入库单号',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockindetail',
'COLUMN', N'StockInId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'物料',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockindetail',
'COLUMN', N'MaterialId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'计划数量',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockindetail',
'COLUMN', N'PlanInQty'
GO

EXEC sp_addextendedproperty
'MS_Description', N'实际数量',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockindetail',
'COLUMN', N'ActInQty'
GO

EXEC sp_addextendedproperty
'MS_Description', N'货架',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockindetail',
'COLUMN', N'StoragerackId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'审核人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockindetail',
'COLUMN', N'AuditinId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'审核时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockindetail',
'COLUMN', N'AuditinTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1 0',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockindetail',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockindetail',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockindetail',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockindetail',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockindetail',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Wms_stockindetail
-- ----------------------------
INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'537108438593830912', N'537108339251740672', N'2', N'524427831757766656', N'1', N'1', N'524427598718042112', N'504990858139926528', N'2019-01-22 11:17:14.007', N'1', N'1', N'504990858139926528', N'2019-01-22 11:17:10.783', N'504990858139926528', N'2019-01-22 11:17:14.007')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'537135004975628288', N'537134955403149312', N'2', N'524427831757766656', N'2', N'2', N'524427598718042112', N'504990858139926528', N'2019-01-22 13:22:04.973', N'1', N'1', N'504990858139926528', N'2019-01-22 13:02:44.653', N'504990858139926528', N'2019-01-22 13:22:04.997')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'537135063733633024', N'537134955403149312', N'2', N'524427831757766656', N'3', N'3', N'524427598718042112', N'504990858139926528', N'2019-01-22 13:22:04.973', N'1', N'1', N'504990858139926528', N'2019-01-22 13:02:58.670', N'504990858139926528', N'2019-01-22 13:22:04.997')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'537140846764490752', N'537140728858411008', N'2', N'524427831757766656', N'3', N'3', N'524427598718042112', N'504990858139926528', N'2019-01-22 13:26:20.933', N'1', NULL, N'504990858139926528', N'2019-01-22 13:25:57.443', N'504990858139926528', N'2019-01-22 13:26:20.933')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'537140925772595200', N'537140728858411008', N'2', N'524427831757766656', N'2', N'2', N'524427598718042112', N'504990858139926528', N'2019-01-22 13:26:20.933', N'1', NULL, N'504990858139926528', N'2019-01-22 13:26:16.300', N'504990858139926528', N'2019-01-22 13:26:20.933')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'537187999872450560', N'537187938673360896', N'2', N'524427831757766656', N'5', N'5', N'524427598718042112', N'504990858139926528', N'2019-01-22 16:40:14.523', N'1', NULL, N'504990858139926528', N'2019-01-22 16:33:19.637', N'504990858139926528', N'2019-01-22 16:40:14.523')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'537800270038433792', N'537800200954052608', N'2', N'524427831757766656', N'5', N'5', N'537155079308836864', N'504990858139926528', N'2019-01-24 09:06:45.767', N'1', NULL, N'504990858139926528', N'2019-01-24 09:06:16.220', N'504990858139926528', N'2019-01-24 09:06:45.767')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'537800318184849408', N'537800200954052608', N'2', N'524427831757766656', N'5', N'5', N'537155079308836864', N'504990858139926528', N'2019-01-24 09:06:45.767', N'1', NULL, N'504990858139926528', N'2019-01-24 09:06:27.703', N'504990858139926528', N'2019-01-24 09:06:45.767')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'537869389718880256', N'537869335801102336', N'1', N'524427831757766656', N'6', N'6', N'537155079308836864', NULL, NULL, N'1', NULL, N'504990858139926528', N'2019-01-24 13:40:55.840', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'539723973068324864', N'539723783821328384', N'1', N'524427831757766656', N'12', N'12', N'537155079308836864', NULL, NULL, N'1', N'12', N'504990858139926528', N'2019-01-29 16:30:22.763', N'504990858139926528', N'2019-01-29 16:30:35.083')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'540141151437455360', N'540141040410034176', N'2', N'524427831757766656', N'1', N'2', N'524427598718042112', N'504990858139926528', N'2019-01-30 20:08:11.913', N'0', N'2', N'504990858139926528', N'2019-01-30 20:08:05.837', N'504990858139926528', N'2019-02-13 16:33:39.113')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'545159143325958144', N'545156477673799680', N'2', N'524427831757766656', N'1', N'1', N'537155079308836864', N'504990858139926528', N'2019-02-13 16:27:53.240', N'0', NULL, N'504990858139926528', N'2019-02-13 16:27:47.810', N'504990858139926528', N'2019-02-13 16:27:56.827')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'546583917986054144', N'546583490531950592', N'2', N'546583803775156224', N'99', N'99', N'537155079308836864', N'504990858139926528', N'2019-02-17 14:50:03.937', N'1', NULL, N'504990858139926528', N'2019-02-17 14:49:21.043', N'504990858139926528', N'2019-02-17 14:50:03.937')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'546585243549696000', N'546585150750720000', N'2', N'546583803775156224', N'22', N'22', N'537155079308836864', N'504990858139926528', N'2019-02-17 14:54:43.617', N'1', N'22', N'504990858139926528', N'2019-02-17 14:54:37.057', N'504990858139926528', N'2019-02-17 14:54:43.617')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'547595001488474112', N'547594949290360832', N'2', N'546583803775156224', N'6', N'6', N'537155079308836864', N'504990858139926528', N'2019-02-20 10:34:53.010', N'1', NULL, N'504990858139926528', N'2019-02-20 09:47:02.163', N'504990858139926528', N'2019-02-20 10:34:53.010')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'547606991200059392', N'547594949290360832', N'2', N'546583803775156224', N'7', N'7', N'537155079308836864', N'504990858139926528', N'2019-02-20 10:34:53.010', N'1', NULL, N'504990858139926528', N'2019-02-20 10:34:39.590', N'504990858139926528', N'2019-02-20 10:34:53.010')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'547607808099483648', N'547607738297876480', N'2', N'546583803775156224', N'6', N'6', N'537155079308836864', N'504990858139926528', N'2019-02-20 10:58:14.170', N'1', NULL, N'504990858139926528', N'2019-02-20 10:37:55.500', N'504990858139926528', N'2019-02-20 10:58:14.170')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'547607855021162496', N'547607738297876480', N'2', N'546583803775156224', N'4', N'4', N'537155079308836864', N'504990858139926528', N'2019-02-20 10:58:14.170', N'1', NULL, N'504990858139926528', N'2019-02-20 10:38:06.700', N'504990858139926528', N'2019-02-20 10:58:14.170')
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'549524823173234688', N'549524779011407872', N'1', N'546583803775156224', N'1', N'1', N'537155079308836864', NULL, NULL, N'1', NULL, N'504990858139926528', N'2019-02-25 17:35:27.490', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_stockindetail] VALUES (N'551746644366852096', N'550715135702859776', N'1', N'549870694884704256', N'2', N'2', N'537155079308836864', NULL, NULL, N'0', NULL, N'504990858139926528', N'2019-03-03 20:44:09.927', N'504990858139926528', N'2019-03-03 20:44:18.903')
GO


-- ----------------------------
-- Table structure for Wms_stockout
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Wms_stockout]') AND type IN ('U'))
	DROP TABLE [dbo].[Wms_stockout]
GO

CREATE TABLE [dbo].[Wms_stockout] (
  [StockOutId] bigint  NOT NULL,
  [StockOutNo] varchar(22) COLLATE Chinese_PRC_CI_AS  NULL,
  [OrderNo] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [StockOutType] bigint  NULL,
  [CustomerId] bigint  NULL,
  [StockOutStatus] tinyint  NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDel] tinyint  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Wms_stockout] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'出库单，系统自动生成',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockout',
'COLUMN', N'StockOutNo'
GO

EXEC sp_addextendedproperty
'MS_Description', N'出库订单',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockout',
'COLUMN', N'OrderNo'
GO

EXEC sp_addextendedproperty
'MS_Description', N'出库类型',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockout',
'COLUMN', N'StockOutType'
GO

EXEC sp_addextendedproperty
'MS_Description', N'客户',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockout',
'COLUMN', N'CustomerId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockout',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1 0',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockout',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockout',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockout',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockout',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockout',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Wms_stockout
-- ----------------------------
INSERT INTO [dbo].[Wms_stockout] VALUES (N'547623989808201728', N'C20190220114213000002', N'1', N'503753018307510272', N'525552041037135872', N'5', N'1', N'1', N'504990858139926528', N'2019-02-20 11:42:12.553', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_stockout] VALUES (N'547939801051955200', N'C20190221083708000001', N'2', N'503753018307510272', N'527399860224131072', N'5', NULL, N'1', N'504990858139926528', N'2019-02-21 08:37:07.360', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_stockout] VALUES (N'551755793792237568', N'C20190303212032000001', N'12111', N'503753018307510272', N'525552041037135872', N'1', NULL, N'1', N'504990858139926528', N'2019-03-03 21:20:31.920', NULL, NULL)
GO


-- ----------------------------
-- Table structure for Wms_stockoutdetail
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Wms_stockoutdetail]') AND type IN ('U'))
	DROP TABLE [dbo].[Wms_stockoutdetail]
GO

CREATE TABLE [dbo].[Wms_stockoutdetail] (
  [StockOutDetailId] bigint  NOT NULL,
  [StockOutId] bigint  NULL,
  [Status] tinyint  NULL,
  [MaterialId] bigint  NULL,
  [PlanOutQty] decimal(18)  NULL,
  [ActOutQty] decimal(18)  NULL,
  [StoragerackId] bigint  NULL,
  [AuditinId] bigint  NULL,
  [AuditinTime] datetime  NULL,
  [IsDel] tinyint  NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Wms_stockoutdetail] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockoutdetail',
'COLUMN', N'StockOutDetailId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'出库单',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockoutdetail',
'COLUMN', N'StockOutId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'物料',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockoutdetail',
'COLUMN', N'MaterialId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'计划数量',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockoutdetail',
'COLUMN', N'PlanOutQty'
GO

EXEC sp_addextendedproperty
'MS_Description', N'实际数量',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockoutdetail',
'COLUMN', N'ActOutQty'
GO

EXEC sp_addextendedproperty
'MS_Description', N'货架',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockoutdetail',
'COLUMN', N'StoragerackId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'审核人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockoutdetail',
'COLUMN', N'AuditinId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'审核时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockoutdetail',
'COLUMN', N'AuditinTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1 0',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockoutdetail',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockoutdetail',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockoutdetail',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockoutdetail',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_stockoutdetail',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Wms_stockoutdetail
-- ----------------------------
INSERT INTO [dbo].[Wms_stockoutdetail] VALUES (N'547624041066790912', N'547623989808201728', N'2', N'546583803775156224', N'11', N'11', N'537155079308836864', N'504990858139926528', N'2019-02-20 11:42:34.950', N'1', N'11', N'504990858139926528', N'2019-02-20 11:42:25.733', N'504990858139926528', N'2019-02-20 11:42:34.950')
GO

INSERT INTO [dbo].[Wms_stockoutdetail] VALUES (N'547978395552579584', N'547939801051955200', N'2', N'546583803775156224', N'2', N'2', N'537155079308836864', N'504990858139926528', N'2019-02-22 13:17:57.280', N'1', NULL, N'504990858139926528', N'2019-02-21 11:10:29.367', N'504990858139926528', N'2019-02-22 13:17:57.280')
GO


-- ----------------------------
-- Table structure for Wms_storagerack
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Wms_storagerack]') AND type IN ('U'))
	DROP TABLE [dbo].[Wms_storagerack]
GO

CREATE TABLE [dbo].[Wms_storagerack] (
  [StorageRackId] bigint  NOT NULL,
  [StorageRackNo] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [StorageRackName] nvarchar(60) COLLATE Chinese_PRC_CI_AS  NULL,
  [ReservoirAreaId] bigint  NOT NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDel] tinyint  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL,
  [WarehouseId] bigint  NULL
)
GO

ALTER TABLE [dbo].[Wms_storagerack] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'货架Id',
'SCHEMA', N'dbo',
'TABLE', N'Wms_storagerack',
'COLUMN', N'StorageRackId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'货架编号',
'SCHEMA', N'dbo',
'TABLE', N'Wms_storagerack',
'COLUMN', N'StorageRackNo'
GO

EXEC sp_addextendedproperty
'MS_Description', N'货架名称',
'SCHEMA', N'dbo',
'TABLE', N'Wms_storagerack',
'COLUMN', N'StorageRackName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'所属库区',
'SCHEMA', N'dbo',
'TABLE', N'Wms_storagerack',
'COLUMN', N'ReservoirAreaId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Wms_storagerack',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1 0',
'SCHEMA', N'dbo',
'TABLE', N'Wms_storagerack',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_storagerack',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_storagerack',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_storagerack',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_storagerack',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Wms_storagerack
-- ----------------------------
INSERT INTO [dbo].[Wms_storagerack] VALUES (N'524427598718042112', N'YA0001', N'原材料货架', N'524427482141556736', NULL, N'1', N'504990858139926528', N'2018-12-18 11:28:03.000', NULL, NULL, N'524427389061562368')
GO

INSERT INTO [dbo].[Wms_storagerack] VALUES (N'537155079308836864', N'Y001', N'Y001', N'524427482141556736', NULL, N'1', N'504990858139926528', N'2019-01-22 14:22:29.580', NULL, NULL, N'524427389061562368')
GO


-- ----------------------------
-- Table structure for Wms_supplier
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Wms_supplier]') AND type IN ('U'))
	DROP TABLE [dbo].[Wms_supplier]
GO

CREATE TABLE [dbo].[Wms_supplier] (
  [SupplierId] bigint  NOT NULL,
  [SupplierNo] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [SupplierName] nvarchar(60) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Address] nvarchar(80) COLLATE Chinese_PRC_CI_AS  NULL,
  [Tel] nvarchar(13) COLLATE Chinese_PRC_CI_AS  NULL,
  [SupplierPerson] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [SupplierLevel] nvarchar(10) COLLATE Chinese_PRC_CI_AS  NULL,
  [Email] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDel] tinyint  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Wms_supplier] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'供应商编号',
'SCHEMA', N'dbo',
'TABLE', N'Wms_supplier',
'COLUMN', N'SupplierNo'
GO

EXEC sp_addextendedproperty
'MS_Description', N'供应商名称',
'SCHEMA', N'dbo',
'TABLE', N'Wms_supplier',
'COLUMN', N'SupplierName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'供应商地址',
'SCHEMA', N'dbo',
'TABLE', N'Wms_supplier',
'COLUMN', N'Address'
GO

EXEC sp_addextendedproperty
'MS_Description', N'联系电话',
'SCHEMA', N'dbo',
'TABLE', N'Wms_supplier',
'COLUMN', N'Tel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'联系人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_supplier',
'COLUMN', N'SupplierPerson'
GO

EXEC sp_addextendedproperty
'MS_Description', N'级别',
'SCHEMA', N'dbo',
'TABLE', N'Wms_supplier',
'COLUMN', N'SupplierLevel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'Email',
'SCHEMA', N'dbo',
'TABLE', N'Wms_supplier',
'COLUMN', N'Email'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Wms_supplier',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'1 0',
'SCHEMA', N'dbo',
'TABLE', N'Wms_supplier',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_supplier',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_supplier',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_supplier',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_supplier',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Wms_supplier
-- ----------------------------
INSERT INTO [dbo].[Wms_supplier] VALUES (N'516603607227826176', N'A', N'A', NULL, NULL, NULL, N'1', NULL, NULL, N'1', N'516234783362121728', N'2019-01-22 21:18:18.000', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_supplier] VALUES (N'524934728818622464', N'B', N'B', NULL, NULL, NULL, N'1', NULL, NULL, N'1', N'504990858139926528', N'2019-01-22 21:03:11.000', N'504990858139926528', N'2018-12-19 21:41:53.000')
GO


-- ----------------------------
-- Table structure for Wms_warehouse
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Wms_warehouse]') AND type IN ('U'))
	DROP TABLE [dbo].[Wms_warehouse]
GO

CREATE TABLE [dbo].[Wms_warehouse] (
  [WarehouseId] bigint  NOT NULL,
  [WarehouseNo] nvarchar(20) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [WarehouseName] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [IsDel] tinyint  NULL,
  [Remark] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CreateBy] bigint  NULL,
  [CreateDate] datetime  NULL,
  [ModifiedBy] bigint  NULL,
  [ModifiedDate] datetime  NULL
)
GO

ALTER TABLE [dbo].[Wms_warehouse] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'仓库编号',
'SCHEMA', N'dbo',
'TABLE', N'Wms_warehouse',
'COLUMN', N'WarehouseNo'
GO

EXEC sp_addextendedproperty
'MS_Description', N'仓库名称',
'SCHEMA', N'dbo',
'TABLE', N'Wms_warehouse',
'COLUMN', N'WarehouseName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'是否删除 1未删除  0删除',
'SCHEMA', N'dbo',
'TABLE', N'Wms_warehouse',
'COLUMN', N'IsDel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Wms_warehouse',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_warehouse',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_warehouse',
'COLUMN', N'CreateDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'Wms_warehouse',
'COLUMN', N'ModifiedBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'Wms_warehouse',
'COLUMN', N'ModifiedDate'
GO


-- ----------------------------
-- Records of Wms_warehouse
-- ----------------------------
INSERT INTO [dbo].[Wms_warehouse] VALUES (N'524427389061562368', N'A001', N'原材料仓库', N'1', N'原材料仓库', N'504990858139926528', N'2018-12-18 11:27:12.000', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_warehouse] VALUES (N'539713274233487360', N'AC', N'AC', N'1', N'AC', N'504990858139926528', N'2019-01-29 15:47:51.913', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_warehouse] VALUES (N'550520278032056320', N'1', N'1', N'1', N'4；
4242】
2】

‘
1’', N'504990858139926528', N'2019-02-28 11:31:01.867', N'504990858139926528', N'2019-02-28 11:31:47.913')
GO

INSERT INTO [dbo].[Wms_warehouse] VALUES (N'550520346348879872', N'2', N'2', N'1', N'4444444', N'504990858139926528', N'2019-02-28 11:31:18.723', N'504990858139926528', N'2019-02-28 11:31:34.060')
GO

INSERT INTO [dbo].[Wms_warehouse] VALUES (N'550523447063609344', N'3', N'3', N'1', N'3', N'504990858139926528', N'2019-02-28 11:43:37.987', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_warehouse] VALUES (N'550523474897010688', N'4', N'4', N'1', NULL, N'504990858139926528', N'2019-02-28 11:43:44.623', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_warehouse] VALUES (N'550523501019136000', N'5', N'5', N'1', N'5', N'504990858139926528', N'2019-02-28 11:43:50.850', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_warehouse] VALUES (N'550523530240851968', N'6', N'6', N'1', N'6', N'504990858139926528', N'2019-02-28 11:43:57.817', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_warehouse] VALUES (N'550523561538748416', N'7', N'7', N'1', NULL, N'504990858139926528', N'2019-02-28 11:44:05.280', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_warehouse] VALUES (N'550523594736664576', N'8', N'8', N'1', N'8', N'504990858139926528', N'2019-02-28 11:44:13.193', NULL, NULL)
GO

INSERT INTO [dbo].[Wms_warehouse] VALUES (N'550523629612302336', N'9', N'9', N'0', NULL, N'504990858139926528', N'2019-02-28 11:44:21.510', N'504990858139926528', N'2019-02-28 11:45:26.170')
GO

INSERT INTO [dbo].[Wms_warehouse] VALUES (N'550523660037783552', N'10', N'010', N'0', NULL, N'504990858139926528', N'2019-02-28 11:44:28.763', N'504990858139926528', N'2019-02-28 11:45:22.610')
GO

INSERT INTO [dbo].[Wms_warehouse] VALUES (N'550523686336069632', N'11', N'11', N'0', NULL, N'504990858139926528', N'2019-02-28 11:44:35.033', N'504990858139926528', N'2019-02-28 11:45:19.277')
GO

INSERT INTO [dbo].[Wms_warehouse] VALUES (N'550523716635721728', N'12', N'12', N'0', NULL, N'504990858139926528', N'2019-02-28 11:44:42.257', N'504990858139926528', N'2019-02-28 11:45:15.840')
GO

INSERT INTO [dbo].[Wms_warehouse] VALUES (N'550524170518134784', N'15', N'15', N'1', N'2', N'504990858139926528', N'2019-02-28 11:46:30.470', NULL, NULL)
GO


-- ----------------------------
-- Primary Key structure for table Sys_dept
-- ----------------------------
ALTER TABLE [dbo].[Sys_dept] ADD CONSTRAINT [PK__sys_dept__014881AE6EC0713C] PRIMARY KEY CLUSTERED ([DeptId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Sys_dict
-- ----------------------------
ALTER TABLE [dbo].[Sys_dict] ADD CONSTRAINT [PK__sys_dict__9882F3F0719CDDE7] PRIMARY KEY CLUSTERED ([DictId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Sys_log
-- ----------------------------
ALTER TABLE [dbo].[Sys_log] ADD CONSTRAINT [PK__sys_log__5E54864874794A92] PRIMARY KEY CLUSTERED ([LogId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Sys_menu_wms
-- ----------------------------
ALTER TABLE [dbo].[Sys_menu_wms] ADD CONSTRAINT [PK__sys_menu__C99ED2307A3223E8] PRIMARY KEY CLUSTERED ([MenuId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Sys_rolemenu
-- ----------------------------
ALTER TABLE [dbo].[Sys_rolemenu] ADD CONSTRAINT [PK__sys_role__F86287B67D0E9093] PRIMARY KEY CLUSTERED ([RoleMenuId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Sys_serialnum
-- ----------------------------
ALTER TABLE [dbo].[Sys_serialnum] ADD CONSTRAINT [PK__Sys_seri__BA34B05627F8EE98] PRIMARY KEY CLUSTERED ([SerialNumberId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Sys_user
-- ----------------------------
ALTER TABLE [dbo].[Sys_user] ADD CONSTRAINT [PK__sys_user__1788CC4C7FEAFD3E] PRIMARY KEY CLUSTERED ([UserId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Wms_carrier
-- ----------------------------
ALTER TABLE [dbo].[Wms_carrier] ADD CONSTRAINT [PK__wms_carr__CB82055902C769E9] PRIMARY KEY CLUSTERED ([CarrierId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Wms_customer
-- ----------------------------
ALTER TABLE [dbo].[Wms_customer] ADD CONSTRAINT [PK__wms_cust__A4AE64D805A3D694] PRIMARY KEY CLUSTERED ([CustomerId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Wms_delivery
-- ----------------------------
ALTER TABLE [dbo].[Wms_delivery] ADD CONSTRAINT [PK__Wms_deli__626D8FCE3EDC53F0] PRIMARY KEY CLUSTERED ([DeliveryId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Wms_inventory
-- ----------------------------
ALTER TABLE [dbo].[Wms_inventory] ADD CONSTRAINT [PK__Wms_inve__F5FDE6B32EA5EC27] PRIMARY KEY CLUSTERED ([InventoryId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Wms_inventorymove
-- ----------------------------
ALTER TABLE [dbo].[Wms_inventorymove] ADD CONSTRAINT [PK__Wms_inve__A1254B8D42ACE4D4] PRIMARY KEY CLUSTERED ([InventorymoveId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Wms_inventoryrecord
-- ----------------------------
ALTER TABLE [dbo].[Wms_inventoryrecord] ADD CONSTRAINT [PK__Wms_inve__F5FDE6B32EA5EC27_copy1] PRIMARY KEY CLUSTERED ([InventoryrecordId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Wms_invmovedetail
-- ----------------------------
ALTER TABLE [dbo].[Wms_invmovedetail] ADD CONSTRAINT [PK__Wms_stoc__EEDA101354CB950F] PRIMARY KEY CLUSTERED ([MoveDetailId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Wms_material
-- ----------------------------
ALTER TABLE [dbo].[Wms_material] ADD CONSTRAINT [PK__wms_mate__C50610F70B5CAFEA] PRIMARY KEY CLUSTERED ([MaterialId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Wms_reservoirarea
-- ----------------------------
ALTER TABLE [dbo].[Wms_reservoirarea] ADD CONSTRAINT [PK__wms_rese__0CB017220E391C95] PRIMARY KEY CLUSTERED ([ReservoirAreaId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Wms_stockin
-- ----------------------------
ALTER TABLE [dbo].[Wms_stockin] ADD CONSTRAINT [PK__wms_stoc__794DA66C11158940] PRIMARY KEY CLUSTERED ([StockInId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Wms_stockindetail
-- ----------------------------
ALTER TABLE [dbo].[Wms_stockindetail] ADD CONSTRAINT [PK__wms_stoc__EEDA101313F1F5EB] PRIMARY KEY CLUSTERED ([StockInDetailId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Wms_stockout
-- ----------------------------
ALTER TABLE [dbo].[Wms_stockout] ADD CONSTRAINT [PK__Wms_stoc__C5308D7A3552E9B6] PRIMARY KEY CLUSTERED ([StockOutId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Wms_stockoutdetail
-- ----------------------------
ALTER TABLE [dbo].[Wms_stockoutdetail] ADD CONSTRAINT [PK__wms_stoc__EEDA101313F1F5EB_copy1] PRIMARY KEY CLUSTERED ([StockOutDetailId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Wms_storagerack
-- ----------------------------
ALTER TABLE [dbo].[Wms_storagerack] ADD CONSTRAINT [PK__wms_stor__243CF6DE16CE6296] PRIMARY KEY CLUSTERED ([StorageRackId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Wms_supplier
-- ----------------------------
ALTER TABLE [dbo].[Wms_supplier] ADD CONSTRAINT [PK__wms_supp__4BE666B419AACF41] PRIMARY KEY CLUSTERED ([SupplierId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Wms_warehouse
-- ----------------------------
ALTER TABLE [dbo].[Wms_warehouse] ADD CONSTRAINT [PK__wms_ware__2608AFF91C873BEC] PRIMARY KEY CLUSTERED ([WarehouseId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

