using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CRUD.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter the firstname!")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "Please enter the lastname!")]
        public String LastName { get; set; }
        [Required(ErrorMessage = "Please enter the middleinitial!")]
        public String MiddleInitial { get; set; }
        [Required, Range(16, 99)]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter the address")]
        public String Address { get; set; }
        [StringLength(12, ErrorMessage = "Enter your contact no. 09***..!")]
        public String ContactNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter the emailaddress!")]
        public String EmailAddress { get; set; }
        [Required(ErrorMessage = "Please enter the nick name!")]
        public String NickName { get; set; }
    }
}
