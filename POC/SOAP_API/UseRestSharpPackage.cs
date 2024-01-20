namespace WebServicesClient.POC.SOAP_API
{

    using System.Net;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Nodes;
    using System.Text.Unicode;
    using System.Xml.Linq;
    using FluentAssertions;
    using RestSharp;
    using RestSharp.Serializers.Xml;
    using static System.Formats.Asn1.AsnWriter;
    using static System.Net.Mime.MediaTypeNames;
    using static System.Net.WebRequestMethods;

    public class UseRestSharpPackage
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]

        //****************************************************************
        //Date - 1/2/2024
        //After 3-days of trial and error and multiple Google searchs
        // that are old version, not specific, and just don't work
        //...I give up...
        //****************************************************************

        //****************************************************************
        // POST Request Calls a test SOAP Calculator Web Service
        // Add 2-numbers return a XML response
        //  Input parameters
        //  IntA
        //  IntB
        //
        //  Return
        //  int
        // Base URL http://www.dneonline.com/calculator.asmx
        // Calculator Test WSDL - http://www.dneonline.com/calculator.asmx?wsdl
        //*****************************************************************************************

        public void TestRestPostCalculatorAdd()
        {
            //Set Base Address
            var baseUrl = "http://www.dneonline.com/calculator.asmx";
            var endpoint = "?op=Add";

            var client = new RestClient(baseUrl);

            //Set search parameters
            RestRequest request = new RestRequest(endpoint, Method.Post);

            //Add SOAP header details
            request.AddHeader("POST", "/calculator.asmx HTTP/1.1");
            request.AddHeader("Host", "www.dneonline.com");
            request.AddHeader("Content-Type", "text/xml; charset=utf-8");
            request.AddHeader("Content-Length", "length");
            request.AddHeader("SOAPAction", "http://tempuri.org/Add");

            //********************************************************************
            //How to include quotes in a string
            //Web Page
            //https://stackoverflow.com/questions/3458046/how-to-include-quotes-in-a-string
            //
            //Question
            //How can I include the quotes before and after c#?
            //
            //Answer
            //Escape them with backslashes.
            //
            //Original String = "I want to learn "C#" "
            //Modified String = "I want to learn \"C#\" "
            //********************************************************************

            //Set SOAP body details. Add to Paramter section
            string rawXml = "<?xml version=\"1.0\" encoding= \"utf-8\"?>< soap:Envelope xmlns:xsi =\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" >";
            request.AddParameter("text/xml", rawXml, ParameterType.RequestBody);
                     
            //Add SOAP parameters;
            request.AddParameter("intA/xml", "3");
            request.AddParameter("intA/xml", "5");

            var response = client.Execute(request);

            // Parse the response body
            //var data = response.Content.ToString();

            //var dotNetXmlDeserializer = new RestSharp.  .Deserializers.DotNetXmlDeserializer();
            //ModelClassName modelClassObject =
            // dotNetXmlDeserializer.Deserialize<ModelClassName>(restResponse);


        }


   
    }
}