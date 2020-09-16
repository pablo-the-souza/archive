using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoxesController : ControllerBase
    {
        private readonly ArchiveContext _context;
        public BoxesController(ArchiveContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Box>>> GetBoxes()
        {
            var boxes = await _context.Boxes.ToListAsync();

            return Ok(boxes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Box>> GetBox(int id)
        {
            // string guid = id.ToString();
            return await _context.Boxes.FindAsync(id);
        }

    }
}