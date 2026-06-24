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
            var client = new RestSharpClientApi();
            // Act
            var response = await client.GetAsync("productsList");
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task PostAllProducts_ShouldReturnSuccessStatusCode()
        {
            // Arrange
            var client = new RestSharpClientApi();
            // Act
            var response = await client.PostAsync("productsList");
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        [Test]
        public async Task GetAllBrandsList_ShouldReturnSuccessStatusCode()
        {
            // Arrange
            var client = new RestSharpClientApi();
            // Act
            var response = await client.GetAsync("brandsList");
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
        }
    }
}
