using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wcl_db_adapter;

namespace wa_panel_store.Models
{
    public class cPanel
    {

        #region ATTRIBUTES
                
        private int m_i_panel_id;
        private string m_s_panel_name;
        private int m_i_panel_company_id;
        private string m_s_panel_company_desc;
        private double m_dl_panel_latitude;
        private double m_dl_panel_longitude;
        private string m_s_panel_location;

        private string m_s_panel_address;
        private string m_s_panel_street;
        private string m_s_panel_sub_place;
        private string m_s_panel_main_place;
        private string m_s_panel_province;
        private string m_s_panel_country;
        private string m_s_panel_country_code;
        private DateTime m_dt_timestamp;

        private wcl_db_adapter.cDBMySQLAdapter m_c_db = null;
        
        #endregion

        #region PROPERTIES

        //public string p_s_user_name
        //{
        //    get
        //    {
        //        return m_s_user_name;
        //    }

        //    set
        //    {
        //        m_s_user_name = value;
        //    }
        //}

        //public string p_s_user_surname
        //{
        //    get
        //    {
        //        return m_s_user_surname;
        //    }

        //    set
        //    {
        //        m_s_user_surname = value;
        //    }
        //}

        //public string p_s_user_company
        //{
        //    get
        //    {
        //        return m_s_user_company;
        //    }

        //    set
        //    {
        //        m_s_user_company = value;
        //    }
        //}

        //public string p_s_user_password
        //{
        //    get
        //    {
        //        return m_s_user_password;
        //    }

        //    set
        //    {
        //        m_s_user_password = value;
        //    }
        //}

        //public DateTime p_dt_user_sign_up
        //{
        //    get
        //    {
        //        return m_dt_user_sign_up;
        //    }

        //    set
        //    {
        //        m_dt_user_sign_up = value;
        //    }
        //}

        //public DateTime p_dt_user_log_in
        //{
        //    get
        //    {
        //        return m_dt_user_log_in;
        //    }

        //    set
        //    {
        //        m_dt_user_log_in = value;
        //    }
        //}

        //public DateTime p_dt_user_log_out
        //{
        //    get
        //    {
        //        return m_dt_user_log_out;
        //    }

        //    set
        //    {
        //        m_dt_user_log_out = value;
        //    }
        //}


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

        public int p_i_panel_id
        {
            get
            {
                return m_i_panel_id;
            }

            set
            {
                m_i_panel_id = value;
            }
        }

        public string p_s_panel_name
        {
            get
            {
                return m_s_panel_name;
            }

            set
            {
                m_s_panel_name = value;
            }
        }

        public int p_i_panel_company_id
        {
            get
            {
                return m_i_panel_company_id;
            }

            set
            {
                m_i_panel_company_id = value;
            }
        }

        public string p_s_panel_company_desc
        {
            get
            {
                return m_s_panel_company_desc;
            }

            set
            {
                m_s_panel_company_desc = value;
            }
        }

        public double p_dl_panel_latitude
        {
            get
            {
                return m_dl_panel_latitude;
            }

            set
            {
                m_dl_panel_latitude = value;
            }
        }

        public double p_dl_panel_longitude
        {
            get
            {
                return m_dl_panel_longitude;
            }

            set
            {
                m_dl_panel_longitude = value;
            }
        }

        public string p_s_panel_location
        {
            get
            {
                return m_s_panel_location;
            }

            set
            {
                m_s_panel_location = value;
            }
        }

        public string p_s_panel_address
        {
            get
            {
                return m_s_panel_address;
            }

            set
            {
                m_s_panel_address = value;
            }
        }

        public string p_s_panel_street
        {
            get
            {
                return m_s_panel_street;
            }

            set
            {
                m_s_panel_street = value;
            }
        }

        public string p_s_panel_sub_place
        {
            get
            {
                return m_s_panel_sub_place;
            }

            set
            {
                m_s_panel_sub_place = value;
            }
        }

        public string p_s_panel_sub_place1
        {
            get
            {
                return m_s_panel_sub_place;
            }

            set
            {
                m_s_panel_sub_place = value;
            }
        }

        public string p_s_panel_main_place
        {
            get
            {
                return m_s_panel_main_place;
            }

            set
            {
                m_s_panel_main_place = value;
            }
        }

        public string p_s_panel_province
        {
            get
            {
                return m_s_panel_province;
            }

            set
            {
                m_s_panel_province = value;
            }
        }

