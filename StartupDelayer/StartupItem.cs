using System;
using System.Diagnostics;

namespace startup_delayer
{
    public class StartupItem : IComparable
    {
        public int Index { get; private set; }
        public string Item { get; private set; }
        public int Offset { get; private set; }
        public string WorkingDirectory { get; private set; }
        public string Arguments { get; private set; }
        public ProcessWindowStyle WindowState { get; private set; }


        public StartupItem(
            int index, 
            string item, 
            int offset, 
            string workingDirectory = "", 
            string arguments = "", 
            ProcessWindowStyle windowState = ProcessWindowStyle.Normal)
        {
            Index = index;
            Item = item;
            Offset = offset;
            WorkingDirectory = workingDirectory;
            Arguments = arguments;
            WindowState = windowState;
        }


        public int CompareTo(object obj)
        {
            StartupItem other = obj as StartupItem;

            return Offset.CompareTo(other.Offset);
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1}, {2}", Item, Offset, WindowState.ToString());
        }
    }
}
