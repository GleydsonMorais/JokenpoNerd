using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace JokenpoNerd.API.Utils
{
    public class FormatString
    {
        public static string OpcaoToTitleCase(string opcao) => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(opcao);
    }
}
