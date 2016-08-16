<%@ Page Title="Member List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="Reining.MemberList" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<div >

                        <table cellpadding="0" cellspacing="1" border="0" class="table"  width="100%">
                            <tr>
                                <td >
                                    Search :
                                </td>
                                <td >
                                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                </td>
                                <td >
                                    Search Field :
                                </td>
                                <td >
                                    <asp:DropDownList ID="ddlSearchField" Width="100" runat="server">
                                        <asp:ListItem Value="0">All Fields</asp:ListItem>
                                        <asp:ListItem Value="1" Selected="True">Name</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="label-col">
                                     State:
                                </td>
                                <td >
                                    <asp:DropDownList ID="ddlState" 
                                        Width="60" runat="server">
                                        <asp:ListItem Text="..." Value="none"></asp:ListItem>
                                                        <asp:ListItem Text="NSW" Value="NSW"></asp:ListItem>
                                                        <asp:ListItem Text="QLD" Value="QLD"></asp:ListItem>
                                                        <asp:ListItem Text="SA" Value="SA"></asp:ListItem>
                                                        <asp:ListItem Text="VIC" Value="VIC"></asp:ListItem>
                                    </asp:DropDownList>
                                     
                                 </td>
                                    <td >
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                    </td>
                               
                            </tr>
                            <tr>
                                <td  colspan="7">
                                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                    <font color="red">
                                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label></font>
                                </td>
                            </tr>
                        </table>
                        <p align="right">
                            <a href="MemberDetails.aspx" title="Add New Member" class="add_new">Add New Member</a>
                        </p>

                        
            
            <asp:GridView ID ="grdMember" runat ="server" Width ="100%" 
            PageSize="25" AutoGenerateColumns="False"
            AllowSorting="True" BorderWidth="2px"  
            GridLines="Horizontal" CellPadding="3"
            CellSpacing="1" BorderStyle="Ridge" 
            AllowPaging="True" OnSorting="grdMember_Sorting" OnPageIndexChanging="grdMember_PageIndexChanging" OnRowCommand="grdMember_RowCommand" OnRowDeleting="grdMember_RowDeleting"  >
                <FooterStyle ForeColor="Black" 
               BackColor="#C6C3C6"></FooterStyle>
            <PagerStyle ForeColor="Black" HorizontalAlign="Right" 
               BackColor="#C6C3C6"></PagerStyle>
            <HeaderStyle ForeColor="#E7E7FF" Font-Bold="True" 
               BackColor="#4A3C8C"></HeaderStyle>
                <Columns>
                    <asp:TemplateField HeaderText="" >
                        <ItemTemplate>
                          <a title="Edit" style="font-size: small;" href='MemberDetails.aspx?MemberID=<%# Eval("MemberID") %>'>
                            Edit</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                      
                      <asp:TemplateField HeaderText="Member No." SortExpression="MemberNumber" >
                        <ItemTemplate>
                          <%# Eval("MemberNumber")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                      
                      <asp:TemplateField HeaderText="Name" SortExpression="FamilyName">
                        <ItemTemplate>
                          <%# Eval("Name") %>  
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DOB"  SortExpression="DateOfBirth" >
                        <ItemTemplate>
                          <%# Eval("DateOfBirth1")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="State"  SortExpression="State" >
                        <ItemTemplate>
                          <%# Eval("State")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                     
                     <asp:TemplateField HeaderText="Current&nbsp;Member"  SortExpression="CurrentMember" >
                        <ItemTemplate>
                          <%# Eval("CurrentMember")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    
                    <asp:TemplateField HeaderText="Member&nbsp;Type"  SortExpression="MemberTypeID" >
                        <ItemTemplate>
                          <%# Eval("MemberTypeID_Desc")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Category"  SortExpression="MCategoryID" >
                        <ItemTemplate>
                          <%# Eval("CategoryName")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="" >
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnDelete" CommandName="Delete" Font-Size="Small" CommandArgument='<%# Eval("MemberID") %>'
                            CausesValidation="false"
                              OnClientClick='<%# "return confirm(\"Are you sure you want to Delete this record? " + ToJs(Eval("Name").ToString() ) + "\");" %> '
                            ToolTip="Delete" runat="server"> Delete </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <EmptyDataTemplate>
                    <b>No records found!</b>
                </EmptyDataTemplate>
                                 
            </asp:GridView>

</div>    
    
</asp:Content>
