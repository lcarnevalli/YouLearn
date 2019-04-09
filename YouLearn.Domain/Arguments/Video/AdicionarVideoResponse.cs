using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Arguments.Video
{
    public class AdicionarVideoResponse
    {
        public Guid Id { get;  set; }

        public AdicionarVideoResponse(Guid id)
        {
            Id = id;
        }

    }
}
