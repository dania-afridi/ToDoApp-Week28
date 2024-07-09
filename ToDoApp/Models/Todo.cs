namespace ToDoApp.Models
{
    public class Todo
    {
        //------------- Private fields Created ---------------//
        private readonly int id;
        private string description;
        private bool done;
        private Person assignee;

        //------------- constructor to initialize private fields ---------------//
        public Todo(int id, string description)
        {
            this.id = id;
            this.description = description;
        }

        //********** CONSTRUCTOR TO INITIALIZE ALL FIELDS ************//
        /*
        public Todo(int id, string description, Person assignee, bool done)
        {
            this.id = id;
            this.description = description;
            this.assignee = assignee;
            this.done = done;
        }*/

        //------------- public properties to get, set and access private field ---------------//

        //********** FOR ID ************//
        public int Id => id;

        //********** FOR DESCRIPTION ************//
        public string Description
        {
            get => description;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Description cannot be null or empty.");
                }
                description = value;
            }
        }

        //********** FOR DESCRIPTION ************//
        public bool Done
        {
            get => done;
            set => done = value;
        }

        //********** FOR ASSIGNEE ************//
        public Person Assignee
        {
            get => assignee;
            set => assignee = value;
        }
    }
}
