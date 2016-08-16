using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Reining.BussinessLogic;

namespace Reining.BussinessLogic
{
    public class MCateogryComponent
    {
        public DataTable SelectBySearch(string searchQuery)
        {
            MCateogryDAC mCDAC = new MCateogryDAC();

            return mCDAC.SelectBySearch(searchQuery);
        }
    }
}