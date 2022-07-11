using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Web_Client.Models;

namespace Web_Client.Controllers
{
    public class BrandController : Controller
    {
        private const string baseUrl = "https://localhost:7226/";
        public async Task<IActionResult> Index()
        {
            IEnumerable<Brand> brands = await CallConnectToApi<List<Brand>>(HttpMethod.Get, "/brand");
            return View(brands);
        }

        public async Task<ActionResult> Details(int id)
        {
            Brand brand = await CallConnectToApi<Brand>(HttpMethod.Get, "/brand/" + id);
            return View(brand);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {

            HttpContent content = new StringContent(JsonSerializer.Serialize(brand), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await CallConnectToApi(HttpMethod.Post, "/brand/", content);
            return RedirectToAction(nameof(Index));

        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Brand brand = await CallConnectToApi<Brand>(HttpMethod.Get, "/brand/" + id);
            return View(brand);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Brand brand)
        {
            try
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(brand), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await CallConnectToApi(HttpMethod.Put, "/brand/" + id, content);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || await CallConnectToApi<Brand>(HttpMethod.Get, "/brand/" + id) == null)
            {
                return NotFound();
            }

            var brand = await CallConnectToApi<Brand>(HttpMethod.Get, "/brand/" + id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await CallConnectToApi(HttpMethod.Delete, "/brand/" + id);
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
