using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSampleApp.Utilities;
using XFSampleApp.ViewModels;

namespace XFSampleApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkiaSharpDrawDemoPage : ContentPage
    {
        private readonly DrawType drawType;
        private readonly SkiaSharpDrawDemoPageViewModel pageVM;
        private SkiaSharpDrawDemoPage()
        {
            InitializeComponent();     
        }

        public SkiaSharpDrawDemoPage(DrawType type) : this()
        {
            drawType = type;
            pageVM = BindingContext as SkiaSharpDrawDemoPageViewModel;

            pageVM.IsClear = true;
            pageVM.DisplayButtonText = $"Draw {drawType.ToString()}";
        }

        private void DrawSKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SkiaSharpHelper.Draw(drawType, pageVM.IsClear, e);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            pageVM.IsClear = !pageVM.IsClear;
            pageVM.DisplayButtonText = pageVM.IsClear ? $"Draw {drawType.ToString()}" : "Clear";

            DrawSKCanvasView.InvalidateSurface();
        }

    }
}