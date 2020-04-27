using Newtonsoft.Json;

namespace Shop.Targeting
{
    public static class Extensions
    {
        public static string SerializeObject<TModel>(this TModel model)
        {
            return JsonConvert.SerializeObject(model);
        }
    }
}