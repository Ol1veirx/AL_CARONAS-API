using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_CARONAS.Core.Entities
{
    public class Review
    {
        public int ReviewId { get; private set; }
        public int UserId { get; private set; }
        public int TargerUserId { get; private set; }
        public int Rating { get; private set; }
        public string? Comment { get; private set; }
        public DateTime Date {  get; private set; }
    }
}
