using BookShopApp.Data;
using BookShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.ViewModels
{
    public static class Db
    {
        private static AppDbContext context = new();

        public static AppDbContext Context { get => context; set => context = value; }
    }
}
