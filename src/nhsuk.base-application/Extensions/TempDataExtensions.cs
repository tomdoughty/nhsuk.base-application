using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace nhsuk.base_application.Extensions
{
    internal static class TempDataExtensions
    {
        public static T Get<T>(this ITempDataDictionary tempData) where T:class
            => tempData.TryPeek(typeof(T).Name, out var data) ? JsonConvert.DeserializeObject<T>(data) : null;

        public static void Set<T>(this ITempDataDictionary tempData, T incomingTempData)
            => tempData[typeof(T).Name] = JsonConvert.SerializeObject(incomingTempData);

        private static bool TryPeek(this ITempDataDictionary tempData, string key, out string value)
        {
            switch (tempData.Peek(key))
            {
                case string temp:
                    value = temp;
                    return true;
                default:
                    value = string.Empty;
                    return false;
            }
        }
    }
}