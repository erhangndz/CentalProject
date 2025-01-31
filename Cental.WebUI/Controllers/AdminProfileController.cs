using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminProfileController(UserManager<AppUser> _userManager, IImageService _imageService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var profileEditDto = user.Adapt<ProfileEditDto>();

            return View(profileEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ProfileEditDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            var succeed = await _userManager.CheckPasswordAsync(user, model.CurrentPassword);
            if (succeed)
            {
                if (model.ImageFile != null)
                {
                    try
                    {
                        model.ImageUrl = await _imageService.SaveImageAsync(model.ImageFile);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(model);

                    }




                }


                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.ImageUrl = model.ImageUrl;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "AdminAbout");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            ModelState.AddModelError(string.Empty, "Girdiğiniz şifre hatalı, güncelleme yapılamadı");
            return View(model);
        }
    }
}
