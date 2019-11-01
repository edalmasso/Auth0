using NUnit.Framework;
using SmartApartmentData.Api.Tests.Entities;
using SmartApartmentData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace SmartApartmentData.Api.Tests
{
    /// <summary>
    /// Method naming convention: UnitOfWork_InitialCondition_ExpectedResult
    /// </summary>
    public class CustomerTests
    {
        public const string baseUrl = "https://smartapartmentdataapi20191031094229.azurewebsites.net/api";
        private SecureString BearerToken;
        private string client_id = "yiC8rzHny6U4Uy1ivQzYegbk1arh9ogr";
        private SecureString client_secret = Utility.CryptoUtility.ToSecureString("k-nCHuwS2BPT3Dyii8cu0fWyrVO9d7Gp_E2v-3EVPXKm7hfX-3z4sE_dS9R4HqlU");
        private string audience = "https://smarapartmentdata/api";

        [SetUp]
        public void Setup()
        {
            #region Generate Bearer Token for all tests
            RestApiHelper<Customer> restApi = new RestApiHelper<Customer>("https://edalmasso.auth0.com");
            var restUrl = restApi.SetUrl("/oauth/token");
            string jsonString = "{\"client_id\" : \"" + client_id + "\",\"client_secret\": \"" + Utility.CryptoUtility.ToUnsecureString(client_secret) + "\", \"audience\" : \"" + audience + "\",\"grant_type\" : \"client_credentials\"}";

            var restRequest = restApi.CreatePostRequest(jsonString);

            var response = restApi.GetResponse(restUrl, restRequest);

            Auth0TokenResponse result = restApi.GetContent<Auth0TokenResponse>(response);
            BearerToken = Utility.CryptoUtility.ToSecureString(result.access_token);
            #endregion
        }


        [Test]
        public void Customer_GetCustomerCompaniesFromV1_CompaniesReturned()
        {
            RestApiHelper<Customer> restApi = new RestApiHelper<Customer>(baseUrl);
            var restUrl = restApi.SetUrl("/v1/customer");
            var restRequest = restApi.CreateGetRequest();

            // Act
            var response = restApi.GetResponse(restUrl, restRequest);

            // Assert
            IEnumerable<string> companies = restApi.GetContent<IEnumerable<string>>(response);
            Assert.IsNotNull(companies);
            Assert.GreaterOrEqual(companies.Count(), 1);
        }


        [Test]
        public void Customer_GetCustomerCompaniesFromV2_UnsupportedApiVersion()
        {
            RestApiHelper<Customer> restApi = new RestApiHelper<Customer>(baseUrl);
            var restUrl = restApi.SetUrl("/v2/customer");
            var restRequest = restApi.CreateGetRequest();

            // Act
            var response = restApi.GetResponse(restUrl, restRequest);

            // Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.BadRequest);
            Assert.IsTrue(response.Content.Contains("UnsupportedApiVersion"));
        }

        [Test]
        public void Customer_CreateCustomer_CustomerCreated()
        {
            //Arrange
            string jsonString = @"{
                                    ""firstName"" : ""Eduardo"",
                                    ""Surname"": ""Dalmasso"",
                                    ""PhoneNumber"" : ""+123456789"",
                                    ""Company"" : ""Smart Apartment Data""
                                  }";

            RestApiHelper<Customer> restApi = new RestApiHelper<Customer>(baseUrl);
            var restUrl = restApi.SetUrl("/v2/customer");
            var restRequest = restApi.CreatePostRequest(jsonString);
            restRequest.AddHeader("authorization", $"Bearer {Utility.CryptoUtility.ToUnsecureString(BearerToken)}");

            // Act
            var response = restApi.GetResponse(restUrl, restRequest);

            // Assert
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                Assert.Fail($"Returned {response.StatusCode}");
            Customer customer = restApi.GetContent<Customer>(response);
            Assert.IsNotNull(customer);
            Assert.AreEqual(customer.FirstName, "Eduardo");
            Assert.AreEqual(customer.Surname, "Dalmasso");
            Assert.AreEqual(customer.Company, "Smart Apartment Data");
            Assert.GreaterOrEqual(customer.Id, 1);
        }

        [Test]
        public void Customer_CreateCustomerWithNoToken_ForbiddenExpected()
        {
            //Arrange
            string jsonString = @"{
                                    ""firstName"" : ""Eduardo"",
                                    ""Surname"": ""Dalmasso"",
                                    ""PhoneNumber"" : ""+123456789"",
                                    ""Company"" : ""Smart Apartment Data""
                                  }";

            RestApiHelper<Customer> restApi = new RestApiHelper<Customer>(baseUrl);
            var restUrl = restApi.SetUrl("/v2/customer");
            var restRequest = restApi.CreatePostRequest(jsonString);

            // Act
            var response = restApi.GetResponse(restUrl, restRequest);

            // Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Unauthorized);
        }

    }
}
