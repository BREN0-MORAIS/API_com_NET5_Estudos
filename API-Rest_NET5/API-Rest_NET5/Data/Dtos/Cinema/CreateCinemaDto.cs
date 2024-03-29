﻿using API_Rest_NET5.Models;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }

        //public Endereco Endereco { get; set; }
        //public int EnderecoFK { get; set; }
        //public int GerenteFK { get; set; }
    }
}
