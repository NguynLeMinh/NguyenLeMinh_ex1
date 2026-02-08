
using Microsoft.AspNetCore.Mvc;
using NguyenLeMinh_ex1.Models;

namespace NguyenLeMinh_ex1.Controllers
{
    public class ToDoControl : Controller
    {
        static List<Todo> todos = new List<Todo>
        {
            new Todo { Id = 1, TenCongViec = "Đi chợ", HoanThanh = false },
            new Todo { Id = 2, TenCongViec = "Chơi thể thao", HoanThanh = true },
            new Todo { Id = 3, TenCongViec = "Chơi game", HoanThanh = false },
            new Todo { Id = 4, TenCongViec = "Học bài", HoanThanh = true }
        };

        public IActionResult Index()
        {
            return View(todos);
        }

        public IActionResult Chitiet(int id)
        {
            var todo = todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        [HttpGet]
        public IActionResult Tao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Tao(Todo todo)
        {
            if (ModelState.IsValid)
            {
                todo.Id = todos.Max(t => t.Id) + 1;
                todos.Add(todo);
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        [HttpGet]
        public IActionResult Sua(int id)
        {
            var todo = todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        [HttpPost]
        public IActionResult Sua(Todo todo)
        {
            var t = todos.FirstOrDefault(x => x.Id == todo.Id);
            t.TenCongViec = todo.TenCongViec;
            t.HoanThanh = todo.HoanThanh;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Xoa(int id)
        {
            var todo = todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            todos.Remove(todo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult XoaXN(int id)
        {
            var todo = todos.FirstOrDefault(t => t.Id == id);
            todos.Remove(todo);
            return RedirectToAction("Index");
        }
    }
}
