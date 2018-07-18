﻿-- CREATE DATABASE MANAGERSTUFF
CREATE DATABASE MANAGERSTUFF
GO

-- USE DATABASE MANAGERSTUFF
USE MANAGERSTUFF
GO

-- CREATE AND DECLARE VARIABLE DEFINE
EXEC sys.sp_addtype @typename = 'IDGLOBAL', -- sysname
    @phystype = 'INT', -- sysname
    @nulltype = 'NOT NULL', -- varchar(8)
    @owner = NULL -- sysname
GO

EXEC sys.sp_addtype @typename = 'STATUSGLOBAL', -- sysname
    @phystype = 'BIT', -- sysname
    @nulltype = 'NOT NULL', -- varchar(8)
    @owner = NULL -- sysname
GO

EXEC sys.sp_addtype @typename = 'CREATEDDATEGLOBAL', -- sysname
    @phystype = 'DATETIME', -- sysname
    @nulltype = 'NOT NULL', -- varchar(8)
    @owner = NULL -- sysname
GO

EXEC sys.sp_addtype @typename = 'CREATEDBYGLOBAL', -- sysname
    @phystype = 'VARCHAR(50)', -- sysname
    @nulltype = 'NOT NULL', -- varchar(8)
    @owner = NULL -- sysname
GO

EXEC sys.sp_addtype @typename = 'MODIFIEDDATEGLOBAL', -- sysname
    @phystype = 'DATETIME', -- sysname
    @nulltype = 'NULL', -- varchar(8)
    @owner = NULL -- sysname
GO

EXEC sys.sp_addtype @typename = 'MODIFIEDBYGLOBAL', -- sysname
    @phystype = 'VARCHAR(50)', -- sysname
    @nulltype = 'NULL', -- varchar(8)
    @owner = NULL -- sysname
GO

-- CREATE TABLE ROLES
CREATE TABLE ROLES
(
	ID IDGLOBAL IDENTITY(1, 1),
	NAME VARCHAR(50) NOT NULL UNIQUE,
	CONSTRAINT PK_ROLES_ID
	PRIMARY KEY (ID)
)
GO

-- CREATE TABLE USERS
CREATE TABLE USERS
(
	ID IDGLOBAL IDENTITY(1, 1),
	USERNAME VARCHAR(50) NOT NULL UNIQUE,
	PASSWORD VARCHAR(32) NOT NULL,
	NAME NVARCHAR(100) NOT NULL,
	SEX BIT DEFAULT 1 NOT NULL,
	BIRTHOFDATE DATETIME NULL CHECK (BIRTHOFDATE < GETDATE()),
	EMAIL VARCHAR(100) NOT NULL,
	PHONENUMBER VARCHAR(15) NOT NULL,
	STATUS STATUSGLOBAL DEFAULT 1,
	CREATEDDATE CREATEDDATEGLOBAL DEFAULT GETDATE() CHECK (CREATEDDATE BETWEEN '01-01-1900' AND GETDATE()),
	CREATEBY CREATEDBYGLOBAL,
	MODIFIEDDATE MODIFIEDDATEGLOBAL CHECK (MODIFIEDDATE BETWEEN '01-01-1900' AND GETDATE()),
	MODIFIEDBY MODIFIEDBYGLOBAL,
	IDROLES IDGLOBAL,
	CONSTRAINT PK_USERS_ID
	PRIMARY KEY (ID),
	CONSTRAINT FK_USERS_IDROLES
	FOREIGN KEY (IDROLES)
	REFERENCES dbo.ROLES (ID)
)
GO

-- CREATE TABLE CATEGORIES
CREATE TABLE CATEGORIES
(
	ID IDGLOBAL IDENTITY(1, 1),
	NAME NVARCHAR(100) NOT NULL UNIQUE,
	STATUS STATUSGLOBAL DEFAULT 1,
	CREATEDDATE CREATEDDATEGLOBAL DEFAULT GETDATE() CHECK (CREATEDDATE BETWEEN '01-01-1900' AND GETDATE()),
	CREATEBY CREATEDBYGLOBAL,
	MODIFIEDDATE MODIFIEDDATEGLOBAL CHECK (MODIFIEDDATE BETWEEN '01-01-1900' AND GETDATE()),
	MODIFIEDBY MODIFIEDBYGLOBAL,
	CONSTRAINT PK_CATEGORIES_ID
	PRIMARY KEY (ID)
)
GO

