using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace TwinTechs.Ios.Extensions
{
    public static class ViewExtensions
    {
        private static GetRendererDelegate _getRendererDelegate;

        private delegate IVisualElementRenderer GetRendererDelegate(BindableObject bindable);

        public static IVisualElementRenderer GetRenderer(this BindableObject bindable)
        {
            if (bindable == null) {
                return null;
            }

            if (_getRendererDelegate == null) {
                var assembly = typeof(EntryRenderer).Assembly;
                var platformType = assembly.GetType ("Xamarin.Forms.Platform.iOS.Platform");
                var method = platformType.GetMethod ("GetRenderer");
                _getRendererDelegate = (GetRendererDelegate)method.CreateDelegate (typeof(GetRendererDelegate));
            }

            var value = _getRendererDelegate (bindable);

            return value;
        }

        /***
         * Thanks to Adam Kemp for generously making this code available.
         * If you are reading this, please petition Xamarin to give us public access to the GetRenderer method:
         * https://bugzilla.xamarin.com/show_bug.cgi?id=30467
         */
    }
}