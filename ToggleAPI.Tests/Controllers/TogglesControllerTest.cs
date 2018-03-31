using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ClientToggle;
using Bussiness.ToggleManager;
using ToggleAPI.Controllers;
using ToggleAPI.Models;

namespace ToggleAPI.Tests.Controllers
{
    [TestClass]
    public class TogglesControllerTest
    {
        
      

        [TestMethod]
        public void Get()
        {
            // Arrange
            ToggleManager managerToggle = new ToggleManager();
            ClientToggle clientToggle = new ClientToggle(managerToggle);
            TogglesController controller = new TogglesController( clientToggle);

            // Act
            IEnumerable<ToggleViewModel> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        //[TestMethod]
        //public void GetById()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    string result = controller.Get(5);

        //    // Assert
        //    Assert.AreEqual("value", result);
        //}

        //[TestMethod]
        //public void Post()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Post("value");

        //    // Assert
        //}

        //[TestMethod]
        //public void Put()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Put(5, "value");

        //    // Assert
        //}

        //[TestMethod]
        //public void Delete()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Delete(5);

        //    // Assert
        //}
    }
}
