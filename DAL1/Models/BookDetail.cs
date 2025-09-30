using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL1.Models
{
    public class BookDetail
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Name is required. It must be more than 2 characters and lesser than 50 characters")]
        public string? BookName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Genre is required. It must be more than 2 characters and lesser than 20 characters")]
        public string? Genre { get; set; }

        public bool Status {  get; set; }
    }
}
