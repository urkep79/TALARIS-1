<%@ Page Title="Glavna" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TALARIS_1.Glavna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <asp:Label ID="lblNisteUlogovani" runat="server" CssClass="lbl"
    Text="Niste ulogovani."></asp:Label>
   <br />
   <br />
            &nbsp;&nbsp;<a href="Login.aspx">Ulogujte se</a> 
        </AnonymousTemplate>
        <LoggedInTemplate>
            <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Ulogovani ste kao "></asp:Label>
            &nbsp;<asp:LoginName ID="LoginName1" runat="server" CssClass ="lbl" />
            
           &nbsp;&nbsp; <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText=" (Izloguj me)" />
        </LoggedInTemplate>
    </asp:LoginView>
    
</asp:Content>
