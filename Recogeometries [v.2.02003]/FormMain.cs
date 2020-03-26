using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic;

namespace Recogeometries_project
{
    public partial class FormMain : Form
    {
        public readonly string _path_modelsDirectory = Application.StartupPath + @"\LearnedModels";
        public FormMain()
        {
            InitializeComponent();
        }

        private void label_Discription_Click(object sender, EventArgs e)
        {

        }

        private void button_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Files",

                CheckFileExists = true,
                CheckPathExists = true,

                RestoreDirectory = true,

                ShowReadOnly = true
            };

            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox_input.Image = ResizeImage(Image.FromFile(openFileDialog.FileName.Trim()), 500, 500);   /////////// RESIZING THE IMAGE FOR FASTER PROCESSING and SAMPLING TO MODEL

                    tabControl_ControlPanel.SelectedTab = (tabPage_Input);
                    listBox_edgesAllocationResults.Items.Clear();
                }
            }
            catch (Exception exp)
            {
                if (exp.Message.ToLower().Contains("memory"))
                    MessageBox.Show("An error has been occured! (File type error)");
                else
                    MessageBox.Show("An error has been occured! (" + exp.Message + ")");
            }
        }
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (listBox_edgesAllocationResults.Items.Count > 1) //Step 2 is completed and program is waiting for 3rd step(Modeling or Finding the most similar model)
            {
                listBox_extractedModel.Items.Clear();
                listBox_mostSimiliarModels.Items.Clear();
                List<string> extractedModel = ModelBOX.ExtractIModelfromData(listBox_edgesAllocationResults.Items);
                foreach (string value in extractedModel)
                    listBox_extractedModel.Items.Add(value);
                List<string> similiarityModelList = ModelBOX.CheckSimiliarityInIModels(listBox_extractedModel.Items, _path_modelsDirectory);
                if (similiarityModelList.Count > 0)
                {
                    foreach (string modelNameANDpercentage in similiarityModelList)
                        listBox_mostSimiliarModels.Items.Add(modelNameANDpercentage);
                }
                else //There's no match for this model
                {
                    if (listBox_extractedModel.Items.Count > 0)
                    {
                        button_addNewModel_Click(this, e);
                    }
                }

                string matchedModel = "UNKNOWN";
                double mostSimiliarity = 0;
                List<string> listSortedModels = new List<string>();
                foreach (var value in listBox_mostSimiliarModels.Items)
                {
                    try
                    {
                        string sValue = value.ToString();
                        double similiarity = Convert.ToDouble(sValue.Split(">>".ToCharArray())[0]);
                        if (similiarity > mostSimiliarity)
                        {
                            mostSimiliarity = similiarity;
                            matchedModel = sValue.Split(">>".ToCharArray())[2];
                            listSortedModels.Add("%"+similiarity + " "+ matchedModel);
                        }
                    }
                    catch { label_finalResult.Text = "UNKNOWN"; }
                }
                listBox_mostSimiliarModels.Items.Clear();
                listSortedModels.Reverse();
                foreach (string model in listSortedModels)
                {
                    listBox_mostSimiliarModels.Items.Add(model);
                }
                label_finalResult.Text = ">> "+ matchedModel.ToUpper().Replace("MODEL","")+" <<";

                tabControl_ControlPanel.SelectedTab = tabPage_result;
            }
            else if (pictureBox_input.Image != null) //Step 1 is completed and program is waiting for 2nd step(Initiating Process)
            {
                pictureBox_process.Image = ProcessOnGraphic();
                List<float> edgeAllocationData = Process();

                try
                {
                    chart_edgesAlloChart.Series.RemoveAt(0);
                }
                catch { }
                var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = "Series1",
                    Color = System.Drawing.Color.Green,
                    IsVisibleInLegend = false,
                    IsXValueIndexed = true,
                    BorderWidth = 2,                                 //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< !
                    ChartType = SeriesChartType.Line
                };
                chart_edgesAlloChart.Series.Clear();
                chart_edgesAlloChart.Series.Add(series1);
                int index = 0;
                listBox_edgesAllocationResults.Items.Clear();
                foreach (float dataSample in edgeAllocationData)
                {
                    series1.Points.AddXY(index, dataSample);
                    listBox_edgesAllocationResults.Items.Add(dataSample);
                    index++;
                }
                chart_edgesAlloChart.Invalidate();
                tabControl_ControlPanel.SelectedTab = tabPage_process;
            }
        }

        public List<float> Process()
        {
            Bitmap input = new Bitmap((Bitmap)pictureBox_input.Image);
            List<float> allocationResults = new List<float>();

            //Top to Bottom* 
            for (int i = 0; i < input.Width; i++)
            {
                Color lastColor = input.GetPixel(i, 0);
                float alloDotResult = -1;
                for (int j = 1; j < input.Height; j++)
                {
                    alloDotResult = -1;
                    Color thisColor = input.GetPixel(i, j);
                    if (!Is_Colorfamily_Equal(thisColor, lastColor, 1))
                    {
                        alloDotResult = (float)j / input.Height; ///////////////////////////////////////                       
                        break;
                    }
                }
                allocationResults.Add(alloDotResult);//.ToString());
            }

            //Left to Right*
            for (int i = 0; i < input.Width; i++)
            {
                Color lastColor = input.GetPixel(i, 0);
                float alloDotResult = -1;
                for (int j = 1; j < input.Height; j++)
                {
                    Color thisColor = input.GetPixel(j, i);
                    alloDotResult = -1;
                    if (!Is_Colorfamily_Equal(thisColor, lastColor, 1))
                    {
                        alloDotResult = (float)j / input.Width; ///////////////////////////////////////                       
                        break;
                    }
                }
                allocationResults.Add(alloDotResult);//.ToString());
            }

            //Bottom to Top*
            for (int i = input.Width - 1; i >= 0; i--)
            {
                Color lastColor = input.GetPixel(i, input.Height - 1);
                float alloDotResult = -1;
                for (int j = input.Height - 2; j >= 0; j--)
                {
                    Color thisColor = input.GetPixel(i, j);
                    alloDotResult = -1;
                    if (!Is_Colorfamily_Equal(thisColor, lastColor, 1))
                    {
                        alloDotResult = (float)(input.Height - j) / input.Height; ///////////////////////////////////////
                        break;
                    }
                }
                allocationResults.Add(alloDotResult);//.ToString());
            }

            //Right to Left*
            for (int i = input.Width - 1; i >= 0; i--)
            {
                Color lastColor = input.GetPixel(i, input.Height - 1);
                float alloDotResult = -1;
                for (int j = input.Height - 2; j >= 0; j--)
                {
                    Color thisColor = input.GetPixel(j, i);
                    alloDotResult = -1;
                    if (!Is_Colorfamily_Equal(thisColor, lastColor, 1))
                    {
                        alloDotResult = (float)(input.Width - j) / input.Width; ///////////////////////////////////////
                        break;
                    }
                }
                allocationResults.Add(alloDotResult);//.ToString());
            }

            return allocationResults;
        }
        public Bitmap ProcessOnGraphic()
        {
            Bitmap input = new Bitmap((Bitmap)pictureBox_input.Image);
            Bitmap result = new Bitmap((Bitmap)pictureBox_input.Image);

            //Top to Bottom
            for (int i = 0; i < input.Width; i++)
            {
                Color lastColor = input.GetPixel(i, 0);
                for (int j = 1; j < input.Height; j++)
                {
                    Color thisColor = input.GetPixel(i, j);

                    if (!Is_Colorfamily_Equal(thisColor, lastColor, 1))
                    {
                        break;
                    }
                    else
                        result.SetPixel(i, j, Color.DarkSlateBlue);
                }
            }

            //Left to Right
            for (int i = 0; i < input.Width; i++)
            {
                Color lastColor = input.GetPixel(i, 0);
                for (int j = 1; j < input.Height; j++)
                {
                    Color thisColor = input.GetPixel(j, i);

                    if (!Is_Colorfamily_Equal(thisColor, lastColor, 1))
                    {
                        break;
                    }
                    else
                        result.SetPixel(j, i, Color.DarkSlateBlue);
                }
            }

            //Bottom to Top
            for (int i = input.Width - 1; i >= 0; i--)
            {
                Color lastColor = input.GetPixel(i, input.Height - 1);
                for (int j = input.Height - 2; j >= 0; j--)
                {
                    Color thisColor = input.GetPixel(i, j);

                    if (!Is_Colorfamily_Equal(thisColor, lastColor, 1))
                    {
                        break;
                    }
                    else
                        result.SetPixel(i, j, Color.DarkSlateBlue);
                }
            }

            //Right to Left
            for (int i = input.Width - 1; i >= 0; i--)
            {
                Color lastColor = input.GetPixel(i, input.Height - 1);
                for (int j = input.Height - 2; j >= 0; j--)
                {
                    Color thisColor = input.GetPixel(j, i);

                    if (!Is_Colorfamily_Equal(thisColor, lastColor, 1))
                    {
                        break;
                    }
                    else
                        result.SetPixel(j, i, Color.DarkSlateBlue);
                }
            }

            return result;
        }

        private bool Is_Colorfamily_Equal(Color a, Color b, int accuracy)
        {
            if (Classify(accuracy, a) == Classify(accuracy, b))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Default accuracy = 1
        /// </summary>
        /// <param name="accuracy"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Color Classify(int accuracy, Color c)
        {
            switch (accuracy)
            {
                case 0:
                    {
                        return Color.Red;
                        break;
                    }
                case 1:
                    {
                        float hue = c.GetHue();
                        float sat = c.GetSaturation();
                        float lgt = c.GetBrightness();

                        if (lgt < 0.2) return Color.Black;
                        if (lgt > 0.8) return Color.White;

                        if (sat < 0.15/*0.25*/) return Color.Gray;

                        if (hue < 30) return Color.Red;
                        if (hue < 90) return Color.Yellow;
                        if (hue < 150) return Color.Green;
                        if (hue < 210) return Color.Cyan;
                        if (hue < 270) return Color.Blue;
                        if (hue < 330) return Color.Magenta;
                        return Color.Red;
                        break;
                    }
                case 2:
                    {
                        return Color.Red;
                        break;
                    }

                default:
                    {
                        Classify(1, c);
                        return Color.Empty;
                        break;
                    }
            }
        }

        private void button_exportProcess_Click(object sender, EventArgs e)
        {
            if (listBox_edgesAllocationResults.Items.Count > 1)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = "Export process step data";
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.Filter = "All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string subPath = saveFileDialog1.FileName + @"\RECOGMETRICS_PS2_" + DateTime.UtcNow.ToFileTime();
                    bool exists = System.IO.Directory.Exists(subPath);
                    if (!exists)
                        System.IO.Directory.CreateDirectory(subPath);

                    pictureBox_input.Image.Save(subPath + @"\Input.bmp");
                    pictureBox_process.Image.Save(subPath + @"\S2SResult.bmp");
                    System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(subPath + @"\S2SResult.inf");
                    SaveFile.WriteLine(this.Text);
                    SaveFile.WriteLine(DateTime.UtcNow.ToLongDateString() + " >> " + DateTime.UtcNow.ToShortTimeString());
                    foreach (var item in listBox_edgesAllocationResults.Items)
                    {
                        SaveFile.WriteLine(item.ToString());
                    }
                    SaveFile.Close();
                    chart_edgesAlloChart.SaveImage(subPath + @"\S2SResult.png", ChartImageFormat.Png);
                }
            }
        }

        private void button_addNewModel_Click(object sender, EventArgs e)
        {
            string modelName;
            if (listBox_extractedModel.Items.Count > 1)
            {
                modelName = Interaction.InputBox("Please enter a valid name for the new model:", "Model name", "UnknownRGS", -1, -1);
                if (!string.IsNullOrEmpty(modelName.Trim()))
                {
                    //if (!System.IO.File.Exists(modelName))
                    //{
                    bool exists = System.IO.Directory.Exists(_path_modelsDirectory);
                    if (!exists)
                        System.IO.Directory.CreateDirectory(_path_modelsDirectory);
                    System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(_path_modelsDirectory + @"\" + modelName + DateTime.UtcNow.ToFileTime() + ".ini");
                    SaveFile.WriteLine(">>" + this.Text);
                    SaveFile.WriteLine(">>" + modelName);
                    foreach (var item in listBox_extractedModel.Items)
                    {
                        SaveFile.WriteLine(item.ToString());
                    }
                    SaveFile.Close();
                }
            }
        }
    }
}
