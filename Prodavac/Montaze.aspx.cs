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
using System.Globalization;

namespace TALARIS_1
{
    public partial class Montaze : System.Web.UI.Page
    {
        SqlDataReader r = null;
        List<Montaza> listaMontaza = new List<Montaza>();
        List<Montazer> listaMontazera = new List<Montazer>();
        DateTime danasnjiDatum = DateTime.Now;
        CultureInfo ci = new CultureInfo("sr-Latn-CS"); //srpski datum



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NapuniMontazere();
                txtDatum.Text = string.Format("{0:d MMM, yyyy}", DateTime.Now);
                OsveziGridove();

            }

        }

        private void NapuniMontazere()
        {
            listMontazeri.Items.Clear();

            r = RadSaBazom.SelectUpit("select ID, ImePrezime, BrojTelefona from zaposleni where SektorID = 3");

            while (r.Read())
            {
                System.Web.UI.WebControls.ListItem l = new System.Web.UI.WebControls.ListItem();
                l.Value = r[0].ToString();
                l.Text = r[1].ToString() + " " + r[2].ToString();
                listMontazeri.Items.Add(l);
            }

            r.Close();
        }

      

        //POSTAVLJANJE POLJA SMENA
        protected void btnUnesiPrvuSmenu_Click(object sender, EventArgs e)
        {
            DetailsViewMontazeDetalji.Visible = true;
            lblSmena.Text = "700";
            DetailsViewMontazeDetalji.ChangeMode(DetailsViewMode.Insert);

        }

        protected void btnUnesiDruguSmenu_Click(object sender, EventArgs e)
        {
            DetailsViewMontazeDetalji.Visible = true;
            lblSmena.Text = "701";
            DetailsViewMontazeDetalji.ChangeMode(DetailsViewMode.Insert);

        }

        protected void btnUnesiTrecuSmenu_Click(object sender, EventArgs e)
        {
            DetailsViewMontazeDetalji.Visible = true;
            lblSmena.Text = "702";
            DetailsViewMontazeDetalji.ChangeMode(DetailsViewMode.Insert);

        }

        //UPDATE montaze
        //Provera da li su podaci o prvoj smeni ažurirani i ispisivanje poruke korisniku
        protected void sourceGridDetalji_Updated(object sender, SqlDataSourceStatusEventArgs e)
        {
           
            if (e.AffectedRows == 0)
            {
                //Neuspešno ažuriranje
                lblMontazaID.Text = "-1";
                OsveziGridove();
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Drugi korisnik je u međuvremenu izvršio promenu podataka vezanih za ovu montažu. Ažuriranje podataka nije uspelo.')", true);
            }
            else
            {
                //Uspešno ažuriranje
                OsveziGridove();
                DeselektujGridove();
                lblMontazaID.Text = "-1";
               // DetailsViewMontazeDetalji.Visible = false;/////////////////////////////////////////////////////////////////////////////////
                
                
                //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Podaci su uspešno ažurirani.')", true);
                
                
               


            }
        }

        //DELETE montaze
        //Provera da li su podaci o prvoj smeni obrisani i ispisivanje poruke korisniku
        protected void sourceGridDetalji_Deleted(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.AffectedRows == 0)
            {
                //Neuspešno brisanje podataka
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Drugi korisnik je u međuvremenu izvršio promenu ili brisanje podataka vezanih za ovu montažu. Brisanje podataka nije uspelo.')", true);
            }
            else
            {
                //Uspešno brisanje podataka
                OsveziGridove();
                //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Podaci su uspešno obrisani.')", true);
            }
        }

        //INSERT montaze
        protected void sourceGridDetalji_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {
            OsveziGridove();
            DeselektujGridove();

        }

        protected void gridPrvaSmena_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            //deselektovanje ostalih gridova
            gridDrugaSmena.SelectedIndex = -1;
            gridTrecaSmena.SelectedIndex = -1;

            //smestanje ID-a montaze u text labele
            lblMontazaID.Text = gridPrvaSmena.SelectedValue.ToString();

        }

        protected void gridDrugaSmena_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //deselektovanje ostalih gridova
            gridPrvaSmena.SelectedIndex = -1;
            gridTrecaSmena.SelectedIndex = -1;

            //smestanje ID-a montaze u text labele
            lblMontazaID.Text = gridDrugaSmena.SelectedValue.ToString();
        }

        protected void gridTrecaSmena_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //deselektovanje ostalih gridova
            gridDrugaSmena.SelectedIndex = -1;
            gridPrvaSmena.SelectedIndex = -1;

            //smestanje ID-a montaze u text labele
            lblMontazaID.Text = gridTrecaSmena.SelectedValue.ToString();
        }

        //osvezavanje podataka u gridovima
        private void OsveziGridove()
        {
            //prva smena
            gridPrvaSmena.DataBind();
            if (gridPrvaSmena.Rows.Count != 0)
            {
                btnUnesiPrvuSmenu.Visible = false;
                lblPrvaSmenaOznaka.Visible = true;
            }
            else
            {
                btnUnesiPrvuSmenu.Visible = true;
                lblPrvaSmenaOznaka.Visible = false;
            }
            //druga smena
            gridDrugaSmena.DataBind();
            if (gridDrugaSmena.Rows.Count != 0)
            {
                btnUnesiDruguSmenu.Visible = false;
                lblDrugaSmenaOznaka.Visible = true;
            }
            else
            {
                btnUnesiDruguSmenu.Visible = true;
                lblDrugaSmenaOznaka.Visible = false;
            }
            //treca smena
            gridTrecaSmena.DataBind();
            if (gridTrecaSmena.Rows.Count != 0)
            {
                btnUnesiTrecuSmenu.Visible = false;
                lblTrecaSmenaOznaka.Visible = true;
            }
            else
            {
                btnUnesiTrecuSmenu.Visible = true;
                lblTrecaSmenaOznaka.Visible = false;
            }
        }

        //deselektovanje indexa u gridovima
        private void DeselektujGridove()
        {

            gridPrvaSmena.SelectedIndex = -1;
            gridDrugaSmena.SelectedIndex = -1;
            gridTrecaSmena.SelectedIndex = -1;
        }

        protected void btnPrikaziMontaze_Click(object sender, EventArgs e)
        {
            // Create a Document object
            var document = new Document(PageSize.A0);

            // Create a new PdfWriter object, specifying the output stream
            var output = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, output);
            

            // Open the Document for writing
            document.Open();

            // OVDE UBACUJES SADRZAJ U PDF
            ///////////////////////////////////////////////////////////////////////////////////////////////

            //POVUCI BROJ MAJSTORA IZ BAZE U POSEBNOM UPITU
            r = RadSaBazom.SelectUpit("SELECT COUNT(*) " +
                                    "FROM Zaposleni Z " +
                                    "WHERE Z.SektorID = 3");
            int brojMajstora = 0;

            while (r.Read())
            {
                brojMajstora = Convert.ToInt32( r[0].ToString());
            }
            r.Close();

            //POVUCI IMENA I BROJEVE TELEFONA MAJSTORA IZ BAZE
            r = RadSaBazom.SelectUpit("SELECT ID, ImePrezime, BrojTelefona " +
                                    "FROM Zaposleni Z " +
                                    "WHERE Z.SektorID = 3");

            //font za fiksni text u celoj tabeli
            var fontZaSmenuDatumMajstore = iTextSharp.text.FontFactory.GetFont(BaseFont.HELVETICA, BaseFont.CP1257, 12, iTextSharp.text.Font.BOLD);

            //UBACI U TABELU IMENA MAJSTORA I BROJEVE TELEFONA
            PdfPTable table = new PdfPTable(brojMajstora + 2);

            //datum kolona
            PdfPCell datum = new PdfPCell(new Phrase("DATUM", fontZaSmenuDatumMajstore));
            datum.HorizontalAlignment = 1;
            table.AddCell(datum);

            //Smena kolona
            PdfPCell smena = new PdfPCell(new Phrase("SMENA", fontZaSmenuDatumMajstore));
            smena.HorizontalAlignment = 1;
            table.AddCell(smena);

            //isprazni listu montazera
            listaMontazera.Clear();

           
            while (r.Read())
            {
                int id = Convert.ToInt32(r[0].ToString());
                string ime = r[1].ToString();
                string telefon = r[2].ToString();

                //napuni listu montazera
                listaMontazera.Add(new Montazer(id, ime, telefon));

               

                PdfPCell cell = new PdfPCell(new Phrase(ime + " " + telefon, fontZaSmenuDatumMajstore));
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);
            }
            r.Close();


            //napuni listu montaza
            napuniListuMontaza();


            //UBACI DATUME ZA 7 POSLEDNJIH DANA
            for (int i = 0; i < 37; i++)
            {
                //DATUM/////////////////////////////////////////////////////
                //tabela sa datumima
                var fontZaDatum = iTextSharp.text.FontFactory.GetFont(BaseFont.HELVETICA, BaseFont.CP1257, 10, iTextSharp.text.Font.BOLD);
                var fontZaSmene = iTextSharp.text.FontFactory.GetFont(BaseFont.HELVETICA, BaseFont.CP1257, 8);
                string datumFormatiran = danasnjiDatum.AddDays(-7 + i).ToString("dd. MMMM yyyy", ci) + Environment.NewLine + danasnjiDatum.AddDays(-7 + i).ToString("dddd", ci);

                PdfPTable datumTabela = new PdfPTable(1);
                PdfPCell celija = new PdfPCell(new Phrase(datumFormatiran, new iTextSharp.text.Font(fontZaDatum)));
                celija.HorizontalAlignment = 1;
                datumTabela.AddCell(celija);

                //HOST celija za datume
                PdfPCell celijaSaDatumTabelom = new PdfPCell(datumTabela);
                table.AddCell(celijaSaDatumTabelom);
                /////////////////////////////////////////////////////////////////////////////

                //SMENA//////////////////////////////////////////////////////////////////////
                //tabela sa smenama
                PdfPTable smenaTabela = new PdfPTable(1);

                PdfPCell prvaSmena = new PdfPCell(new Phrase("1", fontZaSmene));
                prvaSmena.HorizontalAlignment = 1;
                prvaSmena.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.Bisque);

                PdfPCell drugaSmena = new PdfPCell(new Phrase("2", fontZaSmene));
                drugaSmena.HorizontalAlignment = 1;

                PdfPCell trecaSmena = new PdfPCell(new Phrase("3", fontZaSmene));
                trecaSmena.HorizontalAlignment = 1;
                trecaSmena.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightGray);

                smenaTabela.AddCell(prvaSmena);
                smenaTabela.AddCell(drugaSmena);
                smenaTabela.AddCell(trecaSmena);


               

                //HOST celija za smene
                PdfPCell celijaSaSmenama = new PdfPCell(smenaTabela);
                celijaSaSmenama.HorizontalAlignment = 1;
                table.AddCell(celijaSaSmenama);
                /////////////////////////////////////////////////////////////////////////////

                //MONTAZE PO MAJSTORU/////////////////////////////////////////////////////////////

                PdfPCell montazaPrvaSmena = new PdfPCell();
                PdfPCell montazaDrugaSmena = new PdfPCell();
                PdfPCell montazaTrecaSmena = new PdfPCell();
               
                
                foreach (Montazer majstor in listaMontazera)
                {
                    bool postojiPrvaSmena = false;
                    bool postojiDrugaSmena = false;
                    bool postojiTrecaSmena = false;

                    //Prva smena
                    foreach (Montaza m in listaMontaza)
                    {
                        if ((majstor.Id == m.MontazerID) && (m.SmenaID == 700) && (String.Format("{0:yyyy-MM-dd}", danasnjiDatum.AddDays(-7+i)) == String.Format("{0:yyyy-MM-dd}", m.Datum)))
                        {
                            montazaPrvaSmena.Phrase = new Phrase(m.ToString(), fontZaSmene); 
                            montazaPrvaSmena.HorizontalAlignment = 1;
                            montazaPrvaSmena.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.Bisque);
                            postojiPrvaSmena = true; //ubaci bool vrednost da vidis da li postoji
                            
                        }
                    }
                    if (postojiPrvaSmena == false)
                    {
                        montazaPrvaSmena.Phrase = new Phrase("NEMA",fontZaSmene);
                        montazaPrvaSmena.HorizontalAlignment = 1;
                        montazaPrvaSmena.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.Bisque);
                    }

                    //DRUGA smena
                    foreach (Montaza m in listaMontaza)
                    {
                        if ((majstor.Id == m.MontazerID) && (m.SmenaID == 701) && (String.Format("{0:yyyy-MM-dd}", danasnjiDatum.AddDays(-7+i)) == String.Format("{0:yyyy-MM-dd}", m.Datum)))
                        {
                            montazaDrugaSmena.Phrase = new Phrase(m.ToString(), fontZaSmene);
                            montazaDrugaSmena.HorizontalAlignment = 1;
                            postojiDrugaSmena = true; //ubaci bool vrednost da vidis da li postoji

                        }
                    }
                    if (postojiDrugaSmena == false)
                    {
                        montazaDrugaSmena.Phrase = new Phrase("NEMA", fontZaSmene);
                        montazaDrugaSmena.HorizontalAlignment = 1;
                    }

                    //TRECA smena
                    foreach (Montaza m in listaMontaza)
                    {
                        if ((majstor.Id == m.MontazerID) && (m.SmenaID == 702) && (String.Format("{0:yyyy-MM-dd}", danasnjiDatum.AddDays(-7+i)) == String.Format("{0:yyyy-MM-dd}", m.Datum)))
                        {
                            montazaTrecaSmena.Phrase = new Phrase(m.ToString(), fontZaSmene);
                            montazaTrecaSmena.HorizontalAlignment = 1;
                            montazaTrecaSmena.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightGray);
                            postojiTrecaSmena = true; //ubaci bool vrednost da vidis da li postoji

                        }
                    }
                    if (postojiTrecaSmena == false)
                    {
                        montazaTrecaSmena.Phrase = new Phrase("NEMA", fontZaSmene);
                        montazaTrecaSmena.HorizontalAlignment = 1;
                        montazaTrecaSmena.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightGray);

                    }
                    
                    PdfPTable montaza = new PdfPTable(1);
                    montaza.AddCell(montazaPrvaSmena);
                    montaza.AddCell(montazaDrugaSmena);
                    montaza.AddCell(montazaTrecaSmena);


                    //HOST montaze po majstoru
                    PdfPCell celijaSaMontazamaPoMajstoru = new PdfPCell(montaza);
                    celijaSaMontazamaPoMajstoru.HorizontalAlignment = 1;
                    table.AddCell(celijaSaMontazamaPoMajstoru);
                    ////////////////////////////////////////////////////////////////////////////
                  
                }

            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////
     
            document.Add(table);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            // Close the Document - this saves the document contents to the output stream
            document.Close();


            //Otvaranje PDF Racuna u prozoru browser-a
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(output.ToArray());
            Response.End();
        }

        private void napuniListuMontaza()
        {
            listaMontaza.Clear();

            r = RadSaBazom.SelectUpit(" SELECT M.ID, M.MontazerID, M.SmenaID, M.SalonID, M.BravarskaUslugaID, M.MoraTajMajstor, " +
                                             "M.PrezimeAdresa, MO.ImeModela, M.Datum " +
                                        "FROM Montaze M JOIN ModelArtikla MO " +
                                        "ON M.ModelVrata = MO.ID " +
                                        "WHERE M.Datum >= '" + String.Format("{0:yyyy-MM-dd}", danasnjiDatum.AddDays(-7)) + "'" );
            

            if (r != null)
            {

                while (r.Read())
                {
                    int id = Convert.ToInt32(r[0].ToString());
                    int montazerID = Convert.ToInt32(r[1].ToString());
                    int smenaID = Convert.ToInt32(r[2].ToString());
                    int salonID = Convert.ToInt32(r[3].ToString());
                    string bravarskaUslugaID = r[4].ToString();
                    bool moraTajMajstor = Convert.ToBoolean(r[5].ToString());
                    string prezimeAdresa = r[6].ToString();
                    string modelVrata = r[7].ToString();
                    DateTime datum = Convert.ToDateTime(r[8].ToString());

                    listaMontaza.Add(new Montaza(id, montazerID, smenaID, salonID, bravarskaUslugaID, moraTajMajstor, prezimeAdresa, modelVrata, datum));

                   
                }

                r.Close();
            }

        }

        protected void listMontazeri_SelectedIndexChanged(object sender, EventArgs e)
        {
            OsveziGridove();
        }

        protected void txtDatum_TextChanged(object sender, EventArgs e)
        {
            OsveziGridove();
        }

       

    }
}
