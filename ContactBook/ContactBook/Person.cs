using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
    public class Person
    {
        public string name, email, phoneNum, address, notes;
        public DateTime birthdate;

        public string Name{
            get { return name; }
        }

        public Person() {
            name = "New Person";
            email = "";
            phoneNum = "";
            address = "";
            notes = "";
            birthdate = DateTime.Today;
        }
        ~Person() {
            
        }


    }
}
