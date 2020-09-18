using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBoxRepository
    {
         Task <Box> GetBoxByIdAsync (Guid id);
         Task <IReadOnlyList<Box>> GetBoxesAsync(); 
    }
}