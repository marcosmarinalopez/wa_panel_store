using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wcl_db_adapter;


namespace wa_panel_store.Models
{
    public class cPanelManager 
    {
        #region ATTRIBUTES

        private wcl_db_adapter.cDBMySQLAdapter m_c_db;
        private List<cPanel> m_lst_c_panels;        
        private List<cCompany> m_lst_c_companies;
        private List<cLocation> m_lst_c_locations;
      
        private List<cFilterType> m_lst_filter_types;
        private List<cFilter> m_lst_filters;
        
        private cPanel m_c_selected_panel;
        #endregion

        #region PROPERTIES

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

        public List<cPanel> p_lst_c_panels
        {
            get
            {
                return m_lst_c_panels;
            }

            set
            {
                m_lst_c_panels = value;
            }
        }
                
        public List<cCompany> p_lst_c_companies
        {
            get
            {
                return m_lst_c_companies;
            }

            set
            {
                m_lst_c_companies = value;
            }
        }

        public List<cLocation> p_lst_c_locations
        {
            get
            {
                return m_lst_c_locations;
            }

            set
            {
                m_lst_c_locations = value;
            }
        }

        //public List<string> p_lst_main_places
        //{
        //    get
        //    {
        //        return m_lst_main_places;
        //    }

        //    set
        //    {
        //        m_lst_main_places = value;
        //    }
        //}

        //public List<string> p_lst_provinces
        //{
        //    get
        //    {
        //        return m_lst_provinces;
        //    }

        //    set
        //    {
        //        m_lst_provinces = value;
        //    }
        //}

        //public List<string> p_lst_countries
        //{
        //    get
        //    {
        //        return m_lst_countries;
        //    }

        //    set
        //    {
        //        m_lst_countries = value;
        //    }
        //}

        //public List<string> p_lst_companies
        //{
        //    get
        //    {
        //        return m_lst_companies;
        //    }

        //    set
        //    {
        //        m_lst_companies = value;
        //    }
        //}

        public List<cFilterType> p_lst_filter_types
        {
            get
            {
                return m_lst_filter_types;
            }

            set
            {
                m_lst_filter_types = value;
            }
        }

        public List<cFilter> p_lst_filters
        {
            get
            {
                return m_lst_filters;
            }

            set
            {
                m_lst_filters = value;
            }
        }

        public cPanel p_c_selected_panel
        {
            get
            {
                return m_c_selected_panel;
            }

            set
            {
                m_c_selected_panel = value;
            }
        }

        //public List<cPanel> p_lst_c_panels_for_view
        //{
        //    get
        //    {
        //        return m_lst_c_panels_for_view;
        //    }

        //    set
        //    {
        //        m_lst_c_panels_for_view = value;
        //    }
        //}

        //public List<cFilter> p_lst_selected_filters
        //{
        //    get
        //    {
        //        return m_lst_selected_filters;
        //    }

        //    set
        //    {
        //        m_lst_selected_filters = value;
        //    }
        //}

        #endregion

        #region CONSTRUCTORS

