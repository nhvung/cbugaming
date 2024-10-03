using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game11
{
    class CountInfo
    {
        public int LineIndex { get; set; }
        public string Word { get; set; }
        public int WordCount { get; set; }
        public CountInfo() { }
        public CountInfo(int lineIdx, string word, int wordCount)
        {
            LineIndex = lineIdx;
            Word = word;
            WordCount = wordCount;
        }
        public override string ToString()
        {
            return $"{LineIndex}: {Word} - {WordCount}";
        }
    }
}
