/*
 Navicat Premium Data Transfer

 Source Server         : locahost
 Source Server Type    : SQL Server
 Source Server Version : 16001000 (16.00.1000)
 Source Host           : .:1433
 Source Catalog        : LastBugSpa
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001000 (16.00.1000)
 File Encoding         : 65001

 Date: 06/11/2023 02:31:08
*/


-- ----------------------------
-- Table structure for AsignacionesAyudaSocial
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[AsignacionesAyudaSocial]') AND type IN ('U'))
	DROP TABLE [dbo].[AsignacionesAyudaSocial]
GO

CREATE TABLE [dbo].[AsignacionesAyudaSocial] (
  [AsignacionID] int  IDENTITY(1,1) NOT NULL,
  [PersonaID] int  NULL,
  [AyudaSocialID] int  NULL,
  [Fecha] date  NULL
)
GO

ALTER TABLE [dbo].[AsignacionesAyudaSocial] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of AsignacionesAyudaSocial
-- ----------------------------
SET IDENTITY_INSERT [dbo].[AsignacionesAyudaSocial] ON
GO

INSERT INTO [dbo].[AsignacionesAyudaSocial] ([AsignacionID], [PersonaID], [AyudaSocialID], [Fecha]) VALUES (N'1', N'1', N'1', N'2023-11-05')
GO

INSERT INTO [dbo].[AsignacionesAyudaSocial] ([AsignacionID], [PersonaID], [AyudaSocialID], [Fecha]) VALUES (N'2', N'1', N'1', N'2022-11-06')
GO

SET IDENTITY_INSERT [dbo].[AsignacionesAyudaSocial] OFF
GO


-- ----------------------------
-- Table structure for AyudasSociales
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[AyudasSociales]') AND type IN ('U'))
	DROP TABLE [dbo].[AyudasSociales]
GO

CREATE TABLE [dbo].[AyudasSociales] (
  [AyudaSocialID] int  IDENTITY(1,1) NOT NULL,
  [Nombre] nvarchar(255) COLLATE Modern_Spanish_CI_AS  NULL,
  [ComunaID] int  NULL
)
GO

ALTER TABLE [dbo].[AyudasSociales] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of AyudasSociales
-- ----------------------------
SET IDENTITY_INSERT [dbo].[AyudasSociales] ON
GO

INSERT INTO [dbo].[AyudasSociales] ([AyudaSocialID], [Nombre], [ComunaID]) VALUES (N'1', N'Ayuda 1', N'1')
GO

INSERT INTO [dbo].[AyudasSociales] ([AyudaSocialID], [Nombre], [ComunaID]) VALUES (N'2', N'Ayuda 2', N'2')
GO

INSERT INTO [dbo].[AyudasSociales] ([AyudaSocialID], [Nombre], [ComunaID]) VALUES (N'3', N'Ayuda 3', N'4')
GO

INSERT INTO [dbo].[AyudasSociales] ([AyudaSocialID], [Nombre], [ComunaID]) VALUES (N'4', N'Salud Larawi', N'5')
GO

SET IDENTITY_INSERT [dbo].[AyudasSociales] OFF
GO


-- ----------------------------
-- Table structure for Comunas
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Comunas]') AND type IN ('U'))
	DROP TABLE [dbo].[Comunas]
GO

CREATE TABLE [dbo].[Comunas] (
  [ComunaID] int  IDENTITY(1,1) NOT NULL,
  [Nombre] nvarchar(255) COLLATE Modern_Spanish_CI_AS  NULL,
  [RegionID] int  NULL
)
GO

ALTER TABLE [dbo].[Comunas] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Comunas
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Comunas] ON
GO

INSERT INTO [dbo].[Comunas] ([ComunaID], [Nombre], [RegionID]) VALUES (N'1', N'Santiago', N'1')
GO

INSERT INTO [dbo].[Comunas] ([ComunaID], [Nombre], [RegionID]) VALUES (N'2', N'Maipú', N'1')
GO

