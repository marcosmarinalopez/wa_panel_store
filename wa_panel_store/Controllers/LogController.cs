using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace wa_panel_store.Controllers
{
    public class LogController : Controller
    {
        #region CONSTANTS
        public static string s_sta_user_id = "UserID";
        public static string s_sta_user_alias = "UserAlias";
        public static string s_sta_user_name = "UserName";
        public static string s_sta_user_surname = "UserSurname";
        public static string s_sta_user_company = "UserCompany";
        public static string s_sta_user_email = "UserEmail";
        #endregion

        #region ATTRIBUTES
        private wcl_db_adapter.cDBMySQLAdapter m_c_db = null;
        private wa_panel_store.Models.cUserManager m_c_user_manager { get; set; }
        private wa_panel_store.Models.cRegisterUser m_c_register_user { get; set; }
        private wa_panel_store.Models.cUser m_c_user { get; set; }

        #endregion

        #region PROPERTIES
        #endregion

        #region CONSTRUCTORS

        public LogController()
        {
            try
            {
                this.m_c_db = wa_panel_store.Models.cConstants.pb__get_MySQL_Adapter();
            }
            catch (Exception)
            {
                System.Diagnostics.Debugger.Break();
            }
            finally { }
        }

        #endregion

        #region GET

        // GET: LogIn Page       
        [HttpGet]        
        public ActionResult LogInPage()
        {
            bool b_rc = true;
            try
            {
                if (Session[LogController.s_sta_user_email] == null)
                {
                    this.m_c_user = new Models.cUser();
                }                
            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return View(this.m_c_user);
        }

        // GET: Register Page
        [HttpGet]
        public ActionResult RegisterUser()
        {
            bool b_rc = true;

            try
            {
                if (Session[LogController.s_sta_user_email] == null)
                {
                    this.m_c_register_user = new Models.cRegisterUser();
                }                

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return View(this.m_c_register_user);
        }
        
        [HttpGet]
        public ActionResult ErrorRegisterUser()
        {
            return View(this.m_c_register_user);
        }

        //GET: Dashboard for current user
        [HttpGet]
        public ActionResult DashBoard()
        {
            bool b_rc = true;

            try
            {
                if (Session["UsedID"] != null)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return View();
        }

        //GET: Sign Out
        [HttpGet]
        public ActionResult LogOut()
        {
            bool b_rc = true;

            try
            {
                Session.Abandon();
            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region POST
        
        [HttpPost]
        public ActionResult LogInPage(wa_panel_store.Models.cUser c_user)
        {
            bool b_rc = true;
            bool b_user_is_valid = false;

            try
            {
                if (ModelState.IsValid)
                {
                    b_rc = b_rc && c_user.pb__is_user_valid(this.m_c_db, ref b_user_is_valid);

                    if (b_user_is_valid)
                    {
                        Session.Timeout = 15;
                        Session[LogController.s_sta_user_id] = c_user.p_i_user_id;
                        Session[LogController.s_sta_user_email] = c_user.p_s_user_email.ToString();
                        Session[LogController.s_sta_user_name] = c_user.p_s_user_name.ToString();
                        Session[LogController.s_sta_user_surname] = c_user.p_s_user_surname.ToString();
                        Session[LogController.s_sta_user_company] = c_user.p_s_user_company.ToString();
                        Session[LogController.s_sta_user_alias] = c_user.p_s_user_alias.ToString();
                        
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        //ModelState.AddModelError("","Error on auth");                        
                    }
                    this.m_c_user = c_user;
                }

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return View(this.m_c_user);
        }
        
        [HttpPost]
        public ActionResult RegisterUser(wa_panel_store.Models.cRegisterUser c_register_user)
        {
            bool b_rc = true;
            bool b_has_data = true;
            bool b_no_valid_data = false;

            try
            {
                b_rc = b_rc && c_register_user.pb__register_user(this.m_c_db, ref b_no_valid_data);

                if (!c_register_user.p_b_register_user_succesful)
                {
                    this.m_c_register_user = c_register_user;
                }
                else
                {
                    return RedirectToAction("LogInPage", "Log");
                }

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
           
            return View(this.m_c_register_user);
        }
        
        #endregion

        #region EVENTS
        #endregion

        #region FUNCTIONS

        #region public functions
        #endregion

        #region private functions
        #endregion

        #endregion

        #region TEMPLATE FUNCTION
        private bool pr__()
        {
            bool b_rc = true;

            try
            {
                System.Diagnostics.Debugger.Break();

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }
        #endregion

    }
}