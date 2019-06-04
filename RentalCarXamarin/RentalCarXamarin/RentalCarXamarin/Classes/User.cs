using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCarXamarin
{
    public class User
    {
        public String Email;
        public String Nome;
        public String Cognome;
        public String Telefono;

        public User(String Email,String Nome,String Cognome,String Telefono)
        {
            this.Email = Email;
            this.Nome = Nome;
            this.Cognome = Cognome;
            this.Telefono = Telefono;
        }

    }
}
