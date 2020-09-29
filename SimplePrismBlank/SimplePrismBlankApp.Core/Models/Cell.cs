// Models\Cell.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePrismBlank.Core.Models
{
    public class Cell
    {
        private int _cellNumber;
        public int cellNumber
        {
            get => _cellNumber;
        }

        public Cell(int cellNumber)
        {
            _cellNumber = cellNumber;
        }
    }
}
