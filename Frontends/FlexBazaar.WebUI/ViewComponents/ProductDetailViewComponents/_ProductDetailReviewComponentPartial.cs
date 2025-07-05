using FlexBazaar.DtoLayer.CommentDtos;
using FlexBazaar.WebUI.Services.CommentServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FlexBazaar.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial:ViewComponent
    {      
        private readonly ICommentService _commentService;

        public _ProductDetailReviewComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _commentService.CommentListByProductId(id);
            return View(values);
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("http://localhost:7263/api/Comments/CommentListByProductId?id=" + id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            //    return View(values);
            //}
            //return View();
        }
    }
}
