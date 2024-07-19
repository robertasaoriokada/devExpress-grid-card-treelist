using DevExpress.Web.Mvc;
using DXWebApplication1.Models.DbAp;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

        [ValidateInput(false)]
        public ActionResult BatchEditingUpdateModel(MVCxTreeListBatchUpdateValues<service, int> updateValues)
        {
            foreach (var newNode in updateValues.InsertNodes)
            {
                InsertNodesRecursive(newNode, null, updateValues);
            }
            foreach (var post in updateValues.Update)
            {
                if (updateValues.IsValid(post))
                    UpdatePost(post, updateValues);
            }
            foreach (var postID in updateValues.DeleteKeys)
            {
                DeletePost(postID, updateValues);
            }
            var model = db.services;
            
            return PartialView("~/Views/Services/_TreeListPartial.cshtml", model.ToList());
        }
        protected void InsertNodesRecursive(MVCxTreeListNodeInfo<service> node, int? parentKey, MVCxTreeListBatchUpdateValues<service, int> updateValues)
        {
            if (updateValues.IsValid(node.DataItem))
            {
                try
                {
                    if (!node.DataItem.ParentKey.HasValue)
                        node.DataItem.ParentKey = parentKey;
                    db.services.Add(node.DataItem);
                    db.SaveChanges();
                    updateValues.SetInsertedNodeKey(node, node.DataItem.IdService);
                    foreach (var childNode in node.ChildNodes)
                    {
                        InsertNodesRecursive(childNode, node.DataItem.IdService, updateValues);
                    }
                }
                catch (Exception e)
                {
                    updateValues.SetErrorText(node, e.Message);
                }
            }
        }

        protected void UpdatePost(service post, MVCxTreeListBatchUpdateValues<service, int> updateValues)
        {
            try
            {
                db.services.AddOrUpdate(post);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                updateValues.SetErrorText(post, e.Message);
            }
        }
        protected void DeletePost(int postID, MVCxTreeListBatchUpdateValues<service, int> updateValues)
        {
            try
            {
                var model = db.services.FirstOrDefault(x => x.IdService == postID);

                if (model == null)
                {
                    updateValues.SetErrorText(postID, "Service not found");
                    return;
                }

                List<service> childServices = db.services.Where(post => post.ParentKey == postID).ToList();

               
                if (childServices.Any())
                {
                    foreach (var service in childServices)
                    {
                        DeletePost(service.IdService, updateValues);
                    }
                }

                
                db.services.Remove(model);

               
                db.SaveChanges();
            }
            catch (Exception e)
            {
                updateValues.SetErrorText(postID, e.Message);
            }
        }
    }
}