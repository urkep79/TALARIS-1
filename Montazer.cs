using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TALARIS_1
{
    public class Montazer
    {
        //polja
        int id;      
        string imePrezime;   
        string brojTelefona;

       

        //PROPERTY
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string ImePrezime
        {
            get { return imePrezime; }
            set { imePrezime = value; }
        }
        public string BrojTelefona
        {
            get { return brojTelefona; }
            set { brojTelefona = value; }
        }

        //konstruktor
        public Montazer(int id, string imePrezime, string brojTelefona)
        {
            this.id = id;
            this.imePrezime = imePrezime;
            this.brojTelefona = brojTelefona;
        }
    }
}