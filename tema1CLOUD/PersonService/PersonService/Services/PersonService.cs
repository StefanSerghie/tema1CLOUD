using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonService.Services
{
    public class PersonService : PersonManager.PersonManagerBase
    {
        public override Task<AddPersonResponse> AddPerson(AddPersonRequest request, ServerCallContext context)
        {
            var person = request.Person;
            Console.WriteLine("Name " + person.Name);
            Console.WriteLine("Age: ");
            int year = int.Parse(person.Cnp.Substring(1, 2));
            int age =year<=20 ? 2020-(year+2000):2020-(year+1900);

            Console.Write(age);
            Console.WriteLine("Gender: ");
            if (person.Cnp.ElementAt(0) == '5' || person.Cnp.ElementAt(0) == '1')
            {
                Console.Write("M");
            }
            else if(person.Cnp.ElementAt(0) == '6' || person.Cnp.ElementAt(0) == '2')
            {
                Console.Write("F");
            }

            return Task.FromResult(new AddPersonResponse() { Status = AddPersonResponse.Types.Status.Success });
        }

 
    }
}
