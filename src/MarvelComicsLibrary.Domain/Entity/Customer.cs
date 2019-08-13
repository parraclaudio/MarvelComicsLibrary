using MarvelComicsLibrary.Domain.Entity.Base;

namespace MarvelComicsLibrary.Domain.Entity
{
    /// <summary>
    ///  Customer Entity
    /// </summary>
    public class Customer : BaseEntity
    {
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
    }
}
