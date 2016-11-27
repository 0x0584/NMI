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
ALTER TABLE [dbo].[Shippers] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_Shippers_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Shippers] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_Shippers_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shippers_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[Shippers_Tombstone]( 
    [ShipperID] Int NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Shippers_Tombstone] ADD CONSTRAINT [PKDEL_Shippers_Tombstone_ShipperID]
   PRIMARY KEY CLUSTERED
    ([ShipperID])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shippers_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Shippers_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[Shippers_DeletionTrigger] 
    ON [Shippers] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[Shippers_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[ShipperID] = [Shippers_Tombstone].[ShipperID] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[Shippers_Tombstone] 
    ([ShipperID], DeletionDate)
    SELECT [ShipperID], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shippers_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Shippers_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[Shippers_UpdateTrigger] 
    ON [dbo].[Shippers] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Shippers] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[ShipperID] = [Shippers].[ShipperID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shippers_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Shippers_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[Shippers_InsertTrigger] 
    ON [dbo].[Shippers] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Shippers] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[ShipperID] = [Shippers].[ShipperID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
