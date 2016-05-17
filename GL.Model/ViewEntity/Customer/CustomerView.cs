using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GL.Model
{
    public class CustomerView
    {
        [ScaffoldColumn(false)]
        public int CustomerId { get; set; }

        [Required]
        [DisplayName("Название")]
        public string ShortName { get; set; }

        [Required]
        [DisplayName("Полное имя")]
        public string FullName { get; set; }

        [Required]
        [DisplayName("Город")]
        public string City { get; set; }

        [Required]
        [DisplayName("Адрес")]
        public string Address { get; set; }

        [Required]
        [DisplayName("Индекс")]
        public string Zip { get; set; }

        [Required]
        [DisplayName("Телефон")]
        public string Phone { get; set; }

        [Required]
        [DisplayName("ИНН")]
        public string Inn { get; set; }
    }
}
