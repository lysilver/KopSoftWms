/*
 Navicat Premium Data Transfer

 Source Server         : local-mysql
 Source Server Type    : MySQL
 Source Server Version : 50713
 Source Host           : localhost:3306
 Source Schema         : kopwms

 Target Server Type    : MySQL
 Target Server Version : 50713
 File Encoding         : 65001

 Date: 26/06/2019 21:34:05
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for sys_dept
-- ----------------------------
DROP TABLE IF EXISTS `sys_dept`;
CREATE TABLE `sys_dept`  (
  `DeptId` bigint(20) NOT NULL,
  `DeptNo` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeptName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IsDel` tinyint(4) NOT NULL COMMENT '1未删除   0删除',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`DeptId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_dict
-- ----------------------------
DROP TABLE IF EXISTS `sys_dict`;
CREATE TABLE `sys_dict`  (
  `DictId` bigint(20) NOT NULL,
  `DictNo` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DictName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DictType` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IsDel` tinyint(4) NOT NULL COMMENT '1未删除   0删除',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`DictId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_log
-- ----------------------------
DROP TABLE IF EXISTS `sys_log`;
CREATE TABLE `sys_log`  (
  `LogId` bigint(20) NOT NULL,
  `LogType` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Description` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Url` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Browser` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  `LogIp` varchar(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`LogId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_menu_wms
-- ----------------------------
DROP TABLE IF EXISTS `sys_menu_wms`;
CREATE TABLE `sys_menu_wms`  (
  `MenuId` bigint(20) NOT NULL,
  `MenuName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `MenuUrl` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `MenuIcon` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `MenuParent` bigint(20) NULL DEFAULT NULL,
  `Sort` int(11) NULL DEFAULT NULL,
  `Status` tinyint(4) NULL DEFAULT NULL COMMENT '启用1 禁用0',
  `MenuType` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'menu btn',
  `IsDel` tinyint(4) NOT NULL COMMENT '1未删除   0删除',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`MenuId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_menu_wms
-- ----------------------------
INSERT INTO `sys_menu_wms` VALUES (1, '系统管理', '#', NULL, -1, 1, 1, 'menu', 1, NULL, NULL, '2018-09-24 12:10:42', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (2, '用户管理', '/User', NULL, 1, 4, 1, 'menu', 1, NULL, NULL, '2018-09-24 12:12:56', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (3, '部门管理', '/Dept', NULL, 1, 3, 1, 'menu', 1, NULL, NULL, '2018-09-24 12:14:38', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (4, '角色管理', '/Role', NULL, 1, 2, 1, 'menu', 1, NULL, NULL, '2018-09-24 12:14:57', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (5, '数据字典', '/Dict', NULL, 1, 5, 1, 'menu', 1, NULL, NULL, '2018-10-21 14:44:30', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (6, '基础资料', '#', NULL, -1, 6, 1, 'menu', 1, NULL, NULL, '2018-09-24 12:19:07', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (7, '物料管理', '/Material', NULL, 6, 7, 1, 'menu', 1, NULL, NULL, '2018-10-09 08:50:37', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (8, '客户管理', '/Customer', NULL, 6, 8, 1, 'menu', 1, NULL, NULL, '2018-10-09 08:50:44', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (9, '供应商管理', '/Supplier', NULL, 6, 9, 1, 'menu', 1, NULL, NULL, '2018-10-21 10:25:53', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (10, '承运商管理', '/Carrier', NULL, 6, 10, 1, 'menu', 1, NULL, NULL, '2018-10-21 10:25:58', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (11, '仓库管理', '#', NULL, -1, 11, 1, 'menu', 1, NULL, NULL, '2018-12-18 23:01:36', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (12, '仓库管理', '/Warehouse', NULL, 11, 12, 1, 'menu', 1, NULL, NULL, '2018-10-09 08:48:09', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (13, '库区管理', '/ReservoirArea', NULL, 11, 13, 1, 'menu', 1, NULL, NULL, '2018-10-09 08:49:11', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (14, '货架管理', '/StorageRack', '&#xe61a;', 11, 14, 1, 'menu', 1, NULL, NULL, '2018-10-09 08:49:14', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (15, '设备管理', '#', '&#xe62e;', -1, 15, 1, 'menu', 1, NULL, NULL, '2018-11-25 22:32:33', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (16, '设备单元', '/Device', NULL, 15, 16, 1, 'menu', 1, NULL, NULL, '2018-11-26 22:28:25', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (17, '生产管理', '#', '&#xe61a;', -1, 17, 1, 'menu', 1, NULL, NULL, '2018-11-30 21:22:54', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (18, '生产工单', '/ProductionOrder', NULL, 17, 18, 1, 'menu', 1, NULL, NULL, '2018-11-30 21:24:22', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (19, '工艺管理', '#', NULL, -1, 19, 1, 'menu', 1, NULL, NULL, '2018-12-06 15:43:58', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (20, 'BOM管理', '/BOM', NULL, 19, 20, 1, 'menu', 1, NULL, NULL, '2018-12-06 15:44:58', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (21, '工艺路线', '/Routing', NULL, 19, 21, 1, 'menu', 1, NULL, NULL, '2018-12-17 23:04:45', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (22, '日志管理', '#', '&#xe62e;', -1, 22, 1, 'menu', 1, NULL, NULL, '2018-10-09 08:50:51', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (23, '系统日志', '/Log', NULL, 22, 23, 1, 'menu', 1, NULL, NULL, '2018-10-09 08:50:54', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (24, '入库管理', '/StockIn', NULL, 11, 24, 1, 'menu', 1, NULL, NULL, '2018-12-19 14:09:08', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (25, '条码系统', '#', NULL, -1, 25, 1, 'menu', 1, NULL, NULL, '2018-12-26 14:26:25', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (26, '报表管理', '#', NULL, -1, 26, 1, 'menu', 1, NULL, NULL, '2018-12-26 14:29:30', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (27, '出库管理', '/StockOut', NULL, 11, 27, 1, 'menu', 1, NULL, NULL, '2019-01-22 11:06:17', NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (28, '设备报修', '/Devicerepair', NULL, 15, 28, 1, 'menu', 1, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (29, '库存查询', '/Inventory', NULL, 11, 29, 1, 'menu', 1, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (30, '库存记录', '/InventoryRecord', NULL, 11, 30, 1, 'menu', 1, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (31, '登录统计', '/Log/Bar', NULL, 22, 31, 1, 'menu', 1, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (32, '发货记录', '/Delivery', NULL, 11, 32, 1, 'menu', 1, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `sys_menu_wms` VALUES (33, '库存移动', '/InventoryMove', NULL, 11, 33, 1, 'menu', 1, NULL, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for sys_role
-- ----------------------------
DROP TABLE IF EXISTS `sys_role`;
CREATE TABLE `sys_role`  (
  `RoleId` bigint(20) NOT NULL,
  `RoleName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `RoleType` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'admin #',
  `IsDel` tinyint(4) NOT NULL COMMENT '1未删除   0删除',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间'
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_role
-- ----------------------------
INSERT INTO `sys_role` VALUES (494712986628259840, '系统管理员', 'admin', 1, '系统管理员', 491786087098744832, '2018-09-27 11:32:43', 504990858139926528, '2019-03-03 20:46:05');

-- ----------------------------
-- Table structure for sys_rolemenu
-- ----------------------------
DROP TABLE IF EXISTS `sys_rolemenu`;
CREATE TABLE `sys_rolemenu`  (
  `RoleMenuId` bigint(20) NOT NULL,
  `RoleId` bigint(20) NULL DEFAULT NULL,
  `MenuId` bigint(20) NULL DEFAULT NULL,
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`RoleMenuId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_rolemenu
-- ----------------------------
INSERT INTO `sys_rolemenu` VALUES (494712986762477568, 494712986628259840, 1, 491786087098744832, '2018-09-27 11:32:47', 491786087098744832, '2018-12-11 22:26:00');
INSERT INTO `sys_rolemenu` VALUES (494712986762477569, 494712986628259840, 2, 491786087098744832, '2018-09-27 11:32:47', 491786087098744832, '2018-12-11 22:26:00');
INSERT INTO `sys_rolemenu` VALUES (494712986762477570, 494712986628259840, 3, 491786087098744832, '2018-09-27 11:32:47', 491786087098744832, '2018-12-11 22:26:00');
INSERT INTO `sys_rolemenu` VALUES (494712986762477571, 494712986628259840, 4, 491786087098744832, '2018-09-27 11:32:47', 491786087098744832, '2018-12-11 22:26:00');
INSERT INTO `sys_rolemenu` VALUES (494712986762477572, 494712986628259840, 5, 491786087098744832, '2018-09-27 11:32:47', 491786087098744832, '2018-12-11 22:26:01');
INSERT INTO `sys_rolemenu` VALUES (499030681041502208, 494712986628259840, 6, 491786087098744832, '2018-10-09 09:29:46', 491786087098744832, '2018-12-11 22:26:01');
INSERT INTO `sys_rolemenu` VALUES (499030681083445248, 494712986628259840, 7, 491786087098744832, '2018-10-09 09:29:46', 491786087098744832, '2018-12-11 22:26:01');
INSERT INTO `sys_rolemenu` VALUES (499030681137971200, 494712986628259840, 8, 491786087098744832, '2018-10-09 09:29:46', 491786087098744832, '2018-12-11 22:26:01');
INSERT INTO `sys_rolemenu` VALUES (499030681158942720, 494712986628259840, 9, 491786087098744832, '2018-10-09 09:29:46', 491786087098744832, '2018-12-11 22:26:01');
INSERT INTO `sys_rolemenu` VALUES (499030681188302848, 494712986628259840, 12, 491786087098744832, '2018-10-09 09:29:46', 491786087098744832, '2018-12-11 22:26:01');
INSERT INTO `sys_rolemenu` VALUES (499030681217662976, 494712986628259840, 10, 491786087098744832, '2018-10-09 09:29:46', 491786087098744832, '2018-12-11 22:26:02');
INSERT INTO `sys_rolemenu` VALUES (499030681247023104, 494712986628259840, 11, 491786087098744832, '2018-10-09 09:29:46', 491786087098744832, '2018-12-11 22:26:02');
INSERT INTO `sys_rolemenu` VALUES (499030681272188928, 494712986628259840, 13, 491786087098744832, '2018-10-09 09:29:46', 491786087098744832, '2018-12-11 22:26:02');
INSERT INTO `sys_rolemenu` VALUES (499030681427378176, 494712986628259840, 14, 491786087098744832, '2018-10-09 09:29:46', 491786087098744832, '2018-12-11 22:26:02');
INSERT INTO `sys_rolemenu` VALUES (503408458121347072, 494712986628259840, 15, 491786087098744832, '2018-10-21 11:25:29', 491786087098744832, '2018-12-11 22:26:02');
INSERT INTO `sys_rolemenu` VALUES (503408458222010368, 494712986628259840, 16, 491786087098744832, '2018-10-21 11:25:29', 491786087098744832, '2018-12-11 22:26:02');
INSERT INTO `sys_rolemenu` VALUES (503408458251370496, 494712986628259840, 17, 491786087098744832, '2018-10-21 11:25:29', 491786087098744832, '2018-12-11 22:26:03');
INSERT INTO `sys_rolemenu` VALUES (503466471221886976, 494712986628259840, 18, 491786087098744832, '2018-10-21 15:16:01', 491786087098744832, '2018-12-11 22:26:03');
INSERT INTO `sys_rolemenu` VALUES (517164210220695552, 494712986628259840, 19, 504990858139926528, '2018-11-28 10:25:56', 491786087098744832, '2018-12-11 22:26:03');
INSERT INTO `sys_rolemenu` VALUES (517164210333941760, 494712986628259840, 20, 504990858139926528, '2018-11-28 10:25:56', 491786087098744832, '2018-12-11 22:26:03');
INSERT INTO `sys_rolemenu` VALUES (522056475653177344, 494712986628259840, 21, 491786087098744832, '2018-12-11 22:26:03', NULL, NULL);
INSERT INTO `sys_rolemenu` VALUES (522056476315877376, 494712986628259840, 22, 491786087098744832, '2018-12-11 22:26:03', NULL, NULL);
INSERT INTO `sys_rolemenu` VALUES (522056476953411584, 494712986628259840, 23, 491786087098744832, '2018-12-11 22:26:03', NULL, NULL);
INSERT INTO `sys_rolemenu` VALUES (522056477603528704, 494712986628259840, 24, 491786087098744832, '2018-12-11 22:26:04', NULL, NULL);
INSERT INTO `sys_rolemenu` VALUES (524603534847508480, 494712986628259840, 26, 504990858139926528, '2018-12-18 23:07:09', NULL, NULL);
INSERT INTO `sys_rolemenu` VALUES (524603762120065024, 494712986628259840, 25, 504990858139926528, '2018-12-18 23:08:04', NULL, NULL);
INSERT INTO `sys_rolemenu` VALUES (537140827936260096, 494712986628259840, 28, 504990858139926528, '2019-01-22 13:25:53', NULL, NULL);
INSERT INTO `sys_rolemenu` VALUES (537141837408763904, 494712986628259840, 29, 504990858139926528, '2019-01-22 13:29:54', NULL, NULL);
INSERT INTO `sys_rolemenu` VALUES (537141837408763905, 494712986628259840, 30, 504990858139926528, '2019-01-22 13:29:54', NULL, NULL);
INSERT INTO `sys_rolemenu` VALUES (537177594374651904, 494712986628259840, 27, 504990858139926528, '2019-01-22 15:51:59', NULL, NULL);
INSERT INTO `sys_rolemenu` VALUES (537507366317326336, 494712986628259840, 31, 504990858139926528, '2019-01-23 13:42:23', NULL, NULL);
INSERT INTO `sys_rolemenu` VALUES (548367997115301888, 494712986628259840, 32, 504990858139926528, '2019-02-22 12:58:39', NULL, NULL);
INSERT INTO `sys_rolemenu` VALUES (551747124224589824, 494712986628259840, 33, 504990858139926528, '2019-03-03 20:46:05', NULL, NULL);

-- ----------------------------
-- Table structure for sys_serialnum
-- ----------------------------
DROP TABLE IF EXISTS `sys_serialnum`;
CREATE TABLE `sys_serialnum`  (
  `SerialNumberId` int(11) NOT NULL,
  `SerialNumber` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `SerialCount` int(11) NULL DEFAULT NULL,
  `TableName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '表名',
  `Prefix` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '前缀',
  `Digit` int(11) NULL DEFAULT NULL COMMENT '位数',
  `Mantissa` int(11) NULL DEFAULT NULL COMMENT '尾数',
  `IsDel` tinyint(4) NOT NULL COMMENT '1未删除   0删除',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`SerialNumberId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_serialnum
-- ----------------------------
INSERT INTO `sys_serialnum` VALUES (1, 'R20190301002520000001', 1, 'Wms_stockin', 'R', 22, 6, 1, '入库单', 1, '2019-01-07 11:16:09', 504990858139926528, '2019-03-01 00:25:20');
INSERT INTO `sys_serialnum` VALUES (2, 'C20190303212032000001', 1, 'Wms_stockout', 'C', 22, 6, 1, '出库单', 1, '2019-02-13 09:24:58', 504990858139926528, '2019-03-03 21:20:32');
INSERT INTO `sys_serialnum` VALUES (3, 'M20190304224033000002', 2, 'Wms_inventorymove', 'M', 22, 6, 1, '库存移动', 1, '2019-03-03 13:16:43', 504990858139926528, '2019-03-04 22:40:34');

-- ----------------------------
-- Table structure for sys_user
-- ----------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user`  (
  `UserId` bigint(20) NOT NULL,
  `UserName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `UserNickname` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Pwd` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Sort` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Tel` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Mobile` varchar(12) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Sex` tinyint(4) NULL DEFAULT NULL COMMENT '0男 1女',
  `DeptId` bigint(20) NULL DEFAULT NULL,
  `LoginIp` varchar(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `LoginDate` datetime(0) NULL DEFAULT NULL,
  `LoginTime` int(11) NULL DEFAULT NULL,
  `IsEabled` tinyint(4) NULL DEFAULT NULL COMMENT '1 启用 0 禁用',
  `IsDel` tinyint(4) NOT NULL COMMENT '1未删除   0删除',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  `RoleId` bigint(20) NULL DEFAULT NULL,
  `HeadImg` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`UserId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_user
-- ----------------------------
INSERT INTO `sys_user` VALUES (491786087098744832, 'admin', 'admin', '202cb962ac59075b964b07152d234b70', NULL, NULL, '15678676789', NULL, 1, 0, '127.0.0.1', '2019-02-27 22:10:00', 1060, 1, 1, '系统管理员', 491786087098744832, '2018-09-19 09:42:20', NULL, NULL, 494712986628259840, NULL);

-- ----------------------------
-- Table structure for wms_carrier
-- ----------------------------
DROP TABLE IF EXISTS `wms_carrier`;
CREATE TABLE `wms_carrier`  (
  `CarrierId` bigint(20) NOT NULL,
  `CarrierNo` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '承运商编号',
  `CarrierName` varchar(60) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '承运商名称',
  `Address` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '承运商地址',
  `Tel` varchar(13) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '联系电话',
  `CarrierPerson` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '联系人',
  `CarrierLevel` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '级别',
  `Email` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'Email',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `IsDel` tinyint(4) NULL DEFAULT NULL COMMENT '1 0',
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`CarrierId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wms_customer
-- ----------------------------
DROP TABLE IF EXISTS `wms_customer`;
CREATE TABLE `wms_customer`  (
  `CustomerId` bigint(20) NOT NULL,
  `CustomerNo` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '客户编号',
  `CustomerName` varchar(60) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '客户名称',
  `Address` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '客户地址',
  `Tel` varchar(13) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '联系电话',
  `CustomerPerson` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '联系人',
  `CustomerLevel` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '级别',
  `Email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'Email',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `IsDel` tinyint(4) NULL DEFAULT NULL COMMENT '1 0',
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`CustomerId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wms_delivery
-- ----------------------------
DROP TABLE IF EXISTS `wms_delivery`;
CREATE TABLE `wms_delivery`  (
  `DeliveryId` bigint(20) NOT NULL COMMENT '发货主键',
  `StockOutId` bigint(20) NULL DEFAULT NULL COMMENT '出库单主表Id',
  `CarrierId` bigint(20) NULL DEFAULT NULL COMMENT '承运商Id',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `IsDel` tinyint(4) NULL DEFAULT NULL COMMENT '1 0',
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  `DeliveryDate` datetime(0) NULL DEFAULT NULL COMMENT '发货日期',
  `TrackingNo` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '快递单号',
  PRIMARY KEY (`DeliveryId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wms_inventory
-- ----------------------------
DROP TABLE IF EXISTS `wms_inventory`;
CREATE TABLE `wms_inventory`  (
  `InventoryId` bigint(20) NOT NULL,
  `MaterialId` bigint(20) NULL DEFAULT NULL,
  `StoragerackId` bigint(20) NULL DEFAULT NULL,
  `Qty` decimal(18, 2) NULL DEFAULT NULL,
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `IsDel` tinyint(4) NOT NULL COMMENT '1 0',
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`InventoryId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wms_inventorymove
-- ----------------------------
DROP TABLE IF EXISTS `wms_inventorymove`;
CREATE TABLE `wms_inventorymove`  (
  `InventorymoveId` bigint(20) NOT NULL COMMENT '库存移动主键',
  `InventorymoveNo` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '库存移动编号',
  `SourceStoragerackId` bigint(20) NULL DEFAULT NULL COMMENT '原货架Id',
  `AimStoragerackId` bigint(20) NULL DEFAULT NULL COMMENT '目标货架',
  `Status` tinyint(4) NULL DEFAULT NULL COMMENT '状态',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `IsDel` tinyint(4) NULL DEFAULT NULL COMMENT '1 0',
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`InventorymoveId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wms_inventoryrecord
-- ----------------------------
DROP TABLE IF EXISTS `wms_inventoryrecord`;
CREATE TABLE `wms_inventoryrecord`  (
  `InventoryrecordId` bigint(20) NOT NULL,
  `StockInDetailId` bigint(20) NULL DEFAULT NULL,
  `Qty` decimal(18, 2) NULL DEFAULT NULL,
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `IsDel` tinyint(4) NOT NULL COMMENT '1 0',
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`InventoryrecordId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wms_invmovedetail
-- ----------------------------
DROP TABLE IF EXISTS `wms_invmovedetail`;
CREATE TABLE `wms_invmovedetail`  (
  `MoveDetailId` bigint(20) NOT NULL COMMENT '主键',
  `InventorymoveId` bigint(20) NULL DEFAULT NULL COMMENT '库存移动Id',
  `Status` tinyint(4) NULL DEFAULT NULL,
  `MaterialId` bigint(20) NULL DEFAULT NULL COMMENT '物料',
  `PlanQty` decimal(18, 0) NULL DEFAULT NULL COMMENT '计划数量',
  `ActQty` decimal(18, 0) NULL DEFAULT NULL COMMENT '实际数量',
  `AuditinId` bigint(20) NULL DEFAULT NULL COMMENT '审核人',
  `AuditinTime` datetime(0) NULL DEFAULT NULL COMMENT '审核时间',
  `IsDel` tinyint(4) NULL DEFAULT NULL COMMENT '1 0',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`MoveDetailId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wms_material
-- ----------------------------
DROP TABLE IF EXISTS `wms_material`;
CREATE TABLE `wms_material`  (
  `MaterialId` bigint(20) NOT NULL,
  `MaterialNo` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '产品编号',
  `MaterialName` varchar(60) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '产品名称',
  `MaterialType` bigint(20) NULL DEFAULT NULL COMMENT '产品类型',
  `Unit` bigint(20) NULL DEFAULT NULL COMMENT '单位',
  `StoragerackId` bigint(20) NULL DEFAULT NULL COMMENT '默认所属货架',
  `ReservoirAreaId` bigint(20) NULL DEFAULT NULL COMMENT '默认所属库区',
  `WarehouseId` bigint(20) NULL DEFAULT NULL COMMENT '默认所属仓库',
  `Qty` decimal(18, 0) NULL DEFAULT NULL COMMENT '安全库存',
  `ExpiryDate` decimal(18, 0) NULL DEFAULT NULL COMMENT '有效期',
  `IsDel` tinyint(4) NULL DEFAULT NULL COMMENT '1 0',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`MaterialId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wms_reservoirarea
-- ----------------------------
DROP TABLE IF EXISTS `wms_reservoirarea`;
CREATE TABLE `wms_reservoirarea`  (
  `ReservoirAreaId` bigint(20) NOT NULL COMMENT '主键',
  `ReservoirAreaNo` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '库区编号',
  `ReservoirAreaName` varchar(60) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '库区名称',
  `WarehouseId` bigint(20) NOT NULL COMMENT '所属仓库ID',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `IsDel` tinyint(4) NULL DEFAULT NULL COMMENT '1 0',
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`ReservoirAreaId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wms_stockin
-- ----------------------------
DROP TABLE IF EXISTS `wms_stockin`;
CREATE TABLE `wms_stockin`  (
  `StockInId` bigint(20) NOT NULL COMMENT '主键',
  `StockInNo` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '入库单号',
  `StockInType` bigint(20) NULL DEFAULT NULL COMMENT '入库类型',
  `SupplierId` bigint(20) NULL DEFAULT NULL COMMENT '供应商',
  `OrderNo` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '订单号',
  `StockInStatus` tinyint(4) NULL DEFAULT NULL,
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `IsDel` tinyint(4) NULL DEFAULT NULL COMMENT '1 0',
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`StockInId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wms_stockindetail
-- ----------------------------
DROP TABLE IF EXISTS `wms_stockindetail`;
CREATE TABLE `wms_stockindetail`  (
  `StockInDetailId` bigint(20) NOT NULL COMMENT '主键',
  `StockInId` bigint(20) NULL DEFAULT NULL COMMENT '入库单号',
  `Status` tinyint(4) NULL DEFAULT NULL,
  `MaterialId` bigint(20) NULL DEFAULT NULL COMMENT '物料',
  `PlanInQty` decimal(18, 0) NULL DEFAULT NULL COMMENT '计划数量',
  `ActInQty` decimal(18, 0) NULL DEFAULT NULL COMMENT '实际数量',
  `StoragerackId` bigint(20) NULL DEFAULT NULL COMMENT '货架',
  `AuditinId` bigint(20) NULL DEFAULT NULL COMMENT '审核人',
  `AuditinTime` datetime(0) NULL DEFAULT NULL COMMENT '审核时间',
  `IsDel` tinyint(4) NULL DEFAULT NULL COMMENT '1 0',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`StockInDetailId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wms_stockout
-- ----------------------------
DROP TABLE IF EXISTS `wms_stockout`;
CREATE TABLE `wms_stockout`  (
  `StockOutId` bigint(20) NOT NULL,
  `StockOutNo` varchar(22) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '出库单，系统自动生成',
  `OrderNo` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '出库订单',
  `StockOutType` bigint(20) NULL DEFAULT NULL COMMENT '出库类型',
  `CustomerId` bigint(20) NULL DEFAULT NULL COMMENT '客户',
  `StockOutStatus` tinyint(4) NULL DEFAULT NULL,
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `IsDel` tinyint(4) NULL DEFAULT NULL COMMENT '1 0',
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`StockOutId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wms_stockoutdetail
-- ----------------------------
DROP TABLE IF EXISTS `wms_stockoutdetail`;
CREATE TABLE `wms_stockoutdetail`  (
  `StockOutDetailId` bigint(20) NOT NULL COMMENT '主键',
  `StockOutId` bigint(20) NULL DEFAULT NULL COMMENT '出库单',
  `Status` tinyint(4) NULL DEFAULT NULL,
  `MaterialId` bigint(20) NULL DEFAULT NULL COMMENT '物料',
  `PlanOutQty` decimal(18, 0) NULL DEFAULT NULL COMMENT '计划数量',
  `ActOutQty` decimal(18, 0) NULL DEFAULT NULL COMMENT '实际数量',
  `StoragerackId` bigint(20) NULL DEFAULT NULL COMMENT '货架',
  `AuditinId` bigint(20) NULL DEFAULT NULL COMMENT '审核人',
  `AuditinTime` datetime(0) NULL DEFAULT NULL COMMENT '审核时间',
  `IsDel` tinyint(4) NULL DEFAULT NULL COMMENT '1 0',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`StockOutDetailId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wms_storagerack
-- ----------------------------
DROP TABLE IF EXISTS `wms_storagerack`;
CREATE TABLE `wms_storagerack`  (
  `StorageRackId` bigint(20) NOT NULL COMMENT '货架Id',
  `StorageRackNo` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '货架编号',
  `StorageRackName` varchar(60) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '货架名称',
  `ReservoirAreaId` bigint(20) NOT NULL COMMENT '所属库区',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `IsDel` tinyint(4) NULL DEFAULT NULL COMMENT '1 0',
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  `WarehouseId` bigint(20) NULL DEFAULT NULL,
  PRIMARY KEY (`StorageRackId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wms_supplier
-- ----------------------------
DROP TABLE IF EXISTS `wms_supplier`;
CREATE TABLE `wms_supplier`  (
  `SupplierId` bigint(20) NOT NULL,
  `SupplierNo` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '供应商编号',
  `SupplierName` varchar(60) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '供应商名称',
  `Address` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '供应商地址',
  `Tel` varchar(13) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '联系电话',
  `SupplierPerson` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '联系人',
  `SupplierLevel` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '级别',
  `Email` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'Email',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `IsDel` tinyint(4) NULL DEFAULT NULL COMMENT '1 0',
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`SupplierId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for wms_warehouse
-- ----------------------------
DROP TABLE IF EXISTS `wms_warehouse`;
CREATE TABLE `wms_warehouse`  (
  `WarehouseId` bigint(20) NOT NULL,
  `WarehouseNo` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '仓库编号',
  `WarehouseName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '仓库名称',
  `IsDel` tinyint(4) NULL DEFAULT NULL COMMENT '是否删除 1未删除  0删除',
  `Remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `CreateBy` bigint(20) NULL DEFAULT NULL COMMENT '创建人',
  `CreateDate` datetime(0) NULL DEFAULT NULL COMMENT '创建时间',
  `ModifiedBy` bigint(20) NULL DEFAULT NULL COMMENT '修改人',
  `ModifiedDate` datetime(0) NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`WarehouseId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
