﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleUsuario.Models
{
    public class Token
    {
        public string Value { get; }

        public Token(string value)
        {
            Value = value;
        }
    }
}
