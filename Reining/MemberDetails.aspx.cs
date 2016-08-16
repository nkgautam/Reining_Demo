using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Reining.BussinessLogic;
using System.Globalization;


namespace Reining
{
    public partial class MemberDetails : System.Web.UI.Page
    {
        string strMemberID;
        Member objMember = new Member();
        MemberComponent objMC = new MemberComponent();
        public int MemberID
        {
            get 
            {
                int ReturnValue = 0;

                string strValue = Request.QueryString["MemberID"];

                int iParsedReturn;
                if (Int32.TryParse(strValue, out iParsedReturn))
                {
                    ReturnValue = iParsedReturn;
                }
                return ReturnValue;
                 
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                strMemberID = Request.QueryString["MemberID"];
                MCateogryComponent mCObject = new MCateogryComponent();
                ddlCategoryID.DataSource = mCObject.SelectBySearch("1 = 1");
                ddlCategoryID.DataBind();
                ddlCategoryID.Items.Insert(0, new ListItem(" -- select -- ", ""));

                MemberTypeComponent mTObject = new MemberTypeComponent();
                ddlMemberType.DataSource = mTObject.SelectBySearch("1 = 1");
                ddlMemberType.DataBind();
                ddlMemberType.Items.Insert(0, new ListItem(" -- select -- ", ""));

                if (strMemberID != null)
                {
                    btnAdd.Text = "Update";

                    objMember = objMC.SelectByID(Convert.ToInt32(strMemberID.Trim()));
                    txtDateOfBirth.Text = objMember.dateOfBirth.ToString();
                    txtEmail.Text = objMember.emailaddress;
                    txtFamilyName.Text = objMember.familyName;
                    txtGivenName.Text = objMember.givenName;
                    txtHPhone.Text = objMember.phonePrivate;
                    txtMemberNo.Text = objMember.memberNo.ToString();
                    txtMembershipPaid.Text = objMember.dateMembershipPaid.ToString();
                    txtMPhone.Text = objMember.phoneMobile;
                    txtMPostCode.Text = objMember.postcode;
                    txtMSuburb.Text = objMember.suburbResidence;
                    txtMValidUntil.Text = objMember.validUpto.ToString();
                    txtNRHANo.Text = objMember.nRHANo.ToString();
                    txtState.Text = objMember.state;
                    txtStreetNameResidence1.Text = objMember.streetNameResidence;
                    txtStudName.Text = objMember.studName;
                    txtWPhone.Text = objMember.phoneWork;
                    chkCurrentMember.Checked = objMember.currentMember;
                    chkNonPro.Checked = objMember.nonPro;
                    chkNRHA_USA.Checked = objMember.nRHA_USA;
                    ddlCategoryID.SelectedIndex = objMember.mCategoryID;
                    ddlMemberType.SelectedIndex = objMember.memberTypeID;
                }

            }
            lblError.Text = "";
            lblMessage.Text = "";

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
            try
            {
                objMember.dateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text.Trim()).ToString();
                if (Convert.ToDateTime(txtDateOfBirth.Text.Trim()) < (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue || Convert.ToDateTime(txtDateOfBirth.Text.Trim()) > (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue)
                {
                    lblError.Text = "Incorrect DOB value";
                    return; 
                }
            }
            catch (Exception )
            {
                lblError.Text = "Incorrect DOB value";
                return; 
            }

            objMember.emailaddress = txtEmail.Text ;
            objMember.familyName = txtFamilyName.Text;
            if (txtGivenName.Text == String.Empty)
            {
                lblError.Text = "Must Enter Name value";
                return;
            }
            objMember.givenName = txtGivenName.Text;

            objMember.phonePrivate = txtHPhone.Text;

            if (txtMemberNo.Text != String.Empty)
            {
                try
                {
                    objMember.memberNo = Convert.ToInt32(txtMemberNo.Text);
                }
                catch (Exception )
                {
                    lblError.Text = "Incorrect MemberNo value";
                    return;
                }
            }
            
            try
            {
                objMember.dateMembershipPaid = Convert.ToDateTime(txtMembershipPaid.Text.Trim()).ToString();
                if (Convert.ToDateTime(txtMembershipPaid.Text.Trim()) < (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue || Convert.ToDateTime(txtMembershipPaid.Text.Trim()) > (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue)
                {
                    lblError.Text = "Incorrect Membership Paid Date";
                    return;
                }
            }
            catch (Exception )
            {
                lblError.Text = "Incorrect Membership Paid Date";
                return;
            }
            
            objMember.phoneMobile = txtMPhone.Text;
            objMember.postcode = txtMPostCode.Text;
            objMember.suburbResidence = txtMSuburb.Text;
           
            try
            {
                objMember.validUpto = Convert.ToDateTime(txtMValidUntil.Text.Trim()).ToString();
                if (Convert.ToDateTime(txtMValidUntil.Text.Trim()) < (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue || Convert.ToDateTime(txtMValidUntil.Text.Trim()) > (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue)
                {
                    lblError.Text = "Incorrect valid Upto Date";
                    return;
                }
            }
            catch (Exception )
            {
                lblError.Text = "Incorrect valid Upto Date";
                return;
            }
            
            if (txtNRHANo.Text != String.Empty)
            {
                try
                {
                    objMember.nRHANo = Convert.ToInt32(txtNRHANo.Text);
                }
                catch (Exception )
                {
                    lblError.Text = "Incorrect NRHANo value";
                    return;
                }
            }

            objMember.state = txtState.Text;
            objMember.streetNameResidence = txtStreetNameResidence1.Text;
            objMember.studName = txtStudName.Text;
            objMember.phoneWork = txtWPhone.Text;
            objMember.currentMember = chkCurrentMember.Checked;
            objMember.nonPro = chkNonPro.Checked;
            objMember.nRHA_USA = chkNRHA_USA.Checked;
            if (ddlCategoryID.SelectedIndex == 0)
            {
                lblError.Text = "Select Category";
                return;
            }
            objMember.mCategoryID = ddlCategoryID.SelectedIndex;
            if (ddlMemberType.SelectedIndex == 0)
            {
                lblError.Text = "Select Member Type";
                return;
            }
            objMember.memberTypeID = ddlMemberType.SelectedIndex;

            if (btnAdd.Text == "Update")
            {
                int ret = objMC.Update(objMember, MemberID);
                if (ret == 1)
                {
                    lblMessage.Text = "Recored sucessfully updated!!!";
                }
            }

            if (btnAdd.Text == "Add")
            {
                objMC.Insert(objMember);
                if (objMember.memberID > 0)
                {
                    lblMessage.Text = "Recored Added sucessfully!!!";
                }
            }
                
        }
               
    }
}