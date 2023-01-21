using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeviyeBelirlemeIcinETicaret.Models.siniflar
{
    public class WebResult
    {
        public Enums.WebResult Type { get; set; } = Enums.WebResult.NotSet;
        public string Url { get; set; }
        public bool ErrorOccured { get; set; } = false;
        public string ErrorMessage { get; set; } = string.Empty;
        public object Value { get; set; }
    }
}