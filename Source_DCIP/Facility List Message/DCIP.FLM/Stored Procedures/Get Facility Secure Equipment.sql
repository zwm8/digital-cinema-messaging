USE [AMS]
GO

/****** Object:  StoredProcedure [dbo].[flm_GetFacilitySecureEquipment]    Script Date: 01/06/2010 14:34:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[flm_GetFacilitySecureEquipment]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[flm_GetFacilitySecureEquipment]
GO

USE [AMS]
GO

/****** Object:  StoredProcedure [dbo].[flm_GetFacilitySecureEquipment]    Script Date: 01/06/2010 14:34:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[flm_GetFacilitySecureEquipment]
(
	@Site_Id int
)
AS

SELECT     Location.Site_Id, Location.Location_Id, Location_Type.Type_Id AS Location_Type_Id, Location_Type.Type_Name AS Location_Type_Name, 
                      Auditorium.Auditorium_Code, Location_Equipment.Equipment_Id, Equipment.Description, Manufacturer.Manufacturer, Manufacturer.Manufacturer_UniqueIdentifier, 
                      Equipment.Model, Equipment.Serial_Number, Equipment_Cert.Cert_String, Equipment_Attribute.Attribute_Value, 
                      Equipment_Core_Attribute.Equipment_Attribute_Datatype, Equipment_Core_Attribute.Equipment_Attribute_Name, Equipment_Core_Attribute.Core_Attribute_Id, 
                      Equipment_Category.Name, Equipment_Category.FLM_DeviceType
FROM         Equipment_Core_Attribute INNER JOIN
                      Equipment_Attribute ON Equipment_Core_Attribute.Core_Attribute_Id = Equipment_Attribute.Core_Attribute_Id INNER JOIN
                      Equipment_Category ON Equipment_Core_Attribute.Category_Id = Equipment_Category.Category_Id RIGHT OUTER JOIN
                      Equipment INNER JOIN
                      Location_Equipment ON Equipment.Equipment_Id = Location_Equipment.Equipment_Id LEFT OUTER JOIN
                      Manufacturer ON Equipment.Manufacturer_Id = Manufacturer.Manufacturer_Id LEFT OUTER JOIN
                      Equipment_Cert ON Equipment.Equipment_Id = Equipment_Cert.Equipment_Id ON Equipment_Attribute.Equipment_Id = Equipment.Equipment_Id RIGHT OUTER JOIN
                      Auditorium INNER JOIN
                      Location ON Auditorium.Location_Id = Location.Location_Id INNER JOIN
                      Location_Type ON Location.Type_Id = Location_Type.Type_Id ON Location_Equipment.Location_Id = Location.Location_Id
WHERE     (Location.Site_Id = @Site_Id) AND (Location_Type.Type_Name = 'Auditorium') AND ((Equipment_Category.Category = 'Player_SMS') OR
                      (Equipment_Category.Category = 'SMS_Player') OR
                      (Equipment_Category.Category = 'Projector'))
ORDER BY Equipment.Equipment_Id




GO


