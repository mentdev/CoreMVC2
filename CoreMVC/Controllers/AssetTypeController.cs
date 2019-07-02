using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

using JsonRequestBehavior = System.Web.Mvc.JsonRequestBehavior;
namespace CoreMVC.Controllers
{
    public class AssetTypeController : Controller
    {
        private readonly BuildingDBContext db;

        public AssetTypeController(BuildingDBContext context)
        {
            db = context;
        }

        public ActionResult Index()
        {
            List<AssetType> listAst = db.AssetType.Select(x => new AssetType { AssetTypeName = x.AssetTypeName, AssetTypeId = x.AssetTypeId}).ToList();
            ViewBag.AssetTypeList = listAst;

            return View();
        }

        [HttpPost]
        public ActionResult Index(AssetType model)
        {
            try
            {
                if (model.AssetTypeId > 0)
                {
                    //update                    
                    AssetType ast = db.AssetType.SingleOrDefault(x => x.AssetTypeId == model.AssetTypeId);
                    ast.AssetTypeName = model.AssetTypeName;
                    db.SaveChanges();
                }
                else
                {
                    //Insert
                    AssetType ast = new AssetType();
                    ast.AssetTypeName = model.AssetTypeName;
                    db.AssetType.Add(ast);
                    db.SaveChanges();

                }
                return View(model);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ActionResult AddEditAssetType(int AssetTypeId)
        {            
            AssetType model = new AssetType();
            if (AssetTypeId > 0)
            {
                AssetType ast = db.AssetType.SingleOrDefault(x => x.AssetTypeId == AssetTypeId);
                model.AssetTypeId = ast.AssetTypeId;
                model.AssetTypeName = ast.AssetTypeName;
            }
            return PartialView("AddEdit", model);
        }

        /* public JsonResult DeleteAssetType(int AssetTypeId)
         {            
             bool result = false;
             AssetType ast = db.AssetType.SingleOrDefault(x =>  x.AssetTypeId == AssetTypeId);
             if (ast != null)
             {
                 db.AssetType.Remove(ast);
                 db.SaveChanges();
                 result = true;
             }

             return Json(result, JsonRequestBehavior.AllowGet);
         }*/
        public JsonResult DeleteAssetType(int AssetTypeId)
        {
            bool result = false;
            AssetType ast = db.AssetType.SingleOrDefault(x => x.AssetTypeId == AssetTypeId);
            if (ast != null)
            {
                db.AssetType.Remove(ast);
                db.SaveChanges();
                result = true;
            }

            return Json(result);
        }
    }
}
