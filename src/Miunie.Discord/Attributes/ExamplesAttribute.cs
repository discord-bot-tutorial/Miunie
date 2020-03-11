using System;

namespace Miunie.Discord.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ExamplesAttribute : Attribute
    {
        public ExamplesAttribute(params string[] examples)
        {
            Examples = examples;
        }
        public string[] Examples { get; }
    }
}
