using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wa_panel_store.Models
{
    public class cCompany
    {

        #region ATTRIBUTES
        private string m_s_company_desc;
        private int m_i_company_id;
        private bool m_b_selected;

        #endregion

        #region PROPERTIES
        
        public string p_s_company_desc
        {
            get
            {
                return m_s_company_desc;
            }

            set
            {
                m_s_company_desc = value;
            }
        }

        public int p_i_company_id
        {
            get
            {
                return m_i_company_id;
            }

            set
            {
                m_i_company_id = value;
            }
        }

        public bool p_b_selected
        {
            get
            {
                return m_b_selected;
            }

            set
            {
                m_b_selected = value;
            }
        }

        #endregion

        #region CONSTRUCTORS

        public cCompany() { }

        public cCompany(wa_panel_store.Models.cPanel c_panel)
        {
            this.m_i_company_id = c_panel.p_i_panel_company_id;
            this.m_s_company_desc = c_panel.p_s_panel_company_desc;
            this.m_b_selected = false;
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
