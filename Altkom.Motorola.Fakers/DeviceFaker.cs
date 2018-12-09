using Altkom.Motorola.Models;
using Bogus;
using System.Diagnostics;

namespace Altkom.Motorola.Fakers
{
    public class DeviceFaker : Faker<Device>
    {
        public DeviceFaker()
        {
            string[] Models = { "SL4000e", "DP4000e", "DP3000e", "DP4000EX", "SL2600", "DP2000e", "SL1600", "DP1400"};

            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => $"Radio {f.UniqueIndex}");
            RuleFor(p => p.Model, f => f.PickRandom(Models));
            RuleFor(p => p.Firmware, f => f.System.Version().ToString());
            RuleFor(p => p.Description, f => f.Lorem.Paragraph(1));
            Ignore(p => p.Calls);
            FinishWith((f, device) => Debug.WriteLine($"Device was created. Id = {device.Id} {device.Name}")); ;
        }
    }

   
}
