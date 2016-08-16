using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;
using Reining.BussinessLogic;

namespace Reining.BussinessLogic
{
    public class MCateogryDAC
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DataAccess"].ToString();

        private string memberByPagingQuery(string searchQuery)
        {

            string sqlQuery = @"
                
                    SELECT 
                        [MCategoryID], 
                        [MemberTypeID],
                        [Category],
                        [ValidFrom],
                        [ValidTo],
                        [Fee]
                    FROM 
	                    MembershipCateogry
                    WHERE 
	                    " + searchQuery;

            return sqlQuery;
        }
      
        public DataTable SelectBySearch(string searchQuery)
        {

            DataTable dTable = new DataTable();
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(memberByPagingQuery(searchQuery), Conn);
            sqlCmd.CommandType = System.Data.CommandType.Text;

            try
            {
                Conn.Open();
                dTable.Load(sqlCmd.ExecuteReader());
                return dTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }

        }
        
    }

}