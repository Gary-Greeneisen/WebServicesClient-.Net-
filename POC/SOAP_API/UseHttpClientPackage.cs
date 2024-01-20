namespace WebServicesClient.POC.SOAP_API
{
    using Newtonsoft.Json;
    using NUnit.Framework;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Reflection.Metadata;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.Unicode;
    using System.Threading.Tasks;
    using WebServicesClient.ClassFiles;
    using static System.Net.Mime.MediaTypeNames;
    using static System.Net.WebRequestMethods;

    public class UseHttpClientPackage
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

        public async Task TestSOAPPostCalculatorAdd()
        {
            //Set 2-numbers to Add
            //int intA = 3;
            //int intB = 5;

            //Set Base Address
            var baseUrl = "http://www.dneonline.com/calculator.asmx";

            // Set Action Url
            //Copy the SOAP action directly from the WSDL
            //var actionUrl = "http://tempuri.org/Add";

            //Create a client
            //Use the WebServiceClass static instance
            var client = WebServiceClientClass.HttpInstance;
            client.DefaultRequestHeaders.Accept.Clear();

            //Update the SOAP Headers
            //client.DefaultRequestHeaders.Add("SOAPAction", actionUrl);
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            client.DefaultRequestHeaders.Add("POST", "/calculator.asmx HTTP/1.1");
            client.DefaultRequestHeaders.Add("Host", "www.dneonline.com");
            //client.DefaultRequestHeaders.Add("Content-Type", "text/xml; charset = utf-8");
            //client.DefaultRequestHeaders.Add("Content-Length","length");
            client.DefaultRequestHeaders.Add("SOAPAction", "http://tempuri.org/Add");

            //format the paramters to be used in the POST call
            //var soapString = String.Format(@"{0} {1}", intA, intB);
            //var content = new StringContent(soapString, Encoding.UTF8, "text/xml");
            //var response = await client.PostAsync(baseUrl, content);

            //Use a Dictionary/List to add values pairs to the server call
            var values = new Dictionary<string, string>();
            values.Add("intA", "3");
            values.Add("intB", "5");
            var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(baseUrl, content);

            // Parse the response body
            var soapResponse = await response.Content.ReadAsStringAsync(); 



        }
    }
}