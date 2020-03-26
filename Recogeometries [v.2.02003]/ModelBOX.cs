using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recogeometries_project
{
    class ModelBOX
    {
        ///Version 1(I) model handling methods and algorithm
        #region MV1
        //ExtractIModelfromData
        //CheckSimiliarityInIModels
        //AddNewIModel
        public static List<string> ExtractIModelfromData(System.Windows.Forms.ListBox.ObjectCollection rawDataList)
        {
            List<string> Model = new List<string>();
            if (rawDataList.Count > 1)
            {
                Model.Add(">>Recogeometries prj data model version 1");
                //Model.Add(">>" + DateTime.UtcNow.ToLongDateString() + " " + DateTime.UtcNow.ToShortTimeString());
                string data0 = rawDataList[0].ToString();
                //Model.Add(data0);
                double lastChanges = 0;
                foreach (var rDdata1 in rawDataList)
                {
                    string data1 = rDdata1.ToString();
                    ///Modeling by changes
                    //>> -x : decreasing changes
                    //>> +x : increasing changes

                    ///Modeling by values
                    //>> .5 .6 .5 .5 .3 0 >> + - = - --
                    //>> .9 .9 .5 .3 .3 .9>> = -- -- = ++

                    try
                    {
                        double ddata0 = Convert.ToDouble(data0);
                        double ddata1 = Convert.ToDouble(data1);
                        double changes = 0;
                        if (ddata0 == -1) changes = ddata1; else if (ddata1 == -1) changes = ddata0; else changes = (ddata0 - ddata1);

                        if (changes == 0)
                            Model.Add("=");
                        else if ((changes > 0) && changes == lastChanges)
                            Model.Add("+");
                        else if ((changes < 0) && changes == lastChanges)
                            Model.Add("-");
                        else if (changes > 0.1)
                            Model.Add("++");
                        else if (changes < -0.1)
                            Model.Add("--");
                        //else
                        //    Model.Add("?");

                        data0 = data1;
                        lastChanges = changes;
                    }
                    catch { }
                }
            }

            List<string> revisedModel = new List<string>();
            if (Model.Count > 1)
            {
                for (int i = 1; i < Model.Count - 1; i++)
                {
                    if (Model[i] != Model[i - 1])
                        revisedModel.Add(Model[i]);
                }
            }
            return revisedModel;
        }
        public static List<string> CheckSimiliarityInIModels(System.Windows.Forms.ListBox.ObjectCollection extractedModel, string modelsDirectoryPath)
        {
            List<string> similiariesList = new List<string>();

            try
            {

                string extractedModelStr = "";
                foreach (var value in extractedModel)
                {
                    extractedModelStr += Environment.NewLine + value.ToString();
                }
                DirectoryInfo md = new DirectoryInfo(modelsDirectoryPath);   //Assuming models' directory
                FileInfo[] Files = md.GetFiles("*.ini");                     //Getting ini model files
                foreach (FileInfo model in Files)
                {
                    var OpenFile = new System.IO.StreamReader(model.FullName);
                    string learnedModel = OpenFile.ReadToEnd();

                    double similiariyPercentage = CheckSimiliarityIModel(extractedModelStr, learnedModel);
                    similiariesList.Add(similiariyPercentage.ToString() + ">>" + ExtractIModelNamefromINIData(learnedModel));
                }
            }
            catch { }

            return similiariesList;
        }
        private static double CheckSimiliarityIModel(String baseModel, String existsModel)
        {
            try
            {
                double simFromAll = 0;
                List<string> baseModelList = new List<string>();
                foreach (string value in baseModel.Split(Environment.NewLine.ToCharArray()))
                {
                    if (!String.IsNullOrEmpty(value.Trim()) && !value.Contains(">>"))
                        baseModelList.Add(value.Trim());
                }

                List<string> existsModelList = new List<string>();
                foreach (string value in existsModel.Split(Environment.NewLine.ToCharArray()))
                {
                    if (!String.IsNullOrEmpty(value.Trim()) && !value.Contains(">>"))
                        existsModelList.Add(value.Trim());
                }

                for (int index = 0; index < baseModelList.Count; index++)
                {
                    if (index < existsModelList.Count)
                        if (existsModelList[index].Trim() == baseModelList[index].Trim())
                        {
                            simFromAll++;
                        }
                }
                return (simFromAll * 100) / baseModelList.Count();
            }
            catch { return -1; }
        }
        private static string ExtractIModelNamefromINIData(string iModel)
        {
            try
            {
                int index = 0;
                string[] iModelSeparated = iModel.Split(Environment.NewLine.ToCharArray());
                foreach (string imValue in iModelSeparated)
                {
                    if (imValue.Contains(">>"))
                    {
                        if (index == 1)
                            return imValue.Replace(">>", "Model ");
                        else index++;
                    }
                }

                return "";
            }
            catch { return ""; }
        }
        #endregion MV1
    }
}
