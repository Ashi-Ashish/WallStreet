using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Comment;
using api.Interfaces;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        public CommentController(
            ICommentRepository commentRepository,
            IStockRepository stockRepository,
            IMapper mapper
            )
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comment = await _commentRepository.GetAllAsync();
            var commentDTO = comment.Select(c => _mapper.Map<CommentDTO>(c));
            return Ok(commentDTO);
        }

        [HttpGet]
        [Route("{id}")]
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
        [Route("{stockId}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentRequestDTO commentDto)
        {
            if (!await _stockRepository.IsStockExistsAsync(stockId))
            {
                return BadRequest("Stock does not exist");
            }
            var comment = _mapper.Map<Comment>(commentDto);
            comment.StockId = stockId;
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