using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wa_panel_store.Models
{
    public class cLocation
    {

        #region ATTRIBUTES

        private string m_s_location_name;
        private string m_s_location_desc;
        private bool m_b_location_selected;
        private string m_s_location_address;
        private string m_s_location_street;
        private string m_s_location_sub_place;
        private string m_s_location_main_place;
        private string m_s_location_province;
        private string m_s_location_country;
        private string m_s_location_country_code;
        private DateTime m_dt_timestamp;

        #endregion

        #region PROPERTIES

        public string p_s_location_name
        {
            get
            {
                return m_s_location_name;
            }

            set
            {
                m_s_location_name = value;
            }
        }

        public string p_s_location_desc
        {
            get
            {
                return m_s_location_desc;
            }

            set
            {
                m_s_location_desc = value;
            }
        }

        public bool p_b_location_selected
        {
            get
            {
                return m_b_location_selected;
            }

            set
            {
                m_b_location_selected = value;
            }
        }

        public string p_s_location_address
        {
            get
            {
                return m_s_location_address;
            }

            set
            {
                m_s_location_address = value;
            }
        }

        public string p_s_location_street
        {
            get
            {
                return m_s_location_street;
            }

            set
            {
                m_s_location_street = value;
            }
        }

        public string p_s_location_sub_place
        {
            get
            {
                return m_s_location_sub_place;
            }

            set
            {
                m_s_location_sub_place = value;
            }
        }

        public string p_s_location_main_place
        {
            get
            {
                return m_s_location_main_place;
            }

            set
            {
                m_s_location_main_place = value;
            }
        }

        public string p_s_location_province
        {
            get
            {
                return m_s_location_province;
            }

            set
            {
                m_s_location_province = value;
            }
        }

        public string p_s_location_country
        {
            get
            {
                return m_s_location_country;
            }

            set
            {
                m_s_location_country = value;
            }
        }

        public string p_s_location_country_code
        {
            get
            {
                return m_s_location_country_code;
            }

            set
            {
                m_s_location_country_code = value;
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
        public cLocation() { }
        public cLocation(cPanel c_panel)
        {
            bool b_rc = true;

            try
            {                
                this.m_b_location_selected = false;
                this.m_s_location_desc = c_panel.p_s_panel_location;
                this.m_s_location_name = c_panel.p_s_panel_location;
                this.m_s_location_address = c_panel.p_s_panel_address;
                this.m_s_location_street = c_panel.p_s_panel_street;
                this.m_s_location_sub_place = c_panel.p_s_panel_sub_place;
                this.m_s_location_main_place = c_panel.p_s_panel_main_place;
                this.m_s_location_province = c_panel.p_s_panel_province;
                this.m_s_location_country = c_panel.p_s_panel_country;
                this.m_s_location_country_code = c_panel.p_s_panel_country_code;
                this.m_dt_timestamp = c_panel.p_dt_timestamp;

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