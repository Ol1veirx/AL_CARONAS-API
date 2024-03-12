using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_CARONAS.Core.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int TargerUserId { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime Date {  get; set; } = DateTime.Now;
    }
}
