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
ALTER TABLE [dbo].[Products] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_Products_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Products] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_Products_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[Products_Tombstone]( 
    [ProductID] Int NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Products_Tombstone] ADD CONSTRAINT [PKDEL_Products_Tombstone_ProductID]
   PRIMARY KEY CLUSTERED
    ([ProductID])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Products_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[Products_DeletionTrigger] 
    ON [Products] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[Products_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[ProductID] = [Products_Tombstone].[ProductID] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[Products_Tombstone] 
    ([ProductID], DeletionDate)
    SELECT [ProductID], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Products_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[Products_UpdateTrigger] 
    ON [dbo].[Products] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Products] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[ProductID] = [Products].[ProductID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Products_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[Products_InsertTrigger] 
    ON [dbo].[Products] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Products] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[ProductID] = [Products].[ProductID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
