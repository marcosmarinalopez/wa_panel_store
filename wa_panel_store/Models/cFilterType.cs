using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wa_panel_store.Models
{
    public class cFilterType
    {

        #region ATTRIBUTES

        private string m_s_panel_field;
        private string m_s_filter_id;
        private string m_s_filter_desc;
        private string m_s_filter_type;
        private DateTime m_dt_timestamp;

        #endregion

        #region PROPERTIES

        public string p_s_panel_field
        {
            get
            {
                return m_s_panel_field;
            }

            set
            {
                m_s_panel_field = value;
            }
        }

        public string p_s_filter_id
        {
            get
            {
                return m_s_filter_id;
            }

            set
            {
                m_s_filter_id = value;
            }
        }

        public string p_s_filter_desc
        {
            get
            {
                return m_s_filter_desc;
            }

            set
            {
                m_s_filter_desc = value;
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

        public cFilterType() { }

        public cFilterType(wcl_db_adapter.cDBRow c_row)
        {
            bool b_rc = true;

            try
            {
                this.m_s_panel_field = c_row.p_h_fields[cConstants.m_s_field__filter__panel_field].ToString();
                this.m_s_filter_id = c_row.p_h_fields[cConstants.m_s_field__filter__filter_id].ToString();
                this.m_s_filter_desc = c_row.p_h_fields[cConstants.m_s_field__filter__filter_desc].ToString();
                this.m_s_filter_type = c_row.p_h_fields[cConstants.m_s_field__filter__filter_type].ToString();
                this.m_dt_timestamp = (DateTime)c_row.p_h_fields[cConstants.m_s_field__filter__timestamp];

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