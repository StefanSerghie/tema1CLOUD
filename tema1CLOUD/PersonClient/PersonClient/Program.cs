using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace PersonClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
           
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new PersonManager.PersonManagerClient(channel);

            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("CNP: ");
            var cnp = Console.ReadLine();

            var personToBeAdded = new Person() { Name = name.Trim().Length > 0 ? name : "undefined" ,
                Cnp=cnp.Trim().Length>0 ? cnp : "undefined"};
            var response = await client.AddPersonAsync(
                              new AddPersonRequest { Person = personToBeAdded });
            Console.WriteLine("Adding status: " + response.Status);
        }
    }
}
