using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Commons.Utility;
using Commons.ViewModel;
using Newtonsoft.Json;

namespace ConsumerWpfApp
{
    public static class ExtensionMethods
    {
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