-- CREATE TALBE STUFFS
CREATE TABLE STUFFS
(
	ID IDGLOBAL IDENTITY(1, 1),
	BQCODE VARCHAR(100) NULL UNIQUE,
	NAME NVARCHAR(500) NOT NULL,
	PRODUCER NVARCHAR(100) NOT NULL,
	DATEBUY DATETIME NOT NULL CHECK (DATEBUY BETWEEN '01-01-1900' AND GETDATE()),
	DATEUSE DATETIME DEFAULT GETDATE() NOT NULL CHECK (DATEUSE BETWEEN '01-01-1900' AND GETDATE()),
	YEARRELEASE DATETIME NOT NULL CHECK (YEARRELEASE BETWEEN '01-01-1900' AND GETDATE()),
	COLORSTUFFS NVARCHAR(20) NULL,
	STATE NVARCHAR(20) NULL,
	PRICEBUY DECIMAL(18, 2) NOT NULL,
	WARRANTY NVARCHAR(50) NOT NULL,
	STATUS STATUSGLOBAL DEFAULT 1,
	CREATEDDATE CREATEDDATEGLOBAL DEFAULT GETDATE() CHECK (CREATEDDATE BETWEEN '01-01-1900' AND GETDATE()),
	CREATEBY CREATEDBYGLOBAL,
	MODIFIEDDATE MODIFIEDDATEGLOBAL CHECK (MODIFIEDDATE BETWEEN '01-01-1900' AND GETDATE()),
	MODIFIEDBY MODIFIEDBYGLOBAL,
	IDCATEGORIES IDGLOBAL,
	CONSTRAINT PK_STUFFS_ID
	PRIMARY KEY (ID),
	CONSTRAINT FK_STUFFS_IDCATEGORIES
	FOREIGN KEY (IDCATEGORIES) 
	REFERENCES dbo.CATEGORIES (ID)
)
GO

---- TRIGGER TABLE STUFFS ( INSERT, UPDATE STUFFS )
--CREATE TRIGGER TG_INSERT_UPDATE_STUFFS_PARENTID
--ON dbo.STUFFS
--FOR INSERT, UPDATE
--AS
--BEGIN
--	DECLARE @COUNT INT = 0
--	SELECT @COUNT = COUNT(*) FROM Inserted WHERE Inserted.PARENTID > 0 AND Inserted.PARENTID IS NOT NULL AND Inserted.PARENTID NOT IN (SELECT ID FROM dbo.STUFFS)
--	IF(@COUNT > 0)
--	BEGIN
--		PRINT N'PARENTID Trong Dòng Vừa Mới Thêm Không Tồn Tại Trong Bảng STUFFS'
--		ROLLBACK TRAN
--	END
--END
--GO

-- CREATE TABLE PLACESTUFFS
CREATE TABLE PLACESTUFFS
(
	ID IDGLOBAL IDENTITY(1, 1),
	NAME NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_PLACESTUFFS_ID
	PRIMARY KEY (ID)
)
GO

-- CREATE TABLE STUFFSPLACESTUFFS
CREATE TABLE STUFFSPLACESTUFFS
(
	IDSTUFFS IDGLOBAL,
	IDPLACESTUFFS IDGLOBAL,
	CONSTRAINT PK_STUFFSPLACESTUFFS_IDSTUFFS_IDPLACESTUFFS
	PRIMARY KEY (IDSTUFFS, IDPLACESTUFFS),
	CONSTRAINT FK_STUFFSPLACESTUFFS_IDSTUFFS
	FOREIGN KEY (IDSTUFFS)
	REFERENCES dbo.STUFFS (ID),
	CONSTRAINT FK_STUFFSPLACESTUFFS_IDPLACESTUFFS
	FOREIGN KEY (IDPLACESTUFFS)
	REFERENCES dbo.PLACESTUFFS (ID)
)
GO

-- TURN OFF IDENTITY ROLES
-- SET IDENTITY_INSERT dbo.ROLES OFF
-- GO

-- INSERT TABLE ROLES
INSERT dbo.ROLES (NAME) VALUES ('Admin'  -- NAME - varchar(50)
)
GO 

INSERT dbo.ROLES (NAME) VALUES ('User'  -- NAME - varchar(50)
)
GO 

