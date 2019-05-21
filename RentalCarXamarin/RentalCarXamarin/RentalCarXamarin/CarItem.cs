using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCarXamarin
{
    public class CarItem
    {
        //int resIdImage { get; set; }//id dell'immagine della macchina
        public String Model { get; set; }//nome dell'auto
        public String ClassCar { get; set; }//classe dell'auto
        public double Pricegg { get; set; }//prezzo giornaliero
        public String Shift { get; set; }//cambio
        public int Number { get; set; }//numero di posti

        public CarItem( String Model, String ClassCar, double Pricegg, String Shift, int Number)
        {
            //this.resIdImage = resIdImage;
            this.Model = Model;
            this.ClassCar = ClassCar;
            this.Pricegg = Pricegg;
            this.Shift = Shift;
            this.Number = Number;
        }
    }
}
