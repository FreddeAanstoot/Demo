using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Demo.Utils
{
    public class ExtendedObservableCollection<T> : ObservableCollection<T>
    {
        private bool isSuppressing = false;

        public ExtendedObservableCollection()
        {
        }

        public void AddRange(IEnumerable<T> addItems)
        {
            isSuppressing = true;

            try
            {
                foreach (T item in addItems)
                {
                    Add(item);
                }
            }
            finally
            {
                isSuppressing = false;
                SendReset();
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
                OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            }
        }

        public void RemoveRange(IEnumerable<T> removeItems)
        {
            isSuppressing = true;

            try
            {
                foreach (T item in removeItems)
                {
                    Remove(item);
                }
            }
            finally
            {
                isSuppressing = false;
                SendReset();
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
                OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            }
        }
        public void SendReset()
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (isSuppressing)
                return;

            base.OnCollectionChanged(e);
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (isSuppressing)
                return;

            base.OnPropertyChanged(e);
        }
    }
}
