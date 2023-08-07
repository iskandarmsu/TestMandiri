using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;


namespace WebApp.ViewModel
{
    public class OrderViewModel
    {
        public Order order { get; set; }
        //public List<Customer> CustomerList { get; set; }
        public Customer customer { get; set; }
        public Product product { get; set; }

    }
}