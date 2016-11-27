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
ALTER TABLE [dbo].[Suppliers] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_Suppliers_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Suppliers] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_Suppliers_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Suppliers_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[Suppliers_Tombstone]( 
    [SupplierID] Int NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[Suppliers_Tombstone] ADD CONSTRAINT [PKDEL_Suppliers_Tombstone_SupplierID]
   PRIMARY KEY CLUSTERED
    ([SupplierID])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Suppliers_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Suppliers_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[Suppliers_DeletionTrigger] 
    ON [Suppliers] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[Suppliers_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[SupplierID] = [Suppliers_Tombstone].[SupplierID] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[Suppliers_Tombstone] 
    ([SupplierID], DeletionDate)
    SELECT [SupplierID], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Suppliers_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Suppliers_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[Suppliers_UpdateTrigger] 
    ON [dbo].[Suppliers] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Suppliers] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[SupplierID] = [Suppliers].[SupplierID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Suppliers_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[Suppliers_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[Suppliers_InsertTrigger] 
    ON [dbo].[Suppliers] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[Suppliers] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[SupplierID] = [Suppliers].[SupplierID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
