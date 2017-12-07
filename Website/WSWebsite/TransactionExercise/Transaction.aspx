﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Transaction.aspx.cs" Inherits="TransactionExercise_Transaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
   <h1 class="page-header">Employee Skill Registration</h1>
 
<div class="row">
    <asp:Panel ID="EmployeeInfoPanel" runat="server" CssClass="col-md-6" Visible="true">         
     <%-- AREA FOR TEXT BOXES / BUTTONS --%>
             <div class="row">
                <div class="col-sm-3"><asp:Label ID="EmployeeFirstName" runat="server" Text="First Name" AssociatedControlID="FirstName" /></div>
                <div class="col-sm-9"><asp:TextBox ID="FirstName" runat="server" Enabled="true" CssClass="form-control" /></div>
            </div>
            <div class="row">
                <div class="col-sm-3"><asp:Label ID="EmployeeLastName" runat="server" Text="Last Name" AssociatedControlID="LastName" /></div>
                <div class="col-sm-9"><asp:TextBox ID="LastName" runat="server" Enabled="true" CssClass="form-control" /></div>
            </div>
            <div class="row">
                <div class="col-sm-3"><asp:Label ID="EmployeeEmail" runat="server" Text="Email" AssociatedControlID="Email" /></div>
                <div class="col-sm-9"><asp:TextBox ID="Email" runat="server" Enabled="true" CssClass="form-control" /></div>
            </div>
            <asp:Button ID="Register" runat="server" Text="Register" />        
            <asp:Button ID="Clear" runat="server" Text="Clear" />         
        </asp:Panel>
</div>
    <%-- REQUIRES VALIDATION TO ENSURE FNAME LNAME AND PHONE ARE ENTERED AND SKILLS SELECTED --%>



    <%-- THIS AREA WILL BE FOR THE SKILL PANEL GENERATED BY LISTVIEW --%>




<div class="row">
     <asp:Panel ID="EmployeeSkillPanel" runat="server" CssClass="col-md-6" Visible="true">
        <div class="row">
            <asp:ListView ID="SkillLV" runat="server" DataSourceID="SkillLVODS">
                <EditItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="Skill" Mode="Edit" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="SkillID" Mode="Edit" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="Level" Mode="Edit" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="YOE" Mode="Edit" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="HourlyWage" Mode="Edit" runat="server" />
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" ValidationGroup="Insert" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="Skill" Mode="Insert" ValidationGroup="Insert" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="SkillID" Mode="Insert" ValidationGroup="Insert" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="Level" Mode="Insert" ValidationGroup="Insert" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="YOE" Mode="Insert" ValidationGroup="Insert" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="HourlyWage" Mode="Insert" ValidationGroup="Insert" runat="server" />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:DynamicControl DataField="Skill" Mode="ReadOnly" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="SkillID" Mode="ReadOnly" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="Level" Mode="ReadOnly" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="YOE" Mode="ReadOnly" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="HourlyWage" Mode="ReadOnly" runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" style="" border="0">
                                    <tr runat="server" style="">
                                        <th runat="server">Skill</th>
                                        <th runat="server">SkillID</th>
                                        <th runat="server">Level</th>
                                        <th runat="server">YOE</th>
                                        <th runat="server">HourlyWage</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style=""></td>
                        </tr>
                    </table>
                </LayoutTemplate>
</asp:ListView>
     

        </div>
    </asp:Panel>
</div>
<asp:ObjectDataSource ID="SkillLVODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Skills_List" TypeName="WorkSchedule.System.BLL.EmployeeSkillController"></asp:ObjectDataSource>


</asp:Content>

