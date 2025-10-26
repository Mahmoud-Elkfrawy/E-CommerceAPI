using Depitest.IRepository;
using Depitest.Model;
using Depitest.Repository;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Depitest.Controllers
{
    // تعريف مسار الـ API الأساسي: api/Category
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // تعريف واجهة (Interface) خاصة بمستودع الفئات (Repository)
        ICategoryRepository _categoryRepository;

        // حقن الواجهة (Dependency Injection) في الكونستركتور
        public CategoryController(ICategoryRepository categoryRepository)
        {
            //_dbContext = dbContext;
            _categoryRepository = categoryRepository;
        }

        // جلب كل الفئات الموجودة
        [HttpGet]
        public ActionResult GetAll()
        {
            List<Categoray> category = _categoryRepository.Get();
            return Ok(category); // إرجاع قائمة الفئات مع كود 200 (OK)
        }

        // جلب فئة معينة باستخدام الـ id (رقم)
        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            Categoray category = _categoryRepository.GetById(id);
            return Ok(category); // إرجاع الفئة المطلوبة
        }

        // جلب فئة معينة باستخدام الاسم (حروف فقط)
        [HttpGet("{name:alpha}")]
        public ActionResult GetByName(string name)
        {
            Categoray category = _categoryRepository.GetByName(name);
            return Ok(category); // إرجاع الفئة المطلوبة بالاسم
        }

        // إضافة فئة جديدة
        [HttpPost]
        public ActionResult Add(Categoray category)
        {
            _categoryRepository.Add(category);
            // إرجاع كود 201 (Created) مع رابط الفئة الجديدة
            return Created($"/api/Category/{category.Id}", category);
        }

        // حذف فئة بناءً على الـ id
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _categoryRepository.Delete(id);
            return NoContent(); // إرجاع كود 204 بدون محتوى
        }

        // تحديث بيانات فئة موجودة
        [HttpPut]
        public ActionResult Update(Categoray category)
        {
            _categoryRepository.Update(category);
            return NoContent(); // إرجاع كود 204 بعد التحديث
        }

    }
}

