using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wa_panel_store.Models
{
    public class cFilter
    {
        #region ATTRIBUTES

        private string m_s_filter;
        private string m_s_filter_type;
        private bool m_b_filter_selected;
        private cFilterType m_c_filter_type;

        #endregion

        #region PROPERTIES

        public string p_s_filter
        {
            get
            {
                return m_s_filter;
            }

            set
            {
                m_s_filter = value;
            }
        }

        public bool p_b_filter_selected
        {
            get
            {
                return m_b_filter_selected;
            }

            set
            {
                m_b_filter_selected = value;
            }
        }

        public string p_s_filter_type
        {
            get
            {
                return m_s_filter_type;
            }

            set
            {
                m_s_filter_type = value;
            }
        }

        public cFilterType p_c_filter_type
        {
            get
            {
                return m_c_filter_type;
            }

            set
            {
                m_c_filter_type = value;
            }
        }

        #endregion

        #region CONSTRUCTORS

        public cFilter(){}

        public cFilter(wcl_db_adapter.cDBRow c_row, cFilterType c_filter_type, string s_field)
        {
            bool b_rc = true;

            try
            {
                this.m_s_filter = c_row.p_h_fields[s_field].ToString();
                this.p_s_filter_type = c_filter_type.p_s_filter_type;
                this.m_c_filter_type = c_filter_type;
                this.p_b_filter_selected = false;

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