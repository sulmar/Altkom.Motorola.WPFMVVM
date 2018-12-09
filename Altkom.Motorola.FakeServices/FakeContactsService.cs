using Altkom.Motorola.Fakers;
using Altkom.Motorola.IServices;
using Altkom.Motorola.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.Motorola.FakeServices
{
    public class FakeContactsService : IContactsService
    {
        private readonly ICollection<Contact> contacts;

        public FakeContactsService()
        {
            UserFaker userFaker = new UserFaker();
            GroupFaker groupFaker = new GroupFaker();

            contacts = userFaker.Generate(50)
                .OfType<Contact>()
                .Concat(groupFaker.Generate(10))               
                .ToList();

        }

        public void Add(Contact contact)
        {
            contacts.Add(contact);
        }

        public ICollection<Contact> Get()
        {
            return contacts;
        }

        public Contact Get(int id)
        {
            return contacts.SingleOrDefault(c => c.Id == id);
        }

        public void Remove(int id)
        {
            contacts.Remove(Get(id));
        }

        public void Update(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
