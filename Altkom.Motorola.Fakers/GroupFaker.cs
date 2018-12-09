using Altkom.Motorola.Models;
using Bogus;
using System.Diagnostics;

namespace Altkom.Motorola.Fakers
{

    public class GroupFaker : Faker<Group>
    {
        public GroupFaker()
        {
            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => f.Company.CompanyName());
            RuleFor(p => p.Country, f => f.Address.Country());
            RuleFor(p => p.CompanyName, f => f.Company.CompanyName());
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.9f));
            Ignore(p => p.Calls);
            FinishWith((f, group) => Debug.WriteLine($"Group was created. Id= {group.Id} {group.FullName}")); ;
        }
    }

   
}
