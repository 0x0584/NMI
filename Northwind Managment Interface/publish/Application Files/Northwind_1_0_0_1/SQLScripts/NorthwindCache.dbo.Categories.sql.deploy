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
ALTER TABLE [dbo].[Categories] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_Categories_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Categories] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_Categories_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[Categories_Tombstone]( 
    [CategoryID] Int NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Categories_Tombstone] ADD CONSTRAINT [PKDEL_Categories_Tombstone_CategoryID]
   PRIMARY KEY CLUSTERED
    ([CategoryID])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Categories_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[Categories_DeletionTrigger] 
    ON [Categories] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[Categories_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[CategoryID] = [Categories_Tombstone].[CategoryID] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[Categories_Tombstone] 
    ([CategoryID], DeletionDate)
    SELECT [CategoryID], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Categories_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[Categories_UpdateTrigger] 
    ON [dbo].[Categories] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Categories] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[CategoryID] = [Categories].[CategoryID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Categories_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[Categories_InsertTrigger] 
    ON [dbo].[Categories] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Categories] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[CategoryID] = [Categories].[CategoryID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
