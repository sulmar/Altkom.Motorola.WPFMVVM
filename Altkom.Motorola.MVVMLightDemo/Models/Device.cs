using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.MVVMLightDemo.Models
{
    public class Device : Base
    {
        private string _name;

        public string Name
        {
            get => _name; set
            {
                Set(() => Name, ref _name, value);
                
                //if (_name != value)
                //{
                //    _name = value;
                //    RaisePropertyChanged();
                //}
            }
        }

        public string Model { get; set; }
        public string Firmware { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }
}
