using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TALARIS_1
{
    public class Montaza
    {
        /*  SELECT M.ID, M.MontazerID, M.SmenaID, M.SalonID, M.BravarskaUslugaID, M.MoraTajMajstor,
	             M.PrezimeAdresa, MO.ImeModela, M.Datum
            FROM Montaze M JOIN ModelArtikla MO
            ON M.ModelVrata = MO.ID   */


        //polja
        int id;
        int montazerID;
        int smenaID;   
        int salonID;
        string bravarskaUslugaID;
        bool moraTajMajstor;
        string prezimeAdresa;
        string modelVrata;  
        DateTime datum;

       

        //PROPERTY
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int MontazerID
        {
            get { return montazerID; }
            set { montazerID = value; }
        }

        public int SmenaID
        {
            get { return smenaID; }
            set { smenaID = value; }
        }

        public int SalonID
        {
            get { return salonID; }
            set { salonID = value; }
        }

        public string BravarskaUslugaID
        {
            get { return bravarskaUslugaID; }
            set { bravarskaUslugaID = value; }
        }

        public bool MoraTajMajstor
        {
            get { return moraTajMajstor; }
            set { moraTajMajstor = value; }
        }

        public string PrezimeAdresa
        {
            get { return prezimeAdresa; }
            set { prezimeAdresa = value; }
        }

        public string ModelVrata
        {
            get { return modelVrata; }
            set { modelVrata = value; }
        }

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        //konstruktor
        public Montaza(int id, int montazerID, int smenaID, int salonID, string bravarskaUslugaID, bool moraTajMajstor, string prezimeAdresa, string modelVrata, DateTime datum)
        {
            this.id = id;
            this.montazerID = montazerID;
            this.smenaID = smenaID;
            this.salonID = salonID;
            this.bravarskaUslugaID = bravarskaUslugaID;
            this.moraTajMajstor = moraTajMajstor;
            this.prezimeAdresa = prezimeAdresa;
            this.modelVrata = modelVrata;
            this.datum = datum;
        }

        //prikaz
        override public string ToString()
        {
            
            if (modelVrata == "TAL 1")
            {
                modelVrata = "1";
            }

            if (modelVrata == "TAL 2")
            {
                modelVrata = "2";
            }

            if (modelVrata == "TAL 3")
            {
                modelVrata = "3";
            }

            if (modelVrata == "TAL 4")
            {
                modelVrata = "4";
            }

            if (modelVrata == "KONSTRUKCIJA (KLASIK)")
            {
                modelVrata = "K";
            }


            return prezimeAdresa + " (" + modelVrata + ")" + " (" + bravarskaUslugaID + ")" +  ((moraTajMajstor == true) ? "(*)" : ""); 
        }



    }
}