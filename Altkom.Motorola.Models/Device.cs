using System.Collections.Generic;

namespace Altkom.Motorola.Models
{

    // PM> Install-Package Fody
    // PM> Install-Package PropertyChanged.Fody

    public class Device : Base
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Firmware { get; set; }
        public string Description { get; set; }

        private string _color;
        public string Color
        {
            get => _color;

            set
            {
                _color = value;
                Description = value;
                
            }
        }




        public virtual ICollection<Call> Calls { get; set; }


        // public override string ToString() => $"{Name} {Model}";

    }
}
