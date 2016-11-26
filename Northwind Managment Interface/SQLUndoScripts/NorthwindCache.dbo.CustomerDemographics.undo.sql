/****
ATTENTION
 Pour prévenir tout problème éventuel de perte de données, vous devez passer en revue
ce script dans les détails avant de l'exécuter.

Ce script SQL a été généré par la boîte de dialogue Configurer la synchronisation des données.
Il est fourni en complément du script permettant
de créer les objets de base de données requis pour le suivi des modifications. Ce script contient des
instructions pour la suppression de ces modifications.

Pour plus d'informations, consultez la rubrique suivante de l'aide : Comment faire pour configurer un serveur de base de données pour la synchronisation.
****/


IF @@TRANCOUNT > 0
set ANSI_NULLS ON 
set QUOTED_IDENTIFIER ON 

GO
BEGIN TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[CustomerDemographics] DROP CONSTRAINT [DF_CustomerDemographics_LastEditDate]
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[CustomerDemographics] DROP COLUMN [LastEditDate]
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[CustomerDemographics] DROP CONSTRAINT [DF_CustomerDemographics_CreationDate]
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[CustomerDemographics] DROP COLUMN [CreationDate]
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerDemographics_Tombstone]') and TYPE = N'U') 
   DROP TABLE [dbo].[CustomerDemographics_Tombstone];


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerDemographics_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[CustomerDemographics_DeletionTrigger] 

GO


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerDemographics_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[CustomerDemographics_UpdateTrigger] 

GO


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerDemographics_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[CustomerDemographics_InsertTrigger] 

GO
COMMIT TRANSACTION;
