using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CQBE.Common
{
    public class GlobalVariables
    {
       
        public static void xSerialize<T>(List<T> xLst, String xFileName)
        {
            //string xFile = GetFilePath(xFileName);
            //FileStream xFileStream = new FileStream(xFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //try
            //{
            //    xFileStream.SetLength(0);
            //    if (binSerialize == false)
            //    {
            //        XmlSerializer xFormatter = new XmlSerializer(xLst.GetType());
            //        xFormatter.Serialize(xFileStream, xLst);
            //    }
            //    else
            //    {
            //        IFormatter formatter = new BinaryFormatter();
            //        formatter.Serialize(xFileStream, xLst);
            //    }
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); return; }
            //finally
            //{
            //    xFileStream.Flush();
            //    xFileStream.Dispose();
            //}
        }
        public static List<T> xDeSerialize<T>(String xFileName)
        {
            //string xFile = GetFilePath(xFileName);
            //List<T> xLst = new List<T>();
            //if (File.Exists(xFile) == false) { xLst = new List<T>(); return xLst; }
            //FileStream xFileStream = new FileStream(xFile, FileMode.Open, FileAccess.ReadWrite);
            //try
            //{
            //    if (binSerialize == false)
            //    {
            //        XmlSerializer xFormatter = new XmlSerializer(xLst.GetType());
            //        xLst = (List<T>)xFormatter.Deserialize(xFileStream);
            //    }
            //    else
            //    {
            //        IFormatter formatter = new BinaryFormatter();
            //        xLst = (List<T>)formatter.Deserialize(xFileStream);
            //    }
            //}
            //catch { }
            //finally
            //{
            //    xFileStream.Flush();
            //    xFileStream.Dispose();
            //}
            //return xLst;
            return null;
        }
        public static string GetFilePath(string xFileName)
        {
            return "" + xFileName;
        }
    }
}
