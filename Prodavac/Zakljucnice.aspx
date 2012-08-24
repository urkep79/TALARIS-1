<%@ Page Title="Zaključnice" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Zakljucnice.aspx.cs" Inherits="TALARIS_1.Zakljucnice" %>


<%@ PreviousPageType VirtualPath="./Musterije.aspx" %> 


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .punch
        {
            z-index: 1;
            left: 2px;
            top: 2px;
            position: relative;
        }
        .style6
        {
            width: 127px;
        }
        .style12
        {
            width: 116px;
        }
        .style13
        {
            width: 58px;
        }
        .style20
        {
            width: 71px;
        }
        .txtBox
        {
            margin-left: 0px;
        }
        .style22
        {
            width: 150px;
        }
        .myButton
        {}
        .style23
        {
            width: 150px;
            height: 30px;
        }
        .style24
        {
            height: 30px;
        }
        .style26
        {
            height: 21px;
        }
        .style30
        {
            width: 150px;
            height: 25px;
        }
        .style31
        {
            height: 25px;
        }
        .style33
        {
            width: 247px;
        }
        .style34
        {
            width: 117px;
        }
        .style35
        {
            width: 148px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="position: relative; top: 0px; left: 0px; height: 132px;">

    <asp:Panel ID="pnlPretraga" runat="server" Font-Bold="True" Height="127px">
        &nbsp;&nbsp;&nbsp;&nbsp;
        <table style="width: 776px; z-index: 1; left: 17px; top: 20px; position: absolute; height: 32px;" >
            <tr>
                <td class="style35" >
                    <asp:Label ID="lblPretraga" runat="server" CssClass="lbl" Font-Bold="True" Text="Pretraga po:          "></asp:Label>
                </td>
                <td class="style13">
                    <asp:DropDownList ID="listIzbor" runat="server" CssClass="txtBox" AutoPostBack="True" 
                        onselectedindexchanged="listIzbor_SelectedIndexChanged" 
                        style="margin-left: 0px">
                        <asp:ListItem>Broju zaključnice</asp:ListItem>
                        <asp:ListItem>Imenu i prezimenu</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtPretraga" runat="server" CssClass="txtBox" Height="19px" Width="116px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnTrazi" runat="server" CausesValidation="False" 
                        CssClass="myButton" onclick="btnTrazi_Click" Text="Traži" />
                </td>
            </tr>
        </table>
        <table style="width: 776px; height: 32px; z-index: 1; left: 17px; top: 62px; position: absolute;">
            <tr>
                <td class="style34">
                    <asp:Label ID="lblMusterija" runat="server" CssClass="lbl" Text="Mušterija:"></asp:Label>
                </td>
                <td class="style33">
                    <asp:DropDownList ID="listMusterije" runat="server" CssClass="txtBox" AppendDataBoundItems="true" 
                        AutoPostBack="True" 
                        onselectedindexchanged="listMusterije_SelectedIndexChanged" Width="486px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style34">
                    <asp:Label ID="lblBrojZakljucnicePretraga" runat="server" CssClass="lbl" Font-Bold="True" 
                        Text="Br. zaključnice:"></asp:Label>
                </td>
                <td class="style33">
                    <asp:DropDownList ID="listBrojeviZakljucnica" runat="server" CssClass="txtBox"
                        AutoPostBack="True" 
                        onselectedindexchanged="listBrojeviZakljucnica_SelectedIndexChanged" 
                        Width="486px">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <br />
        &nbsp;<br />
        <br />
      
 
    </asp:Panel>
    </div>
    <br /> 
 
    
    <div style="position: relative">
  
    <asp:Panel ID="pnlIzborModela" runat="server" Height="130px">
 
        <table style="height: 112px; width: 466px; z-index: 2; left: 17px; top: 7px; position: absolute;" >
            <tr>
                <td class="style22" style="text-align: left">
                    <asp:Label ID="lblDatum" runat="server" Font-Bold="True" Text="Datum:" CssClass="lbl"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="txtDatum" runat="server" CssClass="txtBox" Width =240px ></asp:TextBox>
                    <asp:Image ID="imgCrveniKalendar" runat="server" 
                        ImageUrl="~/Slike/plaviKalendar32.png" />
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID = "txtDatum" PopupButtonID = "imgCrveniKalendar" Format="d MMM, yyyy">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="style22">
                    <asp:Label ID="lblProdavac" runat="server" Font-Bold="true" Text="Prodavac :" CssClass="lbl"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="listProdavci" runat="server" CssClass="txtBox" 
                         Width="290px" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style22">
                    <asp:Label ID="lblModeliVrata" runat="server" Font-Bold="True" 
                        style="height: 19px;" Text="Model:" CssClass="lbl"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="listModeliVrata" runat="server" CssClass="txtBox"  
                        AppendDataBoundItems="true" AutoPostBack="True" DataTextField="ImeModela" 
                        DataValueField="ModelID" 
                        onselectedindexchanged="listModeliVrata_SelectedIndexChanged" 
                        Width="290px">
                        <asp:ListItem Text="Izaberi model" Value="-1" />
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        
        
        <table ID="tblMusterijaPodaci" 
            style="z-index: 1; left: 510px; top: 17px; position: absolute; height: 80px; width: 272px; right: 824px;">
            <tr>
                <td>
                    <asp:Label ID="lblImePrezimeMusterije" runat="server" CssClass="lbl" Font-Bold="True" 
                        Text="Mušterija:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtImePrezimeMusterije" runat="server" CssClass="txtBox" 
                        height="22px" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAdresaMusterije" runat="server" CssClass="lbl" Font-Bold="True" 
                        height="19px" Text="Adresa:" width="71px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAdresaMusterije" runat="server" CssClass="txtBox" 
                        height="22px" width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTelefonMusterije" runat="server"  CssClass="lbl" Font-Bold="True" 
                        height="19px" Text="Telefon:" width="71px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTelefonMusterije" runat="server" CssClass="txtBox"  Width="200px"></asp:TextBox>
                </td>
            </tr>
        </table>
        
        <br />

        
        
         </asp:Panel>

       
        <asp:Panel ID="pnlTalModeli" runat="server" Height="452px" 
            >
            <br />


                
            <table ID="tblTalKarakteristike" 
               
                
                
                style="z-index: 1; left: 17px; top: 150px; position: absolute; height: 140px; width: 466px" >
                <tr>
                    <td class="style22">
                        <asp:Label ID="lblBojaVrata" runat="server" CssClass="lbl" Font-Bold="True" 
                             Text="Boja:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="listBojaVrata" runat="server" CssClass="txtBox"  DataTextField="Boja" 
                            DataValueField="BojaID"  Width="290px" >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style22">
                        <asp:Label ID="lblDimenzija" runat="server" CssClass="lbl" Font-Bold="True" height="19px" 
                            Text="Dimenzija:" ></asp:Label>
                    </td>
                    <td >
                        <asp:DropDownList ID="listDimenzija" runat="server" CssClass="txtBox"  Width="290px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style22">
                        <asp:Label ID="Label2" runat="server" CssClass="lbl" Font-Bold="True" height="19px" 
                             Text="Otvaranje:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="listOtvaranje" runat="server" CssClass="txtBox"  width="290px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style23">
                        <asp:Label ID="lblGornjaBravaTal" runat="server" CssClass="lbl" Font-Bold="True" height="19px" 
                            Text="Gornja brava:" Width="100px"></asp:Label>
                    </td>
                    <td class="style24">
                        <asp:CheckBox ID="cbxGornjaBravaTal" runat="server"   />
                    </td>
                </tr>
                <tr>
                    <td class="style22">
                        <asp:Label ID="lblKolicinaTal" runat="server" CssClass="lbl" Font-Bold="True" height="19px" 
                            Text="Količina:" ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtKolicinaTal" runat="server" CssClass="txtBox" 
                            style="height: 22px; width: 40px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validatorKolicina" runat="server" 
                            ControlToValidate="txtKolicinaTal" ErrorMessage="*" ForeColor="Red" 
                            style="width: 8px;">
            </asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="validatorUnosKolicine" runat="server" 
                            ControlToValidate="txtKolicinaTal" ErrorMessage="Neispravna količina!" 
                            ForeColor="Red" Operator="DataTypeCheck" Type="Integer">
                </asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style22">
                        <asp:Button ID="btnUpitStanja" runat="server" CausesValidation="False" 
                            CssClass="myButton" onclick="btnUpitStanja_Click" 
                            Text="Upit stanja" Width="120px"  />
                    </td>
                    <td >
                        <asp:Label ID="lblStanje" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            
            <table style="z-index: 1; left: 510px; top: 150px; position: absolute; height: 6px; width: 439px" >
                <tr>
                    <td class="style20">
                        <asp:Label ID="lblCenaTalModeli" runat="server" CssClass="lbl" Font-Bold="True" 
                            height="19px" Text="Cena:" width="71px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCenaTalModeli" runat="server" CssClass="txtBox" 
                            width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validatorCena" runat="server" 
                            ControlToValidate="txtCenaTalModeli" ErrorMessage="*" ForeColor="Red">
            </asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="validatorUnosaCena" runat="server" 
                            ControlToValidate="txtCenaTalModeli" ErrorMessage="Neispravna cena!" 
                            ForeColor="Red" Operator="DataTypeCheck" Type="Currency">
                </asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style20">
                        <asp:Label ID="lblAvansTalModeli" runat="server" CssClass="lbl" 
                            Font-Bold="True" height="19px" Text="Avans:" width="71px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAvansTalModeli" runat="server" CssClass="txtBox" 
                            width="200px" Height="21px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validatorAvans" runat="server" 
                            ControlToValidate="txtAvansTalModeli" ErrorMessage="*" ForeColor="Red" 
                            style="height: 17px;">
            </asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="validatorUnosAvansa" runat="server" 
                            ControlToValidate="txtAvansTalModeli" ErrorMessage="Neispravan avans!" 
                            ForeColor="Red" Operator="DataTypeCheck" Type="Currency">
                </asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style20">
                        <asp:Label ID="lblRazlikaTalModeli" runat="server" CssClass="lbl" 
                            Font-Bold="True" height="19px" Text="Razlika:" width="71px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRazlikaTalModeli" runat="server" CssClass="txtBox" 
                            Height="17px" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validatorRazlika" runat="server" 
                            ControlToValidate="txtRazlikaTalModeli" ErrorMessage="*" ForeColor="Red" 
                            style="width: 13px;">
            </asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="validatorUnosRazlike" runat="server" 
                            ControlToValidate="txtRazlikaTalModeli" ErrorMessage="Neispravna razlika!" 
                            ForeColor="Red" Operator="DataTypeCheck" Type="Currency">
                </asp:CompareValidator>
                    </td>
                </tr>
            </table>
            
            <table style="z-index: 1; left: 510px; top: 296px; position: absolute; height: 184px; width: 269px" >
                <tr>
                    <td>
                        <asp:Label ID="lblKakoSteSaznaliTalModeli" runat="server" CssClass ="lbl"
                            Font-Bold="True" Text="Kako ste saznali za nas ?"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding:10px">
                        <asp:TextBox ID="txtKakoSteSaznaliTalModeli" runat="server" CssClass="txtBox" 
                            style="height: 51px; width: 244px;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNapomenaTalModeli" runat="server" CssClass ="lbl"
                            Font-Bold="True" Text="Napomena:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding:10px">
                        <asp:TextBox ID="txtNapomenaTalModeli" runat="server" CssClass="txtBox" 
                            style="height: 78px; width: 244px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding:10px">
                        <asp:Button ID="btnSacuvajTal" runat="server" CssClass="myButton" 
                            Font-Bold="True" onclick="btnSacuvajTal_Click" 
                            style="height:auto; width: 97px; text-align: right;" Text="Sačuvaj" />
                    </td>
                </tr>
            </table>
            
        </asp:Panel>


      
        <asp:Panel ID="pnlKlasikModel" runat="server" BackColor="White" 
            style=" position: relative; top: 6px; left: 0px; height: 464px;">
            <br />


            <br />
                
                
             
            <br />
             
            <table style="width: 466px; z-index: 1; left: 17px; top: 35px; position: absolute; height: 186px" >
                <tr>
                    <td class="style22">
                        <asp:Label ID="lblKonstrukcije" runat="server" CssClass="lbl" Font-Bold="True" height="19px" 
                            Text="Konstrukcija:" width="93px"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="listKonstrukcije" runat="server" CssClass="txtBox"
                            width="290px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style22">
                        <asp:Label ID="lblBrave" runat="server" CssClass="lbl" Font-Bold="True" height="19px" 
                            style="width: 90px;" Text="Brava:"></asp:Label>
                        </td>
                    <td class="style26">
                        <asp:DropDownList ID="listBrave" runat="server" CssClass="txtBox" width="290px">
                        </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td class="style22">
                        <asp:Label ID="lblKvaka" runat="server" CssClass="lbl" Font-Bold="True" height="19px" 
                            Text="Kvaka:" width="93px"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="listKvake" runat="server" CssClass="txtBox" width="290px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style22">
                        <asp:Label ID="lblObloga" runat="server" CssClass="lbl" Font-Bold="True" height="19px" 
                            Text="Obloga:" width="93px"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="listObloge" runat="server" CssClass="txtBox" width="290px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style22">
                        <asp:Label ID="lblBojaStoka" runat="server" CssClass="lbl" Font-Bold="True" height="19px" 
                            style="width: 93px;" Text="Boja štoka:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="listBojaStoka" runat="server" CssClass="txtBox" width="290px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style30">
                        <asp:Label ID="lblGornjaBrava" runat="server" CssClass="lbl" Font-Bold="True" 
                            Text="Gornja brava:"></asp:Label>
                    </td>
                    <td class="style31">
                        <asp:CheckBox ID="cbxGornjaBravaKlasik" runat="server" AutoPostBack="True" 
                            oncheckedchanged="cbxGornjaBravaKlasik_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td class="style22">
                        <asp:Label ID="lblCilindar" runat="server" CssClass="lbl" Font-Bold="True" height="19px" 
                            Text="Cilindar:" width="93px"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="listCilindri" runat="server" CssClass="txtBox" 
                            Width="290px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style22">
                        <asp:Label ID="lblKolicinaKlasik" runat="server" CssClass="lbl" Font-Bold="True" height="19px" 
                            Text="Količina:" width="93px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtKolicinaKlasik" runat="server" CssClass="txtBox"
                            style="height: 22px; width: 40px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validatorKolicinaKlasik" runat="server" 
                            ControlToValidate="txtKolicinaKlasik" ErrorMessage="*" ForeColor="Red" 
                            style="width: 8px;">
            </asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="validatorUnosKolicineKlasik" runat="server" 
                            ControlToValidate="txtKolicinaKlasik" ErrorMessage="Neispravna količina!" 
                            ForeColor="Red" Operator="DataTypeCheck" Type="Integer">
                </asp:CompareValidator>
                    </td>
                </tr>
            </table>
             
            <table style="z-index: 1; left: 510px; top: 35px; position: absolute; height: 6px; width: 439px; margin-top: 0px;">
                <tr>
                    <td class="style20">
                        <asp:Label ID="lblCenaKlasik" runat="server" CssClass="lbl" Font-Bold="True" height="19px" 
                            Text="Cena:" width="56px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCenaKlasik" runat="server"  CssClass="txtBox" height="22px" width="183px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validatorCenaKlasik" runat="server" 
                            ControlToValidate="txtCenaKlasik" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="validatorUnosaCenaKlasik" runat="server" 
                            ControlToValidate="txtCenaKlasik" ErrorMessage="Neispravna cena!" 
                            ForeColor="Red" Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style20">
                        <asp:Label ID="lblAvansKlasik" runat="server" CssClass="lbl" Font-Bold="True" height="19px" 
                            Text="Avans:" width="56px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAvansKlasik" runat="server"  CssClass="txtBox" height="22px" width="183px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validatorAvansKlasik" runat="server" 
                            ControlToValidate="txtAvansKlasik" ErrorMessage="*" ForeColor="Red" 
                            style="width: 8px;"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="validatorUnosAvansaKlasik" runat="server" 
                            ControlToValidate="txtAvansKlasik" ErrorMessage="Neispravan avans!" 
                            ForeColor="Red" Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style20">
                        <asp:Label ID="lblRazlikaKlasik" runat="server" CssClass="lbl" Font-Bold="True" 
                            style="height: 19px;" Text="Razlika:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRazlikaKlasik" runat="server"  CssClass="txtBox" height="22px" width="183px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validatorRazlikaKlasik" runat="server" 
                            ControlToValidate="txtRazlikaKlasik" ErrorMessage="*" ForeColor="Red" 
                            style="width: 8px;"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="validatorUnosRazlikeKlasik" runat="server" 
                            ControlToValidate="txtRazlikaKlasik" ErrorMessage="Neispravna razlika!" 
                            ForeColor="Red" Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator>
                    </td>
                </tr>
            </table>
            <table style="z-index: 1; left: 510px; top: 177px; position: absolute; height: 184px; width: 269px">
                <tr>
                    <td>
                        <asp:Label ID="lblKakoSteSaznali" runat="server" CssClass="lbl" Font-Bold="True" 
                            Text="Kako ste saznali za nas ?"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding:10px">
                        <asp:TextBox ID="txtKakoSteSaznaliKlasik" runat="server"  CssClass="txtBox"
                            style="height: 51px; width: 244px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNapomenaKlasik" runat="server" CssClass="lbl" Font-Bold="True" 
                            Text="Napomena:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding:10px">
                        <asp:TextBox ID="txtNapomenaKlasik" runat="server" CssClass="txtBox"
                            style="height: 78px; width: 244px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding:10px">
                        <asp:Button ID="btnSacuvajKlasik" runat="server" CssClass="myButton" 
                            onclick="btnSacuvajKlasik_Click" Text="Sačuvaj" />
                    </td>
                </tr>
            </table>
             
        </asp:Panel>
       

        <br />
        <br />

  
     </div>

    <br />
    
    <br />
    <br />
   
</asp:Content>
