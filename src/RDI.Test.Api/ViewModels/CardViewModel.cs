using System;
using System.ComponentModel.DataAnnotations;

namespace RDI.Test.Api.ViewModels
{
    public class CardViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }
    }
}
