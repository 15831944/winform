using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LRLibrary;
using System.Reflection;
using System.Data.SqlClient;
using System.Windows.Forms.VisualStyles;
namespace LRBarcodeApplication
{




    public partial class MainForm : Form
    {
        DataSet d = new DataSet();
        DataTable ds = new DataTable();//显示未打印
        DataTable dsm = new DataTable();//显示条码
        DataTable d1 = new DataTable();
        DataTable d2 = new DataTable();//破损条码
        DataTable d3 = new DataTable(); //现有条码
        DataTable d4 = new DataTable(); //分包后的条码
        DataTable d5 = new DataTable(); //出货表显示
        DataTable d6 = new DataTable(); //出货表显示
        DataTable tmxs = new DataTable(); //条码显示
        public DataTable printtable = new DataTable("dtProdBarcodeMData");
        string ReportName = "cktm.grf";//ReportName打印模板名称
        string sjc1 = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();//获取时间戳
      SqlConnection sqlcon = DBLibrary.getConn("119.23.174.4", "LR", "lr", "lr123456");
        //SqlConnection sqlcon = DBLibrary.getConn("192.168.0.150", "HSLR", "sa", "abc@123");//正式服务器

        // select 生产计划唯一ID,	max(b.顾客ID) as  客户编码 , max(顾客全称 )as 客户名称, max(PDM代号) as 内部物料编码, max(b.PDM名称) as 内部物料名称,max(PDM状态描述)as 内部物料描述 ,max(顾客物料编号) as 客户物料编码,max(顾客物料名称) as 客户物料名称,max(顾客状态描述) as 客户物物料描述,max(包装数量) as 包装数量,max(单位) as 计量单位,max(计划数) as 计划数,max(c.规格型号) as 规格型号,max(c.生产日期) as 生产日期,max(c.送货日期) as 送货日期, max(case 打印状态  when 0 then '未打印' when 0 then '已打印'   end) as 打印状态  from H016C生产计划_产品明细 a  left  join H402包装信息登记表_主表 b  on a.客户名称=b.顾客全称  and a.PDM代号=b.PDM编码 left join 标签_主表 c on  b.顾客物料编号=c.物料编码    where 打印状态=0 group by 生产计划唯一ID 


        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp(System.DateTime time)
        {
            long ts = ConvertDateTimeToInt(time);
            return ts.ToString();
        }
        /// <summary>  
        /// 将c# DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>long</returns>  
        public static long ConvertDateTimeToInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (time.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
            return t;
        }



        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

            //dgv_unprintlist 未打印计划清单view


            string sql = String.Format(@"select 生产计划唯一ID as 计划编号,	max(b.顾客ID) as  客户编码 , max(客户名称 )as 客户名称, 
                max(PDM代号) as 内部物料编码, max(a.PDM名称) as 内部物料名称,max(状态描述)as 内部物料描述 ,max(客户物料号) as  
                客户物料编码,max(顾客物料名称) as 客户物料名称,max(客户物料描述) as 客户物料描述,max(包装数量) as 包装数量,max(单位) as 计量单位, 
                max(计划数) as 计划数,max(c.规格型号) as 规格型号,max(a.生产日期) as 生产日期,max(a.送货日期) as 送货日期, max(case 打印状态  
                 when 0 then '未打印' when 1 then '已打印'   end) as 打印状态 , max(单位明名称) as 单位名称,max(装备计划组别) as 组别 from H016C生产计划_产品明细 a  
                left  join H402包装信息登记表_主表 b  on a.顾客ID=b.顾客ID  and a.PDM代号=b.PDM编码 and a.客户物料号=b.顾客物料编号 left join 标签_主表 c on  客户物料号=c.物料编码   
                 where 打印状态=0 and 包装数量 is not null and  包装数量 <>0 and 计划数 is not null  group by 生产计划唯一ID  order by 生产计划唯一ID desc");

            ds = DBLibrary.GetData(sql, sqlcon);


            dgv_unprintlist.DataSource = ds;
            #region 隐藏
            dgv_unprintlist.Columns["客户编码"].Visible = false;
            dgv_unprintlist.Columns["内部物料描述"].Visible = false;
            dgv_unprintlist.Columns["内部物料编码"].Visible = false;
            dgv_unprintlist.Columns["内部物料名称"].Visible = false;
            dgv_unprintlist.Columns["客户物料描述"].Visible = false;
            dgv_unprintlist.Columns["计量单位"].Visible = false;
            dgv_unprintlist.Columns["打印状态"].Visible = false;
            dgv_unprintlist.Columns["单位名称"].Visible = false;
            dgv_unprintlist.Columns["组别"].Visible = false;
            #endregion
            dgv_unprintlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//填充布局

            AddCheckBoxToDataGridView.dgv = dgv_unprintlist;
            AddCheckBoxToDataGridView.AddFullSelect();

        }


        private void btn_se_Click(object sender, EventArgs e)//分包打印(查找)
        {
            //dgv_exismsglist  条码现有信息views




            string tm = txt_xytm.Text.Trim();
            string sql = String.Format("select 条码,数据来源,组别,计划编号,客户编码,客户名称,客户物料编码  as 物料编码,客户物料名称 as 物料名称, 内部物料描述,内部物料编码," +
                "内部物料名称,客户物料描述,计量单位,b.数量 ,b.规格型号,b.生产日期,b.送货日期  from 条码信息表_主表 b left join 标签_主表 a  " +
            "on a.物料编码=b.内部物料编码  where 条码 like '%" + tm + "%' or 计划编号  like '%" + tm + "%' or 客户名称  like '%" + tm + "%'  or 客户物料编码  like '%" + tm + "%'");

            d3 = DBLibrary.GetData(sql, sqlcon);
            if (d3.Rows.Count <= 0)
            {

                MessageBox.Show("该条码不存在，请重新选择！");
                return;
            }

            //if (d3.Rows[0]["数据来源"].ToString() == "分包")
            //{
            //    MessageBox.Show("该条码已经分包，请重新选择！");
            //    return;
            //}

            dgv_exismsglist.DataSource = d3;

            #region  隐藏
            dgv_exismsglist.Columns["客户编码"].Visible = false;
            dgv_exismsglist.Columns["客户物料描述"].Visible = false;
            dgv_exismsglist.Columns["内部物料编码"].Visible = false;
            dgv_exismsglist.Columns["内部物料名称"].Visible = false;
            dgv_exismsglist.Columns["计量单位"].Visible = false;
            dgv_exismsglist.Columns["内部物料描述"].Visible = false;
            //dgv_exismsglist.Columns["计划编号"].Visible = false;
            dgv_exismsglist.Columns["组别"].Visible = false;
            dgv_exismsglist.Columns["数据来源"].Visible = false;
            #endregion


            dgv_exismsglist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//填充布局
            //AddCheckBoxToDataGridView.dgv = dgv_exismsglist;
            //AddCheckBoxToDataGridView.AddFullSelect();

        }