        public cPanelManager()
        {
            bool b_rc = true;

            try
            {
                //System.Diagnostics.Debugger.Break();
                b_rc = b_rc && this.pr__init_db_adapter();
                //b_rc = b_rc && this.pr__init_lst_panels();
                b_rc = b_rc && this.pr__init_lst(ref this.m_lst_c_panels);

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
        }

        public cPanelManager(wcl_db_adapter.cDBMySQLAdapter db_adapter)
        {
            bool b_rc = true;

            try
            {
                //System.Diagnostics.Debugger.Break();
                this.m_c_db = db_adapter;
                this.m_c_db.p_i_timeout_seconds = cConstants.m_i_timeout;
                //b_rc = b_rc && this.pr__init_lst_panels();
                b_rc = b_rc && this.pr__init_lst(ref this.m_lst_c_panels);

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
        }

        public cPanelManager(string s_connection_string)
        {
            bool b_rc = true;

            try
            {
                //System.Diagnostics.Debugger.Break();
                this.m_c_db = new cDBMySQLAdapter(s_connection_string);
                this.m_c_db.p_i_timeout_seconds = cConstants.m_i_timeout;
                //b_rc = b_rc && this.pr__init_lst_panels();
                b_rc = b_rc && this.pr__init_lst(ref this.m_lst_c_panels);
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

        public bool pb__get_all_panels()
        {
            bool b_rc = true;
            string s_query = String.Empty;

            try
            {
                //System.Diagnostics.Debugger.Break();
                b_rc = b_rc && this.pr__get_all_panels();
                b_rc = b_rc && this.pr__get_filters(s_query);

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        public bool pb__get_panels_for_view()
        {
            bool b_rc = true;
            string s_query = String.Empty;

            try
            {
                b_rc = b_rc && this.pr__get_selected_filters();
                //b_rc = b_rc && this.pr__filter_panels(ref s_query);
                b_rc = b_rc && this.pr__get_filters(s_query);

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        public bool pb__get_panels_for_view(List<cFilter> lst_filters)
        {
            bool b_rc = true;
            string s_query = String.Empty;

            try
            {
                b_rc = b_rc && this.pr__get_selected_filters();
                //b_rc = b_rc && this.pr__filter_panels(ref s_query);
                b_rc = b_rc && this.pr__get_filters(s_query);

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

        #region init lists

        private bool pr__init_lst(ref List<cPanel> lst_panels)
        {
            bool b_rc = true;

            try
            {
                if (lst_panels == null)
                {
                    lst_panels  = new List<cPanel>();
                }
                lst_panels.Clear();

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__init_lst(ref List<cCompany> lst_companies)
        {
            bool b_rc = true;

            try
            {
                if (lst_companies == null)
                {
                    lst_companies = new List<cCompany>();
                }
                lst_companies.Clear();

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__init_lst(ref List<cLocation> lst_locations)
        {
            bool b_rc = true;

            try
            {
                if (lst_locations == null)
                {
                    lst_locations = new List<cLocation>();
                }
                lst_locations.Clear();

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__init_lst(ref List<cFilter> lst_filter)
        {
            bool b_rc = true;

            try
            {
                if (lst_filter == null)
                {
                    lst_filter = new List<cFilter>();
                }
                lst_filter.Clear();

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__init_lst(ref List<cFilterType> lst_filter_type)
        {
            bool b_rc = true;

            try
            {
                if (lst_filter_type == null)
                {
                    lst_filter_type = new List<cFilterType>();
                }
                lst_filter_type.Clear();
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

        //private bool pr__init_lst_panels()
        //{
        //    bool b_rc = true;

        //    try
        //    {
        //        //System.Diagnostics.Debugger.Break();
        //        if (this.p_lst_c_panels == null)
        //        {
        //            this.p_lst_c_panels = new List<Models.cPanel>();
        //        }

        //        this.p_lst_c_panels.Clear();

        //    }
        //    catch (Exception)
        //    {
        //        b_rc = false;
        //        System.Diagnostics.Debugger.Break();
        //    }
        //    finally { }
        //    return b_rc;
        //}

        private bool pr__init_db_adapter()
        {
            bool b_rc = true;

            try
            {
                //System.Diagnostics.Debugger.Break();
                if (this.m_c_db == null)
                {
                    this.m_c_db = new cDBMySQLAdapter();
                    this.m_c_db.p_i_timeout_seconds = cConstants.m_i_timeout;
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

        private bool pr__read_panels(List<wcl_db_adapter.cDBRow> lst_panel_rows)
        {
            bool b_rc = true;

            try
            {                
                if (lst_panel_rows.Count > 0)
                {
                    //b_rc = b_rc && this.pr__init_lst_panels();
                    b_rc = b_rc && this.pr__init_lst(ref this.m_lst_c_panels);
                }

                foreach (wcl_db_adapter.cDBRow c_row in lst_panel_rows)
                {
                    cPanel c_panel = new cPanel(this.m_c_db, c_row);
                    this.p_lst_c_panels.Add(c_panel);
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


        private bool pr__get_all_panels()
        {
            bool b_rc = true;
            string s_query = String.Empty;
            List<wcl_db_adapter.cDBRow> lst_rows = null;

            try
            {
                //System.Diagnostics.Debugger.Break();
                s_query = cConstants.m_s_query__get_all_panels;
                b_rc = b_rc && this.m_c_db.pb__query(s_query, ref lst_rows);
                b_rc = b_rc && this.pr__read_panels(lst_rows);
            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        //private bool pr__get_all_companies()
        //{
        //    bool b_rc = true;

        //    try
        //    {
        //        //System.Diagnostics.Debugger.Break();
        //        if (this.m_lst_c_companies == null)
        //        {
        //            this.m_lst_c_companies = new List<cCompany>();
        //        }
        //        this.m_lst_c_companies.Clear();


        //        foreach (cPanel c_panel in this.p_lst_c_panels)
        //        {
        //            cCompany c_company = new cCompany(c_panel);
        //            if (!this.m_lst_c_companies.Contains(c_company))
        //            {
        //                this.m_lst_c_companies.Add(c_company);
        //            }

        //        }

        //    }
        //    catch (Exception)
        //    {
        //        b_rc = false;
        //        System.Diagnostics.Debugger.Break();
        //    }
        //    finally { }
        //    return b_rc;
        //}

        //private bool pr__get_all_locations()
        //{
        //    bool b_rc = true;

        //    try
        //    {
        //        //System.Diagnostics.Debugger.Break();
        //        if (this.m_lst_c_locations == null)
        //        {
        //            this.m_lst_c_locations = new List<cLocation>();
        //        }
        //        this.m_lst_c_locations.Clear();


        //        foreach (cPanel c_panel in this.p_lst_c_panels)
        //        {
        //            cLocation c_location = new cLocation(c_panel);
        //            if (!this.m_lst_c_locations.Contains(c_location))
        //            {
        //                this.m_lst_c_locations.Add(c_location);
        //            }

        //        }

        //    }
        //    catch (Exception)
        //    {
        //        b_rc = false;
        //        System.Diagnostics.Debugger.Break();
        //    }
        //    finally { }
        //    return b_rc;
        //}

        //private bool pr__get_distinct_companies()
        //{
        //    bool b_rc = true;

        //    try
        //    {
        //        if (this.m_lst_companies == null)
        //        {
        //            this.m_lst_companies = new List<string>();
        //        }
        //        this.m_lst_companies.Clear();

        //        foreach (cCompany c_company in this.m_lst_c_companies)
        //        {
        //            if (!this.m_lst_companies.Contains(c_company.p_s_company_desc))
        //            {
        //                this.m_lst_companies.Add(c_company.p_s_company_desc);
        //            }
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        b_rc = false;
        //        System.Diagnostics.Debugger.Break();
        //    }
        //    finally { }
        //    return b_rc;
        //}

        //private bool pr__get_distinct_main_places()
        //{
        //    bool b_rc = true;

        //    try
        //    {
        //        if (this.m_lst_main_places == null)
        //        {
        //            this.m_lst_main_places = new List<string>();
        //        }
        //        this.m_lst_main_places.Clear();

        //        foreach (cPanel c_panel in this.m_lst_c_panels)
        //        {
        //            if (!this.m_lst_main_places.Contains(c_panel.p_s_panel_main_place))
        //            {
        //                this.m_lst_main_places.Add(c_panel.p_s_panel_main_place);
        //            }
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        b_rc = false;
        //        System.Diagnostics.Debugger.Break();
        //    }
        //    finally { }
        //    return b_rc;
        //}

        //private bool pr__get_distinct_provinces()
        //{
        //    bool b_rc = true;

        //    try
        //    {
        //        if (this.m_lst_provinces == null)
        //        {
        //            this.m_lst_provinces = new List<string>();
        //        }
        //        this.m_lst_provinces.Clear();

        //        foreach (cPanel c_panel in this.m_lst_c_panels)
        //        {
        //            if (!this.m_lst_provinces.Contains(c_panel.p_s_panel_province))
        //            {
        //                this.m_lst_provinces.Add(c_panel.p_s_panel_province);
        //            }
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        b_rc = false;
        //        System.Diagnostics.Debugger.Break();
        //    }
        //    finally { }
        //    return b_rc;
        //}

        //private bool pr__get_distinct_countries()
        //{
        //    bool b_rc = true;

        //    try
        //    {
        //        if (this.m_lst_countries == null)
        //        {
        //            this.m_lst_countries = new List<string>();
        //        }
        //        this.m_lst_countries.Clear();

        //        foreach (cPanel c_panel in this.m_lst_c_panels)
        //        {
        //            if (!this.m_lst_countries.Contains(c_panel.p_s_panel_country))
        //            {
        //                this.m_lst_countries.Add(c_panel.p_s_panel_country);
        //            }
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        b_rc = false;
        //        System.Diagnostics.Debugger.Break();
        //    }
        //    finally { }
        //    return b_rc;
        //}


        private bool pr__get_filters(string s_query)
        {
            bool b_rc = true;

            try
            {
                b_rc = b_rc && this.pr__get_filter_types();
                b_rc = b_rc && this.pr__get_filters_for_display(s_query);

            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        private bool pr__get_filter_types()
        {
            bool b_rc = true;
            string s_query = String.Empty;
            List<wcl_db_adapter.cDBRow> lst_rows = null;

            try
            {
                b_rc = b_rc && this.pr__init_lst(ref this.m_lst_filter_types);
          
                s_query = cConstants.m_s_query__get_filters;
                b_rc = b_rc && this.m_c_db.pb__query(s_query, ref lst_rows);

                foreach (wcl_db_adapter.cDBRow c_row in lst_rows)
                {
                    cFilterType c_filter_type = new Models.cFilterType(c_row);
                    this.m_lst_filter_types.Add(c_filter_type);
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

        private bool pr__get_filters_for_display(string s_query)
        {
            bool b_rc = true;
            string s_query_original = String.Empty;
            List<wcl_db_adapter.cDBRow> lst_rows = null;

            try
            {
                s_query_original = s_query;
                b_rc = b_rc && this.pr__init_lst(ref this.m_lst_filters);

                foreach (cFilterType c_filter_type in this.m_lst_filter_types)
                {
                    if (s_query_original == String.Empty)
                    {
                        s_query = "SELECT " + c_filter_type.p_s_panel_field + " FROM " + cConstants.m_s_table__panels + " GROUP BY " + c_filter_type.p_s_panel_field;
                    }
                    else
                    {
                        s_query = s_query.Replace("*", c_filter_type.p_s_panel_field);
                        s_query += " GROUP BY " + c_filter_type.p_s_panel_field;
                    }
                    
                    b_rc = b_rc && this.m_c_db.pb__query(s_query, ref lst_rows);
                    
                    foreach (wcl_db_adapter.cDBRow c_row in lst_rows)
                    {
                        cFilter c_filter = new cFilter(c_row, c_filter_type, c_filter_type.p_s_panel_field);
                        this.m_lst_filters.Add(c_filter);
                    }   
                                     
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


        private bool pr__get_selected_filters()
        {
            bool b_rc = true;

            try
            {
                //b_rc = b_rc && this.pr__init_lst(ref this.m_lst_selected_filters);
                //this.m_lst_selected_filters = this.m_lst_filters.FindAll(x => x.p_b_filter_selected).ToList();
            }
            catch (Exception)
            {
                b_rc = false;
                System.Diagnostics.Debugger.Break();
            }
            finally { }
            return b_rc;
        }

        //private bool pr__filter_panels(ref string s_query)
        //{
        //    bool b_rc = true;
                        
        //    try
        //    {
        //        b_rc = b_rc && this.pr__init_lst(ref this.m_lst_c_panels_for_view);
                                
        //        this.m_lst_selected_filters = this.m_lst_selected_filters.OrderBy(x => x.p_c_filter_type.p_s_filter_type).ToList();

        //        b_rc = b_rc && this.pr__get_panel_filtered_query(ref s_query);

        //        b_rc = b_rc && this.pr__get_selected_panels(s_query);

        //    }
        //    catch (Exception)
        //    {
        //        b_rc = false;
        //        System.Diagnostics.Debugger.Break();
        //    }
        //    finally { }
        //    return b_rc;
        //}

        //private bool pr__get_panel_filtered_query(ref string s_query)
        //{
        //    bool b_rc = true;

        //    try
        //    {
        //        s_query = cConstants.m_s_query__get_filtered_panels;

        //        for (int i = 0; i < this.m_lst_selected_filters.Count; i++)
        //        {
        //            if (i != 0) { s_query += " OR "; }

        //            s_query += this.m_lst_selected_filters[i].p_c_filter_type.p_s_panel_field + " = " + this.m_lst_selected_filters[i].p_s_filter;
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        b_rc = false;
        //        System.Diagnostics.Debugger.Break();
        //    }
        //    finally { }
        //    return b_rc;
        //}

        //private bool pr__get_selected_panels(string s_query)
        //{
        //    bool b_rc = true;
        //    List<wcl_db_adapter.cDBRow> lst_rows = null;

        //    try
        //    {
        //        b_rc = b_rc && this.m_c_db.pb__query(s_query, ref lst_rows);

        //        foreach (wcl_db_adapter.cDBRow c_row in lst_rows)
        //        {
        //            cPanel c_panel = new cPanel(this.m_c_db, c_row);
        //            this.m_lst_c_panels_for_view.Add(c_panel);
        //        }
                    

        //    }
        //    catch (Exception)
        //    {
        //        b_rc = false;
        //        System.Diagnostics.Debugger.Break();
        //    }
        //    finally { }
        //    return b_rc;
        //}
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