-- SET DATEFORMAT
-- SET DATEFORMAT DMY
-- GO

-- INSERT TABLE USERS
INSERT dbo.USERS (
USERNAME,
PASSWORD,
NAME,
SEX,
BIRTHOFDATE,
EMAIL,
PHONENUMBER,
STATUS,
CREATEDDATE,
CREATEBY,
MODIFIEDDATE,
MODIFIEDBY,
IDROLES) VALUES (
'admin' , -- USERNAME - varchar(50)
'admin' , -- PASSWORD - varchar(32)
N'Admin' , -- NAME - nvarchar(100)
1 , -- SEX - bit
'01-01-1995' , -- BIRTHOFDATE - datetime
'admin@gmail.com' , -- EMAIL - varchar(100)
'123456789' , -- PHONENUMBER - varchar(15)
1, -- STATUS - 
GETDATE(), -- CREATEDDATE - 
'admin', -- CREATEBY - 
NULL, -- MODIFIEDDATE - 
NULL, -- MODIFIEDBY - 
1 -- IDROLES - 
)
GO

INSERT dbo.USERS (
USERNAME,
PASSWORD,
NAME,
SEX,
BIRTHOFDATE,
EMAIL,
PHONENUMBER,
STATUS,
CREATEDDATE,
CREATEBY,
MODIFIEDDATE,
MODIFIEDBY,
IDROLES) VALUES (
'user' , -- USERNAME - varchar(50)
'user' , -- PASSWORD - varchar(32)
N'User' , -- NAME - nvarchar(100)
1 , -- SEX - bit
'01-01-1995' , -- BIRTHOFDATE - datetime
'user@gmail.com' , -- EMAIL - varchar(100)
'123456789' , -- PHONENUMBER - varchar(15)
1, -- STATUS - 
GETDATE(), -- CREATEDDATE - 
'admin', -- CREATEBY - 
NULL, -- MODIFIEDDATE - 
NULL, -- MODIFIEDBY - 
2 -- IDROLES - 
)
GO

-- INSERT TABLE CATEGORIES
INSERT dbo.CATEGORIES (
NAME,
STATUS,
CREATEDDATE,
CREATEBY,
MODIFIEDDATE,
MODIFIEDBY) VALUES ( 
N'Vật Tư Chuyên Dụng' , -- NAME - nvarchar(100)
1, -- STATUS - 
GETDATE(), -- CREATEDDATE - 
'admin', -- CREATEBY - 
NULL, -- MODIFIEDDATE - 
NULL -- MODIFIEDBY - 
)
GO

INSERT dbo.CATEGORIES (
NAME,
STATUS,
CREATEDDATE,
CREATEBY,
MODIFIEDDATE,
MODIFIEDBY) VALUES ( 
N'Vật Tư Thường Dùng' , -- NAME - nvarchar(100)
1, -- STATUS - 
GETDATE(), -- CREATEDDATE - 
'admin', -- CREATEBY - 
NULL, -- MODIFIEDDATE - 
NULL -- MODIFIEDBY - 
)
GO

SET DATEFORMAT DMY
GO

-- INSERT TABLE STUFFS
INSERT dbo.STUFFS (
BQCODE,
NAME,
PRODUCER,
DATEBUY,
DATEUSE,
YEARRELEASE,
COLORSTUFFS,
STATE,
PRICEBUY,
WARRANTY,
STATUS,
CREATEDDATE,
CREATEBY,
MODIFIEDDATE,
MODIFIEDBY,
IDCATEGORIES) VALUES (
'vtcd758245' , -- BQCODE - varchar(100)
N'MacBook Pro 13in Touch Bar MPXY2 Silver- Model 2017' , -- NAME - nvarchar(100)
N'Apple' , -- PRODUCER - nvarchar(100)
'29-04-2018' , -- DATEBUY - datetime
GETDATE() , -- DATEUSE - datetime
'04-02-2018' , -- YEARRELEASE - datetime
N'Trắng' , -- COLORSTUFFS - nvarchar(20)
N'Mới' , -- STATE - nvarchar(20)
43590000 , -- PRICEBUY - decimal
N'2 Năm Rưỡi' , -- WARRANTY - nvarchar(50)
1, -- STATUS - 
GETDATE(), -- CREATEDDATE - 
'admin', -- CREATEBY - 
NULL, -- MODIFIEDDATE - 
NULL, -- MODIFIEDBY - 
1 -- IDCATEGORIES - 
)
GO

