
<%@ Page Title="Montaže" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Montaze.aspx.cs" Inherits="TALARIS_1.Montaze" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .txtBox
        {}
        .style2
        {
            width: 100%;
            height: 107px;
        }
        .style3
        {
            width: 387px;
        }
        .style4
        {
            width: 82px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div>
                   <asp:CalendarExtender ID="CalendarExtender1" runat="server"
                        TargetControlID = "txtDatum" PopupButtonID = "imgCrveniKalendar" Format="d MMM, yyyy">
                    </asp:CalendarExtender>


    
    <table class="style2">
        <tr>
            <td class="style4">
    <asp:Label ID="lblDatum" runat="server" CssClass="lbl" Text="Datum:"></asp:Label>

            </td>
            <td class="style3">

    <asp:TextBox ID="txtDatum" runat="server" CssClass="txtBox" 
        AutoPostBack = "true" ontextchanged="txtDatum_TextChanged" height="22px" 
                    width="350px" ></asp:TextBox>
                    </td>
            <td>
                    <asp:Image ID="imgCrveniKalendar" runat="server" 
                        ImageUrl="~/Slike/plaviKalendar32.png" />
                   </td>
        </tr>
        <tr>
            <td class="style4">

    <asp:Label ID="lblMontazer" runat="server" CssClass="lbl" Text="Montažer:"></asp:Label>

            </td>
            <td class="style3">

    <asp:DropDownList ID="listMontazeri" runat="server" CssClass="txtBox"  AutoPostBack = "true"
        Width="365px" onselectedindexchanged="listMontazeri_SelectedIndexChanged" 
                    height="37px">
     </asp:DropDownList>

            </td>
            <td>

    <asp:Button ID="btnPrikaziMontaze" runat="server" CssClass = "myButton"
        onclick="btnPrikaziMontaze_Click" Text="Prikaži montaže" />

   

            </td>
        </tr>
    </table>


    
    <br />
    
   

  

    <asp:SqlDataSource ID="sourceSaloni" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TalarisArtikli %>" 
        SelectCommand="SELECT [ID], [NazivSalona] FROM [Salon]"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sourceBravarskaUsluga" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TalarisArtikli %>" 
        SelectCommand="SELECT [ID], [NazivUsluge] FROM [BravarskaUsluga]"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sourceModelVrata" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TalarisArtikli %>" SelectCommand="SELECT DISTINCT A.ModelID, M.ImeModela
                                                                                    FROM Artikli A JOIN ModelArtikla M ON
                                                                                    A.ModelID = M.ID
                                                                                    WHERE A.VrstaArtikla = 'V'">
         </asp:SqlDataSource>

    <asp:SqlDataSource ID="sourceMontazePrvaSmena" runat="server" ConnectionString="<%$ ConnectionStrings:TalarisArtikli %>" 
       
        
        SelectCommand="SELECT M.ID, S.NazivSalona, M.PrezimeAdresa, MA.ImeModela, BU.NazivUsluge, M.MoraTajMajstor
                        FROM BravarskaUsluga BU JOIN (ModelArtikla MA JOIN (Montaze M JOIN Salon S
                        ON M.SalonID = S.ID)
                        ON MA.ID = M.ModelVrata)
                        ON BU.ID = M.BravarskaUslugaID
                        WHERE (([Datum] = @Datum) AND ([MontazerID] = @MontazerID) AND ([SmenaID] = @SmenaID))">

        <SelectParameters>
            <asp:ControlParameter ControlID="txtDatum" DbType="Date" Name="Datum" 
                PropertyName="Text" />
            <asp:ControlParameter ControlID="listMontazeri" Name="MontazerID" 
                PropertyName="SelectedValue" Type="Int32" />
            <asp:Parameter DefaultValue="700" Name="SmenaID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sourceMontazeDrugaSmena" runat="server" ConnectionString="<%$ ConnectionStrings:TalarisArtikli %>" 
       
        
        SelectCommand="SELECT M.ID, S.NazivSalona, M.PrezimeAdresa, MA.ImeModela, BU.NazivUsluge, M.MoraTajMajstor
                        FROM BravarskaUsluga BU JOIN (ModelArtikla MA JOIN (Montaze M JOIN Salon S
                        ON M.SalonID = S.ID)
                        ON MA.ID = M.ModelVrata)
                        ON BU.ID = M.BravarskaUslugaID
                        WHERE (([Datum] = @Datum) AND ([MontazerID] = @MontazerID) AND ([SmenaID] = @SmenaID))">

        <SelectParameters>
            <asp:ControlParameter ControlID="txtDatum" DbType="Date" Name="Datum" 
                PropertyName="Text" />
            <asp:ControlParameter ControlID="listMontazeri" Name="MontazerID" 
                PropertyName="SelectedValue" Type="Int32" />
            <asp:Parameter DefaultValue="701" Name="SmenaID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sourceMontazeTrecaSmena" runat="server" ConnectionString="<%$ ConnectionStrings:TalarisArtikli %>" 
       
        
        
        SelectCommand="SELECT M.ID, S.NazivSalona, M.PrezimeAdresa, MA.ImeModela, BU.NazivUsluge, M.MoraTajMajstor
                        FROM BravarskaUsluga BU JOIN (ModelArtikla MA JOIN (Montaze M JOIN Salon S
                        ON M.SalonID = S.ID)
                        ON MA.ID = M.ModelVrata)
                        ON BU.ID = M.BravarskaUslugaID
                        WHERE (([Datum] = @Datum) AND ([MontazerID] = @MontazerID) AND ([SmenaID] = @SmenaID))">

        <SelectParameters>
            <asp:ControlParameter ControlID="txtDatum" DbType="Date" Name="Datum" 
                PropertyName="Text" />
            <asp:ControlParameter ControlID="listMontazeri" Name="MontazerID" 
                PropertyName="SelectedValue" Type="Int32" />
            <asp:Parameter DefaultValue="702" Name="SmenaID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    

    <asp:SqlDataSource ID="sourceGridDetalji" runat="server" 
        
        ConnectionString="<%$ ConnectionStrings:TalarisArtikli %>" 
        DeleteCommand="DELETE FROM [Montaze] WHERE [ID] = @ID AND TIMESTAMP = @TIMESTAMP " 
        InsertCommand="INSERT INTO [Montaze] ([MontazerID], [SmenaID], [SalonID], [BravarskaUslugaID], [MoraTajMajstor], [PrezimeAdresa], [ModelVrata], [Datum]) VALUES (@MontazerID, @SmenaID, @SalonID, @BravarskaUslugaID, @MoraTajMajstor, @PrezimeAdresa, @ModelVrata, @Datum)" 
        SelectCommand="SELECT [MontazerID], [SmenaID], [SalonID], [BravarskaUslugaID], [MoraTajMajstor], [PrezimeAdresa], [ModelVrata], [ID], [Datum], [TIMESTAMP] FROM [Montaze] WHERE ([ID] = @ID)" 
        UpdateCommand="UPDATE [Montaze] SET  [SalonID] = @SalonID, [BravarskaUslugaID] = @BravarskaUslugaID, [MoraTajMajstor] = @MoraTajMajstor, [PrezimeAdresa] = @PrezimeAdresa, [ModelVrata] = @ModelVrata WHERE [ID] =  @ID AND TIMESTAMP = @TIMESTAMP " 
        onupdated="sourceGridDetalji_Updated" 
        ondeleted="sourceGridDetalji_Deleted" 
        oninserted="sourceGridDetalji_Inserted">
       
        <InsertParameters>
            <asp:ControlParameter ControlID="listMontazeri" Name="MontazerID" PropertyName="SelectedValue" Type="Int32" />
            
            <asp:Parameter Name="SalonID" Type="Int32" />
            <asp:Parameter Name="BravarskaUslugaID" Type="String" />
            <asp:Parameter Name="MoraTajMajstor" Type="Boolean" />
            <asp:Parameter Name="PrezimeAdresa" Type="String" />
            <asp:Parameter Name="ModelVrata" Type="Int32" />
            <asp:ControlParameter ControlID="txtDatum" Name="Datum" PropertyName="Text" DbType="Date" />

             <asp:ControlParameter ControlID="lblSmena" Name="SmenaID" PropertyName="Text" DbType="String" />


        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMontazaID" Name="ID" 
                PropertyName="Text" Type="Int32"  />


                


        </SelectParameters>
        <UpdateParameters>
            
     
            <asp:Parameter Name="SalonID" Type="Int32" />
            <asp:Parameter Name="BravarskaUslugaID" Type="String" />
            <asp:Parameter Name="MoraTajMajstor" Type="Boolean" />
            <asp:Parameter Name="PrezimeAdresa" Type="String" />
            <asp:Parameter Name="ModelVrata" Type="Int32" />
           
            
        </UpdateParameters>
    </asp:SqlDataSource>

    

    
    <asp:DetailsView ID="DetailsViewMontazeDetalji" runat="server" Height="50px" Width = "500px"
        AutoGenerateRows="False" DataKeyNames="ID, TIMESTAMP" 
        DataSourceID="sourceGridDetalji" >
        <Fields>
            
           
            <asp:TemplateField HeaderText="Salon:">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlSalon" runat="server" CssClass="txtBox" Width="275px"
                     DataSourceID = "sourceSaloni"
                     DataTextField = "NazivSalona" 
                     DataValueField ="ID" SelectedValue ='<%# Bind("SalonID") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <InsertItemTemplate>
                     <asp:DropDownList ID="ddlSalon" runat="server" CssClass="txtBox" Width="275px"
                     DataSourceID = "sourceSaloni"
                     DataTextField = "NazivSalona" 
                     DataValueField ="ID" SelectedValue ='<%# Bind("SalonID") %>'>
                    </asp:DropDownList>
                </InsertItemTemplate>
                <ItemTemplate>
                     <asp:DropDownList ID="ddlSalon" runat="server" CssClass="txtBox" Width="275px"
                     DataSourceID = "sourceSaloni"
                     DataTextField = "NazivSalona" 
                     DataValueField ="ID" SelectedValue ='<%# Bind("SalonID") %>' 
                     Enabled ="false">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>


             <asp:TemplateField HeaderText="Prezime i adresa kupca:">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox1" runat="server" CssClass="txtBox" Width="260px" Text='<%# Bind("PrezimeAdresa") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <InsertItemTemplate>
                     <asp:TextBox ID="TextBox1" runat="server" CssClass="txtBox" Width="260px" Text='<%# Bind("PrezimeAdresa") %>'></asp:TextBox>
                 </InsertItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label1" runat="server" CssClass="txtBox" Width="260px" Text='<%# Bind("PrezimeAdresa") %>'></asp:Label>
                 </ItemTemplate>
            </asp:TemplateField>


                 <asp:TemplateField HeaderText="Model vrata:" >
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlModelVrata" runat="server" CssClass="txtBox" Width="275px"
                     DataSourceID = "sourceModelVrata"
                     DataTextField = "ImeModela" 
                     DataValueField ="ModelID" SelectedValue ='<%# Bind("ModelVrata") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <InsertItemTemplate>
                   <asp:DropDownList ID="ddlModelVrata" runat="server" CssClass="txtBox" Width="275px"
                     DataSourceID = "sourceModelVrata"
                     DataTextField = "ImeModela" 
                     DataValueField ="ModelID" SelectedValue ='<%# Bind("ModelVrata") %>'>
                    </asp:DropDownList>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="ddlModelVrata" runat="server" CssClass="txtBox" Width="275px"
                     DataSourceID = "sourceModelVrata"
                     DataTextField = "ImeModela" 
                     DataValueField ="ModelID" SelectedValue ='<%# Bind("ModelVrata") %>'
                     Enabled="false">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Bravarska usluga:">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlBravarskaUsluga" runat="server" CssClass="txtBox" Width="275px"
                     DataSourceID = "sourceBravarskaUsluga"
                     DataTextField = "NazivUsluge" 
                     DataValueField ="ID" SelectedValue ='<%# Bind("BravarskaUslugaID") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DropDownList ID="ddlBravarskaUsluga" runat="server" CssClass="txtBox" Width="275px"
                     DataSourceID = "sourceBravarskaUsluga"
                     DataTextField = "NazivUsluge" 
                     DataValueField ="ID" SelectedValue ='<%# Bind("BravarskaUslugaID") %>'>
                    </asp:DropDownList>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="ddlBravarskaUsluga" runat="server" CssClass="txtBox" Width="275px"
                     DataSourceID = "sourceBravarskaUsluga"
                     DataTextField = "NazivUsluge" 
                     DataValueField ="ID" SelectedValue ='<%# Bind("BravarskaUslugaID") %>'
                     Enabled="false">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>



            <asp:CheckBoxField DataField="MoraTajMajstor" HeaderText="Obavezno taj majstor:" />



             <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButtonSacuvaj" runat="server" CausesValidation="True" 
                        CommandName="Update" Text="Sačuvaj"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButtonOdustani" runat="server" CausesValidation="False" 
                        CommandName="Cancel" Text="Odustani"></asp:LinkButton>
                </EditItemTemplate>

                <InsertItemTemplate>
                    <asp:LinkButton ID="LinkButtonSacuvajNovuMontazu" runat="server" CausesValidation="True" 
                        CommandName="Insert" Text="Sačuvaj novu montažu"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButtonOdustani" runat="server" CausesValidation="False" 
                        CommandName="Cancel" Text="Odustani"></asp:LinkButton>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonIzmeni" runat="server" CausesValidation="False" 
                        CommandName="Edit" Text="Izmeni">
                    </asp:LinkButton>&nbsp;
                    &nbsp;
                   <asp:LinkButton ID="LinkButtonObrisi" runat="server" CausesValidation="False" 
                        CommandName="Delete" Text="Obriši" OnClientClick = "return confirm('Da li ste sigurni da želite da obrišete montažu ?');">
                   </asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButtonNovaMontaza" runat="server" CausesValidation="False" Visible ="false" 
                        CommandName="New" Text="Nova montaža">
                    </asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>
        </Fields>

        <HeaderTemplate>
            <label>Nova montaža</label>
        </HeaderTemplate>

    </asp:DetailsView>
    <br />

    

   

    <asp:LinkButton ID="btnUnesiPrvuSmenu" runat="server" 
        onclick="btnUnesiPrvuSmenu_Click">Unesi prvu smenu</asp:LinkButton>
    <asp:Label ID="lblPrvaSmenaOznaka" runat="server" Font-Bold="True" 
        Font-Size="X-Large" Text="I"></asp:Label>
    <br />


    <asp:GridView ID="gridPrvaSmena" runat="server" DataKeyNames="ID" 
        DataSourceID="sourceMontazePrvaSmena" 
        AutoGenerateColumns ="False" 
        onselectedindexchanged="gridPrvaSmena_SelectedIndexChanged" >
        <Columns>
           <asp:BoundField DataField="NazivSalona" HeaderText="Salon" />
            <asp:BoundField DataField="PrezimeAdresa" HeaderText="Prezime i adresa kupca" />
            <asp:BoundField DataField="ImeModela" HeaderText="Model vrata" />
            <asp:BoundField DataField="NazivUsluge" HeaderText="Bravarska usluga" />
            <asp:CheckBoxField DataField="MoraTajMajstor" HeaderText="Obavezno taj majstor"  />
            <asp:CommandField SelectText="Detalji / Ažuriranje" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>


    <br />
    
   <asp:LinkButton ID="btnUnesiDruguSmenu" runat="server" 
        onclick="btnUnesiDruguSmenu_Click">Unesi drugu smenu</asp:LinkButton>
    <asp:Label ID="lblDrugaSmenaOznaka" runat="server" Font-Bold="True" 
        Font-Size="X-Large" Text="II"></asp:Label>
    <br />

    <asp:GridView ID="gridDrugaSmena" runat="server" DataKeyNames="ID" 
        DataSourceID="sourceMontazeDrugaSmena" 
        AutoGenerateColumns ="False" 
        onselectedindexchanged="gridDrugaSmena_SelectedIndexChanged" >
        <Columns>
           <asp:BoundField DataField="NazivSalona" HeaderText="Salon" />
            <asp:BoundField DataField="PrezimeAdresa" HeaderText="Prezime i adresa kupca" />
            <asp:BoundField DataField="ImeModela" HeaderText="Model vrata" />
            <asp:BoundField DataField="NazivUsluge" HeaderText="Bravarska usluga" />
            <asp:CheckBoxField DataField="MoraTajMajstor" HeaderText="Obavezno taj majstor"  />
            <asp:CommandField SelectText="Detalji / Ažuriranje" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    


    <br />
   
    <asp:LinkButton ID="btnUnesiTrecuSmenu" runat="server" 
        onclick="btnUnesiTrecuSmenu_Click">Unesi treću smenu</asp:LinkButton>
    
    <asp:Label ID="lblTrecaSmenaOznaka" runat="server" Font-Bold="True" 
        Font-Size="X-Large" Text="III"></asp:Label>
    
    <br />

    <asp:GridView ID="gridTrecaSmena" runat="server" DataKeyNames="ID" 
        DataSourceID="sourceMontazeTrecaSmena" 
        AutoGenerateColumns ="False" 
        onselectedindexchanged="gridTrecaSmena_SelectedIndexChanged" >
        <Columns>
           <asp:BoundField DataField="NazivSalona" HeaderText="Salon" />
            <asp:BoundField DataField="PrezimeAdresa" HeaderText="Prezime i adresa kupca" />
            <asp:BoundField DataField="ImeModela" HeaderText="Model vrata" />
            <asp:BoundField DataField="NazivUsluge" HeaderText="Bravarska usluga" />
            <asp:CheckBoxField DataField="MoraTajMajstor" HeaderText="Obavezno taj majstor"  />
            <asp:CommandField SelectText="Detalji / Ažuriranje" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblSmena" runat="server" Text="smena" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="lblMontazaID" runat="server" Text="-1" Visible="False"></asp:Label>
    <br />
</div>
</asp:Content>
