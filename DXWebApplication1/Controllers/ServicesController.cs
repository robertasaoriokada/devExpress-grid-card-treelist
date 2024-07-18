using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        public ActionResult Index()
        {
            return View();
        }

        DXWebApplication1.Models.DbAp.Model1 db = new DXWebApplication1.Models.DbAp.Model1();

        [ValidateInput(false)]
        public ActionResult TreeListPartial()
        {
            var model = db.services;
            return PartialView("~/Views/Services/_TreeListPartial.cshtml", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TreeListPartialAddNew(DXWebApplication1.Models.DbAp.service item)
        {
            var model = db.services;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/Services/_TreeListPartial.cshtml", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TreeListPartialUpdate(DXWebApplication1.Models.DbAp.service item)
        {
            var model = db.services;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.IdService == item.IdService);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/Services/_TreeListPartial.cshtml", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TreeListPartialDelete(System.Int32 IdService)
        {
            var model = db.services;
            if (IdService >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.IdService == IdService);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("~/Views/Services/_TreeListPartial.cshtml", model.ToList());
        }
    }
}