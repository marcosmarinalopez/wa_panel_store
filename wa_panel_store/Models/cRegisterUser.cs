using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wcl_db_adapter;

namespace wa_panel_store.Models
{
    public class cRegisterUser
    {

        #region ATTRIBUTES
                    
        private bool m_b_register_user_email__used = false;
        private bool m_b_register_user_succesful = false;
        private bool m_b_is_registered = false;

        private string m_s_register_user_alias;
        private string m_s_register_user_name;
        private string m_s_register_user_surname;
        private string m_s_register_user_company;
        private string m_s_register_user_email;
        private string m_s_register_user_password;
        

        private wcl_db_adapter.cDBMySQLAdapter m_c_db = null;


        #endregion

        #region PROPERTIES

        public string p_s_register_user_alias
        {
            get
            {
                return m_s_register_user_alias;
            }

            set
            {
                m_s_register_user_alias = value;
            }
        }

        public string p_s_register_user_name
        {
            get
            {
                return m_s_register_user_name;
            }

            set
            {
                m_s_register_user_name = value;
            }
        }

        public string p_s_register_user_surname
        {
            get
            {
                return m_s_register_user_surname;
            }

            set
            {
                m_s_register_user_surname = value;
            }
        }

        public string p_s_register_user_company
        {
            get
            {
                return m_s_register_user_company;
            }

            set
            {
                m_s_register_user_company = value;
            }
        }

        public string p_s_register_user_email
        {
            get
            {
                return m_s_register_user_email;
            }

            set
            {
                m_s_register_user_email = value;
            }
        }

        public string p_s_register_user_password
        {
            get
            {
                return m_s_register_user_password;
            }

            set
            {
                m_s_register_user_password = value;
            }
        }
            

        public bool p_b_register_user_email__used
        {
            get
            {
                return m_b_register_user_email__used;
            }

            set
            {
                m_b_register_user_email__used = value;
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

        public bool p_b_register_user_succesful
        {
            get
            {
                return m_b_register_user_succesful;
            }

            set
            {
                m_b_register_user_succesful = value;
            }
        }

        public bool p_b_is_registered
        {
            get
            {
                return m_b_is_registered;
            }

            set
            {
                m_b_is_registered = value;
            }
        }

        #endregion

        #region CONSTRUCTORS
        #endregion

        #region EVENTS
        #endregion

        #region FUNCTIONS


        public bool pb__register_user(wcl_db_adapter.cDBMySQLAdapter c_adapter, ref bool b_no_valid_data)
        {
            bool b_rc = true;
            bool b_has_data = true;

            try
            {
                this.m_c_db = c_adapter;

                b_rc = b_rc && this.pr__check_data(ref b_has_data);

                if (b_has_data)
                {
                    b_rc = b_rc && this.pr__check_if_there_is_another_user_in_db_yet(ref b_no_valid_data);
                }
                else
                {
                    b_no_valid_data = true;
                }

                b_rc = b_rc && this.pr__register_result(b_no_valid_data, b_rc);

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__check_data(ref bool b_has_data)
        {
            bool b_rc = true;

            try
            {
                b_has_data = b_has_data && this.pr__check_if_string_parameter_is_empty(this.m_s_register_user_alias, ref b_has_data);
                b_has_data = b_has_data && this.pr__check_if_string_parameter_is_empty(this.m_s_register_user_company, ref b_has_data);
                b_has_data = b_has_data && this.pr__check_if_string_parameter_is_empty(this.m_s_register_user_name, ref b_has_data);
                b_has_data = b_has_data && this.pr__check_if_string_parameter_is_empty(this.m_s_register_user_surname, ref b_has_data);
                b_has_data = b_has_data && this.pr__check_if_string_parameter_is_empty(this.m_s_register_user_email, ref b_has_data);
                b_has_data = b_has_data && this.pr__check_if_string_parameter_is_empty(this.m_s_register_user_password, ref b_has_data);

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__check_if_string_parameter_is_empty(string s_parameter, ref bool b_has_data)
        {
            bool b_rc = true;

            try
            {
                if (String.IsNullOrEmpty(s_parameter))
                {
                    b_has_data = false;
                }
                else
                {
                    b_has_data = true;
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

        private bool pr__check_if_there_is_another_user_in_db_yet(ref bool b_no_valid_data)
        {
            bool b_rc = true;
            string s_query = String.Empty;
            List<wcl_db_adapter.cDBRow> lst_rows = null;

            try
            {
                s_query = "SELECT * FROM " + wa_panel_store.Models.cConstants.m_s_table__users
                    + " WHERE " + wa_panel_store.Models.cConstants.m_s_field__user_email + " = " + this.m_c_db.pb__get_string(this.m_s_register_user_email);
                    //+ " AND " + wa_panel_store.Models.cConstants.m_s_field__user_password + " = " + this.m_c_db.pb__get_string(this.m_s_register_user_password);

                b_rc = b_rc && this.m_c_db.pb__query(s_query, ref lst_rows);

                if (lst_rows.Count > 0)
                {
                    b_no_valid_data = true;
                }
                else
                {
                    b_rc = b_rc && this.pr__register_user_into_db();
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

        private bool pr__register_user_into_db()
        {
            bool b_rc = true;
            string s_insert = String.Empty;

            try
            {
                b_rc = b_rc && this.pr__register_user_statement(ref s_insert);
                
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

        private bool pr__register_user_statement(ref string s_insert)
        {
            bool b_rc = true;
            int i_registered = 0;
            try
            {
                if (this.m_b_is_registered)
                {
                    i_registered = 1;
                }
                else
                {
                    i_registered = 0;
                }
                asd;
                s_insert = "INSERT INTO " + wa_panel_store.Models.cConstants.m_s_table__users
                    + "(user_id, user_alias, user_name, user_surname, user_company, user_email, user_password, user_sign_up) VALUES "
                    + "( null, "
                    + this.m_c_db.pb__get_string(this.m_s_register_user_alias) + ", "
                    + this.m_c_db.pb__get_string(this.m_s_register_user_name) + ", "
                    + this.m_c_db.pb__get_string(this.m_s_register_user_surname) + ", "
                    + this.m_c_db.pb__get_string(this.m_s_register_user_company) + ", "
                    + this.m_c_db.pb__get_string(this.m_s_register_user_email) + ", "
                    + this.m_c_db.pb__get_string(this.m_s_register_user_password) + ", "
                    + " null, " + i_registered
                    + " )"
                    ;
            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__register_result(bool b_no_valid_data, bool b_error)
        {
            bool b_rc = true;

            try
            {
                if (!b_error)
                {
                    //error al insertar
                }
                if (b_no_valid_data)
                {
                    //usuario ya registrado
                    this.m_b_register_user_email__used = true;
                    this.m_b_register_user_succesful = false;
                }
                else
                {
                    //registro exitoso
                    this.m_b_register_user_succesful = true;
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