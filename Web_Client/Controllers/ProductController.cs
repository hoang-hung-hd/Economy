using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Web_Client.Models;

namespace Web_Client.Controllers
{
    public class ProductController : Controller
    {
        private const string baseUrl = "https://localhost:7226/";
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await CallConnectToApi<List<Product>>(HttpMethod.Get, "/product");
            return View(products);
        }

        public async Task<ActionResult> Details(int id)
        {
            Product product = await CallConnectToApi<Product>(HttpMethod.Get, "/product/" + id);
            return View(product);
        }

        // GET: UserController/Create
        public async Task<ActionResult> Create()
        {
            IEnumerable<Category> categories = await CallConnectToApi<List<Category>>(HttpMethod.Get, "/category");
            IEnumerable<Brand> brands = await CallConnectToApi<List<Brand>>(HttpMethod.Get, "/brand");

            ViewData["categories"] = categories;
            ViewData["brands"]= brands;
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {

            HttpContent content = new StringContent(JsonSerializer.Serialize(product), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await CallConnectToApi(HttpMethod.Post, "/product/", content);
            return RedirectToAction(nameof(Index));

        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            IEnumerable<Category> categories = await CallConnectToApi<List<Category>>(HttpMethod.Get, "/category");
            IEnumerable<Brand> brands = await CallConnectToApi<List<Brand>>(HttpMethod.Get, "/brand");

            ViewData["categories"] = categories;
            ViewData["brands"] = brands;

            Product product = await CallConnectToApi<Product>(HttpMethod.Get, "/product/" + id);
            return View(product);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product product)
        {
            try
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(product), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await CallConnectToApi(HttpMethod.Put, "/product/" + id, content);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || await CallConnectToApi<Product>(HttpMethod.Get, "/product/" + id) == null)
            {
                return NotFound();
            }

            var product = await CallConnectToApi<Product>(HttpMethod.Get, "/product/" + id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await CallConnectToApi(HttpMethod.Delete, "/category/" + id);
            return RedirectToAction(nameof(Index));
            /*return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await CallConnectToApi<List<Brand>>(HttpMethod.Get, "/brand")) });*/
        }

        public async Task<T> CallConnectToApi<T>(HttpMethod method, string pathUrl, HttpContent content = null)
        {
            try
            {
                var rs = await CallConnectToApi(method, pathUrl, content);
                return await rs.Content.ReadFromJsonAsync<T>();
            }
            catch
            {
                return default(T);
            }
        }

        public async Task<HttpResponseMessage> CallConnectToApi(HttpMethod method, string pathUrl, HttpContent content = null)
        {

            HttpRequestMessage request = new HttpRequestMessage(method, pathUrl);
            if (content != null)
            {
                request.Content = content;
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            return await client.SendAsync(request);
        }
    }
}
