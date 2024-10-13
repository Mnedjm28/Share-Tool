﻿using System;
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

        [Required(ErrorMessage="هذا الحقل إجباري")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public int Quantity { get; set; }

        public string ImagePath { get; set; }
    }
}