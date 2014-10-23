<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="EBooks.Web.Book.Delete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Are you shure that you want to delete this book?</h3>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="BookTitle" CssClass="col-md-2 control-label">Title</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="BookTitle" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="BookTitle"
                CssClass="text-danger" Display="Dynamic" ErrorMessage="The title is required." />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="SubTitle" CssClass="col-md-2 control-label">SubTitle</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="SubTitle" CssClass="form-control" />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Author" CssClass="col-md-2 control-label">Author</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="Author" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Author"
                CssClass="text-danger" Display="Dynamic" ErrorMessage="The author is required." />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Publisher" CssClass="col-md-2 control-label">Publisher</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="Publisher" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Publisher"
                CssClass="text-danger" Display="Dynamic" ErrorMessage="The publisher is required." />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label">Description</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="Description" CssClass="form-control" />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Pages" CssClass="col-md-2 control-label">Pages</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="Pages" CssClass="form-control" />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Year" CssClass="col-md-2 control-label">Year</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="Year" CssClass="form-control" />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="ISBN" CssClass="col-md-2 control-label">ISBN</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="ISBN" CssClass="form-control" />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="CategoryDropDown" CssClass="col-md-2 control-label">Category</asp:Label>
        <div class="col-md-10">
            <asp:DropDownList runat="server" ID="CategoryDropDown" DataTextField="Name"></asp:DropDownList>
        </div>
    </div>
    <asp:Button ID="DeleteButton" runat="server" Text="Delete" CssClass="btn btn-primary" OnClick="DeleteButton_Click" />
    <asp:Button ID="CancelButton" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="CancelButton_Click" />

    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Book/Index.aspx" runat="server">Back</asp:HyperLink>
</asp:Content>
