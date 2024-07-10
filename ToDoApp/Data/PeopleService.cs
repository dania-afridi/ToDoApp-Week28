using ToDoApp.Models;

namespace ToDoApp.Data
{
    public class PeopleService
    {
        //------- Private Fields -----------//
        private static Person[] people = new Person[0];

        //------------- Public Methods --------------//

        //********** TO GET PEOPLE SIZE ************//
        public int Size() => people.Length;

        //********** TO GET ALL PEOPLE ************//
        public Person[] FindAll() => people;

        //********** TO GET PERSON BY ID ************//
        public Person FindById(int personId)
        {
            foreach (Person person in people) {
                if (person.Id == personId) { return person; }
            }
            return null;
        }

        //********** TO CREATE PERSON AND ADD IN PEOPLE BY RESIZING PEOPLE ************//
        public Person Create(string firstName, string lastName)
        {
            int personId = PersonSequencer.NextPersonId();
            Person person = new Person(personId, firstName, lastName);

            Array.Resize(ref people, people.Length + 1); // Expand array to add new person
            people[^1] = person; // [^1] = [people.Length - 1]

            return person;
        }

        //********** TO RESET PEOPLE ************//
        public void Clear()
        {
            people = new Person[0];
        }
    }
}
