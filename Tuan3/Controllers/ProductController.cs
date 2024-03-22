using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;
using Tuan3.Models;

namespace Tuan3.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private object imageUrl;

        public ProductController(IProductRepository productRepository,
        ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        // Hiển thị danh sách sản phẩm
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }

        // Hiển thị form thêm sản phẩm mới
        public async Task<IActionResult> Create()
        {

            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }
        // Xử lý thêm sản phẩm mới
        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            if (ModelState.IsValid)
            {
                if(imageUrl != null)
                {
                    //Lưu hình ảnh đại diện
                    product.ImageUrl = await SaveImage(imageUrl);
                }
                await _productRepository.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(product);
        }

        private async Task<string> SaveImage(IFormFile imageUrl)
        {
            var savePath = Path.Combine("wwwroot/images", imageUrl.FileName);
            //THAY DOI DƯỜNG DẪN CẤU HÌNH
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
                return "/images/" + Image.FileName; //trả về đường dẫn tương đối
            }
        }
    }
}

