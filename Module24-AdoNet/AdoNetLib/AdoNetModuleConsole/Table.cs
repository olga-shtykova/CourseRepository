using System.Collections.Generic;

namespace AdoNetModuleConsole
{
    public class Table
    {
        public Table()
        {
            Fields = new List<string>();
        }

        public string Name { get; set; }

        public List<string> Fields { get; set; }

        public string ImportantField { get; set; }

        public byte[] CardNumber { get; set; }

    }
}
