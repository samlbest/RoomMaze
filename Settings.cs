using Microsoft.Framework.ConfigurationModel;

namespace RoomMaze
{
	
    public class Settings
    {
        public Settings()
        {
            
        }
        public Settings(IConfiguration configuration)
        {
            this.Database = configuration.Get("database");
            this.MongoConnection = configuration.Get("mongoconnection"); 
        }
        public string Database { get; set; }
        public string MongoConnection { get; set; }
    }
}