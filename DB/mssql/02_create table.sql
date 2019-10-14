/*
 Navicat Premium Data Transfer

 Source Server         : (local-sqlserver)
 Source Server Type    : SQL Server
 Source Server Version : 13001742
 Source Host           : localhost:1433
 Source Catalog        : KWMS
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 13001742
 File Encoding         : 65001

 Date: 29/06/2019 22:32:39
*/

use KopSoftWms
go

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
  [Browser] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
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

