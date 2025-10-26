using Depitest.IRepository;
using Depitest.Model;
using Depitest.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Depitest.Controllers
{
    // تعريف مسار الـ API الأساسي: api/Product
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // تعريف واجهة (Interface) خاصة بمستودع المنتجات (Repository)
        IProductRepository _productRepository;

        // حقن الواجهة (Dependency Injection) في الكونستركتور
        public ProductController(IProductRepository categoryRepository)
        {
            _productRepository = categoryRepository;
        }

        // جلب كل المنتجات
        [HttpGet]
        public ActionResult GetAll()
        {
            List<Product> product = _productRepository.Get();
            return Ok(product); // إرجاع قائمة المنتجات مع كود 200 (OK)
        }

        // جلب منتج معين باستخدام الـ id (رقم)
        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            Product product = _productRepository.GetById(id);
            return Ok(product); // إرجاع المنتج المطلوب
        }

        // جلب منتج معين باستخدام الاسم (حروف فقط)
        [HttpGet("{name:alpha}")]
        public ActionResult GetByName(string name) {
            Product product = _productRepository.GetByName(name);
            return Ok(product); // إرجاع المنتج المطلوب بالاسم
        }

        // إضافة منتج جديد
        [HttpPost]
        public ActionResult Add(Product product)
        {
            _productRepository.Add(product);
            // إرجاع كود 201 (Created) مع رابط المنتج الجديد
            return Created($"/api/Product/{product.Id}", product); 
        }

        // حذف منتج بناءً على الـ id
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            return NoContent(); // إرجاع كود 204 بدون محتوى
        }
        
        // تحديث بيانات منتج موجود
        [HttpPut]
        public ActionResult Update(Product product)
        {
            _productRepository.Update(product);
            return NoContent(); // إرجاع كود 204 بعد التحديث
        }
        
    }
}
﻿using Depitest.IRepository;
using Depitest.Model;
using Depitest.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Depitest.Controllers
{
    // تعريف مسار الـ API الأساسي: api/Product
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // تعريف واجهة (Interface) خاصة بمستودع المنتجات (Repository)
        IProductRepository _productRepository;

        // حقن الواجهة (Dependency Injection) في الكونستركتور
        public ProductController(IProductRepository categoryRepository)
        {
            _productRepository = categoryRepository;
        }

        // جلب كل المنتجات
        [HttpGet]
        public ActionResult GetAll()
        {
            List<Product> product = _productRepository.Get();
            return Ok(product); // إرجاع قائمة المنتجات مع كود 200 (OK)
        }

        // جلب منتج معين باستخدام الـ id (رقم)
        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            Product product = _productRepository.GetById(id);
            return Ok(product); // إرجاع المنتج المطلوب
        }

        // جلب منتج معين باستخدام الاسم (حروف فقط)
        [HttpGet("{name:alpha}")]
        public ActionResult GetByName(string name) {
            Product product = _productRepository.GetByName(name);
            return Ok(product); // إرجاع المنتج المطلوب بالاسم
        }

        // إضافة منتج جديد
        [HttpPost]
        public ActionResult Add(Product product)
        {
            _productRepository.Add(product);
            // إرجاع كود 201 (Created) مع رابط المنتج الجديد
            return Created($"/api/Product/{product.Id}", product); 
        }

        // حذف منتج بناءً على الـ id
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            return NoContent(); // إرجاع كود 204 بدون محتوى
        }
        
        // تحديث بيانات منتج موجود
        [HttpPut]
        public ActionResult Update(Product product)
        {
            _productRepository.Update(product);
            return NoContent(); // إرجاع كود 204 بعد التحديث
        }
        
    }
}
