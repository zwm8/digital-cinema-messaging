USE [AMS]
GO

/****** Object:  StoredProcedure [dbo].[flm_GetNonCriticalAuditoriumInfo]    Script Date: 01/05/2010 19:11:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[flm_GetNonCriticalAuditoriumInfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[flm_GetNonCriticalAuditoriumInfo]
GO

USE [AMS]
GO

/****** Object:  StoredProcedure [dbo].[flm_GetNonCriticalAuditoriumInfo]    Script Date: 01/05/2010 19:11:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[flm_GetNonCriticalAuditoriumInfo]
(
	@Site_Id int
)
AS

SELECT     Site.Site_Id, Auditorium.Auditorium_Id, Auditorium.Auditorium_3D, Auditorium.Auditorium_Code, Location.Acceptance_Date, Auditorium_Screen.Silver_Screen, 
                      Auditorium_3D_Type.Type_Description, Site_Deployment.Date_Standard_Conversion, Site_Deployment.Date_3D_Conversion, Auditorium.Auditorium_IMAX, 
                      Auditorium.Conversion
FROM         Site_Deployment INNER JOIN
                      Site ON Site_Deployment.Site_Id = Site.Site_Id LEFT OUTER JOIN
                      Auditorium INNER JOIN
                      Location ON Auditorium.Location_Id = Location.Location_Id INNER JOIN
                      Auditorium_3D_Type ON Auditorium.Auditorium_3D_Type_Id = Auditorium_3D_Type.Type_Id LEFT OUTER JOIN
                      Auditorium_Screen ON Auditorium.Auditorium_Id = Auditorium_Screen.Auditorium_Id ON Site.Site_Id = Location.Site_Id
WHERE     (Site.Site_Id = @Site_Id)
ORDER BY Auditorium.Auditorium_Code



GO


