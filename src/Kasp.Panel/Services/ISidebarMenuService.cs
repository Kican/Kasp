using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Kasp.Panel.Services
{
    public interface ISidebarMenuService
    {
        IReadOnlyList<MenuItemData> GetItems { get; }
        event Action OnChange;

        void AddMenu(MenuItemData itemData);
    }

    public class SidebarMenuService : ISidebarMenuService
    {
        public List<MenuItemData> Items { get; set; } = new();

        public IReadOnlyList<MenuItemData> GetItems => Items.AsReadOnly();
        public event Action OnChange;

        public void AddMenu(MenuItemData itemData)
        {
            Items.Add(itemData);
            OnChange?.Invoke();
        }
    }

    public record MenuItemData(string Title, string Link);
}