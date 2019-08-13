using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dyna.Areas.Analitic.Models.Marking;
using Dyna.Models.FileManager;
using Dyna.Models.ExcelManager;

namespace Dyna.Areas.Analitic.Controllers
{
    public class MarkingController : Controller, IFileManager
    {
        public string ControllerName
        {          
            get
            {
                return "Marking";
            }
        }

        public string AreaName
        {
            get
            {
                return new AnaliticAreaRegistration().AreaName;
            }
        }
        // GET: Analitic/Marking
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ResetDraft()
        {
            IEnumerable<DraftPins> result = MarkingCollection.WithDraft;
            return View(result);
        }

        [HttpPost]
        public ActionResult DropDraft()
        {
            ViewBag.Count = ExecuteMarking.DropDraft().ToString();
            //return RedirectToAction("ResetDraft");
            IEnumerable<DraftPins> result = MarkingCollection.WithDraft;
            
            return View("ResetDraft", result);
        }

        public ActionResult WriteDraft()
        {
            IEnumerable<CleanPins> result = MarkingCollection.WithoutDraft;

            return View(result);
        }

        [HttpPost]
        public ActionResult TextAreaLoadDraft(string incomingPins)
        {
            if (incomingPins != null)
            {
                MarkingCollection.IncomingPins = incomingPins;
            }           
            IEnumerable<CleanPins> result = MarkingCollection.WithoutDraft;
            return View("WriteDraft", result);
        }

        [HttpPost]
        public ActionResult FileLoadDraft(HttpPostedFileBase fileLoad)
        {
            if (fileLoad != null)
            {
                
                FileManager file = new FileManager(Server.MapPath("~/App_Data"), AreaName, ControllerName, fileLoad);
                file.Save();

                ExcelManager excel = new ExcelManager(file.FullPath, 1);
                excel.ReadAll();
                
                List<string> vs = new List<string>();
                foreach (var row in excel.Rows)
                {
                    if (row.Cell(1).Value.ToString().All(char.IsDigit))
                    {
                        vs.Add(row.Cell(1).Value.ToString());
                    }                  
                }
                excel.Dispose();
               
                MarkingCollection.IncomingPinsFile = vs.ToArray();
            }          
            IEnumerable<CleanPins> result = MarkingCollection.WithoutDraft;
            return View("WriteDraft", result);
        }

        [HttpPost]
        public ActionResult SetDraft()
        {
            ViewBag.Count = ExecuteMarking.SetDraft().ToString();
            //ViewBag.Count2 = ExecuteMarking.Test(MarkingModel.IncomingPins);
            IEnumerable<CleanPins> result = MarkingCollection.WithoutDraft;

            return View("WriteDraft", result);
        }

        public ActionResult ClearTable()
        {
            //MarkingCollection.IncomingPins = null;//"0"
            ExecuteMarking.SetNullVariables();
            IEnumerable<CleanPins> result = MarkingCollection.WithoutDraft;
            return View("WriteDraft", result);
        }
    }


}