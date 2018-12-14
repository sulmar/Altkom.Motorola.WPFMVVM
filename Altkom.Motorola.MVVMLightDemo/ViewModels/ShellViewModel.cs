using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Altkom.Motorola.MVVMLightDemo.ViewModels
{
    public class ShellViewModel
    {
        private readonly INavigationService navigationService;

        public ICommand DevicesCommand { get; set; }

        public ShellViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            this.DevicesCommand = new RelayCommand(() => ShowDevices());
        }

        public void ShowDevices()
        {
            navigationService.NavigateTo("Devices", "Hello World");
        }
    }
}
