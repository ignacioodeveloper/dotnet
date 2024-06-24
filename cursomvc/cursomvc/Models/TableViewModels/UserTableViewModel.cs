using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// en MODELS 
// creamos una carpeta TableViewModels
// donde aca dejaremos las clases
// que nesecitemos con sus campos
// para asi usar solo las cosas que necesitemos
// y no traer 10 campos si solo queremos 3

namespace cursomvc.Models.TableViewModels
{
    public class UserTableViewModel
    {
        public int Id { get; set; } 
        public string Email { get; set; }
        public int? Edad { get; set; }   
    }
}