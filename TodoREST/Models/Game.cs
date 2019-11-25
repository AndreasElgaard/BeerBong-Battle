using System.Collections.Generic;

namespace TodoREST.Models
{
    public class Game
    {
        public int gameId { get; set; }
        public List<Player> players { get; set; }
    }
}