using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Eleve;

namespace IEZoom.Actions.IEZoom
{
    public class Initialize : IEZoomActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs evnt, object parameter)
        {
            ExecuteCommand("Refresh");

            return SuccessTask;
        }
    }
}
