using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruYum.Models;

namespace TruYum.Controllers
{
    public class MenuItemsController : Controller
    {
        TruYumContext db = new TruYumContext();
        [Authorize]
        public ActionResult Index(bool IsAdmin)
        {
            if(IsAdmin)
            { 
            var list = db.MenuItems.ToList();
            return View(list);
            }
            else
            {
                return RedirectToAction("CustomerIndex");
            }
        }
        [Authorize]
        public ActionResult CustomerIndex()
        {
            var list = db.MenuItems.ToList();
            return View(list);
        }
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            return View();
        }
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Category = new SelectList(db.Categories.ToList(), "Id", "Name");
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                db.MenuItems.Add(menuItem);
                db.SaveChanges();
                return RedirectToAction("Index",new { IsAdmin = true });
            }
            else
            {
                return View();
            }
        }
        [Authorize]
        public ActionResult Edit(int? id)
        {
            MenuItem menuItem = null;
            if (id != null)
            {
                menuItem = db.MenuItems.Find(id);
                ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            }
            return View(menuItem);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(int? id,MenuItem menuItem)
        {

            if (ModelState.IsValid)
            {
                var list = db.MenuItems.Where(x => x.Id == id).ToList();
                list.ForEach(x =>
                {
                    x.Name = menuItem.Name;
                    x.Price = menuItem.Price;
                    x.FreeDelivery = menuItem.FreeDelivery;
                    x.Active = menuItem.Active;
                    x.CategoryId = menuItem.CategoryId;
                    x.DateOfLaunch = menuItem.DateOfLaunch;
                });
                db.SaveChanges();
                return RedirectToAction("Index", new { IsAdmin = true });
            }
            else
            {
                return RedirectToAction("CustomerIndex");
            }
        }
        [Authorize]
        public ActionResult Delete(int?  id)
        {
            MenuItem menuItem = null;
            if(id!=null)
            {
                menuItem = db.MenuItems.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(menuItem);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int? id, MenuItem menuItem)
        {

            if (id != null)
            {
                menuItem = db.MenuItems.Where(x => x.Id == id).FirstOrDefault();
            }
            db.MenuItems.Remove(menuItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        
    }
}