using System;
using System.Web.UI;
using System.ServiceModel;

namespace WebClient
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        readonly ServiceReference.ServiceClient wcf = new ServiceReference.ServiceClient("BasicHttpBinding_IService");
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Content/Js/jquery-3.2.1.min.js",
            });
            try
            {
                if (!IsPostBack)
                {
                    GridView1.DataSource = wcf.GetProviders();
                    GridView1.DataBind();
                }
            }
            catch (EndpointNotFoundException exc)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Host closed!')", true);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    wcf.NewProvider(TextBox1.Text);
                    GridView1.DataSource = wcf.GetProviders();
                    GridView1.DataBind();
                }
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Host closed!')", true);
            }
        }
    }
}