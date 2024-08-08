using ASP_DBSlide.Handlers;
using ASP_DBSlide.Mapper;
using ASP_DBSlide.Models.User;
using BLL_DBSlide.Entities;
using BLL_DBSlide.Entities.Enums;
using Common_DBSlide.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_DBSlide.Controllers
{
    
    public class AuthController : Controller
    {
        private readonly IUserRepository<User, Role> _userRepository;
        private readonly SessionManager _sessionManager;

        public AuthController(IUserRepository<User, Role> userRepository, SessionManager sessionManager)
        {
            _userRepository = userRepository;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [NotConnectedAuthorize]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginForm form)
        {
            try
            {
                if(!ModelState.IsValid) throw new Exception();
                //Si formulaire valide : vérifier résultat serveur
                Guid? id = _userRepository.CheckPassword(form.Email, form.Password);
                //Si Guid : Alors sauvegarder en session
                if(id is null) throw new Exception();
                _sessionManager.CurrentUser = _userRepository.Get((Guid)id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }

        [NotConnectedAuthorize]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterForm form)
        {
            if(_sessionManager.CurrentUser is not null) return RedirectToAction("Index");
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                User bll = form.ToBLL();
                bll.User_Id = _userRepository.Insert(bll);
                bll.Password = "********";
                //Enregistre la présence de l'utilisateur
                _sessionManager.CurrentUser = bll;
                return RedirectToAction("Index");
            }
            catch
            {
                return View(form);
            }
        }

        [ConnectedAuthorize]
        public IActionResult Logout() { return View(); }
        [HttpPost]
        public IActionResult Logout(Guid userId) {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                _sessionManager.CurrentUser = null;
                return RedirectToAction(nameof(Login));
            }
            catch 
            {
                return RedirectToAction(nameof(Index),"Home");
            }
        
        }
    }
}
