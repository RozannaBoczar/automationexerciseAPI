using automationexerciseAPI.HelpersRest;
using FluentAssertions;

namespace automationexerciseAPI.TestsRest
{
    [TestFixture]
    public class AutomationExerciseRestApiTests
    {
        private IRestSharpClientApi _client;

        [SetUp]
        public void Setup() {
            _client = new RestSharpClientApi("https://automationexercise.com/api/");
        }

        [Test]
        public async Task GetAllProducts_ShouldReturnSuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("productsList");
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task PostAllProducts_ShouldReturnMethodNotAllowedStatusCode()
        {
            // Act
            var response = await _client.PostAsync("productsList");
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        [Test]
        public async Task GetAllBrandsList_ShouldReturnSuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("brandsList");
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task PutAllBrandsList_ShouldReturnMethodNotAllowedStatusCode()
        {
            // Act
            var response = await _client.PutAsync("brandsList");
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        [Test]
        public async Task PostSearchProduct_ShouldReturnSuccessStatusCode()
        {
            // Arrange
            var body = new { search_product = "T-Shirt" };
            // Act
            var response = await _client.PostAsync("searchProduct", body);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task PostSearchProduct_ShouldReturnBadRequestStatusCode_WhenNoSearchProduct()
        {
            // Act
            var response = await _client.PostAsync("searchProduct");
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            response.ErrorMessage.Should().Be("search_product parameter is missing in POST request");
        }

        [Test]
        public async Task PostVerifyLogin_ShouldReturnSuccessStatusCode()
        {
            // Arrange
            var body = new
            {
                email = "test@roziacorp.com",
                password = "password",
            };
            // Act
            var response = await _client.PostAsync("verifyLogin", body);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Content.Should().Contain("User exists!");
        }

        [Test]
        public async Task PostVerifyLogin_ShouldReturnBadRequestStatusCode_WhenNoEmail()
        {
            // Arrange
            var body = new
            {
                password = "password",
            };
            // Act
            var response = await _client.PostAsync("verifyLogin", body);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            response.Content.Should().Contain("email or password parameter is missing in POST request");
        }

        [Test]
        public async Task PostVerifyLogin_ShouldReturnBadRequestStatusCode_WhenNoPassword()
        {
            // Arrange
            var body = new
            {
                email = "test@roziacorp.com"
            };
            // Act
            var response = await _client.PostAsync("verifyLogin", body);
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            response.Content.Should().Contain("email or password parameter is missing in POST request");
        }

        [Test]
        public async Task DeleteVerifyLogin_ShouldReturnMethodNotAllowedStatusCode()
        {
            // Act
            var response = await _client.DeleteAsync("verifyLogin");
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        [Test]
        public async Task PostVerifyLogin_ShouldReturnNotFoundStatusCode_WhenInvalidDetails()
        {
            // Arrange
            var body = new
            {
                email = "invalid@roziacorp.com",
                password = "invalidpassword",
            };

            // Act
            var response = await _client.PostAsync("verifyLogin", body);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            response.ErrorMessage.Should().Be("User not found!");
        }

        [Test]
        public async Task PostCreateAccount_ShouldReturnCreatedStatusCode()
        {
            // Arrange
            var body = new
            {
                name = "rozia",
                email = "valid@roziacorp.com",
                password = "validpassword",
                title = "Miss",
                birth_date = "1990-01-01",
                birth_month = "01",
                birth_year = "1990",
                firstname = "Rozia",
                lastname = "Oczar",
                company = "RoziaCorp",
                addres1 = "123 Main St",
                address2 = "Apt 4B",
                country = "USA",
                zipcode = "12345",
                state = "NY",
                city = "New York",
                mobile_phone = "1234567890"
            };

            // Act
            var response = await _client.PostAsync("createAccount", body);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            response.Content.Should().Be("User created!");
        }

        [Test]
        public async Task DeleteAccount_ShouldReturnSuccessfullStatusCode()
        {
            // Arrange
            var body = new
            {
                email = "valid@roziacorp.com",
                password = "validpassword"
            };

            // Act
            var response = await _client.DeleteAsync("deleteAccount", body);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Content.Should().Be("Account deleted!");
        }

        [Test]
        public async Task PutUpdateAccount_ShouldReturnSuccessfullStatusCode()
        {
            // Arrange
            var body = new
            {
                name = "rozia",
                email = "valid@roziacorp.com",
                password = "validpassword",
                title = "Miss",
                birth_date = "1990-01-01",
                birth_month = "01",
                birth_year = "1990",
                firstname = "Rozia",
                lastname = "Oczar",
                company = "RoziaCorp",
                addres1 = "123 Main St",
                address2 = "Apt 4B",
                country = "USA",
                zipcode = "12345",
                state = "NY",
                city = "New York",
                mobile_phone = "1234567890"
            };

            // Act
            var response = await _client.DeleteAsync("updateAccount", body);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Content.Should().Be("User updated!");
        }

        [Test]
        public async Task GetUserDetailByEmail_ShouldReturnSuccessfullStatusCode()
        {
            // Arrange
            var body = new
            {
                email = "valid@roziacorp.com"
            };

            // Act
            var response = await _client.GetAsync("getUserDetailByEmail", body);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