        public string p_s_panel_country
        {
            get
            {
                return m_s_panel_country;
            }

            set
            {
                m_s_panel_country = value;
            }
        }

        public string p_s_panel_country_code
        {
            get
            {
                return m_s_panel_country_code;
            }

            set
            {
                m_s_panel_country_code = value;
            }
        }

        public DateTime p_dt_timestamp
        {
            get
            {
                return m_dt_timestamp;
            }

            set
            {
                m_dt_timestamp = value;
            }
        }

        #endregion

        #region CONSTRUCTORS

        public cPanel()
        {
            bool b_rc = true;

            try
            {
                //System.Diagnostics.Debugger.Break();
                b_rc = b_rc && this.pr__init_db_adapter();

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
        }

        public cPanel(wcl_db_adapter.cDBMySQLAdapter db_adapter)
        {
            bool b_rc = true;

            try
            {
                //System.Diagnostics.Debugger.Break();
                b_rc = b_rc && this.pr__init_db_adapter(db_adapter);

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
        }

        public cPanel(wcl_db_adapter.cDBMySQLAdapter db_adapter, wcl_db_adapter.cDBRow c_row)
        {
            bool b_rc = true;

            try
            {
                //System.Diagnostics.Debugger.Break();
                b_rc = b_rc && this.pr__init_db_adapter(db_adapter);
                b_rc = b_rc && this.pr__read(c_row);


            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
        }

        #endregion

        #region EVENTS
        #endregion

        #region FUNCTIONS

        #region public functions

        public bool pb__read(wcl_db_adapter.cDBRow c_row)
        {
            bool b_rc = true;

            try
            {
                System.Diagnostics.Debugger.Break();
                b_rc = b_rc && this.pr__read(c_row);
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

        private bool pr__init_db_adapter()
        {
            bool b_rc = true;

            try
            {
                //System.Diagnostics.Debugger.Break();
                this.m_c_db = new cDBMySQLAdapter();
                this.m_c_db.p_i_timeout_seconds = cConstants.m_i_timeout;

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__init_db_adapter(wcl_db_adapter.cDBMySQLAdapter db_adapter)
        {
            bool b_rc = true;

            try
            {
                //System.Diagnostics.Debugger.Break();
                this.m_c_db = new cDBMySQLAdapter();
                this.m_c_db = db_adapter;
                this.m_c_db.p_i_timeout_seconds = cConstants.m_i_timeout;

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__read(wcl_db_adapter.cDBRow c_row)
        {
            bool b_rc = true;

            try
            {
                this.m_i_panel_id = Int32.Parse(c_row.p_h_fields[cConstants.m_s_field__panel_id].ToString());
                this.m_s_panel_name = c_row.p_h_fields[cConstants.m_s_field__panel_name].ToString();
                this.m_i_panel_company_id = Int32.Parse(c_row.p_h_fields[cConstants.m_s_field__panel_company_id].ToString());
                this.m_s_panel_company_desc = c_row.p_h_fields[cConstants.m_s_field__panel_company_desc].ToString();
                this.m_dl_panel_latitude = Double.Parse(c_row.p_h_fields[cConstants.m_s_field__panel_latitude].ToString());
                this.m_dl_panel_longitude = Double.Parse(c_row.p_h_fields[cConstants.m_s_field__panel_longitude].ToString());
                this.m_s_panel_location = c_row.p_h_fields[cConstants.m_s_field__panel_location].ToString();

                this.m_s_panel_address = c_row.p_h_fields[cConstants.m_s_field__panel_address].ToString();
                this.m_s_panel_street = c_row.p_h_fields[cConstants.m_s_field__panel_street].ToString();
                this.m_s_panel_sub_place = c_row.p_h_fields[cConstants.m_s_field__panel_sub_place].ToString();
                this.m_s_panel_main_place = c_row.p_h_fields[cConstants.m_s_field__panel_main_place].ToString();
                this.m_s_panel_province = c_row.p_h_fields[cConstants.m_s_field__panel_province].ToString();
                this.m_s_panel_country = c_row.p_h_fields[cConstants.m_s_field__panel_country].ToString();
                this.m_s_panel_country_code = c_row.p_h_fields[cConstants.m_s_field__panel_country_code].ToString();
                this.m_dt_timestamp =(DateTime) c_row.p_h_fields[cConstants.m_s_field__timestamp];

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