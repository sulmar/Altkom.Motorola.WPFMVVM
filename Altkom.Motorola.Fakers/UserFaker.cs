using Altkom.Motorola.Models;
using Bogus;
using System.Diagnostics;

namespace Altkom.Motorola.Fakers
{
    // PM> Install-Package Bogus

    public class UserFaker : Faker<User>
    {
        public UserFaker()
        {                       
            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.Country, f => f.Address.Country());
            RuleFor(p => p.CompanyName, f => f.Company.CompanyName());
            RuleFor(p => p.IsRemoved, f => f.PickRandomParam(new bool[] { true, true, false }));
            Ignore(p => p.Calls);
            FinishWith((f, user) => Debug.WriteLine($"User was created. Id = {user.Id} {user.FullName}")); ;
        }
    }

   
}
