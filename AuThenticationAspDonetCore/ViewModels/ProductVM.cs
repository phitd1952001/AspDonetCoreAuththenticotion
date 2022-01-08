using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using AuThenticationAspDonetCore.Models;

namespace AuThenticationAspDonetCore.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}