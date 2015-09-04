using System.Reflection;
using System.Web.Mvc;

namespace MvcDemo.Helpers
{
    public class AcceptButtonNameAttribute : ActionNameSelectorAttribute
    {
        public string Name { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var provider = new FormValueProvider(controllerContext);
            var value = provider.GetValue(Name);

            return value != null;
        }
    }
}