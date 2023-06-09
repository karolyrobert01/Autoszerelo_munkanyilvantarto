﻿using System.ComponentModel.DataAnnotations;
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
        [TypeValidation]
        public string Type { get; set; }


        [Required(ErrorMessage = "A Rendszám kitöltése kötelező!")]
        [IDValidation]
        public string RSZ { get; set; }

        [Required(ErrorMessage = "Az év kitöltése kötelező")]
        [YearValidation]
        public string Year { get; set; }

        [Required(ErrorMessage = "A munka leírás kitöltése kötelező")]
        [WorkDetailsValidation]
        public string Workdetails { get; set; }

		[Required(ErrorMessage = "A hiba leírás kitöltése kötelező")]
		[ErrorValidation]
        public string Error { get; set; }


        [Required(ErrorMessage = "A súlyosság kitöltése kötelező")]
		[SeriousnessValidation]
		public string Seriousness { get; set; }

        
        public override string ToString()
        {
            return $"{Name} - {Type} - {RSZ}";
        }
    }
}
