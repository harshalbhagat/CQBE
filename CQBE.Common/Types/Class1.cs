using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQBE.Common.Types
{
    public enum UnitResult
    {
        Success,
        Failed,
        UnitsAlreadyExist,
        UnitCantContainAnyItem,
        IdNotContainInUintsList,
        NoUnitsSelected,
        UnitAtTopPosition,
        UnitAtBottomPosition
    }
}
