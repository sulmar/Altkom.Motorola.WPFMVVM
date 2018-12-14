using Altkom.Motorola.Models;
using System.Collections.Generic;

namespace Altkom.Motorola.IServices
{
    public interface IItemsService<TItem>
        where TItem : Base
    {
        ICollection<TItem> Get();
        TItem Get(int id);
        void Add(TItem item);
        void Update(TItem item);
        void Remove(int id);
    }
}
