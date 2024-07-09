using System;
using System.Security.Cryptography;
using ToDoApp.Models;
using Xunit;

namespace ToDo_UnitTesting
{
    public class PersonTest
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            int _id = 1;
            string _firstName = "Awais";
            string _lastname = "Khan";

            // Act
            Person person = new Person(_id, _firstName, _lastname);

            // Assert
            Assert.Equal(_id, person.Id);
            Assert.Equal(_firstName, person.FirstName);
            Assert.Equal(_lastname, person.LastName);
        }

        [Fact]
        public void FirstName_Setter_ShouldThrowArgumentException_WhenNullOrEmpty()
        {
            // Arrange
            int _id = 1;
            string _firstName = "";
            string _lastname = "Khan";

            // Act
            Person person = new Person(_id, _firstName, _lastname);

            // Assert
            Assert.Throws<ArgumentNullException>(() => person.FirstName = null);
            Assert.Throws<ArgumentNullException>(() => person.FirstName = "");
            Assert.Throws<ArgumentNullException>(() => person.FirstName = " ");
        }

        [Fact]
        public void LastName_Setter_ShouldThrowArgumentException_WhenNullOrEmpty()
        {
            // Arrange
            int _id = 1;
            string _firstName = "Awais";
            string _lastname = " ";

            // Act
            Person person = new Person(_id, _firstName, _lastname);

            // Assert
            Assert.Throws<ArgumentNullException>(() => person.LastName = null);
            Assert.Throws<ArgumentNullException>(() => person.LastName = "");
            Assert.Throws<ArgumentNullException>(() => person.LastName = " ");
        }

        [Fact]
        public void FirstName_Setter_ShouldUpdateValue()
        {
            // Arrange
            Person person = new Person(1, "Awais", "Khan");
            string fName = "Anabia";

            // Act
            person.FirstName = fName;

            // Assert
            Assert.Equal(fName, person.FirstName);
        }

        [Fact]
        public void LastName_Setter_ShouldUpdateValue()
        {
            // Arrange
            Person person = new Person(1, "Awais", "Khan");
            string lName = "Awaisdotter";

            // Act
            person.LastName = lName;

            // Assert
            Assert.Equal(lName, person.LastName);
        }

    }
}