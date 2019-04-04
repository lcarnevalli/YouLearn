﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.ValueObjects;
using YouLearn.Infra.Persistence.EF;

namespace YouLearn.Infra.Persistence.Repositories
{
    

    public class RepositoryUsuario : IRepositoryUsuario
    {
        private readonly YouLearnContext _context;

        public RepositoryUsuario(YouLearnContext context)
        {
            _context = context;
        }

        public bool Existe(Email email)
        {
            return _context.Usuarios.Any(x => x.Email == email);

        }

        public Usuario Obter(Guid id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public Usuario Obter(Email email, Senha senha)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }

        public void Salvar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);

        }
    }
}