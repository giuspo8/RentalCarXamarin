using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCarXamarin
{
    public class CarItem
    {
        int resIdImage { get; set; }//id dell'immagine della macchina
        String carName { get; set; }//nome dell'auto
        String classCar { get; set; }//classe dell'auto
        double priceGg { get; set; }//prezzo giornaliero
        String carShift { get; set; }//cambio
        int numberOfPassengers { get; set; }//numero di posti

        public CarItem(String carName)
        {
            this.carName = carName;
        }

        public CarItem(int resIdImage, String carName, String classCar, double priceGg, String carShift, int numberOfPassengers)
        {
            this.resIdImage = resIdImage;
            this.carName = carName;
            this.classCar = classCar;
            this.priceGg = priceGg;
            this.carShift = carShift;
            this.numberOfPassengers = numberOfPassengers;
        }
    }
}
