using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using Eleve;

namespace IEZoom.Actions.IEZoom
{
    public class Closing : IEZoomActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs e, object obj)
        {
            CancelEventArgs evnt = e as CancelEventArgs;
            evnt.Cancel = true;

            ViewModel.View.Visibility = Visibility.Collapsed;


            return SuccessTask;
        }
    }
}
