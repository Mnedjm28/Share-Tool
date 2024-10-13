using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShareTool.Models
{
    public class SharedTool
    {
        public SharedTool()
        {
        }

        public SharedTool(string name, string description, int quantity, string imagePath)
        {
            Name = name;
            Description = description;
            Quantity = quantity;
            ImagePath = imagePath;
        }

        [Required(ErrorMessageResourceType = typeof(Resources.ShareToolResource), ErrorMessageResourceName = "FieldRequired")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ShareToolResource), ErrorMessageResourceName = "FieldRequired")]
        public int Quantity { get; set; }

        public string ImagePath { get; set; }
    }
}