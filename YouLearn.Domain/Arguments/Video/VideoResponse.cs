using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Arguments.Video
{
    public class VideoResponse
    {
        public Guid IdVideo { get; private set; }
        //public Guid idCanal { get; private set; }
        //public Guid idPlayList { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Tags { get; private set; }
        public int OrdemNaPlayList { get; private set; }
        public string IdVideoYoutube { get; private set; }
        public EnumStatus Status { get; private set; }

        public static explicit operator VideoResponse(Entities.Video entidade)
        {
            return new VideoResponse()
            {
                IdVideo = entidade.Id,
                Titulo = entidade.Titulo,
                Descricao = entidade.Descricao,
                Tags = entidade.Tags,
                OrdemNaPlayList = entidade.OrdemNaPlayList,
                IdVideoYoutube = entidade.IdVideoYoutube,
                Status = entidade.Status
            };
        }
    }
}
