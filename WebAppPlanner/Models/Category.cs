using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppPlanner.Models
{
    public class Category
    {
        
       public Category()
        {
            Tasks = new List<MyTask>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Категорія")]
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public virtual ICollection<MyTask> Tasks { get; set; }
    }
}
