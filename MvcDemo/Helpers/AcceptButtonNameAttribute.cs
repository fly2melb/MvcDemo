using System.Reflection;
using System.Web.Mvc;

namespace MvcDemo.Helpers
{
    public class AcceptButtonNameAttribute : ActionNameSelectorAttribute
    {
        public string Name { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            return controllerContext.Controller.ValueProvider.GetValue(Name) != null;
        }
    }
}