<%@ Page Title="Greška" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Greska.aspx.cs" Inherits="TALARIS_1.Greska" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblGreska" runat="server" Text="" Font-Size="Large"
        ForeColor="Red" >Greška u radu sa bazom. Pokušajte ponovo kasnije.<br /><br /> Error : <%# greska %></asp:Label>
</asp:Content>
