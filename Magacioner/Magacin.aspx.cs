using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TALARIS_1
{
    public partial class Magacin : System.Web.UI.Page
    {
        SqlDataReader r = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PopuniGridViewKontrole();
                
            }
            
        }

        private void PopuniGridViewKontrole()
        {
            
            PopuniGridTal1();
            PopuniGridTal2();
            PopuniGridTal3();
            PopuniGridTal4();
            PopuniGridKlasik();
            PopuniGridObloge();
            PopuniGridBrave();
            PopuniGridCilindri();
            PopuniGridKvake();
          
        }

        private void PopuniGridKvake()
        {
            r = RadSaBazom.SelectUpit("SELECT A.ID, MA.ImeModela, A.Stanje " +
                                        "FROM Artikli A JOIN ModelArtikla MA " +
                                        "ON A.ModelID = MA.ID " +
                                        "WHERE A.KategorijaArtiklaID = 3");
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (r == null)
            {
                Response.Redirect("./Greska.aspx");

            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////

            GridViewKvake.DataSource = r;
            GridViewKvake.DataKeyNames = new string[] { "ID" };
            GridViewKvake.DataBind();
            r.Close();
        }

        private void PopuniGridCilindri()
        {
            r = RadSaBazom.SelectUpit("SELECT A.ID, MA.ImeModela, D.Dimenzija, DC.NazivDizajna, A.Stanje " +
                                       "FROM ModelArtikla MA JOIN(DizajnCilindra DC JOIN (Dimenzija D JOIN (Artikli A JOIN ArtikliCilindri AC " +
                                       "ON A.ID = AC.ArtikliID) " +
                                       "ON D.ID = AC.DimenzijaID) " +
                                       "ON DC.ID = AC.DizajnCilindraID) " +
                                       "ON MA.ID = A.ModelID");
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (r == null)
            {
                Response.Redirect("./Greska.aspx");

            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////

            GridViewCilindri.DataSource = r;
            GridViewCilindri.DataKeyNames = new string[] { "ID" };
            GridViewCilindri.DataBind();
            r.Close();
        }

        private void PopuniGridBrave()
        {
            r = RadSaBazom.SelectUpit("SELECT A.ID, MA.ImeModela, A.Stanje " +
                                       "FROM Artikli A JOIN ModelArtikla MA " +
                                       "ON A.ModelID = MA.ID " +
                                       "WHERE A.KategorijaArtiklaID = 4");
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (r == null)
            {
                Response.Redirect("./Greska.aspx");

            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////


            GridViewBrave.DataSource = r;
            GridViewBrave.DataKeyNames = new string[] { "ID" };
            GridViewBrave.DataBind();
            r.Close();
        }

        private void PopuniGridObloge()
        {
            r = RadSaBazom.SelectUpit("SELECT A.ID, MA.ImeModela, A.Stanje " +
                                        "FROM Artikli A JOIN ModelArtikla MA " +
                                        "ON A.ModelID = MA.ID " +
                                        "WHERE A.KategorijaArtiklaID = 2");
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (r == null)
            {
                Response.Redirect("./Greska.aspx");

            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////

            GridViewObloge.DataSource = r;
            GridViewObloge.DataKeyNames = new string[] { "ID" };
            GridViewObloge.DataBind();
            r.Close();
        }

        private void PopuniGridKlasik()
        {
            r = RadSaBazom.SelectUpit("SELECT A.ID, M.ImeModela, D.Dimenzija, OV.Otvaranje, A.Stanje " +
                                        "FROM Dimenzija D JOIN (OrijentacijaVrata OV JOIN(ModelArtikla M JOIN(Artikli A JOIN ArtikliVrata AV " +
                                        "ON A.ID = AV.ArtikliID) " +
                                        "ON M.ID = A.ModelID) " +
                                        "ON OV.ID = AV.OrijentacijaVrataID) " +
                                        "ON D.ID = AV.DimenzijaID " +
                                        "WHERE A.ModelID = 104");
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (r == null)
            {
                Response.Redirect("./Greska.aspx");

            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////


            GridViewKlasik.DataSource = r;
            GridViewKlasik.DataKeyNames = new string[] { "ID" };
            GridViewKlasik.DataBind();
            r.Close();
        }

        private void PopuniGridTal4()
        {
            r = RadSaBazom.SelectUpit("SELECT A. ID, M.ImeModela,D.Dimenzija, B.Boja, OV.Otvaranje, A.Stanje " +
                                "FROM OrijentacijaVrata OV JOIN(Dimenzija D JOIN(ModelArtikla M JOIN(Boja B JOIN(Artikli A JOIN ArtikliVrata AV " +
                                "ON A.ID = AV.ArtikliID) " +
                                "ON B.ID = AV.BojaID)" +
                                "ON M.ID = A.ModelID)" +
                                "ON D.ID = AV.DimenzijaID)" +
                                "ON OV.ID = AV.OrijentacijaVrataID " +
                                "WHERE M.ID = 103");

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (r == null)
            {
                Response.Redirect("./Greska.aspx");

            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////


            GridViewTal4.DataSource = r;
            GridViewTal4.DataKeyNames = new string[] { "ID" };
            GridViewTal4.DataBind();
            r.Close();
        }

        private void PopuniGridTal3()
        {
            r = RadSaBazom.SelectUpit("SELECT A.ID, M.ImeModela,D.Dimenzija, B.Boja, OV.Otvaranje, A.Stanje " +
                                  "FROM OrijentacijaVrata OV JOIN(Dimenzija D JOIN(ModelArtikla M JOIN(Boja B JOIN(Artikli A JOIN ArtikliVrata AV " +
                                  "ON A.ID = AV.ArtikliID) " +
                                  "ON B.ID = AV.BojaID)" +
                                  "ON M.ID = A.ModelID)" +
                                  "ON D.ID = AV.DimenzijaID)" +
                                  "ON OV.ID = AV.OrijentacijaVrataID " +
                                  "WHERE M.ID = 102");
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (r == null)
            {
                Response.Redirect("./Greska.aspx");

            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////

            GridViewTal3.DataSource = r;
            GridViewTal3.DataKeyNames = new string[] { "ID" };
            GridViewTal3.DataBind();
            r.Close();
        }

        private void PopuniGridTal2()
        {
            r = RadSaBazom.SelectUpit("SELECT A.ID, M.ImeModela,D.Dimenzija, B.Boja, OV.Otvaranje, A.Stanje " +
                                  "FROM OrijentacijaVrata OV JOIN(Dimenzija D JOIN(ModelArtikla M JOIN(Boja B JOIN(Artikli A JOIN ArtikliVrata AV " +
                                  "ON A.ID = AV.ArtikliID) " +
                                  "ON B.ID = AV.BojaID)" +
                                  "ON M.ID = A.ModelID)" +
                                  "ON D.ID = AV.DimenzijaID)" +
                                  "ON OV.ID = AV.OrijentacijaVrataID " +
                                  "WHERE M.ID = 101");

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (r == null)
            {
                Response.Redirect("./Greska.aspx");

            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////

            GridViewTal2.DataSource = r;
            GridViewTal2.DataKeyNames = new string[] { "ID" };
            GridViewTal2.DataBind();
            r.Close();
        }

        private void PopuniGridTal1()
        {

            
                r = RadSaBazom.SelectUpit("SELECT A.ID, M.ImeModela,D.Dimenzija, B.Boja, OV.Otvaranje, A.Stanje " +
                                        "FROM OrijentacijaVrata OV JOIN(Dimenzija D JOIN(ModelArtikla M JOIN(Boja B JOIN(Artikli A JOIN ArtikliVrata AV " +
                                        "ON A.ID = AV.ArtikliID) " +
                                        "ON B.ID = AV.BojaID)" +
                                        "ON M.ID = A.ModelID)" +
                                        "ON D.ID = AV.DimenzijaID)" +
                                        "ON OV.ID = AV.OrijentacijaVrataID " +
                                        "WHERE M.ID = 100");

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (r == null)
                {
                    Response.Redirect("./Greska.aspx");

                }
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////

                GridViewTal1.DataSource = r;
                GridViewTal1.DataKeyNames = new string[] { "ID" };
                GridViewTal1.DataBind();
                r.Close();
           
               
           
        }
       

        // TAL 1 /////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        //ubaci selektovani red u edit mode
        protected void GridViewTal1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewTal1.EditIndex = e.NewEditIndex;
            PopuniGridTal1();
            GridViewTal1.Rows[e.NewEditIndex].FindControl("txtStanje").Focus();

        }

        //odustani od izmene stanja
        protected void GridViewTal1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewTal1.EditIndex = -1;
            PopuniGridTal1();
            lblTal1.Text = "";
            
        }

        //izmena podataka u izabranom redu
        protected void GridViewTal1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rez = UpdateGridViewReda(sender, e);
           
            if (rez == 0) //sve ok
            {
                PopuniGridTal1();
                lblTal1.Text = "";
            }
            else if(rez == -1) // uneto slovo ili prazan string ili nije u opsegu
            {
                PopuniGridTal1();
                GridViewTal1.Rows[e.RowIndex].FindControl("txtStanje").Focus();
                lblTal1.Text = "Morate uneti broj izmedju 0 i 1000";
            }
            
            
        }

        //AZURIRANJE STANJA
        private void izmeniStanjeArtikla(int artikalID, int novoStanje)
        {
            Dictionary<string, string> parametri = new Dictionary<string, string>();
            parametri.Add("@NovoStanje", novoStanje.ToString());
            parametri.Add("@ArtikliID", artikalID.ToString());

            //izvrsavanje procedure i provera da li je doslo do greske
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            if (RadSaBazom.sProceduraAsp("IzmenaStanja", parametri) == -1)
            {
                Response.Redirect("./Greska.aspx");
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        // METODA ZA UPDATE SVIH GRID VIEW KONTROLA NA STRANI
        private int UpdateGridViewReda(object sender, GridViewUpdateEventArgs e)
        {
            GridView grid = (GridView)sender;
            int indexReda = e.RowIndex;
           
            TextBox txtStanjeNovo = (TextBox)grid.Rows[indexReda].FindControl("txtStanje");
            
           if (txtStanjeNovo.Text == "" ) // prazan string unet
            {
               
                return -1;
            }


           try // provera da li su uneti pogresni podaci (slovo)
           {
               int novoStanje = Convert.ToInt32(txtStanjeNovo.Text); //novo stanje
               int artikalID = Convert.ToInt32(grid.DataKeys[indexReda].Value.ToString()); //id artikla


               if ((Convert.ToInt32(txtStanjeNovo.Text) > 1000 || (Convert.ToInt32(txtStanjeNovo.Text) < 0))) // nije u opsegu od 0 - 1000
               {
                   return -1;
               }
               izmeniStanjeArtikla(artikalID, novoStanje);

               grid.EditIndex = -1;
               return 0;
           }
           catch
           {

               return -1;
           }
                  
            
        }


        // TAL 2 /////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void GridViewTal2_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridViewTal2.EditIndex = e.NewEditIndex;
            PopuniGridTal2();
            GridViewTal2.Rows[e.NewEditIndex].FindControl("txtStanje").Focus();
        }

        protected void GridViewTal2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewTal2.EditIndex = -1;
            PopuniGridTal2();
            lblTal2.Text = "";
        }

        protected void GridViewTal2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
            int rez = UpdateGridViewReda(sender, e); 

            if (rez == 0) //sve ok
            {
                PopuniGridTal2();
                lblTal2.Text = "";
            }
            else if (rez == -1) // uneto slovo ili prazan string ili nije u opsegu
            {
                PopuniGridTal2();
                GridViewTal2.Rows[e.RowIndex].FindControl("txtStanje").Focus();
                lblTal2.Text = "Morate uneti broj izmedju 0 i 1000";
            }
            
        }

        // TAL 3 /////////////////////////////////////////////////////////////////////////////////////////////////
        protected void GridViewTal3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewTal3.EditIndex = e.NewEditIndex;
            PopuniGridTal3();
            GridViewTal3.Rows[e.NewEditIndex].FindControl("txtStanje").Focus();
        }

        protected void GridViewTal3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewTal3.EditIndex = -1;
            PopuniGridTal3();
            lblTal3.Text = "";
        }

        protected void GridViewTal3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rez = UpdateGridViewReda(sender, e); 

            if (rez == 0) //sve ok
            {
                PopuniGridTal3();
                lblTal3.Text = "";
            }
            else if (rez == -1) // uneto slovo ili prazan string ili nije u opsegu
            {
                PopuniGridTal3();
                GridViewTal3.Rows[e.RowIndex].FindControl("txtStanje").Focus();
                lblTal3.Text = "Morate uneti broj izmedju 0 i 1000";
                
            }
            
        }

        

       // TAL 4 /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void GridViewTal4_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewTal4.EditIndex = e.NewEditIndex;
            PopuniGridTal4();
            GridViewTal4.Rows[e.NewEditIndex].FindControl("txtStanje").Focus();
        }

        protected void GridViewTal4_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewTal4.EditIndex = -1;
            PopuniGridTal4();
            lblTal4.Text = "";
        }

        protected void GridViewTal4_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rez = UpdateGridViewReda(sender, e); 

            if (rez == 0) //sve ok
            {
                PopuniGridTal4();
                lblTal4.Text = "";
            }
            else if (rez == -1) // uneto slovo ili prazan string ili nije u opsegu
            {
                PopuniGridTal4();
                GridViewTal4.Rows[e.RowIndex].FindControl("txtStanje").Focus();
                lblTal4.Text = "Morate uneti broj izmedju 0 i 1000";
                
            }
        }

        // KLASIK KONSTRUKCIJA ////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void GridViewKlasik_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewKlasik.EditIndex = e.NewEditIndex;
            PopuniGridKlasik();
            GridViewKlasik.Rows[e.NewEditIndex].FindControl("txtStanje").Focus();
        }

        protected void GridViewKlasik_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewKlasik.EditIndex = -1;
            PopuniGridKlasik();
            lblKlasik.Text = "";
        }

        protected void GridViewKlasik_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rez = UpdateGridViewReda(sender, e); 

            if (rez == 0) //sve ok
            {
                PopuniGridKlasik();
                lblKlasik.Text = "";
            }
            else if (rez == -1) // uneto slovo ili prazan string ili nije u opsegu
            {
                PopuniGridKlasik();
                GridViewKlasik.Rows[e.RowIndex].FindControl("txtStanje").Focus();
                lblKlasik.Text = "Morate uneti broj izmedju 0 i 1000";

            }
            
        }

        // CILINDRI //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void GridViewCilindri_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewCilindri.EditIndex = e.NewEditIndex;
            PopuniGridCilindri();
            GridViewCilindri.Rows[e.NewEditIndex].FindControl("txtStanje").Focus();
        }

        protected void GridViewCilindri_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewCilindri.EditIndex = -1;
            PopuniGridCilindri();
            lblCilindri.Text = "";
        }

        protected void GridViewCilindri_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rez = UpdateGridViewReda(sender, e); 

            if (rez == 0) //sve ok
            {
                PopuniGridCilindri();
                lblCilindri.Text = "";
            }
            else if (rez == -1) // uneto slovo ili prazan string ili nije u opsegu
            {
                PopuniGridCilindri();
                GridViewCilindri.Rows[e.RowIndex].FindControl("txtStanje").Focus();
                lblCilindri.Text = "Morate uneti broj izmedju 0 i 1000";

            }
        }

        // BRAVE ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void GridViewBrave_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewBrave.EditIndex = e.NewEditIndex;
            PopuniGridBrave();
            GridViewBrave.Rows[e.NewEditIndex].FindControl("txtStanje").Focus();
            
        }

        protected void GridViewBrave_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewBrave.EditIndex = -1;
            PopuniGridBrave();
            lblBrave.Text = "";
        }

        protected void GridViewBrave_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rez = UpdateGridViewReda(sender, e); 

            if (rez == 0) //sve ok
            {
                PopuniGridBrave();
                lblBrave.Text = "";
            }
            else if (rez == -1) // uneto slovo ili prazan string ili nije u opsegu
            {
                PopuniGridBrave();
                GridViewBrave.Rows[e.RowIndex].FindControl("txtStanje").Focus();
                lblBrave.Text = "Morate uneti broj izmedju 0 i 1000";

            }
        }

        // KVAKE //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void GridViewKvake_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewKvake.EditIndex = e.NewEditIndex;
            PopuniGridKvake();
            GridViewKvake.Rows[e.NewEditIndex].FindControl("txtStanje").Focus();
        }

        protected void GridViewKvake_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewKvake.EditIndex = -1;
            PopuniGridKvake();
            lblKvake.Text = "";
        }

        protected void GridViewKvake_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rez = UpdateGridViewReda(sender, e); 

            if (rez == 0) //sve ok
            {
                PopuniGridKvake();
                lblKvake.Text = "";
            }
            else if (rez == -1) // uneto slovo ili prazan string ili nije u opsegu
            {
                PopuniGridKvake();
                GridViewKvake.Rows[e.RowIndex].FindControl("txtStanje").Focus();
                lblKvake.Text = "Morate uneti broj izmedju 0 i 1000";

            }
        }

        // OBLOGE UNIVER //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void GridViewObloge_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewObloge.EditIndex = e.NewEditIndex;
            PopuniGridObloge();
            GridViewObloge.Rows[e.NewEditIndex].FindControl("txtStanje").Focus();
        }

        protected void GridViewObloge_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewObloge.EditIndex = -1;
            PopuniGridObloge();
            lblObloge.Text = "";
        }

        protected void GridViewObloge_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rez = UpdateGridViewReda(sender, e); 

            if (rez == 0) //sve ok
            {
                PopuniGridObloge();
                lblObloge.Text = "";
            }
            else if (rez == -1) // uneto slovo ili prazan string ili nije u opsegu
            {
                PopuniGridObloge();
                GridViewObloge.Rows[e.RowIndex].FindControl("txtStanje").Focus();
                lblObloge.Text = "Morate uneti broj izmedju 0 i 1000";

            }
        }

       
        
       
    }
}