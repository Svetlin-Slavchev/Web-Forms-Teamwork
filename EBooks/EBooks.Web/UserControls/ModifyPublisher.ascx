<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModifyPublisher.ascx.cs" Inherits="EBooks.Web.UserControls.ModifyPublisher" %>

<div class="col-md-9">

    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div runat="server" id="ModificationForm" class="row">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label"> Name</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                            CssClass="text-danger" ErrorMessage="The user name field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" ID="ModifyButton" OnClick="ModifyButton_Click" CssClass="btn btn-default" />
                    </div>
                </div>
            </div>

            <asp:Label ID="StatusPanel" runat="server" CssClass="alert alert-dismissable alert-danger" Visible="false" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ModifyButton" />
        </Triggers>
    </asp:UpdatePanel>
    <br /> <br />
    <asp:HyperLink CssClass="btn btn-primary" NavigateUrl="~/Publisher/Index" runat="server">Back</asp:HyperLink>
</div>
