using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using gregn6Lib;

namespace LRBarcodeApplication
{
    public partial class GridReportForm : Form
    {
        public DataTable printtable = new DataTable();
        public string reportname = "";
        private GridppReport Report = new GridppReport();
        public bool ptintview =true;
        public GridReportForm()
        {
            InitializeComponent();
        }

        public void GridReportForm_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath.ToLower();//获取启动了应用程序的可执行文件的路径，不包括可执行文件的名称
            string FileName = path + "\\" + reportname;
            try { Report.LoadFromFile(FileName); }
            catch { }
            try { Report.DetailGrid.Recordset.ConnectionString = ""; }
            catch { }

            //连接报表事件
            Report.ProcessBegin += new _IGridppReportEvents_ProcessBeginEventHandler(FillRecordToReport);

            if (ptintview)
            {
                try { axGRPrintViewer1.Report = Report; }
                catch { }
                //启动报表运行
                try { axGRPrintViewer1.Start(); }
                catch { }
            }
            else { Report.Print(false); }//无预览，直接打印
        }

        private struct MatchFieldPairType
        {
            public IGRField grField;
            public int MatchColumnIndex;
        }
        // 将 DataTable 的数据转储到 Grid++Report 的数据集中
        public  void FillRecordToReport()
        {
            try
            {
                MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, printtable.Columns.Count)];

                #region //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
                int MatchFieldCount = 0;
                for (int i = 0; i < printtable.Columns.Count; ++i)
                {
                    foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
                    {
                        if (String.Compare(fld.Name, printtable.Columns[i].ColumnName, true) == 0)
                        {
                            MatchFieldPairs[MatchFieldCount].grField = fld;
                            MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                            ++MatchFieldCount;
                            break;
                        }
                    }
                }
                #endregion

                #region // 将 DataTable 中的每一条记录转储到 Grid++Report 的数据集中去
                IGRRecordset Recordset = Report.DetailGrid.Recordset;//数据集
                foreach (DataRow dr in printtable.Rows)
                {
                    try { Recordset.Append(); }
                    catch { }

                    for (int i = 0; i < MatchFieldCount; ++i)
                    {
                        if (!dr.IsNull(MatchFieldPairs[i].MatchColumnIndex))
                            MatchFieldPairs[i].grField.Value = dr[MatchFieldPairs[i].MatchColumnIndex];
                    }

                    try { Recordset.Post(); }
                    catch { }
                }
                #endregion
            }
            catch { }
        }

    }
}
