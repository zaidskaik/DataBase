using DataBase.Models;
using DataBase.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataBase.database
{
    public class Connect : DbContext
    {
        //هذا السطر هو المشد ووظيفته تمرير الاعدادات من ملف التشغيل الى قاعدة البيانات
        // base option تمرر الاضافات الخاصة بهذا الكلاس الى الكلاس الاب دون احداث تغيير فيه
        // option هو اسم المتغير الذي يحمل هذه الإعدادات.
        public Connect(DbContextOptions<Connect> option) : base (option) 
        {
        }
         // table to class Equipment1 هذا السطر بجهز 
        public DbSet<Equipment1> EquipmentTable { get; set; }

       
        
    }
}
