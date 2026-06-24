using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace automationexerciseAPI.TestsRest
{
    [TestFixture]
    public class AutomationExerciseRestApiTests
    {
        [Test]
        public async Task GetAllProducts_ShouldReturnSuccessStatusCode()
        {
            // Arrange
            var client = new RestSharpClientApi("https://automationexercise.com/api/");
            // Act
            var response = await client.GetAsync("productsList");
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
