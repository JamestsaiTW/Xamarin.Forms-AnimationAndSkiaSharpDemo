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
    public partial class SkiaSharpAnimationDemoPage : ContentPage
    {
        private readonly SkiaSharpDemoPageViewModel pageVM;
        public SkiaSharpAnimationDemoPage()
        {
            InitializeComponent();
            pageVM = BindingContext as SkiaSharpDemoPageViewModel;
        }

        float scale;
        readonly System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        bool isRun = false;

        private async void Button_Clicked(object sender, EventArgs e)
        {
            pageVM.DisplayButtonText = isRun ? "Start" : "Stop";

            isRun = !isRun;

            await AnimationLoop();
        }

        private void DrawSKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SkiaSharpHelper.Draw(DrawType.CircleAnimation, false, e , scale);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            isRun = false;
            pageVM.DisplayButtonText = "Start";
        }

        async Task AnimationLoop()
        {
            stopwatch.Start();

            while (isRun)
            {
                double cycleTime = MySlider.Value;
                double t = stopwatch.Elapsed.TotalSeconds % cycleTime / cycleTime;
                scale = (1 + (float)Math.Sin(2 * Math.PI * t)) / 2;
                DrawSKCanvasView.InvalidateSurface();
                await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
            }

            stopwatch.Stop();
        }
    }
}