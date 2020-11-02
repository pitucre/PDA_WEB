using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CCT.DAL;

namespace FixedAssetBarcodeScanProject.Web
{
    public partial class EmployeeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String sql = "SELECT FANUMB,FAAAID,FADL01,FAACL1,FAACL2,FAAN8,FAASID,FAEQST,FAKITL,FALOC,FAXMCU,FARMK,FARMK2,FAUPMJ,FAUPMT FROM F1201 WHERE FACO='08190' ORDER BY FANUMB"; //"SELECT DRKY,DRDL01 FROM F0005 WHERE DRSY='12' AND DRRT='ES'";
            //String sql = "SELECT * FROM F1202";
            //CCT.DAL.EMPLOYEEINFODal dal = new EMPLOYEEINFODal();
            DataSet ds = new DataSet() ;
            try
            {
                ds = DbHelperSQL.OracleExecuteDataset(sql, "F1201");
                gridView.DataSource = ds;
                //dal.DeleteAll();
                //for (int i = 0; i < ds.Tables["F0101"].Rows.Count; i++)
                //{
                //    DataRow dr = ds.Tables["F0101"].Rows[i];
                //    CCT.Model.EMPLOYEEINFOModel model = new CCT.Model.EMPLOYEEINFOModel();
                //    model.EMPLOYEECODE = dr["ABAN8"].ToString();
                //    model.EMPLOYEENAME = dr["ABALPH"].ToString();
                //    model.CCTEMPLOYEECODE = dr["ABALKY"].ToString();
                    
                //    dal.Add(model);
                //}
                
                gridView.DataBind();
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
    }
}