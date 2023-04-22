using Xunit.Abstractions;
using Xunit.Sdk;

namespace Bank.Tests.Lib.Categories
{
    public class CategoryDiscoverer : ITraitDiscoverer
    {
        public const string Key = "category";

        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var ctorArgs = traitAttribute.GetConstructorArguments().ToList();
            yield return new KeyValuePair<string, string>(Key, ctorArgs[0].ToString());
        }
    }
}