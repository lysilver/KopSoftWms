
USE master
go
if exists (select * from sysdatabases where name='KopSoftWms')
drop database KopSoftWms
go
create database KopSoftWms
on primary
(
	name='KopSoftWms_data',
	filename='D:\KopSoft\KopSoftWms\DB\KopSoftWms_data.mdf',
	size=10MB,
	maxsize=unlimited,
	filegrowth=20%
)
log on 
(
	name='KopSoftWms_log',
	filename='D:\KopSoft\KopSoftWms\DB\KopSoftWms_log.ldf',
	size=10MB,
	maxsize=unlimited,
	filegrowth=20%
)
go

