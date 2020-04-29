
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Shop.Database
{
    public static class Extensions
    {
        public static string SerializeObject<TModel>(this TModel model)
        {
            return JsonConvert.SerializeObject(model);
        }
        
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return true;
            }
           
            var collection = enumerable as ICollection<T>;
            if (collection != null)
            {
                return collection.Count < 1;
            }
            return !enumerable.Any(); 
        }
    }
}