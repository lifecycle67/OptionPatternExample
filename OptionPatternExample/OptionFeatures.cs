using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPatternExample
{
    public class OptionFeatures
    {
        public const string Base = nameof(Base);
        public const string Derive = nameof(Derive);

        public bool Enabled { get; set; }
        public string Url { get; set; }
    }
}
