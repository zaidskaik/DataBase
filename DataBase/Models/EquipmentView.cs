using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
    public class EquipmentView
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public double price { get; set; }

        // الان بدي اضيف هذا المودلز للداتا بيس حتى يعمله كجدول عن طريق ال console
    }
}
