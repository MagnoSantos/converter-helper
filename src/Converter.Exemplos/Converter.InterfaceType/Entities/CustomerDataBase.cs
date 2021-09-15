using System;

namespace Converter.InterfaceType.Entities
{
    public class CustomerDataBase : BaseDataBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
    }

    public class BaseDataBase
    {
        public Guid Identifier { get; set; }
        public DateTime CreateAt { get; set; }
    }
}