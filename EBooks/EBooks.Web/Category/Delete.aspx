<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="EBooks.Web.Category.Delete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Are you shure that you want to delete this category?</h3>
    <div>
        <div class="row">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="CategoryName" CssClass="col-md-2 control-label">CategoryName</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="CategoryName" CssClass="form-control" readonly="true"/>
                </div>
            </div>
        </div>
    </div>
    <div class="panel">
        <asp:Button ID="DeleteButton" runat="server" Text="Delete" CssClass="btn btn-primary" OnClick="DeleteButton_Click" />
        <asp:Button ID="CancelButton" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="CancelButton_Click" />
        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Category/Index.aspx" runat="server">Back</asp:HyperLink>
    </div>
</asp:Content>
