using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaTreinoAPI.Domain;
using AgendaTreinoAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgendaTreinoAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtletaController : ControllerBase
    {
        private readonly ILogger<AtletaController> _logger;
        private readonly IAtletaRepository _atletaRepository;

        public AtletaController(ILogger<AtletaController> logger, IAtletaRepository atletaRepository)
        {
            _logger = logger;
            _atletaRepository = atletaRepository;   
        }

        [HttpGet]
        public IActionResult GetAllData()
        {
            try
            {
                var data = _atletaRepository.ListAll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, @"Erro ao obter dados.");
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _atletaRepository.GetById(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, @"Erro ao obter dados.");
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult SetData([FromBody] Atleta atleta)
        {
            try
            {
                var result = _atletaRepository.Insert(atleta);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, @"Erro ao inserir dados.");
                return new StatusCodeResult(500);
            }
        }
    }
}
