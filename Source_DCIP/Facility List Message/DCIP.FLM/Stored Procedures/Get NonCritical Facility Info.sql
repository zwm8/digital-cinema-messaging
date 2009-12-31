USE [AMS]
GO

/****** Object:  StoredProcedure [dbo].[flm_GetNonCriticalFacilityInfo]    Script Date: 12/28/2009 14:16:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[flm_GetNonCriticalFacilityInfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[flm_GetNonCriticalFacilityInfo]
GO

USE [AMS]
GO

/****** Object:  StoredProcedure [dbo].[flm_GetNonCriticalFacilityInfo]    Script Date: 12/28/2009 14:16:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO










CREATE PROCEDURE [dbo].[flm_GetNonCriticalFacilityInfo]
(
	@Site_Id int
)
AS

SELECT     Exhibitor.Exhibitor_Name, Site_1.Street_1, Site_1.Street_2, Site_1.Street_3, Site_1.State, Site_1.City, Site_1.Zip_Code, Site_1.Nation, Site_1.Site_Name, 
                      Site_1.Site_Id,
                          (SELECT     COUNT(*) AS Expr1
                            FROM          Auditorium INNER JOIN
                                                   Location ON Auditorium.Location_Id = Location.Location_Id INNER JOIN
                                                   Site ON Location.Site_Id = Site.Site_Id
                            WHERE      (Site.Site_Id = @Site_Id)) AS TotalScreenCount, Site_AlternateIdentifier.Alternate_Identifier, AuthoritativeSource.Authoritative_Source_Name
FROM         Exhibitor INNER JOIN
                      Site AS Site_1 ON Exhibitor.Exhibitor_Id = Site_1.Exhibitor_Id INNER JOIN
                      Site_AlternateIdentifier ON Site_1.Site_Id = Site_AlternateIdentifier.Site_Id INNER JOIN
                      AuthoritativeSource ON Site_AlternateIdentifier.Authoritative_Source_Id = AuthoritativeSource.Authoritative_Source_Id
WHERE     (Site_1.Site_Id = @Site_Id)



GO


