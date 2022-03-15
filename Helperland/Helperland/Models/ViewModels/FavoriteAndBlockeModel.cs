using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models.ViewModels
{
    public class FavoriteAndBlockeModel
    {
        public int? UserId { get; set; }
        public int? TargetUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Profile { get; set; }
        public int? SPId { get; set; }
        public decimal Rating { get; set; }
        public int CleaningCount { get; set; }
        public bool? isBlocked { get; set; }
        public bool? isFavorite { get; set; }

        public List<FavoriteAndBlockeModel> blocked { get; set; }
    }
}
