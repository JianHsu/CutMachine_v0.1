
using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CutMachine_v0._1
{
    class EdgeAlogorithm
    {
        public Mat Step1;
        public Mat Step2;
        public Mat Step3;
        public Mat ContourImage;


        public EdgeAlogorithm(string ImageFilePath)
        {
            Mat src = CvInvoke.Imread(ImageFilePath, ImreadModes.Color);
            Mat dst = CvInvoke.Imread(ImageFilePath, ImreadModes.Color);
            Mat OtsuImage = CvInvoke.Imread(ImageFilePath, ImreadModes.Color);
            CvInvoke.GaussianBlur(src, src, new System.Drawing.Size(3, 3), 0, 0);        // 平滑濾波
            CvInvoke.BilateralFilter(src, dst, 9, 30, 30);                              // 雙邊濾波

            Mat dst1 = CvInvoke.Imread(ImageFilePath, ImreadModes.Color);
            Mat dst2 = CvInvoke.Imread(ImageFilePath, ImreadModes.Color);
            CvInvoke.Canny(dst, dst1, 10, 100, 3);               // Canny Edge Decteion
            CvInvoke.Threshold(dst1, dst2, 128, 255, ThresholdType.BinaryInv);  //反轉影像，讓邊緣呈現黑線

            Mat GraylevelImage = CvInvoke.Imread(ImageFilePath, ImreadModes.Color);
            CvInvoke.CvtColor(src, GraylevelImage, ColorConversion.Rgb2Gray);
            CvInvoke.Threshold(GraylevelImage, OtsuImage, 0, 255, ThresholdType.Otsu);

            Mat labels = CvInvoke.Imread(ImageFilePath, ImreadModes.Color), stats = CvInvoke.Imread(ImageFilePath, ImreadModes.Color), centroids = CvInvoke.Imread(ImageFilePath, ImreadModes.Color);
            int nccomps = CvInvoke.ConnectedComponentsWithStats(OtsuImage, labels, stats, centroids);

            List<uint[]> colors;
            colors = new List<uint[]>();
            colors.Add(new uint[] { 0, 0, 0 });
            for (int loopnum = 1; loopnum < nccomps; loopnum++)
            {
                Random r = new Random();

                if (stats.GetData(loopnum, 4)[0] < 200)
                {
                    colors.Add(new uint[3] { 0, 0, 0 });
                }
                else
                {
                    colors.Add(new uint[3] { (uint)r.Next(0, 256), (uint)r.Next(0, 256), (uint)r.Next(0, 256) });
                }
            }

            //var mat = new Mat(200, 200, DepthType.Cv64F, 3);
            for (int row = 0; row < src.Rows; row++)
            {
                for (int col = 0; col < src.Cols; col++)
                {
                    src.SetValue(row, col, (byte)col);
                    var value = src.GetValue(row, col);
                    //Console.WriteLine("Value = " + value);
                    /*if (value != 255 && Test < 50)
                    {
                        OtsuImage.SetValue(row, col, (byte)255);
                        Test++;
                        //System.Console.ReadKey();
                    }*/

                }
            }
            ImageContour imagecontour = new ImageContour();

            Mat ImageContourImage = imagecontour.ImageContourMethod(OtsuImage);

            Step1 = dst;
            Step2 = dst2;
            Step3 = OtsuImage;
            ContourImage = ImageContourImage;
            /*
            String win1 = "Canny_1"; //The name of the window
            CvInvoke.NamedWindow(win1); //Create the window using the specific name

            String win2 = "Canny_2"; //The name of the window
            CvInvoke.NamedWindow(win2); //Create the window using the specific name

            String win3 = "OtsuImage"; //The name of the window
            CvInvoke.NamedWindow(win3); //Create the window using the specific name

            String win4 = "OtsuImage_ImageContourMethod"; //The name of the window
            CvInvoke.NamedWindow(win4); //Create the window using the specific name

            CvInvoke.Imshow(win1, dst); //Show the image
            CvInvoke.Imshow(win2, dst2); //Show the image
            CvInvoke.Imshow(win3, OtsuImage); //Show the image
            CvInvoke.Imshow(win4, ImageContourImage); //Show the image
            CvInvoke.WaitKey(0);  //Wait for the key pressing event
            CvInvoke.DestroyWindow(win1); //Destroy the window if key is pressed
            CvInvoke.DestroyWindow(win2); //Destroy the window if key is pressed
            CvInvoke.DestroyWindow(win3); //Destroy the window if key is pressed
            CvInvoke.DestroyWindow(win4); //Destroy the window if key is pressed
            */
        }

        class ImageContour
        {
            private const char BLACK = (char)0;
            public const byte MarkValue = 255;

            public Mat ImageContourMethod(Mat InputMat)
            {
                Mat ReturnMat = new Mat(InputMat.Rows, InputMat.Cols, DepthType.Cv8U, 1);
                //  Initialize ReturnMat
                for (int row_loop = 0; row_loop < InputMat.Rows; row_loop++)
                {
                    for (int col_loop = 0; col_loop < InputMat.Cols; col_loop++)
                    {
                        var value = InputMat.GetValue(row_loop, col_loop);
                        ReturnMat.SetValue(row_loop, col_loop, (byte)0);
                    }
                }

                XYpoint OperationPoint = new XYpoint(0, 0);
                int loop_num_x = 0, loop_num_y = 0;
                //	Find X1, Y1
                for (loop_num_y = 0; loop_num_y < InputMat.Rows; loop_num_y++)      //	以for迴圈依序掃描圖像像素
                {                                                                   //	進入for迴圈
                    for (loop_num_x = 0; loop_num_x < InputMat.Cols; loop_num_x++)  //	以for迴圈依序掃描圖像像素
                    {
                        byte pixel_value = InputMat.GetValue(loop_num_y, loop_num_x);
                        if (pixel_value == BLACK)
                        {
                            OperationPoint.SetXYpoint(loop_num_x, loop_num_y);

                        }
                    }
                }                                                                   //	結束for迴圈	
                Console.WriteLine("X1 = " + OperationPoint.GetXValue().ToString());
                Console.WriteLine("Y1 = " + OperationPoint.GetYValue().ToString());

                List<XYpoint> MarkedPixels = new List<XYpoint>() { };
                MarkedPixels.Add(new XYpoint(OperationPoint));

                int CaseNumber = 0;                                                 //	上一格編號

                while (true)
                {
                    ReturnMat.SetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue(), (byte)MarkValue);
                    switch (CaseNumber)
                    {
                        case (0):
                            {
                                if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 5;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue()) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue(), ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 6;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 7;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, (int)OperationPoint.GetYValue());
                                    CaseNumber = 8;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 1;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue()) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue(), ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 2;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 3;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, (int)OperationPoint.GetYValue());
                                    CaseNumber = 4;
                                }
                                else
                                {
                                    CaseNumber = 9;
                                }
                                break;
                            }
                        case (1):
                            {

                                if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue()) == BLACK)
                                {
                                    OperationPoint.SetXYpoint(((int)(OperationPoint.GetXValue())), ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 6;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 7;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, (int)OperationPoint.GetYValue());
                                    CaseNumber = 8;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 1;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue()) == BLACK)
                                {
                                    OperationPoint.SetXYpoint(OperationPoint.GetXValue(), ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 2;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 3;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, (int)OperationPoint.GetYValue());
                                    CaseNumber = 4;
                                }
                                else
                                {
                                    CaseNumber = 9;
                                }
                                break;
                            }
                        case (2):
                            {

                                if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 7;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, (int)OperationPoint.GetYValue());
                                    CaseNumber = 8;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 1;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue()) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue(), ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 2;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 3;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, (int)OperationPoint.GetYValue());
                                    CaseNumber = 4;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 5;
                                }
                                else
                                {
                                    CaseNumber = 9;
                                }
                                break;
                            }
                        case (3):
                            {

                                if (InputMat.GetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, (int)OperationPoint.GetYValue());
                                    CaseNumber = 8;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 1;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue()) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue(), ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 2;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 3;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, (int)OperationPoint.GetYValue());
                                    CaseNumber = 4;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 5;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue()) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue(), ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 6;
                                }
                                else
                                {
                                    CaseNumber = 9;
                                }
                                break;

                            }
                        case (4):
                            {

                                if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 1;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue()) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue(), ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 2;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 3;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue()));
                                    CaseNumber = 4;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 5;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue()) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue(), ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 6;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 7;
                                }
                                else
                                {
                                    CaseNumber = 9;
                                }
                                break;

                            }
                        case (5):
                            {
                                if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue()) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue(), ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 2;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 3;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue()));
                                    CaseNumber = 4;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 5;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue()) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue(), ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 6;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 7;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue()));
                                    CaseNumber = 8;
                                }
                                else
                                {
                                    CaseNumber = 9;
                                }
                                break;
                            }
                        case (6):
                            {

                                if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 3;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue()));
                                    CaseNumber = 4;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 5;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue()) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue(), ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 6;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 7;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue()));
                                    CaseNumber = 8;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 1;
                                }
                                else
                                {
                                    CaseNumber = 9;
                                }
                                break;
                            }
                        case (7):
                            {

                                if (InputMat.GetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue()));
                                    CaseNumber = 4;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 5;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue()) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue(), ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 6;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 7;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue()));
                                    CaseNumber = 8;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 1;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue()) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue(), ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 2;
                                }
                                else
                                {
                                    CaseNumber = 9;
                                }
                                break;
                            }
                        case (8):
                            {

                                if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 5;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue()) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue(), ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 6;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() + 1, (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue() + 1));
                                    CaseNumber = 7;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue(), (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue()));
                                    CaseNumber = 8;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue() + 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() + 1, ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 1;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue()) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue(), ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 2;
                                }
                                else if (InputMat.GetValue((int)OperationPoint.GetYValue() - 1, (int)OperationPoint.GetXValue() - 1) == BLACK)
                                {
                                    OperationPoint.SetXYpoint((int)OperationPoint.GetXValue() - 1, ((int)OperationPoint.GetYValue() - 1));
                                    CaseNumber = 3;
                                }
                                else
                                {
                                    CaseNumber = 9;
                                }
                                break;
                            }
                        case (9):                                                               //  Not complete
                            {
                                MarkedPixels.Clear();                                           //  Clear points
                                                                                                //***Clear image data***
                                for (int row_loop = 0; row_loop < InputMat.Rows; row_loop++)
                                {
                                    for (int col_loop = 0; col_loop < InputMat.Cols; col_loop++)
                                    {
                                        ReturnMat.SetValue(row_loop, col_loop, (byte)0);
                                    }
                                }
                                return ReturnMat;
                            }
                    }
                    Console.WriteLine("(" + OperationPoint.GetXValue().ToString() + "," + OperationPoint.GetYValue().ToString() + ")");
                    Console.WriteLine("CaseNumber = " + CaseNumber.ToString());
                    try
                    {
                        bool PointAlreadExist = false;
                        foreach (XYpoint item in MarkedPixels)
                        {
                            if ((item.GetXValue() == (int)OperationPoint.GetXValue()) && (item.GetYValue() == (int)OperationPoint.GetYValue()))
                            {
                                PointAlreadExist = true;
                            }
                        }
                        if (PointAlreadExist == false)
                        {
                            MarkedPixels.Add(new XYpoint(OperationPoint));
                        }
                        else
                        {
                            return ReturnMat;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        class XYpoint
        {
            private double point_X, point_Y;                                    //	在XYpoint class中有兩項雙精度浮點數
            public XYpoint(double X, double Y)                                  //	設定class成員
            {                                                                   //	設定class成員
                point_X = X;                                                    //	宣告XYpointclass內部元素(X座標)
                point_Y = Y;                                                    //	宣告XYpointclass內部元素(Y座標)
            }                                                                   //	設定class成員完成
            public XYpoint(XYpoint NewXYpoint)
            {
                this.point_X = NewXYpoint.GetXValue();
                this.point_Y = NewXYpoint.GetYValue();
            }
            public void SetXYpoint(double X, double Y)
            {
                this.point_X = X;
                this.point_Y = Y;
            }
            public void SetXYpoint(XYpoint NewXYpoint)
            {
                this.point_X = NewXYpoint.GetXValue();
                this.point_Y = NewXYpoint.GetYValue();
            }
            public double GetXValue()
            {
                return this.point_X;
            }
            public double GetYValue()
            {
                return this.point_Y;
            }
        }

    }
    public static class MatExtension
    {
        public static dynamic GetValue(this Mat mat, int row, int col)
        {
            var value = CreateElement(mat.Depth);
            Marshal.Copy(mat.DataPointer + (row * mat.Cols + col) * mat.ElementSize, value, 0, 1);
            return value[0];
        }

        public static void SetValue(this Mat mat, int row, int col, dynamic value)
        {
            var target = CreateElement(mat.Depth, value);
            Marshal.Copy(target, 0, mat.DataPointer + (row * mat.Cols + col) * mat.ElementSize, 1);
        }
        private static dynamic CreateElement(DepthType depthType, dynamic value)
        {
            var element = CreateElement(depthType);
            element[0] = value;
            return element;
        }

        private static dynamic CreateElement(DepthType depthType)
        {
            if (depthType == DepthType.Cv8S)
            {
                return new sbyte[1];
            }
            if (depthType == DepthType.Cv8U)
            {
                return new byte[1];
            }
            if (depthType == DepthType.Cv16S)
            {
                return new short[1];
            }
            if (depthType == DepthType.Cv16U)
            {
                return new ushort[1];
            }
            if (depthType == DepthType.Cv32S)
            {
                return new int[1];
            }
            if (depthType == DepthType.Cv32F)
            {
                return new float[1];
            }
            if (depthType == DepthType.Cv64F)
            {
                return new double[1];
            }
            return new float[1];
        }
    }
}
