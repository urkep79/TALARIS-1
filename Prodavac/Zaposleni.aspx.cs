using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace TALARIS_1
{
    public partial class Zaposlni : System.Web.UI.Page
    {
        SqlDataReader r = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            PopuniGridZaposleni();
        }

        private void PopuniGridZaposleni()
        {
            r = RadSaBazom.SelectUpit("SELECT Z.ID, S.NazivSektora, Z.ImePrezime, Z.Adresa, Z.BrojTelefona, Z.Aktivan " +
                                        "FROM Zaposleni Z JOIN Sektor S " +
                                        "ON Z.SektorID = S.ID");

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (r == null)
            {
                 Response.Redirect("./Greska.aspx");
                
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            GridViewZaposleni.DataSource = r;
            GridViewZaposleni.DataBind();
            r.Close();

        }

        protected void GridViewZaposleni_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopuniDetailsViewZaposleniDetalji();
            
        }

        private void PopuniDetailsViewZaposleniDetalji()
        {
            int ID = Convert.ToInt32(GridViewZaposleni.DataKeys[GridViewZaposleni.SelectedIndex].Value); //ID selektovanog reda

            Dictionary<string, string> parametri = new Dictionary<string, string>();
            parametri.Add("@ZaposleniID", ID.ToString());

            r = RadSaBazom.ParametarskiSelectUpit("SELECT * " +
                                                   "FROM Zaposleni " + 
                                                   "WHERE Zaposleni.ID = @ZaposleniID", parametri);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (r == null)
            {
                Response.Redirect("./Greska.aspx");

            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
          
            DetailsViewZaposleniDetalji.DataSource = r;
            DetailsViewZaposleniDetalji.DataBind();
            r.Close();
        }

        //IZMENA MODA  DEATAILS VIEW KONTROLE(EDIT, READ-ONLY, INSERT)
        protected void DetailsViewZaposleniDetalji_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            DetailsViewZaposleniDetalji.ChangeMode(e.NewMode);
            
            // KADA DETAILSVIEW ulazi u insert mode posle klika na lbtnNoviZaposleni
            // puca aplikacija ako kliknes na cancel jer nije selektovan nijedan zaposleni u 
            // GridViewZaposleni kontroli. Refresh -om stranice zaposleni se zaobilazi ovaj problem
            if (GridViewZaposleni.SelectedIndex != -1)
            {
                PopuniDetailsViewZaposleniDetalji();
            }
            else
            {
                Response.Redirect("/Prodavac/Zaposleni.aspx");
            }
           
        }

        //UPDATE Zaposlenog
        protected void DetailsViewZaposleniDetalji_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            // ID selektovanog zaposlenog
            int ID = Convert.ToInt32( DetailsViewZaposleniDetalji.DataKey.Value);

            //izvlacenje ID-a sektora 
            DropDownList lista = (DropDownList) DetailsViewZaposleniDetalji.FindControl("ddlSektor");
            int sektorID = Convert.ToInt32(lista.SelectedValue);


            //Izvlacenje kontrola iz DeatailsViewZaposleniDetalji kontrole
            TextBox txtImePrezime = (TextBox) DetailsViewZaposleniDetalji.FindControl("txtImePrezime");
            TextBox txtAdresa = (TextBox)DetailsViewZaposleniDetalji.FindControl("txtAdresa");
            TextBox txtEmail = (TextBox)DetailsViewZaposleniDetalji.FindControl("txtEmail");
            TextBox txtBrojTelefona = (TextBox)DetailsViewZaposleniDetalji.FindControl("txtBrojTelefona");
            TextBox txtKorisnickoIme = (TextBox)DetailsViewZaposleniDetalji.FindControl("txtKorisnickoIme");
            TextBox txtSifra = (TextBox)DetailsViewZaposleniDetalji.FindControl("txtSifra");
            CheckBox cbAktivan = (CheckBox)DetailsViewZaposleniDetalji.FindControl("cbAktivan");

            
            //Parametri
            Dictionary<string, string> parametri = new Dictionary<string, string>();
            parametri.Add("@ZaposleniID", ID.ToString());
            parametri.Add("@SektorID", sektorID.ToString());
            parametri.Add("@ImePrezime", txtImePrezime.Text);
            parametri.Add("@Adresa", txtAdresa.Text);
            parametri.Add("@Email", txtEmail.Text);
            parametri.Add("@BrojTelefona", txtBrojTelefona.Text);
            parametri.Add("@KorisnickoIme", txtKorisnickoIme.Text);
            parametri.Add("@Sifra", txtSifra.Text);
            parametri.Add("@Aktivan", cbAktivan.Checked.ToString());

            bool rezultat = RadSaBazom.InsertUpdateDeleteSaParametrima("UPDATE Zaposleni SET SektorID = @SektorID,ImePrezime = @ImePrezime, Adresa = @Adresa, Email = @Email, " +
	                                                    "BrojTelefona = @BrojTelefona, KorisnickoIme = @KorisnickoIme, Sifra = @Sifra, Aktivan = @Aktivan " +
                                                        "WHERE ID = @ZaposleniID ", parametri);

            /////////////////////////////////////////////////////////////////////////////////////////
            if (rezultat == false)
            {
                Response.Redirect("./Greska.aspx");
            }
            ////////////////////////////////////////////////////////////////////////////////////////

            

            // Finisiranje update komande
            DetailsViewZaposleniDetalji.ChangeMode(DetailsViewMode.ReadOnly);
            PopuniGridZaposleni();
            PopuniDetailsViewZaposleniDetalji();

            Response.Redirect("./Zaposleni.aspx");
            


        }

        //INSERT  novog zaposlenog
        protected void DetailsViewZaposleniDetalji_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            //izvlacenje ID-a sektora 
            DropDownList lista = (DropDownList)DetailsViewZaposleniDetalji.FindControl("ddlSektor");
            int sektorID = Convert.ToInt32(lista.SelectedValue);


            //Izvlacenje kontrola iz DeatailsViewZaposleniDetalji kontrole
            TextBox txtImePrezime = (TextBox)DetailsViewZaposleniDetalji.FindControl("txtImePrezime");
            TextBox txtAdresa = (TextBox)DetailsViewZaposleniDetalji.FindControl("txtAdresa");
            TextBox txtEmail = (TextBox)DetailsViewZaposleniDetalji.FindControl("txtEmail");
            TextBox txtBrojTelefona = (TextBox)DetailsViewZaposleniDetalji.FindControl("txtBrojTelefona");
            TextBox txtKorisnickoIme = (TextBox)DetailsViewZaposleniDetalji.FindControl("txtKorisnickoIme");
            TextBox txtSifra = (TextBox)DetailsViewZaposleniDetalji.FindControl("txtSifra");
            CheckBox cbAktivan = (CheckBox)DetailsViewZaposleniDetalji.FindControl("cbAktivan");


            //Parametri
            Dictionary<string, string> parametri = new Dictionary<string, string>();
            parametri.Add("@ZaposleniID", ID.ToString());
            parametri.Add("@SektorID", sektorID.ToString());
            parametri.Add("@ImePrezime", txtImePrezime.Text);
            parametri.Add("@Adresa", txtAdresa.Text);
            parametri.Add("@Email", txtEmail.Text);
            parametri.Add("@BrojTelefona", txtBrojTelefona.Text);
            parametri.Add("@KorisnickoIme", txtKorisnickoIme.Text);
            parametri.Add("@Sifra", txtSifra.Text);
            parametri.Add("@Aktivan", cbAktivan.Checked.ToString());

            bool rezultat = RadSaBazom.InsertUpdateDeleteSaParametrima("INSERT INTO Zaposleni VALUES(@SektorID, " +
                             "@ImePrezime, @Adresa, @Email, @BrojTelefona, @KorisnickoIme, @Sifra, @Aktivan)", parametri);

            /////////////////////////////////////////////////////////////////////////////////////////
            if (rezultat == false)
            {
                Response.Redirect("./Greska.aspx");
            }
            ////////////////////////////////////////////////////////////////////////////////////////

            // Finisiranje INSERT komande
            
            Response.Redirect("./Zaposleni.aspx");
        }

        //DELETE zaposlenog
        protected void DetailsViewZaposleniDetalji_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            // ID selektovanog zaposlenog
            int ID = Convert.ToInt32(DetailsViewZaposleniDetalji.DataKey.Value);

            Dictionary<string, string> parametri = new Dictionary<string, string>();
            parametri.Add("@ZaposleniID", ID.ToString());

            bool rezultat = RadSaBazom.InsertUpdateDeleteSaParametrima("DELETE FROM Zaposleni WHERE ID = @ZaposleniID", parametri);

            /////////////////////////////////////////////////////////////////////////////////////////
            if (rezultat == false)
            {
                Response.Redirect("~/Greska.aspx");
            }
            ////////////////////////////////////////////////////////////////////////////////////////
            Response.Redirect("./Zaposleni.aspx");

        }
        //INSERT zaposlenog preko posebnog linka
        protected void lbtnNoviZaposleni_Click(object sender, EventArgs e)
        {
            GridViewZaposleni.SelectedIndex = -1;
            DetailsViewZaposleniDetalji.ChangeMode(DetailsViewMode.Insert);
        }

       
    }
}