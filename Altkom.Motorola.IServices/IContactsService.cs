using Altkom.Motorola.Models;
using System;
using System.Text;

namespace Altkom.Motorola.IServices
{
    

    public interface IContactsService : IItemsService<Contact>
    {     
    }

    public interface ICallsService : IItemsService<Call>
    {

    }
}
