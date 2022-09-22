using Settings;

namespace Core
{
    public interface IEnemy
    {
        public GameSettings Settings { get; set; }
        public string Id { get; set; }
    }
}

