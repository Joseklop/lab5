using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using ReactiveUI;

namespace lab5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string path = "";
        string output = "";
        string regex_prev = "";
        string regex_new = "";

        public string Input
        {
            get { return path; }
            set { this.RaiseAndSetIfChanged(ref path, value); FindMatches(); }
        }

        public string Output
        {
            get { return output; }
            set { this.RaiseAndSetIfChanged(ref output, value); }
        }

        string path_in = "";
        public string SetPath
        {
            get { return path_in; }

            set { path_in = value; Input = File.ReadAllText(path_in); }
        }

        string path_out = "";
        public string GetPath
        {
            get { return path_out; }
            set { path_out = value; File.AppendAllText(path_out, output);}
        }


        public string Regex_Prev
        {
            get { return regex_prev; }

            set { regex_prev = value;}
        }

        public string Regex_New
        {
            get { return regex_prev; }

            set { regex_new = value; FindMatches(); }
        }
        public void FindMatches()
        {
            Output = "";
            foreach (Match match in Regex.Matches(path, regex_new))
            {
                Output += match + "\n";
            }
        }
    }
}
