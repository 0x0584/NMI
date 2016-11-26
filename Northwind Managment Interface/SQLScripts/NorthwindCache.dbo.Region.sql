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
ALTER TABLE [dbo].[Region] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_Region_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Region] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_Region_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Region_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[Region_Tombstone]( 
    [RegionID] Int NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Region_Tombstone] ADD CONSTRAINT [PKDEL_Region_Tombstone_RegionID]
   PRIMARY KEY CLUSTERED
    ([RegionID])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Region_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Region_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[Region_DeletionTrigger] 
    ON [Region] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[Region_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[RegionID] = [Region_Tombstone].[RegionID] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[Region_Tombstone] 
    ([RegionID], DeletionDate)
    SELECT [RegionID], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Region_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Region_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[Region_UpdateTrigger] 
    ON [dbo].[Region] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Region] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[RegionID] = [Region].[RegionID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Region_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Region_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[Region_InsertTrigger] 
    ON [dbo].[Region] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Region] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[RegionID] = [Region].[RegionID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
