using System;
using System.Collections.ObjectModel;

namespace Alternet.UI
{
    public class Collection<T> : ObservableCollection<T>
    {
        public event EventHandler<CollectionChangeEventArgs<T>>? ItemInserted;

        public event EventHandler<CollectionChangeEventArgs<T>>? ItemRemoved;

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);

            OnItemInserted(new CollectionChangeEventArgs<T>(index, item));
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];
            base.RemoveItem(index);

            OnItemRemoved(new CollectionChangeEventArgs<T>(index, item));
        }

        protected virtual void OnItemInserted(CollectionChangeEventArgs<T> e) => ItemInserted?.Invoke(this, e);

        protected virtual void OnItemRemoved(CollectionChangeEventArgs<T> e) => ItemRemoved?.Invoke(this, e);
    }
}