using System;

namespace MarvelComicsLibrary.Domain.Interface
{
    /// <summary>
    ///  Base Entity Interface
    /// </summary>
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        Guid Key { get; set; }
    }
}
