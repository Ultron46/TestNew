using CsharpAssignment.BusinessEntities.ViewModels;
using CsharpAssignment.Business.Interfaces;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsharpAssignment.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerManager _customerManager;
        private ICityManager _cityManager;

        public CustomersController(ICustomerManager customerManager, ICityManager cityManager)
        {
            _customerManager = customerManager;
            _cityManager = cityManager;
        }

        [HttpGet]
        // GET: Customers
        public ActionResult Index(int? page)
        {
            List<CustomerViewModel> customerViews = _customerManager.GetAllCustomers();
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(customerViews.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> cities = _cityManager.GetAllCities().Select(x => new SelectListItem() { Text = x.Name, Value = x.id.ToString()}).ToList();
            ViewBag.cities = cities;
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel customer)
        {
            List<SelectListItem> cities = _cityManager.GetAllCities().Select(x => new SelectListItem() { Text = x.Name, Value = x.id.ToString() }).ToList();
            bool status = _customerManager.InsertCustomer(customer);
            if(status == false)
            {
                ViewBag.cities = cities;
                return View(customer);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<SelectListItem> cities = _cityManager.GetAllCities().Select(x => new SelectListItem() { Text = x.Name, Value = x.id.ToString() }).ToList();
            ViewBag.cities = cities;
            CustomerViewModel customer = _customerManager.GetCustomer(id);
            Session["City"] = customer.City;
            Session["CreateDate"] = customer.Create_Date;
            Session["Birthdate"] = customer.Birth_Date;
            ViewBag.cities = cities;
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel customer)
        {
            List<SelectListItem> cities = _cityManager.GetAllCities().Select(x => new SelectListItem() { Text = x.Name, Value = x.id.ToString() }).ToList();
            ViewBag.cities = cities;
            if (customer.City == null)
            {
                customer.City = Session["City"].ToString();
            }
            customer.Create_Date = Convert.ToDateTime(Session["CreateDate"]);
            customer.Update_Date = System.DateTime.Now;
            customer.Birth_Date = customer.Birth_Date ?? Convert.ToDateTime(Session["Birthdate"]);
            bool status = _customerManager.UpdateCustomer(customer);
            Session["Birthdate"] = null;
            Session["City"] = null;
            Session["CreateDate"] = null;
            if(status == false)
            {
                ViewBag.cities = cities;
                return View(customer);
            }
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public ActionResult DeleteAjax(int id)
        //{
        //    Customer c;
        //    using (CustomerDetailsEntities db = new CustomerDetailsEntities())
        //    {
        //        c = db.Customers.Find(id);

        //    }
        //    if (c == null)
        //    {
        //        return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    CustomerViewModel customer = new CustomerViewModel();
        //    using (CustomerDetailsEntities db = new CustomerDetailsEntities())
        //    {
        //        Customer c = db.Customers.Find(id);
        //        customer.id = c.id;
        //        customer.Name = c.Name;
        //        customer.Address_1 = c.Address_1;
        //        customer.Address_2 = c.Address_2;
        //        customer.City = c.City1.Name;
        //        customer.Country = c.Country;
        //        customer.Post_Code = c.Post_Code;
        //        customer.Email = c.Email;
        //        customer.Mobile = c.Mobile;
        //        customer.Birth_Date = c.Birth_Date;
        //        customer.Active = c.Active;
        //        customer.Create_Date = c.Create_Date;
        //        customer.Update_Date = c.Update_Date;
        //    }
        //    return View(customer);
        //}

        //[HttpPost]
        //public ActionResult DeleteConfirm(int id)
        //{
        //    using (CustomerDetailsEntities db = new CustomerDetailsEntities())
        //    {
        //        Customer c = db.Customers.Find(id);
        //        db.Customers.Remove(c);
        //        if (db.SaveChanges() > 0)
        //        {
        //            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //        }
        //        return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}