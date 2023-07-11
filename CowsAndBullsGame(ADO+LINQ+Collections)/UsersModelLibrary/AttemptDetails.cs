

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersModelLibrary
{
    public  class AttemptDetails
    {
        
        public int Id{ get; set; }
        [ForeignKey("Id")]
        public int  NumberOfAttempts{ get; set; }
        public string Word { get; set; }
        public string Status { get; set; }  
    }
}
