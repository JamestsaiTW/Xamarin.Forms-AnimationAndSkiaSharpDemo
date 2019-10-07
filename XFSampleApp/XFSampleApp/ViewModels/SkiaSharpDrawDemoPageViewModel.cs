using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XFSampleApp.ViewModels
{
    public class SkiaSharpDrawDemoPageViewModel : SkiaSharpDemoPageViewModel
    {
        private bool _isClear;

        public bool IsClear
        {
            get { return _isClear; }
            set
            {
                if (_isClear != value)
                {
                    _isClear = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
