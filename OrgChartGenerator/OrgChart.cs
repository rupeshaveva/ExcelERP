#region Copyright © 2007 Rotem Sapir
/*
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from the
 * use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not claim
 * that you wrote the original software. If you use this software in a product,
 * an acknowledgment in the product documentation is required, as shown here:
 *
 * Portions Copyright © 2007 Rotem Sapir
 *
 * 2. No substantial portion of the source code of this library may be redistributed
 * without the express written permission of the copyright holders, where
 * "substantial" is defined as enough code to be recognizably from this library.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Xml;

namespace OrgChartGenerator
{
    public class OrgChart : IDisposable
    {

        private Color _FontColor = Color.Black;
        private int _BoxWidth = 120;
        private int _BoxHeight = 60;
        private int _Margin = 20;
        private int _HorizontalSpace = 30;
        private int _VerticalSpace = 30;
        private int _FontSize = 9;
        private int imgWidth = 0;
        private int imgHeight = 0;
        private Graphics gr;
        private Color _LineColor = Color.Black;
        private float _LineWidth = 2;
        private Color _BoxFillColor = Color.White;
        private Color _BGColor = Color.White;
        /// <summary>
        /// the employee data
        /// </summary>
        private OrgData.OrgDetailsDataTable dtOrg;
        /// <summary>
        /// A list of the employee positions.
        /// </summary>
        //private List<EmployeePos> EmpPositions;
        // A Dictionary of all employee data
        private SortedDictionary<string, OrgChartRecord> EmployeeChartData;

        public SortedDictionary<string, OrgChartRecord> EmployeeData
        {
            get { return EmployeeChartData; }
            set { EmployeeChartData = value; }
        }
        public Color BoxFillColor
        {
            get { return _BoxFillColor; }
            set { _BoxFillColor = value; }
        }
        public int BoxWidth
        {
            get { return _BoxWidth; }
            set { _BoxWidth = value; }
        }
        public int BoxHeight
        {
            get { return _BoxHeight; }
            set { _BoxHeight = value; }
        }
        public int Margin
        {
            get { return _Margin; }
            set { _Margin = value; }
        }
        public int HorizontalSpace
        {
            get { return _HorizontalSpace; }
            set { _HorizontalSpace = value; }
        }
        public int VerticalSpace
        {
            get { return _VerticalSpace; }
            set { _VerticalSpace = value; }
        }
        public int FontSize
        {
            get { return _FontSize; }
            set { _FontSize = value; }
        }
        public Color LineColor
        {
            get { return _LineColor; }
            set { _LineColor = value; }
        }
        public float LineWidth
        {
            get { return _LineWidth; }
            set { _LineWidth = value; }
        }


        public Color BGColor
        {
            get { return _BGColor; }
            set { _BGColor = value; }
        }

        public Color FontColor
        {
            get { return _FontColor; }
            set { _FontColor = value; }
        }

        public OrgChart(OrgData.OrgDetailsDataTable OrganizationalDataTable)
        {
            //TODO: Fill/Gradient in boxes
            //TODO: Add employee pics

            dtOrg = OrganizationalDataTable;

        }

        public void Dispose()
        {
            dtOrg = null;

            if (gr != null)
            {
                gr.Dispose();
                gr = null;
            }
        }


        /// <summary>
        /// The main function used to create the image
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="BossEmployeeID">The ID of the Boss from which to start building the chart</param>
        /// <param name="ImageType"></param>
        /// <returns>A stream of the image. can be shown or saved to disk.</returns>
        public System.IO.Stream GenerateOrgChart(int Width,
                                        int Height,
                                        string BossEmployeeID,
                                        ImageFormat ImageType)
        {
            MemoryStream Result = new MemoryStream();

            EmployeeChartData = new SortedDictionary<string, OrgChartRecord>();

            //reset image size
            imgHeight = 0;
            imgWidth = 0;
            //define the image
            OrgTree = null;
            OrgTree = new XmlDocument();
            
            XmlNode RootNode = OrgTree.CreateNode(XmlNodeType.Element, "RootNode", "");

            XmlAttribute Att = OrgTree.CreateAttribute("EmployeeID");
            Att.InnerText = BossEmployeeID;
            RootNode.Attributes.Append(Att);
            OrgTree.AppendChild(RootNode);
            BuildTree(RootNode, 0);
            //uncomment lines below to save the xml created, for debugging.
            //XmlTextWriter xw = new XmlTextWriter(@"d:\temp\1.xml", Encoding.UTF8);
            //OrgTree.WriteTo(xw);
            //xw.Flush();
            //xw.Close();
                       
            Bitmap bmp = new Bitmap(imgWidth, imgHeight);
            gr = Graphics.FromImage(bmp);
            gr.Clear(_BGColor);
            DrawChart(RootNode);
            
            //if caller does not care about size, use original calculated size
            if (Width < 0)
            {
                Width = imgWidth;
            }
            if (Height < 0)
            {
                Height = imgHeight;
            }

            Bitmap ResizedBMP = new Bitmap(bmp, new Size(Width, Height));
            //after resize - change the coordinates of the list, in order return the proper coordinates
            //for each employee
            CalculateImageMapData(Width, Height);
            ResizedBMP.Save(Result, ImageType);
            ResizedBMP.Dispose();
            bmp.Dispose();
            gr.Dispose();
            return Result;


        }
        /// <summary>
        /// This overloaded method can be used to return the image using it's default calculated size, without resizing
        /// </summary>
        /// <param name="BossEmployeeID"></param>
        /// <param name="ImageType"></param>
        /// <returns></returns>
        public System.IO.Stream GenerateOrgChart(
                                        string BossEmployeeID,
                                        ImageFormat ImageType)
        {
            return GenerateOrgChart(-1, -1, BossEmployeeID, ImageType);


        }
        private XmlDocument OrgTree;
        private void BuildTree(XmlNode EmployeeNode, int y)
        {

            //has employees
            foreach (OrgData.OrgDetailsRow EmployeeRow in dtOrg.Select(string.Format("BossEmployeeID='{0}'", EmployeeNode.Attributes["EmployeeID"].InnerText)))
            {
                //for each employee call this function again
                XmlNode NewEmployeeNode = OrgTree.CreateElement("Node");
                //NewEmployeeNode.InnerText = EmployeeRow.EmployeeID;
                XmlAttribute Att = OrgTree.CreateAttribute("EmployeeID");
                Att.InnerText = EmployeeRow.EmployeeID;
                NewEmployeeNode.Attributes.Append(Att);
                EmployeeNode.AppendChild(NewEmployeeNode);
                BuildTree(NewEmployeeNode, y + 1);

            }
            //build employee data
            //after checking for employees we can add the current employee
            OrgChartRecord CurrentEmp = new OrgChartRecord();
            CurrentEmp.EmployeeData = ((OrgData.OrgDetailsRow)dtOrg.Select(string.Format("EmployeeID='{0}'", EmployeeNode.Attributes["EmployeeID"].Value))[0]);
            CurrentEmp.EmployeeCount = EmployeeNode.ChildNodes.Count;


            int StartX;
            int StartY;
            int[] ResultsArr = new int[] {GetXPosByOwnChildren(EmployeeNode),
                                    GetXPosByParentPreviousSibling(EmployeeNode),
                                    GetXPosByPreviousSibling(EmployeeNode),
                                    _Margin };
            Array.Sort(ResultsArr);
            StartX = ResultsArr[3];
            StartY = (y * (_BoxHeight + _VerticalSpace)) + _Margin;
            int width = _BoxWidth;
            int height = _BoxHeight;
            //update the coordinates of this box into the matrix, for later calculations

            Rectangle drawRect = new Rectangle(StartX, StartY, width, height);
            //update the image size
            if (imgWidth < (StartX + width + _Margin))
            {
                imgWidth = StartX + width + _Margin;
            }
            if (imgHeight < (StartY + height + _Margin))
            {
                imgHeight = StartY + height + _Margin;
            }
            CurrentEmp.EmployeePos = drawRect;

            EmployeeChartData.Add(CurrentEmp.EmployeeData.EmployeeID,
                                                        CurrentEmp);
            CurrentEmp.Dispose();
            CurrentEmp = null;




        }

        /************************************************************************************************************************
         * The box position is affected by:
         * 1. The previous sibling (box on the same level)
         * 2. The positions of it's children
         * 3. The position of it's uncle (parents' previous sibling)/ cousins (parents' previous sibling children)
         * What determines the position is the farthest x of all the above. If all/some of the above have no value, the margin 
         * becomes the dtermining factor.
         * **********************************************************************************************************************
        */

        private int GetXPosByPreviousSibling(XmlNode CurrentNode)
        {
            int Result = -1;
            XmlNode PrevSibling = CurrentNode.PreviousSibling;
            if (PrevSibling != null)
            {
                if (PrevSibling.HasChildNodes)
                {
                    Result = EmployeeChartData[PrevSibling.LastChild.Attributes["EmployeeID"].Value].EmployeePos.X + _BoxWidth + _HorizontalSpace;
                }
                else
                {
                    Result = EmployeeChartData[PrevSibling.Attributes["EmployeeID"].Value].EmployeePos.X + _BoxWidth + _HorizontalSpace;

                }
            }
            return Result;
        }

        private int GetXPosByOwnChildren(XmlNode CurrentNode)
        {
            int Result = -1;
            if (CurrentNode.HasChildNodes)
            {
                Result = (((EmployeeChartData[CurrentNode.LastChild.Attributes["EmployeeID"].Value].EmployeePos.X + _BoxWidth) -
                    EmployeeChartData[CurrentNode.FirstChild.Attributes["EmployeeID"].Value].EmployeePos.X) / 2) -
                    (_BoxWidth / 2) +
                    EmployeeChartData[CurrentNode.FirstChild.Attributes["EmployeeID"].Value].EmployeePos.X;

            }
            return Result;
        }
        private int GetXPosByParentPreviousSibling(XmlNode CurrentNode)
        {
            int Result = -1;
            XmlNode ParentPrevSibling = CurrentNode.ParentNode.PreviousSibling;
            if (ParentPrevSibling != null)
            {
                if (ParentPrevSibling.HasChildNodes)
                {
                    Result = EmployeeChartData[ParentPrevSibling.LastChild.Attributes["EmployeeID"].Value].EmployeePos.X + _BoxWidth + _HorizontalSpace;
                }
                else
                {
                    Result = EmployeeChartData[ParentPrevSibling.Attributes["EmployeeID"].Value].EmployeePos.X + _BoxWidth + _HorizontalSpace;
                }
            }
            else //ParentPrevSibling == null
            {
                if (CurrentNode.ParentNode.Name != "RootNode" && CurrentNode.ParentNode.Name != "#document")
                {
                    Result = GetXPosByParentPreviousSibling(CurrentNode.ParentNode);
                }
            }
            return Result;
        }
                                 

        /// <summary>
        /// Draws the actual chart image.
        /// </summary>
        private void DrawChart(XmlNode oNode)
        {
            // Create font and brush.
            Font drawFont = new Font("verdana", _FontSize);
            SolidBrush drawBrush = new SolidBrush(_FontColor);
            Pen boxPen = new Pen(_LineColor, _LineWidth);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            foreach (OrgData.OrgDetailsRow EmployeeRow in dtOrg.Select(string.Format("BossEmployeeID='{0}'", oNode.Attributes["EmployeeID"].Value)))
            {
                DrawChart(oNode.SelectSingleNode(string.Format("Node[@EmployeeID='{0}']", EmployeeRow.EmployeeID)));
            }
            gr.DrawRectangle(boxPen, EmployeeChartData[oNode.Attributes["EmployeeID"].Value].EmployeePos);
            gr.FillRectangle(new SolidBrush(_BoxFillColor), EmployeeChartData[oNode.Attributes["EmployeeID"].Value].EmployeePos);
            //// Create string to draw.
            String drawString = EmployeeChartData[oNode.Attributes["EmployeeID"].Value].EmployeeData.EmployeeID +
                Environment.NewLine +
                EmployeeChartData[oNode.Attributes["EmployeeID"].Value].EmployeeData.EmployeeTitle;
            //String drawString = EmployeeChartData[OrgCharMatrix[x, y]].EmployeePos.X.ToString();
            // Draw string to screen.
            gr.DrawString(drawString, drawFont, drawBrush, EmployeeChartData[oNode.Attributes["EmployeeID"].Value].EmployeePos, drawFormat);

            //draw connecting lines

            if (oNode.Name!="RootNode" )
            {
                //all but the top box should have lines growing out of their top
                gr.DrawLine(boxPen, EmployeeChartData[oNode.Attributes["EmployeeID"].Value].EmployeePos.Left + (_BoxWidth / 2),
                                            EmployeeChartData[oNode.Attributes["EmployeeID"].Value].EmployeePos.Top,
                                            EmployeeChartData[oNode.Attributes["EmployeeID"].Value].EmployeePos.Left + (_BoxWidth / 2),
                                            EmployeeChartData[oNode.Attributes["EmployeeID"].Value].EmployeePos.Top - (_VerticalSpace / 2));
            }
            if (oNode.HasChildNodes )
            {
                //all employees which have employees should have lines coming from bottom down
                gr.DrawLine(boxPen, EmployeeChartData[oNode.Attributes["EmployeeID"].Value].EmployeePos.Left + (_BoxWidth / 2),
                                    EmployeeChartData[oNode.Attributes["EmployeeID"].Value].EmployeePos.Top + _BoxHeight,
                                    EmployeeChartData[oNode.Attributes["EmployeeID"].Value].EmployeePos.Left + (_BoxWidth / 2),
                                    EmployeeChartData[oNode.Attributes["EmployeeID"].Value].EmployeePos.Top + _BoxHeight + (_VerticalSpace / 2));

            }
            if (oNode.PreviousSibling != null)
            {
                //the prev employee has the same boss - connect the 2 employees
                gr.DrawLine(boxPen, EmployeeChartData[oNode.PreviousSibling.Attributes["EmployeeID"].Value].EmployeePos.Left + (_BoxWidth / 2) - (_LineWidth / 2),
                                    EmployeeChartData[oNode.PreviousSibling.Attributes["EmployeeID"].Value].EmployeePos.Top - (_VerticalSpace / 2),
                                    EmployeeChartData[oNode.Attributes["EmployeeID"].Value].EmployeePos.Left + (_BoxWidth / 2) + (_LineWidth / 2),
                                    EmployeeChartData[oNode.Attributes["EmployeeID"].Value].EmployeePos.Top - (_VerticalSpace / 2));
            
            
            }



        }
                                           
        private void CalculateImageMapData(double ActualWidth, double ActualHeight)
        {
            double PercentageChangeX = ActualWidth / imgWidth;
            double PercentageChangeY = ActualHeight / imgHeight;
            foreach (OrgChartRecord EP in EmployeeChartData.Values)
            {

                Rectangle ResizedRectangle = new Rectangle(
                    (int)(EP.EmployeePos.X * PercentageChangeX),
                    (int)(EP.EmployeePos.Y * PercentageChangeY),
                    (int)(BoxWidth * PercentageChangeX),
                    (int)(BoxHeight * PercentageChangeY));
                EP.EmployeePos = ResizedRectangle;

            }
        }

    }
}
