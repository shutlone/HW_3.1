using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5._0_ViewModel.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; private set; } // значение для сортировки по имени
        public SortState StrenghtSort { get; private set; }    // значение для сортировки по возрасту
        public SortState MusicSort { get; private set; }   // значение для сортировки по компании
        public SortState Current { get; private set; }     // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            StrenghtSort = sortOrder == SortState.StrenghtAsc ? SortState.StrenghtDesc : SortState.StrenghtAsc;
            MusicSort = sortOrder == SortState.MusicAsc ? SortState.MusicDesc : SortState.MusicAsc;
            Current = sortOrder;
        }
    }
}
