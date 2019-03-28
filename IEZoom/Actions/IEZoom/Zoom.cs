using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;
using IEZoom.Models;
using SHDocVw;

namespace IEZoom.Actions.IEZoom
{
    public class Zoom : IEZoomActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs e, object obj)
        {

            Ie ie = ViewModel.SelectedItem;

            ie.Zoom(ViewModel.Percent);


            return SuccessTask;
        }
    }
}
