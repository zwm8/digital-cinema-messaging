USE [AMS]
GO

/****** Object:  StoredProcedure [dbo].[flm_GetFacilitySecureEquipment]    Script Date: 12/02/2009 10:30:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[flm_GetFacilitySecureEquipment]
(
	@Site_Id int
)
AS

SELECT     Site.Site_Id, Location.Location_Id, Location.Type_Id AS Location_Type_Id, Location_Type.Type_Name AS Location_Type_Name, Auditorium.Auditorium_Code, 
                      Equipment.Equipment_Id, Equipment_Category.Name, Equipment.Description, Manufacturer.Manufacturer, Manufacturer.Manufacturer_UniqueIdentifier, 
                      Equipment.Model, Equipment.Serial_Number, Equipment_Cert.Cert_String, Equipment_Category.FLM_DeviceType, 
                      Equipment_Attribute.Attribute_Value, Equipment_Core_Attribute.Equipment_Attribute_Datatype, Equipment_Core_Attribute.Equipment_Attribute_Name, 
                      Equipment_Core_Attribute.Core_Attribute_Id
FROM         Equipment INNER JOIN
                      Location_Equipment ON Equipment.Equipment_Id = Location_Equipment.Equipment_Id INNER JOIN
                      Equipment_Category ON Equipment.Category_Id = Equipment_Category.Category_Id INNER JOIN
                      Equipment_Attribute ON Equipment.Equipment_Id = Equipment_Attribute.Equipment_Id INNER JOIN
                      Equipment_Core_Attribute ON Equipment_Category.Category_Id = Equipment_Core_Attribute.Category_Id AND 
                      Equipment_Attribute.Core_Attribute_Id = Equipment_Core_Attribute.Core_Attribute_Id INNER JOIN
                      Equipment_Cert ON Equipment.Equipment_Id = Equipment_Cert.Equipment_Id AND Equipment_Category.Category_Id = Equipment_Cert.Category_Id INNER JOIN
                      Manufacturer ON Equipment.Manufacturer_Id = Manufacturer.Manufacturer_Id AND 
                      Equipment_Cert.Manufacturer_Id = Manufacturer.Manufacturer_Id RIGHT OUTER JOIN
                      Location INNER JOIN
                      Site ON Location.Site_Id = Site.Site_Id ON Location_Equipment.Location_Id = Location.Location_Id LEFT OUTER JOIN
                      Location_Type ON Location.Type_Id = Location_Type.Type_Id LEFT OUTER JOIN
                      Auditorium ON Location.Location_Id = Auditorium.Location_Id
WHERE     (Site.Site_Id = @Site_Id) AND (Location_Type.Type_Name = 'Auditorium') AND (Equipment_Category.Category = 'Player_SMS' OR
                      Equipment_Category.Category = 'SMS_Player' OR
                      Equipment_Category.Category = 'Projector')
ORDER BY Equipment.Equipment_Id



GO

