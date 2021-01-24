using System;
using System.Web.UI;
using System.ServiceModel;

namespace WebClient
{
    public partial class WebForm1 : System.Web.UI.Page
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
                    GridView1.DataSource = wcf.GetInvoices();
                    GridView1.DataBind();

                    DropDownList1.DataSource = wcf.Providers();
                    DropDownList1.DataTextField = "Value";
                    DropDownList1.DataValueField = "Key";
                    DropDownList1.DataBind();
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
                    wcf.NewInvoice(Convert.ToDateTime(Date.Text), Convert.ToInt32(DropDownList1.SelectedValue), Convert.ToInt32(TextBox1.Text));
                    GridView1.DataSource = wcf.GetInvoices();
                    GridView1.DataBind();
                }
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Host closed!')", true);
            }

        }

        protected void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            try
            {
                args.IsValid = Convert.ToDouble(TextBox1.Text) > 0;
            }

            catch
            {
                args.IsValid = false;
            }
        }
    }
}