INSERT dbo.STUFFS (
BQCODE,
NAME,
PRODUCER,
DATEBUY,
DATEUSE,
YEARRELEASE,
COLORSTUFFS,
STATE,
PRICEBUY,
WARRANTY,
STATUS,
CREATEDDATE,
CREATEBY,
MODIFIEDDATE,
MODIFIEDBY,
IDCATEGORIES) VALUES (
'vtcd888995' , -- BQCODE - varchar(100)
N'Laptop DELL Inspiron 7577 – N7577A Core i7-7700HQ / Win10 (15.6 inch) + Office365' , -- NAME - nvarchar(100)
N'Dell' , -- PRODUCER - nvarchar(100)
'29-04-2018' , -- DATEBUY - datetime
GETDATE() , -- DATEUSE - datetime
'04-03-2018' , -- YEARRELEASE - datetime
N'Đen' , -- COLORSTUFFS - nvarchar(20)
N'Mới' , -- STATE - nvarchar(20)
27490000 , -- PRICEBUY - decimal
N'2 Năm' , -- WARRANTY - nvarchar(50)
1, -- STATUS - 
GETDATE(), -- CREATEDDATE - 
'admin', -- CREATEBY - 
NULL, -- MODIFIEDDATE - 
NULL, -- MODIFIEDBY - 
1 -- IDCATEGORIES - 
)
GO

-- INSERT TABLE STUFFS
INSERT dbo.STUFFS (
BQCODE,
NAME,
PRODUCER,
DATEBUY,
DATEUSE,
YEARRELEASE,
COLORSTUFFS,
STATE,
PRICEBUY,
WARRANTY,
STATUS,
CREATEDDATE,
CREATEBY,
MODIFIEDDATE,
MODIFIEDBY,
IDCATEGORIES) VALUES (
'vttd99786' , -- BQCODE - varchar(100)
N'Máy In Phun Canon Pixma G1000' , -- NAME - nvarchar(100)
N'Canon' , -- PRODUCER - nvarchar(100)
'29-04-2018' , -- DATEBUY - datetime
GETDATE() , -- DATEUSE - datetime
'04-04-2018' , -- YEARRELEASE - datetime
N'Đen' , -- COLORSTUFFS - nvarchar(20)
N'Mới' , -- STATE - nvarchar(20)
2550000 , -- PRICEBUY - decimal
N'1 Năm' , -- WARRANTY - nvarchar(50)
1, -- STATUS - 
GETDATE(), -- CREATEDDATE - 
'admin', -- CREATEBY - 
NULL, -- MODIFIEDDATE - 
NULL, -- MODIFIEDBY - 
2 -- IDCATEGORIES - 
)
GO

-- INSERT TABLE STUFFS
INSERT dbo.STUFFS (
BQCODE,
NAME,
PRODUCER,
DATEBUY,
DATEUSE,
YEARRELEASE,
COLORSTUFFS,
STATE,
PRICEBUY,
WARRANTY,
STATUS,
CREATEDDATE,
CREATEBY,
MODIFIEDDATE,
MODIFIEDBY,
IDCATEGORIES) VALUES (
'vttd458764' , -- BQCODE - varchar(100)
N'Máy Scan Canon Lide 220' , -- NAME - nvarchar(100)
N'Canon' , -- PRODUCER - nvarchar(100)
'29-04-2018' , -- DATEBUY - datetime
GETDATE() , -- DATEUSE - datetime
'04-01-2018' , -- YEARRELEASE - datetime
N'Đen' , -- COLORSTUFFS - nvarchar(20)
N'Mới' , -- STATE - nvarchar(20)
2149000 , -- PRICEBUY - decimal
N'1 Năm' , -- WARRANTY - nvarchar(50)
1, -- STATUS - 
GETDATE(), -- CREATEDDATE - 
'admin', -- CREATEBY - 
NULL, -- MODIFIEDDATE - 
NULL, -- MODIFIEDBY - 
2 -- IDCATEGORIES - 
)
GO

-- INSERT TABLE PLACESTUFFS
INSERT dbo.PLACESTUFFS
        ( NAME )
