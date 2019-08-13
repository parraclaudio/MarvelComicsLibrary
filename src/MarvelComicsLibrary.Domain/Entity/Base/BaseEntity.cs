using MarvelComicsLibrary.Domain.Interface;
using System;

namespace MarvelComicsLibrary.Domain.Entity.Base
{
    /// <summary>
    ///  Base Entity
    /// </summary>
    public abstract class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            Key = Guid.NewGuid();
        }

        //Collection Database ID
        public Guid Id { get; set; }

        //Application ID
        public Guid Key { get; set; }
    }
}