INSERT INTO [dbo].[Comunas] ([ComunaID], [Nombre], [RegionID]) VALUES (N'3', N'Talca', N'2')
GO

INSERT INTO [dbo].[Comunas] ([ComunaID], [Nombre], [RegionID]) VALUES (N'4', N'La Plata', N'3')
GO

INSERT INTO [dbo].[Comunas] ([ComunaID], [Nombre], [RegionID]) VALUES (N'5', N'Lima', N'4')
GO

INSERT INTO [dbo].[Comunas] ([ComunaID], [Nombre], [RegionID]) VALUES (N'6', N'Abc', N'5')
GO

INSERT INTO [dbo].[Comunas] ([ComunaID], [Nombre], [RegionID]) VALUES (N'7', N'Bcd', N'5')
GO

INSERT INTO [dbo].[Comunas] ([ComunaID], [Nombre], [RegionID]) VALUES (N'8', N'DF', N'6')
GO

SET IDENTITY_INSERT [dbo].[Comunas] OFF
GO


-- ----------------------------
-- Table structure for Paises
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Paises]') AND type IN ('U'))
	DROP TABLE [dbo].[Paises]
GO

CREATE TABLE [dbo].[Paises] (
  [PaisID] int  IDENTITY(1,1) NOT NULL,
  [Nombre] nvarchar(255) COLLATE Modern_Spanish_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Paises] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Paises
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Paises] ON
GO

INSERT INTO [dbo].[Paises] ([PaisID], [Nombre]) VALUES (N'1', N'Chile')
GO

INSERT INTO [dbo].[Paises] ([PaisID], [Nombre]) VALUES (N'2', N'Argentina')
GO

INSERT INTO [dbo].[Paises] ([PaisID], [Nombre]) VALUES (N'3', N'Perú')
GO

INSERT INTO [dbo].[Paises] ([PaisID], [Nombre]) VALUES (N'4', N'Bolivia')
GO

INSERT INTO [dbo].[Paises] ([PaisID], [Nombre]) VALUES (N'5', N'Ecuador')
GO

INSERT INTO [dbo].[Paises] ([PaisID], [Nombre]) VALUES (N'6', N'Colombia')
GO

INSERT INTO [dbo].[Paises] ([PaisID], [Nombre]) VALUES (N'7', N'Mexico')
GO

SET IDENTITY_INSERT [dbo].[Paises] OFF
GO


-- ----------------------------
-- Table structure for Persona
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Persona]') AND type IN ('U'))
	DROP TABLE [dbo].[Persona]
GO

CREATE TABLE [dbo].[Persona] (
  [PersonaID] int  IDENTITY(1,1) NOT NULL,
  [Nombre] nvarchar(255) COLLATE Modern_Spanish_CI_AS  NULL,
  [CorreoElectronico] nvarchar(255) COLLATE Modern_Spanish_CI_AS  NULL,
  [ComunaID] int  NULL
)
GO

ALTER TABLE [dbo].[Persona] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Persona
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Persona] ON
GO

INSERT INTO [dbo].[Persona] ([PersonaID], [Nombre], [CorreoElectronico], [ComunaID]) VALUES (N'1', N'Omar', N'oyujra@gmail.com', N'1')
GO

INSERT INTO [dbo].[Persona] ([PersonaID], [Nombre], [CorreoElectronico], [ComunaID]) VALUES (N'2', N'Santos', N'syujra@gmail.com', N'2')
GO

SET IDENTITY_INSERT [dbo].[Persona] OFF
GO


-- ----------------------------
-- Table structure for Regiones
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Regiones]') AND type IN ('U'))
	DROP TABLE [dbo].[Regiones]
GO

CREATE TABLE [dbo].[Regiones] (
  [RegionID] int  IDENTITY(1,1) NOT NULL,
  [Nombre] nvarchar(255) COLLATE Modern_Spanish_CI_AS  NULL,
  [PaisID] int  NULL
)
GO

