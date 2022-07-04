using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserRegistration.Entities.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrígatório")]
        [StringLength(60, ErrorMessage = "O nome não pode conter mais do que 60 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [RegularExpression(".+\\@.+\\..+")]
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
