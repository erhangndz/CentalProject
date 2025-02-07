using AutoMapper;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultManagerComponent(UserManager<AppUser> _userManager,IMapper _mapper): ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var managers = await _userManager.GetUsersInRoleAsync("Manager");
            var dto = _mapper.Map<List<ResultUserDto>>(managers);
            return View(dto.TakeLast(4).ToList());
        }
    }
}
