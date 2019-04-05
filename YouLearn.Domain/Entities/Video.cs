using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Enums;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Entities
{
    public class Video : EntityBase
    {
        public Video(Canal canal, PlayList playList, string titulo, string descricao, string tags, int ordemNaPlayList, string idVideoYoutube, Usuario usuarioSugeriu)
        {
            Canal = canal;
            PlayList = playList;
            Titulo = titulo;
            Descricao = descricao;
            Tags = tags;
            OrdemNaPlayList = ordemNaPlayList;
            IdVideoYoutube = idVideoYoutube;
            UsuarioSugeriu = usuarioSugeriu;
            Status = EnumStatus.EmAnalise;
            new AddNotifications<Video>(this)
                 .IfNullOrInvalidLength(x => x.Descricao, 2, 500, MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("2", "500"));

            AddNotifications(UsuarioSugeriu, canal, playList);

        }

        //public Guid Id { get; set; }
        public Canal Canal { get; private set; }
        public PlayList PlayList { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Tags { get; private set; }
        public int OrdemNaPlayList { get; private set; }
        public string IdVideoYoutube { get; private set; }
        public Usuario UsuarioSugeriu { get; private set; }
        public EnumStatus Status { get; private set; }
        
    }
}
