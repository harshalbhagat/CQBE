using CQBE.Common;
using CQBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQBE.Common.Types;
using System.Collections.ObjectModel;

namespace CQBE.Business.Units
{
    public class UnitsService : IUnitsService
    {

        public static bool UseMeters = true;
        //public void xSerialize()
        //{
        //    String xFileName = "Units.xml";
        //    GlobalVariables.xSerialize<Unit>(mLst, xFileName);
        //}
        //public void xDeSerialize()
        //{
        //    String xFileName = "Units.xml";
        //    mLst = new List<Unit>();
        //    mLst = GlobalVariables.xDeSerialize<Unit>(xFileName);
        //}
        private Int32 GetNewID(ObservableCollection<Unit> mLst)
        {
            if (mLst.Count == 0) return 101;
            var xLst = mLst.OrderBy(p => Convert.ToInt32(p.xId)).ToList();
            if (xLst.Count == 0) return 101;
            return Convert.ToInt32(xLst[xLst.Count - 1].xId) + 1;
        }
        private Int32 GetNewSeqNo(ObservableCollection<Unit> mLst)
        {
            if (mLst.Count == 0) return 100001;
            var xLst = mLst.OrderBy(p => Convert.ToInt32(p.xSeqNo)).ToList();
            if (xLst.Count == 0) return 100001;
            return Convert.ToInt32(xLst[xLst.Count - 1].xSeqNo) + 1;
        }


        // Tested and working fine.
        public UnitResult xAdd(Unit xTemp, ObservableCollection<Unit> Units)
        {
            if (Units.Count == 0)
            {
                xTemp.xSeqNo = GetNewSeqNo(Units).ToString();
                xTemp.xId = GetNewID(Units).ToString();
                Units.Add(xTemp);
                return UnitResult.Success;
            }
            else if (!Units.Contains<Unit>(xTemp))
            {
                xTemp.xSeqNo = GetNewSeqNo(Units).ToString();
                xTemp.xId = GetNewID(Units).ToString();
                Units.Add(xTemp);
                return UnitResult.Success;
            }
            else
            {
                return UnitResult.UnitsAlreadyExist;
            }
        }


        public UnitResult xUpDate(Unit xTemp, Unit xNew, ObservableCollection<Unit> Units)
        {


            var result = Units.FirstOrDefault(p => p.xId == xTemp.xId);
            Int32 xInd = Units.IndexOf(result);


            xTemp.xNameFt = xNew.xNameFt;
            xTemp.xName = xNew.xName;
            if (Units.Contains<Unit>(xTemp))
            {
                return UnitResult.UnitsAlreadyExist;
            }
            else
            {
                Units.RemoveAt(xInd);
                Units.Insert(xInd, xTemp);
                return UnitResult.Success;
            }

        }

        public UnitResult xDelete(string xId, ObservableCollection<Unit> Units)
        {
            try
            {
                if (String.IsNullOrEmpty(xId)) return UnitResult.NoUnitsSelected;

                var result = Units.FirstOrDefault(x => x.xId == xId);

                if (Units.Count(x => x.xId == xId) > 1)
                {
                    Units.Remove(result);
                    return UnitResult.Success;
                }

            }
            catch { }
            return UnitResult.Failed;
        }



        public UnitResult xGetList(ObservableCollection<Unit> Units)
        {
            throw new NotImplementedException();
        }

        public UnitResult xDelete(Unit xTemp, ObservableCollection<Unit> Units)
        {
            if (Units.Remove(xTemp))
            {
                return UnitResult.Success;
            }
            return UnitResult.Failed;
        }

        //public UnitResult UpOrDown(Unit xTemp, bool MoveUp, ObservableCollection<Unit> Units)
        //{

        //    if (MoveUp)
        //    {


        //    }
        //    else
        //    {
        //        if (Units.Count == 1)
        //        {
        //            return UnitResult.UnitAtTopPosition;
        //        }
        //       else
        //        {
        //            if (xInd == 0)
        //            {
        //                return UnitResult.UnitAtTopPosition;
        //            }
        //            else
        //            {
        //                var temp1 = Units.ElementAt(xInd);
        //                var temp2 = Units.ElementAt(xInd + 1);
        //                Units.RemoveAt(xInd);
        //                Units.RemoveAt(xInd + 1);

        //                Units.Insert(xInd, temp2);
        //                Units.Insert(xInd + 1, temp1);
        //                return UnitResult.Success;
        //            }
        //        }
        //    }

        //}

        public UnitResult xMoveUp(Unit xTemp, ObservableCollection<Unit> Units)
        {
            int xInd = Units.IndexOf(xTemp);

            if (Units.Count == 1)
            {
                return UnitResult.UnitAtTopPosition;
            }
            else
            {
                if (xInd == 0)
                {
                    return UnitResult.UnitAtTopPosition;
                }
                else
                {
                    var old = Units[xInd - 1];
                    Units[xInd - 1] = Units[xInd];
                    Units[xInd] = old;
                    return UnitResult.Success;
                }
            }
        }

