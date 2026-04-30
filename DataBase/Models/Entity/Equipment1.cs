using System.ComponentModel.DataAnnotations;

namespace DataBase.Models.Entity
{
    public class Equipment1
    {
        [Key]//its mean the id is primary key & the system entered it
        public int Id { get; set; }
        public string Name { get; set; }
        public double price { get; set; }

        //this is the class connecting with DB
    }
}
