using Altkom.Motorola.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.Motorola.IServices
{
    public interface IContactsService
    {
        ICollection<Contact> Get();
        Contact Get(int id);
        void Add(Contact contact);
        void Update(Contact contact);
        void Remove(int id);
    }
}