        private void btn_barcode_Click(object sender, EventArgs e)//按计划打印生成清单
        {
            //dgv_barcodelist 条码清单view
            try
            {
                #region 条码显示
                string date = DateTime.Now.ToString("yyyyMMdd");
                string sql1 = String.Format("select 条码,组别,数据来源,计划编号,客户编码,客户名称,客户物料编码  as 物料编码,客户物料名称 as 物料名称, " +
                    "内部物料描述,内部物料编码,内部物料名称,客户物料描述,计量单位,b.数量 ,b.规格型号,b.生产日期,b.送货日期,'' as 新增标识  from " +
                "条码信息表_主表 b left join 标签_主表 a on a.物料编码=b.内部物料编码 where 1=2");

                // select 生产计划唯一ID,	max(b.顾客ID) as  客户编码 , max(顾客全称 )as 客户名称, max(PDM代号) as 内部物料编码, max(b.PDM名称) as 内部物料名称,max(PDM状态描述)as 内部物料描述 ,max(顾客物料编号) as 客户物料编码,max(顾客物料名称) as 客户物料名称,max(顾客状态描述) as 客户物料描述,max(包装数量) as 包装数量,max(单位) as 计量单位,max(计划数) as 计划数,max(c.规格型号) as 规格型号,max(c.生产日期) as 生产日期,max(c.送货日期) as 送货日期, max(case 打印状态  when 0 then '未打印' when 0 then '已打印'   end) as 打印状态  from H016C生产计划_产品明细 a  left  join H402包装信息登记表_主表 b  on a.客户名称=b.顾客全称  and a.PDM代号=b.PDM编码 left join 标签_主表 c on  b.顾客物料编号=c.物料编码    where 打印状态=0 group by 生产计划唯一ID 

                dsm = DBLibrary.GetData(sql1, sqlcon);
      
                d1 = dsm.Clone();
                string sjc = GetTimeStamp(DateTime.Now);
                int xuhao = 1;
              
                int count = 0;  //用于保存选中的checkbox数量 
                string updatejhbhlist = "";
                for (int i = 0; i < dgv_unprintlist.RowCount; i++)
                {


                    if (dgv_unprintlist.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                    //这里判断复选框是否选中 
                    {

                        #region 已存入的条码显示



                        if (ds.Rows[i]["包装数量"] == null || ds.Rows[i]["包装数量"].ToString() == "" || Convert.ToInt32(ds.Rows[i]["包装数量"]) == 0)
                        {
                            MessageBox.Show("包装数量不能为0，请重新选择！");
                            return;
                        }



                        string sqlcx = @"select 条码,组别,数据来源,计划编号,客户编码,客户名称,客户物料编码  as 物料编码,客户物料名称 as 物料名称, " +
                    "内部物料描述,内部物料编码,内部物料名称,客户物料描述,计量单位,b.数量 ,b.规格型号,b.生产日期,b.送货日期,'' as 新增标识  from " +
                "条码信息表_主表 b left join 标签_主表 a on a.物料编码=b.内部物料编码 where 计划编号='" + ds.Rows[i]["计划编号"].ToString() + "'";
                        DataTable di = DBLibrary.GetData(sqlcx, sqlcon);//获取现有条码信息

                        if (di.Rows.Count > 0)
                        {
                            MessageBox.Show(ds.Rows[i]["计划编号"].ToString()+"该计划已存入条码表中！如不想显示此消息，请点击刷新按钮！");

                            foreach (DataRow dr in di.Rows)
                            {
                                d1.ImportRow(dr);
                            }
                            count++;
                        }
                        #endregion
                        else
                        {
                            updatejhbhlist = updatejhbhlist + "'" + ds.Rows[i]["计划编号"] + "',";
                            //dsm.Rows.Add(ds.Rows[i].ItemArray);
                            //数据填充
                            int jhs = Convert.ToInt32(ds.Rows[i]["计划数"]);//计划数量
                            int bzs = Convert.ToInt32(ds.Rows[i]["包装数量"]);//包装数量
                            int shang = jhs / bzs;
                            int yushu = jhs % bzs;

                            for (int j = 0; j < shang; j++)
                            {
                                DataRow dr = d1.NewRow();

                                dr["条码"] = sjc + "-" + xuhao;//条码
                                dr["物料编码"] = ds.Rows[i]["客户物料编码"];
                                dr["物料名称"] = ds.Rows[i]["客户物料名称"];
                                dr["数量"] = bzs;//数量
                                dr["计划编号"] = ds.Rows[i]["计划编号"];
                                #region 隐藏
                                dr["组别"] = ds.Rows[i]["组别"];

                                dr["客户编码"] = ds.Rows[i]["客户编码"];
                                dr["内部物料描述"] = ds.Rows[i]["内部物料描述"];
                                dr["内部物料编码"] = ds.Rows[i]["内部物料编码"];
                                dr["内部物料名称"] = ds.Rows[i]["内部物料名称"];
                                dr["计量单位"] = ds.Rows[i]["计量单位"];
                                dr["客户物料描述"] = ds.Rows[i]["客户物料描述"];
                                dr["数据来源"] = "按计划";
                                #endregion


                                //dgv_unprintlist.Columns["客户编码"].Visible = false;
                                //dgv_unprintlist.Columns["内部物料描述"].Visible = false;
                                //dgv_unprintlist.Columns["客户物料编码"].Visible = false;
                                //dgv_unprintlist.Columns["客户物料名称"].Visible = false;
                                //dgv_unprintlist.Columns[""].Visible = false;
                                //dgv_unprintlist.Columns["计量单位"].Visible = false;
                                //dgv_unprintlist.Columns["打印状态"].Visible = false;
                                dr["客户名称"] = ds.Rows[i]["客户名称"];
                                dr["规格型号"] = ds.Rows[i]["规格型号"];
                                dr["生产日期"] = ds.Rows[i]["生产日期"];
                                dr["送货日期"] = ds.Rows[i]["送货日期"];
                                dr["新增标识"] = "1";
                                d1.Rows.Add(dr);
                                xuhao = xuhao + 1;
                                //foreach (DataRow dh in tmxs.Rows)
                                //{
                                //    if (d1.Rows[0]["条码"].ToString() == dh["条码"].ToString())
                                //    {
                                //        MessageBox.Show("该信息已经存入条码表中,请重新选择");

                                //        return;

                                //    }
                                //}

                            }
                            if (yushu > 0)
                            {

                                DataRow dr = d1.NewRow();

                                dr["条码"] = sjc + "-" + xuhao;//条码
                                dr["物料编码"] = ds.Rows[i]["客户物料编码"];
                                dr["物料名称"] = ds.Rows[i]["客户物料名称"];
                                dr["数量"] = yushu;//数量
                                dr["计划编号"] = ds.Rows[i]["计划编号"];
                                #region 隐藏

                                dr["组别"] = ds.Rows[i]["组别"];
                                dr["客户编码"] = ds.Rows[i]["客户编码"];
                                dr["内部物料描述"] = ds.Rows[i]["内部物料描述"];
                                dr["内部物料编码"] = ds.Rows[i]["内部物料编码"];
                                dr["计量单位"] = ds.Rows[i]["计量单位"];
                                dr["客户物料描述"] = ds.Rows[i]["客户物料描述"];
                                dr["数据来源"] = "按计划";
                                #endregion

                                dr["客户名称"] = ds.Rows[i]["客户名称"];
                                dr["规格型号"] = ds.Rows[i]["规格型号"];
                                dr["生产日期"] = ds.Rows[i]["生产日期"];
                                dr["送货日期"] = ds.Rows[i]["送货日期"];
                                dr["新增标识"] = "1";
                                d1.Rows.Add(dr);
                                xuhao = xuhao + 1;
                                //foreach (DataRow dh in tmxs.Rows)
                                //{
                                //    if (d1.Rows[0]["条码"].ToString() == dh["条码"].ToString())
                                //    {
                                //        MessageBox.Show("该信息已经存入条码表中,请重新选择");
                                //        return;

                                //    }
                                //}
                            }
                            count++;



                        }
                    }
                  
                }
                if (count == 0)
                {
                    MessageBox.Show("请至少选择一条数据！", "提示");
                    return;
                }
                else
                {
                    if (MessageBox.Show(this, "您要更新数据么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString() == "Yes")
                    {
                        while (this.dgv_barcodelist.Rows.Count != 0)
                        {
                            this.dgv_barcodelist.Rows.RemoveAt(0);
                        }

                        for (int i = 0; i < count; i++)
                        {

                            dgv_barcodelist.DataSource = d1;


                            #region  隐藏
                            dgv_barcodelist.Columns["客户编码"].Visible = false;
                            dgv_barcodelist.Columns["内部物料描述"].Visible = false;
                            dgv_barcodelist.Columns["内部物料编码"].Visible = false;
                            dgv_barcodelist.Columns["内部物料名称"].Visible = false;
                            dgv_barcodelist.Columns["计量单位"].Visible = false;
                            dgv_barcodelist.Columns["客户物料描述"].Visible = false;
                            dgv_barcodelist.Columns["新增标识"].Visible = false;
                            dgv_barcodelist.Columns["组别"].Visible = false;
                            dgv_barcodelist.Columns["数据来源"].Visible = false;

                            #endregion
                           

                        }
                        AddCheckBoxToDataGridView1.dgv = dgv_barcodelist;
                        AddCheckBoxToDataGridView1.AddFullSelect();
                    }
                    else
                    {
                        return;
                    }
                }
                #endregion


                #region 条码保存
                string dydate = DateTime.Now.ToString();//打印时间

                for (int i = 0; i < dgv_barcodelist.Rows.Count; i++)
                {
                    if (dgv_barcodelist.Rows[i].Cells["新增标识"].Value.ToString().Equals("1"))
                    {
                        string tm = dgv_barcodelist.Rows[i].Cells["条码"].EditedFormattedValue.ToString();//条码
                        string wlbm = dgv_barcodelist.Rows[i].Cells["物料编码"].EditedFormattedValue.ToString();//物料编码
                        string wlmc = dgv_barcodelist.Rows[i].Cells["物料名称"].EditedFormattedValue.ToString();//物料名称
                        string bzsl = dgv_barcodelist.Rows[i].Cells["数量"].EditedFormattedValue.ToString();//包装数量
                        string khmc = dgv_barcodelist.Rows[i].Cells["客户名称"].EditedFormattedValue.ToString();//客户名称
                        string ggxh = dgv_barcodelist.Rows[i].Cells["规格型号"].EditedFormattedValue.ToString();//规格型号
                        string scrq = dgv_barcodelist.Rows[i].Cells["生产日期"].EditedFormattedValue.ToString();//生产日期
                        string shrq = dgv_barcodelist.Rows[i].Cells["送货日期"].EditedFormattedValue.ToString();//送货日期
                        string dysj = dydate;

                        //隐藏项保存
                        string khbm = dgv_barcodelist.Rows[i].Cells["客户编码"].EditedFormattedValue.ToString();//客户编码
                        string khwlms = dgv_barcodelist.Rows[i].Cells["客户物料描述"].EditedFormattedValue.ToString();//客户物料描述
                        string khwlbm = dgv_barcodelist.Rows[i].Cells["内部物料编码"].EditedFormattedValue.ToString();//客户物料编码
                        string jldw = dgv_barcodelist.Rows[i].Cells["计量单位"].EditedFormattedValue.ToString();//计量单位
                        string khwlmc = dgv_barcodelist.Rows[i].Cells["内部物料名称"].EditedFormattedValue.ToString();//客户物料名称
                        string nbwlms = dgv_barcodelist.Rows[i].Cells["内部物料描述"].EditedFormattedValue.ToString();//内部物料描述
                        string jhbh = dgv_barcodelist.Rows[i].Cells["计划编号"].EditedFormattedValue.ToString();//计划编号
                        string zb = dgv_barcodelist.Rows[i].Cells["组别"].EditedFormattedValue.ToString();//计划编号
                        string sjly = dgv_barcodelist.Rows[i].Cells["数据来源"].EditedFormattedValue.ToString();//数据来源
                        //条码，客户名称，客户编码，内部物料描述，内部物料编码，内部物料名称，客户物料编码，客户物料名称，客户物料描述，数量，计量单位
                        //生产日期，送货日期，条码打印时间，重新打印时间，入库时间，出货计划编号
                        string sql = "insert into 条码信息表_主表(条码,客户名称,客户物料编码,客户物料名称,数量,生产日期,送货日期,条码打印时间,客户编码,客户物料描述,内部物料编码,计量单位,内部物料名称,内部物料描述,规格型号,计划编号,组别,数据来源) values ('" + tm + "', '" + khmc + "','" + wlbm + "','" + wlmc + "','" + bzsl + "','" + scrq + "','" + shrq + "','" + dysj + "','" + khbm + "','" + khwlms + "','" + khwlbm + "','" + jldw + "','" + khwlmc + "','" + nbwlms + "','" + ggxh + "','" + jhbh + "','" + zb + "','" + sjly + "') ";
                        DBLibrary.UpdateData(sql, sqlcon);                        
                    }
                }

                if (updatejhbhlist.Length > 0)
                {
                    string gx = "update  H016C生产计划_产品明细 set 打印状态=1 where 生产计划唯一ID in (" + updatejhbhlist.TrimEnd(',') + ") ";
                    DBLibrary.UpdateData(gx, sqlcon);
                }


                #endregion



            }
            catch (SqlException ee)
            {
                MessageBox.Show(ee.Message);
            }


        }

        private void btn_print_Click(object sender, EventArgs e)//按计划打印(打印)
        {
            try
            {


                DataTable dyxs = new DataTable();
                string sql4 = String.Format("select 条码,组别,数据来源,计划编号,客户编码,客户名称,客户物料编码  as 物料编码,客户物料名称 as 物料名称, " +
                    "内部物料描述,内部物料编码,内部物料名称,客户物料描述,计量单位,b.数量 ,b.规格型号,b.生产日期,b.送货日期 , ''as 新增标识 from " +
                "条码信息表_主表 b left join 标签_主表 a on a.物料编码=b.内部物料编码 where 1=2  ");

                d3 = DBLibrary.GetData(sql4, sqlcon);

                dsm = d3.Clone();

                //  int count = 0;  //用于保存选中的checkbox数量 
                for (int i = 0; i < dgv_barcodelist.RowCount; i++)
                {
                    if (dgv_barcodelist.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                    //这里判断复选框是否选中 
                    {
                        dsm.Rows.Add(d1.Rows[i].ItemArray);//获取条码数据

                    }
                }

                DataRow[] rows = dsm.Select();
                if (rows.Length < 1) { MessageBox.Show("请选择要打印的行", "提示："); return; }
                printtable.Clear();
                printtable = rows.CopyToDataTable();//  获取数据源数据
                if (printtable.Rows.Count < 1 || printtable.Columns.Count < 2) { MessageBox.Show("数据源中没有数据", "提示："); return; }

                #region //打印条码
                try
                {
                    ReportName = "cktm.grf";
                    if (d1.Rows[0]["客户编码"].ToString() == "GK005")
                    {
                        ReportName = "cktmdj.grf";
                    }

                    GridReportForm BForm = new GridReportForm();
                    BForm.printtable = printtable;
                    BForm.reportname = ReportName;
                    for (int i = 0; i < printtable.Rows.Count; i++)
                    {
                        string jhbm = printtable.Rows[0]["计划编号"].ToString();
                        string sql = string.Format("update  H016C生产计划_产品明细  set 打印状态=1 where 生产计划唯一ID='" + jhbm + "'");
                        DBLibrary.UpdateData(sql, sqlcon);
                    }
                    BForm.ShowDialog();


                    dsm.Clear();

                }
                catch { }
                #endregion

            }
            catch { }

        }

        private void btn_refresh_Click(object sender, EventArgs e)//按计划打印刷新
        {
            //dgv_unprintlist 未打印计划清单view


            string sql = String.Format(@"select 生产计划唯一ID as 计划编号,	max(b.顾客ID) as  客户编码 , max(客户名称 )as 客户名称, 
                max(PDM代号) as 内部物料编码, max(a.PDM名称) as 内部物料名称,max(状态描述)as 内部物料描述 ,max(客户物料号) as  
                客户物料编码,max(顾客物料名称) as 客户物料名称,max(客户物料描述) as 客户物料描述,max(包装数量) as 包装数量,max(单位) as 计量单位, 
                max(计划数) as 计划数,max(c.规格型号) as 规格型号,max(a.生产日期) as 生产日期,max(a.送货日期) as 送货日期, max(case 打印状态  
                 when 0 then '未打印' when 1 then '已打印'   end) as 打印状态 , max(单位明名称) as 单位名称,max(装备计划组别) as 组别 from H016C生产计划_产品明细 a  
                left  join H402包装信息登记表_主表 b  on a.顾客ID=b.顾客ID  and a.PDM代号=b.PDM编码 and a.客户物料号=b.顾客物料编号 left join 标签_主表 c on  客户物料号=c.物料编码   
                 where 打印状态=0 and 包装数量 is not null and  包装数量 <>0 and 计划数 is not null  group by 生产计划唯一ID  order by 生产计划唯一ID desc");

            ds = DBLibrary.GetData(sql, sqlcon);
            dgv_unprintlist.DataSource = ds;

            dgv_unprintlist.DataSource = ds;
            #region 不显示项
            dgv_unprintlist.Columns["客户编码"].Visible = false;
            dgv_unprintlist.Columns["内部物料描述"].Visible = false;
            dgv_unprintlist.Columns["内部物料编码"].Visible = false;
            dgv_unprintlist.Columns["内部物料名称"].Visible = false;
            dgv_unprintlist.Columns["客户物料描述"].Visible = false;
            dgv_unprintlist.Columns["计量单位"].Visible = false;
            dgv_unprintlist.Columns["打印状态"].Visible = false;
            dgv_unprintlist.Columns["单位名称"].Visible = false;
            dgv_unprintlist.Columns["组别"].Visible = false;
            #endregion
            dgv_unprintlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//填充布局
            AddCheckBoxToDataGridView.dgv = dgv_unprintlist;
            AddCheckBoxToDataGridView.AddFullSelect();


        }

        private void button1_Click(object sender, EventArgs e)//补打(查找)
        {
            //dgv_brokenlist   补打条码包含信息view

            string tm = txt_tm.Text.Trim();
            string sql = String.Format(@"select 条码,组别,计划编号,客户编码,客户名称,客户物料编码  as 物料编码,客户物料名称 as 物料名称, 内部物料描述,
               内部物料编码,内部物料名称,客户物料描述,计量单位,b.数量 ,b.规格型号,b.生产日期,b.送货日期  from 条码信息表_主表 b left join 
               标签_主表 a on a.物料编码=b.内部物料编码   
            where 条码 like '%" + tm + "%' or 计划编号  like '%" + tm + "%' or 客户名称  like '%" + tm + "%'  or 客户物料编码  like '%" + tm + "%' ");

            d2 = DBLibrary.GetData(sql, sqlcon);

            dgv_brokenlist.DataSource = d2;

            #region  隐藏
            dgv_brokenlist.Columns["客户编码"].Visible = false;
            dgv_brokenlist.Columns["客户物料描述"].Visible = false;
            dgv_brokenlist.Columns["内部物料编码"].Visible = false;
            dgv_brokenlist.Columns["内部物料名称"].Visible = false;
            dgv_brokenlist.Columns["计量单位"].Visible = false;
            dgv_brokenlist.Columns["内部物料描述"].Visible = false;
            //dgv_brokenlist.Columns["计划编号"].Visible = false;
            dgv_brokenlist.Columns["组别"].Visible = false;
            #endregion

            dgv_brokenlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//填充布局
            AddCheckBoxToDataGridView.dgv = dgv_brokenlist;
            AddCheckBoxToDataGridView.AddFullSelect();

        }

        private void btn_pri_Click(object sender, EventArgs e)//补打(打印)
        {
            try
            {

                string sql = String.Format("select 条码,组别,计划编号,客户编码,客户名称,客户物料编码  as 物料编码,客户物料名称 as 物料名称, 内部物料描述,内部物料编码,内部物料名称,客户物料描述,计量单位,b.数量 ,b.规格型号,b.生产日期,b.送货日期  from 条码信息表_主表 b left join 标签_主表 a on a.物料编码=b.内部物料编码");

                d3 = DBLibrary.GetData(sql, sqlcon);

                dsm = d3.Clone();
                //  int count = 0;  //用于保存选中的checkbox数量 
                for (int i = 0; i < dgv_brokenlist.RowCount; i++)
                {
                    if (dgv_brokenlist.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                    //这里判断复选框是否选中 
                    {
                        dsm.Rows.Add(d2.Rows[i].ItemArray);//获取条码数据

                    }
                }

                DataRow[] rows = dsm.Select();
                if (rows.Length < 1) { MessageBox.Show("请选择要打印的行", "提示："); return; }
                printtable.Clear();
                printtable = rows.CopyToDataTable();//  获取数据源数据
                if (printtable.Rows.Count < 1 || printtable.Columns.Count < 2) { MessageBox.Show("数据源中没有数据", "提示："); return; }

                #region //打印条码
                try
                {
                    ReportName = "cktm.grf";
                    if (d2.Rows[0]["客户编码"].ToString() == "GK005")
                    {
                        ReportName = "cktmdj.grf";
                    }
                    GridReportForm BForm = new GridReportForm();
                    BForm.printtable = printtable;
                    BForm.reportname = ReportName;
                    for (int i = 0; i < printtable.Rows.Count; i++)
                    {
                        string jhbm = printtable.Rows[0]["计划编号"].ToString();
                        string sql1 = string.Format("update  H016C生产计划_产品明细  set 打印状态=1 where 生产计划唯一ID='" + jhbm + "'");
                        DBLibrary.UpdateData(sql1, sqlcon);


                    }
                    BForm.ShowDialog();
                    #region 条码更新
                    string cxdydate = DateTime.Now.ToString();//重新打印时间     字段更新 ！！！ 

                    for (int i = 0; i < dsm.Rows.Count; i++)
                    {
                        string tm = dsm.Rows[i]["条码"].ToString();//条码
                        string wlbm = dsm.Rows[i]["物料编码"].ToString();//物料编码
                        string wlmc = dsm.Rows[i]["物料名称"].ToString();//物料名称
                        string bzsl = dsm.Rows[i]["数量"].ToString();//包装数量
                        string khmc = dsm.Rows[i]["客户名称"].ToString();//客户名称
                        string ggxh = dsm.Rows[i]["规格型号"].ToString();//规格型号
                        string scrq = dsm.Rows[i]["生产日期"].ToString();//生产日期
                        string shrq = dsm.Rows[i]["送货日期"].ToString();//送货日期
                        string cxdysj = cxdydate;//重新打印时间



                        //条码，客户名称，客户编码，内部物料描述，内部物料编码，内部物料名称，客户物料编码，客户物料名称，客户物料描述，数量，计量单位
                        //生产日期，送货日期，条码打印时间，重新打印时间，入库时间，出货计划编号
                        string sql1 = "update 条码信息表_主表 set 重新打印时间 ='" + cxdysj + "'  where 条码='" + tm + "'  and  客户物料编码='" + wlbm + "' and 客户物料名称='" + wlmc + "' and  客户名称='" + khmc + "' and  数量='" + bzsl + "' and  生产日期='" + scrq + "' and  送货日期='" + shrq + "' ";
                        DBLibrary.UpdateData(sql1, sqlcon);

                    #endregion


                    }
                    dsm.Clear();

                }

                catch
                {

                }



                #endregion




            }
            catch { }

        }

        private void btn_sub_Click(object sender, EventArgs e)//分包打印(分包)
        {
            //dgv_sublist  分包后信息view

            try
            {
                #region 条码显示

                if (txt_fbsl.Text.Trim() == "")
                {

                    MessageBox.Show("输入的分包数量不能为空!请重新输入");
                    return;
                }
                int fbsl = Convert.ToInt32(txt_fbsl.Text.Trim());//分包数量
                string sql = String.Format("select 条码,组别,数据来源,计划编号,客户编码,客户名称,客户物料编码  as 物料编码,客户物料名称 as 物料名称," +
                    "内部物料描述,内部物料编码,内部物料名称,客户物料描述,计量单位,b.数量 ,b.规格型号,b.生产日期,b.送货日期  from " +
                    "条码信息表_主表 b left join 标签_主表 a on a.物料编码=b.内部物料编码  where 1=2 ");

                d2 = DBLibrary.GetData(sql, sqlcon);
                d2.Clear();
                d4 = d2.Clone();
                string sjc = GetTimeStamp(DateTime.Now);
                int xuhao = 1;
                int count = 0;  //用于保存选中的checkbox数量 
                for (int i = 0; i < dgv_exismsglist.RowCount; i++)
                {
                    if (dgv_exismsglist.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                    //这里判断复选框是否选中 
                    {
                        // d4.Rows.Add(d3.Rows[i].ItemArray);  //将包装数量减去分包数量后更新到表中？？


                        //数据填充
                        int bzs = Convert.ToInt32(d3.Rows[i]["数量"]);//包装数量
                        int sl = bzs - fbsl;//分包后的数量
                        //d4.Rows[0]["数量"] = sl;//将初始的包装数量的值赋值为分包的数量
                        //d4.Rows[0]["数据来源"] = "分包";//分包
                        //d4.Rows[0]["组别"] = d3.Rows[i]["组别"];

                        if (bzs < fbsl)
                        {
                            MessageBox.Show("分包数量不能大于条码中原有数量！请重新输入！");
                            txt_fbsl.Text = "";
                            return;
                        }

                        DataRow dr = d4.NewRow();
                        dr["条码"] = sjc + "-" + xuhao;//条码
                        dr["物料编码"] = d3.Rows[i]["物料编码"];
                        dr["物料名称"] = d3.Rows[i]["物料名称"];
                        dr["数量"] = fbsl;//数量
                        #region 隐藏
                        dr["组别"] = d3.Rows[i]["组别"];
                        dr["计划编号"] = d3.Rows[i]["计划编号"];
                        dr["客户编码"] = d3.Rows[i]["客户编码"];
                        dr["客户物料描述"] = d3.Rows[i]["客户物料描述"];
                        dr["内部物料编码"] = d3.Rows[i]["内部物料编码"];
                        dr["内部物料名称"] = d3.Rows[i]["内部物料名称"];
                        dr["计量单位"] = d3.Rows[i]["计量单位"];
                        dr["内部物料描述"] = d3.Rows[i]["内部物料描述"];
                        dr["数据来源"] = "分包";
                        #endregion
                        dr["客户名称"] = d3.Rows[i]["客户名称"];
                        dr["规格型号"] = d3.Rows[i]["规格型号"];
                        dr["生产日期"] = d3.Rows[i]["生产日期"];
                        dr["送货日期"] = d3.Rows[i]["送货日期"];
                        d4.Rows.Add(dr);
                        xuhao++;

                        #region 更新分包后的条码中的信息

                        string tmbh = d3.Rows[i]["条码"].ToString();
                        int tmsl = sl;
                        string sql2 = "update  条码信息表_主表 set 数量='" + tmsl + "' where 条码='" + tmbh + "'";
                        DBLibrary.UpdateData(sql2, sqlcon);
                        #endregion

                        count++;
                    }
                }
                if (count == 0)
                {
                    MessageBox.Show("请至少选择一条数据！", "提示");
                    return;
                }
                else
                {
                    if (MessageBox.Show(this, "您要更新数据么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString() == "Yes")
                    {
                        while (this.dgv_sublist.Rows.Count != 0)
                        {
                            this.dgv_sublist.Rows.RemoveAt(0);
                        }

                        for (int i = 0; i < count; i++)
                        {


                            dgv_sublist.DataSource = d4;
                            #region  隐藏
                            dgv_sublist.Columns["客户编码"].Visible = false;
                            dgv_sublist.Columns["客户物料描述"].Visible = false;
                            dgv_sublist.Columns["内部物料编码"].Visible = false;
                            dgv_sublist.Columns["内部物料名称"].Visible = false;
                            dgv_sublist.Columns["计量单位"].Visible = false;
                            dgv_sublist.Columns["内部物料描述"].Visible = false;
                            //dgv_sublist.Columns["计划编号"].Visible = false;
                            dgv_sublist.Columns["组别"].Visible = false;
                            dgv_sublist.Columns["数据来源"].Visible = false;
                            #endregion


                        }
                        //AddCheckBoxToDataGridView.dgv = dgv_sublist;
                        //AddCheckBoxToDataGridView.AddFullSelect();
                    }
                    else
                    {
                        return;
                    }
                }
                #endregion


                #region 分包后的条码保存
                string dydate = DateTime.Now.ToString();//打印时间

                for (int i = 0; i < dgv_sublist.Rows.Count; i++)
                {
                    string tm = dgv_sublist.Rows[i].Cells["条码"].EditedFormattedValue.ToString();//条码
                    string wlbm = dgv_sublist.Rows[i].Cells["物料编码"].EditedFormattedValue.ToString();//物料编码
                    string wlmc = dgv_sublist.Rows[i].Cells["物料名称"].EditedFormattedValue.ToString();//物料名称
                    string bzsl = dgv_sublist.Rows[i].Cells["数量"].EditedFormattedValue.ToString();//包装数量
                    string khmc = dgv_sublist.Rows[i].Cells["客户名称"].EditedFormattedValue.ToString();//客户名称
                    string ggxh = dgv_sublist.Rows[i].Cells["规格型号"].EditedFormattedValue.ToString();//规格型号
                    string scrq = dgv_sublist.Rows[i].Cells["生产日期"].EditedFormattedValue.ToString();//生产日期
                    string shrq = dgv_sublist.Rows[i].Cells["送货日期"].EditedFormattedValue.ToString();//送货日期
                    string dysj = dydate;
                    //隐藏项保存
                    string khbm = dgv_sublist.Rows[i].Cells["客户编码"].EditedFormattedValue.ToString();//客户编码
                    string khwlms = dgv_sublist.Rows[i].Cells["客户物料描述"].EditedFormattedValue.ToString();//客户物料描述
                    string khwlbm = dgv_sublist.Rows[i].Cells["内部物料编码"].EditedFormattedValue.ToString();//客户物料编码
                    string jldw = dgv_sublist.Rows[i].Cells["计量单位"].EditedFormattedValue.ToString();//计量单位
                    string khwlmc = dgv_sublist.Rows[i].Cells["内部物料名称"].EditedFormattedValue.ToString();//客户物料名称
                    string nbwlms = dgv_sublist.Rows[i].Cells["内部物料描述"].EditedFormattedValue.ToString();//内部物料描述
                    string jhbh = dgv_sublist.Rows[i].Cells["计划编号"].EditedFormattedValue.ToString();//计划编号
                    string zb = dgv_sublist.Rows[i].Cells["组别"].EditedFormattedValue.ToString();//组别
                    string sjly = dgv_sublist.Rows[i].Cells["数据来源"].EditedFormattedValue.ToString();//数据来源
                    //条码，客户名称，客户编码，内部物料描述，内部物料编码，内部物料名称，客户物料编码，客户物料名称，客户物料描述，数量，计量单位
                    //生产日期，送货日期，条码打印时间，重新打印时间，入库时间，出货计划编号
                    string sql1 = "insert into 条码信息表_主表(条码,客户名称,客户物料编码,客户物料名称,数量,生产日期,送货日期,条码打印时间,客户编码,客户物料描述,内部物料编码,计量单位,内部物料名称,内部物料描述,规格型号,计划编号,组别,数据来源) values ('" + tm + "', '" + khmc + "','" + wlbm + "','" + wlmc + "','" + bzsl + "','" + scrq + "','" + shrq + "','" + dysj + "','" + khbm + "','" + khwlms + "','" + khwlbm + "','" + jldw + "','" + khwlmc + "','" + nbwlms + "','" + ggxh + "','" + jhbh + "','" + zb + "','" + sjly + "') ";
                    DBLibrary.UpdateData(sql1, sqlcon);

                }

                #endregion


            }
            catch (SqlException ee)
            {
                MessageBox.Show(ee.Message);
            }


        }

        private void btn_p_Click(object sender, EventArgs e)//分包打印(打印)
        {
            try
            {

                string sql = String.Format("select 条码,组别,计划编号,数据来源,客户编码,客户名称,客户物料编码  as 物料编码,客户物料名称 as 物料名称, 内部物料描述,内部物料编码,内部物料名称,客户物料描述,计量单位,b.数量 ,b.规格型号,b.生产日期,b.送货日期  from 条码信息表_主表 b left join 标签_主表 a on a.物料编码=b.内部物料编码");

                d2 = DBLibrary.GetData(sql, sqlcon);

                dsm = d2.Clone();
                //  int count = 0;  //用于保存选中的checkbox数量 
                for (int i = 0; i < dgv_sublist.RowCount; i++)
                {
                    if (dgv_sublist.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                    //这里判断复选框是否选中 
                    {
                        dsm.Rows.Add(d4.Rows[i].ItemArray);//获取条码数据

                    }
                }

                DataRow[] rows = dsm.Select();
                if (rows.Length < 1) { MessageBox.Show("请选择要打印的行", "提示："); return; }
                printtable.Clear();
                printtable = rows.CopyToDataTable();//  获取数据源数据
                if (printtable.Rows.Count < 1 || printtable.Columns.Count < 2) { MessageBox.Show("数据源中没有数据", "提示："); return; }

                #region //打印条码
                try
                {
                    ReportName = "cktm.grf";
                    if (d4.Rows[0]["客户编码"].ToString() == "GK005")
                    {
                        ReportName = "cktmdj.grf";
                    }

                    GridReportForm BForm = new GridReportForm();
                    BForm.printtable = printtable;
                    BForm.reportname = ReportName;
                    for (int i = 0; i < printtable.Rows.Count; i++)
                    {
                        string jhbm = printtable.Rows[0]["计划编号"].ToString();
                        string sql1 = string.Format("update  H016C生产计划_产品明细  set 打印状态=1 where 生产计划唯一ID='" + jhbm + "'");
                        DBLibrary.UpdateData(sql1, sqlcon);


                    }
                    BForm.ShowDialog();
                    dsm.Clear();
                }

                catch { }



                #endregion

                #region 条码更新
                string cxdydate = DateTime.Now.ToString();//重新打印时间     字段更新 ！！！ 

                for (int i = 0; i < dsm.Rows.Count; i++)
                {
                    string tm = dsm.Rows[i]["条码"].ToString();//条码
                    string wlbm = dsm.Rows[i]["物料编码"].ToString();//物料编码
                    string wlmc = dsm.Rows[i]["物料名称"].ToString();//物料名称
                    string bzsl = dsm.Rows[i]["包装数量"].ToString();//包装数量
                    string khmc = dsm.Rows[i]["客户名称"].ToString();//客户名称
                    string ggxh = dsm.Rows[i]["规格型号"].ToString();//规格型号
                    string scrq = dsm.Rows[i]["生产日期"].ToString();//生产日期
                    string shrq = dsm.Rows[i]["送货日期"].ToString();//送货日期
                    string cxdysj = cxdydate;//重新打印时间
                    //条码，客户名称，客户编码，内部物料描述，内部物料编码，内部物料名称，客户物料编码，客户物料名称，客户物料描述，数量，计量单位
                    //生产日期，送货日期，条码打印时间，重新打印时间，入库时间，出货计划编号
                    string sql1 = "update 条码信息表_主表 set 重新打印时间 ='" + cxdysj + "'  where 条码='" + tm + "'  and  客户物料编码='" + wlbm + "' and 客户物料名称='" + wlmc + "' and  客户名称='" + khmc + "' and  数量='" + bzsl + "' and  生产日期='" + scrq + "' and  送货日期='" + shrq + "' ";
                    DBLibrary.UpdateData(sql1, sqlcon);

                #endregion


                }


            }
            catch { }

        }

        private void btn_sf_Click(object sender, EventArgs e)//退货打印(查找)
        {
            //dgv_Shipmentslist 出货信息view
            if (txt_chd.Text.Trim() == "")
            {
                MessageBox.Show("查询信息不能为空！");
                return;

            }
            string chdh = txt_chd.Text.Trim();

            string sql = string.Format("select 唯一ID  as  出货单号 ,max(c.顾客ID) as 客户编码,max(c.顾客全称) as 客户名称, max(内部编码) as 内部物料编码,max(c.PDM名称) as 内部物料名称 ," +
                "max(c.PDM状态描述) as 内部物料描述,max(客户编码) as 客户物料编码,max(状态描述) as 客户物料描述,max(名称) as 客户物料名称,max(单位) as 计量单位, " +
                "max(a.数量) as 数量,max(规格型号) as 规格型号 from  O205销售出库单_明细 a  left join 标签_主表 b on a.客户编码=b.物料编码 left " +
                "join H402包装信息登记表_主表 c on a.内部编码=c.PDM编码 where 唯一ID  like '%" + chdh + "%'   or 顾客全称  like '%" + chdh + "%' or 客户编码  like '%" + chdh + "%'  group by 唯一ID ");
            d5 = DBLibrary.GetData(sql, sqlcon);



            if (d5 == null || d5.Rows.Count == 0)
            {
                MessageBox.Show("此信息已退货或不存在！请重新选择");
                //DataTable dt = (DataTable)dgv_Shipmentslist.DataSource;

                //dt.Rows.Clear();
                //DataTable da = (DataTable)dgv_relist.DataSource;

                //da.Rows.Clear();
                return;
            }

            dgv_Shipmentslist.DataSource = d5;




            #region  隐藏
            dgv_Shipmentslist.Columns["客户编码"].Visible = false;
            dgv_Shipmentslist.Columns["客户物料描述"].Visible = false;
            dgv_Shipmentslist.Columns["内部物料编码"].Visible = false;
            dgv_Shipmentslist.Columns["内部物料名称"].Visible = false;
            dgv_Shipmentslist.Columns["计量单位"].Visible = false;
            dgv_Shipmentslist.Columns["内部物料描述"].Visible = false;

            #endregion


            dgv_exismsglist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//填充布局
            //AddCheckBoxToDataGridView.dgv = dgv_Shipmentslist;
            //AddCheckBoxToDataGridView.AddFullSelect();


        }
        private void btn_th_Click(object sender, EventArgs e)//退货
        {

            try
            {


                string sqlcx = @"select 条码 from 条码信息表_主表";
                tmxs = DBLibrary.GetData(sqlcx, sqlcon);//获取现有条码信息

                string sjc = GetTimeStamp(DateTime.Now);
                #region 条码显示
                if (txt_thsl.Text.Trim() == "")
                {

                    MessageBox.Show("输入的退货数量不能为空!请重新输入");
                    return;
                }
                if (d5 == null || d5.Rows.Count == 0)
                {
                    MessageBox.Show("此信息已退货！请重新选择");
                    return;
                }

                string date = DateTime.Now.ToString("yyyyMMdd");
                int thsl = Convert.ToInt32(txt_thsl.Text.Trim());//退货数量
                string sql = String.Format("select 条码,组别,数据来源,出货计划编号,客户编码,客户名称,客户物料编码  as 物料编码,客户物料名称 as 物料名称, 内部物料描述," + 
                    "内部物料编码,内部物料名称,客户物料描述,计量单位,b.数量 ,b.规格型号,b.生产日期,b.送货日期  from 条码信息表_主表 b left join 标签_主表 a on a.物料编码=b.内部物料编码 where 1=2");

                d2 = DBLibrary.GetData(sql, sqlcon);
                d2.Clear();
                d6 = d2.Clone();
                int xuhao = 1;
                int count = 0;  //用于保存选中的checkbox数量 
                for (int i = 0; i < dgv_Shipmentslist.RowCount; i++)
                {
                    if (dgv_Shipmentslist.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                    //这里判断复选框是否选中 
                    {


                        //数据填充
                        int bzs = Convert.ToInt32(d5.Rows[i]["数量"]);//数量
                        int sl = bzs - thsl;//退货后的数量

                        if (bzs <= thsl)
                        {
                            MessageBox.Show("退货数量不能大于原有数量！请重新输入！");
                            txt_thsl.Text = "";
                            return;
                        }
                        DataRow dr = d6.NewRow();

                        dr["条码"] = sjc + "-" + xuhao;//条码
                        dr["物料编码"] = d5.Rows[i]["客户物料编码"];
                        dr["物料名称"] = d5.Rows[i]["客户物料名称"];
                        dr["数量"] = thsl;//数量
                        dr["出货计划编号"] = d5.Rows[i]["出货单号"];
                        #region 隐藏
                        // dr["组别"] = d5.Rows[i]["组别"];

                        dr["客户编码"] = d5.Rows[i]["客户编码"];
                        dr["客户物料描述"] = d5.Rows[i]["客户物料描述"];
                        dr["内部物料编码"] = d5.Rows[i]["内部物料编码"];
                        dr["内部物料名称"] = d5.Rows[i]["内部物料名称"];
                        dr["计量单位"] = d5.Rows[i]["计量单位"];
                        dr["内部物料描述"] = d5.Rows[i]["内部物料描述"];
                        dr["数据来源"] = "退货";
                        #endregion


                        dr["客户名称"] = d5.Rows[i]["客户名称"];
                        dr["规格型号"] = d5.Rows[i]["规格型号"];

                        //dr["生产日期"] = d5.Rows[i]["生产日期"];
                        //dr["送货日期"] = d5.Rows[i]["送货日期"];
                        d6.Rows.Add(dr);
                        string sql2 = "update  O205销售出库单_明细 set 数量='" + sl + "' where 唯一ID='" + d5.Rows[i]["出货单号"] + "'";
                        DBLibrary.UpdateData(sql2, sqlcon);
                        xuhao = xuhao + 1;
                        foreach (DataRow dh in tmxs.Rows)
                        {
                            if (d6.Rows[0]["条码"].ToString() == dh["条码"].ToString())
                            {
                                MessageBox.Show("该信息已经退货,请重新选择");
                                return;

                            }
                        }
                        //将出货单表中的数量更新？？


                        count++;
                    }
                }
                if (count == 0)
                {
                    MessageBox.Show("请至少选择一条数据！", "提示");
                    return;
                }
                else
                {
                    if (MessageBox.Show(this, "您要更新数据么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString() == "Yes")
                    {
                        while (this.dgv_relist.Rows.Count != 0)
                        {
                            this.dgv_relist.Rows.RemoveAt(0);
                        }

                        for (int i = 0; i < count; i++)
                        {


                            dgv_relist.DataSource = d6;
                            #region  隐藏
                            dgv_relist.Columns["客户编码"].Visible = false;
                            dgv_relist.Columns["客户物料描述"].Visible = false;
                            dgv_relist.Columns["内部物料编码"].Visible = false;
                            dgv_relist.Columns["内部物料名称"].Visible = false;
                            dgv_relist.Columns["计量单位"].Visible = false;
                            dgv_relist.Columns["内部物料描述"].Visible = false;
                            //dgv_relist.Columns["出货计划编号"].Visible = false;
                            dgv_relist.Columns["数据来源"].Visible = false;
                            dgv_relist.Columns["组别"].Visible = false;
                            #endregion


                        }
                        //AddCheckBoxToDataGridView.dgv = dgv_relist;
                        //AddCheckBoxToDataGridView.AddFullSelect();
                    }
                    else
                    {
                        return;
                    }
                }
                #endregion

                #region 退货后的条码保存
                string dydate = DateTime.Now.ToString();//打印时间

                for (int i = 0; i < dgv_relist.Rows.Count; i++)
                {
                    string tm = dgv_relist.Rows[i].Cells["条码"].EditedFormattedValue.ToString();//条码
                    string wlbm = dgv_relist.Rows[i].Cells["物料编码"].EditedFormattedValue.ToString();//物料编码
                    string wlmc = dgv_relist.Rows[i].Cells["物料名称"].EditedFormattedValue.ToString();//物料名称
                    string bzsl = dgv_relist.Rows[i].Cells["数量"].EditedFormattedValue.ToString();//包装数量
                    string khmc = dgv_relist.Rows[i].Cells["客户名称"].EditedFormattedValue.ToString();//客户名称
                    string ggxh = dgv_relist.Rows[i].Cells["规格型号"].EditedFormattedValue.ToString();//规格型号
                    //string scrq = dgv_sublist.Rows[i].Cells["生产日期"].EditedFormattedValue.ToString();//生产日期
                    //string shrq = dgv_sublist.Rows[i].Cells["送货日期"].EditedFormattedValue.ToString();//送货日期
                    string dysj = dydate;
                    //隐藏项保存
                    string khbm = dgv_relist.Rows[i].Cells["客户编码"].EditedFormattedValue.ToString();//客户编码
                    string khwlms = dgv_relist.Rows[i].Cells["客户物料描述"].EditedFormattedValue.ToString();//客户物料描述
                    string khwlbm = dgv_relist.Rows[i].Cells["内部物料编码"].EditedFormattedValue.ToString();//客户物料编码
                    string jldw = dgv_relist.Rows[i].Cells["计量单位"].EditedFormattedValue.ToString();//计量单位
                    string khwlmc = dgv_relist.Rows[i].Cells["内部物料名称"].EditedFormattedValue.ToString();//客户物料名称
                    string nbwlms = dgv_relist.Rows[i].Cells["内部物料描述"].EditedFormattedValue.ToString();//内部物料描述
                    string jhbh = dgv_relist.Rows[i].Cells["出货计划编号"].EditedFormattedValue.ToString();//出货计划编号
                    string sjly = dgv_relist.Rows[i].Cells["数据来源"].EditedFormattedValue.ToString();//数据来源
                    // string zb = dgv_sublist.Rows[i].Cells["组别"].EditedFormattedValue.ToString();//组别
                    //条码，客户名称，客户编码，内部物料描述，内部物料编码，内部物料名称，客户物料编码，客户物料名称，客户物料描述，数量，计量单位
                    //生产日期，送货日期，条码打印时间，重新打印时间，入库时间，出货计划编号
                    string sql1 = string.Format("insert  into 条码信息表_主表(条码,客户编码,客户名称,内部物料编码,内部物料名称,内部物料描述,客户物料描述,客户物料名称,客户物料编码,数量,计量单位,规格型号,条码打印时间,出货计划编号,数据来源) values ('" + tm + "','" + khbm + "','" + khmc + "','" + khwlbm + "','" + khwlmc + "','" + nbwlms + "','" + khwlms + "','" + wlmc + "','" + wlbm + "','" + bzsl + "','" + jldw + "','" + ggxh + "','" + dydate + "','" + jhbh + "','" + sjly + "')");
                    DBLibrary.UpdateData(sql1, sqlcon);

                    //string thbc = @"update O205销售出库单_明细 set 退回标记=1 where 唯一ID='" + jhbh + "'";
                    //DBLibrary.UpdateData(thbc, sqlcon);
                }

                #endregion


            }
            catch (SqlException ee)
            {
                MessageBox.Show(ee.Message);
            }



        }


        private void button2_Click(object sender, EventArgs e)//退货打印(打印)
        {
            //dgv_relist  退货信息view

            try
            {

                string sql = String.Format("select 条码,组别,数据来源,出货计划编号,客户编码,客户名称,客户物料编码  as 物料编码,客户物料名称 as 物料名称, 内部物料描述,内部物料编码,内部物料名称,客户物料描述,计量单位,b.数量 ,b.规格型号,b.生产日期,b.送货日期  from 条码信息表_主表 b left join 标签_主表 a on a.物料编码=b.内部物料编码");

                d2 = DBLibrary.GetData(sql, sqlcon);

                dsm = d2.Clone();



                //  int count = 0;  //用于保存选中的checkbox数量 
                for (int i = 0; i < dgv_relist.RowCount; i++)
                {
                    if (dgv_relist.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                    //这里判断复选框是否选中 
                    {
                        dsm.Rows.Add(d6.Rows[i].ItemArray);//获取条码数据

                    }
                }

                DataRow[] rows = dsm.Select();
                if (rows.Length < 1) { MessageBox.Show("请选择要打印的行", "提示："); return; }
                printtable.Clear();
                printtable = rows.CopyToDataTable();//  获取数据源数据
                if (printtable.Rows.Count < 1 || printtable.Columns.Count < 2) { MessageBox.Show("数据源中没有数据", "提示："); return; }

                #region //打印条码
                try
                {
                    ReportName = "cktm.grf";
                    if (d6.Rows[0]["客户编码"].ToString() == "GK005")
                    {
                        ReportName = "cktmdj.grf";
                    }

                    GridReportForm BForm = new GridReportForm();
                    BForm.printtable = printtable;
                    BForm.reportname = ReportName;

                    BForm.ShowDialog();


                    dsm.Clear();

                }

                catch { }
                #endregion

            }
            catch { }


        }

        private void dgv_unprintlist_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try { }
            catch
            {

            }
        }
        string dataold = "", datanew = "";
        private void dgv_unprintlist_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                dgv_unprintlist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
            }
        }

        int r2 = -1, Icol2 = -1; int r = -1; int Icol = -1;
        private void dgv_unprintlist_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                r2 = e.RowIndex; Icol2 = e.ColumnIndex;
                r = e.RowIndex; Icol = e.ColumnIndex;
            }
            catch { }
        }

        private void dgv_unprintlist_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = "";
                try { str = dgv_unprintlist.Columns[e.ColumnIndex].HeaderText.ToString(); }
                catch { str = ""; }
                if (str.Trim().LastIndexOf("选择") >= 0 || str.Trim().LastIndexOf("修改") >= 0) return;

                try { datanew = dgv_unprintlist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim(); }
                catch { datanew = ""; }
                if (dataold == datanew) { }
                else
                {
                    dgv_unprintlist.Rows[e.RowIndex].Cells["修改"].Value = 1; dgv_unprintlist.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                }
            }
            catch { }
        }



        private void dgv_unprintlist_CellClick(object sender, DataGridViewCellEventArgs e)//判断勾选
        {
            #region 点击表头无反应
            if (e.RowIndex == -1)
            {
                foreach (DataGridViewColumn column in dgv_unprintlist.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                return;

            }
            #endregion

            if ((bool)dgv_unprintlist.Rows[e.RowIndex].Cells["选择"].EditedFormattedValue == true)
            {


                dgv_unprintlist.Rows[e.RowIndex].Cells["选择"].Value = false;
            }
            else
            {
                dgv_unprintlist.Rows[e.RowIndex].Cells["选择"].Value = true;
            }



        }

        #region 全选
        /// <summary>
        /// 给DataGridView添加全选
        /// </summary>
        public class AddCheckBoxToDataGridView
        {
            public static System.Windows.Forms.DataGridView dgv;
            public static void AddFullSelect()
            {
                if (dgv.Rows.Count < 1)
                {
                    return;
                }
                System.Windows.Forms.CheckBox ckBox = new System.Windows.Forms.CheckBox();
                ckBox.Text = "全选";
                ckBox.Checked = false;
                System.Drawing.Rectangle rect =
                dgv.GetCellDisplayRectangle(0, -1, true);
                ckBox.Size = new System.Drawing.Size(dgv.Columns[0].Width, 23);
                ckBox.Location = rect.Location;
                ckBox.CheckedChanged += new EventHandler(ckBox_CheckedChanged);
                dgv.Controls.Add(ckBox);
            }
            static void ckBox_CheckedChanged(object sender, EventArgs e)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells[0].Value = ((System.Windows.Forms.CheckBox)sender).Checked;
                }
                dgv.EndEdit();
            }



        }
        public class AddCheckBoxToDataGridView1
        {
            public static System.Windows.Forms.DataGridView dgv;
            public static void AddFullSelect()
            {
                if (dgv.Rows.Count < 1)
                {
                    return;
                }
                System.Windows.Forms.CheckBox ckBox = new System.Windows.Forms.CheckBox();
                ckBox.Text = "全选 ";
                ckBox.Checked = false;
                System.Drawing.Rectangle rect =
                dgv.GetCellDisplayRectangle(0, -1, true);
                ckBox.Size = new System.Drawing.Size(dgv.Columns[0].Width, 23);
                ckBox.Location = rect.Location;
                ckBox.CheckedChanged += new EventHandler(ckBox_CheckedChanged);
                dgv.Controls.Add(ckBox);
            }
            static void ckBox_CheckedChanged(object sender, EventArgs e)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells[0].Value = ((System.Windows.Forms.CheckBox)sender).Checked;

                }
                dgv.EndEdit();
            }



        }

        #endregion


        private void dgv_barcodelist_CellClick(object sender, DataGridViewCellEventArgs e)//选择
        {

            if (e.RowIndex == -1)
            {
                foreach (DataGridViewColumn column in dgv_barcodelist.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                return;

            }

            if ((bool)dgv_barcodelist.Rows[e.RowIndex].Cells["c1"].EditedFormattedValue == true)
            {
                dgv_barcodelist.Rows[e.RowIndex].Cells["c1"].Value = false;
            }
            else
            {
                dgv_barcodelist.Rows[e.RowIndex].Cells["c1"].Value = true;
            }

        }

        private void dgv_brokenlist_CellClick(object sender, DataGridViewCellEventArgs e)//破损条码选择点击
        {

            if (e.RowIndex == -1)
            {
                foreach (DataGridViewColumn column in dgv_brokenlist.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                return;

            }

            if ((bool)dgv_brokenlist.Rows[e.RowIndex].Cells["c2"].EditedFormattedValue == true)
            {
                dgv_brokenlist.Rows[e.RowIndex].Cells["c2"].Value = false;
            }
            else
            {
                dgv_brokenlist.Rows[e.RowIndex].Cells["c2"].Value = true;
            }
        }

        private void dgv_exismsglist_CellClick(object sender, DataGridViewCellEventArgs e)//现有条码选择点击
        {
            if (e.RowIndex == -1)
            {
                foreach (DataGridViewColumn column in dgv_exismsglist.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                return;

            }

            if ((bool)dgv_exismsglist.Rows[e.RowIndex].Cells["c3"].EditedFormattedValue == true)
            {
                dgv_exismsglist.Rows[e.RowIndex].Cells["c3"].Value = false;
            }
            else
            {
                dgv_exismsglist.Rows[e.RowIndex].Cells["c3"].Value = true;
            }
        }

        private void dgv_sublist_CellClick(object sender, DataGridViewCellEventArgs e)//分包后信息点击
        {

            if (e.RowIndex == -1)
            {
                foreach (DataGridViewColumn column in dgv_sublist.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                return;

            }
            if ((bool)dgv_sublist.Rows[e.RowIndex].Cells["c4"].EditedFormattedValue == true)
            {
                dgv_sublist.Rows[e.RowIndex].Cells["c4"].Value = false;
            }
            else
            {
                dgv_sublist.Rows[e.RowIndex].Cells["c4"].Value = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)//查询(未打印)
        {
            string cx = txtcx.Text.Trim();


            string sql = String.Format(@"select 生产计划唯一ID as 计划编号,	max(b.顾客ID) as  客户编码 , max(客户名称 )as 客户名称, 
                max(PDM代号) as 内部物料编码, max(a.PDM名称) as 内部物料名称,max(状态描述)as 内部物料描述 ,max(客户物料号) as  
                客户物料编码,max(顾客物料名称) as 客户物料名称,max(客户物料描述) as 客户物料描述,max(包装数量) as 包装数量,max(单位) as 计量单位, 
                max(计划数) as 计划数,max(c.规格型号) as 规格型号,max(a.生产日期) as 生产日期,max(a.送货日期) as 送货日期, max(case 打印状态  
                 when 0 then '未打印' when 1 then '已打印'   end) as 打印状态 , max(单位明名称) as 单位名称,max(装备计划组别) as 组别 from H016C生产计划_产品明细 a  
                left  join H402包装信息登记表_主表 b  on a.顾客ID=b.顾客ID  and a.PDM代号=b.PDM编码 and a.客户物料号=b.顾客物料编号 left join 标签_主表 c on  客户物料号=c.物料编码   
                   where 打印状态=0 and 包装数量 is not null and  包装数量 <>0 and 计划数 is not null and 生产计划唯一ID like '%" + cx + "%'  or 客户名称 like '%" + cx + "%' or 客户物料号 like '%" + cx + "%'  group by 生产计划唯一ID  order by 生产计划唯一ID desc");
            ds = DBLibrary.GetData(sql, sqlcon);
            if (ds == null || ds.Rows.Count == 0)
            {
                MessageBox.Show("此信息不存在或已打印！请重新输入");
                DataTable dt = (DataTable)dgv_unprintlist.DataSource;

                dt.Rows.Clear();
                //dt.Columns.Clear();

                dgv_unprintlist.DataSource = dt;
                //  dgv_barcodelist.Rows.Clear();
                DataTable dz = (DataTable)dgv_barcodelist.DataSource;

                dz.Rows.Clear();
                //dz.Columns.Clear();

                dgv_barcodelist.DataSource = dz;

                return;
            }


            dgv_unprintlist.DataSource = ds;
            #region 隐藏
            dgv_unprintlist.Columns["客户编码"].Visible = false;
            dgv_unprintlist.Columns["内部物料描述"].Visible = false;
            dgv_unprintlist.Columns["内部物料编码"].Visible = false;
            dgv_unprintlist.Columns["内部物料名称"].Visible = false;
            dgv_unprintlist.Columns["客户物料描述"].Visible = false;
            dgv_unprintlist.Columns["计量单位"].Visible = false;
            dgv_unprintlist.Columns["打印状态"].Visible = false;
            dgv_unprintlist.Columns["单位名称"].Visible = false;
            dgv_unprintlist.Columns["组别"].Visible = false;
            #endregion
            dgv_unprintlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//填充布局
            AddCheckBoxToDataGridView.dgv = dgv_unprintlist;
            AddCheckBoxToDataGridView.AddFullSelect();

        }

        private void dgv_Shipmentslist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                foreach (DataGridViewColumn column in dgv_Shipmentslist.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                return;

            }

            //if ((bool)dgv_Shipmentslist.Rows[e.RowIndex].Cells["c5"].EditedFormattedValue == true)
            //{


            //    dgv_Shipmentslist.Rows[e.RowIndex].Cells["c5"].Value = false;

            //}
            //else
            //{
            //    dgv_Shipmentslist.Rows[e.RowIndex].Cells["c5"].Value = true;
            //}

            #region 设置出货单中数据只能一行一行点击
            if (e.ColumnIndex == 0)
            {
                DataGridViewCheckBoxCell ccbc = dgv_Shipmentslist.Rows[e.RowIndex].Cells[0] as DataGridViewCheckBoxCell;
                if (ccbc.Value.ToString() == "true")
                {
                    ccbc.Value = "false";
                }
                else
                {
                    ccbc.Value = "true";
                }
            }
            #endregion


        }

        private void dgv_relist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region 点击表头无反应
            if (e.RowIndex == -1)
            {
                foreach (DataGridViewColumn column in dgv_relist.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                return;

            }
            #endregion

                if ((bool)dgv_relist.Rows[e.RowIndex].Cells["c6"].EditedFormattedValue == true)
                {
                    dgv_relist.Rows[e.RowIndex].Cells["c6"].Value = false;
                }
                else
                {
                    dgv_relist.Rows[e.RowIndex].Cells["c6"].Value = true;
                }
        }



        private void dgv_Shipmentslist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //    if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            //    { //如果选择所属的列是第1列那么 ColumnIndex == 0
            //        foreach (DataGridViewRow row in dgv_Shipmentslist.Rows) row.Cells[e.ColumnIndex].Value = false;
            //        dgv_Shipmentslist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
            //    }
            for (int i = 0; i < dgv_Shipmentslist.Rows.Count; i++)
            {
                if (i != e.RowIndex && dgv_Shipmentslist.CurrentCell.ColumnIndex == 0)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgv_Shipmentslist.Rows[i].Cells[0];
                    cell.Value = false;
                }
            }



        }

        private void dgv_Shipmentslist_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            #region 设置出货单中数据只能一行一行点击
            foreach (DataGridViewRow dr in this.dgv_Shipmentslist.Rows)
            {
                //dr.ReadOnly = true;
                DataGridViewCheckBoxCell dc = dr.Cells[0] as DataGridViewCheckBoxCell;
                if (dc == null)
                    return;
                dc.ReadOnly = false;
                dc.TrueValue = "true";
                dc.FalseValue = "false";
                dc.Value = "false";
            }
            #endregion
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgv_unprintlist_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dgv_barcodelist_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dgv_brokenlist_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dgv_exismsglist_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dgv_sublist_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dgv_Shipmentslist_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dgv_relist_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

     






    }
}
