using Microsoft.Framework.OptionsModel;
using RoomMaze.Models;
using System;
using System.Collections.Generic;
using System.Net;
using MongoDB.Driver;
using MongoDB.Bson;

using System.Linq;
using System.Threading.Tasks;

namespace RoomMaze.Repositories
{

    public class MongoRepository
    {
        private readonly IOptions<Settings> _settings;
        private readonly IMongoDatabase _database;
        
        protected IMongoDatabase Database
        {
            get
            {
                return _database;
            }
        }
        

        public MongoRepository(IOptions<Settings> settings)
        {
            this._settings = settings;
            this._database = Connect();
            System.Console.WriteLine("repo constructor finished");
        }
        
        private IMongoDatabase Connect()
        {

            var client = new MongoClient(_settings.Options.MongoConnection);

            var database = client.GetDatabase(_settings.Options.Database);
            System.Console.WriteLine(_settings.Options.Database);
            return database;
        }
    }
}