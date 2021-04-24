using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pastebin_backend.Models
{
    public class Pastebin
    {
        public long Id { get; set; }

        [Key]
        public string key { get; set; }
        public string code { get; set; }
        public long dateEnd { get; set; }
        public string type { get; set; }
    }
}
