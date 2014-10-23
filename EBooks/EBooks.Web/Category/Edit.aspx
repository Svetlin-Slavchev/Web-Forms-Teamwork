<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="EBooks.Web.Category.Edit" %>

<%@ Register Src="~/UserControls/CategorySearch.ascx" TagPrefix="uc1" TagName="CategorySearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:CategorySearch runat="server" ID="CategorySearch" />
        </div>
        <div class="col-md-9">
            <div class="row">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="CategoryName" CssClass="col-md-2 control-label">CategoryName</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="CategoryName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="CategoryName"
                            CssClass="text-danger" ErrorMessage="The user name field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="EditButton_Click"
                             Text="Edit" CssClass="btn btn-default" />
                    </div>
                </div>

                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Category/Index.aspx" runat="server">Back</asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>
