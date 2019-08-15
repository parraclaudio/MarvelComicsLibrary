using MarvelComicsLibrary.Domain.Entity.Base;

namespace MarvelComicsLibrary.Domain.Entity
{
    /// <summary>
    ///  Customer Entity
    /// </summary>
    public class Customer : BaseEntity
    {
        public string Email { get;  set; }
        public string Cpf { get;  set; }
        public string Name { get;  set; }
        public string Telephone { get;  set; }

        /*public Customer(string _email,string _cpf, string _name, string _telephone)
        {
            Email = _email;
            Cpf = _cpf;
            Name = _name;
            Telephone = _telephone;

            Validate(this, new CustomerValidation());
        }*/
    }
}
