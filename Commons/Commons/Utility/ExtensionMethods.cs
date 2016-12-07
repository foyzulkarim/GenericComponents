using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Commons.ViewModel;
using Newtonsoft.Json;

namespace Commons.Utility
{
    public static class ExtensionMethods
    {
        public static object GetValue(this object obj, List<PropertyInfo> propertyInfos)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (var p in propertyInfos)
            {
                var value = p.GetValue(obj);
                dictionary.Add(p.Name, value);
            }
            var expandoObject = new ExpandoObject();
            var keyValuePairs = (ICollection<KeyValuePair<string, object>>)expandoObject;
            foreach (var kvp in dictionary)
            {
                keyValuePairs.Add(kvp);
            }
            return expandoObject;
        }

        public static List<dynamic> ConvertToViewableDynamicList(this List<object> models)
        {
            Type modelType = models.First().GetType();
            //you should send the IsViewable type as parameter. I didn't do this because i don't need to
            Type viewable = typeof(IsViewable);
            List<PropertyInfo> propertyInfos = modelType.GetProperties().Where(x => x.CustomAttributes.Any(y => y.AttributeType == viewable)).ToList();
            List<dynamic> list = models.Select(x => x.GetValue(propertyInfos)).ToList();
            List<dynamic> deserializeObject = JsonConvert.DeserializeObject<List<dynamic>>(JsonConvert.SerializeObject(list));
            return deserializeObject;
        }
    }
}
