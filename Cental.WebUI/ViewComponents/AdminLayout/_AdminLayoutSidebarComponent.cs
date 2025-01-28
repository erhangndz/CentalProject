using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.AdminLayout
{
	public class _AdminLayoutSidebarComponent(UserManager<AppUser> _userManager) : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);

			ViewBag.nameSurname = string.Join(" ", user.FirstName, user.LastName);
			ViewBag.userImage = user.ImageUrl;
			return View();
		}
	}
}
