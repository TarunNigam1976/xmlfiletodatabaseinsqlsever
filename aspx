<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="XMLTODataBase.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
     <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="Button1" Text="Upload XML" runat="server" OnClick="Button1_Click"  />
</asp:Content>