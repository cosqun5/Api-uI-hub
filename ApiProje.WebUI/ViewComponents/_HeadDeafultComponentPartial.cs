using Microsoft.AspNetCore.Mvc;

namespace ApiProje.WebUI.ViewComponenets
{
	public class _HeadDeafultComponentPartial: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
