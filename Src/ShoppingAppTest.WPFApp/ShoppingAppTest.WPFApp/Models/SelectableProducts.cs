using ShoppingAppTest.WPFApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppTest.WPFApp.Models
{
    public class SelectableProducts : BaseModel
    {
        public SelectableProducts()
        {

        }
        private decimal _ProductID;
        public decimal ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
            }
        }
        
        
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public string ProductDescription2 { get; set; }
        public decimal Price { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public string Images { get; set; }
        public decimal Quantity { get; set; }
    }
}
