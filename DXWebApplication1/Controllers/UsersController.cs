using DevExpress.Web.Mvc;
using DXWebApplication1.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {

            var model = UsersService.GetUsers();


            return PartialView("~/Views/Users/_GridViewPartial.cshtml", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(DXWebApplication1.Models.DbAp.user item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsersService.AddUsers(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = UsersService.GetUsers();
            return PartialView("~/Views/Users/_GridViewPartial.cshtml", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(DXWebApplication1.Models.DbAp.user item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsersService.UpdateUsers(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            var model = UsersService.GetUsers();

            return PartialView("~/Views/Users/_GridViewPartial.cshtml", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 userId)
        {
            if (userId >= 0)
            {
                try
                {
                    UsersService.DeleteUsers(userId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = UsersService.GetUsers();
            return PartialView("~/Views/Users/_GridViewPartial.cshtml", model.ToList());
        }


    }
}