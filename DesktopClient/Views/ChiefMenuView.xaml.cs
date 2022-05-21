using MahApps.Metro.Controls;

namespace DesktopClient.Views
{
    public partial class ChiefMenuView
    {
        public ChiefMenuView()
        {
            InitializeComponent();
        }

        private void HamburgerMenu_OnItemClick(object sender, ItemClickEventArgs e)
        {
            HamburgerMenuControl.Content = e.ClickedItem;
            HamburgerMenuControl.IsPaneOpen = false;
        }

        private void HamburgerMenu_OnOptionsItemClick(object sender, ItemClickEventArgs e)
        {
            HamburgerMenuControl.Content = e.ClickedItem;
            HamburgerMenuControl.IsPaneOpen = false;
        }
    }
}
