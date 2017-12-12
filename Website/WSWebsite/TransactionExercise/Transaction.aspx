<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Transaction.aspx.cs" Inherits="TransactionExercise_Transaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
   <h1 class="page-header">Employee Skill Registration</h1>
 

    <%-- REQUIRES VALIDATION TO ENSURE FNAME LNAME AND PHONE ARE ENTERED AND SKILLS SELECTED --%>

<div class="row">
    <asp:Panel ID="EmployeeInfoPanel" runat="server" CssClass="col-md-6" Visible="true">         
        <fieldset>
            <asp:Label ID="Label6" runat="server" Text="First Name" AssociatedControlID="FirstName" />
            <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>           
            <asp:Label ID="Label7" runat="server" Text="Last Name" AssociatedControlID="LastName" />
            <asp:TextBox ID="LastName" runat="server"></asp:TextBox>                         
            <asp:Label ID="Label16" runat="server" Text="Phone" AssociatedControlID="Phone" />
            <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
        </fieldset>                           
        <%-- AREA FOR BUTTONS --%>
            <asp:Button ID="Register" runat="server" Text="Register" />        
            <asp:Button ID="Clear" runat="server" Text="Clear" />     
            <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>        
    
        </asp:Panel>
</div>
    <%-- THIS AREA WILL BE FOR THE SKILL PANEL IN A LISTVIEW --%>

<div class="row">
     <asp:Panel ID="EmployeeSkillPanel" runat="server" CssClass="col-md-6" Visible="true">
        <div class="row">
            <asp:ListView ID="newSkillsLV" runat="server" DataSourceID="SkillODS">
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" style="" border="0">
                                    <tr runat="server" style="">
                                        <th runat="server">Skill</th>>
                                        <th runat="server">SkillID</th>
                                        <th runat="server">Description</th>
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
                    <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:TextBox Text='<%# Bind("Skill") %>' runat="server" ID="SkillTextBox" /></td>
                        <td>
                            <asp:CheckBox ID="SkillCheckBox" runat="server" />
                            <asp:TextBox Text='<%# Bind("SkillID") %>' runat="server" ID="SkillIDTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("Description") %>' runat="server" ID="DescriptionTextBox" /></td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label Text='<%# Eval("Skill") %>' runat="server" ID="SkillLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("SkillID") %>' runat="server" ID="SkillIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Description") %>' runat="server" ID="DescriptionLabel" /></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:ListView ID="LevelLV" runat="server" DataSourceID="LevelODS">
                <InsertItemTemplate>
                        <td>
                            <asp:TextBox Text='<%# Bind("Level") %>' runat="server" ID="LevelTextBox" /></td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label Text='<%# Eval("Level") %>' runat="server" ID="LevelLabel" /></td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" style="" border="0">
                                    <tr runat="server" style="">
                                        <th runat="server">Level</th>
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
                <SelectedItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label Text='<%# Eval("Level") %>' runat="server" ID="LevelLabel" /></td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:ObjectDataSource ID="SkillODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Skills_List" TypeName="WorkSchedule.System.BLL.SkillsController"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="LevelODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListLevel" TypeName="WorkSchedule.System.BLL.EmployeeSkillController"></asp:ObjectDataSource>

            <asp:Label ID="Label1" runat="server" Text="YOE" AssociatedControlID="YOE" />
            <asp:TextBox ID="YOE" runat="server"></asp:TextBox>                         
            <asp:Label ID="Label2" runat="server" Text="HourlyWage" AssociatedControlID="HourlyWage" />
            <asp:TextBox ID="HourlyWage" runat="server"></asp:TextBox>















<%--            <asp:ListView ID="SkillsLV" runat="server" ItemType="WorkSchedule.Data.Entities.POCOs.SkillSet" OnItemCommand="SkillsListView_Command" OnLayoutCreated="SkillsListView_LayoutCreated" DataSourceID="SkillODS">
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" style="" border="0">
                                    <tr runat="server" style="">
                                        <th runat="server"></th>
                                        <th runat="server">Skill</th>
                                        <th runat="server">SkillID</th>
                                        <th runat="server">Description</th>
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
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# Bind("Skill") %>' runat="server" ID="SkillTextBox" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# Bind("SkillID") %>' runat="server" ID="SkillIDTextBox" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="LevelRadioButtonList" runat="server" RepeatDirection="Horizontal" DataValueField="Key"></asp:RadioButtonList>  
                            <asp:TextBox Text='<%# Bind("Level") %>' runat="server" ID="LevelRadioButton" />
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
                        </td>
                        <td>
                            <asp:Label ID="YOELabel" runat="server" AssociatedControlID="YOETextBox"></asp:Label>                           
                            <asp:TextBox Text='<%# Bind("YOE") %>' runat="server" ID="YOETextBox" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# Bind("HourlyWage") %>' runat="server" ID="HourlyWageTextBox" /></td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label Text='<%# Eval("Skill") %>' runat="server" ID="SkillLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("SkillID") %>' runat="server" ID="SkillIDLabel" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Eval("Level") %>' runat="server" ID="LevelLabel" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Eval("YOE") %>' runat="server" ID="YOELabel" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Eval("HourlyWage") %>' runat="server" ID="HourlyWageLabel" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:ObjectDataSource ID="SkillODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Skills_List" TypeName="WorkSchedule.System.BLL.SkillsController">
            </asp:ObjectDataSource>--%>
        </div>
</asp:Panel>
    </div>
</asp:Content>

