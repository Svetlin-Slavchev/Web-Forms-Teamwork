<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookSearch.ascx.cs" Inherits="EBooks.Web.UserControls.BookSearch" %>
<%@ Import Namespace="EBooks.Web.Models" %>

<div class="panel panel-default">
    <div class="panel-heading">
        <div class="form-group">
            <input type="text" id="search_input" class="form-control" placeholder="Search">
        </div>
    </div>
    <div class="panel-body">
        <ul id="search_list" class="nav nav-list tree">
            <% foreach (BookModel book in this.AllBooks)
               { %>
            <% var bookHref = "../Book/View.aspx?bookId=" + book.Id; %>
            <li>
                <a href='<%= bookHref %>'><%= book.Title %></a>
            </li>
            <% } %>
        </ul>
    </div>
</div>
