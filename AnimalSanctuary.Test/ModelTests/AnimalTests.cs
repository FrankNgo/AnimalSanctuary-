using AnimalSanctuary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnimalSanctuary.Test
{
    [TestClass]
    public class AnimalTests
    {
    
        [TestMethod]
        public void GetDescription_ReturnsAnimalDescription_String()
        {
            //Arrange
            var animal = new Animal();

            //Act
            animal.Name = "Happy";
            var result = animal.Name;

            //Assert
            Assert.AreEqual("Happy.", result);
        }
        
    }
}
