using Altkom.Motorola.IServices;
using Altkom.Motorola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.ViewModels
{
    //public class ContactsViewModel : BaseViewModel
    //{
    //    public ICollection<Contact> Contacts { get; set; }

    //    private readonly IContactsService contactsService;

    //    public ContactsViewModel(IContactsService contactsService)
    //    {
    //        this.contactsService = contactsService;

    //        Load();
    //    }

    //    private void Load() => Contacts = contactsService.Get();
    //}


    public class ContactsViewModel 
        : ItemsViewModel<Contact, IContactsService>
    {
        public ContactsViewModel(IContactsService itemsService) 
            : base(itemsService)
        {
        }
    }

    public class CallViewModel : ItemsViewModel<Call, ICallsService>
    {
        public CallViewModel(ICallsService itemsService) : base(itemsService)
        {
        }
    }
}
