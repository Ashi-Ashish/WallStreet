using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Comment;
using api.Extensions;
using api.Helper;
using api.Interfaces;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepository;
        private readonly IFMPService _fMPService;
        private readonly IMapper _mapper;
        public CommentController(
            ICommentRepository commentRepository,
            IStockRepository stockRepository,
            IMapper mapper,
            UserManager<AppUser> userManager,
            IFMPService fMPService
        )
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
            _mapper = mapper;
            _userManager = userManager;
            _fMPService = fMPService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CommentQueryObject queryObject)
        {
            var comment = await _commentRepository.GetAllAsync(queryObject);
            var commentDTO = comment.Select(c => _mapper.Map<CommentDTO>(c));
            return Ok(commentDTO);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommentDTO>(comment));
        }

        [HttpPost]
        [Route("{symbol:alpha}")]
        public async Task<IActionResult> Create([FromRoute] string symbol, [FromBody] CreateCommentRequestDTO commentDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stock = await _stockRepository.GetBySymbolAsync(symbol);

            if (stock == null)
            {
                stock = await _fMPService.FindStockBySymbolAsync(symbol);
                if (stock == null)
                {
                    return BadRequest("Stock does not exists");
                }
                else
                {
                    await _stockRepository.CreateAsync(stock);
                }
            }


            var userEmail = User.GetUserEmail();
            var appUser = await _userManager.FindByEmailAsync(userEmail);
            var comment = _mapper.Map<Comment>(commentDto);
            comment.StockId = stock.Id;
            comment.AppUserId = appUser.Id;
            Console.WriteLine($"Comment.Stock: {comment.StockId}");
            await _commentRepository.CreateAsync(comment);
            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, _mapper.Map<CommentDTO>(comment));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDTO commentDto)
        {
            var updatedComment = await _commentRepository.UpdateAsync(id, commentDto);
            if (updatedComment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommentDTO>(updatedComment));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedComment = await _commentRepository.DeleteAsync(id);
            if (deletedComment == null)
            {
                return NotFound("Comment not found");
            }
            return Ok(deletedComment);
        }
    }
}