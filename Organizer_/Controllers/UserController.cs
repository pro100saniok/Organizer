using Organizer_.Security;
using Organizer_.ViewModel;
using Organizer_Domain.Contracts.Repository;
using Organizer_Domain.EntityModel;
using System.Data;
using System.Web.Mvc;
using System.Web.Security;

namespace Organizer_.Controllers
{
    /// <summary>
    ///  Контролер для роботи з користувачами на сайті
    /// </summary>
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Вхід в сайт.
        /// </summary>
        /// <returns></returns>
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                //Перевірка правильності введених даних
                if (ModelState.IsValid)
                {
                    //Пошук користувача по імені та паролю
                    var customer = _userRepository.GetUserByEmailAndPassword(model.Email, CryptPassword.Hash(model.Password));
                    //Якщо користувач найдений робиться вхід.
                    if (customer != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    ModelState.AddModelError("", @"Ім'я або пароль введені неправильно спробуйте ще раз.");
                }
                ModelState.AddModelError("", @"Введіть коректні дані!");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", @"Неможливо ввійти. <br/> Спробуйте ще раз.");
            }

            return View(model);
        }

        /// <summary>
        ///  Реєстрація користувача.
        /// </summary>
        /// <returns></returns>
        public ActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model, string returnUrl)
        {
            try
            {
                //Перевірка правильності введених данних.
                if (ModelState.IsValid)
                {
                    //Перевірка чи немає користувача з таким Email.
                    if (!_userRepository.CheckIfEmailExistInDb(model.Name))
                    {
                        //Створення нового користувача.
                        var newUser = new User
                        {
                            Email = model.Name,
                            Password = CryptPassword.Hash(model.Password),
                        };
                        var user = _userRepository.SaveUser(newUser);
                        //Якщо користувач добавлений в бд, перенаправлення на головну сторінку.
                        if (user != null)
                        {
                            FormsAuthentication.SetAuthCookie(model.Name, true);
                            if (Url.IsLocalUrl(returnUrl))
                            {
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                    ModelState.AddModelError("", @"Користувач з таким поштовою адресою вже зареєстрований!");
                }
                ModelState.AddModelError("", @"Введіть коректні дані!");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", @"Неможливо зареєструватися. Спробуйте ще раз.");
            }
            return View(model);
        }

        /// <summary>
        ///  Вихід з сайту.
        /// </summary>
        /// <returns></returns>
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }


}