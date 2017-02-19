using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wcl_db_adapter;

namespace wa_panel_store.Models
{
    public class cUser
    {

        #region CONSTANTS
        public static string s_sta_user_id = "user_id";
        public static string s_sta_user_alias = "user_alias";
        public static string s_sta_user_name = "user_name";
        public static string s_sta_user_surname = "user_surname";
        public static string s_sta_user_company = "user_company";
        public static string s_sta_user_email = "user_email";
        public static string s_sta_user_password = "user_password";
        #endregion

        #region ATTRIBUTES

        private bool m_b_user_registered;
        private bool m_b_remember_me = false;

        private bool m_b_user_login_error = false;        

        private int m_i_user_id;

        private string m_s_user_alias;
        private string m_s_user_name;
        private string m_s_user_surname;        
        private string m_s_user_company;

        private string m_s_user_email;
        private string m_s_user_password;

        private wcl_db_adapter.cDBMySQLAdapter m_c_db = null;

        #endregion

        #region PROPERTIES


        public bool p_b_user_registered
        {
            get
            {
                return m_b_user_registered;
            }

            set
            {
                m_b_user_registered = value;
            }
        }

        public string p_s_user_alias
        {
            get
            {
                return m_s_user_alias;
            }

            set
            {
                m_s_user_alias = value;
            }
        }

        public string p_s_user_name
        {
            get
            {
                return m_s_user_name;
            }

            set
            {
                m_s_user_name = value;
            }
        }

        public string p_s_user_surname
        {
            get
            {
                return m_s_user_surname;
            }

            set
            {
                m_s_user_surname = value;
            }
        }

        public int p_i_user_id
        {
            get
            {
                return m_i_user_id;
            }

            set
            {
                m_i_user_id = value;
            }
        }

        public string p_s_user_company
        {
            get
            {
                return m_s_user_company;
            }

            set
            {
                m_s_user_company = value;
            }
        }


        public string p_s_user_email
        {
            get
            {
                return m_s_user_email;
            }

            set
            {
                m_s_user_email = value;
            }
        }

        public string p_s_user_password
        {
            get
            {
                return m_s_user_password;
            }

            set
            {
                m_s_user_password = value;
            }
        }

        public cDBMySQLAdapter p_c_db
        {
            get
            {
                return m_c_db;
            }

            set
            {
                m_c_db = value;
            }
        }

        public bool p_b_remember_me
        {
            get
            {
                return m_b_remember_me;
            }

            set
            {
                m_b_remember_me = value;
            }
        }

        public bool p_b_user_login_error
        {
            get
            {
                return m_b_user_login_error;
            }

            set
            {
                m_b_user_login_error = value;
            }
        }


        #endregion

        #region CONSTRUCTORS
        #endregion

        #region EVENTS
        #endregion

        #region FUNCTIONS

        #region public functions

        public bool pb__is_user_valid(wcl_db_adapter.cDBMySQLAdapter c_adapter, ref bool b_is_valid)
        {
            bool b_rc = true;
            string s_validation_query = String.Empty;
            List<wcl_db_adapter.cDBRow> lst_rows = null;

            try
            {
                this.m_c_db = c_adapter;

                s_validation_query = "SELECT * FROM " + cConstants.m_s_table__users
                    + " WHERE " + cConstants.m_s_field__user_email + " = " + this.m_c_db.pb__get_string(this.m_s_user_email)
                    + " AND " + cConstants.m_s_field__user_password + " = " + this.m_c_db.pb__get_string(this.m_s_user_password);

                b_rc = b_rc && this.m_c_db.pb__query(s_validation_query, ref lst_rows);

                if (lst_rows != null && lst_rows.Count == 1)
                {
                    b_is_valid = true;
                    this.m_b_user_login_error = false;
                    b_rc = b_rc && this.pr__read_user(lst_rows);
                }
                else
                {
                    b_is_valid = false;
                    this.m_b_user_login_error = true;
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

        public bool pb__set_user(wcl_db_adapter.cDBRow c_row)
        {
            bool b_rc = true;

            try
            {
                this.m_i_user_id = Int32.Parse(c_row.p_h_fields[cConstants.m_s_field__user_alias].ToString());

                this.m_s_user_alias = c_row.p_h_fields[cConstants.m_s_field__user_alias].ToString();
                this.m_s_user_name= c_row.p_h_fields[cConstants.m_s_field__user_name].ToString();
                this.m_s_user_surname = c_row.p_h_fields[cConstants.m_s_field__user_surname].ToString();
                this.m_s_user_company = c_row.p_h_fields[cConstants.m_s_field__user_company].ToString();

                this.m_s_user_email = c_row.p_h_fields[cConstants.m_s_field__user_email].ToString();
                this.m_s_user_password = c_row.p_h_fields[cConstants.m_s_field__user_password].ToString();

                this.m_b_user_registered = true;

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        public bool pb__set_guest()
        {
            bool b_rc = true;
            int i_guest_id = 0;

            try
            {
                b_rc = b_rc && this.pr__set_guest_id(ref i_guest_id);

                this.m_i_user_id = i_guest_id;

                this.m_s_user_alias = i_guest_id.ToString();
                this.m_s_user_name = i_guest_id.ToString();
                this.m_s_user_surname = i_guest_id.ToString();
                this.m_s_user_company = i_guest_id.ToString();

                this.m_s_user_email = i_guest_id.ToString();
                this.m_s_user_password = i_guest_id.ToString();

                this.m_b_user_registered = false;

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

        #region private functions

        private bool pr__set_guest_id(ref int i_guest_id)
        {
            bool b_rc = true;

            try
            {
                i_guest_id = Int32.Parse(DateTime.Now.Year.ToString()) +
                                   Int32.Parse(DateTime.Now.Month.ToString()) +
                                   Int32.Parse(DateTime.Now.Day.ToString()) +
                                   Int32.Parse(DateTime.Now.Hour.ToString()) +
                                   Int32.Parse(DateTime.Now.Minute.ToString()) +
                                   Int32.Parse(DateTime.Now.Second.ToString());
            }
            catch (Exception)
            {
                b_rc = false;
                i_guest_id = 0;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__read_user(List<wcl_db_adapter.cDBRow> lst_rows)
        {
            bool b_rc = true;
            wcl_db_adapter.cDBRow c_row = null;
            try
            {
                c_row = new cDBRow();
                c_row = lst_rows[0];

                this.m_i_user_id = Int32.Parse(c_row.p_h_fields[cUser.s_sta_user_id].ToString());
                this.m_s_user_alias = c_row.p_h_fields[cUser.s_sta_user_alias].ToString();
                this.m_s_user_name = c_row.p_h_fields[cUser.s_sta_user_name].ToString();
                this.m_s_user_surname = c_row.p_h_fields[cUser.s_sta_user_surname].ToString();
                this.m_s_user_company = c_row.p_h_fields[cUser.s_sta_user_company].ToString();
                this.m_s_user_email = c_row.p_h_fields[cUser.s_sta_user_email].ToString();
                this.m_s_user_password = c_row.p_h_fields[cUser.s_sta_user_password].ToString();

            }
            catch (Exception ex)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }
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