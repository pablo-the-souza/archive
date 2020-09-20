using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoliciesController : ControllerBase
    {
        private readonly IGenericRepository<Policy> _policiesRepo;
        private readonly IMapper _mapper;
        public PoliciesController(IGenericRepository<Policy> policiesRepo, IMapper mapper)
        {
            _mapper = mapper;
            _policiesRepo = policiesRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PolicyToReturnDTO>>> GetPolicies()
        {
            var spec = new PoliciesWithBoxSpecification();

            var policies = await _policiesRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Policy>, IReadOnlyList<PolicyToReturnDTO>>(policies)); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PolicyToReturnDTO>> GetPolicy(Guid id)
        {
            var spec = new PoliciesWithBoxSpecification(id);

            var policy = await _policiesRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Policy, PolicyToReturnDTO>(policy);
        }
    }
}