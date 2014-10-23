<%@ Page Title="Create book" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="EBooks.Web.Book.Create" %>

<%@ Register Src="~/UserControls/BookSearch.ascx" TagPrefix="uc1" TagName="BookSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:BookSearch runat="server" ID="BookSearch" />
        </div>
        <div class="col-md-9">
            <div class="form-horizontal">
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
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Picture" CssClass="col-md-2 control-label">Picture</asp:Label>
                    <div class="col-md-10">
                        <asp:FileUpload runat="server" ID="Picture" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="CreateBook_Click" Text="Create book" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
