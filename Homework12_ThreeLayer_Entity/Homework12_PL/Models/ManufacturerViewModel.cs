﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12_PL.Models
{
    public class ManufacturerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<CarViewModel> CarsModel { get; set; }

        public IEnumerable<DetailViewModel> DetailsModel { get; set; }
    }
}
