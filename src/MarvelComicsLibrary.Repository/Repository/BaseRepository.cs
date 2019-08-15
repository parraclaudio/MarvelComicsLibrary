using MarvelComicsLibrary.Domain.Entity.Base;
using MarvelComicsLibrary.Repository.Context;
using MarvelComicsLibrary.Repository.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MarvelComicsLibrary.Repository.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly string _databaseName;
        private readonly IMongoCollection<T> _collection;

        public BaseRepository(IConfiguration configuration)
        {
            IConfigurationSection section = configuration.GetSection("MongoDB");

            _connectionFactory = new ConnectionFactory(section["ConnectionStrings"]);
            _databaseName = section["Database"];

            _collection = _connectionFactory.GetDataBase(_databaseName).GetCollection<T>(typeof(T).Name);
        }

        public List<T> GetAll()
        {
            return _collection.Find(Builders<T>.Filter.Empty).ToList();
        }

        public T GetByKey(Guid Key)
        {
            try { 
                return _collection.Find(Builders<T>.Filter.Eq("Key", Key)).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public void Insert(T obj)
        {
            try
            {
                _collection.InsertOne(obj);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(T obj)
        {
            _collection.ReplaceOne(Builders<T>.Filter.Eq("_id", obj.Id), obj);   
        }

    }
}
