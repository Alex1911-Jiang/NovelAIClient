using System;
using System.Collections;

namespace NovelAIClient.Models
{
    internal class input
    {
        public int fn_index { get; set; }
        public ArrayList data { get; set; }

        public input(int fnIndex, ArrayList data)
        {
            fn_index = fnIndex;
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            this.data = data;
        }
    }
}
