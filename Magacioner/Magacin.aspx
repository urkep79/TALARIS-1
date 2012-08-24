<%@ Page Title="Magacin" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Magacin.aspx.cs"
 Inherits="TALARIS_1.Magacin" MaintainScrollPositionOnPostback = "true" %> 


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style1
    {
        text-align: left;
    }
    .style2
    {
        text-align: left;
        width: 328px;
    }
    .style3
    {
        width: 100%;
    }
    .style4
    {
            width: 444px;
        }
    .style5
    {
        width: 444px;
        height: 42px;
    }
    .style6
    {
        height: 42px;
    }
    .style7
    {
        width: 444px;
        height: 16px;
    }
    .style8
    {
        height: 16px;
    }
        .style9
        {
            text-align: left;
        }
        .style10
        {
            width: 444px;
            height: 238px;
        }
        .style11
        {
            height: 238px;
        }
        .style12
        {
            width: 444px;
            height: 23px;
        }
        .style13
        {
            height: 23px;
        }
        .style14
        {
            width: 444px;
            height: 45px;
        }
        .style15
        {
            height: 45px;
        }
        .style16
        {
            width: 444px;
            height: 163px;
        }
        .style17
        {
            height: 163px;
        }
    </style>

    <!--ONEMOGUCAVA PRITISKANJE TASTERA ENTER ------------------------------------------------------------------------ -->
   <script type="text/jscript">
       function kH(e) {
           var pK = e ? e.which : window.event.keyCode;
           return pK != 13;
       }
       document.onkeypress = kH;
       if (document.layers) document.captureEvents(Event.KEYPRESS);
</script>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="style1">
</div>
<div class="style1">
</div>
<div class="style1">
    <table cellpadding="5" cellspacing="20" class="style3">
        <tr>
            <td class="style5">
