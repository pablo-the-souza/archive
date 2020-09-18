using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IPolicyRepository
    {
         Task <Policy> GetPolicyByIdAsync (Guid id);
         Task <IReadOnlyList<Policy>> GetPoliciesAsync(); 
    }
}