using System;

namespace Commons.ViewModel
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IsViewable: Attribute
    {
        public bool Value { get; set; }
    }
}