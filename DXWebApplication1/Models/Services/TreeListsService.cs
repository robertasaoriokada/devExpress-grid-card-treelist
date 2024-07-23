using DXWebApplication1.Models.DbAp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DXWebApplication1.Models
{
    public class TreeListsService
    {
        private readonly Model1 db = new Model1();

        public List<service> ItemizacaoDosItens()
        {
            var model = db.services.ToList();
            
            var rootItems = model.Where(item => item.ParentKey == null).ToList();
           
            ProcessItems(rootItems, string.Empty, model);
            db.SaveChanges();
            return model;
        }

        private void ProcessItems(List<service> items, string prefix, List<service> allItems)
        {
            for (int i = 0; i < items.Count; i++)
            {
             
                var currentPrefix = string.IsNullOrEmpty(prefix) ? (i + 1).ToString() : $"{prefix}.{i + 1}";
          
                items[i].NumberItem = currentPrefix;

                var childNodes = allItems.Where(n => n.ParentKey == items[i].IdService).ToList();

                if (childNodes.Count > 0)
                {
                    ProcessItems(childNodes, currentPrefix, allItems);
                }
                
            }
        }
    }
}
