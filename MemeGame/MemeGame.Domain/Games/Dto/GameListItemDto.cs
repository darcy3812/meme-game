using Mapster;

namespace MemeGame.Domain.Games.Dto
{
    public class GameListItemDto : IRegister
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UsersCount { get; set; }
        public GameSettingsDto GameSettings { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Game, GameListItemDto>()
                .Map(g => g.UsersCount, g => g.GameUsers.Count);
        }
    }
}