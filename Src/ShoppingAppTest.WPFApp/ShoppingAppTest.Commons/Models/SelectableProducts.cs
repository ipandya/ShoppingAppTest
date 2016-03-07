using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppTest.Commons.Models
{
    public class SelectableProducts : BaseModel
    {
        public SelectableProducts()
        {
            this.CartQuantity = 1;
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

        public int CartQuantity { get; set; }

        public decimal SubTotal
        {
            get
            {
                return Price * CartQuantity;
            }
        }
    }
}
