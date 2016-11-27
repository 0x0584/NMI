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
ALTER TABLE [dbo].[Territories] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_Territories_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Territories] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_Territories_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Territories_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[Territories_Tombstone]( 
    [TerritoryID] NVarChar(20) NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Territories_Tombstone] ADD CONSTRAINT [PKDEL_Territories_Tombstone_TerritoryID]
   PRIMARY KEY CLUSTERED
    ([TerritoryID])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Territories_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Territories_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[Territories_DeletionTrigger] 
    ON [Territories] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[Territories_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[TerritoryID] = [Territories_Tombstone].[TerritoryID] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[Territories_Tombstone] 
    ([TerritoryID], DeletionDate)
    SELECT [TerritoryID], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Territories_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Territories_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[Territories_UpdateTrigger] 
    ON [dbo].[Territories] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Territories] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[TerritoryID] = [Territories].[TerritoryID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Territories_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Territories_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[Territories_InsertTrigger] 
    ON [dbo].[Territories] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Territories] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[TerritoryID] = [Territories].[TerritoryID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
