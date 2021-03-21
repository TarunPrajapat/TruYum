using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruYum.Models;

namespace TruYum.Controllers
{
    public class CustomerController : Controller
    {
        TruYumContext db = new TruYumContext();
     
        [Authorize]
        public ActionResult Cart(int? menuItemId)
        {
            if (menuItemId != null)
            {
                Cart cart = new Cart()
                {
                    MenuItemId = (int)menuItemId
                };
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("ViewCart");
            }
            else
            {
                return View();
            }
        }

        public class CartList
        {
            public int CartId { get; set; }
            public string Name { get; set; }
            public bool FreeDelivery { get; set; }
            public double Price { get; set; }
        }
        public ActionResult ViewCart()
        {
            var list = (from cart in db.Carts
                        join menu in db.MenuItems on cart.MenuItemId equals menu.Id
                        orderby cart.MenuItemId
                        select new CartList()
                        {
                            CartId = cart.MenuItemId,
                            Name = menu.Name,
                            FreeDelivery = menu.FreeDelivery,
                            Price = menu.Price,
                        }).ToList();

            return View(list);
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Cart Cid = db.Carts.Find(id);
                db.Carts.Remove(Cid);
                db.SaveChanges();
                return RedirectToAction("ViewCart");
            }
            else
            {
                return View();
            }

        }
    }
}