<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuthorSearch.ascx.cs" Inherits="EBooks.Web.UserControls.AuthorSearch" %>
<%@ Import Namespace="EBooks.Web.Models" %>

<div class="panel panel-default">
    <div class="panel-heading">
        <div class="form-group">
            <input type="text" id="search_input" class="form-control" placeholder="Search">
        </div>
    </div>
    <div class="panel-body">
        <ul id="search_list" class="nav nav-list tree">
            <% foreach (AuthorModel author in this.AllAuthors)
               { %>
            <% var href = "../Author/View.aspx?authorId=" + author.Id; %>
            <li>
                <a href='<%= href %>'><%= author.Name %></a>
            </li>
            <% } %>
        </ul>
    </div>
</div>
