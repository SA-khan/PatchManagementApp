using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.App_Code
{
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public string ProductVersion { get; set; }
        public string ProductType { get; set; }
        public string ProductCategory { get; set; }
        public string ProductRating { get; set; }
        public string ProductDemoUserId { get; set; }
        public string ProductDemoPasscode { get; set; }
        public string ProductPOC { get; set; }
        public string ProductSupportEmail { get; set; }
        public string ProductComments { get; set; }
    }
}