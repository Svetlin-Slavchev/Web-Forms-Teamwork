﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="EBooks.Web.Author.Edit" %>

<%@ Register Src="~/UserControls/AuthorSearch.ascx" TagPrefix="uc1" TagName="AuthorSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:AuthorSearch runat="server" id="AuthorSearch" />
        </div>
        <div class="col-md-9">
            <div class="row">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="AuthorName" CssClass="col-md-2 control-label">Author Name: </asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="AuthorName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="AuthorName"
                            CssClass="text-danger" ErrorMessage="The author name cannot be empty!" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="EditButton_Click"
                             Text="Edit" CssClass="btn btn-default" />
                    </div>
                </div>

                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Author/Index.aspx" runat="server">Back</asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>
