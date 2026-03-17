using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopApp.Models
{
    public partial class Product
    {
        public double? PriceAfterSale => Sale.HasValue ? Price * (1 - Sale.Value / 100) : Price; // Вычисляемое поле цены после скидки

        public bool IsOutOfStock => Count == 0; // Возращает закончился ли предмет на складе

        public bool HasDiscount => Sale.HasValue && Sale.Value > 0; // Возращает есть ли скидка

        public bool IsHigherThan15 => Sale.HasValue && Sale.Value > 17; // Возращает превышает ли скидка 15%

        public string PhotoPath => Photo.IsNullOrEmpty() ? "/Assets/Images/picture.png" : $"/Assets/Images/{Photo}"; // Вычисляемое поле пути к фотографиям
    }
}
