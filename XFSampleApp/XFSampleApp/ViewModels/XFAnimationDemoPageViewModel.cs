using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XFSampleApp.ViewModels
{
    public class XFAnimationDemoPageViewModel : BasePageViewModel
    {
        private bool _isAnimating;

        public bool IsAnimating
        {
            get { return _isAnimating; }
            set {
                if (_isAnimating != value)
                {
                    _isAnimating = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
