using MahApps.Metro.Controls;

namespace DesktopClient.Views
{
    public partial class EngineerMenuView 
    {
        public EngineerMenuView()
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
