using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using TradeWebAPI.DataBase;


namespace TradeWebAPI.Models
{
    public class ResponseTrade
    {
        public ResponseTrade(ResponseTrade trade)
        {
            Orderdate = trade.Orderdate;
            OrderDeliveryDate = trade.OrderDeliveryDate;
            Code = trade.Code;
            OrderStatus = trade.OrderStatus;
            ProductName = trade.ProductName;
            ProductQuantityInStock = trade.ProductQuantityInStock;
            ProductCost = trade.ProductCost;
            ProductDescription = trade.ProductDescription;
            ProductDiscountAmount = trade.ProductDiscountAmount;
            ProductPhoto = trade.ProductPhoto;
        }


        /// Order
        public DateTime Orderdate { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public int Code { get; set; }
        public string OrderStatus { get; set; }
        /// Products
        public string ProductName { get; set; }
        public int ProductQuantityInStock { get; set; }
        public decimal ProductCost { get; set; }
        public string ProductDescription { get; set; }
        public int ProductDiscountAmount { get; set; }
        public byte[] ProductPhoto { get; set; }

    }
}