<h2 style="z-index: 1" class="style9">MODEL TAL1 </h2>
            </td>
            <td class="style6">
 <h2 align="left">MODEL TAL2 </h2>
 
            </td>
        </tr>
        <tr>
            <td class="style16">
              
    <!-- Grid View  TAL 1 -------------------------------------------------------------------------------------------------------------->

    <asp:GridView ID="GridViewTal1" runat="server" AutoGenerateColumns="False" 
                    onrowcancelingedit="GridViewTal1_RowCancelingEdit" 
                    onrowediting="GridViewTal1_RowEditing" 
                    onrowupdating="GridViewTal1_RowUpdating" >
                            
        <Columns>
        
            <asp:BoundField DataField= "ImeModela" HeaderText = "Ime modela" ReadOnly ="true"/>
            <asp:BoundField DataField= "Dimenzija" HeaderText = "Dimenzija" ReadOnly="true"/>
            <asp:BoundField DataField= "Boja" HeaderText = "Boja" ReadOnly="true"/>
            <asp:BoundField DataField= "Otvaranje" HeaderText = "Otvaranje" ReadOnly="true"/>
            <asp:TemplateField HeaderText="Stanje">
                <EditItemTemplate>          
                    <asp:TextBox ID="txtStanje" runat="server" Text='<%# Bind("Stanje") %>' Width = "25"></asp:TextBox>                 
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStanje" runat="server" Text='<%# Bind("Stanje") %>'></asp:Label>
                </ItemTemplate>          
            </asp:TemplateField>
          <asp:CommandField  ShowEditButton="True" CancelText="Odustani" EditText="Izmeni"  UpdateText="Sačuvaj"/>

        </Columns>
    </asp:GridView>
                <p>
                <asp:Label ID="lblTal1" runat="server" ForeColor="Red"></asp:Label>
                </p>
            </td>
            <td class="style17">
 
 <!-- Grid View  TAL 2 ------------------------------------------------------------------------------------------------------------------>
    <asp:GridView ID="GridViewTal2" runat="server" AutoGenerateColumns ="False" 
                    onrowcancelingedit="GridViewTal2_RowCancelingEdit" 
                    onrowediting="GridViewTal2_RowEditing" onrowupdating="GridViewTal2_RowUpdating">
        <Columns>
            <asp:BoundField DataField= "ImeModela" HeaderText = "Ime modela" ReadOnly ="true"/>
            <asp:BoundField DataField= "Dimenzija" HeaderText = "Dimenzija" ReadOnly ="true" />
            <asp:BoundField DataField= "Boja" HeaderText = "Boja" ReadOnly ="true"/>
            <asp:BoundField DataField= "Otvaranje" HeaderText = "Otvaranje" ReadOnly ="true"/>
            <asp:TemplateField HeaderText="Stanje">
                <EditItemTemplate>
                    <asp:TextBox ID="txtStanje" runat="server" Text='<%# Bind("Stanje") %>' Width = "25"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStanje" runat="server" Text='<%# Bind("Stanje") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" CancelText="Odustani" EditText="Izmeni" UpdateText="Sačuvaj"/>
        </Columns>
    </asp:GridView>

                 <p>
                <asp:Label ID="lblTal2" runat="server" ForeColor="Red"></asp:Label>
                </p>
            </td>
        </tr>
        <tr>
            <td class="style7">

    <h2 class="style2">MODEL TAL3 </h2>
 
            </td>
            <td class="style8">

    <h2 class="style2">MODEL TAL4 </h2>
 
            </td>
        </tr>
        <tr>
            <td class="style4">

    <!-- Grid View  TAL 3 ----------------------------------------------------------------------------------------------------------->
    <asp:GridView ID="GridViewTal3" runat="server" AutoGenerateColumns="False" 
                    onrowcancelingedit="GridViewTal3_RowCancelingEdit" 
                    onrowediting="GridViewTal3_RowEditing" onrowupdating="GridViewTal3_RowUpdating">
        <Columns>
            <asp:BoundField DataField= "ImeModela" HeaderText = "Ime modela" ReadOnly ="true"/>
            <asp:BoundField DataField= "Dimenzija" HeaderText = "Dimenzija" ReadOnly ="true" />
            <asp:BoundField DataField= "Boja" HeaderText = "Boja" ReadOnly ="true"/>
            <asp:BoundField DataField= "Otvaranje" HeaderText = "Otvaranje" ReadOnly ="true"/>
            <asp:TemplateField HeaderText="Stanje">
                <EditItemTemplate>
                     <asp:TextBox ID="txtStanje" runat="server" Text='<%# Bind("Stanje") %>' Width = "25"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStanje" runat="server" Text='<%# Bind("Stanje") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" CancelText="Odustani" EditText="Izmeni" UpdateText="Sačuvaj"/>
        </Columns>
    </asp:GridView>
                <p>
                <asp:Label ID="lblTal3" runat="server" ForeColor="Red"></asp:Label>
                </p>
            </td>
            <td>
 
     <!-- Grid View  TAL 4 ------------------------------------------------------------------------------------------------------------>
    <asp:GridView ID="GridViewTal4" runat="server" AutoGenerateColumns ="False" 
                    onrowcancelingedit="GridViewTal4_RowCancelingEdit" 
                    onrowediting="GridViewTal4_RowEditing" onrowupdating="GridViewTal4_RowUpdating">
        <Columns>
             <asp:BoundField DataField= "ImeModela" HeaderText = "Ime modela" ReadOnly ="true"/>
            <asp:BoundField DataField= "Dimenzija" HeaderText = "Dimenzija" ReadOnly ="true" />
            <asp:BoundField DataField= "Boja" HeaderText = "Boja" ReadOnly ="true"/>
            <asp:BoundField DataField= "Otvaranje" HeaderText = "Otvaranje" ReadOnly ="true"/>
            <asp:TemplateField HeaderText="Stanje">
                <EditItemTemplate>
                   <asp:TextBox ID="txtStanje" runat="server" Text='<%# Bind("Stanje") %>' Width = "25"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStanje" runat="server" Text='<%# Bind("Stanje") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" CancelText="Odustani" EditText="Izmeni" UpdateText="Sačuvaj"/>
        </Columns>
    </asp:GridView>
                <p>
                <asp:Label ID="lblTal4" runat="server" ForeColor="Red"></asp:Label>
                </p>
            </td>
        </tr>
        <tr>
            <td class="style12">
            <h2 class="style2">CILINDRI</h2>
            </td>
            <td class="style13">
 
                <h2 class="style2">OBLOGE - UNIVER</h2>
                
            </td>
        </tr>
        <tr>
            <td class="style10">
             <!-- Grid View Cilindri --------------------------------------------------------------------------------------- -->
               <asp:GridView ID="GridViewCilindri" runat="server" AutoGenerateColumns ="False" 
                    onrowcancelingedit="GridViewCilindri_RowCancelingEdit" 
                    onrowediting="GridViewCilindri_RowEditing" 
                    onrowupdating="GridViewCilindri_RowUpdating">
        <Columns>
             <asp:BoundField DataField= "ImeModela" HeaderText = "Ime modela" ReadOnly ="true"/>
             <asp:BoundField DataField= "Dimenzija" HeaderText = "Dimenzija" ReadOnly ="true"/>
             <asp:BoundField DataField= "NazivDizajna" HeaderText = "Dizajn" ReadOnly ="true"/>
            <asp:TemplateField HeaderText="Stanje">
                <EditItemTemplate>
                   <asp:TextBox ID="txtStanje" runat="server" Text='<%# Bind("Stanje") %>' Width = "25"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStanje" runat="server" Text='<%# Bind("Stanje") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" CancelText="Odustani" EditText="Izmeni" UpdateText="Sačuvaj"/>
        </Columns>
    </asp:GridView> 
                <p>
                <asp:Label ID="lblCilindri" runat="server" ForeColor="Red"></asp:Label>
                </p>
            </td>
            <td align="justify" class="style11">
                <!-- Grid View  Obloge univer ----------------------------------------------------------------------------------->
                <asp:GridView ID="GridViewObloge" runat="server" AutoGenerateColumns ="False" 
                    style="margin-top: 0px" 
                    onrowcancelingedit="GridViewObloge_RowCancelingEdit" 
                    onrowediting="GridViewObloge_RowEditing" 
                    onrowupdating="GridViewObloge_RowUpdating">
        <Columns>
             <asp:BoundField DataField= "ImeModela" HeaderText = "Ime modela" ReadOnly ="true"/>
            <asp:TemplateField HeaderText="Stanje">
                <EditItemTemplate>
                   <asp:TextBox ID="txtStanje" runat="server" Text='<%# Bind("Stanje") %>' Width = "25"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStanje" runat="server" Text='<%# Bind("Stanje") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" CancelText="Odustani" EditText="Izmeni" UpdateText="Sačuvaj"/>
        </Columns>
    </asp:GridView>
                <p>
                <asp:Label ID="lblObloge" runat="server" ForeColor="Red"></asp:Label>
                </p>
            </td>
        </tr>
        <tr>
            <td class="style4" align="justify">

               <h2 class="style2">KLASIK KONSTRUKCIJE</h2>
            </td>
            <td align="justify">
            <h2 class="style2">BRAVE</h2>
            </td>
        </tr>
        <tr>
            <td class="style10" align="justify">
              <!-- Grid View  Klasik konstrukcije ------------------------------------------------------------------------------------>
                <asp:GridView ID="GridViewKlasik" runat="server" AutoGenerateColumns ="False" 
                    onrowcancelingedit="GridViewKlasik_RowCancelingEdit" 
                    onrowediting="GridViewKlasik_RowEditing" 
                    onrowupdating="GridViewKlasik_RowUpdating" style="margin-top: 0px">
        <Columns>
             <asp:BoundField DataField= "ImeModela" HeaderText = "Ime modela" ReadOnly ="true"/>
            <asp:BoundField DataField= "Dimenzija" HeaderText = "Dimenzija" ReadOnly ="true" />
            <asp:BoundField DataField= "Otvaranje" HeaderText = "Otvaranje" ReadOnly ="true"/>
            <asp:TemplateField HeaderText="Stanje">
                <EditItemTemplate>
                   <asp:TextBox ID="txtStanje" runat="server" Text='<%# Bind("Stanje") %>' Width = "25"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStanje" runat="server" Text='<%# Bind("Stanje") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" CancelText="Odustani" EditText="Izmeni" UpdateText="Sačuvaj"/>
        </Columns>
    </asp:GridView>
                <p>
                <asp:Label ID="lblKlasik" runat="server" ForeColor="Red"></asp:Label>
                </p>
            </td>
            <td align="justify" class="style11">

            <!-- Grid View  Brave ----------------------------------------------------------------------------------------------------->
            <asp:GridView ID="GridViewBrave" runat="server" AutoGenerateColumns ="False" 
                    onrowcancelingedit="GridViewBrave_RowCancelingEdit" 
                    onrowediting="GridViewBrave_RowEditing" 
                    onrowupdating="GridViewBrave_RowUpdating">
        <Columns>
             <asp:BoundField DataField= "ImeModela" HeaderText = "Ime modela" ReadOnly ="true"/>
            <asp:TemplateField HeaderText="Stanje">
                <EditItemTemplate>
                   <asp:TextBox ID="txtStanje" runat="server" Text='<%# Bind("Stanje") %>' Width = "25"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStanje" runat="server" Text='<%# Bind("Stanje") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" CancelText="Odustani" EditText="Izmeni" UpdateText="Sačuvaj"/>
        </Columns>
    </asp:GridView>
                <p>
                <asp:Label ID="lblBrave" runat="server" ForeColor="Red"></asp:Label>
                </p>
            </td>
        </tr>
        <tr>
            <td class="style14" align="justify">
               <h2 class="style2">KVAKE</h2>
            </td>
            <td align="justify" class="style15">

                </td>
        </tr>
        <tr>
            <td class="style10" align="justify">
                 <!-- Grid View  kvake ----------------------------------------------------------------------------------->
                <asp:GridView ID="GridViewKvake" runat="server" AutoGenerateColumns ="False" 
                     onrowcancelingedit="GridViewKvake_RowCancelingEdit" 
                     onrowediting="GridViewKvake_RowEditing" 
                     onrowupdating="GridViewKvake_RowUpdating">
        <Columns>
             <asp:BoundField DataField= "ImeModela" HeaderText = "Ime modela" ReadOnly ="true"/>
            <asp:TemplateField HeaderText="Stanje">
                <EditItemTemplate>
                   <asp:TextBox ID="txtStanje" runat="server" Text='<%# Bind("Stanje") %>' Width = "25"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStanje" runat="server" Text='<%# Bind("Stanje") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" CancelText="Odustani" EditText="Izmeni" UpdateText="Sačuvaj"/>
        </Columns>
    </asp:GridView>
                <p>
                <asp:Label ID="lblKvake" runat="server" ForeColor="Red"></asp:Label>
                </p>
    </td>
            <td align="justify" class="style11">

                &nbsp;</td>
        </tr>
    </table>

</div>
<div class="style1">
</div>
</asp:Content>
