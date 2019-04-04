using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Arguments.Video
{
    public class AdicionarVideoRequest
    {

        public Guid idCanal { get; set; }
        public Guid idPlayList { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Tags { get; set; }
        public int OrdemNaPlayList { get; set; }
        public string IdVideoYoutube { get; set; }
       

    }
}
