using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using PilotGaea.Serialize;
using PilotGaea.TMPEngine;
using PilotGaea.Geometry;

namespace ModelSetConverterApp
{
    public partial class Form1 : Form
    {
        CModelSetMaker m_Maker = null;
        Stopwatch m_Stopwatch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();

            //加入功能列表
            List<string> featureNames = new List<string>();
            featureNames.Add("來源KMZ");
            featureNames.Add("來源SHP");
            featureNames.Add("來源MESH");
            featureNames.Add("輸出OGC I3S");
            featureNames.Add("輸出OGC 3DTiles");
            comboBox_Features.Items.AddRange(featureNames.ToArray());
            comboBox_Features.SelectedIndex = 0;
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            EnableUI(false);

            //將來源資料輸出成ModelSet圖層
            System.Environment.CurrentDirectory = @"C:\Program Files\PilotGaea\TileMap";//為了順利存取安裝目錄下的相關DLL
            m_Maker = new CModelSetMaker();
            //設定必要參數
            CModelSetMaker.MODELSET_CREATE_PARAM createParam = new CModelSetMaker.MODELSET_CREATE_PARAM();
            createParam.LayerDBFile = string.Format(@"{0}\..\output\modelset_maker.DB", Application.StartupPath);
            createParam.LayerName = "test";
            createParam.TerrainDBFile = string.Format(@"{0}\..\data\terrain_maker\terrain.DB", Application.StartupPath);
            createParam.TerrainName = "terrain";
            createParam.ExportType = EXPORT_TYPE.LET_DB;

            MODELSET_SRC sourceData = new MODELSET_SRC(MODELSET_SRC.MESH_SOURCE_TYPE.MESH_SOURCE_KMZ);


            //監聽轉檔事件
            m_Maker.CreateLayerCompleted += M_Maker_CreateLayerCompleted; ;
            m_Maker.ProgressMessageChanged += M_Maker_ProgressMessageChanged;
            m_Maker.ProgressPercentChanged += M_Maker_ProgressPercentChanged;

            //設定進階參數
            switch (comboBox_Features.SelectedIndex)
            {
                case 0://"來源KMZ"
                    sourceData = new MODELSET_SRC(MODELSET_SRC.MESH_SOURCE_TYPE.MESH_SOURCE_KMZ);
                    sourceData.MeshFileName = string.Format(@"{0}\..\data\modelset_maker\TC1036955_r1.kmz", Application.StartupPath);
                    break;
                case 1://"來源SHP"
                    sourceData = new MODELSET_SRC(MODELSET_SRC.MESH_SOURCE_TYPE.MESH_SOURCE_SHP);
                    createParam.LayerDBFile = string.Format(@"{0}\..\output\modelset_maker_shp.DB", Application.StartupPath);
                    createParam.HeightField = "height";
                    createParam.ShpDir = string.Format(@"{0}\..\data\modelset_maker\gis_osm_buildings_a_free_1_20m.shp", Application.StartupPath);
                    sourceData.MeshFileName = string.Format(@"{0}\..\data\modelset_maker\gis_osm_buildings_a_free_1_20m.shp", Application.StartupPath);
                    sourceData.MeshEPSG = 4326;
                    break;
                case 2://"來源MESH"
                    sourceData = new MODELSET_SRC(MODELSET_SRC.MESH_SOURCE_TYPE.MESH_SOURCE_MESH);
                    createParam.LayerDBFile = string.Format(@"{0}\..\output\modelset_maker_stl.DB", Application.StartupPath);
                    sourceData.MeshFileName = string.Format(@"{0}\..\data\modelset_maker\to_stl_temp2.stl", Application.StartupPath);
                    sourceData.MeshEPSG = 3826;
                    sourceData.PosX = 179259.33;
                    sourceData.PosY = 2502475.66;
                    break;
                case 3://"輸出OGC I3S"
                    createParam.ExportType = EXPORT_TYPE.LET_OGCI3S;
                    createParam.LayerName = "modelset_maker_ogci3s";
                    //會在destPath目錄下產生layerName.slpk
                    break;
                case 4://"輸出OGC 3DTiles
                    createParam.ExportType = EXPORT_TYPE.LET_OGC3DTILES;
                    createParam.LayerName = "modelset_maker_ogc3dtiles";
                    //會在destPath目錄下產生layerName資料夾
                    break;
            }

            m_Stopwatch.Restart();
            //開始非同步轉檔
            bool ret = m_Maker.Create(createParam);
            string message = string.Format("Create{0}", (ret ? "通過" : "失敗"));
            listBox_Main.Items.Add(message);
            ret = m_Maker.NewEntity(sourceData);
            message = string.Format("NewEntity{0}", (ret ? "成功" : "失敗"));
            listBox_Main.Items.Add(message);
            ret = m_Maker.EndCreate();
            message = string.Format("EndCreate{0}", (ret ? "通過" : "失敗"));
            listBox_Main.Items.Add(message);
        }

        private void M_Maker_ProgressPercentChanged(double Percent)
        {
            progressBar_Main.Value = Convert.ToInt32(Percent);
        }

        private void M_Maker_ProgressMessageChanged(string Message)
        {
            listBox_Main.Items.Add(Message);
        }

        private void M_Maker_CreateLayerCompleted(string LayerName, bool Success, string ErrorMessage)
        {
            m_Stopwatch.Stop();
            string message = string.Format("轉檔{0}", (Success ? "成功" : "失敗"));
            listBox_Main.Items.Add(message);
            message = string.Format("耗時{0}分。", m_Stopwatch.Elapsed.TotalMinutes.ToString("0.00"));
            listBox_Main.Items.Add(message);
        }

        private void EnableUI(bool enable)
        {
            button_Start.Enabled = enable;
            comboBox_Features.Enabled = enable;
        }
    }
}
