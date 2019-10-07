using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSampleApp.ViewModels;

namespace XFSampleApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XFAnimationDemoPage : ContentPage
    {
        readonly XFAnimationDemoPageViewModel xfAdpVM ;
        public XFAnimationDemoPage()
        {
            InitializeComponent();
            xfAdpVM = BindingContext as XFAnimationDemoPageViewModel;
        }

        private void StartAnimationButton_Clicked(object sender, EventArgs e)
        {
            xfAdpVM.IsAnimating = true;
            var myAnimation = new Animation {
                                                { 0, 0.5, new Animation (v => xFAnimationImage.Scale = v, 1, 2) },
                                                { 0, 1, new Animation (v => xFAnimationImage.Rotation = v, 0, 360) },
                                                { 0.5, 1, new Animation (v => xFAnimationImage.Scale = v, 2, 1) }
                                            };
            myAnimation.Commit(this, "MyAnimation", 16, 4000, null,
                            (v, c) =>
                            {
                                xfAdpVM.IsAnimating = false;
                            });
        }

        private void StartConcurrentAnimationButton_Clicked(object sender, EventArgs e)
        {
            xfAdpVM.IsAnimating = true;

            var myFirstAnimation = new Animation(v => xFAnimationImage.Scale = v, 1, 2);
            var mySecondAnimation = new Animation(v => xFAnimationImage.Rotation = v, 0, 360);
            var myThirdAnimation = new Animation(v => xFAnimationImage.Scale = v, 2, 1);

            new Animation()
                           .WithConcurrent(myFirstAnimation, 0, 0.35)
                           .WithConcurrent(mySecondAnimation, 0.35, 0.7)
                           .WithConcurrent(myThirdAnimation, 0.7, 1)
                           .Commit(this, "MyAnimation", 16, 4000, null,
                                (v, c) =>
                                {
                                    xfAdpVM.IsAnimating = false;
                                });
        }

        private void CancelAnimationButton_Clicked(object sender, EventArgs e)
        {
            this.AbortAnimation("MyAnimation");
        }
    }
}