ALTER TABLE [dbo].[Regiones] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Regiones
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Regiones] ON
GO

INSERT INTO [dbo].[Regiones] ([RegionID], [Nombre], [PaisID]) VALUES (N'1', N'Región Metropolitana', N'1')
GO

INSERT INTO [dbo].[Regiones] ([RegionID], [Nombre], [PaisID]) VALUES (N'2', N'Región del Maule', N'1')
GO

INSERT INTO [dbo].[Regiones] ([RegionID], [Nombre], [PaisID]) VALUES (N'3', N'Región de Buenos Aires', N'2')
GO

INSERT INTO [dbo].[Regiones] ([RegionID], [Nombre], [PaisID]) VALUES (N'4', N'Región de Lima', N'3')
GO

INSERT INTO [dbo].[Regiones] ([RegionID], [Nombre], [PaisID]) VALUES (N'5', N'Cali', N'6')
GO

INSERT INTO [dbo].[Regiones] ([RegionID], [Nombre], [PaisID]) VALUES (N'6', N'Sur', N'7')
GO

SET IDENTITY_INSERT [dbo].[Regiones] OFF
GO


-- ----------------------------
-- Table structure for Usuarios
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type IN ('U'))
	DROP TABLE [dbo].[Usuarios]
GO

CREATE TABLE [dbo].[Usuarios] (
  [UsuarioID] int  IDENTITY(1,1) NOT NULL,
  [Nombre] nvarchar(255) COLLATE Modern_Spanish_CI_AS  NULL,
  [CorreoElectronico] nvarchar(255) COLLATE Modern_Spanish_CI_AS  NULL,
  [Contrasena] nvarchar(255) COLLATE Modern_Spanish_CI_AS  NULL,
  [Rol] nvarchar(50) COLLATE Modern_Spanish_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Usuarios] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Usuarios
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Usuarios] ON
GO

INSERT INTO [dbo].[Usuarios] ([UsuarioID], [Nombre], [CorreoElectronico], [Contrasena], [Rol]) VALUES (N'1', N'Admin', N'admin@example.com', N'contrasena123', N'Administrador')
GO

INSERT INTO [dbo].[Usuarios] ([UsuarioID], [Nombre], [CorreoElectronico], [Contrasena], [Rol]) VALUES (N'2', N'Usuario1', N'usuario1@example.com', N'password123', N'Usuario')
GO

INSERT INTO [dbo].[Usuarios] ([UsuarioID], [Nombre], [CorreoElectronico], [Contrasena], [Rol]) VALUES (N'3', N'Usuario2', N'usuario2@example.com', N'securepass', N'Usuario')
GO

INSERT INTO [dbo].[Usuarios] ([UsuarioID], [Nombre], [CorreoElectronico], [Contrasena], [Rol]) VALUES (N'4', N'Omar', N'oyujra@gmail.com', N'123456', N'usuario')
GO

INSERT INTO [dbo].[Usuarios] ([UsuarioID], [Nombre], [CorreoElectronico], [Contrasena], [Rol]) VALUES (N'7', N'Ricardo', N'yrack@gmail.com', N'123456', N'Administrador')
GO

INSERT INTO [dbo].[Usuarios] ([UsuarioID], [Nombre], [CorreoElectronico], [Contrasena], [Rol]) VALUES (N'8', N'Claudia', N'yayita@gmail.com', N'12346', N'Usuario')
GO

INSERT INTO [dbo].[Usuarios] ([UsuarioID], [Nombre], [CorreoElectronico], [Contrasena], [Rol]) VALUES (N'9', N'Ross', N'ross@gmail.com', N'123465', N'Administrador')
GO

SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO


-- ----------------------------
-- Auto increment value for AsignacionesAyudaSocial
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[AsignacionesAyudaSocial]', RESEED, 2)
GO


