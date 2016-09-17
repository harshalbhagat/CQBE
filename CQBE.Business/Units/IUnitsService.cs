using CQBE.Common.Types;
using CQBE.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQBE.Business.Units
{
    public interface IUnitsService
    {
        UnitResult xAdd(Unit xTemp, ObservableCollection<Unit> Units);
        UnitResult xUpDate(Unit xTemp, Unit xNew, ObservableCollection<Unit> Units);
        UnitResult xDelete(Unit xTemp, ObservableCollection<Unit> Units);
        UnitResult UpOrDown(Unit xTemp, bool MoveUp, ObservableCollection<Unit> Units);
        UnitResult xGetList(ObservableCollection<Unit> Units);

    }
}
