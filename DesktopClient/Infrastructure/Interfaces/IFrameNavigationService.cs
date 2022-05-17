using GalaSoft.MvvmLight.Views;

namespace DesktopClient.Infrastructure.Interfaces
{
    public interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }
    }
}
