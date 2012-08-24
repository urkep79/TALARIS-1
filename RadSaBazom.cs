using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace TALARIS_1
{
    

    public class RadSaBazom 
    {
        public static string greska;

        //ovo sam ubacio da bi radilo na serveru umesto konekcije dole zakomentirane
        public static string konekcioniString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        public static SqlConnection konekcija = new SqlConnection(konekcioniString);


        //public static SqlConnection konekcija =
           // new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TalarisArtikli;Integrated Security=True");

        //SELECT KOMANDA
        public static SqlDataReader SelectUpit(string upit)
        {
            greska = "";
            SqlCommand komanda = new SqlCommand(upit, konekcija);

            SqlDataReader r = null;

            try
            {
                konekcija.Open();
                r = komanda.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception ex)
            {
                greska = ex.Message;
                
            }
            
            return r;
        }

      //PARAMETRIZOVANA SELECT KOMANDA
        public static SqlDataReader ParametarskiSelectUpit(string upit, Dictionary<string, string> parametri)
        {
            greska = "";
            SqlCommand komanda = new SqlCommand(upit, konekcija);

            foreach (KeyValuePair<string, string> parametar in parametri)
            {
                SqlParameter p = new SqlParameter(parametar.Key, parametar.Value);
                komanda.Parameters.Add(p);
            }
            

            SqlDataReader r = null;

            try
            {
                konekcija.Open();
                r = komanda.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception ex)
            {
                greska = ex.Message;

            }

            return r;
        }

        //INSERT, DELETE ILI UPDATE KOMANDA
        public static bool UpdateUpit(string upit)
        {
            SqlCommand komanda = new SqlCommand(upit, konekcija);

            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();
                konekcija.Close();
                return true;
            }
            catch (Exception ex)
            {
                konekcija.Close();
                
                return false;
            }
        }

        //PARAMETRIZOVANI INSERT, UPDATE  I DELETE UPIT
        public static bool InsertUpdateDeleteSaParametrima(string upit, Dictionary<string, string> parametri)
        {
            greska = "";
            SqlCommand komanda = new SqlCommand(upit, konekcija);

            //dodavanje parametara komandi
            foreach (KeyValuePair<string, string> parametar in parametri)
            {
                SqlParameter p = new SqlParameter(parametar.Key, parametar.Value);
                komanda.Parameters.Add(p);
            }

            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();
                konekcija.Close();
                

            }
            catch (Exception ex)
            {
                konekcija.Close();
                greska = ex.Message;
                return false;
            }

            return true;

        }

        //STORED PROCEDURA
        public static int SProcedura(string naziv, Dictionary<string, string> parametri)
        {
            SqlCommand komanda = new SqlCommand();
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Connection = konekcija;
            komanda.CommandText = naziv;

            //parametri
            foreach (KeyValuePair<string, string> param in parametri)
            {
                SqlParameter p = new SqlParameter(param.Key, param.Value);
                komanda.Parameters.Add(p);
            }

            int rez;
            try
            {
                konekcija.Open();
                rez = Convert.ToInt32(komanda.ExecuteScalar());
                konekcija.Close();
                return rez;
            }
            catch (Exception ex)
            {
                konekcija.Close();
                
                return -1;
            }


        }

        //STORED PROCEDURA ZA ASP
        public static int sProceduraAsp(string naziv, Dictionary<string, string> parametri)
        {
            greska = "";

            SqlCommand komanda = new SqlCommand();
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Connection = konekcija;
            komanda.CommandText = naziv;

            //parametri
            foreach (KeyValuePair<string, string> param in parametri)
            {
                SqlParameter p = new SqlParameter(param.Key, param.Value);
                komanda.Parameters.Add(p);
            }

            int rez;
            try
            {
                konekcija.Open();
                rez = Convert.ToInt32(komanda.ExecuteScalar());
                konekcija.Close();
                return rez;
            }
            catch (Exception ex)
            {
                konekcija.Close();
                greska = ex.Message;
                return -1;
            }
        }

        //STORED PROCEDURA KOJA VRACA ID UNETOG
        public static int spSaVracenomVrednoscu(string nazivProc, List<SqlParameter> parametri, string imePovratnogParametra)
        {
            SqlCommand komanda = new SqlCommand();
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Connection = konekcija;
            komanda.CommandText = nazivProc;
            
            int povratnaVrednost;

                    foreach (SqlParameter p in parametri)
                    {
                        komanda.Parameters.Add(p);
                    }

                    try
                    {
                        konekcija.Open();
                        komanda.ExecuteNonQuery();
                        povratnaVrednost = (int)komanda.Parameters[imePovratnogParametra].Value;
                        konekcija.Close();
                        return povratnaVrednost;
                    }
                    catch
                    {
                        konekcija.Close();
                        return -1;
                    }
                        
        }

        //SELECT PROCEDURA
        public static SqlDataReader sprocBolja(string naziv, List<SqlParameter> parametri)
        {
            SqlCommand komanda = new SqlCommand();
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Connection = konekcija;
            komanda.CommandText = naziv;

            foreach (SqlParameter p in parametri)
            {
                komanda.Parameters.Add(p);
            }

            SqlDataReader r = null;
            try
            {
                konekcija.Open();
                r= komanda.ExecuteReader(CommandBehavior.CloseConnection);
                
                
            }
            catch
            {
                konekcija.Close();   
            }
            return r;

        }


       
       
    }
}
    