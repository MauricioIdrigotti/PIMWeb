using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SildeBar.Models
{
    public class conncetion
    {
        private int errCode;
        private string errMsg;

        private SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataAdapter ad;

        public SqlConnection CN
        {
            get { return cn; }
            set { cn = value; }
        }
        public SqlCommand CMD
        {
            get { return cmd; }
            set { cmd = value; }
        }
        public SqlDataAdapter AD
        {
            get { return ad; }
            set { ad = value; }
        }
        public int ErrCode
        {
            get { return errCode; }
        }
        public string ErrMsg
        {
            get { return errMsg; }
        }

        public conncetion()
        {
            login();
        }
        private void login()
        {
            string server = "Winner";
            string db = "WEBDB";
            string user = "sa";
            string pass = "SAPB1Admin";

            string str = "Data Source="+server+";Initial Catalog="+db+";User ID="+user+";Password="+pass+";";

            try
            {
                CN = new SqlConnection(str);
                if (CN.State == System.Data.ConnectionState.Closed) CN.Open();

                if (CN.State == System.Data.ConnectionState.Open) errCode = 0;
                else { errCode = 9999;errMsg = "unknow"; }

            }catch(Exception ex)
            {
                errCode = ex.HResult;
                errMsg = ex.Message;
            }

        }
    }
}
