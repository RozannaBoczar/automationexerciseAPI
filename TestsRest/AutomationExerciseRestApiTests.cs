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
        public async Task PostAllProducts_ShouldReturnMethodNotAllowedStatusCode()
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
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task PutAllBrandsList_ShouldReturnMethodNotAllowedStatusCode()
        {
            // Arrange
            var client = new RestSharpClientApi();
            // Act
            var response = await client.PutAsync("brandsList");
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        [Test]
        public async Task PostSearchProduct_ShouldReturnSuccessStatusCode()
        {
            // Arrange
            var client = new RestSharpClientApi();
            var body = new { search_product = "T-Shirt" };
            // Act
            var response = await client.PostAsync("searchProduct", body);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task PostSearchProduct_ShouldReturnBadRequestStatusCode_WhenNoSearchProduct()
        {
            // Arrange
            var client = new RestSharpClientApi();
            // Act
            var response = await client.PostAsync("searchProduct");
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            response.ErrorMessage.Should().Be("search_product parameter is missing in POST request");
        }
    }
}
