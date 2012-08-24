<%@ Page Title="Zaposleni" Language="C#" MasterPageFile="~/Site1.Master" MaintainScrollPositionOnPostback = "true" AutoEventWireup="true" CodeBehind="Zaposleni.aspx.cs" Inherits="TALARIS_1.Zaposlni" %>
<asp:Content ID="Content1"  ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Pregled i ažuriranje zaposlenih</h1>
    <br />
    
    <asp:LinkButton ID="lbtnNoviZaposleni" runat="server" 
        onclick="lbtnNoviZaposleni_Click">Novi zaposleni</asp:LinkButton>
    <br />
    <asp:DetailsView ID="DetailsViewZaposleniDetalji" runat="server" 
        AutoGenerateRows = "False" Width = "500px" DataKeyNames="ID"
        onmodechanging="DetailsViewZaposleniDetalji_ModeChanging" 
        onitemupdating="DetailsViewZaposleniDetalji_ItemUpdating" 
        oniteminserting="DetailsViewZaposleniDetalji_ItemInserting" 
        onitemdeleting="DetailsViewZaposleniDetalji_ItemDeleting" >
        <Fields>
            <asp:TemplateField HeaderText="Sektor :">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlSektor" runat="server" CssClass="txtBox" Width="275px"
                     DataSourceID = "DataSourceSektor"
                     DataTextField = "NazivSektora" 
                     DataValueField ="ID" SelectedValue ='<%# Bind("SektorID") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DropDownList ID="ddlSektor" runat="server" CssClass="txtBox" Width="275px"
                     DataSourceID = "DataSourceSektor"
                     DataTextField = "NazivSektora" 
                     DataValueField ="ID" SelectedValue ='<%# Bind("SektorID") %>'>
                     </asp:DropDownList>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="ddlSektor" runat="server" CssClass="txtBox" Width="275px"
                     DataSourceID = "DataSourceSektor"
                     DataTextField = "NazivSektora" 
                     DataValueField ="ID" SelectedValue ='<%# Bind("SektorID") %>'
                     Enabled="false">
                     </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>

           
            <asp:TemplateField HeaderText="Ime i prezime :">
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
                    <asp:Label ID="lblImePrezime" runat="server" Text='<%# Bind("ImePrezime") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            
            <asp:TemplateField HeaderText="Adresa : ">
                <EditItemTemplate>
                    <asp:TextBox ID="txtAdresa" runat="server" CssClass="txtBox" Text='<%# Bind("Adresa") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAdresa" runat="server" CssClass="txtBox" Text='<%# Bind("Adresa") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAdresa" runat="server" Text='<%# Bind("Adresa") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Email :">
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


            <asp:TemplateField HeaderText="Broj telefona :">
                <EditItemTemplate>
                    <asp:TextBox ID="txtBrojTelefona" runat="server" CssClass="txtBox" Text='<%# Bind("BrojTelefona") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                        ControlToValidate="txtBrojTelefona" runat="server"  ErrorMessage="*" ForeColor="Red">
                     </asp:RequiredFieldValidator>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtBrojTelefona" runat="server" CssClass="txtBox" Text='<%# Bind("BrojTelefona") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                        ControlToValidate="txtBrojTelefona" runat="server" ErrorMessage="*" ForeColor="Red">
                     </asp:RequiredFieldValidator>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblBrojTelefona" runat="server" Text='<%# Bind("BrojTelefona") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Korisničko ime :">
                <EditItemTemplate>
                    <asp:TextBox ID="txtKorisnickoIme" runat="server" CssClass="txtBox" Text='<%# Bind("KorisnickoIme") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtKorisnickoIme" runat="server" CssClass="txtBox" Text='<%# Bind("KorisnickoIme") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblKorisnickoIme" runat="server" Text='<%# Bind("KorisnickoIme") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Šifra : ">
                <EditItemTemplate>
                    <asp:TextBox ID="txtSifra" runat="server" CssClass="txtBox" Text='<%# Bind("Sifra") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtSifra" runat="server" CssClass="txtBox" Text='<%# Bind("Sifra") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSifra" runat="server" Text='<%# Bind("Sifra") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="U radnom odnosu :">
                <EditItemTemplate>
                    <asp:CheckBox ID="cbAktivan" runat="server"  Checked='<%# Bind("Aktivan") %>' />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:CheckBox ID="cbAktivan" runat="server"  Checked='<%# Bind("Aktivan") %>' />
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="cbAktivan" runat="server" Checked='<%# Bind("Aktivan") %>' 
                        Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButtonSacuvaj" runat="server" CausesValidation="True" 
                        CommandName="Update" Text="Sačuvaj"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButtonOdustani" runat="server" CausesValidation="False" 
                        CommandName="Cancel" Text="Odustani"></asp:LinkButton>
                </EditItemTemplate>

                <InsertItemTemplate>
                    <asp:LinkButton ID="LinkButtonSacuvajNovog" runat="server" CausesValidation="True" 
                        CommandName="Insert" Text="Sačuvaj novog"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButtonOdustani" runat="server" CausesValidation="False" 
                        CommandName="Cancel" Text="Odustani"></asp:LinkButton>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonIzmeni" runat="server" CausesValidation="False" 
                        CommandName="Edit" Text="Izmeni">
                    </asp:LinkButton>&nbsp;
                    &nbsp;
                   <asp:LinkButton ID="LinkButtonObrisi" runat="server" CausesValidation="False" 
                        CommandName="Delete" Text="Obriši" OnClientClick = "return confirm('Da li ste sigurni da želite da obrišete zaposlenog ?');">
                   </asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButtonNoviZaposleni" runat="server" CausesValidation="False" Visible ="false" 
                        CommandName="New" Text="Novi zaposleni">
                    </asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>
        </Fields>

        <HeaderTemplate>
            <%#Eval("ImePrezime")== null? "Novi zaposleni":Eval("ImePrezime") %> 
        </HeaderTemplate>
    </asp:DetailsView>
     <br />
    <!--Grid View Zaposleni -------------------------------------------------------------------------------->
    <asp:GridView ID="GridViewZaposleni" runat="server" DataKeyNames="ID" 
        AutoGenerateColumns ="False" 
        onselectedindexchanged="GridViewZaposleni_SelectedIndexChanged">  
        <Columns>
            
            <asp:BoundField DataField = "ImePrezime" HeaderText = "Ime i prezime" />
            <asp:BoundField DataField = "NazivSektora" HeaderText = "Sektor" />
            <asp:BoundField DataField = "Adresa" HeaderText = "Adresa" />
            <asp:BoundField DataField = "BrojTelefona" HeaderText = "Broj telefona" />
            <asp:CheckBoxField DataField = "Aktivan" HeaderText = "U radnom odnosu" />    
            <asp:CommandField SelectText="Detalji / Ažuriranje" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>

   

    <br />
    <!-- DetailsViewZaposleniDetalji ----------------------------------------------------------------------->
    


   
    <!-- Data source kontrola za popunjavanje liste sektora u DetailsViewZaposleni kontroli -->
    <asp:SqlDataSource ID="DataSourceSektor" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TalarisArtikli %>" 
        SelectCommand="SELECT [ID], [NazivSektora] FROM [Sektor]">
    </asp:SqlDataSource>


</asp:Content>
