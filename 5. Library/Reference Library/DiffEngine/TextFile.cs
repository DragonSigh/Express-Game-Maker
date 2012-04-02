using System;
using System.IO;
using System.Collections;

namespace DifferenceEngine
{
    public class TextLine : IComparable
    {
        public string Line;
        public int _hash;

        public TextLine(string str)
        {
            Line = str.Replace("\t", "    ");
            _hash = str.GetHashCode();
        }
        #region IComparable Members

        public int CompareTo(object obj)
        {
            return _hash.CompareTo(((TextLine)obj)._hash);
        }

        #endregion
    }


    public class DiffList_TextFile : IDiffList
    {
        private const int MaxLineLength = 1024;
        private ArrayList _lines;

        public DiffList_TextFile() { }
        public DiffList_TextFile(string fileName)
        {
            _lines = new ArrayList();
            using (StreamReader sr = new StreamReader(fileName))
            {
                String line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length > MaxLineLength)
                    {
                        throw new InvalidOperationException(
                            string.Format("File contains a line greater than {0} characters.",
                            MaxLineLength.ToString()));
                    }
                    _lines.Add(new TextLine(line));
                }
            }
        }


        public static DiffList_TextFile FromText(string text)
        {
            DiffList_TextFile diff = new DiffList_TextFile();
            diff._lines = new ArrayList();
            // Read and display lines from the file until the end of 
            // the file is reached.
            string[] lines = text.Split('\n');
            foreach (string line in lines)
            {
                if (line.Length > MaxLineLength)
                {
                    throw new InvalidOperationException(
                        string.Format("File contains a line greater than {0} characters.",
                        MaxLineLength.ToString()));
                }
                diff._lines.Add(new TextLine(line));
            }
            return diff;
        }
        #region IDiffList Members

        public int Count()
        {
            return _lines.Count;
        }

        public IComparable GetByIndex(int index)
        {
            return (TextLine)_lines[index];
        }

        #endregion

    }
}