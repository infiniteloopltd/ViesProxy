using System;
using eu.europa.ec;
using Newtonsoft.Json;


public partial class viesproxy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var svc = new checkVatService();
        var countryCode = Request.QueryString["Country"];
        var vatNumber = Request.QueryString["VAT"];
        string name;
        string address;
        bool valid;
        svc.checkVat(ref countryCode, ref vatNumber, out valid, out name, out address);
        var data = new { name,  address};
        var output = JsonConvert.SerializeObject(data);
        Response.Write(output);
    }
}