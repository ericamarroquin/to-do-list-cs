using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public string Priority { get; set; }
    private static List<Item> _instances = new List<Item> {};

    public Item(string description)
    {
      Description = description;
      _instances.Add(this);
    }

    public Item(string description, string priority)
      : this(description)
      {
        Priority = priority;
      }

    public static List<Item> GetAll()
    {
      Dictionary<string, int> priorityLookup = new Dictionary<string, int>(3)
      {
        {"High", 1},
        {"Medium", 2},
        {"Low", 3}
      };

      List<Item> sortedList = _instances.OrderBy(item => priorityLookup[item.Priority]).ToList();
      return sortedList;
    }

        public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}