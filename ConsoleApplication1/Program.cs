using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;
using System.Web.Script.Serialization;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true) {
            string choice;
            string id;
            int status;

            var client = new RestClient("http://192.168.0.3:1337/auto/api/v1.0/");
            var request = new RestRequest("relays", Method.GET);  
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var response = client.Execute<Relay>(request);
            var RelayCollection = client.Execute<RelayCollection>(request);

            Console.WriteLine(RelayCollection.Content);
            Console.WriteLine("What id do you want to change?");
            id = Console.ReadLine();
            Console.WriteLine("We will change id:{0}\nwhat do you want to do?\n0 = off 1 = on", id);
            choice = Console.ReadLine();
            if(choice == "1")
            {
                status = 1;
            }
            else
            {
                status = 0;
            }

            var putRequest = new RestRequest("relays/" + id, Method.PUT);
            putRequest.AddJsonBody(new { status = status });
            client.Execute(putRequest);

        }
        }
    }
}
