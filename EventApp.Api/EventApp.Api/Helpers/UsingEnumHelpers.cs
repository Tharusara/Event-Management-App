//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;
//using System.Text.Json.Serialization;

//namespace EventApp.Api.Models
//{
//    public class Gender
//    {
//        [Required]
//        public int Id { get; set; }

//        [JsonConverter(typeof(StringEnumConverter))]
//        public Genders Name { get; set; }

//        [JsonIgnore]
//        public virtual ICollection<Employee> Employees { get; set; }
//    }

//      public enum Genders
//      {
//          Male = 1,
//          Female = 2,
//      }
//      can globally haddle it in startup
//      services.AddControllers().AddNewtonsoftJson(options =>
//           {  // for jsonignore globally
//              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
//              // to show enums as names globally
//               options.SerializerSettings.Converters.Add(new StringEnumConverter());
//              });
//}
