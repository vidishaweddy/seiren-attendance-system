using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public partial class Browse : System.Web.UI.Page
{
    private OleDbConnection OleDB;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    public void Grid_Change(Object sender, DataGridPageChangedEventArgs e)
    {

        DataGridSLM.CurrentPageIndex = e.NewPageIndex;
        DataGridSLM.DataSource = CreateDataSource();
        DataGridSLM.DataBind();

    }
    String TableRFA()
    {

        return "SELECT ";
    }
    ICollection CreateDataSource()
    {
        OleDbCommand myCommand = new OleDbCommand();
        OleDB = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\WWWRoot\WEBApp\LicenseManagement\software license mgmt v3.0\client\client 3.05\slm.mdb;Mode=Share Deny None;Persist Security Info=False");
        OleDbDataAdapter da = new OleDbDataAdapter(TableRFA(), OleDB);
        //myCommand.CommandText = TableRFA();
        //myCommand.Connection = OleDB;
        DataTable dtView = new DataTable();
        OleDB.Open();
        da.Fill(dtView);
        DataView dv = new DataView(dtView);
        return dv;
        //return myCommand.ExecuteReader();

    }
}
