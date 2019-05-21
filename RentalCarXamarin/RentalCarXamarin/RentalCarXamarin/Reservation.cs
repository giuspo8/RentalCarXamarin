using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCarXamarin
{
    public class Reservation
    {
        public int id;
        public Stazioni retStation;
        public Stazioni recStation;
        public String car;
        public String email;
        public String dateRetire;
        public String dateRestitution;
        public int payment;
        public double price;

        public Reservation(Stazioni retStation, Stazioni recStation, String car, String email, String dateRetire, String dateRestitution, int payment, double price)
        {
            this.retStation = retStation;
            this.recStation = recStation;
            this.car = car;
            this.email = email;
            this.dateRetire = dateRetire;
            this.dateRestitution = dateRestitution;
            this.payment = payment;
            this.price = price;
        }
        public Reservation(int id, Stazioni retStation, Stazioni recStation, String car, String email, String dateRetire, String dateRestitution, int payment, double price)
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
