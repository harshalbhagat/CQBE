using CQBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQBE.Business.Units
{
    public interface IUnitsService
    {
        String xAdd(Unit xTemp);
        void xUpDate(Unit xTemp);
        void xDelete(String xId);
        void UpOrDown(String xId, bool MoveUp);
        List<Unit> GetUnitList();
    }
}
