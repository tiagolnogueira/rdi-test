using System;
using System.ComponentModel.DataAnnotations;

namespace RDI.Test.Api.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public CardViewModel Card { get; set; }
    }
}
