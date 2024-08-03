using Mapster;
using MemeGame.Domain.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGame.Domain.Games.Dto
{
    public class GameDto : IRegister
    {
        public string Name { get; set; }
        public List<UserDto> UsersCount { get; set; }
        public GameSettingsDto GameSettings { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Game, GameListItemDto>()
                .Map(g => g.UsersCount, g => g.GameUsers.Count);
        }
    }
}
