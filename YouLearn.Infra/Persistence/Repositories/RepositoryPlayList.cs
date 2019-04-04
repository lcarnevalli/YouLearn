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
    

    public class RepositoryPlayList : IRepositoryPlayList
    {
        private readonly YouLearnContext _context;

        public RepositoryPlayList(YouLearnContext context)
        {
            _context = context;
        }

        public PlayList Adicionar(PlayList playList)
        {
           _context.PlayLists.Add(playList);

            return playList;
    
        }

        public void Excluir(PlayList playList)
        {
            _context.PlayLists.Remove(playList);
            
        }

        public IEnumerable<PlayList> Listar(Guid IdUsuario)
        {
            //o tolist retorna todos.
            // se eu quisesse trazer de pouco em pouco, 
            // as no tracking retira todo o controle de estado do objeto no banco. isso torna mais rápido sem este rastreamento
            return _context.PlayLists.Where(x => x.Usuario.Id == IdUsuario).AsNoTracking().ToList();
        }

        public PlayList Obter(Guid idPlayList)
        {
            return _context.PlayLists.FirstOrDefault(x => x.Id == idPlayList);
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
