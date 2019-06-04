using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCarXamarin
{
    class Segnalazione
    {
        public String Problema { get; set; }//problema

        public Segnalazione(String Problema)
        {
            this.Problema = Problema;
        }
    }
}
