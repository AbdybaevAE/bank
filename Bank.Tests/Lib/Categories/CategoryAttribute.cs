using Xunit.Sdk;

namespace Bank.Tests.Lib.Categories
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class CategoryAttribute : Attribute, ITraitAttribute
    {
        public CategoryAttribute(TestCategory category)
        {
            _ = category;
        }
    }
}
