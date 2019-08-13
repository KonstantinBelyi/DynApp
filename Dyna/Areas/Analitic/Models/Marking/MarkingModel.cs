using System;
using System.Data;
using Dyna.Models;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dyna.Areas.Analitic.Models.Marking
{
    public class MarkingModel
    {
        public string Count { get; set; }
        public string Reestr { get; set; }
        public string Draft { get; set; }
    }
}