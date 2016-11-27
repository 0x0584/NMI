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
ALTER TABLE [dbo].[Customers] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_Customers_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Customers] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_Customers_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[Customers_Tombstone]( 
    [CustomerID] NChar(5) NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Customers_Tombstone] ADD CONSTRAINT [PKDEL_Customers_Tombstone_CustomerID]
   PRIMARY KEY CLUSTERED
    ([CustomerID])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Customers_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[Customers_DeletionTrigger] 
    ON [Customers] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[Customers_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[CustomerID] = [Customers_Tombstone].[CustomerID] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[Customers_Tombstone] 
    ([CustomerID], DeletionDate)
    SELECT [CustomerID], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Customers_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[Customers_UpdateTrigger] 
    ON [dbo].[Customers] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Customers] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[CustomerID] = [Customers].[CustomerID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Customers_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[Customers_InsertTrigger] 
    ON [dbo].[Customers] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Customers] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[CustomerID] = [Customers].[CustomerID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
