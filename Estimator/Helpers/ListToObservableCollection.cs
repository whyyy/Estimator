using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Estimator.Helpers
{
    static class ListToObservableCollection
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            var _observableCollection = new ObservableCollection<T>();
            foreach (var element in collection)
                _observableCollection.Add(element);
            return _observableCollection;
        }

    }
}
