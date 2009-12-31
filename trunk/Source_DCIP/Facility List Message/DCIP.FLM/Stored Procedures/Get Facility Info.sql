USE [AMS]
GO

/****** Object:  StoredProcedure [dbo].[flm_GetFacilityInfo]    Script Date: 12/28/2009 13:53:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[flm_GetFacilityInfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[flm_GetFacilityInfo]
GO

USE [AMS.2009.12.23]
GO

/****** Object:  StoredProcedure [dbo].[flm_GetFacilityInfo]    Script Date: 12/28/2009 13:53:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[flm_GetFacilityInfo]
(
	@Site_Id int
)
AS
SELECT     Exhibitor.Exhibitor_Name, Exhibitor.URI_Mapping, Site.Site_Id, Site.Site_Code, Site.Site_Name, Site_AlternateIdentifier.Alternate_Identifier, 
                      AuthoritativeSource.Authoritative_Source_Name
FROM         Exhibitor INNER JOIN
                      Site ON Exhibitor.Exhibitor_Id = Site.Exhibitor_Id INNER JOIN
                      AuthoritativeSource INNER JOIN
                      Site_AlternateIdentifier ON AuthoritativeSource.Authoritative_Source_Id = Site_AlternateIdentifier.Authoritative_Source_Id ON 
                      Site.Site_Id = Site_AlternateIdentifier.Site_Id
WHERE     (Site.Site_Id = @Site_Id)





GO


