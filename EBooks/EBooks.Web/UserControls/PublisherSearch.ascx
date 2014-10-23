<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PublisherSearch.ascx.cs" Inherits="EBooks.Web.UserControls.PublisherSearch" %>
<%@ Import Namespace="EBooks.Web.Models" %>

<div class="panel panel-default">
    <div class="panel-heading">
        <div class="form-group">
            <input type="text" id="search_input" class="form-control" placeholder="Search">
        </div>
    </div>
    <div class="panel-body">
        <ul id="search_list" class="nav nav-list tree">
            <% foreach (PublisherModel publisher in this.AllPublishers)
               { %>
            <% var href = "../Publisher/" + publisher.Id; %>
            <li>
                <a href='<%= href %>'><%= publisher.Name %></a>
            </li>
            <% } %>
        </ul>
    </div>
</div>
