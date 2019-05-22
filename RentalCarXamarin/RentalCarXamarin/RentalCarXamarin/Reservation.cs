using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCarXamarin
{
    public class Reservation
    {
        public int ID;
        public String StazioneRit;
        public String StazioneRic;
        public String Macchina;
        public String Email;
        public String DataRitiro;
        public String DataRestituzione;
        public int Pagamento;
        public double Prezzo;

        public Reservation(String StazioneRit, String StazioneRic, String Macchina, String Email, String DataRitiro, String DataRestituzione, int Pagamento, double Prezzo)
        {
            this.StazioneRit = StazioneRit;
            this.StazioneRic = StazioneRic;
            this.Macchina = Macchina;
            this.Email = Email;
            this.DataRitiro = DataRitiro;
            this.DataRestituzione = DataRestituzione;
            this.Pagamento = Pagamento;
            this.Prezzo = Prezzo;
        }
        public Reservation(int ID, String StazioneRit, String StazioneRic, String Macchina, String DataRitiro, String DataRestituzione, int Pagamento, String Email, double Prezzo)
        {
            this.ID = ID;
            this.StazioneRit = StazioneRit;
            this.StazioneRic = StazioneRic;
            this.Macchina = Macchina;
            this.Email = Email;
            this.DataRitiro = DataRitiro;
            this.DataRestituzione = DataRestituzione;
            this.Pagamento = Pagamento;
            this.Prezzo = Prezzo;
        }
        public Reservation() { }

    }
}
