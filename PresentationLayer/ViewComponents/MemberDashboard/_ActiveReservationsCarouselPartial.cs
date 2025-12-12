using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewComponents.MemberDashboard
{
    public class _ActiveReservationsCarouselPartial : ViewComponent
    {
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _userManager;

        public _ActiveReservationsCarouselPartial(IReservationService reservationService, UserManager<AppUser> userManager)
        {
            _reservationService = reservationService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User?.Identity?.IsAuthenticated == true && !string.IsNullOrEmpty(User.Identity.Name))
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    var activeReservations = _reservationService.GetListWithReservationByAccepted(user.Id).Take(3).ToList();
                    return View(activeReservations);
                }
            }
            return View(new System.Collections.Generic.List<Reservation>());
        }
    }
}

