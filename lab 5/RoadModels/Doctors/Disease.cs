using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    public static class Disease
    {
        static string[] _allDisease = new string[]
        {
            "Авария",
            "Сбили человека",
            "Водитель заснул",
            "Водитель умер",
            "Пещеход умер"
        };

        public static string[] AllDisease { get => _allDisease; }
    }
}