        public UnitResult xMoveDown(Unit xTemp, ObservableCollection<Unit> Units)
        {
            int xInd = Units.IndexOf(xTemp);

            if (Units.Count == 1 || Units.Count == xInd)
            {
                return UnitResult.UnitAtBottomPosition;
            }
            else
            {
                if (xInd == 0)
                {
                    return UnitResult.UnitAtBottomPosition;
                }
                else
                {
                    var old = Units[xInd + 1];
                    Units[xInd + 1] = Units[xInd];
                    Units[xInd] = old;
                    return UnitResult.Success;
                }
            }
        }
        //public String xAdd(Unit xTemp)
        //{
        //    try
        //    {
        //        if (UseMeters == true)
        //       {
        //            if (Exists(xTemp.xName) == true) return GetIDByName(xTemp.xName);
        //        }
        //        else
        //        {
        //            if (Exists(xTemp.xNameFt) == true) return GetIDByName(xTemp.xNameFt);
        //        }
        //        xTemp.xSeqNo = GetNewSeqNo().ToString();
        //        xTemp.xId = GetNewID().ToString();
        //        mLst.Add(xTemp);
        //        return xTemp.xId;
        //    }
        //    catch { return string.Empty; }
        //}
        //public void xUpDate(Unit xTemp)
        //{
        //    try
        //    {
        //        if (mLst.Exists(p => p.xId == xTemp.xId) == false) return;
        //        if (mLst.Exists(p => p.xId != xTemp.xId && p.xName == xTemp.xName) == true)
        //        {
        //            //MessageBox.Show("Unit Name Already Exists.");
        //            return;
        //        }
        //        if (mLst.Exists(p => p.xId != xTemp.xId && p.xNameFt == xTemp.xNameFt) == true)
        //        {
        //            //MessageBox.Show("Unit Name Already Exists.");
        //            return;
        //        }
        //        Int32 xInd = mLst.FindIndex(p => p.xId == xTemp.xId);
        //        xTemp.xSeqNo = mLst[xInd].xSeqNo;
        //        xTemp.xId = mLst[xInd].xId;
        //        mLst.RemoveAt(xInd);
        //        mLst.Add(xTemp);
        //    }
        //    catch { }
        //}
        //public void xDelete(String xId)
        //{
        //    try
        //    {
        //        if (String.IsNullOrEmpty(xId)) return;
        //        if (xId.Length == 3)
        //        {
        //            mLst.RemoveAll(p => p.xId.Substring(0, 3) == xId);
        //        }
        //    }
        //    catch { }
        //}
        //public void UpOrDown(String xId, bool MoveUp)
        //{
        //    try
        //    {
        //        List<Unit> xLst = new List<Unit>();
        //        if (xId.Length == 3)
        //        {
        //            xLst = mLst.FindAll(p => p.xId.Length == 3);
        //        }

        //        if (xLst.Count < 2) return;

        //        xLst = xLst.OrderBy(p => Convert.ToInt32(p.xSeqNo)).ToList();
        //        if (MoveUp == false) xLst.Reverse();

        //        if (xLst[0].xId == xId) return;

        //        for (int i = 1; i < xLst.Count; i++)
        //        {
        //            if (xLst[i].xId == xId)
        //            {
        //                String xTemp = xLst[i].xSeqNo;
        //                xLst[i].xSeqNo = xLst[i - 1].xSeqNo;
        //                xLst[i - 1].xSeqNo = xTemp;
        //            }
        //        }

        //        if (xId.Length == 3)
        //        {
        //            mLst.RemoveAll(p => p.xId.Length == 3);
        //        }
        //        mLst.AddRange(xLst);
        //    }
        //    catch
        //    { }
        //}

        //public bool Exists(String UnitName)
        //{
        //    if (UseMeters == true)
        //    {
        //        if (mLst.Exists(p => p.xName.ToLower() == UnitName.ToLower())) return true;
        //    }
        //    else
        //    {
        //        if (mLst.Exists(p => p.xNameFt.ToLower() == UnitName.ToLower())) return true;

        //    }
        //    return false;
        //}
        //public List<Unit> GetList()
        //{
        //    return mLst;
        //}
        //public String GetIDByName(String xName)
        //{
        //    if (UseMeters == true)
        //    {
        //        Unit xTemp = mLst.Find(p => p.xName.ToLower() == xName.ToLower());
        //        if (xTemp == null) return "";
        //        return xTemp.xId;
        //    }
        //    else
        //    {
        //        Unit xTemp = mLst.Find(p => p.xNameFt.ToLower() == xName.ToLower());
        //        if (xTemp == null) return "";
        //        return xTemp.xId;

        //    }
        //}
        //public String GetNameByID(String xId)
        //{
        //    if (UseMeters == true)
        //    {
        //        Unit xTemp = mLst.Find(p => p.xId == xId);
        //        if (xTemp == null) return "";
        //        return xTemp.xName;
        //    }
        //    else
        //    {
        //        Unit xTemp = mLst.Find(p => p.xId == xId);
        //        if (xTemp == null) return "";
        //        return xTemp.xNameFt;
        //    }
        //}


    }
}
