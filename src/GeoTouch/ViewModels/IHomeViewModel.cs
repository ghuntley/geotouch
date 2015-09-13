using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Splat;

using Xamarin.Forms;

namespace GeoTouch.ViewModels
{
    public interface IHomeViewModel
    {
        string Title
        {
            get; set;
        }

        Task<ShapeViewModel> GenerateRandomShapeAsync();

        ICommand PlaceShape();
    }
}