using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class Person
    {
        private readonly int id;
        private string firstName;
        private string lastName;

        //------------- constructor to intialize private fields specialy id ---------------//
        public Person(int id , string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        //------------- public properties to access private field while getting and setting ---------------//

        //********** FOR ID ************//
        public int Id => this.id;

        //********** FOR FIRST NAME ************//
        public string FirstName
        {
            get => this.firstName; 
            set
            {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentNullException("First Name could not be null or empty.");
                }
                else
                    this.firstName = value;
            }
        }

        //********** FOR LAST NAME ************//
        public string LastName
        {
            get => this.lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last Name could not be null or empty.");
                }
                else
                    this.lastName = value;
            }
        }
    }
}
