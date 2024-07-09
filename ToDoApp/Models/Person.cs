namespace ToDoApp.Models
{
    public class Person
    {
        //------------- Private fields Created ---------------//
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
        public int Id => id;

        //********** FOR FIRST NAME ************//
        public string FirstName
        {
            get => firstName; 
            set
            {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentNullException("First Name could not be null or empty.");
                }
                firstName = value;
            }
        }

        //********** FOR LAST NAME ************//
        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last Name could not be null or empty.");
                }
                lastName = value;
            }
        }
    }
}
