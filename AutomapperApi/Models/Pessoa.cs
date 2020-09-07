﻿using System;

namespace AutomapperApi.Models
{

    public class Pessoa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }

        public string Endereco { get; set; }
    }
}