VALUES  ( N'Phòng Kế Toán'  -- NAME - nvarchar(100)
          )
GO

INSERT dbo.PLACESTUFFS
        ( NAME )
VALUES  ( N'Phòng Kỹ Thuật'  -- NAME - nvarchar(100)
          )
GO

-- INSERT TABLE STUFFSPLACESTUFFS
INSERT dbo.STUFFSPLACESTUFFS
        ( IDSTUFFS, IDPLACESTUFFS )
VALUES  ( 2, -- IDSTUFFS - IDGLOBAL
          2  -- IDPLACESTUFFS - IDGLOBAL
          )
GO

INSERT dbo.STUFFSPLACESTUFFS
        ( IDSTUFFS, IDPLACESTUFFS )
VALUES  ( 3, -- IDSTUFFS - IDGLOBAL
          2 -- IDPLACESTUFFS - IDGLOBAL
          )
GO

INSERT dbo.STUFFSPLACESTUFFS
        ( IDSTUFFS, IDPLACESTUFFS )
VALUES  ( 4, -- IDSTUFFS - IDGLOBAL
          1 -- IDPLACESTUFFS - IDGLOBAL
          )
GO

INSERT dbo.STUFFSPLACESTUFFS
        ( IDSTUFFS, IDPLACESTUFFS )
VALUES  ( 1, -- IDSTUFFS - IDGLOBAL
          1 -- IDPLACESTUFFS - IDGLOBAL
          )
GO

-- CREATE STORE GETLASTID 1
CREATE PROC SP_GETLASTID
@TABLE VARCHAR(20)
AS
BEGIN
	DECLARE @QUERYGETCOUNT NVARCHAR(50) = N'SELECT COUNT(*) FROM ' + @TABLE
	DECLARE @COUNT INT
	-- EXEC sp_executesql @QUERYGETCOUNT, N'@COUNT INT OUTPUT', @COUNT OUTPUT
	DECLARE @TABLECOUNT TABLE (
		COUNT INT NOT NULL
	)
	INSERT INTO @TABLECOUNT(COUNT) EXEC (@QUERYGETCOUNT)
	SELECT @COUNT = (SELECT TOP 1 COUNT FROM @TABLECOUNT)
	DECLARE @ID INT
	DECLARE @QUERYGETLASTID NVARCHAR(100)
	IF(@COUNT > 1) 
	BEGIN
		SELECT @QUERYGETLASTID = N'SELECT ID FROM ' + @TABLE + ' WHERE ID NOT IN (SELECT TOP ' + CAST((@COUNT - 1) AS VARCHAR) + ' ID FROM ' + @TABLE + ')'
		EXEC sp_executesql @QUERYGETLASTID, N'@ID INT OUTPUT', @ID OUTPUT
	END
	ELSE
	BEGIN
		SELECT @QUERYGETLASTID = N'SELECT ID FROM ' + @TABLE + ' WHERE ID NOT IN (SELECT TOP ' + CAST(1 AS VARCHAR) + ' ID FROM ' + @TABLE + ')'
		EXEC sp_executesql @QUERYGETLASTID, N'@ID INT OUTPUT', @ID OUTPUT
	END
END
GO

EXEC dbo.SP_GETLASTID @TABLE = 'STUFFS'
GO

-- CREATE STORE GETLASTID 2
DECLARE @MYVAR NVARCHAR(100)
DECLARE MYTESTCURSOR CURSOR
DYNAMIC 
FOR
SELECT ID FROM dbo.STUFFS
OPEN MYTESTCURSOR
FETCH LAST FROM MYTESTCURSOR INTO @MYVAR
CLOSE MYTESTCURSOR
DEALLOCATE MYTESTCURSOR
SELECT @MYVAR
GO

-- SELECT
SELECT * FROM dbo.ROLES
GO

SELECT * FROM dbo.USERS
GO

SELECT * FROM dbo.CATEGORIES
GO

SELECT * FROM dbo.STUFFS
GO

SELECT * FROM dbo.PLACESTUFFS
GO

SELECT * FROM dbo.STUFFSPLACESTUFFS
GO

