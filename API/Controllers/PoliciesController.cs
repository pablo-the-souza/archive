using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PoliciesController : BaseAPIController
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PolicyToReturnDTO>> GetPolicy(Guid id)
        {
            var spec = new PoliciesWithBoxSpecification(id);

            var policy = await _policiesRepo.GetEntityWithSpec(spec);

            if (policy == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Policy, PolicyToReturnDTO>(policy);
        }
    }
}