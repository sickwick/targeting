using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Shop.Storage.Extensions
{
    public static class HelperExtensions
    {
        /// <summary>
        /// Convert any type to json string
        /// </summary>
        /// <param name="model"></param>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        public static string SerializeObject<TModel>(this TModel model)
        {
            return JsonConvert.SerializeObject(model);
        }
        
        /// <summary>
        /// Convert to any type from json string
        /// </summary>
        /// <param name="jsonString"></param>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        public static TModel DeserializeObject<TModel>(this string jsonString)
        {
            return JsonConvert.DeserializeObject<TModel>(jsonString) ?? throw new NullReferenceException();
        }
        
        /// <summary>
        ///     Check if your enumerable null or not
        /// </summary>
        /// <param name="enumerable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns> True if your enumerable is empty</returns>
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