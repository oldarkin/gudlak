using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GL.Model
{
    public class StaffView
    {
        [ScaffoldColumn(false)]
        public int StaffId { get; set; }

        [DisplayName("Фамилия")]
        [Required]
        public string Surname { get; set; }

        [DisplayName("Имя")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Отчество")]
        [Required]
        public string Patronymic { get; set; }

        [UIHint("StaffTypeTemplate")]
        [DisplayName("Должность")]
        [Required]
        public StaffTypeView StaffType { get; set; }

        public int? StaffTypeId { get; set; }
    }
}
