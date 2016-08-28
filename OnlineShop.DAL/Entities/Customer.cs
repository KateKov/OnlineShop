using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineShop.DAL.Entities
{
    public class Customer : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        [DisplayName("Имя"), Required(ErrorMessage = "Поле должно быть установлено"), MaxLength(30, ErrorMessage = "Имя не может состоять более чем из 30 символов")]
        public string FirstName { get; set; }
        [DisplayName("Фамилия"), Required(ErrorMessage = "Поле должно быть установлено"), MaxLength(30, ErrorMessage = "Фамилия не может состоять более чем из 30 символов")]
        public string LastName { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        [DisplayName("Уникальный ключ")]
        public Guid UniqueKey { get; set; }
        [DisplayName("Дата рождения"), Required(ErrorMessage = "Поле должно быть установлено"), DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Номер телефона")]
        [RegularExpression(@"((8|0|\+3)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}", ErrorMessage = "Некорректный номер")]
        public string Mobile { get; set; }
        [DisplayName("Дата регистрации"), Required(ErrorMessage = "Поле должно быть установлено"), DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
    }
}
