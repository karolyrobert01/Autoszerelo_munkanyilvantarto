using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebApi_Common.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApi_Common_Tests
{
    [TestClass]
    public class IDClassValidationTest : IDValidation
    {
        [DataRow("NZK-123")]
        [DataRow("ABC-123")]
        [DataTestMethod]
        public void IsValidData(string name)
        {
            var ValidationContext = new ValidationContext(name);
            var attribute = new IDValidation();

            var validationResult = attribute.GetValidationResult(name, ValidationContext);

            Assert.AreEqual(ValidationResult.Success, validationResult);

        }
    }
}