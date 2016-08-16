using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;
using Reining.BussinessLogic;

namespace Reining.BussinessLogic
{
    public class MemberDAC
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DataAccess"].ToString();
        string sqlAddQuery = @"
                             INSERT INTO MemberDetails 
                             (MemberNumber,
                             NRHANo,
                             FamilyName,
                             GivenName,
                             DateOfBirth,
                             StudName,
                             StreetNameResidence,
                             SuburbResidence,
                             State,
                             Postcode,
                             PhoneWork,
                             PhonePrivate,
                             PhoneMobile,
                             MemberTypeID,
                             DateMembershipPaid,
                             CurrentMember,
                             NonPro,
                             NRHA_USA,
                             emailaddress,
                             ValidUpto,
                             MCategoryID)
		                VALUES 
                            (@MemberNumber,
                            @NRHANo,
                            @FamilyName,
                            @GivenName,
                            @DateOfBirth,
                            @StudName,
                            @StreetNameResidence,
                            @SuburbResidence,
                            @State,
                            @Postcode,
                            @PhoneWork,
                            @PhonePrivate,
                            @PhoneMobile,
                            @MemberTypeID,
                            @DateMembershipPaid,
                            @CurrentMember,
                            @NonPro,
                            @NRHA_USA,
                            @emailaddress,
                            @ValidUpto,
                            @MCategoryID)";

        string sqlUpdateQuery = @"
		        UPDATE MemberDetails SET
                             [MemberNumber] =  @MemberNumber,                     
                             [NRHANo] = @NRHANo,
                             [FamilyName] = @FamilyName,
                             [GivenName] = @GivenName,
                             [DateOfBirth] = @DateOfBirth,
                             [StudName] = @StudName,
                             [StreetNameResidence] = @StreetNameResidence,
                             [SuburbResidence] = @SuburbResidence,
                             [State] = @State,
                             [Postcode] = @Postcode,
                             [PhoneWork] = @PhoneWork,
                             [PhonePrivate] = @PhonePrivate,
                             [PhoneMobile] = @PhoneMobile,
                             [MemberTypeID] = @MemberTypeID,
                             [DateMembershipPaid] = @DateMembershipPaid,
                             [CurrentMember] = @CurrentMember,
                             [NonPro] = @NonPro,
                             [NRHA_USA] = @NRHA_USA,
                             [emailaddress] = @emailaddress,
                             [ValidUpto] = @ValidUpto,
                             [MCategoryID] = @MCategoryID
                        WHERE
                            [MemberID] = @memberID";

