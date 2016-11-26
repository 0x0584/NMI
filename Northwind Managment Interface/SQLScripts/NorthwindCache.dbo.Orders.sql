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
ALTER TABLE [dbo].[Orders] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_Orders_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Orders] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_Orders_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[Orders_Tombstone]( 
    [OrderID] Int NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Orders_Tombstone] ADD CONSTRAINT [PKDEL_Orders_Tombstone_OrderID]
   PRIMARY KEY CLUSTERED
    ([OrderID])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Orders_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[Orders_DeletionTrigger] 
    ON [Orders] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[Orders_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[OrderID] = [Orders_Tombstone].[OrderID] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[Orders_Tombstone] 
    ([OrderID], DeletionDate)
    SELECT [OrderID], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Orders_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[Orders_UpdateTrigger] 
    ON [dbo].[Orders] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Orders] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[OrderID] = [Orders].[OrderID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Orders_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[Orders_InsertTrigger] 
    ON [dbo].[Orders] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Orders] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[OrderID] = [Orders].[OrderID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
