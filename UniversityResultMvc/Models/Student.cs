using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityResultMvc.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int RegisterNo { get; set; }
        public string Name { get; set; }
        public int Malayalam { get; set; }
        public int English { get; set; }
        public int Hindi { get; set; }
        public int Maths { get; set; }
        public int Science { get; set; }
        public int Total { get; set; }
        public string Status { get; set; }
    }
}