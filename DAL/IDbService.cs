using APBD04.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD04.DAL
{
    public class IDbService
    {
        public IEnumerable<Animal> Animals { get; }
    }
}
