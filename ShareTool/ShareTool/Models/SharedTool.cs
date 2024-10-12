using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareTool.Models
{
    public class SharedTool
    {
        public SharedTool()
        {
        }

        public SharedTool(string name, string description, int quantity)
        {
            Name = name;
            Description = description;
            Quantity = quantity;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }
    }
}