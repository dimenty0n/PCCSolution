using System.Collections.Generic;

namespace ProcessLib
{
    public class PFContainer
    {
        public TypePF Type { get; set; }
        public string Name { get; set; }
        public List<string> Parameters { get; set; }
        public string Text { get; set; }
        public int Index { get; set; }
    }
    public enum TypePF
    {
        Function,
        Procedure

    }
}

