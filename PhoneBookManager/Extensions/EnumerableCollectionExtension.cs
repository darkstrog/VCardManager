using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PhoneBookManager.Extensions
{
    internal static class EnumerableCollectionExtension
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerableCollection)
        {
            return enumerableCollection != null ? new ObservableCollection<T>(enumerableCollection) : null;
        }
    }
}
