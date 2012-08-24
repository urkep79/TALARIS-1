using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.events;

namespace TALARIS_1
{
    public partial class Zakljucnice : System.Web.UI.Page
    {
        SqlDataReader r = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                NapuniZaposlene();
                NapuniModeleVrata();
                NapuniBojeVrata();
                PrikaziTekuciDatum();

                
                SakrijPanele();
               

                if (PreviousPage!=null ) // prethodna stranica je stranica Musterije
                {
                    pnlPretraga.Visible = false;
                    PrikaziIzabranuMusteriju();
                     
                    
                }
                else //direktan pristup stranici Zakljucnice
                {
                    OnemoguciKontroleZaPretraguPoImenu();
                    
                    pnlIzborModela.Visible = false;
                    pnlTalModeli.Visible = false;
                }
               
            }
        }

        private void PrikaziTekuciDatum()
        {
            txtDatum.Text = string.Format("{0:d MMM, yyyy}", DateTime.Now);
        }

        private void SakrijPanele()
        {
            pnlKlasikModel.Visible = false;
            pnlTalModeli.Visible = false;
        }

        private void NapuniBojeVrata()
        {
            r = RadSaBazom.SelectUpit("SELECT DISTINCT A.BojaID, B.Boja " +
                                        "FROM ArtikliVrata A JOIN Boja B " +
                                        "ON A.BojaID = B.ID");

            listBojaVrata.DataSource = r;
            listBojaVrata.DataBind();
            r.Close();
        }

        private void NapuniModeleVrata()
        {
            r = RadSaBazom.SelectUpit("SELECT DISTINCT A.ModelID, M.ImeModela " +  
                                        "FROM Artikli A JOIN ModelArtikla M " +
                                        "ON A.ModelID = M.ID " +
                                        "WHERE KategorijaArtiklaID = 1");


            listModeliVrata.DataSource = r;
            listModeliVrata.DataBind();
            //listModeliVrata.SelectedIndex = -1;
            
            r.Close();

            
        }

        private void PrikaziIzabranuMusteriju()
        {
            Dictionary<string, string> parametri = new Dictionary<string, string>();
            parametri.Add("@ID", PreviousPage.IDMusterije);

            r = RadSaBazom.ParametarskiSelectUpit("SELECT ImePrezime, AdresaDeoGrada, Telefon, ID " +
                                                    "FROM Musterije " +
                                                    "WHERE ID= @ID", parametri);
            while (r.Read())
            {
                
                txtImePrezimeMusterije.Text = r[0].ToString();
                txtAdresaMusterije.Text = r[1].ToString();
                txtTelefonMusterije.Text = r[2].ToString();

                ViewState["IdIzabraneMusterije"] = Convert.ToInt32(r[3].ToString()); //////////////////////////kesiranje id-a izabrane musterije
            }


            r.Close();
        }

      
        private void NapuniZaposlene()
        {
            r = RadSaBazom.SelectUpit("SELECT ImePrezime, ID FROM Zaposleni WHERE SektorID = 2");

            listProdavci.DataSource = r;
            listProdavci.DataTextField = "ImePrezime";
            listProdavci.DataValueField = "ID";
            listProdavci.DataBind();
            r.Close();
        }

        protected void listModeliVrata_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStanje.Text = "";

           
            if (listModeliVrata.SelectedValue == "104")//ako izaberes klasik konstrukciju
            {
                NapuniKonstrukcije();
                NapuniBrave();
                NapuniKvake();
                NapuniCilindre();
                NapuniObloge();
                NapuniBojeStoka();

                pnlTalModeli.Visible = false;
                pnlKlasikModel.Visible = true;
                txtKolicinaKlasik.Text = "1";
                OnemoguciIzborCilidnra();
            }
            else if (listModeliVrata.SelectedValue == "-1") // NISTA IZABRANO
            {
                pnlKlasikModel.Visible = false;
                pnlTalModeli.Visible = false;
            }

            else       // TAL MODELI    
            {
                //dimenzije i otvaranja po izabranom modelu vrata u listi modela
                NapuniListuDimenzija();
                NapuniListuOtvaranja();

                pnlTalModeli.Visible = true;
                pnlKlasikModel.Visible = false;

               

                txtKolicinaTal.Text = "1"; //podrazumevana kolicina
            }
        }

        private void NapuniBojeStoka()
        {
            listBojaStoka.Items.Clear();

            r = RadSaBazom.SelectUpit("SELECT B.ID, B.Boja " +
                                        "FROM BojePoKategoriji BP JOIN Boja B " +
                                        "ON BP.BojaID = B.ID " +
                                        "WHERE BP.NazivKategorijeID = 7");

           

            while (r.Read())
            {
                System.Web.UI.WebControls.ListItem l = new System.Web.UI.WebControls.ListItem();
                l.Value = r[0].ToString();
                l.Text = r[1].ToString();
                listBojaStoka.Items.Add(l);
            }
            r.Close();
        }

        private void NapuniObloge()
        {
            listObloge.Items.Clear(); //isprazni sve obloge

            r = RadSaBazom.SelectUpit("SELECT A.ID, MA.ImeModela, A.Stanje " +
                                       "FROM Artikli A JOIN ModelArtikla MA " +
                                       "ON A.ModelID = MA.ID " +
                                       "WHERE A.KategorijaArtiklaID = 2");

            while (r.Read())
            {
                System.Web.UI.WebControls.ListItem l = new System.Web.UI.WebControls.ListItem();
                l.Value = r[0].ToString();
                l.Text = r[1].ToString() + " kom: " + r[2].ToString();
                listObloge.Items.Add(l);
            }
            r.Close();
        }

        private void NapuniCilindre()
        {
            listCilindri.Items.Clear(); // isprazni sve cilindre

            r = RadSaBazom.SelectUpit("SELECT A.ID, MA.ImeModela, D.Dimenzija, DC.NazivDizajna, A.Stanje " +
                                      "FROM ModelArtikla MA JOIN(DizajnCilindra DC JOIN (Dimenzija D JOIN (Artikli A JOIN ArtikliCilindri AC " +
                                      "ON A.ID = AC.ArtikliID) " +
                                      "ON D.ID = AC.DimenzijaID) " +
                                      "ON DC.ID = AC.DizajnCilindraID) " +
                                      "ON MA.ID = A.ModelID");

            while (r.Read())
            {
                System.Web.UI.WebControls.ListItem l = new System.Web.UI.WebControls.ListItem();
                l.Value = r[0].ToString();
                l.Text = r[1].ToString() + " " + r[2].ToString() + " " + r[3].ToString() +  " kom: " + r[4].ToString();
                listCilindri.Items.Add(l);
            }
            r.Close();
        }

        private void NapuniKvake()
        {
            listKvake.Items.Clear(); // isprazni sve kvake

            r = RadSaBazom.SelectUpit("SELECT A.ID, MA.ImeModela, A.Stanje " +
                                       "FROM Artikli A JOIN ModelArtikla MA " +
                                       "ON A.ModelID = MA.ID " +
                                       "WHERE A.KategorijaArtiklaID = 3");
            while (r.Read())
            {
                System.Web.UI.WebControls.ListItem l = new System.Web.UI.WebControls.ListItem();
                l.Value = r[0].ToString();
                l.Text = r[1].ToString() + " kom: " + r[2].ToString();
                listKvake.Items.Add(l);
            }
            r.Close();
        }

        private void NapuniBrave()
        {
            listBrave.Items.Clear(); // isprazni sve brave

            r = RadSaBazom.SelectUpit("SELECT A.ID, MA.ImeModela, A.Stanje " +
                                        "FROM Artikli A JOIN ModelArtikla MA " +
                                        "ON A.ModelID = MA.ID " + 
                                        "WHERE A.KategorijaArtiklaID = 4");

            while (r.Read())
            {
                System.Web.UI.WebControls.ListItem l = new System.Web.UI.WebControls.ListItem();
                l.Value = r[0].ToString();
                l.Text = r[1].ToString() + " kom: " + r[2].ToString();
                listBrave.Items.Add(l);
            }
            r.Close();
        }

        private void NapuniKonstrukcije()
        {
            listKonstrukcije.Items.Clear();//isprazni sve konstrukcije

            r = RadSaBazom.SelectUpit("SELECT A.ID, D.Dimenzija, OV.Otvaranje, A.Stanje " + 
                                        "FROM Dimenzija D JOIN (OrijentacijaVrata OV JOIN(ModelArtikla M JOIN(Artikli A JOIN ArtikliVrata AV " + 
                                        "ON A.ID = AV.ArtikliID) " +
                                        "ON M.ID = A.ModelID) " + 
                                        "ON OV.ID = AV.OrijentacijaVrataID) " + 
                                        "ON D.ID = AV.DimenzijaID " + 
                                        "WHERE A.ModelID = 104");

            while (r.Read())
            {
                System.Web.UI.WebControls.ListItem l = new System.Web.UI.WebControls.ListItem();
                l.Value = r[0].ToString();
                l.Text = r[1].ToString() + " " + r[2].ToString() + " kom: " + r[3].ToString();
                listKonstrukcije.Items.Add(l);
            }
            r.Close();
        }

        private void NapuniListuOtvaranja()
        {
            r = RadSaBazom.SelectUpit("SELECT * FROM OrijentacijaVrata");


            listOtvaranje.DataSource = r;
            listOtvaranje.DataTextField = "Otvaranje";
            listOtvaranje.DataValueField = "ID";
            listOtvaranje.DataBind();
            r.Close();

        }

        private void NapuniListuDimenzija()
        {


            Dictionary<string, string> parametri = new Dictionary<string, string>();
            parametri.Add("@ModelID", listModeliVrata.SelectedValue);
            r = RadSaBazom.ParametarskiSelectUpit("SELECT DISTINCT D.ID, D.Dimenzija " +
                                                    "FROM Artikli A JOIN (ArtikliVrata AV JOIN Dimenzija D " +
                                                    "ON AV.DimenzijaID = D.ID) " +
                                                    "ON A.ID = AV.ArtikliID " +
                                                    "WHERE A.ModelID = @ModelID", parametri);

            listDimenzija.DataSource = r;
            listDimenzija.DataTextField = "Dimenzija";
            listDimenzija.DataValueField = "ID";
            listDimenzija.DataBind();
            r.Close();
        }

        protected void btnUpitStanja_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parametri = new Dictionary<string, string>();
            parametri.Add("@ModelID", listModeliVrata.SelectedValue);
            parametri.Add("@DimenzijaID", listDimenzija.SelectedValue);
            parametri.Add("@BojaID", listBojaVrata.SelectedValue);
            parametri.Add("@OrijentacijaVrataID", listOtvaranje.SelectedValue);

            r = RadSaBazom.ParametarskiSelectUpit("SELECT A.Stanje " +
                                                    "FROM Artikli A JOIN ArtikliVrata AV " +
                                                    "ON A.ID = AV.ArtikliID " +
                                                    "WHERE A.ModelID = @ModelID " +
                                                    "AND AV.DimenzijaID = @DimenzijaID " +
                                                    "AND AV.BojaID = @BojaID " +
                                                    "AND AV.OrijentacijaVrataID =@OrijentacijaVrataID", parametri);

            r.Read();
            int stanje = int.Parse(r[0].ToString());
            r.Close();

            if (stanje <= 0)
            {
                lblStanje.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblStanje.ForeColor = System.Drawing.Color.Black;
            }
            
            lblStanje.Text = "Trenutno stanje: " + stanje;
        }


        //Enable i Disable Izbora cilindra////////////////////////////////////////////////////////////
        protected void cbxGornjaBravaKlasik_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxGornjaBravaKlasik.Checked == true) OmoguciIzborCilindra();

            else OnemoguciIzborCilidnra();
            
        }

        private void OnemoguciIzborCilidnra()
        {
            listCilindri.Visible = false;
            lblCilindar.Visible = false;
        }

        private void OmoguciIzborCilindra()
        {
            listCilindri.Visible = true;
            lblCilindar.Visible = true;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////


        protected void btnSacuvajTal_Click(object sender, EventArgs e)
        {
            /* 
             * - proveri da li je ispravan unos (kolicina, cena, avans, razlika)
             * - nadji ID izabranog artikla
             * - izvrsi proceduru za unos talZakljucnice
             * - obavesti korisnika o uspesnom / neuspesnom unosu
             *      1. uspesan unos - isprazni sve kontrole + obavestenje
             *      2. neuspesan unos - ostavi kontrole popunjene + obavestenje da se pokusa ponovo ili greska  */
           

            int ArtikalID = VratiIDArtikla();
            int IdIzabraneMusterije = (int)ViewState["IdIzabraneMusterije"];
           
            List<SqlParameter> parametri = new List<SqlParameter>();
            
            parametri.Add(new SqlParameter("@ProdavacID", listProdavci.SelectedValue));
            parametri.Add(new SqlParameter("@MusterijaID", IdIzabraneMusterije.ToString()));
            parametri.Add(new SqlParameter("@Datum", txtDatum.Text));
            parametri.Add(new SqlParameter("@Cena", txtCenaTalModeli.Text));
            parametri.Add(new SqlParameter("@Avans", txtAvansTalModeli.Text));
            parametri.Add(new SqlParameter("@Razlika", txtRazlikaTalModeli.Text));
            parametri.Add(new SqlParameter("@KakoSteSaznali", txtKakoSteSaznaliTalModeli.Text));
            parametri.Add(new SqlParameter("@Napomena", txtNapomenaTalModeli.Text));
           // parametri.Add(new SqlParameter("@BojaStoka", null)); /////////////////////////////////////////////PROBLEM
            parametri.Add(new SqlParameter("@GornjaBrava", cbxGornjaBravaTal.Checked.ToString()));
            parametri.Add(new SqlParameter("@ArtikalID", ArtikalID));
            parametri.Add(new SqlParameter("@Kolicina", txtKolicinaTal.Text));


            SqlParameter povratnaVrednost = new SqlParameter("@povratnaVrednost", DbType.Int32);
            povratnaVrednost.Direction = ParameterDirection.ReturnValue;
            parametri.Add(povratnaVrednost);

            SqlParameter IDZakljucnice = new SqlParameter("@ZakljucnicaID", DbType.Int32);
            IDZakljucnice.Direction = ParameterDirection.Output;
            parametri.Add(IDZakljucnice);

            int vrednostVracena = RadSaBazom.spSaVracenomVrednoscu("UnesiZakljucnicuTal", parametri, "@povratnaVrednost");
            int ZakljucnicaID = (int)IDZakljucnice.Value;

            string poruka = "";


            switch (vrednostVracena)
            {
                case 0: //sve u redu
                    poruka = "Zaključnica je uspešno unesena u bazu.";
                   
                    //////////////////////////////////////////////////////////
                    StampajZakljucnicu(ZakljucnicaID, "tal");
                    listModeliVrata.SelectedValue = "-1";
                    listModeliVrata_SelectedIndexChanged(null,null);
                   
                    //////////////////////////////////////////////////////////
                    
                    break;

                case 2: //nema na stanju
                    poruka = "Nema više artikla na stanju";
                    break;

                default: //ostale greske
                    poruka = "Greška u radu sa bazom. Pokušajte ponovo";
                    break;
                
            }
                //Poruka korisniku
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + poruka + "')", true);

                
        }

        private void StampajZakljucnicu(int ZakljucnicaID, string model)
        {

            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "window.open('/Racun.aspx?ID=" + ZakljucnicaID + "&model="+ model +"')", true);
            
        }

        private int VratiIDArtikla()
        {
            Dictionary<string, string> parametri = new Dictionary<string, string>();
            parametri.Add("@ModelID", listModeliVrata.SelectedValue);
            parametri.Add("@DimenzijaID", listDimenzija.SelectedValue);
            parametri.Add("@BojaID", listBojaVrata.SelectedValue);
            parametri.Add("@OrijentacijaVrataID", listOtvaranje.SelectedValue);

            r = RadSaBazom.ParametarskiSelectUpit("SELECT A.ID " +
                                                    "FROM Artikli A JOIN ArtikliVrata AV " +
                                                    "ON A.ID = AV.ArtikliID " +
                                                    "WHERE A.ModelID = @ModelID " +
                                                    "AND AV.DimenzijaID = @DimenzijaID " +
                                                    "AND AV.BojaID = @BojaID " +
                                                    "AND AV.OrijentacijaVrataID =@OrijentacijaVrataID", parametri);

            r.Read();
            int ArtikalID = int.Parse(r[0].ToString());
            r.Close();

            return ArtikalID;
        }

       

        protected void listIzbor_SelectedIndexChanged(object sender, EventArgs e)
        {

           
                OnemoguciKontroleZaPretraguPoImenu();
                pnlIzborModela.Visible = false;
                pnlTalModeli.Visible = false;
                pnlKlasikModel.Visible = false;
                txtPretraga.Text = string.Empty;
           
        }

       
        private void OnemoguciKontroleZaPretraguPoImenu()
        {
            lblMusterija.Visible = false;
            listMusterije.Visible = false;
            lblBrojZakljucnicePretraga.Visible = false;
            listBrojeviZakljucnica.Visible = false;
        }

        protected void btnTrazi_Click(object sender, EventArgs e)
        {

            listMusterije.Items.Clear();
            pnlIzborModela.Visible = false;
            pnlTalModeli.Visible = false;
            OnemoguciKontroleZaPretraguPoImenu();

            if (listIzbor.SelectedIndex == 0) //izabrana je pretraga po broju zakljucnice
            {
                if (txtPretraga.Text == string.Empty)
                {
                    //Poruka korisniku
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Morate uneti broj zaključnice')", true);
                    return;
                }
                PrikaziZakljucnicu(txtPretraga.Text);
            }

            if (listIzbor.SelectedIndex == 1) //izabrana pretraga po imenu i prezimenu
            {
                lblMusterija.Visible = true;
                listMusterije.Visible = true;

                listBrojeviZakljucnica.Items.Clear();

              
                Dictionary<string,string> parametri = new Dictionary<string,string>();
                parametri.Add("@ImePrezime",   txtPretraga.Text + "%");

                //dodavanje poruke dropDown listi musterija
                System.Web.UI.WebControls.ListItem nistaIzabrano = new System.Web.UI.WebControls.ListItem();
                nistaIzabrano.Text = "Izaberite mušteriju";
                nistaIzabrano.Value = "-1";
                listMusterije.Items.Add(nistaIzabrano);
                //////////////////////////////////////////

                r = RadSaBazom.ParametarskiSelectUpit("SELECT * FROM Musterije WHERE ImePrezime LIKE @ImePrezime", parametri);

               while (r.Read())
               {
                   System.Web.UI.WebControls.ListItem l = new System.Web.UI.WebControls.ListItem();
                   l.Text = r[1].ToString() + " adresa: " + r[2].ToString() + " tel: " + r[5].ToString();
                   l.Value = r[0].ToString();

                   listMusterije.Items.Add(l);
               }

               r.Close();


            }

            
        }

        protected void listMusterije_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (listMusterije.SelectedItem != null)
            {
                pnlIzborModela.Visible = false;
                pnlTalModeli.Visible = false;
                pnlKlasikModel.Visible = false;

                lblBrojZakljucnicePretraga.Visible = true;
                listBrojeviZakljucnica.Visible = true;

                listBrojeviZakljucnica.Items.Clear();

                int MusterijaID = Convert.ToInt32(listMusterije.SelectedValue); //id musterije

                Dictionary<string, string> parametri = new Dictionary<string, string>();
                parametri.Add("@MusterijaID", MusterijaID.ToString());

                r = RadSaBazom.ParametarskiSelectUpit("SELECT ID FROM Zakljucnice WHERE MusterijaID = @MusterijaID", parametri);

                //dodavanje poruke dropDown listi zakljucnica
                System.Web.UI.WebControls.ListItem nistaIzabrano = new System.Web.UI.WebControls.ListItem();
                nistaIzabrano.Text = "Izaberite zaključnicu";
                nistaIzabrano.Value = "-1";
                listBrojeviZakljucnica.Items.Add(nistaIzabrano);
                //////////////////////////////////////////
               

                while (r.Read())
                {
                    System.Web.UI.WebControls.ListItem l = new System.Web.UI.WebControls.ListItem();
                    l.Text = r[0].ToString();

                    listBrojeviZakljucnica.Items.Add(l);
                }

                r.Close();

                // ako je izabran naslov kontrole
                if (listMusterije.SelectedIndex == 0)
                {
                    lblBrojZakljucnicePretraga.Visible = false;
                    listBrojeviZakljucnica.Visible = false;
                }
            }

        }

        protected void listBrojeviZakljucnica_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrikaziZakljucnicu(listBrojeviZakljucnica.SelectedItem.Text);
                  
            
        }

        private void PrikaziZakljucnicu(string brojZakljucnice)
        {
            // IMAS BROJ ZAKLJUCNICE KAO ULAZNI PARAMETAR
            // POPUNJAVAS PRODAVCA, MUSTERIJU, DATUM, MODEL i sve ostalo vezano za cenu, napomenu, kolicinu...
            // PROVERA DA LI ZAKLJUCNICA IMA VISE ARTIKALA (IMA - KLASIK, NEMA - TAL (IZLVACIS MODEL))
            // AKO JE TAL ZAKLJUCNICA  ONDA NA OSNOVU ArtikalID biras (???MODELid?????)BOJU, DIMENZIJU, OTVARANJE
            // AKO JE KLASIK ZAKLJUCNICA konstrukcija, brava, kvaka, obloga, boja stoka, gornja brava, cilindar i kolicina


            //ulazni parametar (broj zakljucnice)
            Dictionary<string, string> parametri = new Dictionary<string, string>();
            parametri.Add("@BrojZakljucnice", brojZakljucnice);




            r = RadSaBazom.ParametarskiSelectUpit("SELECT Z.ProdavacID, Z.Datum, Z.Cena, Z.Avans, " +
                                                        "Z.Razlika, Z.KakoSteSaznali, Z.Napomena, Z.BojaStoka, Z.GornjaBrava, M.ImePrezime, M.AdresaDeoGrada, M.Telefon " +
                                                    "FROM Zakljucnice Z JOIN Musterije M " +
                                                    "ON Z.MusterijaID = M.ID " +
                                                    "WHERE Z.ID = @BrojZakljucnice", parametri);


            //NE POSTOJI ZAKLJUCNICA SA UNETIM BROJEM (U SLUCAJU DA SE PRETRAGA VRSI PUTEM BROJA ZAKLJUCNICE)
            if (r.HasRows == false)
            {
                //Poruka korisniku
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Ne postoji zaključnica sa unetim brojem.')", true);
                r.Close();
                return;
            }

            // POSTOJI ZAKLJUCNICA
            r.Read();
            
                string prodavacID = r[0].ToString();
                string datum = string.Format("{0:d MMM, yyyy}", Convert.ToDateTime(r[1].ToString()));
                string cena = String.Format("{0:0.00}",Convert.ToDouble(r[2].ToString()));
                string avans = String.Format("{0:0.00}", Convert.ToDouble(r[3].ToString()));
                string razlika = String.Format("{0:0.00}", Convert.ToDouble(r[4].ToString()));
                string kakoSteSaznali = r[5].ToString();
                string napomena = r[6].ToString();

                string bojaStoka = r.IsDBNull(7) ? "nema" : r[7].ToString(); //////////////////////////// GENIJALNO !!!

                string gornjaBrava = r[8].ToString();
                string imePrezime = r[9].ToString();
                string adresa = r[10].ToString();
                string telefon = r[11].ToString();
            
            r.Close();


            //popunjavanje panela za izbor modela
            pnlIzborModela.Visible = true;

            txtDatum.Text = datum;
            listProdavci.SelectedValue = prodavacID;
            txtImePrezimeMusterije.Text = imePrezime;
            txtAdresaMusterije.Text = adresa;
            txtTelefonMusterije.Text = telefon;


            List<SqlParameter> parametriP = new List<SqlParameter>();
            parametriP.Add(new SqlParameter("@BrojZakljucnice", brojZakljucnice));

            SqlParameter povratnaVrednost = new SqlParameter("@povratnaVrednost", DbType.Int32);
            povratnaVrednost.Direction = ParameterDirection.ReturnValue;
            parametriP.Add(povratnaVrednost);

            //ako je promenljiva redova == 1 onda je model vrata neki od tal modela
            //u suprotnom je model klasik
            int redova = RadSaBazom.spSaVracenomVrednoscu("ProveraModela", parametriP, "@povratnaVrednost");

            // TAL MODELI
            if (redova == 1)
            {
                //izvuci boju, dimenziju i otvaranje i kolicinu na osnovu broja zakljucnice I MODELid !!!!!!!
                r = RadSaBazom.SelectUpit("SELECT A.ModelID, AV.DimenzijaID, AV.BojaID, AV.OrijentacijaVrataID, SZ.Kolicina " +
                                            "FROM Artikli A JOIN (ArtikliVrata AV JOIN StavkaZakljucnice SZ " +
                                            "ON AV.ArtikliID = SZ.ArtikalID) " +
                                            "ON A.ID = AV.ArtikliID " +
                                            "WHERE SZ.ZakljucnicaID = " + brojZakljucnice);
                r.Read();
                
                    string modelID = r[0].ToString();
                    string dimenzijaID = r[1].ToString();
                    string bojaID = r[2].ToString();
                    string otvaranje = r[3].ToString();
                    string kolicina = r[4].ToString();
                
                r.Close();

                listModeliVrata.SelectedValue = modelID;  // izbor modela
                listModeliVrata_SelectedIndexChanged(null, null); // otvaranje odgovarajuceg panela (TAL u zavisnosti od modela)

                //popunjavanje kontrola vrednostima iz zakljucnice
                listBojaVrata.SelectedValue = bojaID;
                listDimenzija.SelectedValue = dimenzijaID;
                listOtvaranje.SelectedValue = otvaranje;
                cbxGornjaBravaTal.Checked = Convert.ToBoolean(gornjaBrava);
                txtKolicinaTal.Text = kolicina;
                txtCenaTalModeli.Text = cena;
                txtAvansTalModeli.Text = avans;
                txtRazlikaTalModeli.Text = razlika;
                txtKakoSteSaznaliTalModeli.Text = kakoSteSaznali;
                txtNapomenaTalModeli.Text = napomena;

            }
            // KLASIK MODEL
            else
            {
                string kolicina = "";

                //izbor i punjenje kontrola panela klasik
                listModeliVrata.SelectedValue = "104";
                listModeliVrata_SelectedIndexChanged(null, null);

                //postavljanje kontrola na vrednosti iz baze
                r = RadSaBazom.SelectUpit("SELECT sz.ArtikalID, Kolicina " +
                                            "FROM StavkaZakljucnice SZ " +
                                            "WHERE ZakljucnicaID = " + brojZakljucnice);

                List<string> artikli = new List<string>();

                while (r.Read())
                {
                    artikli.Add(r[0].ToString());
                    kolicina = r[1].ToString();
                }
                r.Close();

               
                string konstrukcija = artikli[0];
                string brava = artikli[1];
                string kvaka = artikli[2];
                string cilindar = artikli[3];
                string obloga = artikli[4];

                listKonstrukcije.SelectedValue = konstrukcija;
                listBrave.SelectedValue = brava;
                listKvake.SelectedValue = kvaka;
                //da li postoji gornja brava ?
                bool g = cbxGornjaBravaKlasik.Checked = Convert.ToBoolean(gornjaBrava);
                if (g == true)
                {
                    listCilindri.SelectedValue = cilindar;
                    listCilindri.Visible = true;
                    lblCilindar.Visible = true;
                }
                else listCilindri.Visible = false;
                
                // da li postoji boja stoka ?    
                if (bojaStoka != "nema")
                {
                    listBojaStoka.SelectedValue = bojaStoka;
                }
                else listBojaStoka.SelectedValue = "4"; // vrednost je NEMA

                listObloge.SelectedValue = obloga;
                txtKolicinaKlasik.Text = kolicina;
                txtCenaKlasik.Text = cena;
                txtAvansKlasik.Text = avans;
                txtRazlikaKlasik.Text = razlika;
                txtKakoSteSaznaliKlasik.Text = kakoSteSaznali;
                txtNapomenaKlasik.Text = napomena;


            }
            

            //onemogucavanje kontrola koje se koriste za unos zakljucnice
            btnSacuvajTal.Enabled = false;
            btnSacuvajTal.Visible = false;
            btnUpitStanja.Visible = false;
            lblStanje.Visible = false;
            btnSacuvajKlasik.Enabled = false;
            btnSacuvajKlasik.Visible = false;
        }

        protected void btnSacuvajKlasik_Click(object sender, EventArgs e)
        {
            int IdIzabraneMusterije = (int)ViewState["IdIzabraneMusterije"];

            List<SqlParameter> parametri = new List<SqlParameter>();

            parametri.Add(new SqlParameter("@ProdavacID", listProdavci.SelectedValue));
            parametri.Add(new SqlParameter("@MusterijaID", IdIzabraneMusterije.ToString()));
            parametri.Add(new SqlParameter("@Datum", txtDatum.Text));
            parametri.Add(new SqlParameter("@Cena", txtCenaKlasik.Text));
            parametri.Add(new SqlParameter("@Avans", txtAvansKlasik.Text));
            parametri.Add(new SqlParameter("@Razlika", txtRazlikaKlasik.Text));
            parametri.Add(new SqlParameter("@KakoSteSaznali", txtKakoSteSaznaliKlasik.Text));
            parametri.Add(new SqlParameter("@Napomena", txtNapomenaKlasik.Text));
            parametri.Add(new SqlParameter("@BojaStoka", listBojaStoka.SelectedValue)); 
            parametri.Add(new SqlParameter("@GornjaBrava", cbxGornjaBravaKlasik.Checked.ToString()));
            parametri.Add(new SqlParameter("@KonstrukcijaID", listKonstrukcije.SelectedValue));
            parametri.Add(new SqlParameter("@BravaID", listBrave.SelectedValue));
            parametri.Add(new SqlParameter("@KvakaID", listKvake.SelectedValue));
            parametri.Add(new SqlParameter("@CilindarID", cbxGornjaBravaKlasik.Checked == true ? listCilindri.SelectedValue:(object)DBNull.Value));//
            parametri.Add(new SqlParameter("@OblogaID", listObloge.SelectedValue));
            parametri.Add(new SqlParameter("@Kolicina", txtKolicinaKlasik.Text));


            SqlParameter povratnaVrednost = new SqlParameter("@povratnaVrednost", DbType.Int32);
            povratnaVrednost.Direction = ParameterDirection.ReturnValue;
            parametri.Add(povratnaVrednost);

            //IZLAZNI PARAMETAR ID Zakljucnice
             SqlParameter IDZakljucnice = new SqlParameter("@ZakljucnicaID", DbType.Int32);
            IDZakljucnice.Direction = ParameterDirection.Output;
            parametri.Add(IDZakljucnice);

            int vrednostVracena = RadSaBazom.spSaVracenomVrednoscu("UnesiZakljucnicuKlasik", parametri, "@povratnaVrednost");
            

            string poruka = "";


            switch (vrednostVracena)
            {
                case 0: //sve u redu
                    poruka = "Zaključnica je uspešno unesena u bazu.";
                    int ZakljucnicaID = (int)IDZakljucnice.Value;
                    listModeliVrata.SelectedValue = "-1";
                    listModeliVrata_SelectedIndexChanged(null,null);
                    StampajZakljucnicu(ZakljucnicaID, "klasik");
                    
                    break;

                //nema na stanju
                case 6: 
                    poruka = "Nema više izabrane konstrukcije na stanju.";
                    break;

                case 7:
                    poruka = "Nema više izabrane brave na stanju.";
                    break;

                case 8:
                    poruka = "Nema više izabrane kvake na stanju.";
                    break;

                case 9:
                    poruka = "Nema više izabranog cilindra na stanju.";
                    break;

                case 10:
                    poruka = "Nema više izabrane obloge na stanju.";
                    break;

                default: //ostale greske
                    poruka = "Greška u radu sa bazom. Pokušajte ponovo.";
                    break;

            }
            //Poruka korisniku
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + poruka + "')", true);
                  
        }
    
    }
}