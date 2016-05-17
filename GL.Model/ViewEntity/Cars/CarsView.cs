using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GL.Model
{
    public class CarsView
    {
        [ScaffoldColumn(false)]
        public int CarsId { get; set; }

        //[Required]
        [DisplayName("Имя")]
        public string Name { get; set; }

        //[Required]
        [DisplayName("Марка")]
        public string Manufacturer { get; set; }

        //[Required]
        [DisplayName("Рег. номер")]
        public string RegNumber { get; set; }

        //[Required]
        [DisplayName("Кол-во мест")]
        public int RegNumberRegion { get; set; }

        //[Required]
        [DisplayName("Гаражный номер")]
        public string GarageNumber { get; set; }

        //[Required]
        [DisplayName("Тип ТС")]
        [UIHint("CarsTypeTemplate")]
        public CarsTypeView CarsType { get; set; }

        public int CarsTypeId { get; set; }
    }
}
