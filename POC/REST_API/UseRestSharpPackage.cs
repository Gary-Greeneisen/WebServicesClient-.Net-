namespace WebServicesClient.POC.REST_API
{

    using System.Net;
    using System.Text.Json;
    using System.Text.Json.Nodes;
    using System.Xml.Linq;
    using FluentAssertions;
    using RestSharp;
    using RestSharp.Serializers.Xml;
    using static System.Net.WebRequestMethods;

    public class UseRestSharpPackage
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

        public void GetRestSharp()
        {
            //Set Base Address
            //var baseUrl = "https://petstore.swagger.io/v2/pet/findByStatus?status=available";
            var baseUrl = "https://petstore.swagger.io";

            // Set search parameters
            var endpoint = "/v2/pet/findByStatus?status=available";

            // send GET request with RestSharp
            //Set base URL
            //Don't have to concatate the Base Url + Endpoint Url
            //We are setting the BaseAddress = Base Url
            RestClient client = new RestClient(baseUrl);

            //Set search parameters
            RestRequest restRequest = new RestRequest(endpoint, Method.Get);
            //RestRequest restRequest = new RestRequest(baseUrl, Method.Get);

            //Don't need to set the Request Header Type
            //restRequest.AddHeader("Content-Type", "application/json");
            //restRequest.AddHeader("Content-Type", "application/xml");
            RestResponse restResponse = client.Execute(restRequest);  //Blocking call to the Web Service

            restResponse.Should().NotBeNull();
            restResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // deserialize json string response to JsonNode object
            var data = JsonSerializer.Deserialize<JsonNode>(restResponse.Content!)!;



        }


   
    }
}