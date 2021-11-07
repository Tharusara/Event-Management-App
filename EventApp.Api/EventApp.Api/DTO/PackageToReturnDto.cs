using System;

namespace EventApp.Api.DTO
{
    public class PackageToReturnDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime Tocreation { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public decimal Price { get; set; }
        public decimal Extrahourcost { get; set; }
        public string PackageStatus { get; set; }
        public string Name { get; set; }
        public UserForListDto Creator { get; set; }
    }
}
