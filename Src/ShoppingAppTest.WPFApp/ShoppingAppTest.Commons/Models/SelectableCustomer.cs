using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShoppingAppTest.Commons.Models
{

    [JsonObject("CustomerMaster")]
    public class SelectableCustomer
    {
        public decimal CustomerID { get; set; }
        public bool CustomerTitle { get; set; }
        public string CustomerFName { get; set; }
        public string CustomerLName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string EmailAddress { get; set; }
    }
}
