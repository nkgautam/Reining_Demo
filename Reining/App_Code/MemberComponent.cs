using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Reining.BussinessLogic;

namespace Reining.BussinessLogic
{
    public  class MemberComponent
    {
       
        public Member Insert(Member member)
        {
            MemberDAC memberDAC = new MemberDAC();
            memberDAC.Insert(ref member);
            return member;
        }

       
        public int Update(Member member, int memberID)
        {
            MemberDAC memberDAC = new MemberDAC();
            int ret = -1;
            memberDAC.Update(member, memberID, ref ret);
            return ret;
        }

        public DataTable SelectBySearch(string searchQuery)
        {
            MemberDAC memberDAC = new MemberDAC();

            return memberDAC.SelectBySearch(searchQuery);
        }

        public void DeleteByID(int memberID)
        {
            MemberDAC memberDAC = new MemberDAC();
            memberDAC.DeleteByID(memberID);
        }
       
        public Member SelectByID(int memberID)
        {
            MemberDAC memberDAC = new MemberDAC();
            DataTable dataTable = memberDAC.SelectByID(memberID);
            Member obj = new Member();

            obj.memberID = Convert.ToInt32(dataTable.Rows[0]["MemberID"]);
            
            if (!DBNull.Value.Equals(dataTable.Rows[0]["MemberNumber"]))
                obj.memberNo = Convert.ToInt32(dataTable.Rows[0]["MemberNumber"]);

            if (!DBNull.Value.Equals(dataTable.Rows[0]["MemberTypeID"]))
                obj.memberTypeID = Convert.ToInt32(dataTable.Rows[0]["MemberTypeID"]);
            else
                obj.memberTypeID = 0;

            if (!DBNull.Value.Equals(dataTable.Rows[0]["MCategoryID"]))
                obj.mCategoryID = Convert.ToInt32(dataTable.Rows[0]["MCategoryID"]);
            else
                obj.mCategoryID = 0;

            obj.nonPro = Convert.ToBoolean(dataTable.Rows[0]["NonPro"]);
            obj.nRHA_USA = Convert.ToBoolean(dataTable.Rows[0]["NRHA_USA"]);
            obj.currentMember = Convert.ToBoolean(dataTable.Rows[0]["currentMember"]);
           
            obj.dateMembershipPaid = Convert.ToString(dataTable.Rows[0]["DateMembershipPaid"]);
          
            obj.dateOfBirth = Convert.ToString(dataTable.Rows[0]["DateOfBirth"]);
            obj.emailaddress = Convert.ToString(dataTable.Rows[0]["emailaddress"]);
            obj.familyName = Convert.ToString(dataTable.Rows[0]["FamilyName"]);
            obj.givenName = Convert.ToString(dataTable.Rows[0]["GivenName"]);
            obj.phoneMobile = Convert.ToString(dataTable.Rows[0]["PhoneMobile"]);
            obj.phonePrivate = Convert.ToString(dataTable.Rows[0]["phonePrivate"]);
            obj.phoneWork = Convert.ToString(dataTable.Rows[0]["phoneWork"]);
            obj.postcode = Convert.ToString(dataTable.Rows[0]["postcode"]);
            obj.state = Convert.ToString(dataTable.Rows[0]["State"]);
            obj.streetNameResidence = Convert.ToString(dataTable.Rows[0]["StreetNameResidence"]);
            obj.studName = Convert.ToString(dataTable.Rows[0]["StudName"]);
            obj.suburbResidence = Convert.ToString(dataTable.Rows[0]["SuburbResidence"]);
            obj.validUpto = Convert.ToString(dataTable.Rows[0]["ValidUpto"]);
           
            return obj;

        }
    }
}