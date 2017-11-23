<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="EmployeeSkillDirectory.aspx.vb" Inherits="Reporting_EmployeeSkillDirectory" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 class="page-header">Employee Skill Directory</h1>
    <div class="row">
        <div class="col-md-12">
            <rsweb:ReportViewer ID="EmployeeSkillDirectoryRV" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                <LocalReport ReportPath="Reporting\EmployeeSkillDirectory.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource Name="EmployeeSkillDirectoryDS" DataSourceId="EmployeeSkillDirectoryDS"></rsweb:ReportDataSource>
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
    </div>
    <asp:ObjectDataSource ID="EmployeeSkillDirectoryDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetEmployeeSkills" TypeName="WorkSchedule.System.BLL.EmployeeSkillController"></asp:ObjectDataSource>
</asp:Content>

