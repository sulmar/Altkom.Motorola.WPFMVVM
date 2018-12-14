using Altkom.Motorola.IServices;
using Altkom.Motorola.Models;
using System.Collections.Generic;

namespace Altkom.Motorola.ViewModels
{
    public class ItemsViewModel<TItem, TItemsService> : BaseViewModel
        where TItem : Base
        where TItemsService : IItemsService<TItem>

    {
        public ICollection<TItem> Items { get; set; }

        private readonly TItemsService itemsService;

        public ItemsViewModel(TItemsService itemsService)
        {
            this.itemsService = itemsService;

            Load();
        }

        public virtual void Load()
        {
            Items = itemsService.Get();
        }




    }
}
