﻿using FlexBazaar.DtoLayer.CatalogDtos.ProductDtos;
using FlexBazaar.DtoLayer.CommentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FlexBazaar.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasaya";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi";
            ViewBag.v0 = "Yorum İşlemleri";

            var client = _httpClientFactory.CreateClient();

            // Yorumları listele

            var responseMessage = await client.GetAsync("http://localhost:7263/api/Comments");

            if (!responseMessage.IsSuccessStatusCode)

            {

                return View();

            }

            var data = await responseMessage.Content.ReadAsStringAsync();

            var comments = JsonConvert.DeserializeObject<List<ResultCommentDto>>(data);


            // Ürünleri listele

            var productResponse = await client.GetAsync("http://localhost:7017/api/Products");

            if (!productResponse.IsSuccessStatusCode)

            {

                return View(comments);

            }

            var productData = await productResponse.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(productData);


            // Yorumlara uygun ürün isimlerini eşitle

            foreach (var comment in comments)

            {

                var matchedProduct = products.FirstOrDefault(p => p.ProductId == comment.ProductId);

                if (matchedProduct != null)

                {

                    comment.ProductName = matchedProduct.ProductName;

                }

            }


            return View(comments);
        }    

        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("http://localhost:7263/api/Comments?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateComment/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateComment(string id)
        {

            ViewBag.v1 = "Anasaya";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi";
            ViewBag.v0 = "Yorum İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7263/api/Comments/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCommentDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [Route("UpdateComment/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            updateCommentDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:7263/api/Comments/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }
    }
}
