using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GL.Model
{
    public class DriversView
    {
        [ScaffoldColumn(false)]
        public int DriversId { get; set; }

        [Required]
        [DisplayName("Фамилия")]
        public string Surname { get; set; }
        
        [Required]
        [DisplayName("Имя")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        [Required]
        [DisplayName("Номер ВУ")]
        public string PravaNum { get; set; }

        [Required]
        [DisplayName("Табельный номер")]
        public string TabNumber { get; set; }

        [DisplayName("Список ТС")]
        [UIHint("CarsEditor")]
        public IEnumerable<CarsView> Cars { get; set; }

        public DateTime? PraveDataPo { get; set; }

        public DateTime? DateBirth { get; set; }

        public string PassportSer { get; set; }

        public string PassportNum { get; set; }

        public string PassportInfo { get; set; }

    }
}
