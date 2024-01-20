namespace WebServicesClient.POC.REST_API
{

    using NUnit.Framework;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using WebServicesClient.ClassFiles;

    public class UseHttpClientPackage
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        //****************************************************************
        // Get Request Calls a test REST Web Service
        // return a XML response as JSON format
        // This is from Soap UI Web Site - https://www.soapui.org/docs/rest-testing/
        //Use this REST url to return 590 XML pet records
        //https://petstore.swagger.io/v2/pet/findByStatus?status=available
        //*****************************************************************************************

        public async Task GetHttpClient()
        {
            //Create a client
            //Use the WebServiceClass static instance
            var client = WebServiceClientClass.HttpInstance;

            //Set base URL
            //Don't have to concatate the Base Url + Endpoint Url
            //We are setting the BaseAddress = Base Url
            client.BaseAddress = new Uri("https://petstore.swagger.io");

            // Set search parameters
            var endpoint = "/v2/pet/findByStatus?status=available"; 

            //Call the Web Service
            var response = await client.GetAsync(endpoint);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            // Parse the JSON response body
            var data = response.Content.ReadAsStringAsync().Result;
    


        }
    }
}