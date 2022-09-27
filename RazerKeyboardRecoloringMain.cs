using Corale.Colore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colore = Corale.Colore.Core.Color;
using Color = System.Drawing.Color;
using System.Drawing;
using System.Threading;
using System.Timers;
using Microsoft.SqlServer.Server;
using System.Windows.Forms;

namespace RazerKeyboardRecoloring
{
    internal static class Extentions
    {
        public static Color[] hackmansColors = new Color[] { "#066BFF".ToRgb(), "#5501D4".ToRgb(), "#5501D4".ToRgb(), "#FF00FF".ToRgb() };
        public static Color[] hackmansColors2 = new Color[] { "#FF41F8".ToRgb(), "#FF4660".ToRgb(), "#FF4660".ToRgb(), "#FF7623".ToRgb() };
        public static Color[] rainbowHUE = new Color[] { "#FF5880".ToRgb(), "#FFFC51".ToRgb(), "#63FF68".ToRgb(), "#62F1FF".ToRgb(),
        "#9F47FF".ToRgb(), "#FF5880".ToRgb() };

        public static Color[] GetAnimatedGradient(int length, Color[] colors, bool reverse = false, float speed = 1f, float width = 0.3f)
        {
            List<Color> toRet = new List<Color>();
            if (reverse)
            {
                colors = colors.Reverse().ToArray();
                for (int i = length - 1; i > -1; i--)
                {
                    var alphaByTime = remap((float)Math.Sin(speed * (DateTime.Now - Form1.startTime).TotalSeconds + (width * i)), -1, 1, 0, 1);
                    toRet.Add(lerpinfinity(colors, alphaByTime));
                }
            }
            else
                for (int i = 0; i < length; i++)
                {
                    var alphaByTime = remap((float)Math.Sin(speed * (DateTime.Now - Form1.startTime).TotalSeconds + (width * i)), -1, 1, 0, 1);
                    toRet.Add(lerpinfinity(colors, alphaByTime));
                }
            return toRet.ToArray();
        }

        private static Color lastColor = Color.White;
        private static Color lerpinfinity(Color[] colors, float alpha)
        {
            if (alpha == 0)
                return colors[0];
            else if (alpha == 1)
                return colors[colors.Length - 1];
            var length = colors.Length - 1;
            var source = remap(alpha, 0, 1, 0, length);
            var offsetMin = (int)Math.Floor(source);
            var offsetMax = (int)Math.Ceiling(source);
            Color col = Lerp(colors[offsetMin], colors[offsetMax], remap(alpha, (float)offsetMin / length, (float)offsetMax / length, 0, 1));
            if (!col.IsNaN())
                lastColor = col;
            else
                col = lastColor;
            return col;
        }

        public static bool IsNaN(this Color col) => float.IsNaN(col.R) || float.IsNaN(col.G) || float.IsNaN(col.B);

        public static Color Lerp(this Color s, Color t, float k)
        {
            var bk = (1 - k);
            var a = s.A * bk + t.A * k;
            var r = s.R * bk + t.R * k;
            var g = s.G * bk + t.G * k;
            var b = s.B * bk + t.B * k;
            return Color.FromArgb((int)a, (int)r, (int)g, (int)b);
        }

        internal static float remap(float value, float start1, float stop1, float start2, float stop2) => start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));

        internal static System.Drawing.Color ToRgb(this string hex) => System.Drawing.ColorTranslator.FromHtml(hex);
        internal static string ToHex(this System.Drawing.Color color) => System.Drawing.ColorTranslator.ToHtml(color);
        public static Corale.Colore.Core.Color ToColore(this System.Drawing.Color color) => new Corale.Colore.Core.Color(color.R, color.G, color.B);
        public static Corale.Colore.Core.Color ToColore(this string hex) => hex.ToRgb().ToColore();
        public static Corale.Colore.Core.Color[] ToColore(this System.Drawing.Color[] colors) => colors.Select(color => new Corale.Colore.Core.Color(color.R, color.G, color.B)).ToArray();
        public static Corale.Colore.Core.Color[] ToColore(this string[] hexs) => hexs.Select(hex => hex.ToRgb()).ToArray().Select(color => color.ToColore()).ToArray();
        public static System.Drawing.Color ToColor(this Corale.Colore.Core.Color colore) => System.Drawing.Color.FromArgb(colore.R, colore.G, colore.B);
        public static string[] ToHex(this Corale.Colore.Core.Color[] colores) => (colores == null ? (new Corale.Colore.Core.Color[] { Corale.Colore.Core.Color.Red, Corale.Colore.Core.Color.Blue }) : colores).Select(colore => colore.ToColor()).ToArray().Select(color => color.ToHex()).ToArray();
        public static Color[] ToColor(this Corale.Colore.Core.Color[] colores) => (colores == null ? (new Corale.Colore.Core.Color[] { Corale.Colore.Core.Color.Red, Corale.Colore.Core.Color.Blue }) : colores).Select(colore => colore.ToColor()).ToArray();
    }
    internal class RazerKeyboardRecoloringMain
    {
        static void Main(string[] args)
        {
            Application.Run(new Form1());
        }
    }
}
