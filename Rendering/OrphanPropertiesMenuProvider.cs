using System.Collections.Generic;

using EPiServer.Shell.Navigation;

namespace <Site>.Web.Features.OrphanProperties.Rendering
{
    [MenuProvider]
    public class OrphanPropertiesMenuProvider : IMenuProvider
    {
        public IEnumerable<MenuItem> GetMenuItems()
        {
            var menuItems = new List<MenuItem>()
            {
                new UrlMenuItem("Orphan Properties", "/global/cms/OrphanPropertiesReport", "/Admin/OrphanPropertiesReport")
                {
                    IsAvailable = request => true,
                    SortIndex = SortIndex.Last + 15
                }
            };

            return menuItems;
        }
    }
}
