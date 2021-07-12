using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PilotGaea.TMPEngine;

namespace ModelSetConverterApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(@"C:\Program Files\PilotGaea\TileMap");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CModelSetMaker maker = new CModelSetMaker();

            maker.ProgressPercentChanged += Maker_ProgressPercentChanged;
            maker.ProgressMessageChanged += Maker_ProgressMessageChanged;
            maker.CreateLayerCompleted += Maker_CreateLayerCompleted;

            string[] FieldNames = new string[2];
            FieldNames[0] = "Field1";
            FieldNames[1] = "Field2";
            FIELD_TYPE[] FieldTypes = new FIELD_TYPE[2];
            FieldTypes[0] = FIELD_TYPE.STRING;
            FieldTypes[1] = FIELD_TYPE.DOUBLE;
            if (maker.Create("layername", @"D:\圖資\test\ConverterDB.DB", "terrain", @"D:\圖資\terrain.DB", EXPORT_TYPE.LET_DB, FieldNames, FieldTypes))
            {

            }
            MODELSET_SRC src = new MODELSET_SRC("KMZ");
            src.MeshFileName = @"D:\圖資 \Taipei3DBuilding\4847\5144_r1.kmz";
            src.MeshEPSG = 3826;

            src.Attrs = new string[0];
            src.OffsetX = 0;
            src.OffsetY = 0;
            src.OffsetZ = 0;
            src.PosX = 0;
            src.PosY = 0;
            src.PosZ = 0;
            src.IsAbsHeight = false;
            maker.NewEntity(src);

            maker.EndCreate(true);

            maker = null;
        }

        private void Maker_CreateLayerCompleted(string LayerName, bool Success, string ErrorMessage)
        {
            m_MessageList.Items.Add("Maker_CreateLayerCompleted:" + LayerName + " - " + Success.ToString());
        }

        private void Maker_ProgressMessageChanged(string Message)
        {
            m_MessageList.Items.Add("Maker_ProgressMessageChanged:" + Message);
        }

        private void Maker_ProgressPercentChanged(double Percent)
        {
            m_MessageList.Items.Add("Maker_ProgressPercentChanged:" + (Percent / 10.0).ToString("0.00") + "%");
        }

    }
}
