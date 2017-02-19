using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wa_panel_store.Models;

namespace wa_panel_store.Controllers
{
    public class PanelStoreController : Controller
    {
        #region ATTRIBUTES

        private wa_panel_store.Models.cPanelManager m_c_panel_manager { get; set; }
        private wa_panel_store.Models.cUserManager m_c_user_manager { get; set; }
        private wa_panel_store.Models.cRegisterUser m_c_register_user { get; set; }
        private wcl_db_adapter.cDBMySQLAdapter m_c_db { get; set; }
        private DateTime m_dt_fixed_datetime { get; set; }

        #endregion

        #region PROPERTIES
        #endregion

        #region CONSTRUCTORS
        #endregion


        #region GET


        // GET: PanelStore
        [HttpGet]
        public ActionResult PanelStore()
        {
            bool b_rc = true;

            try
            {
                //System.Diagnostics.Debugger.Break();
                b_rc = b_rc && this.pr__get_all_panels();
                Session[cConstants.m_s_panel_manager_for_session] = this.m_c_panel_manager;                
            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return View(this.m_c_panel_manager);
        }
        public ActionResult RetrieveAllpanel(cPanelManager c_panel_manager)
        {
            bool b_rc = true;
            try
            {
                b_rc = b_rc && this.pr__get_all_panels();
                Session[cConstants.m_s_panel_manager_for_session] = this.m_c_panel_manager;

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return View(this.m_c_panel_manager);
        }

        // GET: PanelStore
        [HttpGet]
        public ActionResult AddPanelToCart(int i_id)
        {
            bool b_rc = true;

            try
            {
                this.m_c_panel_manager = (cPanelManager)Session[cConstants.m_s_panel_manager_for_session];
                this.m_c_panel_manager.p_c_selected_panel = this.m_c_panel_manager.p_lst_c_panels.Find(x => x.p_i_panel_id == i_id);
                b_rc = b_rc && this.pr__add_to_cart();
            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return View(this.m_c_panel_manager);
        }

        #endregion

        #region POST
        [HttpPost]
        public ActionResult PanelStore(cPanelManager panel_manager_POST)
        {
            bool b_rc = true;

            try
            {
                b_rc = b_rc && this.pr__show_filtrated_panels(panel_manager_POST);

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return View(this.m_c_panel_manager);
        }

      
        #endregion

        #region FUNCTIONS

        
        private bool pr__get_all_panels()
        {
            bool b_rc = true;

            try
            {
                //System.Diagnostics.Debugger.Break();
                b_rc = b_rc && this.pr__init();
                b_rc = b_rc && this.m_c_panel_manager.pb__get_all_panels();

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__init()
        {
            bool b_rc = true;

            try
            {
                //System.Diagnostics.Debugger.Break();
                this.m_c_panel_manager = new Models.cPanelManager(wa_panel_store.Models.cConstants.m_s_connection_string);
            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__get_filtered_panels()
        {
            bool b_rc = true;

            try
            {
                

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }


        private bool pr__show_filtrated_panels(cPanelManager c_panel_manager_POST)
        {
            bool b_rc = true;

            try
            {
                b_rc = b_rc && this.pr__init();
                List<cFilter> lst_filters = new List<Models.cFilter>();
                lst_filters = c_panel_manager_POST.p_lst_filters;
                this.m_c_panel_manager.pb__get_panels_for_view(lst_filters);

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__add_to_cart()
        {
            bool b_rc = true;

            try
            {
                if (this.m_c_panel_manager.p_c_selected_panel != null)
                {
                    b_rc = b_rc && this.pr__process_order();                    
                }

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__process_order()
        {
            bool b_rc = true;

            try
            {
                b_rc = b_rc && this.pr__check_if_there_is_a_register_user();
                

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;

        }
        private bool pr__check_if_there_is_a_register_user()
        {
            bool b_rc = true;

            try
            {
                if (Session[cConstants.m_s_session_user] == null)
                {
                    this.m_dt_fixed_datetime = DateTime.Now;
                    b_rc = b_rc && this.pr__init_db_adapter();
                    b_rc = b_rc && this.pr__set_new_anonymous_user();
                    b_rc = b_rc && this.pr__get_anonymous_user();                                        
                }

                b_rc = b_rc && this.pr__check_if_there_is_shop_order_available();

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__check_if_there_is_shop_order_available()
        {
            bool b_rc = true;

            try
            {
                //check order ID  Think about how to implement unique order an maintain it
                //if not => create one
                //add product to database and session

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }


        private bool pr__set_new_anonymous_user()
        {
            bool b_rc = true;
            bool b_no_valid_data = false;
            string s_insert = String.Empty;
            
            try
            {
                this.m_c_register_user = new Models.cRegisterUser();
                this.m_c_register_user.p_s_register_user_name = "anonymous" + DateTime.Now.ToString();
                this.m_c_register_user.p_b_is_registered = false;

                this.m_c_register_user.pb__register_user(this.m_c_db, ref b_no_valid_data);


                s_insert = "INSERT INTO " + cConstants.m_s__table__anonymous_user
                    + " (" + cConstants.m_s__db_field__user_id + ", " + cConstants.m_s__db_field__timestamp + ") VALUES ("
                    + " null, " + this.m_c_db.pb__get_date(this.m_dt_fixed_datetime) + " )";

                b_rc = b_rc && this.m_c_db.pb__insert(s_insert);
                this.m_c_db.pb__finish_transaction(b_rc);
            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__init_db_adapter()
        {
            bool b_rc = true;

            try
            {
                this.m_c_db = new wcl_db_adapter.cDBMySQLAdapter(cConstants.m_s_connection_string);
            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__get_anonymous_user()
        {
            bool b_rc = true;
            string s_select = String.Empty;
            List<wcl_db_adapter.cDBRow> lst_rows = null;

            try
            {
                s_select = "SELECT * FROM " + cConstants.m_s__table__anonymous_user
                    + " WHERE " + cConstants.m_s__db_field__timestamp + " = " + this.m_c_db.pb__get_date(this.m_dt_fixed_datetime);
                b_rc = b_rc && this.m_c_db.pb__query(s_select, ref lst_rows);

                if (lst_rows.Count == 1)
                {
                    Session[cConstants.m_s_session_user] = lst_rows[0].p_h_fields[cConstants.m_s__db_field__user_id].ToString();
                }
                else
                {
                    System.Diagnostics.Debugger.Break();
                }

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