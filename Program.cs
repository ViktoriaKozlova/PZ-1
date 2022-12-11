using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using XmlParsers;
using XmlParsers.Parsers;
using static Order;

// Validation
/*
XmlValidator.ValidateXmlDocument(new Url(XmlHelper.BaseUrl, @"Xml/Order.xml"));
XmlValidator.ValidateXmlDocument(new Url(XmlHelper.BaseUrl, @"Xml/Orders.xml"));
XmlValidator.ValidateXmlDocument(new Url(XmlHelper.BaseUrl, @"Xml/Menu.xml"));
XmlValidator.ValidateXmlDocument(new Url(XmlHelper.BaseUrl, @"Xml/Rooms.xml"));
XmlValidator.ValidateXmlDocument(new Url(XmlHelper.BaseUrl, @"Xml/Spa.xml"));
XmlValidator.ValidateXmlDocument(new Url(XmlHelper.BaseUrl, @"Xml/Room.xml"));
XmlValidator.ValidateXmlDocument(new Url(XmlHelper.BaseUrl, @"Xml/User.xml"));

// Sereallization

var marshalledOrder1 = new Order() { orderId = 1,  roomId = 1, spaId = 1, menuId = 1, userId = 1 };
var marshalledOrder2 = new Order() { orderId = 2,  roomId = 1, spaId = 1, menuId = 1, userId = 1 };

var marshalledOrder = new Order
{
    orderStatus = OrderStatus.Active,
    orders = new List<Order>() { marshalledOrder1, marshalledOrder2 },
    orderId = 1,id  = 1
   
};

Console.WriteLine($"Order to marshalling: {marshalledOrder}\n");

var createdXml = XmlGenericSerializer<Order>.Serialize(marshalledOrder);
File.WriteAllText(new Url(XmlHelper.BaseUrl, @"Xml/marshalledOrder.xml").FullPath, createdXml, Encoding.Unicode);

var orderDemarshalled = XmlGenericDeserializer<Order>.Deserialize(new Url(XmlHelper.BaseUrl, @"Xml/marshalledOrder.xml").FullPath);
Console.WriteLine($"\nDemarshalled order: {orderDemarshalled}");

var orderCustom = XmlGenericDeserializer<Order>.Deserialize(new Url(XmlHelper.BaseUrl, @"Xml/Order.xml").FullPath);
Console.WriteLine($"\nCustom order: {orderCustom}");

var parsedOrdersDOM = XmlDomParser.ParseOrders(new Url(XmlHelper.BaseUrl, @"Xml/Orders.xml").FullPath);

foreach (var booking in parsedOrdersDOM)
{
    Console.WriteLine(booking);
}
*/
XmlTransform.TransformXMLToHTML(new Url(XmlHelper.BaseUrl, @"Xml/Orders.xml").FullPath,
    new Url(XmlHelper.BaseUrl, @"Xml/Order.xslt").FullPath);