SELECT C.ID, C.NAME, C.STATUS, C.CREATEDDATE, C.CREATEBY, C.MODIFIEDDATE, C.MODIFIEDBY, COUNT(*) AS COUNTSTUFFS
FROM dbo.CATEGORIES AS C 
JOIN dbo.STUFFS AS T 
ON T.IDCATEGORIES = C.ID 
GROUP BY C.ID, C.NAME, C.STATUS, C.CREATEDDATE, C.CREATEBY, C.MODIFIEDDATE, C.MODIFIEDBY, T.IDCATEGORIES 
HAVING C.STATUS = 1
GO

SELECT TOP 5 S.ID, S.NAME, S.BQCODE, S.PRODUCER, S.DATEBUY, S.DATEUSE, S.YEARRELEASE, S.COLORSTUFFS, S.STATE, S.PRICEBUY, S.WARRANTY, S.STATUS, S.CREATEDDATE, S.CREATEBY, S.MODIFIEDDATE, S.MODIFIEDBY, C.NAME AS CATEGORY, (SELECT P.NAME FROM dbo.STUFFSPLACESTUFFS AS SP, dbo.PLACESTUFFS AS P WHERE SP.IDSTUFFS = S.ID AND P.ID = SP.IDPLACESTUFFS) AS 'PLACESTUFF'
FROM dbo.STUFFS AS S 
JOIN dbo.CATEGORIES AS C 
ON C.ID = S.IDCATEGORIES
WHERE S.ID NOT IN (SELECT TOP 0 ID FROM dbo.STUFFS)
GO

SELECT S.COLUMN_NAME, S.IS_NULLABLE, S.DATA_TYPE, S.CHARACTER_MAXIMUM_LENGTH, (SELECT C.CONSTRAINT_TYPE FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS C 
INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS U 
ON C.TABLE_NAME = U.TABLE_NAME 
WHERE C.TABLE_NAME = 'ROLES' 
AND U.TABLE_NAME = 'ROLES' 
AND U.TABLE_NAME = S.TABLE_NAME 
AND C.TABLE_NAME = S.TABLE_NAME
AND U.COLUMN_NAME = S.COLUMN_NAME)
AS CONSTRAINT_TYPE 
FROM INFORMATION_SCHEMA.COLUMNS AS S
WHERE S.TABLE_NAME = 'ROLES'
GO

SELECT C.ID, C.NAME, C.STATUS, C.CREATEDDATE, C.CREATEBY, C.MODIFIEDDATE, C.MODIFIEDBY, (SELECT COUNT(*) FROM dbo.STUFFS AS S 
WHERE S.IDCATEGORIES = C.ID) AS COUNTSTUFFS 
FROM dbo.CATEGORIES AS C
GO

SELECT PS.ID, PS.NAME, (SELECT COUNT(*) FROM dbo.STUFFSPLACESTUFFS AS S 
WHERE S.IDPLACESTUFFS = PS.ID) AS COUNTSTUFFS 
FROM dbo.PLACESTUFFS AS PS
GO

SELECT S.ID, S.NAME, S.BQCODE, S.PRODUCER, S.DATEBUY, S.DATEUSE, S.YEARRELEASE, S.COLORSTUFFS, S.STATE, S.PRICEBUY, S.WARRANTY 
FROM dbo.STUFFS AS S 
LEFT JOIN dbo.STUFFSPLACESTUFFS AS SP
ON SP.IDSTUFFS = S.ID
WHERE S.ID NOT IN (SELECT IDSTUFFS FROM dbo.STUFFSPLACESTUFFS)
GO

SELECT U.USERNAME, U.NAME, U.STATUS, (SELECT R.NAME FROM dbo.ROLES AS R WHERE R.ID = U.IDROLES) AS 'ROLE' FROM USERS AS U WHERE U.USERNAME = 'admin' AND U.PASSWORD = 'admin'
GO

SELECT COUNT(*) FROM dbo.USERS AS U JOIN dbo.ROLES AS R ON R.ID = U.IDROLES WHERE R.NAME = 'User'
GO

SELECT U.ID, U.USERNAME, U.NAME, U.SEX, U.BIRTHOFDATE, U.EMAIL, U.PHONENUMBER, U.STATUS, R.NAME AS 'ROLENAME' FROM dbo.USERS AS U JOIN dbo.ROLES AS R ON R.ID = U.IDROLES WHERE R.NAME = 'User'
GO

