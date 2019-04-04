using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.ValueObjects;
using YouLearn.Infra.Persistence.EF;

namespace YouLearn.Infra.Persistence.Repositories
{
    

    public class RepositoryCanal : IRepositoryCanal
    {
        private readonly YouLearnContext _context;

        public RepositoryCanal(YouLearnContext context)
        {
            _context = context;
        }

        public Canal Adicionar(Canal canal)
        {
           _context.Canais.Add(canal);

            return canal;
    
        }

        public void Excluir(Canal canal)
        {
            _context.Canais.Remove(canal);
            
        }

        public IEnumerable<Canal> Listar(Guid IdUsuario)
        {
            //o tolist retorna todos.
            // se eu quisesse trazer de pouco em pouco, 
            // as no tracking retira todo o controle de estado do objeto no banco. isso torna mais rápido sem este rastreamento
            return _context.Canais.Where(x => x.Usuario.Id == IdUsuario).AsNoTracking().ToList();
        }

        public Canal Obter(Guid idCanal)
        {
            return _context.Canais.FirstOrDefault(x => x.Id == idCanal);
        }

        //public bool Existe(Email email)
        //{
        //    return _context.Usuarios.Any(x => x.Email == email);

        //}

        //public Usuario Obter(Guid id)
        //{
        //    return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        //}

        //public Usuario Obter(Email email, Senha senha)
        //{
        //    return _context.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        //}

        //public void Salvar(Usuario usuario)
        //{
        //    _context.Usuarios.Add(usuario);

        //}
    }
}
