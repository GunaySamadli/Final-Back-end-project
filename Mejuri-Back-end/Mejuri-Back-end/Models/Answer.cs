using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public Question Question { get; set; }

    }
}