        private string memberByPagingQuery(string searchQuery)
        {

            string sqlQuery = @"
                
                    SELECT 
                        [MemberID], 
                        [MemberNumber],
                        [NRHANo],
                        [FamilyName],
                        [GivenName],
                        ([GivenName] + ' '+  [FamilyName]) AS [Name],
                        [DateOfBirth],
                        ISNULL(CASE DateOfBirth WHEN '1753-01-01 00:00:00.000' THEN '' ELSE CONVERT(VARCHAR(10),DateOfBirth,103) END,'') AS [DateOfBirth1],
                        [StudName],
                        [StreetNameResidence],
                        [SuburbResidence],
                        [State],
                        [Postcode],
                        [PostalAddress1],
                        [PostalAddress2],
                        [PhoneWork],
                        [PhonePrivate],
                        [PhoneMobile],
                        [MemberTypeID],
                        (SELECT TOP 1 [MemberTypeDescription] FROM MemberType WHERE MemberType.ID = MemberDetails.MemberTypeID) AS [MemberTypeID_Desc],
                        [DateMembershipPaid],
                        ISNULL(CASE DateMembershipPaid WHEN '1753-01-01 00:00:00.000' THEN '' ELSE CONVERT(VARCHAR(10),DateOfBirth,103) END,'') AS [DateMembershipPaid1],
                        [CurrentMember],
                        [NonPro],
                        [NRHA_USA],
                        [emailaddress],
                        [ValidUpto],
                        ISNULL(CASE ValidUpto WHEN '1753-01-01 00:00:00.000' THEN '' ELSE CONVERT(VARCHAR(10),ValidUpto,103) END,'') AS [ValidUpto1],
                        [MCategoryID],
                        (SELECT TOP 1 [Category] FROM MembershipCateogry WHERE MembershipCateogry.MCategoryID = MemberDetails.MCategoryID) AS [CategoryName]
                    FROM 
	                    MemberDetails
                    WHERE 
	                    " + searchQuery;

            return sqlQuery;
        }
        public DataTable SelectByID(int memberID)
        {
            return SelectBySearch("MemberID = " + memberID);
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
        public void Insert(ref Member member)
        {
            SqlConnection Conn = null;

            try
            {
                Conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlAddQuery, Conn);
                cmd.Parameters.AddWithValue("@MemberNumber", member.memberNo);
                cmd.Parameters.AddWithValue("@NRHANo", member.nRHANo);
                cmd.Parameters.AddWithValue("@FamilyName", member.familyName);
                cmd.Parameters.AddWithValue("@GivenName", member.givenName);
                cmd.Parameters.AddWithValue("@DateOfBirth", member.dateOfBirth);
                cmd.Parameters.AddWithValue("@StudName", member.studName);
                cmd.Parameters.AddWithValue("@StreetNameResidence", member.streetNameResidence);
                cmd.Parameters.AddWithValue("@SuburbResidence", member.suburbResidence);
                cmd.Parameters.AddWithValue("@State", member.state);
                cmd.Parameters.AddWithValue("@Postcode", member.postcode);
                cmd.Parameters.AddWithValue("@PhoneWork", member.phoneWork);
                cmd.Parameters.AddWithValue("@PhonePrivate", member.phonePrivate);
                cmd.Parameters.AddWithValue("@PhoneMobile", member.phoneMobile);
                cmd.Parameters.AddWithValue("@MemberTypeID", member.memberTypeID);
                cmd.Parameters.AddWithValue("@DateMembershipPaid", member.dateMembershipPaid);
                cmd.Parameters.AddWithValue("@CurrentMember", member.currentMember);
                cmd.Parameters.AddWithValue("@NonPro", member.nonPro);
                cmd.Parameters.AddWithValue("@NRHA_USA", member.nRHA_USA);
                cmd.Parameters.AddWithValue("@emailaddress", member.emailaddress);
                cmd.Parameters.AddWithValue("@ValidUpto", member.validUpto);
                cmd.Parameters.AddWithValue("@MCategoryID", member.mCategoryID);

                Conn.Open();

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT @@IDENTITY";

                object oResult = cmd.ExecuteScalar();

                if (oResult != DBNull.Value)
                {
                    member.memberID = Convert.ToInt32(oResult);
                }
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
        
        public void Update(Member member, int memberID, ref int ret)
        {
            SqlConnection Conn = null;

            try
            {
                Conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlUpdateQuery, Conn);
                cmd.Parameters.AddWithValue("@MemberNumber", member.memberNo);
                cmd.Parameters.AddWithValue("@NRHANo",  member.nRHANo);
                cmd.Parameters.AddWithValue("@FamilyName",  member.familyName);
                cmd.Parameters.AddWithValue("@GivenName", member.givenName);
                cmd.Parameters.AddWithValue("@DateOfBirth", member.dateOfBirth);
                cmd.Parameters.AddWithValue("@StudName",  member.studName);
                cmd.Parameters.AddWithValue("@StreetNameResidence",  member.streetNameResidence);
                cmd.Parameters.AddWithValue("@SuburbResidence",  member.suburbResidence);
                cmd.Parameters.AddWithValue("@State",  member.state);
                cmd.Parameters.AddWithValue("@Postcode", member.postcode);
                cmd.Parameters.AddWithValue("@PhoneWork",  member.phoneWork);
                cmd.Parameters.AddWithValue("@PhonePrivate",  member.phonePrivate);
                cmd.Parameters.AddWithValue("@PhoneMobile",  member.phoneMobile);
                cmd.Parameters.AddWithValue("@MemberTypeID",  member.memberTypeID);
                cmd.Parameters.AddWithValue("@DateMembershipPaid",  member.dateMembershipPaid);
                cmd.Parameters.AddWithValue("@CurrentMember", member.currentMember);
                cmd.Parameters.AddWithValue("@NonPro",  member.nonPro);
                cmd.Parameters.AddWithValue("@NRHA_USA",  member.nRHA_USA);
                cmd.Parameters.AddWithValue("@emailaddress",  member.emailaddress);
                cmd.Parameters.AddWithValue("@ValidUpto",  member.validUpto);
                cmd.Parameters.AddWithValue("@MCategoryID",  member.mCategoryID);
                cmd.Parameters.AddWithValue("@memberID", memberID);
                Conn.Open();

                ret = cmd.ExecuteNonQuery();
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

        public void DeleteByID(int memberID)
        {
            string sqlDeleteQuery = @"
                DELETE 
                    MemberDetails 
                WHERE 
                    [MemberID] = " + memberID.ToString();

            SqlConnection Conn = null;

            try
            {
                Conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlDeleteQuery, Conn);
                Conn.Open();
                cmd.ExecuteNonQuery();
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