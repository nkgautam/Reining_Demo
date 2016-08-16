using System;

namespace Reining.BussinessLogic
{
    public class Member
    {
        public int memberID { get; set; }
        public int nRHANo { get; set; }
        public int memberNo { get; set; }
        public string familyName { get; set; }
        public string givenName { get; set; }
        public string dateOfBirth { get; set; }
        public string studName { get; set; }
        public string streetNameResidence { get; set; }
        public string suburbResidence { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public string phoneWork { get; set; }
        public string phonePrivate { get; set; }
        public string phoneMobile { get; set; }
        public int memberTypeID { get; set; }
        public string dateMembershipPaid { get; set; }
        public bool currentMember { get; set; }
        public bool nonPro { get; set; }
        public bool nRHA_USA { get; set; }
        public string emailaddress { get; set; }
        public string validUpto { get; set; }
        public int mCategoryID { get; set; }

        public Member()
        {
        }
    }

}