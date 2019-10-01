using Sheet4StarSubs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sheet4StarSubs.Models;

namespace Sheet4StarSubs.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            return View();
        }
        public ActionResult Totals()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Order newOrder, FormCollection myform)
        {
            double[] subPrice = new double[] { 1.99, 2.99, 3.99, 4.99, 5.99, 6.99, 7.99 };
            string subName = Enum.GetName(typeof(SubType), newOrder.Sub);
            var priceOfSub = subPrice[(int)newOrder.Sub];

            double[] sizePrice = new double[] { 1.49, 2.49, 3.49, 4.49};
            string sizeOfBread = Enum.GetName(typeof(SizeType), newOrder.Size);
            var priceOfBread = sizePrice[(int)newOrder.Size];

            double[] dealPrice = new double[] { 0, 1.50, 2.50 };
            string dealName = Enum.GetName(typeof(MealType), newOrder.MealDeal);
            var priceOfDeal = dealPrice[(int)newOrder.MealDeal];

            //Strat Sheet 5
            double quantity = Int32.Parse(myform["quantity"]);
            //End Sheet 5

            double totalPriceOfSub = priceOfSub + priceOfBread;

            double singlecost = totalPriceOfSub + priceOfDeal;

            double cost = (totalPriceOfSub + priceOfDeal)*quantity;

            ViewBag.Cost = cost;
            ViewBag.Sub = subName;
            ViewBag.Bread = sizeOfBread;
            ViewBag.PriceSub = totalPriceOfSub;
            ViewBag.DealName = dealName;
            ViewBag.PriceDeal = priceOfDeal;
            ViewBag.SingleCost = singlecost;
            //Start Sheet 5
            ViewBag.Quantity = quantity;
            //End Sheet 5

            double tax = cost * .15;
            ViewBag.Tax = tax;
            double total = cost + tax;
            ViewBag.Total = total;

            //Start Sheet 5
            string date = @DateTime.Today.ToLongDateString();
            newOrder.Quantity = quantity;
            
            if(Session[date]!= null)
            {
                List<Order> oldorders = new List<Order>();
                oldorders = (List<Order>) Session[date];
                oldorders.Add(newOrder);
                Session[date] = oldorders;
            }
            else
            {
                var orders = new List<Order>();
                orders.Add(newOrder);
                Session[date] = orders;
                
            }

            if (TempData[date] != null) {
                double totalAmount = (double)TempData[date];
                totalAmount += total;
                TempData[date] = totalAmount;
            }
            else {
                TempData[date] = total;
            }

            //End Sheet 5
            return View("Receipt");

        }
        

    }
}