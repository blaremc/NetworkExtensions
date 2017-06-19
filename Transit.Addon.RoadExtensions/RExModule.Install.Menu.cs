using JetBrains.Annotations;
using System.Linq;
using Transit.Addon.RoadExtensions.Menus;
using Transit.Addon.RoadExtensions.Menus.Roads;
using Transit.Framework;
using Transit.Framework.Builders;
using Transit.Framework.ExtensionPoints.UI;
using UnityEngine;
#if DEBUG
using Debug = Transit.Framework.Debug;
#endif
namespace Transit.Addon.RoadExtensions
{
    public partial class RExModule
    {
        [UsedImplicitly]
        private class MenuInstaller : Installer<RExModule>
        {
            private static bool Done { get; set; } //Only one MenuAssets throughout the application

            protected override bool ValidatePrerequisites()
            {
                return true;
            }

            protected override void Install(RExModule host)
            {
                if (Done) //Only one MenuAssets throughout the application
                {
                    return;
                }
                if (RoadCategoryOrderManager.GetOrder(RExExtendedMenus.ROADS_TINY) == null) 
                    RoadCategoryOrderManager.RegisterCategory(RExExtendedMenus.ROADS_TINY, 5);
                if (RoadCategoryOrderManager.GetOrder(RExExtendedMenus.ROADS_SMALL_HV) == null)
                    RoadCategoryOrderManager.RegisterCategory(RExExtendedMenus.ROADS_SMALL_HV, 20);
                if (RoadCategoryOrderManager.GetOrder(RExExtendedMenus.ROADS_WIDE) == null)
                    RoadCategoryOrderManager.RegisterCategory(RExExtendedMenus.ROADS_WIDE, 40);
                if (RoadCategoryOrderManager.GetOrder(RExExtendedMenus.ROADS_WIDE_AVENUE) == null)
                    RoadCategoryOrderManager.RegisterCategory(RExExtendedMenus.ROADS_WIDE_AVENUE, 50);
                if (RoadCategoryOrderManager.GetOrder(RExExtendedMenus.ROADS_BUSWAYS) == null)
                    RoadCategoryOrderManager.RegisterCategory(RExExtendedMenus.ROADS_BUSWAYS, 65);
                if (RoadCategoryOrderManager.GetOrder(RExExtendedMenus.ROADS_PEDESTRIANS) == null)
                    RoadCategoryOrderManager.RegisterCategory(RExExtendedMenus.ROADS_PEDESTRIANS, 75);

                var categories = host.Parts
                    .OfType<IMenuItemBuilder>()
                    .WhereActivated()
                    .Select(mib => mib.UICategory)
                    .Where(cat => !string.IsNullOrEmpty(cat))
                    .Distinct()
                    .ToArray();
                
                foreach (var cat in categories)
                {
                    ExtendedMenuManager.RegisterNewCategory(cat, GeneratedGroupPanel.GroupFilter.Net, ItemClass.Service.Road);
                }

                /*
                Debug.Log("---------------------------------------");
                Resources.FindObjectsOfTypeAll<PropInfo>().All(p => {
                    Debug.Log(p.name);
                    return p.name == "";
                });
                Debug.Log("----------------END-----------------------");*/
                Done = true;
            }
        }
    }
}
