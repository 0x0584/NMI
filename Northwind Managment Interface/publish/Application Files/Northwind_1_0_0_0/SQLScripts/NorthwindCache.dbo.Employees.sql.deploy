/****
Ce script SQL a été généré par la boîte de dialogue
Configurer la synchronisation des données. Ce script contient des instructions qui créent les
colonnes de suivi des modifications, la table des éléments supprimés et les déclencheurs sur
la base de données du serveur. Ces objets de base de données sont requis par les
services de synchronisation pour synchroniser correctement les données entre les
bases de données client et serveur. Pour plus d'informations, consultez la rubrique
‘Comment faire : Configurer un serveur de base de données pour la synchronisation’ dans l'aide.
****/


IF @@TRANCOUNT > 0
set ANSI_NULLS ON 
set QUOTED_IDENTIFIER ON 

GO
BEGIN TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Employees] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_Employees_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Employees] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_Employees_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[Employees_Tombstone]( 
    [EmployeeID] Int NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Employees_Tombstone] ADD CONSTRAINT [PKDEL_Employees_Tombstone_EmployeeID]
   PRIMARY KEY CLUSTERED
    ([EmployeeID])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Employees_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[Employees_DeletionTrigger] 
    ON [Employees] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[Employees_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[EmployeeID] = [Employees_Tombstone].[EmployeeID] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[Employees_Tombstone] 
    ([EmployeeID], DeletionDate)
    SELECT [EmployeeID], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Employees_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[Employees_UpdateTrigger] 
    ON [dbo].[Employees] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Employees] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[EmployeeID] = [Employees].[EmployeeID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Employees_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[Employees_InsertTrigger] 
    ON [dbo].[Employees] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Employees] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[EmployeeID] = [Employees].[EmployeeID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
