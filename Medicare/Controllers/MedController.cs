using Medicare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ClosedXML.Excel;


namespace Medicare.Controllers
{
    public class MedController : Controller
    {

        // GET: Med
        [HttpGet]
        public ActionResult Insert1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert1(Func a)
        {


            Func m = new Func();
            ViewBag.IsPost = true;
            m.Insert1(a);
            m.Getcred();
            return RedirectToAction("Insert2");


        }

        [HttpGet]
        public ActionResult Insert2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert2(Func a)
        {


            Func m = new Func();
            ViewBag.IsPost = true;
            m.Fetch(a);
            m.Insert2(a);
            return RedirectToAction("Insert3");

        }


        [HttpGet]
        public ActionResult Insert3()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert3(Func a)
        {


            Func m = new Func();
            ViewBag.IsPost = true;
            m.Fetch(a);
            m.Insert3(a);
            return RedirectToAction("Insert4");

        }

        [HttpGet]
        public ActionResult Insert4()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert4(Func a)
        {


            Func m = new Func();
            ViewBag.IsPost = true;
            m.Fetch(a);
            m.Insert4(a);

            return RedirectToAction("displayno");
        }
        [HttpGet]
        public ActionResult Admin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Admin(logincred admlogin)
        {
            if (ModelState.IsValid)

            {

                if (new adminlogin().ValidAdm(admlogin.username, admlogin.Password))
                {

                    Session["adminlogin"] = admlogin;
                    return RedirectToAction("Show");

                }
                else
                {
                    ViewBag.InvalidAdmin = "Not Authorized ! ";
                    return View();
                }
            }
            return View(admlogin);

            //return RedirectToAction("Show", "Med");
        }

        public ActionResult Show(string searchBy, string search)
        {
            if (Session["adminlogin"] != null)
            {
                Func a = new Func();
                List<Func> DataList = a.GetData(searchBy, search);
                return View(DataList);
            }
            return RedirectToAction("Admin");
        }

        public ActionResult Logout()
        {
            Session["adminlogin"] = null;
            return RedirectToAction("Admin");
        }
        public ActionResult Delete(Int64 id)
        {
            Func e = new Func();
            int emp = e.Delete(id);
            return RedirectToAction("Show");
        }
        public ActionResult Edit(Int64 id)
        {
            Func e = new Func();
            Func mark = e.GetSingleFunc(id);
            return View(mark);
        }
        [HttpPost]
        public ActionResult Edit(Func e)
        {
            if (ModelState.IsValid)
            {
                Func entity = new Func();

                int rowCount = entity.Update(e);
                return RedirectToAction("Edit");
            }
            return View(e);

        }
        public ActionResult displayno()
        {
            return View();
        }
        public ActionResult Export(Func a)
        {
            a.Export();
            return View();
        }
    }
}
