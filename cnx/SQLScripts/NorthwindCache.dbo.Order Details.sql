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
ALTER TABLE [dbo].[Order Details] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_Order Details_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Order Details] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_Order Details_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order Details_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[Order Details_Tombstone]( 
    [OrderID] Int NOT NULL,
    [ProductID] Int NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Order Details_Tombstone] ADD CONSTRAINT [PKDEL_Order Details_Tombstone_OrderIDProductID]
   PRIMARY KEY CLUSTERED
    ([OrderID], [ProductID])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order Details_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Order Details_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[Order Details_DeletionTrigger] 
    ON [Order Details] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[Order Details_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[OrderID] = [Order Details_Tombstone].[OrderID] 
    AND deleted.[ProductID] = [Order Details_Tombstone].[ProductID] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[Order Details_Tombstone] 
    ([OrderID], [ProductID], DeletionDate)
    SELECT [OrderID], [ProductID], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order Details_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Order Details_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[Order Details_UpdateTrigger] 
    ON [dbo].[Order Details] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Order Details] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[OrderID] = [Order Details].[OrderID] 
    AND inserted.[ProductID] = [Order Details].[ProductID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order Details_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Order Details_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[Order Details_InsertTrigger] 
    ON [dbo].[Order Details] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Order Details] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[OrderID] = [Order Details].[OrderID] 
    AND inserted.[ProductID] = [Order Details].[ProductID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
