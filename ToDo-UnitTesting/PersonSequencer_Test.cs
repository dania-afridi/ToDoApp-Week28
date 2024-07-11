using ToDoApp.Data;
using ToDoApp.Models;
using Xunit;

namespace ToDo_UnitTesting
{
    public class PersonSequencer_Test
    {
        //--------------- NextPersonId Testing ----------//
        [Fact]
        public void NextPersonId_ShouldIncrementAndReturnNextValue()
        {
            // Arrange
            PersonSequencer.Reset();

            // Act
            int firstPersonId = PersonSequencer.NextPersonId();
            int secondPersonId = PersonSequencer.NextPersonId();

            // Assert
            Assert.Equal(1, firstPersonId);
            Assert.Equal(2, secondPersonId);
        }

        //--------------- Reset Method Testing ----------//
        [Fact]
        public void Reset_ShouldSetPersonIdToZero()
        {
            // Arrange
            int firstPersonId = PersonSequencer.NextPersonId();
            int secondPersonId = PersonSequencer.NextPersonId();

            // Act
            PersonSequencer.Reset();
            int PersonId_AfterReset = PersonSequencer.NextPersonId();

            // Assert
            Assert.Equal(1, PersonId_AfterReset);
        }

    }
}
