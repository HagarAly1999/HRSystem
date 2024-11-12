using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp.Models

{
    [Table("Department",Schema="dbo")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Department ID")]
        public int DepartmentId{ get; set; }
        [Required]
        [Column(TypeName="varchar(50)")]
        [Display(Name ="Department Name")]
        public string Name{get; set; }

        [Column(TypeName="varchar(10)")]
        [Display(Name ="Department Abbreviation")]
        public string DepartmentAbbr { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
