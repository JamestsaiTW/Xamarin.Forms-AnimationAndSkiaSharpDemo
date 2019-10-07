using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XFSampleApp.ViewModels
{
    public class SkiaSharpDemoPageViewModel : BasePageViewModel
    {
        private string _displayButtonText;

        public string DisplayButtonText
        {
            get { return _displayButtonText; }
            set
            {
                if (_displayButtonText != value)
                {
                    _displayButtonText = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
