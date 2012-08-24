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
    public partial class Musterije : System.Web.UI.Page
    {
        private string upit = "SELECT * FROM Musterije";

        //polje i property za prenos id musterije na stranu zakljucnice
        private string idMusterije;
        public string IDMusterije { get { return idMusterije; } set { idMusterije = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NapuniGridMusterije();
            }
        }

        private void NapuniGridMusterije()
        {
            DataSet dsTalaris = new DataSet();
            SqlConnection konekcija = RadSaBazom.konekcija;

            if (ViewState["dsTalaris"] == null) // kesiranje dataset objekta u memoriji
            {
                SqlDataAdapter daMusterije = new SqlDataAdapter(upit, konekcija);
                daMusterije.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                daMusterije.Fill(dsTalaris, "Musterije");
                ViewState["dsTalaris"] = dsTalaris;

            }
            else
            {
                dsTalaris = (DataSet)ViewState["dsTalaris"]; //ukoliko dataset postoji u memoriji
            }

            string sortExpression;
            if (gridSortDirection == SortDirection.Ascending)
            {
                sortExpression = gridSortExpression + " ASC";
            }
            else
            {
                sortExpression = gridSortExpression + " DESC";
            }

            DataTable tblMusterije = dsTalaris.Tables["Musterije"];

            tblMusterije.DefaultView.Sort = sortExpression;
            GridViewMusterije.DataSource = tblMusterije;
            GridViewMusterije.DataBind();
        }

        //menjanje Page indexa kontrole gridview
        protected void GridViewMusterije_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewMusterije.PageIndex = e.NewPageIndex;
            NapuniGridMusterije();
        }

        //PROPERTIES ZA SORTIRANJE
        private SortDirection gridSortDirection
        {
            get
            {
                if (ViewState["GridSortDirection"] == null)
                {
                    ViewState["GridSortDirection"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["GridSortDirection"];
            }

            set
            {
                ViewState["GridSortDirection"] = value;
            }
        }

        private string gridSortExpression
        {
            get
            {
                if (ViewState["GridSortExpression"] == null)
                {
                    ViewState["GridSortExpression"] = "ImePrezime";
                }
                return (string)ViewState["GridSortExpression"];
            }
            set
            {
                ViewState["GridSortExpression"] = value;
            }
        }

        //SORTIRANJE PO KOLONAMA
        protected void GridViewMusterije_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;

            if (sortExpression == gridSortExpression)
            {
                if (gridSortDirection == SortDirection.Ascending)
                {
                    gridSortDirection = SortDirection.Descending;
                }
                else
                {
                    gridSortDirection = SortDirection.Ascending;
                }
            }
            else
            {
                gridSortDirection = SortDirection.Ascending;
            }
            gridSortExpression = sortExpression;
            NapuniGridMusterije();

        }

        //dugme Traži
        protected void btnTrazi_Click(object sender, EventArgs e)
        {
            ViewState["dsTalaris"] = null;

            if (listIzbor.SelectedIndex == 0)
            {      
                upit = "SELECT * FROM Musterije WHERE ImePrezime LIKE '" + txtPretraga.Text + "%'";
                NapuniGridMusterije();
                PopuniDvMusterije();
            }
            else
            {
                upit = "SELECT * FROM Musterije WHERE AdresaDeoGrada LIKE '" + txtPretraga.Text + "%'";
                NapuniGridMusterije();
            }
        }


        // DETALJI U dvMusterijeDetalji kontroli ///////////////////////////////////////////////////////////////////////////////
        protected void dvMusterijeDetalji_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            dvMusterijeDetalji.ChangeMode(e.NewMode);

            // KADA DETAILSVIEW ulazi u insert mode posle klika na lbtnNovaMusterija
            // puca aplikacija ako kliknes na cancel jer nije selektovan nijedan zaposleni u 
            // GridViewMusterije kontroli. Refresh -om stranice zaposleni se zaobilazi ovaj problem
            if (GridViewMusterije.SelectedIndex != -1)
            {
                PopuniDvMusterije();
            }
            else Response.Redirect("./Musterije.aspx");
            

        }

        protected void GridViewMusterije_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopuniDvMusterije();
        }

        private void PopuniDvMusterije()
        {
            if (GridViewMusterije.SelectedIndex != -1)
            {
                if (GridViewMusterije.SelectedValue != null)
                {


                    int id = Convert.ToInt32(GridViewMusterije.SelectedDataKey.Value); //id Musterije

                    SqlDataReader r = RadSaBazom.SelectUpit("SELECT * FROM Musterije WHERE ID = " + id);
                    dvMusterijeDetalji.DataSource = r;
                    dvMusterijeDetalji.DataBind();
                    r.Close();
                }
               
            }
            
        }

        // UPDATE MUSTERIJE
        protected void dvMusterijeDetalji_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            DataSet dsTalaris = (DataSet)ViewState["dsTalaris"];
            DataRow redUpdate = dsTalaris.Tables["Musterije"].Rows.Find(dvMusterijeDetalji.DataKey.Value);

            SqlDataAdapter daMusterije = new SqlDataAdapter("SELECT * FROM Musterije", RadSaBazom.konekcija);
            SqlCommandBuilder bilder = new SqlCommandBuilder(daMusterije);

            //izvlacenje vrednosti iz kontrola dvMusterijeDetalji
            TextBox txtImePrezime = (TextBox)dvMusterijeDetalji.FindControl("txtImePrezime");
            TextBox txtAdresa = (TextBox)dvMusterijeDetalji.FindControl("txtAdresa");
            TextBox txtSprat = (TextBox)dvMusterijeDetalji.FindControl("txtSprat");
            TextBox txtStan = (TextBox)dvMusterijeDetalji.FindControl("txtStan");
            TextBox txtTelefon = (TextBox)dvMusterijeDetalji.FindControl("txtTelefon");
            TextBox txtEmail = (TextBox)dvMusterijeDetalji.FindControl("txtEmail");

            // Postavljanje vrednosti u slog
            redUpdate["ImePrezime"] = txtImePrezime.Text;
            redUpdate["AdresaDeoGrada"] = txtAdresa.Text;
            redUpdate["Sprat"] = txtSprat.Text;
            redUpdate["Stan"] = txtStan.Text;
            redUpdate["Telefon"] = txtTelefon.Text;
            redUpdate["Email"] = txtEmail.Text;

            
           //Update tabele
            try
            {

                daMusterije.Update(dsTalaris, "Musterije");
                ViewState["dsTalaris"] = null;
                NapuniGridMusterije();
                dvMusterijeDetalji.ChangeMode(DetailsViewMode.ReadOnly);
                PopuniDvMusterije();
                

                //Poruka
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Mušterija je uspešno ažurirana.')", true);
            }

            catch (Exception )
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Greška u radu sa bazom. Pokušajte kasnije.')", true);
                
            }
            

        }

        protected void lbtnNovaMusterija_Click(object sender, EventArgs e)
        {
            GridViewMusterije.SelectedIndex = -1;
            dvMusterijeDetalji.ChangeMode(DetailsViewMode.Insert);
               
        }

        // INSERT Musterije
        protected void dvMusterijeDetalji_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            
            //izvlacenje vrednosti iz kontrola dvMusterijeDetalji
            TextBox txtImePrezime = (TextBox)dvMusterijeDetalji.FindControl("txtImePrezime");
            TextBox txtAdresa = (TextBox)dvMusterijeDetalji.FindControl("txtAdresa");
            TextBox txtSprat = (TextBox)dvMusterijeDetalji.FindControl("txtSprat");
            TextBox txtStan = (TextBox)dvMusterijeDetalji.FindControl("txtStan");
            TextBox txtTelefon = (TextBox)dvMusterijeDetalji.FindControl("txtTelefon");
            TextBox txtEmail = (TextBox)dvMusterijeDetalji.FindControl("txtEmail");


            //parametri
            List<SqlParameter> parametri = new List<SqlParameter>();
            parametri.Add(new SqlParameter("@ImePrezime", txtImePrezime.Text));
            parametri.Add(new SqlParameter("@AdresaDeoGrada", txtAdresa.Text));
            parametri.Add(new SqlParameter("@Sprat", txtSprat.Text));
            parametri.Add(new SqlParameter("@Stan", txtStan.Text));
            parametri.Add(new SqlParameter("@Telefon", txtTelefon.Text));
            parametri.Add(new SqlParameter("@Email", txtEmail.Text));
            
            //povratna vrednost
            SqlParameter p = new SqlParameter("@MusterijaID", SqlDbType.Int, 0, "ID");
            p.Direction = ParameterDirection.Output;
            parametri.Add(p);

            try
            {
                int NovaMusterijaID = RadSaBazom.spSaVracenomVrednoscu("InsertMusterije", parametri, "@MusterijaID");
                ViewState["dsTalaris"] = null;
                NapuniGridMusterije();

               
               
                //IZABIRANJE UNETOG REDA U KONTROLI GRIDVIEW/////////////////////////////////////////////////////////////////////////////////

                //postavljanje vrednosti
                int gridStrana = -1;
                int gridRed = -1;

                //prolaz kroz strane gridview kontrole
                for (int i = 0; i < GridViewMusterije.PageCount; i++)
                {
                    GridViewMusterije.PageIndex = i;
                    NapuniGridMusterije();

                    //postavljanje na prvi red
                    int indeksReda = 0;

                    //prolaz kroz ID-je na datoj strani
                    foreach (DataKey dk in GridViewMusterije.DataKeys)
                    {
                        if ((int)dk.Value == NovaMusterijaID)
                        {
                            //sacuvaj stranu
                            gridStrana = i;
                            //sacuvaj red
                            gridRed = indeksReda;
                            break;
                        }

                        //prelaz na slececi red na strani
                        indeksReda++;
                    }
                }
               
                
                GridViewMusterije.PageIndex = gridStrana;
                GridViewMusterije.SelectedIndex = gridRed;
                dvMusterijeDetalji.ChangeMode(DetailsViewMode.ReadOnly);
                NapuniGridMusterije();
                PopuniDvMusterije();
                  
                
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////  

                //pokazi poruku 
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Mušterija uspešno unesena u bazu.')", true);
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Nije uspeo unos mušterije. Pokušajte ponovo.');window.open('./Musterije.aspx','_self');", true);
            }
            
        }

        //DELETE Musterije
        protected void dvMusterijeDetalji_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            DataSet dsTalaris = (DataSet)ViewState["dsTalaris"];
            DataRow redDelete = dsTalaris.Tables["Musterije"].Rows.Find(dvMusterijeDetalji.DataKey.Value);

            SqlDataAdapter daMusterije = new SqlDataAdapter("SELECT * FROM Musterije", RadSaBazom.konekcija);
            SqlCommandBuilder bilder = new SqlCommandBuilder(daMusterije);

            redDelete.Delete();

            try
            {
                //update tabele
                daMusterije.Update(dsTalaris, "Musterije");
                ViewState["dsTalaris"] = null;
                NapuniGridMusterije();
                Response.Redirect("./Musterije.aspx");
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Nije uspelo brisanje mušterije. Pokušajte ponovo.');window.open('./Musterije.aspx','_self');", true);
            }
        }

        
        //preusmeravanje na stranicu Zakljucnice preko dugmeta OtvoriZakljucnicu
        protected void dvMusterijeDetalji_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "btnOtvoriZakljucnicu")
            {
                IDMusterije = e.CommandArgument.ToString();
                     
            }
           
            
        }

        
       
    }
}