using System;
using System.Collections.Generic;
using System.Xml;
using static Order;

namespace XmlParsers.Parsers;

public static class XmlDomParser
{
    public static IEnumerable<Order> ParseOrders(string xmlPath)
    {
        var orders = new List<Order>();

        var document = new XmlDocument();
        document.Load(xmlPath);
        var root = document.DocumentElement;

        if (document.DocumentElement is null)
        {
            return null!;
        }
        else
        {
            foreach (XmlElement xmlElement in document.DocumentElement)
            {
                var order = new Order();
                var identifier = xmlElement.Attributes.GetNamedItem("id");
                order.orderId = ulong.Parse(identifier.Value);

                foreach (XmlNode node in xmlElement.ChildNodes)
                {
                    switch (node.LocalName)
                    {
                        case "orderId":
                            {
                                order.orderId = ulong.Parse(node.InnerText);
                                break;
                            }
                        case "orderStatus":
                            {
                                Enum.TryParse(node.InnerText, out OrderStatus status);
                                order.orderStatus = status;
                                break;
                            }
                        case "room":
                            {
                                order.orders.Add(ParseOrderNode(node));
                                break;
                            }
                      
                    }
                }

                orders.Add(order);
            }
        }
        return orders;
    }



    private static Order ParseOrderNode(XmlNode orderNode)
    {
        var orderId = orderNode.Attributes?.GetNamedItem("id")?.Value;

        var order = new Order
        {
            id = ulong.Parse(orderId)
        };

        for (int i = 0; i < orderNode.ChildNodes.Count; i++)
        {

            var innerElement = orderNode.ChildNodes[i];

            switch (innerElement.LocalName)
            {
                case "orderStatus":
                    {

                        order.orderStatus = (OrderStatus)byte.Parse(innerElement.InnerText);
                        break;
                    }
                case "room":
                    {

                        order.roomId = byte.Parse(innerElement.InnerText);
                        break;
                    }
                case "spa":
                    {

                        order.spaId = byte.Parse(innerElement.InnerText);
                        break;
                    }
                case "menu":
                    {

                        order.menuId = byte.Parse(innerElement.InnerText);
                        break;
                    }

            }
        }

        return order;
    }



    //private static Room ParseRoomNode(XmlNode roomNode)
    //{
    //    var roomId = roomNode.Attributes?.GetNamedItem("id")?.Value;

    //    var room = new Room
    //    {
    //        id = ulong.Parse(roomId) 
    //    };

    //    for (int i = 0; i < roomNode.ChildNodes.Count; i++)
    //    {

    //        var innerElement = roomNode.ChildNodes[i];

    //        switch (innerElement.LocalName)
    //        {
    //            case "number":
    //                {
                       
    //                    room.number = byte.Parse(innerElement.InnerText);
    //                    break;
    //                }
    //            case "categori":
    //                {
    //                    room.categori = innerElement.InnerText;
    //                    break;
    //                }
    //            case "count":
    //                {
    //                    room.count = byte.Parse(innerElement.InnerText);
    //                    break;
    //                }
    //            case "price":
    //                {
    //                    room.price = ulong.Parse(innerElement.InnerText);
    //                    break;
    //                }
    //        }
    //    }

    //    return room;
    //}





    //private static Spa ParseSpaNode(XmlNode spaNode)
    //{
    //    var spaId = spaNode.Attributes?.GetNamedItem("id")?.Value;

    //    var spa = new Spa
    //    {
    //        id = ulong.Parse(spaId)
    //    };

    //    for (int i = 0; i < spaNode.ChildNodes.Count; i++)
    //    {

    //        var innerElement = spaNode.ChildNodes[i];

    //        switch (innerElement.LocalName)
    //        {
    //            case "name":
    //                {
    //                    spa.name = innerElement.InnerText;
    //                    break;
    //                }

    //            case "price":
    //                {
    //                    spa.price = double.Parse(innerElement.InnerText);
    //                    break;
    //                }
    //        }
    //    }

    //    return spa;
    //}

    //private static Menu ParseMenuNode(XmlNode menuNode)
    //{
    //    var menuId = menuNode.Attributes?.GetNamedItem("id")?.Value;

    //    var menu = new Menu
    //    {
    //        id = ulong.Parse(menuId)
    //    };

    //    for (int i = 0; i < menuNode.ChildNodes.Count; i++)
    //    {

    //        var innerElement = menuNode.ChildNodes[i];

    //        switch (innerElement.LocalName)
    //        {
    //            case "name":
    //                {
    //                    menu.name = innerElement.InnerText;
    //                    break;
    //                }
    //            case "ingridients":
    //                {
    //                    menu.ingridients = innerElement.InnerText;
    //                    break;
    //                }
    //            case "price":
    //                {
    //                    menu.price = ulong.Parse(innerElement.InnerText);
    //                    break;
    //                }
    //        }
    //    }

    //    return menu;
    //}
}
