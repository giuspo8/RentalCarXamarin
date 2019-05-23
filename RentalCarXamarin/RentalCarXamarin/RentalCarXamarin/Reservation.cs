using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCarXamarin
{
    public class Reservation
    {
        public int ID { get; set; }
        public String StazioneRit { get; set; }
        public String StazioneRic { get; set; }
        public String Macchina { get; set; }
        public String Email { get; set; }
        public String DataRitiro { get; set; }
        public String DataRestituzione { get; set; }
        public int Pagamento { get; set; }
        public double Prezzo { get; set; }

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
        
        public Reservation() { }

    }
}
