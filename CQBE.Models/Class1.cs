using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQBE.Models
{
    public class Unit
    {
        public String xId { set; get; }
        public String xSeqNo { set; get; }
        public String xName { set; get; }
        public String xNameFt { set; get; }

        public Unit()
        {

        }
        public Unit(String _xId, String _xSeqNo, String _xName, String _xNameFt)
        {
            this.xId = _xId;
            this.xName = _xName;
            this.xNameFt = _xNameFt;
            this.xSeqNo = _xSeqNo;
        }
    }
}
