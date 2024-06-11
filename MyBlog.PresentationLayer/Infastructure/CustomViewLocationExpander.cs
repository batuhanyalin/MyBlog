using Microsoft.AspNetCore.Mvc.Razor;

namespace MyBlog.PresentationLayer.Infastructure
{
    public class CustomViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            // Mevcut viewLocations listesine ekleme yapıyoruz
            var customLocations = new List<string>
            {
                "/Areas/{2}/Views/Shared/Components/{1}/{0}.cshtml",
                "/Views/Shared/Components/{1}/{0}.cshtml"
            };

            return customLocations.Concat(viewLocations);
        }

        public void PopulateValues(ViewLocationExpanderContext context) { }
    }
}
