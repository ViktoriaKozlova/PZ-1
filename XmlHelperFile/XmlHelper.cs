using System.Xml;
using System.Xml.Schema;

namespace XmlParsers;

public static class XmlHelper
{
    public static readonly string TargetNamespace = "http://hotel.com";
    public static readonly string BaseUrl = @"C:\ПРОЭКТЫ\XmlParser\XmlParser\XmlFile"; ///////

    public static readonly string BaseEntityUrl = @$"{BaseUrl}\Xsd\Entity.xsd";
    public static readonly string RoomUrl = @$"{BaseUrl}\Xsd\Room.xsd";
    public static readonly string UserUrl = @$"{BaseUrl}\Xsd\User.xsd";
    public static readonly string OrderUrl = @$"{BaseUrl}\Xsd\Order.xsd";
    public static readonly string SpaUrl = @$"{BaseUrl}\Xsd\Spa.xsd";
    public static readonly string MenuUrl = @$"{BaseUrl}\Xsd\Menu.xsd";

    public static XmlReaderSettings RetreiveXmlReaderSettings()
    {
        var settings = new XmlReaderSettings();

        settings.Schemas.Add(TargetNamespace, BaseEntityUrl);
        settings.Schemas.Add(TargetNamespace, RoomUrl);
        settings.Schemas.Add(TargetNamespace, UserUrl);
        settings.Schemas.Add(TargetNamespace, OrderUrl);
        settings.Schemas.Add(TargetNamespace, SpaUrl);
        settings.Schemas.Add(TargetNamespace, MenuUrl);

        settings.ValidationType = ValidationType.Schema;

        settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
        settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
        settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

        return settings;
    }
}