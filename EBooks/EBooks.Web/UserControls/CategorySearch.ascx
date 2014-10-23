<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategorySearch.ascx.cs" Inherits="EBooks.Web.UserControls.CategorySearch" %>
<%@ Import Namespace="EBooks.Web.Models" %>

<div class="panel panel-default">
    <div class="panel-heading">
        <div class="form-group">
            <input type="text" id="search_input" class="form-control" placeholder="Search">
        </div>
    </div>
    <div class="panel-body">
        <ul id="search_list" class="nav nav-list tree">
            <% foreach (CategoryModel category in this.AllCategories)
               { %>
            <% var href = "../Category/View.aspx?categoryId=" + category.Id; %>
            <li>
                <a href='<%= href %>'><%= category.Name %></a>
            </li>
            <% } %>
        </ul>
    </div>
</div>
