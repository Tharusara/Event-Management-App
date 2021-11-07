using System;
using System.Collections.Generic;

namespace EventApp.Api.DTO
{
    public class ItemToReturnDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime ToCreation { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public byte[] Photo { get; set; }
        public UserForListDto Creator { get; set; }
        public string ItemStatus { get; set; }
        public ICollection<PhotosDto> Photos { get; set; }
    }
}
