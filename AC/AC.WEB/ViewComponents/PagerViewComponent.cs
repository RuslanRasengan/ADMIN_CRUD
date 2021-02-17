using Microsoft.AspNetCore.Mvc;
using AC.ViewModels;
using System.Threading.Tasks;

namespace AC.WEB.ViewComponents
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}