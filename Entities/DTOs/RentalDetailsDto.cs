using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailsDto: IDTOs
    {
        public string CustomerName { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string BrandName { get; set; }
        public int  CarId { get; set; }
    }
}
