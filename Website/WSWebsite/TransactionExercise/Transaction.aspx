<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Transaction.aspx.cs" Inherits="TransactionExercise_Transaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
   <h1 class="page-header">Employee Skill Registration</h1>
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

    <%-- THIS AREA WILL BE FOR THE SKILL PANEL --%>






</asp:Content>

