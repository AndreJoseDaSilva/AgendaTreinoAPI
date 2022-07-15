using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AgendaTreinoAPI.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AgendaTreinoAPI.Repository
{
    public sealed class AtletaRepository : IAtletaRepository
    {
        private readonly string _connectionString;

        public AtletaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AgendaTreinoDataServer");
        }

        public IEnumerable<Atleta> ListAll()
        {
            using var connection = new SqlConnection(_connectionString);

            var atletaData = connection.Query<Atleta>("Select * From Atleta Order by Nome");

            return atletaData;
        }

        public Atleta GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = @"Select * From Atleta Where id = @Id";

            Atleta atleta = connection.Query<Atleta>(query, new { Id = id }).FirstOrDefault();

            return atleta;
        }

        public int Insert(Atleta atleta)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = @"Insert Into Atleta (nome, apelido, celular) Values (@nome, @apelido, @celular)";

            var result = connection.Execute(query, new { nome = atleta.Nome, apelido = atleta.Aplelido, celular = atleta.Celular });

            return result;
        }
    }
}
