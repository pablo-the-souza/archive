using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyRepository _repo;
        public PoliciesController(IPolicyRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Policy>>> GetBoxes()
        {
            var boxes = await _repo.GetPoliciesAsync();

            return Ok(boxes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetBox(Guid id)
        {
            return await _repo.GetPolicyByIdAsync(id);
        }
    }
}