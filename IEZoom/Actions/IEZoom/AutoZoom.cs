using System;
using System.Threading.Tasks;
using Eleve;
using IEZoom.Models;

namespace IEZoom.Actions.IEZoom
{
    public class AutoZoom : IEZoomActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs e, object obj)
        {
            ViewModel.Refresh();
            foreach(Ie ie in ViewModel.InternetExplorers)
            {
                ie.Zoom(ViewModel.Percent);
            }

            return SuccessTask;
        }
    }
}
