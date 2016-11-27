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
ALTER TABLE [dbo].[CustomerDemographics] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_CustomerDemographics_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[CustomerDemographics] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_CustomerDemographics_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerDemographics_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[CustomerDemographics_Tombstone]( 
    [CustomerTypeID] NChar(10) NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[CustomerDemographics_Tombstone] ADD CONSTRAINT [PKDEL_CustomerDemographics_Tombstone_CustomerTypeID]
   PRIMARY KEY CLUSTERED
    ([CustomerTypeID])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerDemographics_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[CustomerDemographics_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[CustomerDemographics_DeletionTrigger] 
    ON [CustomerDemographics] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[CustomerDemographics_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[CustomerTypeID] = [CustomerDemographics_Tombstone].[CustomerTypeID] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[CustomerDemographics_Tombstone] 
    ([CustomerTypeID], DeletionDate)
    SELECT [CustomerTypeID], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerDemographics_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[CustomerDemographics_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[CustomerDemographics_UpdateTrigger] 
    ON [dbo].[CustomerDemographics] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[CustomerDemographics] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[CustomerTypeID] = [CustomerDemographics].[CustomerTypeID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerDemographics_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[CustomerDemographics_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[CustomerDemographics_InsertTrigger] 
    ON [dbo].[CustomerDemographics] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[CustomerDemographics] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[CustomerTypeID] = [CustomerDemographics].[CustomerTypeID] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
