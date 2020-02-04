using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5._0_ViewModel.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Music> msc, int? alc, string brand)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            msc.Insert(0, new Music { Name = "Все", Id = 0 });
            Music = new SelectList(msc, "Id", "Executor", alc);
            SelectedAlc = alc;
            SelectedBrand = brand;
        }
        public SelectList Music { get; private set; }
        public int? SelectedAlc { get; private set; }
        public string SelectedBrand { get; private set; }
    }

    public enum SortState
    {
        NameAsc,
        NameDesc,
        StrenghtAsc,
        StrenghtDesc,
        MusicAsc,
        MusicDesc
    }
}
