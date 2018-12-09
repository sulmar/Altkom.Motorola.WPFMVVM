using Altkom.Motorola.Models;
using Bogus;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Altkom.Motorola.Fakers
{
    public class CallFaker : Faker<Call>
    {
        public CallFaker(List<Device> devices, List<Contact> contacts)
        {
            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.BeginCallDate, f => f.Date.Past());
            RuleFor(p => p.EndCallDate, (f, p) => p.BeginCallDate.AddMinutes(f.Random.Double(1, 3)));
            RuleFor(p => p.Status, f => f.PickRandom<CallStatus>());
            RuleFor(p => p.Source, f => f.PickRandom(devices));
            RuleFor(p => p.Sender, f => f.PickRandom(contacts));
            RuleFor(p => p.Target, (f, p) => f.PickRandom(devices.Except(new List<Device>() { p.Source })));
            RuleFor(p => p.IsAnswered, f => f.Random.Bool(0.8f));
            RuleFor(p => p.ChannelId, f => f.Random.Number(255));
            FinishWith((f, call) => Debug.WriteLine($"Call was created. Id = {call.Id} {call.Source.Name} -> {call.Target.Name}"));
        }
    }

   
}
