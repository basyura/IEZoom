using System;
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

                /*
                ie.Document.body.runtimeStyle.Zoom = "50%";
                */
                ViewModel.InternetExplorers.Add(new Ie(ie));


            }

            return SuccessTask;
        }
    }
}