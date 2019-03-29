﻿using System;
using System.Threading.Tasks;
using Eleve;
using IEZoom.Models;

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