-- ----------------------------
-- Primary Key structure for table AsignacionesAyudaSocial
-- ----------------------------
ALTER TABLE [dbo].[AsignacionesAyudaSocial] ADD CONSTRAINT [PK__Asignaci__D82B5BB779AAC7E7] PRIMARY KEY CLUSTERED ([AsignacionID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for AyudasSociales
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[AyudasSociales]', RESEED, 4)
GO


-- ----------------------------
-- Primary Key structure for table AyudasSociales
-- ----------------------------
ALTER TABLE [dbo].[AyudasSociales] ADD CONSTRAINT [PK__AyudasSo__7D00E50B75A2B8BC] PRIMARY KEY CLUSTERED ([AyudaSocialID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Comunas
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Comunas]', RESEED, 8)
GO


-- ----------------------------
-- Primary Key structure for table Comunas
-- ----------------------------
ALTER TABLE [dbo].[Comunas] ADD CONSTRAINT [PK__Comunas__4F2DF61F9FCCE07E] PRIMARY KEY CLUSTERED ([ComunaID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Paises
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Paises]', RESEED, 7)
GO


-- ----------------------------
-- Primary Key structure for table Paises
-- ----------------------------
ALTER TABLE [dbo].[Paises] ADD CONSTRAINT [PK__Paises__B501E1A51F3A2921] PRIMARY KEY CLUSTERED ([PaisID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Persona
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Persona]', RESEED, 2)
GO


-- ----------------------------
-- Primary Key structure for table Persona
-- ----------------------------
ALTER TABLE [dbo].[Persona] ADD CONSTRAINT [PK__Persona__7C34D32343A2447F] PRIMARY KEY CLUSTERED ([PersonaID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Regiones
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Regiones]', RESEED, 6)
GO


-- ----------------------------
-- Primary Key structure for table Regiones
-- ----------------------------
ALTER TABLE [dbo].[Regiones] ADD CONSTRAINT [PK__Regiones__ACD8444387C680EB] PRIMARY KEY CLUSTERED ([RegionID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Usuarios
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Usuarios]', RESEED, 9)
GO


-- ----------------------------
-- Primary Key structure for table Usuarios
-- ----------------------------
ALTER TABLE [dbo].[Usuarios] ADD CONSTRAINT [PK__Usuarios__2B3DE7984F66467B] PRIMARY KEY CLUSTERED ([UsuarioID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table AsignacionesAyudaSocial
-- ----------------------------
ALTER TABLE [dbo].[AsignacionesAyudaSocial] ADD CONSTRAINT [FK__Asignacio__Perso__6383C8BA] FOREIGN KEY ([PersonaID]) REFERENCES [dbo].[Persona] ([PersonaID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[AsignacionesAyudaSocial] ADD CONSTRAINT [FK__Asignacio__Ayuda__6477ECF3] FOREIGN KEY ([AyudaSocialID]) REFERENCES [dbo].[AyudasSociales] ([AyudaSocialID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table AyudasSociales
-- ----------------------------
ALTER TABLE [dbo].[AyudasSociales] ADD CONSTRAINT [FK__AyudasSoc__Comun__534D60F1] FOREIGN KEY ([ComunaID]) REFERENCES [dbo].[Comunas] ([ComunaID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Comunas
-- ----------------------------
ALTER TABLE [dbo].[Comunas] ADD CONSTRAINT [FK__Comunas__RegionI__5070F446] FOREIGN KEY ([RegionID]) REFERENCES [dbo].[Regiones] ([RegionID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Persona
-- ----------------------------
ALTER TABLE [dbo].[Persona] ADD CONSTRAINT [FK__Persona__ComunaI__5CD6CB2B] FOREIGN KEY ([ComunaID]) REFERENCES [dbo].[Comunas] ([ComunaID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Regiones
-- ----------------------------
ALTER TABLE [dbo].[Regiones] ADD CONSTRAINT [FK__Regiones__PaisID__4D94879B] FOREIGN KEY ([PaisID]) REFERENCES [dbo].[Paises] ([PaisID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

