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
    public partial class Racun : System.Web.UI.Page
    {
        SqlDataReader r = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            string model = Request.QueryString["model"];

            if (model == "tal")
            {
                PrikaziPDFZakljucniceTAL();
            }
            else PrikaziPDFZakljucniceKLASIK();
            
        }

        private void PrikaziPDFZakljucniceKLASIK()
        {
            string zakljucnicaID = Request.QueryString["ID"];

            List<SqlParameter> parametri = new List<SqlParameter>();

            //ULAZNI PARAMETAR
            parametri.Add(new SqlParameter("@ZakljucnicaID",Convert.ToInt32(zakljucnicaID)));


            r = RadSaBazom.sprocBolja("StavkeKlasikZakljucnice", parametri);

            
            if (r == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Greška u radu sa bazom.')", true);
                return;
            }
            else
            {
                r.Read();
                
                    string cilindar = r[0].ToString();
                    string brava = r[1].ToString();
                    string obloga = r[2].ToString();
                    string kvaka = r[3].ToString();
                    string klasikID = r[4].ToString();
                
                r.Close();

                r = RadSaBazom.SelectUpit("SELECT Z.ID, Z.Datum, M.ImePrezime, M.AdresaDeoGrada, M.Telefon, M.Email, M.Sprat, M.Stan, D.Dimenzija, OV.Otvaranje, " +
                                    "B.Boja AS[BojaStoka], Z.GornjaBrava, Z.Cena,Z.Avans, Z.Razlika, Z.Napomena, Z.KakoSteSaznali " +
                                "FROM Boja B JOIN (OrijentacijaVrata OV JOIN (Dimenzija D JOIN (ArtikliVrata AV JOIN  " +
                                    "(Artikli A JOIN (StavkaZakljucnice SZ JOIN " +
                                    "(Zakljucnice Z JOIN Musterije M " +
                                "ON Z.MusterijaID = M.ID) " +
                                "ON SZ.ZakljucnicaID = Z.ID) " +
                                "ON A.ID = SZ.ArtikalID) " +
                                "ON AV.ArtikliID = A.ID) " +
                                "ON D.ID = AV.DimenzijaID) " +
                                "ON OV.ID = AV.OrijentacijaVrataID) " +
                                "ON B.ID = Z.BojaStoka " +
                                "WHERE Z.ID =  " + zakljucnicaID +
                                "AND A.ModelID = " + klasikID);

                if (r != null)
                {
                    r.Read();

                    string brojZakljucnice = r[0].ToString();
                    string datum = string.Format("{0:d. MMM yyyy.}", Convert.ToDateTime(r[1].ToString()));
                    string imePrezime = r[2].ToString().ToUpper();
                    string adresa = r[3].ToString();
                    string telefon = r[4].ToString();
                    string email = r[5].ToString();
                    string sprat = r[6].ToString();
                    string stan = r[7].ToString();
                    string imeModela = "KLASIK";
                    string dimenzija = r[8].ToString();
                    string boja = "/";
                    string otvaranje = r[9].ToString();
                    string bojaStoka = r[10].ToString();
                    string gornjaBrava = r[11].ToString() == "True" ? "1" : "0";
                    string cena = String.Format("{0:0.00}", Convert.ToDouble(r[12].ToString()));
                    string avans = String.Format("{0:0.00}", Convert.ToDouble(r[13].ToString()));
                    string razlika = String.Format("{0:0.00}", Convert.ToDouble(r[14].ToString()));

                    string napomena = Environment.NewLine + Environment.NewLine + r[15].ToString() +
                        Environment.NewLine + Environment.NewLine + "Cilindar: " + cilindar
                      + Environment.NewLine + Environment.NewLine + "Brava: " + brava
                      + Environment.NewLine + Environment.NewLine + "Obloga: " + obloga
                      + Environment.NewLine + Environment.NewLine + "Kvaka: " + kvaka;

                    string kakoSteSaznali = r[16].ToString();

                    r.Close();

                    //dodeljivanje vrednosti poljima u PDF racunu
                    PdfReader reader = new PdfReader(Server.MapPath("~/pdfRacun/talarisRacun.pdf"));
                    MemoryStream output = new MemoryStream();
                    PdfStamper stamper = new PdfStamper(reader, output);

                    //ovde se stvarno vrsi dodela
                    stamper.AcroFields.SetField("txtBrojRacuna", brojZakljucnice);
                    stamper.AcroFields.SetField("txtDatum", datum);
                    stamper.AcroFields.SetField("txtImePrezime", imePrezime);
                    stamper.AcroFields.SetField("txtAdresaDeoGrada", adresa);
                    stamper.AcroFields.SetField("txtTelefon", telefon);
                    stamper.AcroFields.SetField("txtEmail", email);
                    stamper.AcroFields.SetField("txtSprat", sprat);
                    stamper.AcroFields.SetField("txtStan", stan);
                    stamper.AcroFields.SetField("txtModel", imeModela);
                    stamper.AcroFields.SetField("txtDimenzija", dimenzija);
                    stamper.AcroFields.SetField("txtBojaVrata", boja);
                    stamper.AcroFields.SetField("txtOtvaranje", otvaranje);
                    stamper.AcroFields.SetField("txtStok", bojaStoka);
                    stamper.AcroFields.SetField("cbxGornjaBrava", gornjaBrava);
                    stamper.AcroFields.SetField("txtCena", cena);
                    stamper.AcroFields.SetField("txtAvans", avans);
                    stamper.AcroFields.SetField("txtRazlika", razlika);
                    stamper.AcroFields.SetField("txtNapomena", napomena);
                    stamper.AcroFields.SetField("txtKakoSteSaznali", kakoSteSaznali);

                    // ONEMOGUCAVANJE EDITOVANJA POLJA
                    stamper.FormFlattening = true;

                    stamper.Close();
                    reader.Close();

                    //Response.AddHeader("Slanje sadrzaja racuna", "attachment; filename=VasPDF.pdf"); /////// SLANJE PDF FAJLA ZA DOWNLOAD

                    //Otvaranje PDF Racuna u prozoru browser-a
                    Response.ContentType = "application/pdf";
                    Response.BinaryWrite(output.ToArray());
                    
                    Response.End();

                }




            }
        }

        private void PrikaziPDFZakljucniceTAL()
        {
            r = RadSaBazom.SelectUpit("SELECT Z.ID, Z.Datum, M.ImePrezime, M.AdresaDeoGrada, M.Telefon, M.Email, M.Sprat, " +     //otvoris novu stranu, izvrsis upit
                                         "M.Stan, MA.ImeModela, D.Dimenzija, B.Boja, OV.Otvaranje, " +
                                         "Z.BojaStoka, Z.GornjaBrava, Z.Cena,Z.Avans, Z.Razlika, Z.Napomena, Z.KakoSteSaznali " +
                                     "FROM OrijentacijaVrata OV JOIN (Boja B JOIN(Dimenzija D JOIN " +
                                         "(ArtikliVrata AV JOIN (ModelArtikla MA JOIN(Artikli A JOIN " +
                                         "(Musterije M JOIN(Zakljucnice Z JOIN StavkaZakljucnice SZ " +
                                     "ON Z.ID = SZ.ZakljucnicaID) " +
                                     "ON M.ID = Z.MusterijaID) " +
                                     "ON A.ID = SZ.ArtikalID) " +
                                     "ON MA.ID = A.ModelID) " +
                                     "ON AV.ArtikliID = A.ID) " +
                                     "ON D.ID = AV.DimenzijaID) " +
                                     "ON B.ID = AV.BojaID) " +
                                     "ON OV.ID = AV.OrijentacijaVrataID " +
                                     "WHERE Z.ID = " + Request.QueryString["ID"]);
            if (r != null)
            {
                r.Read();

                string brojZakljucnice = r[0].ToString();
                string datum = string.Format("{0:d. MMM yyyy.}", Convert.ToDateTime(r[1].ToString()));
                string imePrezime = r[2].ToString().ToUpper();
                string adresa = r[3].ToString();
                string telefon = r[4].ToString();
                string email = r[5].ToString();
                string sprat = r[6].ToString();
                string stan = r[7].ToString();
                string imeModela = r[8].ToString();
                string dimenzija = r[9].ToString();
                string boja = r[10].ToString();
                string otvaranje = r[11].ToString();
                string bojaStoka = r.IsDBNull(12) ? "NEMA" : r[12].ToString(); //////////////////////////// GENIJALNO !!!
                string gornjaBrava = r[13].ToString() == "True" ? "1" : "0";
                string cena = String.Format("{0:0.00}", Convert.ToDouble(r[14].ToString()));
                string avans = String.Format("{0:0.00}", Convert.ToDouble(r[15].ToString()));
                string razlika = String.Format("{0:0.00}", Convert.ToDouble(r[16].ToString()));
                string napomena = Environment.NewLine + Environment.NewLine + r[17].ToString();
                string kakoSteSaznali = r[18].ToString();

                r.Close();


                //dodeljivanje vrednosti poljima u PDF racunu
                PdfReader reader = new PdfReader(Server.MapPath("~/pdfRacun/talarisRacun.pdf"));
                MemoryStream output = new MemoryStream();
                PdfStamper stamper = new PdfStamper(reader, output);

                //ovde se stvarno vrsi dodela
                stamper.AcroFields.SetField("txtBrojRacuna", brojZakljucnice);
                stamper.AcroFields.SetField("txtDatum", datum);
                stamper.AcroFields.SetField("txtImePrezime", imePrezime);
                stamper.AcroFields.SetField("txtAdresaDeoGrada", adresa);
                stamper.AcroFields.SetField("txtTelefon", telefon);
                stamper.AcroFields.SetField("txtEmail", email);
                stamper.AcroFields.SetField("txtSprat", sprat);
                stamper.AcroFields.SetField("txtStan", stan);
                stamper.AcroFields.SetField("txtModel", imeModela);
                stamper.AcroFields.SetField("txtDimenzija", dimenzija);
                stamper.AcroFields.SetField("txtBojaVrata", boja);
                stamper.AcroFields.SetField("txtOtvaranje", otvaranje);
                stamper.AcroFields.SetField("txtStok", bojaStoka);
                stamper.AcroFields.SetField("cbxGornjaBrava", gornjaBrava);
                stamper.AcroFields.SetField("txtCena", cena);
                stamper.AcroFields.SetField("txtAvans", avans);
                stamper.AcroFields.SetField("txtRazlika", razlika);
                stamper.AcroFields.SetField("txtNapomena", napomena);
                stamper.AcroFields.SetField("txtKakoSteSaznali", kakoSteSaznali);

                // ONEMOGUCAVANJE EDITOVANJA POLJA
                stamper.FormFlattening = true;

                stamper.Close();
                reader.Close();

                //Response.AddHeader("Slanje sadrzaja racuna", "attachment; filename=VasPDF.pdf"); /////// SLANJE PDF FAJLA ZA DOWNLOAD

                //Otvaranje PDF Racuna u prozoru browser-a
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(output.ToArray());

                Response.End();
            }
        }
    }
}
