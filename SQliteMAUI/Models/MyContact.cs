using System;
using SQLite;

namespace SQliteMAUI.Models
{
    //se redefine el nombre de la tabla
    //en SQLite como "Contact" en lugar de "MyContact"
    //por defecto SQLite utiliza el nombre de la clase
    //para nombrar sus nombres de tablas.
    [Table("Contact")]
    public class MyContact
    {
        //la llave primaria
        //se define como long
        //y por ser numerico se
        //puede utilizar el auto incrementable
        [AutoIncrement]
        [PrimaryKey]
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        //limita el numero telefonico a ser
        //10 digitos
        [MaxLength(10)]
        public string? PhoneNumber { get; set; }
        //el correo debe ser unico
        //si se trata de agregar otro correo
        //igual lanzara una excepcion
        [Unique]
        public string? Email { get; set; }
        //esta propiedad no necesita ser guardada
        //por lo que se ignora de SQLite
        [Ignore]
        public string Fullname => $"{Id} - {FirstName} {LastName}";
    }
}

