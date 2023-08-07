using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Order
    {
        [Display(Name = "OrderId")]
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Customer ID")]
        public string CustomerID { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Required Date")]
        [DataType(DataType.Date)]
        public DateTime RequiredDate { get; set; }
        [Display(Name = "Order Name")]
        public string OrderName { get; set; }
        [Display(Name = "Product ID")]
        public string ProductID { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Qty")]
        public int Qty { get; set; }
        [Display(Name = "Harga")]
        public decimal Harga { get; set; }
        [Display(Name = "Total")]
        public decimal Total { get; set; }
    }
   
}