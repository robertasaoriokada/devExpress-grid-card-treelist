using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class UsersCardsController : Controller
    {
        DXWebApplication1.Models.DbAp.Model1 db1 = new DXWebApplication1.Models.DbAp.Model1();

        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult CardViewPartial()
        {
            var model = db1.users;
            return PartialView("~/Views/UsersCards/_CardViewPartial.cshtml", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CardViewPartialAddNew(DXWebApplication1.Models.DbAp.user item)
        {
            var model = db1.users;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/UsersCards/_CardViewPartial.cshtml", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CardViewPartialUpdate(DXWebApplication1.Models.DbAp.user item)
        {
            var model = db1.users;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.userId == item.userId);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db1.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/UsersCards/_CardViewPartial.cshtml", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CardViewPartialDelete(System.Int32 userId)
        {
            var model = db1.users;
            if (userId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.userId == userId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("~/Views/UsersCards/_CardViewPartial.cshtml", model.ToList());
        }
    }
}