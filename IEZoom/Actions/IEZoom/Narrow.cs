using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Eleve;

namespace IEZoom.Actions.IEZoom
{
    public class Narrow : IEZoomActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            KeyEventArgs evnt = args as KeyEventArgs;
            if (evnt.Key == Key.Enter)
            {
                Keyboard.ClearFocus();
            }

            ExecuteCommand<Refresh>();

            return SuccessTask;
        }
    }
}
