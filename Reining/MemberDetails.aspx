<%@ Page Title="Member" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberDetails.aspx.cs" Inherits="Reining.MemberDetails" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
     <script src="js/jquery-1.11.1.min.js" type="text/javascript"></script>

    <script src="js/jquery-ui.js" type="text/javascript"></script>

    <link href="js/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <script>
        $(function () {
            $("<%= txtDateOfBirth.ClientID %>").datepicker();
        });
    </script>
    
    <div >
            <p  align="right" style="padding-right:40px;"> 
                    <asp:Literal ID="ltErrors" runat ="server" Text=""></asp:Literal>
                    <asp:Label ID="lblErrors" runat ="server" Text ="Errors" Visible ="false" ForeColor ="Red" Font-Bold ="true" ></asp:Label>
                    </p>
             
                     
                        <table cellpadding="0" cellspacing="1" border="0"  width="100%" >
                           
                            <tr>
                                <td valign="top" >
                                    <table  cellpadding="0" cellspacing="1" border="0"  width="100%">
                                        <tr>
                                             <th  colspan="4">
                                   <b align="left"> Membership Information </b>
                                </th>
                                        </tr>
                                        <tr id="trMemberNo"  runat="server">
                                            <td >
                                                Member No. 
                                            </td>
                                            <td  colspan="3">
                                                <asp:TextBox ID="txtMemberNo" MaxLength="8" runat="server" Width="250"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="tr1"  runat="server">
                                            <td >
                                                NRHA No 
                                            </td>
                                            <td  colspan="3">
                                                <asp:TextBox ID="txtNRHANo" MaxLength="8" runat="server" Width="250"></asp:TextBox>
                                                
                                            </td>
                                        </tr>
                                        <tr id="tr3"  runat="server">
                                            <td >
                                                Name 
                                            </td>
                                            <td  colspan="3">
                                                <asp:TextBox ID="txtGivenName" MaxLength="20" runat="server" Width="250"></asp:TextBox>
                                               
                                            </td>
                                        </tr>
                                        <tr id="tr2"  runat="server">
                                            <td >
                                                Family Name 
                                            </td>
                                            <td  colspan="3">
                                                <asp:TextBox ID="txtFamilyName" MaxLength="20" runat="server" Width="250"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="tr5" runat="server">
                                            <td >
                                                Stud Name 
                                            </td>
                                            <td  colspan="3">
                                                <asp:TextBox ID="txtStudName" MaxLength="20" runat="server" Width="250"></asp:TextBox>
                                            </td>
                                        </tr>
                                        
                                        <tr id="tr4"  runat="server">
                                            <td >
                                                DOB 
                                            </td>
                                            <td  colspan="3">
                                                <asp:TextBox ID="txtDateOfBirth" MaxLength="10" runat="server" Width="250"></asp:TextBox>
                                            </td>
                                        </tr>

                                    <tr>
                                          <td >
                                                Member Type 
                                            </td>
                                            <td  colspan="3">
                                                <asp:DropDownList ID="ddlMemberType" DataTextField="MemberTypeDescription" DataValueField="ID" 
                                                    runat="server" Width="250">
                                                </asp:DropDownList>
                                            </td>
                                    </tr>
                                        <tr>
                                            <td >
                                                Membership Category 
                                            </td>
                                            <td  colspan="3">
                                                <asp:DropDownList ID="ddlCategoryID" DataTextField="Category"  DataValueField="MCategoryID"
                                                    runat="server"  Width="250">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr id="tr6"  runat="server">
                                            <td >
                                                Membership Paid 
                                            </td>
                                            <td  colspan="3">
                                                <asp:TextBox ID="txtMembershipPaid" CssClass="txtDate" MaxLength="10" runat="server" Width="250"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                Valid Until 
                                            </td>
                                           <td  colspan="3">
                                                <asp:TextBox ID="txtMValidUntil"   MaxLength="10" runat="server" Width="250"></asp:TextBox>
                                                    
                                            </td>
                                        </tr>
                                        <tr>
                                                <td >
                                                    Current Member 
                                                </td>
                                                <td  colspan="2">
                                                    <asp:CheckBox ID="chkCurrentMember" runat="server" Text="" 
                                                        TextAlign="Right" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td >
                                                    Non Pro :
                                                </td>
                                                <td  colspan="2">
                                                    <asp:CheckBox ID="chkNonPro" runat="server" Text="" 
                                                        TextAlign="Right" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td >
                                                    NRHA USA 
                                                </td>
                                                <td  colspan="2">
                                                    <asp:CheckBox ID="chkNRHA_USA" runat="server" Text="" 
                                                        TextAlign="Right" />
                                                </td>
                                            </tr>
                                                                                    
                                    </table>
                                </td>
                                <td valign="top">
                                    <table cellpadding="0" cellspacing="1" border="0"  width="100%">
                                        <tr>
                                            <th colspan="4">
                                                <b align="left">Contact Information</b>
                                            </th>
                                            <tr>
                                                <td >
                                                    Work  
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtWPhone" runat="server"   MaxLength="20" 
                                                        Width="250"></asp:TextBox>
                                                </td>
                                                </tr>
                                            <tr>
                                                <td >
                                                    Home  
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtHPhone" runat="server"   MaxLength="20" 
                                                        Width="250"></asp:TextBox>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td >
                                                    Mobile 
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtMPhone" runat="server"   MaxLength="20" 
                                                        Width="250"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td >
                                                    Email 
                                                </td>
                                                <td  colspan="3">
                                                    <asp:TextBox ID="txtEmail" runat="server"  MaxLength="100" 
                                                        Width="250"></asp:TextBox>
                                                    
                                                    <asp:Literal ID="ltSentEmail" runat="server" Text="Send Email" Visible="false"></asp:Literal>
                                                </td>
                                            </tr>
                                            
                                            
                                            <tr>
                                                <th class="header" colspan="2">
                                                    Mailing Address 
                                                </th>
                                               
                                            </tr>
                                            <tr>
                                                <td >
                                                    Street Name (Residence)
                                                </td>
                                                <td >
                                                    <asp:TextBox ID="txtStreetNameResidence1" runat="server"  MaxLength="50" Width="250"></asp:TextBox>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td >
                                                    Suburb
                                                </td>
                                                <td >
                                                    <asp:TextBox ID="txtMSuburb" runat="server"  
                                                        MaxLength="50" Width="250"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td >
                                                    State 
                                                </td>
                                                <td >
                                                    <asp:TextBox ID="txtState" runat="server"  
                                                        MaxLength="50" Width="250"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td >
                                                    Postcode 
                                                </td>
                                                <td >
                                                    <asp:TextBox ID="txtMPostCode" runat="server" CssClass="txtMPostCode" 
                                                        MaxLength="10" Width="250"></asp:TextBox>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td colspan="4">
                                                    <font color="blue">
                                                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                                    </font><font color="red">
                                                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                                    </font>
                                                </td>
                                            </tr>
                                        </tr>
                                        
                                    </table>
                                </td>
                            </tr>
                        </table>
                       
                        <p align="center">
                         <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"   />&nbsp;
                         <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="javascript:location.href='MemberList.aspx'; return false;" />
          
                        </p>

                         
              </div>
   
</asp:Content>

