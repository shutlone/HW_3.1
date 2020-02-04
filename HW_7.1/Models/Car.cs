using System;
using System.ComponentModel.DataAnnotations;


namespace Web_7.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название авто")]
        public string Name { get; set; }

        [Range(1, 1500, ErrorMessage = "Мощность должен быть в промежутке от 1 до 1500")]
        [Required(ErrorMessage = "Укажите мощность авто")]
        public int Power { get; set; }
        
    }
}
