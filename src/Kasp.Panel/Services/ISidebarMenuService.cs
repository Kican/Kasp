using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Kasp.Panel.Services
{
    public interface ISidebarMenuService
    {
        IReadOnlyList<MenuItemData> GetItems { get; }
        void AddMenu(MenuItemData itemData);
        
    }

    public class SidebarMenuService : ISidebarMenuService
    {
        public List<MenuItemData> Items { get; set; } = new();

        public IReadOnlyList<MenuItemData> GetItems => Items.AsReadOnly();

        public void AddMenu(MenuItemData itemData)
        {
            Items.Add(itemData);
        }

        public EventCallback OnItemsChanged { get; } = new();
    }

    public record MenuItemData(string Title, string Link);
}