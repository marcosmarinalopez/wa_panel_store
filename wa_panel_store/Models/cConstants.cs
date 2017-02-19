using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wa_panel_store.Models
{
    public class cConstants
    {
        #region database settings

        public static string m_s_local_db_connection_string = "local_db_connection_string";
        public static string m_s_connection_string = System.Configuration.ConfigurationManager.ConnectionStrings[cConstants.m_s_local_db_connection_string].ConnectionString;
        public static wcl_db_adapter.cDBMySQLAdapter sta_c_db = null;
        #endregion

        #region MySQL adapter settings

        public static int m_i_timeout = 6000;

        #endregion

        #region schemas

        public static string m_s_schema__panel_web = "panel_web";

        #endregion


        #region tables

        public static string m_s_table__log_user = "log_user";
        public static string m_s_table__panels = "panels";
        public static string m_s_table__filters = "filters";
        public static string m_s_table__users = "users";

        #endregion


        #region table log_user
                
        public static string m_s_field__user_log_in = "user_log_in";
        public static string m_s_field__user_log_out = "user_log_out";

        #endregion

        #region table users

        public static string m_s_field__user_id = "user_id";
        public static string m_s_field__user_alias = "user_alias";
        public static string m_s_field__user_name = "user_name";
        public static string m_s_field__user_surname = "user_surname";
        public static string m_s_field__user_company = "user_company";

        public static string m_s_field__user_email = "user_email";
        public static string m_s_field__user_password = "user_password";
        public static string m_s_field__user_sign_up = "user_sign_up";        

        #endregion

        #region table panels
        
        public static string m_s_field__panel_id = "panel_id";
        public static string m_s_field__panel_name = "panel_name";
        public static string m_s_field__panel_company_id = "panel_company_id";
        public static string m_s_field__panel_company_desc = "panel_company_desc";
        public static string m_s_field__panel_latitude = "panel_latitude";
        public static string m_s_field__panel_longitude = "panel_longitude";
        public static string m_s_field__panel_location = "panel_location";

        public static string m_s_field__panel_address = "panel_address";
        public static string m_s_field__panel_street = "panel_street";
        public static string m_s_field__panel_sub_place = "panel_sub_place";
        public static string m_s_field__panel_main_place = "panel_main_place";
        public static string m_s_field__panel_province = "panel_province";
        public static string m_s_field__panel_country = "panel_country";
        public static string m_s_field__panel_country_code = "panel_country_code";
        public static string m_s_field__timestamp = "timestamp";


        #endregion

        #region table filters

        public static string m_s_field__filter__panel_field = "panel_field";
        public static string m_s_field__filter__filter_id = "filter_id";
        public static string m_s_field__filter__filter_desc = "filter_desc";
        public static string m_s_field__filter__filter_type = "filter_type";
        public static string m_s_field__filter__timestamp = "timestamp";

        #endregion

        #region anonymous_user
        public static string m_s__table__anonymous_user = "anonymous_user";
        public static string m_s__db_field__user_id = "user_id";
        public static string m_s__db_field__timestamp = "timestamp";

        #endregion

        #region queries

        public static string m_s_query__get_all_panels = "SELECT * FROM " + cConstants.m_s_table__panels;
        public static string m_s_query__get_filters = "SELECT * FROM " + cConstants.m_s_table__filters;
        public static string m_s_query__get_filtered_panels = "SELECT * FROM " + cConstants.m_s_table__panels + " WHERE ";

        #endregion

        #region Session Parameters
        public static string m_s_panel_manager_for_session = "panel_manager";
        public static string m_s_session_user = "UserID";
        #endregion
        public static wcl_db_adapter.cDBMySQLAdapter pb__get_MySQL_Adapter()
        {
            bool b_rc = true;

            try
            {
                if (sta_c_db == null)
                {
                    sta_c_db = new wcl_db_adapter.cDBMySQLAdapter(cConstants.m_s_connection_string);
                }

            }
            catch (Exception)
            {
                b_rc = false;
                sta_c_db = null;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return sta_c_db;
        }


        #region TEMPLATE FUNCTION
        private bool pr__()
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
        #endregion


        

    }
}