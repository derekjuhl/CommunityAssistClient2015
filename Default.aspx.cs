using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    CommunityServicesReference.CAServiceClient csr = new CommunityServicesReference.CAServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        { 
            List<string> servicesList = csr.GetCommunityServices().ToList();
            DropDownList1.DataSource = servicesList;
            DropDownList1.DataBind();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string serv = DropDownList1.SelectedItem.Text;
        List<CommunityServicesReference.ServiceGrant> grants = csr.GetGrants(serv).ToList();
        GridView1.DataSource = grants;
        GridView1.DataBind();
    }
}