using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Property_cls;
using System.Xml.Linq;
using System.Configuration;

namespace Property.Controls
{
    public partial class ExclusiveListing : System.Web.UI.UserControl
    {
        #region Global
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServiceDataBase"].ConnectionString.ToString());
        cls_Property clsobj = new cls_Property();

        int findex, lindex;
        public int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] != null)
                {
                    return Convert.ToInt32(ViewState["CurrentPage"]);
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["CurrentPage"] = value; }
        }

        #endregion Global
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                GetDreamHouseList();

            }
            if (Session["ListView"] == null )
            {
                Session["ListView"] = "ShowGrid";
            }
            if (Session["ListView"] == "ShowGrid")
            {
                //DivListSearch.Style.Add("display", "block");
                DivGridSearch.Style.Add("display", "none");
            }
             
        }
        #endregion PageLoad
        #region Pagination Repeater Events

        protected void RepeaterPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("newpage"))
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
                if (Convert.ToString(Session["SearchType"])== "Residential" || Convert.ToString(Session["QueryString"]) == "Residential")
                {
                    //SearchResidentialProperties();
                }
                else if (Convert.ToString(Session["SearchType"]) == "Commercial" || Convert.ToString(Session["QueryString"]) == "Commercial")
                {
                  //  SearchCommercialProperties();
                }
                else if (Convert.ToString(Session["SearchType"]) == "Condo" || Convert.ToString(Session["QueryString"]) == "Condo")
                {
                   // SearchCondoProperties();
                }
                else
                {
                   // SearchResidentialPropertiesListing();
                }
            }
        }
        protected void RepeaterPaging_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            LinkButton lnkPage = (LinkButton)e.Item.FindControl("Pagingbtn");

            if (lnkPage.CommandArgument.ToString() == CurrentPage.ToString())
            {
                lnkPage.Enabled = false;
                lnkPage.BackColor = System.Drawing.Color.FromName("#1e707e");
                lnkPage.ForeColor = System.Drawing.Color.FromName("#FFFFFF");
            }
        }

        #endregion Pagination Repeater Events

        

        #region Button Click's

        protected void lnkPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;

            if (Convert.ToString(Session["SearchType"]) == "Residential" || Convert.ToString(Session["QueryString"]) == "Residential")
            {
                //SearchResidentialProperties();
            }
            else if (Convert.ToString(Session["SearchType"]) == "Commercial" || Convert.ToString(Session["QueryString"]) == "Commercial")
            {
               // SearchCommercialProperties();
            }
            else if (Convert.ToString(Session["SearchType"]) == "Condo" || Convert.ToString(Session["QueryString"]) == "Condo")
            {
                //SearchCondoProperties();
            }
            else
            {
                //SearchResidentialPropertiesListing();
            }
        }

        protected void lnkNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            if (Convert.ToString(Session["SearchType"]) == "Residential" || Convert.ToString(Session["QueryString"]) == "Residential")
            {
                //SearchResidentialProperties();
            }
            else if (Convert.ToString(Session["SearchType"]) == "Commercial" || Convert.ToString(Session["QueryString"]) == "Commercial")
            {
               // SearchCommercialProperties();
            }
            else if (Convert.ToString(Session["SearchType"]) == "Condo" || Convert.ToString(Session["QueryString"]) == "Condo")
            {
                //SearchCondoProperties();
            }
            else
            {
                //SearchResidentialPropertiesListing();
            }
        }

        protected void lnkFirst_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;

            if (Convert.ToString(Session["SearchType"]) == "Residential" || Convert.ToString(Session["QueryString"]) == "Residential")
            {
                //SearchResidentialProperties();
            }
            else if (Convert.ToString(Session["SearchType"]) == "Commercial" || Convert.ToString(Session["QueryString"]) == "Commercial")
            {
               // SearchCommercialProperties();
            }
            else if (Convert.ToString(Session["SearchType"]) == "Condo" || Convert.ToString(Session["QueryString"]) == "Condo")
            {
               // SearchCondoProperties();
            }
            else
            {
                // Session["Municipality"] = Request.QueryString["Municipality"];
                //SearchResidentialPropertiesListing();
            }
        }

        protected void lnkLast_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["totpage"]) - 1);

            if (Convert.ToString(Session["SearchType"]) == "Residential" || Convert.ToString(Session["QueryString"]) == "Residential")
            {
                //SearchResidentialProperties();
            }
            else if (Convert.ToString(Session["SearchType"]) == "Commercial" || Convert.ToString(Session["QueryString"]) == "Commercial")
            {
               // SearchCommercialProperties();
            }
            else if (Convert.ToString(Session["SearchType"]) == "Condo" || Convert.ToString(Session["QueryString"]) == "Condo")
            {
                //SearchCondoProperties();
            }
            else
            {
                //SearchResidentialPropertiesListing();
            }
        }

        protected void btnGridView_Click(object sender, EventArgs e)
        {
            Session["ListView"] = "ShowGrid";
            //DivGridSearch.Style.Add("display", "block");
            //DivListSearch.Style.Add("display", "none");
        }

        protected void btnListView_Click(object sender, EventArgs e)
        {
            Session["ListView"] = "ShowList";
            //DivListSearch.Style.Add("display", "block");
            //DivGridSearch.Style.Add("display", "none");
        }
        #endregion Button Click's

        #region Pagination Method

        private void doPaging()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PageIndex");
            dt.Columns.Add("PageText");
            findex = CurrentPage - 5;
            if (CurrentPage > 5)
            {
                lindex = CurrentPage + 5;
            }
            else
            {
                lindex = 10;
            }
            if (lindex > Convert.ToInt32(ViewState["totpage"]))
            {
                lindex = Convert.ToInt32(ViewState["totpage"]);
                findex = lindex - 10;
            }

            if (findex < 0)
            {
                findex = 0;
            }
            for (int i = findex; i < lindex; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }
            RepeaterPaging.DataSource = dt;
            RepeaterPaging.DataBind();
        }

        #endregion Pagination Method

        #region Search methods
        void GetDreamHouseList()
        {          
          try
          {
              DataTable dt = clsobj.GetDreamHouseList();    
              if (dt.Rows.Count > 0)
              {
                              
                  dt.TableName = "ContactedUsers"; 
                  upSearch.Visible = true;
                  PagedDataSource pagedData = new PagedDataSource();
                  pagedData.DataSource = dt.DefaultView;
                  pagedData.AllowPaging = true;
                  pagedData.PageSize = 8;
                  pagedData.CurrentPageIndex = CurrentPage;
                  ViewState["totpage"] = pagedData.PageCount;
                  lnkPrevious.Visible = !pagedData.IsFirstPage;
                  lnkNext.Visible = !pagedData.IsLastPage;
                  lnkFirst.Visible = !pagedData.IsFirstPage;
                  lnkLast.Visible = !pagedData.IsLastPage;

                  rptSearchResults.DataSource = pagedData;
                  rptSearchResults.DataBind();
                  rptSearchResultList.DataSource = pagedData;
                  rptSearchResultList.DataBind();

                  doPaging();
                  RepeaterPaging.ItemStyle.HorizontalAlign = HorizontalAlign.Center;

                    
                }
                else
              {
                  resultSearch.Visible = true;
                  pagesLink.Visible = false;
                  resultSearch.Text = "Property is not available ";
                  //btnGridView.Visible = false;
                  //btnListView.Visible = false;
              }

          }
          catch (Exception ex)
          {

          }
          finally
          {

          }
        }
        


        
        #endregion Search Methods

    
    }
}