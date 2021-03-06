﻿using Microsoft.EntityFrameworkCore;
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
    

    public class RepositoryVideo : IRepositoryVideo
    {
        private readonly YouLearnContext _context;

        public RepositoryVideo(YouLearnContext context)
        {
            _context = context;
        }

        public Video Adcionar(Video video)
        {
               _context.Videos.Add(video);

                return video;
        }

        public void Excluir(Video video)
        {
            _context.Videos.Remove(video);
        }

        public bool ExisteCanalAssociado(Guid idCanal)
        {
            return _context.Videos.Any(x => x.Canal.Id == idCanal);
        }

        public bool ExistePlayListAssociada(Guid idPlayList)
        {

            //return (_context.PlayLists.Count(x => x.Id == idPlayList) != 0);
            return _context.Videos.Any(x => x.PlayList.Id == idPlayList);
        }

        public IEnumerable<Video> Listar(Guid idPlayList)
        {
            return _context.Videos.Include(x => x.Canal).Include(x => x.PlayList)
                .Where(x => x.PlayList.Id == idPlayList).ToList();
            //return _context.Videos.Where(x => x.id == idPlayList).AsNoTracking().ToList();
        }

        public IEnumerable<Video> Listar(string tags)
        {
            //return _context.Videos.Where(x => x.Tags == tags).AsNoTracking().ToList();
            var query = _context.Videos.Include(x => x.Canal).Include(x => x.PlayList).AsQueryable();
            tags.Split(' ').ToList().ForEach(tag =>
                {
                    query = query.Where(x => x.Tags.Contains(tag) || x.Titulo.Contains(tag) || x.Descricao.Contains(tag));

                });
            return query.ToList();

        }

        public IEnumerable<Video> ListarCanal(Guid IdUsuario, Guid idCanal)
        {
            return _context.Videos.Where(x => x.UsuarioSugeriu.Id == IdUsuario && x.Canal.Id == idCanal).AsNoTracking().ToList();
        }

        public IEnumerable<Video> ListarPlayList(Guid IdUsuario, Guid idPlayList)
        {
            return _context.Videos.Where(x => x.UsuarioSugeriu.Id == IdUsuario && x.PlayList.Id == idPlayList).AsNoTracking().ToList();
        }

        public Video Obter(Guid idVideo)
        {
            return _context.Videos.FirstOrDefault(x => x.Id == idVideo);
        }

        //public Canal Adicionar(Canal canal)
        //{
        //   _context.Canais.Add(canal);

        //    return canal;

        //}

        //public void Excluir(Canal canal)
        //{
        //    _context.Canais.Remove(canal);

        //}

        //public IEnumerable<Canal> Listar(Guid IdUsuario)
        //{
        //    //o tolist retorna todos.
        //    // se eu quisesse trazer de pouco em pouco, 
        //    // as no tracking retira todo o controle de estado do objeto no banco. isso torna mais rápido sem este rastreamento
        //    return _context.Canais.Where(x => x.Usuario.Id == IdUsuario).AsNoTracking().ToList();
        //}

        //public Canal Obter(Guid idCanal)
        //{
        //    return _context.Canais.FirstOrDefault(x => x.Id == idCanal);
        //}


    }
}
