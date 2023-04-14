using Framework.Logging;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowStripControls;

namespace Framework.Elements
{
    public class WFMenuBar
    {
        public string Name { get; private set; }
        private MenuBar _menuBar;

        public WFMenuBar(MenuBar menuBar, string name) 
        {
            Name = name;
            _menuBar = menuBar;
        }

        public void ChooseMenuBarItemByPath(params string[] menuItemPath) 
        {
            FrameworkLogger.Debug($"Choosing a menu item by path:[{string.Join("", menuItemPath)}] at menu:[{Name}]");
            if (menuItemPath.Length == 1) 
            {
                _menuBar.MenuItem(menuItemPath);
                return;
            }
            for (int i = 0; i < menuItemPath.Length - 1; i++) 
            {
                GetChildMenu(_menuBar.MenuItem(menuItemPath[i]), menuItemPath[i + 1]).Click();
            }
        }

        private Menu GetChildMenu(Menu menu, string elementName)
        {
            return menu.ChildMenus.First(m => m.Name.Contains(elementName));
        }
    }
}
