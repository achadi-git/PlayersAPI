using System.Collections.Generic;

namespace PlayersWebAPI.Core.Entities
{
    public class Data
    {
        public int rank { get; set; }
        public int points { get; set; }
        public int weight { get; set; }
        public int height { get; set; }
        public int age { get; set; }
        public List<int> last { get; set; }
    }
}
