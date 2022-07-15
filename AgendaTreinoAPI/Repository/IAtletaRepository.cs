using AgendaTreinoAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTreinoAPI.Repository
{
    public interface IAtletaRepository
    {
        public IEnumerable<Atleta> ListAll();

        public Atleta GetById(int id);

        public int Insert(Atleta atleta);
    }
}
