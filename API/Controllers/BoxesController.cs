using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoxesController : ControllerBase
    {
        private readonly IBoxRepository _repo;
        public BoxesController(IBoxRepository repo)
        {
            _repo = repo;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<Box>>> GetBoxes()
        {
            var boxes = await _repo.GetBoxesAsync();

            return Ok(boxes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Box>> GetBox(Guid id)
        {
            return await _repo.GetBoxByIdAsync(id);
        }
    }
}