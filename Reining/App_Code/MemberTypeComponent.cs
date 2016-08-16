using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Reining.BussinessLogic;

namespace Reining.BussinessLogic
{
    public class MemberTypeComponent
    {
        public DataTable SelectBySearch(string searchQuery)
        {
            MemberTypeDAC mTDAC = new MemberTypeDAC();

            return mTDAC.SelectBySearch(searchQuery);
        }
    }
}