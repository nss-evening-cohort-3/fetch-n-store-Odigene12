using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FetchNStore.Models
{
    public class Response
    {
        [Key] //table's primary key
        public int Id { get; set; }

        [Required] //This will not allow null entries
        public int StatusCode { get; set; }

        public string URL { get; set;}

        public int ResponseTime { get; set; }

        [Required]
        public string HTTPMethod { get; set; }
    }
}