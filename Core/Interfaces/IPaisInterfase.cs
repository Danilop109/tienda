using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces;
public interface IPaisInterfase : IGenericRepoA<Pais>
{
    Task<Pais> GetByIdAsync(string id);
}
