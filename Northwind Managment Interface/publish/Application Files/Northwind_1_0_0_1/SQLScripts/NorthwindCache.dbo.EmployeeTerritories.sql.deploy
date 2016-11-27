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
ALTER TABLE [dbo].[EmployeeTerritories] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_EmployeeTerritories_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[EmployeeTerritories] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_EmployeeTerritories_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeTerritories_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[EmployeeTerritories_Tombstone]( 
    [EmployeeID] Int NOT NULL,
    [TerritoryID] NVarChar(20) NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[EmployeeTerritories_Tombstone] ADD CONSTRAINT [PKDEL_EmployeeTerritories_Tombstone_EmployeeIDTerritoryID]
   PRIMARY KEY CLUSTERED
    ([EmployeeID], [TerritoryID])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeTerritories_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[EmployeeTerritories_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[EmployeeTerritories_DeletionTrigger] 
    ON [EmployeeTerritories] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[EmployeeTerritories_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[EmployeeID] = [EmployeeTerritories_Tombstone].[EmployeeID] 
    AND deleted.[TerritoryID] = [EmployeeTerritories_Tombstone].[TerritoryID] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[EmployeeTerritories_Tombstone] 
    ([EmployeeID], [TerritoryID], DeletionDate)
    SELECT [EmployeeID], [TerritoryID], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeTerritories_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[EmployeeTerritories_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[EmployeeTerritories_UpdateTrigger] 
    ON [dbo].[EmployeeTerritories] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[EmployeeTerritories] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[EmployeeID] = [EmployeeTerritories].[EmployeeID] 
    AND inserted.[TerritoryID] = [EmployeeTerritories].[TerritoryID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeTerritories_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[EmployeeTerritories_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[EmployeeTerritories_InsertTrigger] 
    ON [dbo].[EmployeeTerritories] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[EmployeeTerritories] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[EmployeeID] = [EmployeeTerritories].[EmployeeID] 
    AND inserted.[TerritoryID] = [EmployeeTerritories].[TerritoryID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
