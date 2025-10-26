using Depitest.IRepository;
using Depitest.Model;
using Depitest.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Depitest.Controllers
{
    // تعريف مسار الـ API الأساسي: api/User
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // تعريف واجهة (Interface) خاصة بمستودع المستخدمين (Repository)
        IUserRepository _userRepository;

        // حقن الواجهة (Dependency Injection) في الكونستركتور
        public UserController(IUserRepository categoryRepository)
        {
            _userRepository = categoryRepository;
        }

        // جلب كل المستخدمين
        [HttpGet]
        public ActionResult GetAll()
        {
            List<User> User = _userRepository.Get();
            return Ok(User); // إرجاع قائمة المستخدمين مع كود 200 (OK)
        }

        // جلب مستخدم معين باستخدام الـ id (رقم)
        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            User user = _userRepository.GetById(id);
            return Ok(user); // إرجاع المستخدم المطلوب
        }

        // جلب مستخدم معين باستخدام الاسم (حروف فقط)
        [HttpGet("{name:alpha}")]
        public ActionResult GetByName(string UserName)
        {
            User user = _userRepository.GetByName(UserName);
            return Ok(user); // إرجاع المستخدم المطلوب بالاسم
        }

        // إضافة مستخدم جديد
        [HttpPost]
        public ActionResult Add(User User)
        {
            _userRepository.Add(User);
            // إرجاع كود 201 (Created) مع رابط المستخدم الجديد
            return Created($"/api/User/{User.Id}", User);
        }

        // حذف مستخدم بناءً على الـ id
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _userRepository.Delete(id);
            return NoContent(); // إرجاع كود 204 بدون محتوى
        }

        // تحديث بيانات مستخدم موجود
        [HttpPut]
        public ActionResult Update(User user)
        {
            _userRepository.Update(user);
            return NoContent(); // إرجاع كود 204 بعد التحديث
        }

        // التحقق من وجود اسم مستخدم محدد
        [HttpGet("Check/{UserName:alpha}")]
        public ActionResult CheckUserName(string UserName)
        {
            User user = _userRepository.GetByName(UserName);
            return Ok(user); // إرجاع بيانات المستخدم إذا وُجد
        }
    }
}
