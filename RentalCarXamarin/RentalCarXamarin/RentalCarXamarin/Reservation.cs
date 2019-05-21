using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCarXamarin
{
    public class Reservation
    {
        private int id;
        private Stazioni retStation;
        private Stazioni recStation;
        private CarItem car;
        private String email;
        private String dateRetire;
        private String dateRestitution;
        private int payment;
        private double price;

        public Reservation(int id, Stazioni retStation, Stazioni recStation, CarItem car, String email, String dateRetire, String dateRestitution, int payment, double price)
        {
            this.id = id;
            this.retStation = retStation;
            this.recStation = recStation;
            this.car = car;
            this.email = email;
            this.dateRetire = dateRetire;
            this.dateRestitution = dateRestitution;
            this.payment = payment;
            this.price = price;
        }

    }
}
