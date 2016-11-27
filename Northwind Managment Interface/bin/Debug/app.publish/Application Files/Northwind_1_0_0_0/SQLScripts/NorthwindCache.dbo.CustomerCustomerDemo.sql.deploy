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
ALTER TABLE [dbo].[CustomerCustomerDemo] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_CustomerCustomerDemo_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[CustomerCustomerDemo] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_CustomerCustomerDemo_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerCustomerDemo_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[CustomerCustomerDemo_Tombstone]( 
    [CustomerID] NChar(5) NOT NULL,
    [CustomerTypeID] NChar(10) NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[CustomerCustomerDemo_Tombstone] ADD CONSTRAINT [PKDEL_CustomerCustomerDemo_Tombstone_CustomerIDCustomerTypeID]
   PRIMARY KEY CLUSTERED
    ([CustomerID], [CustomerTypeID])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerCustomerDemo_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[CustomerCustomerDemo_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[CustomerCustomerDemo_DeletionTrigger] 
    ON [CustomerCustomerDemo] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[CustomerCustomerDemo_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[CustomerID] = [CustomerCustomerDemo_Tombstone].[CustomerID] 
    AND deleted.[CustomerTypeID] = [CustomerCustomerDemo_Tombstone].[CustomerTypeID] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[CustomerCustomerDemo_Tombstone] 
    ([CustomerID], [CustomerTypeID], DeletionDate)
    SELECT [CustomerID], [CustomerTypeID], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerCustomerDemo_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[CustomerCustomerDemo_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[CustomerCustomerDemo_UpdateTrigger] 
    ON [dbo].[CustomerCustomerDemo] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[CustomerCustomerDemo] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[CustomerID] = [CustomerCustomerDemo].[CustomerID] 
    AND inserted.[CustomerTypeID] = [CustomerCustomerDemo].[CustomerTypeID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerCustomerDemo_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[CustomerCustomerDemo_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[CustomerCustomerDemo_InsertTrigger] 
    ON [dbo].[CustomerCustomerDemo] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[CustomerCustomerDemo] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[CustomerID] = [CustomerCustomerDemo].[CustomerID] 
    AND inserted.[CustomerTypeID] = [CustomerCustomerDemo].[CustomerTypeID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
