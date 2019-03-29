using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Eleve;
using mshtml;
using SHDocVw;

namespace IEZoom.Actions.IEZoom
{
    public class Refresh : IEZoomActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs e, object obj)
        {
            ViewModel.InternetExplorers.Clear();

            Regex filter = null;
            if (!string.IsNullOrEmpty(ViewModel.Filter))
            {
                filter = new Regex(ViewModel.Filter);
            }
            
            foreach (object window in new ShellWindows())
            {
                InternetExplorer ie = window as InternetExplorer;
                if (ie == null)
                {
                    continue;
                }

                if (!(ie.Document is HTMLDocument doc))
                {
                    continue;
                }

                if (filter != null && !filter.IsMatch(ie.LocationURL))
                {
                    continue;
                }

                ViewModel.Add(ie);
            }

            return SuccessTask;
        }
    }
}