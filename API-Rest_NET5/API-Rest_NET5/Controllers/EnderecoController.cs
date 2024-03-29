﻿using API_Rest_NET5.Data.Dtos.Endereco;
using API_Rest_NET5.Models;
using AutoMapper;
using FilmesApi.Data;
using FilmesAPI.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API_Rest_NET5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController:ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto createEnderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(createEnderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable<Endereco> RecuperaEnderecos([FromQuery] string nomeDoFilme)
        {
            return _context.Enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            var  endereco = _context.Enderecos.FirstOrDefault(Endereco => Endereco.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto EnderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return Ok(EnderecoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
