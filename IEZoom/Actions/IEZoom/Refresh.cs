using System;
using System.Threading.Tasks;
using Eleve;

namespace IEZoom.Actions.IEZoom
{
    public class Refresh : IEZoomActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs e, object obj)
        {
            ViewModel.Refresh();

            return SuccessTask;
        }
    }
}