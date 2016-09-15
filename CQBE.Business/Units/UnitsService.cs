using CQBE.Common;
using CQBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQBE.Business.Units
{
    public class UnitsService : IUnitsService
    {
        private static List<Unit> mLst = new List<Unit>();
        public static bool UseMeters = true;
        public void xSerialize()
        {
            String xFileName = "Units.xml";
            GlobalVariables.xSerialize<Unit>(mLst, xFileName);
        }
        public void xDeSerialize()
        {
            String xFileName = "Units.xml";
            mLst = new List<Unit>();
            mLst = GlobalVariables.xDeSerialize<Unit>(xFileName);
        }
        private Int32 GetNewID()
        {
            if (mLst.Count == 0) return 101;
            List<Unit> xLst = mLst.FindAll(p => p.xId.Length == 3);
            xLst = xLst.OrderBy(p => Convert.ToInt32(p.xId)).ToList();
            if (xLst.Count == 0) return 101;
            return Convert.ToInt32(xLst[xLst.Count - 1].xId) + 1;
        }
        private Int32 GetNewSeqNo()
        {
            if (mLst.Count == 0) return 100001;
            List<Unit> xLst = mLst.FindAll(p => p.xId.Length == 3);
            xLst = xLst.OrderBy(p => Convert.ToInt32(p.xSeqNo)).ToList();
            if (xLst.Count == 0) return 100001;
            return Convert.ToInt32(xLst[xLst.Count - 1].xSeqNo) + 1;
        }
        public String xAdd(Unit xTemp)
        {
            try
            {
                if (UseMeters == true)
               {
                    if (Exists(xTemp.xName) == true) return GetIDByName(xTemp.xName);
                }
                else
                {
                    if (Exists(xTemp.xNameFt) == true) return GetIDByName(xTemp.xNameFt);
                }
                xTemp.xSeqNo = GetNewSeqNo().ToString();
                xTemp.xId = GetNewID().ToString();
                mLst.Add(xTemp);
                return xTemp.xId;
            }
            catch { return string.Empty; }
        }
        public void xUpDate(Unit xTemp)
        {
            try
            {
                if (mLst.Exists(p => p.xId == xTemp.xId) == false) return;
                if (mLst.Exists(p => p.xId != xTemp.xId && p.xName == xTemp.xName) == true)
                {
                    //MessageBox.Show("Unit Name Already Exists.");
                    return;
                }
                if (mLst.Exists(p => p.xId != xTemp.xId && p.xNameFt == xTemp.xNameFt) == true)
                {
                    //MessageBox.Show("Unit Name Already Exists.");
                    return;
                }
                Int32 xInd = mLst.FindIndex(p => p.xId == xTemp.xId);
                xTemp.xSeqNo = mLst[xInd].xSeqNo;
                xTemp.xId = mLst[xInd].xId;
                mLst.RemoveAt(xInd);
                mLst.Add(xTemp);
            }
            catch { }
        }
        public void xDelete(String xId)
        {
            try
            {
                if (String.IsNullOrEmpty(xId)) return;
                if (xId.Length == 3)
                {
                    mLst.RemoveAll(p => p.xId.Substring(0, 3) == xId);
                }
            }
            catch { }
        }
        public void UpOrDown(String xId, bool MoveUp)
        {
            try
            {
                List<Unit> xLst = new List<Unit>();
                if (xId.Length == 3)
                {
                    xLst = mLst.FindAll(p => p.xId.Length == 3);
                }

                if (xLst.Count < 2) return;

                xLst = xLst.OrderBy(p => Convert.ToInt32(p.xSeqNo)).ToList();
                if (MoveUp == false) xLst.Reverse();

                if (xLst[0].xId == xId) return;

                for (int i = 1; i < xLst.Count; i++)
                {
                    if (xLst[i].xId == xId)
                    {
                        String xTemp = xLst[i].xSeqNo;
                        xLst[i].xSeqNo = xLst[i - 1].xSeqNo;
                        xLst[i - 1].xSeqNo = xTemp;
                    }
                }

                if (xId.Length == 3)
                {
                    mLst.RemoveAll(p => p.xId.Length == 3);
                }
                mLst.AddRange(xLst);
            }
            catch
            { }
        }

        public bool Exists(String UnitName)
        {
            if (UseMeters == true)
            {
                if (mLst.Exists(p => p.xName.ToLower() == UnitName.ToLower())) return true;
            }
            else
            {
                if (mLst.Exists(p => p.xNameFt.ToLower() == UnitName.ToLower())) return true;

            }
            return false;
        }
        public List<Unit> GetList()
        {
            return mLst;
        }
        public String GetIDByName(String xName)
        {
            if (UseMeters == true)
            {
                Unit xTemp = mLst.Find(p => p.xName.ToLower() == xName.ToLower());
                if (xTemp == null) return "";
                return xTemp.xId;
            }
            else
            {
                Unit xTemp = mLst.Find(p => p.xNameFt.ToLower() == xName.ToLower());
                if (xTemp == null) return "";
                return xTemp.xId;

            }
        }
        public String GetNameByID(String xId)
        {
            if (UseMeters == true)
            {
                Unit xTemp = mLst.Find(p => p.xId == xId);
                if (xTemp == null) return "";
                return xTemp.xName;
            }
            else
            {
                Unit xTemp = mLst.Find(p => p.xId == xId);
                if (xTemp == null) return "";
                return xTemp.xNameFt;
            }
        }

        public List<Unit> GetUnitList()
        {
            return mLst;
        }
    }
}
