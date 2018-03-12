﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers; 

namespace ResearchManager.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return viewSignIn(Session["StaffPosition"]);
        }

        public ActionResult viewSignIn(object staffPos)
        {
            if (staffPos != null)
                return ControllerChange(null);
            return View("SignIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(Models.SignInData model)
        {
            var db = new Entities();

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    var usr = db.users.Where(u => u.Matric == model.userID.Trim()).First();

                    if (usr != null)
                    {
                        string ps = model.plntxtPass + usr.salt;
                        bool isCorrect = Crypto.VerifyHashedPassword(usr.hash, ps);

                        if (isCorrect)
                        {
                            Models.ActiveUser active = new Models.ActiveUser();

                            active.staffPosition = usr.staffPosition;
                            active.forename = usr.forename;
                            active.surname = usr.surname;
                            active.matric = usr.Matric;
                            active.email = usr.Email; 

                            return ControllerChange(active);
                        }
                    }
                }
            }
            catch
            {
            }
            ViewBag.Message = "Login Failed, Please Try Again";
            return View();
        }

        public RedirectToRouteResult ControllerChange(Models.ActiveUser active)
        {
            try
            {
                //Redirect user to appropriate page
                if (active.staffPosition == "Researcher")
                {
                    return RedirectToAction("Index", "Research", active);
                }
                else if (active.staffPosition == "RIS")
                {
                    return RedirectToAction("Index", "RIS", active);
                }
                else if (active.staffPosition == "Dean")
                {
                    return RedirectToAction("Index", "Dean", active);
                }
                else if (active.staffPosition == "AssociateDean")
                {
                    return RedirectToAction("Index", "Associate", active);
                }
                else
                {
                    return RedirectToAction("SignIn");
                }
            }
            catch
            {
                return RedirectToAction("SignIn"); 
            }
        } 
    }
    
}
