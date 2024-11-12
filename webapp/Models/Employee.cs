using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp.Models
{
    [Table("Employee",Schema ="dbo")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }
        [Required]
        [Column(TypeName="varchar(50)")]
        [MaxLength(50)]
        [Display(Name = "Employee Number")]
        public string EmployeeNumber {  get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        [MaxLength(20)]
        [Display(Name = "Employee Name")]
        public string EmployeeName{ get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Hiring Date")]
        //[DisplayFormat(DataFormatString ="{0:dd-mm-yyyy}")]
        public DateTime HiringDate { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name ="Gross Salary")]
        public string GrossSalary { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Net Salary")]
        public string NetSalary { get; set; }
        [ForeignKey("Department")]
        [Required(ErrorMessage = "The Department field is required.")]
        public int DepartmentId { get; set; }
   
        [Display(Name = "Department")]
        [NotMapped]
        public string DapartmentName { get; set; }
        public virtual Department Department { get; set; }

    }
}
