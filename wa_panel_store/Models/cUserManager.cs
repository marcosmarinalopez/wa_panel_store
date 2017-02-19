using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wa_panel_store.Models
{
    public class cUserManager
    {
        #region ATTRIBUTES

        private cUser m_c_user;

        public cUser p_c_user
        {
            get
            {
                return m_c_user;
            }

            set
            {
                m_c_user = value;
            }
        }

        #endregion

        #region PROPERTIES
        #endregion

        #region CONSTRUCTORS
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