SELECT S.BQCODE, S.NAME, S.PRODUCER, S.DATEBUY, S.DATEUSE, S.YEARRELEASE, S.COLORSTUFFS, S.STATE, S.PRICEBUY, S.WARRANTY, S.CREATEDDATE, S.CREATEBY, S.MODIFIEDDATE, S.MODIFIEDBY, C.NAME AS 'CATEGORY', P.NAME AS 'PLACESTUFF'
FROM dbo.STUFFS AS S 
JOIN dbo.CATEGORIES AS C
ON C.ID = S.IDCATEGORIES
JOIN dbo.STUFFSPLACESTUFFS AS SP
ON SP.IDSTUFFS = S.ID
JOIN dbo.PLACESTUFFS AS P
ON P.ID = SP.IDPLACESTUFFS
WHERE S.NAME LIKE N'%Máy%'
AND C.NAME = N'Vật Tư Thường Dùng'
ORDER BY S.NAME DESC
GO

SELECT P.NAME
FROM dbo.STUFFS AS S 
JOIN dbo.CATEGORIES AS C
ON C.ID = S.IDCATEGORIES
JOIN dbo.STUFFSPLACESTUFFS AS SP
ON SP.IDSTUFFS = S.ID
JOIN dbo.PLACESTUFFS AS P
ON P.ID = SP.IDPLACESTUFFS
WHERE S.COLORSTUFFS IS NOT NULL 
GROUP BY P.NAME
GO

SELECT U.USERNAME, U.NAME, U.SEX, U.BIRTHOFDATE, U.EMAIL, U.PHONENUMBER, U.STATUS, U.CREATEDDATE, U.CREATEBY, U.MODIFIEDDATE, U.MODIFIEDBY, R.NAME AS 'ROLENAME' 
FROM dbo.USERS AS U 
JOIN dbo.ROLES AS R 
ON R.ID = U.IDROLES 

SELECT U.USERNAME
FROM dbo.USERS AS U 
JOIN dbo.ROLES AS R 
ON R.ID = U.IDROLES 
GROUP BY U.USERNAME
GO

SELECT P.NAME, COUNT(*) AS 'COUNTSTUFFS' 
FROM dbo.PLACESTUFFS AS P, dbo.STUFFSPLACESTUFFS AS SP 
WHERE P.ID = SP.IDPLACESTUFFS
 GROUP BY P.NAME
GO

SELECT C.NAME, C.CREATEDDATE, C.CREATEBY, C.MODIFIEDDATE, C.MODIFIEDBY, COUNT(*) AS 'COUNTSTUFFS' 
FROM dbo.CATEGORIES AS C, dbo.STUFFS AS S 
WHERE S.IDCATEGORIES = C.ID 
GROUP BY C.NAME, C.CREATEDDATE, C.CREATEBY, C.MODIFIEDDATE, C.MODIFIEDBY
GO

SELECT S.ID, S.NAME, S.BQCODE, S.PRODUCER, S.DATEBUY, S.DATEUSE, S.YEARRELEASE, S.COLORSTUFFS, S.STATE, S.PRICEBUY, S.WARRANTY, S.STATUS, S.CREATEDDATE, S.CREATEBY, S.MODIFIEDDATE, S.MODIFIEDBY, C.NAME AS CATEGORY 
FROM dbo.STUFFS AS S 
JOIN dbo.CATEGORIES AS C 
ON C.ID = S.IDCATEGORIES 
WHERE S.ID 
NOT IN ( SELECT SP.IDSTUFFS FROM dbo.STUFFSPLACESTUFFS AS SP)
GO

SELECT S.ID, S.NAME, S.BQCODE, S.PRODUCER, S.DATEBUY, S.DATEUSE, S.YEARRELEASE, S.COLORSTUFFS, S.STATE, S.PRICEBUY, S.WARRANTY, S.STATUS, S.CREATEDDATE, S.CREATEBY, S.MODIFIEDDATE, S.MODIFIEDBY, P.NAME AS PLACESTUFF, C.NAME AS CATEGORY
FROM dbo.STUFFS AS S 
JOIN dbo.STUFFSPLACESTUFFS AS SP 
ON SP.IDSTUFFS = S.ID 
JOIN dbo.PLACESTUFFS AS P 
ON SP.IDPLACESTUFFS = P.ID 
JOIN dbo.CATEGORIES AS C
ON C.ID = S.IDCATEGORIES
WHERE P.ID = 1

