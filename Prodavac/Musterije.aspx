<%@ Page Title="Mušterije" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Musterije.aspx.cs" Inherits="TALARIS_1.Musterije" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <h1>Pregled i ažuriranje mušterija</h1>
    <br />
   
    <asp:LinkButton ID="lbtnNovaMusterija" runat="server" 
        onclick="lbtnNovaMusterija_Click">Nova mušterija</asp:LinkButton>
    <br />
   
    <asp:DetailsView ID="dvMusterijeDetalji" runat="server" Width = "500px" 
         AutoGenerateRows="False" 
        DataKeyNames = "ID" onmodechanging="dvMusterijeDetalji_ModeChanging" 
        onitemupdating="dvMusterijeDetalji_ItemUpdating" 
        onitemdeleting="dvMusterijeDetalji_ItemDeleting" 
        oniteminserting="dvMusterijeDetalji_ItemInserting" 
        onitemcommand="dvMusterijeDetalji_ItemCommand">
        <Fields>
             
            <asp:TemplateField HeaderText="Ime i prezime:">
                <EditItemTemplate>
                    <asp:TextBox ID="txtImePrezime" runat="server" CssClass="txtBox" Text='<%# Bind("ImePrezime") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorImePrezime" 
                        ControlToValidate="txtImePrezime" runat="server" ErrorMessage="*" ForeColor="Red">
                    </asp:RequiredFieldValidator>    
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtImePrezime" runat="server" CssClass="txtBox" Text='<%# Bind("ImePrezime") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorImePrezime" 
                        ControlToValidate="txtImePrezime" runat="server" ErrorMessage="*" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblImePrezime" runat="server"  Text='<%# Bind("ImePrezime") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Adresa:">
                <EditItemTemplate>
                    <asp:TextBox ID="txtAdresa" runat="server" CssClass="txtBox" Text='<%# Bind("AdresaDeoGrada") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAdresa" 
                        ControlToValidate="txtAdresa" runat="server" ErrorMessage="*" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAdresa" runat="server" CssClass="txtBox" Text='<%# Bind("AdresaDeoGrada") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAdresa" 
                        ControlToValidate="txtAdresa" runat="server" ErrorMessage="*" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAdresa" runat="server" Text='<%# Bind("AdresaDeoGrada") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Sprat:">
                <EditItemTemplate>
                    <asp:TextBox ID="txtSprat" runat="server" CssClass="txtBox" Text='<%# Bind("Sprat") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtSprat" runat="server" CssClass="txtBox" Text='<%# Bind("Sprat") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSprat" runat="server" Text='<%# Bind("Sprat") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Stan:">
                <EditItemTemplate>
                    <asp:TextBox ID="txtStan" runat="server" CssClass="txtBox" Text='<%# Bind("Stan") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtStan" runat="server" CssClass="txtBox" Text='<%# Bind("Stan") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStan" runat="server" Text='<%# Bind("Stan") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Telefon:">
                <EditItemTemplate>
                    <asp:TextBox ID="txtTelefon" runat="server" CssClass="txtBox" Text='<%# Bind("Telefon") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefon" 
                        ControlToValidate="txtTelefon" runat="server" ErrorMessage="*" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtTelefon" runat="server" CssClass="txtBox" Text='<%# Bind("Telefon") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefon" 
                        ControlToValidate="txtTelefon" runat="server" ErrorMessage="*" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTelefon" runat="server" Text='<%# Bind("Telefon") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Email:">
                <EditItemTemplate>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="txtBox" Text='<%# Bind("Email") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="txtBox" Text='<%# Bind("Email") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="lbtnSacuvaj" runat="server"  CausesValidation="True" 
                        CommandName="Update" Text="Sačuvaj"></asp:LinkButton>
                    &nbsp;&nbsp;<asp:LinkButton ID="lbtnOdustani" runat="server" CausesValidation="False" 
                        CommandName="Cancel" Text="Odustani"></asp:LinkButton>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:LinkButton ID="lbtnSacuvajNovuMusteriju" runat="server" CausesValidation="True" 
                        CommandName="Insert" Text="Sačuvaj novu mušteriju"></asp:LinkButton>
                    &nbsp;&nbsp;<asp:LinkButton ID="lbtnOdustani" runat="server" CausesValidation="False" 
                        CommandName="Cancel" Text="Odustani"></asp:LinkButton>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnIzmeni" runat="server" CausesValidation="False" 
                        CommandName="Edit" Text="Izmeni"></asp:LinkButton>
                    &nbsp;&nbsp;<asp:LinkButton ID="lbtnNovaMusterija" runat="server" CausesValidation="False" Visible = "false" 
                        CommandName="New" Text="Nova mušterija"></asp:LinkButton>
                    &nbsp;&nbsp;<asp:LinkButton ID="lbtnObrisi" runat="server" CausesValidation="False" OnClientClick = "return confirm('Da li ste sigurni da želite da obrišete mušteriju ?');"
                        CommandName="Delete" Text="Obriši"  ></asp:LinkButton>

                       
                   &nbsp;&nbsp; <asp:Button ID="btnNovaZakljucnica" runat="server" Text="Otvori zaključnicu" CssClass="myButton" CommandName = "btnOtvoriZakljucnicu" PostBackUrl ="./Zakljucnice.aspx" CommandArgument = '<%# Eval("ID") %>' />
                </ItemTemplate>
            </asp:TemplateField>

        
        </Fields>
        <HeaderTemplate>
            <%#Eval("ImePrezime")== null? "Nova mušterija":Eval("ImePrezime") %> 
        </HeaderTemplate>
    </asp:DetailsView>

    <br />
    
    
    <asp:Label ID="lblPretraga" runat="server" CssClass="lbl" Text="Pretraga po: " 
        Font-Bold="True"></asp:Label>
    <asp:DropDownList ID="listIzbor" runat="server" CssClass ="txtBox">
        <asp:ListItem>Imenu i prezimenu</asp:ListItem>
        <asp:ListItem>Adresi</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="txtPretraga" runat="server" Width="146px" CssClass ="txtBox"></asp:TextBox>
    <asp:Button ID="btnTrazi" runat="server" Text="Traži" CssClass="myButton" 
        onclick="btnTrazi_Click" />
    <br />
    <br />
    
    <asp:GridView ID="GridViewMusterije" runat="server" AllowSorting="True" 
        AutoGenerateColumns ="False"   DataKeyNames="ID" PageSize = "7" 
        AllowPaging ="True" 
        onpageindexchanging="GridViewMusterije_PageIndexChanging" 
        onsorting="GridViewMusterije_Sorting" 
        onselectedindexchanged="GridViewMusterije_SelectedIndexChanged"  >
        <Columns>
            <asp:BoundField DataField = "ImePrezime" HeaderText = "Ime i prezime" SortExpression = "ImePrezime"/>
            <asp:BoundField DataField = "AdresaDeoGrada" HeaderText = "Adresa" SortExpression="AdresaDeoGrada"/>
            <asp:BoundField DataField = "Sprat" HeaderText = "Sprat"/>
            <asp:BoundField DataField = "Stan" HeaderText = "Broj stana"/>
            <asp:BoundField DataField = "Telefon" HeaderText = "Broj telefona"/>
            <asp:CommandField SelectText="Detalji / Ažuriranje" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    
   
</asp:Content>
