using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_LABS.Entities
{
    public class Currency
    {
        [Key]
        public int Cur_ID { get; set; }
        public string Cur_Abbreviation { get; set; }
        public string Cur_Name { get; set; }

        public Currency(int cur_ID, string cur_Abbreviation, string cur_Name)
        {
            Cur_ID = cur_ID;
            Cur_Abbreviation = cur_Abbreviation;
            Cur_Name = cur_Name;
        }
    }


}
