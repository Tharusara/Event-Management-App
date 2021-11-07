using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace EventApp.Api.DTO
{
    public class HallToReturnDto
    {
        public HallToReturnDto()
        {
            ImageUrls = new List<string>();
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime Tocreation { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string HallStatus { get; set; }
        public string HallType { get; set; }
        public decimal Hourfee { get; set; }
        public decimal Squarefeet { get; set; }
        public UserForListDto Creator { get; set; }
        public ICollection<PhotosDto> Photos { get; set; }
        public IList<string> ImageUrls { get; set; }
    }
}
