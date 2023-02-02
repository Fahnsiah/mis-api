using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MISAPI.DAL.Interfaces;
using MISAPI.DataModel.ViewModels;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MIS_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleInterface _articleService;

        private readonly IMapper _mapper;

        public ArticleController(
            IArticleInterface articleService,
            IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        // GET: api/<TransactionTypeController>
        [HttpGet]
        public ActionResult<IEnumerable<ArticleResponse>> Get()
        {
            var data = _articleService.GetAll();
            return Ok(data);
        }

        // GET api/<TransactionTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<ArticleResponse> Get(int id)
        {
            var data = _articleService.GetById(id);
            return Ok(data);
        }

        // POST api/<TransactionTypeController>
        [HttpPost]
        public ActionResult<ArticleResponse> Post([FromBody] ArticleRequest model)
        {
            var data = _articleService.Create(model);
            return Ok(data);
        }

        // PUT api/<TransactionTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<ArticleResponse> Put(int id, [FromBody] ArticleRequest model)
        {
            var data = _articleService.Update(id, model);
            return Ok(data);
        }

        // DELETE api/<TransactionTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _articleService.Delete(id);
            return Ok(new { message = "Record deleted successfully" });
        }    
    
    }
}
