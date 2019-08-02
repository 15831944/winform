using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace LRBarcodeApplication
{
    public partial class MCS_ReportForm : Form
    {
        public DataTable printtable = new DataTable("dtScan");
        string Barcode = "";
        public MCS_ReportForm()
        {
            InitializeComponent();
        }
        System.Drawing.Image printImage;
        
        private void MCS_ReportForm_Load(object sender, EventArgs e)
        {
            if (use_printView_x == 1) { printView1(); }
            else
            { printView(); }
            
        }
        private void sctm(string text)//生成条码
        {
            try
            {
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();//实例化程序集对象
                //int iW = 280;//定义一张条码的宽度
                //int iH = 30;//定义一张条码的高度
                //UNSPECIFIED在引用的程序集里是未定义的编码类型的意思
                BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
                #region//选择编码类型
                string CodeType = "Code 128";
                switch (CodeType)
                {
                    case "UPC-A": type = BarcodeLib.TYPE.UPCA; break;
                    case "UPC-E": type = BarcodeLib.TYPE.UPCE; break;
                    case "UPC 2 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT; break;
                    case "UPC 5 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT; break;
                    case "EAN-13": type = BarcodeLib.TYPE.EAN13; break;
                    case "JAN-13": type = BarcodeLib.TYPE.JAN13; break;
                    case "EAN-8": type = BarcodeLib.TYPE.EAN8; break;
                    case "ITF-14": type = BarcodeLib.TYPE.ITF14; break;
                    case "Codabar": type = BarcodeLib.TYPE.Codabar; break;
                    case "PostNet": type = BarcodeLib.TYPE.PostNet; break;
                    case "Bookland/ISBN": type = BarcodeLib.TYPE.BOOKLAND; break;
                    case "Code 11": type = BarcodeLib.TYPE.CODE11; break;
                    case "Code 39": type = BarcodeLib.TYPE.CODE39; break;
                    case "Code 39 Extended": type = BarcodeLib.TYPE.CODE39Extended; break;
                    case "Code 93": type = BarcodeLib.TYPE.CODE93; break;
                    case "LOGMARS": type = BarcodeLib.TYPE.LOGMARS; break;
                    case "MSI": type = BarcodeLib.TYPE.MSI_Mod10; break;
                    case "Interleaved 2 of 5": type = BarcodeLib.TYPE.Interleaved2of5; break;
                    case "Standard 2 of 5": type = BarcodeLib.TYPE.Standard2of5; break;
                    case "Code 128": type = BarcodeLib.TYPE.CODE128; break;
                    case "Code 128-A": type = BarcodeLib.TYPE.CODE128A; break;
                    case "Code 128-B": type = BarcodeLib.TYPE.CODE128B; break;
                    case "Code 128-C": type = BarcodeLib.TYPE.CODE128C; break;
                    default: return;
                }
                #endregion
                b.IncludeLabel = false;// this.checkBox1.Checked;//是否打印条码数据在下方
                //BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE128;

                //Bitmap1 = new Bitmap(iW, iH);
                //Graphics g = Graphics.FromImage(Bitmap1);
                //g.Clear(Color.White);
                printImage = b.Encode(type, text.Trim(), b.ForeColor, b.BackColor, iW, iH);//生成图片
                //g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                //int il = 0;//左位置
                //int it = 0;//顶空白
                //g.DrawImage(printImage, il, it, int.Parse(((int)iW).ToString()), int.Parse(((int)iH).ToString()));//将图片放置到图片框
                //this.pictureBox1.Image = (Image)Bitmap1;
            }
            catch
            {

            }

        }
        private byte[] BitmapToBytes(Bitmap Bitmap)//图片转换成二进制数据，以传用报表
        {
            MemoryStream ms = null;
            try
            {
                ms = new MemoryStream();
                // Bitmap.Save(ms, ImageFormat.Gif);
                Bitmap.Save(ms, ImageFormat.Jpeg);
                byte[] byteImage = new Byte[ms.Length];
                byteImage = ms.ToArray();
                return byteImage;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            finally
            {
                ms.Close();
            }
        }
        public int use_printView_x = 1;//使用方法名
        public int iW = 280;//定义一张条码的宽度
        public int iH = 30;//定义一张条码的高度
        //图形页面设置
        public string PageWidth = "6cm";//宽
        public string PageHeight = "2cm";//高
        public string MarginTop = "0cm";//上边距
        public string MarginLeft = "0cm";//左边距
        public string MarginRight = "0cm";//右边距
        public string MarginBottom = "0cm";//下边距 
        public string reportname = "Report1.rdlc";

        private void printView()
        {
            try
            {
                foreach (DataRow row in printtable.Rows)
                {
                    try { Barcode = row["cBarcode"].ToString(); }
                    catch { Barcode = ""; }
                    try
                    {
                        sctm(Barcode);//生成条码
                    }
                    catch { }
                    try
                    {
                        row["Barcode"] = BitmapToBytes((Bitmap)printImage);//一维码
                    }
                    catch { }
                }
                try
                {
                    try { reportViewer1.LocalReport.DataSources.Clear(); }
                    catch { }
                    try {  reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", printtable));}
                    catch { }
                    //为报表浏览器指定报表文件
                    //string reportName = "MCS_Scan.Report." + reportname;
                    //reportViewer1.LocalReport.ReportEmbeddedResource = reportName;//使用类中的报表
                    try {  reportViewer1.LocalReport.ReportPath = reportname;}
                    catch { }//使用文件夹中的报表
                    try {  reportViewer1.LocalReport.Refresh();}
                    catch { }
                    try { reportViewer1.RefreshReport(); }
                    catch { }
                }
                catch { }
                try
                {
                    //// 直接打印
                    //SYSVARS.Demo.dtStu = printtable;
                    //SYSVARS.Demo.reportname = reportname;
                    //SYSVARS.Demo.PageWidth = PageWidth;
                    //SYSVARS.Demo.PageHeight = PageHeight;
                    //SYSVARS.Demo.MarginTop = MarginTop;
                    //SYSVARS.Demo.MarginLeft = MarginLeft;
                    //SYSVARS.Demo.MarginRight = MarginRight;
                    //SYSVARS.Demo.MarginBottom = MarginBottom;
                    //SYSVARS.Demo.Main();
                    //timer1.Enabled = true;
                }
                catch { }
            }
            catch { }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
        }
        private void printView1()
        {
            try
            {
                //foreach (DataRow row in printtable.Rows)
                //{
                //    try { Barcode = row["cBarcode"].ToString(); }
                //    catch { Barcode = ""; }
                //    try
                //    {
                //        sctm(Barcode);//生成条码
                //    }
                //    catch { }
                //    try
                //    {
                //        row["Barcode"] = BitmapToBytes((Bitmap)printImage);//一维码
                //    }
                //    catch { }
                //}
                try
                {
                    try { reportViewer1.LocalReport.DataSources.Clear(); }
                    catch { }
                    try { reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", printtable)); }
                    catch { }
                    //为报表浏览器指定报表文件
                    //string reportName = "MCS_Scan.Report." + reportname;
                    //reportViewer1.LocalReport.ReportEmbeddedResource = reportName;//使用类中的报表
                    try { reportViewer1.LocalReport.ReportPath = reportname; }
                    catch { }//使用文件夹中的报表
                    try { reportViewer1.LocalReport.Refresh(); }
                    catch { }
                    try { reportViewer1.RefreshReport(); }
                    catch { }
                }
                catch { }
                try
                {
                    //// 直接打印
                    //SYSVARS.Demo.dtStu = printtable;
                    //SYSVARS.Demo.reportname = reportname;
                    //SYSVARS.Demo.PageWidth = PageWidth;
                    //SYSVARS.Demo.PageHeight = PageHeight;
                    //SYSVARS.Demo.MarginTop = MarginTop;
                    //SYSVARS.Demo.MarginLeft = MarginLeft;
                    //SYSVARS.Demo.MarginRight = MarginRight;
                    //SYSVARS.Demo.MarginBottom = MarginBottom;
                    //SYSVARS.Demo.Main();
                    //timer1.Enabled = true;
                }
                catch { }
            }
            catch { }
        }

    }
}
