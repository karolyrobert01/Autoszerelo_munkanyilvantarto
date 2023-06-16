using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Common.Validation;

namespace WebApi_Common.Models
{
    public class Work
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "A név kitöltése kötelező")]
        [NameValidation]
        public string Name { get; set; }



        [Required(ErrorMessage = "A típus kitöltése kötelező")]
        //[TypeValidation]
        public string Type { get; set; }


        [Required(ErrorMessage = "A Rendszám kitöltése kötelező!")]
        [IDValidation]
        public string ID { get; set; }

        [Required(ErrorMessage = "Az év kitöltése kötelező")]
        //[YearValidation]
        public string Year { get; set; }

        [Required(ErrorMessage = "A munka leírás kitöltése kötelező")]
        //[WorkDetailsValidation]
        public string Workdetails { get; set; }

        //[ErrorValidation]
        public string Error { get; set; }

        [Required(ErrorMessage = "A súlyosság kitöltése kötelező")]
        public string Seriousness { get; set; }

        //[SeriousnessValidation]
        public override string ToString()
        {
            return $"{Name} - {Type} - {ID}";
        }
    }
}
