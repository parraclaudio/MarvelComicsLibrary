using MarvelComicsLibrary.Domain.Entity.Base;
using MarvelComicsLibrary.Repository.Context;
using MarvelComicsLibrary.Repository.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Repository.Repository
{
    public class BaseRepository<T> : BaseEntity, IBaseRepository<T>
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly string _databaseName;

        public BaseRepository(IConfiguration configuration)
        {
            IConfigurationSection section = configuration.GetSection("MongoDB");

            _connectionFactory = new ConnectionFactory(section["ConnectionStrings"]);
            _databaseName = section["Database"];
        }
        public List<T> QueryAll()
        {
            var collection = _connectionFactory
                .GetDataBase(_databaseName)
                    .GetCollection<T>(typeof(T).Name);

            var data = collection?.AsQueryable()?.ToList();

            return data;
        }

        public bool Insert(T obj)
        {
            var collection = _connectionFactory
                .GetDataBase(_databaseName)
                .GetCollection<T>(typeof(T).Name);

            collection.InsertOne(obj);

            return true;
        }
    }
}
