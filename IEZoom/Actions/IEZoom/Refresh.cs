using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using Eleve;
using IEZoom.Models;
using SHDocVw;
using Shell32;

namespace IEZoom.Actions.IEZoom
{
    public class Refresh : IEZoomActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs e, object obj)
        {
            ViewModel.InternetExplorers.Clear();

            Shell shell = new Shell();
            dynamic windows = shell.Windows();

            Regex filter = null;
            if (!string.IsNullOrEmpty(ViewModel.Filter))
            {
                filter = new Regex(ViewModel.Filter);
            }
            
            

            foreach (object window in windows)
            {
                InternetExplorer ie = window as SHDocVw.InternetExplorer;
                if (ie == null)
                {
                    continue;
                }

                string url = ie.LocationURL;
                if (!url.StartsWith("http"))
                {
                    continue;
                }

                if (filter != null && !filter.IsMatch(url))
                {
                    continue;
                }

                ViewModel.InternetExplorers.Add(new Ie(ie));

            }

            return SuccessTask;
        }
    }
}