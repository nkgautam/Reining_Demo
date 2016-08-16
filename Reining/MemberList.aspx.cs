using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Reining.BussinessLogic;

namespace Reining
{
    public partial class MemberList : System.Web.UI.Page
    {
        DataTable dataTable;
        public string searchQuery
        {
            get
            {
                string searchText = Request.QueryString["text"];
                string searchOption = Request.QueryString["field"];
                string searchState = Request.QueryString["state"];


                if (!IsPostBack)
                {
                    // if page is loaded first time then get value from queryString ('text')
                    searchText = Request.QueryString["text"];
                    txtSearch.Text = searchText;
                    ddlSearchField.SelectedValue = searchOption;
                    ddlState.SelectedValue = searchState;
                }
                else
                {

                    searchText = txtSearch.Text.Trim();

                    ddlState.SelectedValue = searchState;
                }

                // pass text value into sql database
                if(searchText != null)
                    searchText = searchText.Replace("'", "''");

                string _lChar = " LIKE '%";
                string _rChar = "%'";

                
                string strQuery = "";

                if (ddlSearchField.SelectedIndex == 0)
                    strQuery = @" (CAST([MemberID] AS VARCHAR(100)) " + _lChar + searchText + _rChar + @"  OR 
                               [NRHANo] " + _lChar + searchText + _rChar + @" OR 
                               CAST([MemberNumber] AS VARCHAR(100)) " + _lChar + searchText + _rChar + @" OR 
                               CAST([MemberTypeID] AS VARCHAR(100)) " + _lChar + searchText + _rChar + @" OR 
                               CAST([MCategoryID] AS VARCHAR(100)) " + _lChar + searchText + _rChar + @" OR 
                               [FamilyName] " + _lChar + searchText + _rChar + @" OR 
                               [GivenName] " + _lChar + searchText + _rChar + @" OR 
                                [DateOfBirth] " + _lChar + searchText + _rChar + @" OR 
                                [StudName] " + _lChar + searchText + _rChar + @" OR 
                                [StreetNameResidence] " + _lChar + searchText + _rChar + @" OR 
                                [SuburbResidence] " + _lChar + searchText + _rChar + @" OR 
                                [State] " + _lChar + searchText + _rChar + @" OR 
                                [Postcode] " + _lChar + searchText + _rChar + @" OR 
                                [PostalAddress1] " + _lChar + searchText + _rChar + @" OR 
                                [PostalAddress2] " + _lChar + searchText + _rChar + @" OR 
                                [PhoneWork] " + _lChar + searchText + _rChar + @" OR 
                                [PhonePrivate] " + _lChar + searchText + _rChar + @" OR 
                                [PhoneMobile] " + _lChar + searchText + _rChar + @" OR 
                                [DateMembershipPaid] " + _lChar + searchText + _rChar + @" OR 
                                [CurrentMember] " + _lChar + searchText + _rChar + @" OR 
                                [NonPro] " + _lChar + searchText + _rChar + @" OR 
                                [NRHA_USA] " + _lChar + searchText + _rChar + @" OR 
                                [emailaddress] " + _lChar + searchText + _rChar + @" OR 
                                [ValidUpto] " + _lChar + searchText + _rChar + @"  )";
                else if (ddlSearchField.SelectedIndex == 1)
                    strQuery = @" CAST([GivenName] AS VARCHAR(100)) " + _lChar + searchText + _rChar;
                

                if (ddlState.SelectedIndex > 0)
                    strQuery += " AND (State = '" + ddlState.SelectedValue + "')";

                // make a search query
                return (searchText == "" && ddlState.SelectedIndex <= 0) ? " 1 = 1 " : strQuery;
            }
        }

       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
            }
            PopulateData();
            lblMessage.Text = "";
           
        }

        private DataTable PopulateData()
        {

            MemberComponent mc = new MemberComponent();
            dataTable = mc.SelectBySearch(searchQuery);
           
            DataView view = new DataView(dataTable);
            
            Session["view"] = view;
            grdMember.DataSource = dataTable;
            grdMember.DataBind();

            return dataTable;
            
        }

        public string ToJs(string value)
        {
            return value.Replace("'", "\\'");
        }             

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberList.aspx?text=" + txtSearch.Text.Trim() + "&field=" + ddlSearchField.SelectedValue + "&state=" + ddlState.SelectedValue, true);
        }
        public SortDirection direction
        {
            get
            {
                if (ViewState["dState"] == null)
                {
                    ViewState["dState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dState"];
            }
            set
            { ViewState["dState"] = value; }
        }
        protected void grdMember_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortingDirection = string.Empty;
            if (direction == SortDirection.Ascending)
            {
                direction = SortDirection.Descending;
                sortingDirection = "Desc";
            }
            else
            {
                direction = SortDirection.Ascending;
                sortingDirection = "Asc";
            }
            
            DataView sortedView = new DataView(PopulateData());
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            Session["view"] = sortedView;
            grdMember.DataSource = sortedView;
            grdMember.DataBind();

        }              
       
        protected void grdMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var gView = sender as GridView;
                      
            gView.PageIndex = e.NewPageIndex;
            gView.DataSource = Session["view"];
            gView.DataBind();
        }
        protected void grdMember_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                MemberComponent mc = new MemberComponent();
                int memberId = Convert.ToInt32( e.CommandArgument.ToString());
                mc.DeleteByID(memberId);
                lblMessage.Text = "Record deleted successfully!!!";

                PopulateData();
            }
        }

        protected void grdMember_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //MemberComponent mc = new MemberComponent();
            //mc.DeleteByID(e.Values[0]);
        }

       

        
        

       
    }
}