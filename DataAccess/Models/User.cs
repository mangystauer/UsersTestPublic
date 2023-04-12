using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class User : IUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 50 символов")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 50 символов")]
        public string LastName { get; set; }

        public string? MiddleName { get; set; }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 10 символов")]
        public string AdLogin { get; set; }
        public bool IsDeleted { get; set; }
    }
}
