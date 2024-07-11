using ToDoApp.Data;
using ToDoApp.Models;
using Xunit;

namespace ToDo_UnitTesting
{
    public class PeopleService_Test
    {
        //--------------- PeopleService Size Testing ----------//
        [Fact]
        public void Size_ShouldReturnLengthOfArray()
        {
            // Arrange
            PeopleService service = new PeopleService();
            service.Clear();

            // Act
            int size = service.Size();

            // Assert
            Assert.Equal(0, size);

            //Size by adding person
            service.Create("Anabia", "Khan");
            size = service.Size();
            Assert.Equal(1, size);
        }

        //--------------- PeopleService FindAll Method Testing ----------//
        [Fact]
        public void FindAll_ShouldReturnPersonArray()
        {
            // Arrange
            PeopleService service = new PeopleService();
            service.Clear();

            // Act
            Person[] allPeople = service.FindAll();

            // Assert
            Assert.NotNull(allPeople);
            Assert.Empty(service.FindAll());

            //Size by adding person
            service.Create("Anabia", "Khan");
            allPeople = service.FindAll();
            Assert.Single(allPeople);
        }

        //--------------- PeopleService FindById Method Testing ----------//
        [Fact]
        public void FindById_ShouldReturnCorrectPerson()
        {
            // Arrange
            PeopleService service = new PeopleService();
            service.Clear();
            Person createPerson = service.Create("Awais", "Khan");

            // Act
            Person foundPerson = service.FindById(createPerson.Id);

            // Assert
            Assert.NotNull(service.FindById(createPerson.Id));
            Assert.Equal(createPerson.Id, foundPerson.Id);

            //Size by adding person
            Person p2 = service.Create("Anabia", "Khan");
            Person foundP2 = service.FindById(p2.Id);
            Assert.NotNull (foundP2);
            Assert.Equal(p2.Id, foundP2.Id);
        }

        //--------------- PeopleService Create Method Testing ----------//
        [Fact]
        public void Create_ShouldAddPersonToArray()
        {
            // Arrange
            PeopleService service = new PeopleService();
            service.Clear();

            // Act
            Person newPerson = service.Create("Awais", "Khan");
            int size = service.Size();

            // Assert
            Assert.NotNull(newPerson);
            Assert.Equal("Awais", newPerson.FirstName);
            Assert.Equal("Khan", newPerson.LastName);
            Assert.Equal(1, size);

        }

        //--------------- PeopleService Clear Method Testing ----------//
        [Fact]
        public void Clear_ShouldRemoveAllPeople()
        {
            // Arrange
            PeopleService service = new PeopleService();
            Person newPerson1 = service.Create("Awais", "Khan");
            Person newPerson2 = service.Create("Anabia", "Khan");

            // Act
            service.Clear();

            // Assert
            Assert.Equal(0, service.Size());
            Assert.Empty(service.FindAll());
        }

        //--------------- PeopleService Remove Method Testing ----------//
        [Fact]
        public void RemovePerson_ShouldRemovePersonFromArray()
        {
            // Arrange
            PeopleService service = new PeopleService();
            service.Clear();
            Person person1 = service.Create("Awais", "Khan");
            Person person2 = service.Create("Anabia", "Khan");

            // Act
            service.RemovePerson(person1.Id);

            // Assert
            Assert.Single(service.FindAll());
            Assert.Null(service.FindById(person1.Id));
            Assert.NotNull(service.FindById(person2.Id));
        }
    }
}
