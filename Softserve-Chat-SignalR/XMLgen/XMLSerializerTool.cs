using System;
using System.Xml.Serialization;

namespace Softserve_Chat_SignalR.XMLgen
{
    public class XmlSerializerTool
    {
        public void Serial()
        {
            var sale = new SalesOrder
            {
                Comments = "joe",
                CreatedByID = 2,
                CreatedByIDSpecified = true,
                CreatedDate = DateTime.Now,
                CreatedDateSpecified = true,
                CustomerID = 2,
                CustomerIDSpecified = true,
                CustomerName = "Frikkie",
                DeliveryDetail = new AddressDetail()
                {
                    AddressDetailID = 1,
                    AddressDetailIDSpecified = true,
                    AddressLine1 = "help",
                    AddressLine2 = "me",
                    AltNumber = "what?",
                    City = "hell",
                    Company = "torture inc",
                    Country = "Australia",
                    Email = "Satan@hell.com",
                    FullName = "Lucifer",
                    Mobile = "666-Hell",
                    Phone = "666-Hole",
                    PostCode = "666",
                    Province = "7th circle",
                },
                IsReject = true,
                IsRejectSpecified = true,
                IsXStock = true,
                IsXStockSpecified = true,
                LineItems = new[]
            {
                new SalesOrderDetail()
                {
                    CommissionID = 1,
                    CommissionIDSpecified = true,
                    Commission = 1,
                    CommissionSpecified = true,
                    Comment = "so much shit to type",
                    Discount = 0,
                    DueDateSpecified = true,
                    Description = "it is pink",
                    DiscountSpecified = false,
                    DueDate = DateTime.Now,
                    ExRateSpecified = true,
                    ExRate = 5,
                    JobProductIDSpecified = true,
                    JobProductID = 2,
                    RepCodeID = 2,
                    RateSpecified = true,
                    Rate = 1,
                    Reference = "as",
                    RepCodeIDSpecified = true,
                    SODetailID = 1,
                    SkuDetails = new[]
                    {
                        new SkuDetail()
                        {
                            ProductStockID = 1,
                            ProductStockIDSpecified = true,
                            Size = "xxx",
                            SizeID = 1,
                            SizeIDSpecified = true,
                            SizeIndex = 1,
                            SizeIndexSpecified = true,
                            ThirdPartyBarcode = "afdsadfasdfasd",
                            UnitsSpecified = true,
                            Units = 3
                        }
                    }
                }
            },
                OrderNumber = "666-666-666",
                PONumber = "6six6",
                RequiredDate = DateTime.Now,
                RequiredDateSpecified = true,
                SalesOrderID = 2,
                SalesOrderIDSpecified = true,
                SalesRepID = 66,
                SalesRepIDSpecified = true,
                SpecialInstructions = "tickle lightly",
                StatusID = 1,
                StatusIDSpecified = true,
            };

            var ser = new XmlSerializer(typeof(SalesOrder));

            ser.Serialize(Console.Out, sale);
        }
    }
}