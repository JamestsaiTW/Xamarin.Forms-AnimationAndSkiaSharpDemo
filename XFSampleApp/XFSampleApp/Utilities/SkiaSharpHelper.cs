using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFSampleApp.Utilities
{
    public enum DrawType
    {
        Line,
        Circle,
        MeasureText,
        CircleAnimation
    }


    public   class SkiaSharpHelper
    {
     
        internal static void Draw(DrawType type, bool isClear, SKPaintSurfaceEventArgs e, float scale = 0.0f)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            if (isClear)
            {
                return;
            }

            switch (type)
            {
                case DrawType.Line:
                    Line(info, canvas);
                    break;
                case DrawType.Circle:
                    Circle(info, canvas);
                    break;
                case DrawType.MeasureText:
                    MeasureText(info, canvas);
                    break;
                case DrawType.CircleAnimation:
                    CircleAnimation(info, canvas, scale);
                    break;
                default:
                    break;
            }
        }

        private static void Line(SKImageInfo info, SKCanvas canvas)
        {
            using (SKPaint thickLinePaint = new SKPaint() { Style = SKPaintStyle.Stroke, Color = SKColors.Orange, StrokeWidth = 25 })
            {
                float x1 = 100;
                float x2 = info.Width - x1;
                float y1 = 100, y2 = info.Height - y1;
                canvas.DrawLine(x1, y1, x2, y2, thickLinePaint);
            }
        }



        private static void Circle(SKImageInfo info, SKCanvas canvas)
        {

            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Stroke;
                paint.Color = Color.Red.ToSKColor();
                paint.StrokeWidth = 25;

                canvas.DrawCircle(info.Width / 2, info.Height / 2, 300, paint);

                paint.Style = SKPaintStyle.Fill;
                paint.Color = SKColors.Blue;
                canvas.DrawCircle(info.Width / 2, info.Height / 2, 300, paint);
            }
        }
        private static void MeasureText(SKImageInfo info, SKCanvas canvas)
        {

            string str = "SkiaSharp Demo";

            SKRect textBounds = new SKRect();
            float xText;
            float yText;

            using (SKPaint textPaint = new SKPaint() { Color = SKColors.Chocolate })
            {

                float textWidth = textPaint.MeasureText(str);
                textPaint.TextSize = 0.9f * info.Width * textPaint.TextSize / textWidth;

                // Find the text bounds
                textPaint.MeasureText(str, ref textBounds);

                // Calculate offsets to center the text on the screen
                xText = info.Width / 2 - textBounds.MidX;
                yText = info.Height / 2 - textBounds.MidY;

                // And draw the text
                canvas.DrawText(str, xText, yText, textPaint);
            }


            using (SKPaint framePaint = new SKPaint() { Color = SKColors.Blue, StrokeWidth = 5, Style = SKPaintStyle.Stroke })
            {
                SKRect frameRect = textBounds;
                frameRect.Offset(xText, yText);
                frameRect.Inflate(10, 10);

                canvas.DrawRoundRect(frameRect, 20, 20, framePaint);

                // Inflate the frameRect and draw another
                frameRect.Inflate(10, 10);
                framePaint.Color = SKColors.DarkBlue;

                canvas.DrawRoundRect(frameRect, 30, 30, framePaint);
            }

        }

        private static void CircleAnimation(SKImageInfo info, SKCanvas canvas, float scale)
        {
            float maxRadius = 0.75f * Math.Min(info.Width, info.Height) / 2;
            float minRadius = 0.25f * maxRadius;


            float xRadius = minRadius * scale + maxRadius * (1 - scale);
            float yRadius = maxRadius * scale + minRadius * (1 - scale);

            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Stroke;
                paint.Color = SKColors.Blue;
                paint.StrokeWidth = 50;
                canvas.DrawOval(info.Width / 2, info.Height / 2, xRadius, yRadius, paint);

                paint.Style = SKPaintStyle.Fill;
                paint.Color = SKColors.SkyBlue;
                canvas.DrawOval(info.Width / 2, info.Height / 2, xRadius, yRadius, paint);
            }
        }


    }

}
