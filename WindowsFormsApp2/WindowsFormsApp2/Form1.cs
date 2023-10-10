using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MetroSet_UI.Forms;
using System.Threading;

namespace WindowsFormsApp2
{
    public partial class Form1 : MetroSetForm
    {
        VAMemory mem = new VAMemory("Borderlands3");
        Process processes;

        uint FOVpAddress = 0x65E7A80;
        int FOVptrOffset1 = 0x30;
        int FOVptrOffset2 = 0x528;
        int FOVptrOffset3 = 0x168;
        int FOVptrOffset4 = 0x20;
        int FOVptrOffset5 = 0x460;
        int FOVptrOffset6 = 0x118;
        int FOVptrOffset7 = 0x470;

        UInt64 FOVOffset1;
        UInt64 FOVOffset2;
        UInt64 FOVOffset3;
        UInt64 FOVOffset4;
        UInt64 FOVOffset5;
        UInt64 FOVOffset6;
        UInt64 FOVOffset7;

        uint HealthpAddress = 0x661B508;
        int HealthptrOffset1 = 0x67C;
        int HealthptrOffset2 = 0x20;
        int HealthptrOffset3 = 0x910;
        int HealthptrOffset4 = 0x678;
        int HealthptrOffset5 = 0xE0;
        int HealthptrOffset6 = 0x180;
        int HealthptrOffset7 = 0x198;

        UInt64 HealthOffset1;
        UInt64 HealthOffset2;
        UInt64 HealthOffset3;
        UInt64 HealthOffset4;
        UInt64 HealthOffset5;
        UInt64 HealthOffset6;
        UInt64 HealthOffset7;

        uint MaxHealthpAddress = 0x63617E0;
        int MaxHealthptrOffset1 = 0x20;
        int MaxHealthptrOffset2 = 0x118;
        int MaxHealthptrOffset3 = 0x460;
        int MaxHealthptrOffset4 = 0x528;
        int MaxHealthptrOffset5 = 0x68;
        int MaxHealthptrOffset6 = 0x180;
        int MaxHealthptrOffset7 = 0x118;

        UInt64 MaxHealthOffset1;
        UInt64 MaxHealthOffset2;
        UInt64 MaxHealthOffset3;
        UInt64 MaxHealthOffset4;
        UInt64 MaxHealthOffset5;
        UInt64 MaxHealthOffset6;
        UInt64 MaxHealthOffset7;

        uint ShieldCapacitypAddress = 0x5FFE248;
        int ShieldCapacityptrOffset1 = 0x0;
        int ShieldCapacityptrOffset2 = 0x8;
        int ShieldCapacityptrOffset3 = 0x10;
        int ShieldCapacityptrOffset4 = 0x10;
        int ShieldCapacityptrOffset5 = 0x638;
        int ShieldCapacityptrOffset6 = 0x180;
        int ShieldCapacityptrOffset7 = 0x290;

        UInt64 ShieldCapacityOffset1;
        UInt64 ShieldCapacityOffset2;
        UInt64 ShieldCapacityOffset3;
        UInt64 ShieldCapacityOffset4;
        UInt64 ShieldCapacityOffset5;
        UInt64 ShieldCapacityOffset6;
        UInt64 ShieldCapacityOffset7;

        uint MaxShieldCapacitypAddress = 0x65F38C8;
        int MaxShieldCapacityptrOffset1 = 0x8;
        int MaxShieldCapacityptrOffset2 = 0x2F8;
        int MaxShieldCapacityptrOffset3 = 0x460;
        int MaxShieldCapacityptrOffset4 = 0x528;
        int MaxShieldCapacityptrOffset5 = 0xE0;
        int MaxShieldCapacityptrOffset6 = 0x180;
        int MaxShieldCapacityptrOffset7 = 0x210;

        UInt64 MaxShieldCapacityOffset1;
        UInt64 MaxShieldCapacityOffset2;
        UInt64 MaxShieldCapacityOffset3;
        UInt64 MaxShieldCapacityOffset4;
        UInt64 MaxShieldCapacityOffset5;
        UInt64 MaxShieldCapacityOffset6;
        UInt64 MaxShieldCapacityOffset7;

        uint ShieldRechargeDelaypAddress = 0x65899C0;
        int ShieldRechargeDelayptrOffset1 = 0x8;
        int ShieldRechargeDelayptrOffset2 = 0x1E0;
        int ShieldRechargeDelayptrOffset3 = 0x2B0;
        int ShieldRechargeDelayptrOffset4 = 0x90;
        int ShieldRechargeDelayptrOffset5 = 0x180;
        int ShieldRechargeDelayptrOffset6 = 0x24C;

        UInt64 ShieldRechargeDelayOffset1;
        UInt64 ShieldRechargeDelayOffset2;
        UInt64 ShieldRechargeDelayOffset3;
        UInt64 ShieldRechargeDelayOffset4;
        UInt64 ShieldRechargeDelayOffset5;
        UInt64 ShieldRechargeDelayOffset6;

        uint ShieldRechargeRatepAddress = 0x5D9EED0;
        int ShieldRechargeRateptrOffset1 = 0x0;
        int ShieldRechargeRateptrOffset2 = 0x148;
        int ShieldRechargeRateptrOffset3 = 0x558;
        int ShieldRechargeRateptrOffset4 = 0x528;
        int ShieldRechargeRateptrOffset5 = 0xE0;
        int ShieldRechargeRateptrOffset6 = 0x180;
        int ShieldRechargeRateptrOffset7 = 0x240;

        UInt64 ShieldRechargeRateOffset1;
        UInt64 ShieldRechargeRateOffset2;
        UInt64 ShieldRechargeRateOffset3;
        UInt64 ShieldRechargeRateOffset4;
        UInt64 ShieldRechargeRateOffset5;
        UInt64 ShieldRechargeRateOffset6;
        UInt64 ShieldRechargeRateOffset7;

        uint RankEXPpAddress = 0x65F38C8;
        int RankEXPptrOffset1 = 0x8;
        int RankEXPptrOffset2 = 0x328;
        int RankEXPptrOffset3 = 0x118;
        int RankEXPptrOffset4 = 0x848;
        int RankEXPptrOffset5 = 0x2B0;
        int RankEXPptrOffset6 = 0xD0;
        int RankEXPptrOffset7 = 0x1D8;

        UInt64 RankEXPOffset1;
        UInt64 RankEXPOffset2;
        UInt64 RankEXPOffset3;
        UInt64 RankEXPOffset4;
        UInt64 RankEXPOffset5;
        UInt64 RankEXPOffset6;
        UInt64 RankEXPOffset7;

        uint GardianEXPpAddress = 0x6365CB0;
        int GardianEXPptrOffset1 = 0x0;
        int GardianEXPptrOffset2 = 0xA0;
        int GardianEXPptrOffset3 = 0x0;
        int GardianEXPptrOffset4 = 0x8;
        int GardianEXPptrOffset5 = 0x300;
        int GardianEXPptrOffset6 = 0x30;
        int GardianEXPptrOffset7 = 0x180;

        UInt64 GardianEXPOffset1;
        UInt64 GardianEXPOffset2;
        UInt64 GardianEXPOffset3;
        UInt64 GardianEXPOffset4;
        UInt64 GardianEXPOffset5;
        UInt64 GardianEXPOffset6;
        UInt64 GardianEXPOffset7;

        uint PlayerCorddinatespAddress = 0x65E7A80;
        int PlayerCorddinatesptrOffset1 = 0x30;
        int PlayerCorddinatesptrOffset2 = 0x900;
        int PlayerCorddinatesptrOffset3 = 0x1B0;
        int PlayerCorddinatesptrOffset4 = 0x888;
        int PlayerCorddinatesptrOffset5 = 0x608;
        int PlayerCorddinatesptrOffset6 = 0x180;

        UInt64 PlayerCorddinatesOffset1;
        UInt64 PlayerCorddinatesOffset2;
        UInt64 PlayerCorddinatesOffset3;
        UInt64 PlayerCorddinatesOffset4;
        UInt64 PlayerCorddinatesOffset5;
        UInt64 PlayerCorddinatesOffset6;
        UInt64 PlayerCorddinatesOffset7;

        int PlayerYaxisptrOffset = 0x228;
        int PlayerXaxisptrOffset = 0x224;
        int PlayerZaxisptrOffset = 0x220;

        uint PlayerCurrencypAddress = 0x65899C0;
        int PlayerCurrencyptrOffset1 = 0x8;
        int PlayerCurrencyptrOffset2 = 0x308;
        int PlayerCurrencyptrOffset3 = 0x498;
        int PlayerCurrencyptrOffset4 = 0x2B0;
        int PlayerCurrencyptrOffset5 = 0x1C0;
        int PlayerCurrencyptrOffset6 = 0x228;

        UInt64 PlayerCurrencyOffset1;
        UInt64 PlayerCurrencyOffset2;
        UInt64 PlayerCurrencyOffset3;
        UInt64 PlayerCurrencyOffset4;
        UInt64 PlayerCurrencyOffset5;
        UInt64 PlayerCurrencyOffset6;
        UInt64 PlayerCurrencyOffset7;

        int EDptrOffset = 0x58;
        int MoneyptrOffset = 0x18;

        uint WayCorddinatespAddress = 0x6040FD0;
        int WayCorddinatesptrOffset1 = 0x1E0;
        int WayCorddinatesptrOffset2 = 0x140;
        int WayCorddinatesptrOffset3 = 0x20;
        int WayCorddinatesptrOffset4 = 0x190;
        int WayCorddinatesptrOffset5 = 0x1A0;
        int WayCorddinatesptrOffset6 = 0x128;

        UInt64 WayCorddinatesOffset1;
        UInt64 WayCorddinatesOffset2;
        UInt64 WayCorddinatesOffset3;
        UInt64 WayCorddinatesOffset4;
        UInt64 WayCorddinatesOffset5;
        UInt64 WayCorddinatesOffset6;
        UInt64 WayCorddinatesOffset7;

        int WayYaxisptrOffset = 0x1D8;
        int WayXaxisptrOffset = 0x1D4;
        int WayZaxisptrOffset = 0x1D0;

        uint BPSpAddress = 0x65899C0;
        int BPSptrOffset1 = 0x0;
        int BPSptrOffset2 = 0x1E0;
        int BPSptrOffset3 = 0x300;
        int BPSptrOffset4 = 0x60;
        int BPSptrOffset5 = 0x2A8;

        UInt64 BPSOffset1;
        UInt64 BPSOffset2;
        UInt64 BPSOffset3;
        UInt64 BPSOffset4;
        UInt64 BPSOffset5;

        uint WeaponPropertiespAddress = 0x5FFE248;
        int WeaponPropertiesptrOffset1 = 0x0;
        int WeaponPropertiesptrOffset2 = 0x8;
        int WeaponPropertiesptrOffset3 = 0x10;
        int WeaponPropertiesptrOffset4 = 0x20;
        int WeaponPropertiesptrOffset5 = 0x600;
        int WeaponPropertiesptrOffset6 = 0x470;

        UInt64 WeaponPropertiesOffset1;
        UInt64 WeaponPropertiesOffset2;
        UInt64 WeaponPropertiesOffset3;
        UInt64 WeaponPropertiesOffset4;
        UInt64 WeaponPropertiesOffset5;
        UInt64 WeaponPropertiesOffset6;
        UInt64 WeaponPropertiesOffset7;

        int DamageptrOffset = 0x31C;
        int AccuracyptrOffset = 0x2F4;
        int FRptrOffset = 0x21C;
        int ProjectileptrOffset = 0x904;

        uint CarCorddinatespAddress = 0x1E474208;
        int CarCorddinatesptrOffset1 = 0x1C4;
        int CarCorddinatesptrOffset2 = 0x60;
        int CarCorddinatesptrOffset3 = 0x38;
        int CarCorddinatesptrOffset4 = 0x198;
        int CarCorddinatesptrOffset5 = 0x58;
        int CarCorddinatesptrOffset6 = 0x20;

        UInt64 CarCorddinatesOffset1;
        UInt64 CarCorddinatesOffset2;
        UInt64 CarCorddinatesOffset3;
        UInt64 CarCorddinatesOffset4;
        UInt64 CarCorddinatesOffset5;
        UInt64 CarCorddinatesOffset6;
        UInt64 CarCorddinatesOffset7;

        int CarYptrOffset = 0x18;
        int CarXptrOffset = 0x14;
        int CarZptrOffset = 0x10;

        uint CarPropertiespAddress = 0x661BE28;
        int CarPropertiesptrOffset1 = 0x10;
        int CarPropertiesptrOffset2 = 0x20;
        int CarPropertiesptrOffset3 = 0x560;
        int CarPropertiesptrOffset4 = 0x228;
        int CarPropertiesptrOffset5 = 0x2B8;
        int CarPropertiesptrOffset6 = 0x180;

        UInt64 CarPropertiesOffset1;
        UInt64 CarPropertiesOffset2;
        UInt64 CarPropertiesOffset3;
        UInt64 CarPropertiesOffset4;
        UInt64 CarPropertiesOffset5;
        UInt64 CarPropertiesOffset6;
        UInt64 CarPropertiesOffset7;

        int CarPropertiesBoostptrOffset = 0x290;
        int CarPropertiesMaxBoostptrOffset = 0x210;
        int CarPropertiesHealthptrOffset = 0xA0;
        int CarPropertiesMaxHealthptrOffset = 0x20;

        uint MainTextpAddress = 0x126D68A8;
        int MainTextptrOffset1 = 0xE78;
        int MainTextptrOffset2 = 0x994;
        int MainTextptrOffset3 = 0x260;
        int MainTextptrOffset4 = 0x1A8;
        int MainTextptrOffset5 = 0x10;

        UInt64 MainTextOffset1;
        UInt64 MainTextOffset2;
        UInt64 MainTextOffset3;
        UInt64 MainTextOffset4;
        UInt64 MainTextOffset5;
        UInt64 MainTextOffset6;

        int MainPlayptrOffset = 0x190;
        int MainSocialptrOffset = 0x170;
        int MainOptionsptrOffset = 0x1A0;
        int MainQGptrOffset = 0x3BA30;

        uint InTextpAddress = 0x1B90D990;
        int InTextptrOffset1 = 0x488;
        int InTextptrOffset2 = 0x3D0;
        int InTextptrOffset3 = 0xA38;
        int InTextptrOffset4 = 0xA40;
        int InTextptrOffset5 = 0x3A0;
        int InTextptrOffset6 = 0x10;

        UInt64 InTextOffset1;
        UInt64 InTextOffset2;
        UInt64 InTextOffset3;
        UInt64 InTextOffset4;
        UInt64 InTextOffset5;
        UInt64 InTextOffset6;
        UInt64 InTextOffset7;

        int InTextResumeptr = 0x60;
        int InTextSocialptr = 0x470;
        int InTextOptionsptr = 0x70;
        int InTextPMptr = 0x3E8B0;
        int InTextQGptr = 0x3E870;

        int DebugPage;

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Height = 295;
            this.Width = 601;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                DebugInfo();
                RollersValues();
                GetPlayerCorddinates();
                GetCarProperties();
                GetWayCorddinates();
                GetCarCorrdinates();
                Thread.Sleep(500);
            }
        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            treeView1.LabelEdit = true;
            treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes.Add("0");
            treeView1.Nodes[0].Nodes[0].Nodes[1].Nodes.Add("0");
            treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("0");
            treeView1.Nodes[0].Nodes[1].Nodes[1].Nodes.Add("0");
            treeView1.Nodes[0].Nodes[1].Nodes[2].Nodes.Add("0");
            treeView1.Nodes[0].Nodes[1].Nodes[3].Nodes.Add("0");
            treeView1.Nodes[0].Nodes[2].Nodes[0].Nodes.Add("0");
            treeView1.Nodes[0].Nodes[2].Nodes[1].Nodes.Add("0");
            treeView1.Nodes[0].Nodes[3].Nodes[0].Nodes.Add("0");
            treeView1.Nodes[0].Nodes[3].Nodes[1].Nodes.Add("0");
            treeView1.Nodes[0].Nodes[4].Nodes.Add("0");
            treeView1.Nodes[0].Nodes[5].Nodes.Add("0");
            treeView1.Nodes[1].Nodes[0].Nodes[0].Nodes.Add("0");
            treeView1.Nodes[1].Nodes[0].Nodes[1].Nodes.Add("0");
            treeView1.Nodes[1].Nodes[0].Nodes[2].Nodes.Add("0");
            treeView1.Nodes[1].Nodes[1].Nodes[0].Nodes.Add("0");
            treeView1.Nodes[1].Nodes[1].Nodes[1].Nodes.Add("0");
            treeView1.Nodes[1].Nodes[1].Nodes[2].Nodes.Add("0");
            treeView1.Nodes[1].Nodes[2].Nodes[0].Nodes.Add("0");
            treeView1.Nodes[1].Nodes[2].Nodes[1].Nodes.Add("0");
            treeView1.Nodes[1].Nodes[2].Nodes[2].Nodes.Add("0");
            treeView1.Nodes[2].Nodes[0].Nodes.Add("0");
            treeView1.Nodes[2].Nodes[1].Nodes.Add("0");
            treeView1.Nodes[2].Nodes[2].Nodes.Add("0");
            treeView1.Nodes[2].Nodes[3].Nodes.Add("0");
            treeView1.Nodes[3].Nodes[0].Nodes[0].Nodes.Add("0");
            treeView1.Nodes[3].Nodes[0].Nodes[1].Nodes.Add("0");
            treeView1.Nodes[3].Nodes[1].Nodes[0].Nodes.Add("0");
            treeView1.Nodes[3].Nodes[1].Nodes[1].Nodes.Add("0");

            processes = Process.GetProcessesByName("Borderlands3").ToList().FirstOrDefault();
            string ID = processes.Id.ToString();
            metroSetLabel10.Text = ID;

            if (processes != null)
            {
                GetFov();
                GetHealth();
                GetMaxHealth();
                GetShieldCapacity();
                GetMaxShieldCapacity();
                GetShieldRechargeDelay();
                GetShieldRechargeRate();
                GetRankEXP();
                GetGardianEXP();
                GetPlayerCurrency();
                GetBackpackSpace();
                GetWeaponProperties();
                GetMainText();
                GetInText();
                backgroundWorker1.RunWorkerAsync();

                byte[] playBytes = { 0x4F, 0x00, 0x58, 0x00, 0x59, 0x00, 0x5F, 0x00 };
                byte[] socialBytes = { 0x50, 0x00, 0x52, 0x00, 0x49, 0x00, 0x56, 0x00, 0x41, 0x00, 0x54, 0x00, 0x45, 0x00 };
                byte[] optionBytes = { 0x54, 0x00, 0x52, 0x00, 0x41, 0x00, 0x49, 0x00, 0x4E, 0x00, 0x45, 0x00, 0x52, 0x00 };
                byte[] qgBytes = { 0x42, 0x00, 0x49, 0x00, 0x49, 0x00, 0x43, 0x00, 0x48, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

                byte[] inResumeBytes = { 0x4F, 0x00, 0x58, 0x00, 0x59, 0x00, 0x5F, 0x00, 0x27, 0x00, 0x53 };
                byte[] inSocialBytes = { 0x50, 0x00, 0x52, 0x00, 0x49, 0x00, 0x56, 0x00, 0x41, 0x00, 0x54, 0x00, 0x45 };
                byte[] inOptionsBytes = { 0x54, 0x00, 0x52, 0x00, 0x41, 0x00, 0x49, 0x00, 0x4E, 0x00, 0x45, 0x00, 0x52 };
                byte[] inPMBytes = { 0x56, 0x00, 0x2D, 0x00, 0x31, 0x00, 0x2E, 0x00, 0x30, 0x00, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                byte[] inQGBytes = { 0x47, 0x00, 0x41, 0x00, 0x59, 0x00, 0x20, 0x00, 0x41, 0x00, 0x53, 0x00, 0x53, 0x00, 0x00, 0x00, 0x00 };

                mem.WriteByteArray((IntPtr)MainTextOffset6 + MainPlayptrOffset, playBytes);
                mem.WriteByteArray((IntPtr)MainTextOffset6 + MainSocialptrOffset, socialBytes);
                mem.WriteByteArray((IntPtr)MainTextOffset6 + MainOptionsptrOffset, optionBytes);
                //mem.WriteByteArray((IntPtr)MainTextOffset6 + MainQGptrOffset, qgBytes);

                mem.WriteByteArray((IntPtr)InTextOffset7 + InTextResumeptr, inResumeBytes);
                mem.WriteByteArray((IntPtr)InTextOffset7 + InTextSocialptr, inSocialBytes);
                mem.WriteByteArray((IntPtr)InTextOffset7 + InTextOptionsptr, inOptionsBytes);
                //mem.WriteByteArray((IntPtr)InTextOffset7 + InTextPMptr, inPMBytes);
                //mem.WriteByteArray((IntPtr)InTextOffset7 + InTextQGptr, inQGBytes);
            }

        }

        public void RollersValues()
        {
            //metroSetTrackBar1.Maximum = (int)mem.ReadFloat((IntPtr)MaxHealthOffset7 + MaxHealthptrOffset7);
            metroSetTrackBar1.Value = (int)mem.ReadFloat((IntPtr)HealthOffset7 + HealthptrOffset7);
            //metroSetTrackBar3.Maximum = (int)mem.ReadFloat((IntPtr)MaxShieldCapacityOffset7 + MaxShieldCapacityptrOffset7);
            metroSetTrackBar3.Value = (int)mem.ReadFloat((IntPtr)ShieldCapacityOffset7 + ShieldCapacityptrOffset7);
            metroSetTrackBar5.Value = (int)mem.ReadFloat((IntPtr)ShieldRechargeDelayOffset6 + ShieldRechargeDelayptrOffset6);
            metroSetTrackBar6.Value = (int)mem.ReadFloat((IntPtr)ShieldRechargeRateOffset7 + ShieldRechargeRateptrOffset7);
            metroSetTrackBar7.Value = (int)mem.ReadFloat((IntPtr)FOVOffset7 + FOVptrOffset7);
            //metroSetTrackBar4.Maximum = (int)mem.ReadFloat((IntPtr)CarPropertiesOffset7 + CarPropertiesMaxBoostptrOffset);
            metroSetTrackBar4.Value = (int)mem.ReadFloat((IntPtr)CarPropertiesOffset7 + CarPropertiesBoostptrOffset);
           // metroSetTrackBar2.Maximum = (int)mem.ReadFloat((IntPtr)CarPropertiesOffset7 + CarPropertiesMaxHealthptrOffset);
            metroSetTrackBar2.Value = (int)mem.ReadFloat((IntPtr)CarPropertiesOffset7 + CarPropertiesHealthptrOffset);
            metroSetTrackBar8.Value = 1;
            metroSetTrackBar8.Value = 1;
            metroSetTrackBar8.Value = 1;
            metroSetTrackBar8.Value = 1;
            metroSetTrackBar8.Value = 1;
            metroSetTrackBar8.Value = 1;
            metroSetTrackBar8.Value = 1;
        }

        public void DebugInfo()
        {
            treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes[0].Text = mem.ReadFloat((IntPtr)HealthOffset7 + HealthptrOffset7).ToString();
            treeView1.Nodes[0].Nodes[0].Nodes[1].Nodes[0].Text = mem.ReadFloat((IntPtr)MaxHealthOffset7 + MaxHealthptrOffset7).ToString();
            treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes[0].Text = mem.ReadFloat((IntPtr)ShieldCapacityOffset7 + ShieldCapacityptrOffset7).ToString();
            treeView1.Nodes[0].Nodes[1].Nodes[1].Nodes[0].Text = mem.ReadFloat((IntPtr)MaxShieldCapacityOffset7 + MaxShieldCapacityptrOffset7).ToString();
            treeView1.Nodes[0].Nodes[1].Nodes[2].Nodes[0].Text = mem.ReadFloat((IntPtr)ShieldRechargeDelayOffset6 + ShieldRechargeDelayptrOffset6).ToString();
            treeView1.Nodes[0].Nodes[1].Nodes[3].Nodes[0].Text = mem.ReadFloat((IntPtr)ShieldRechargeRateOffset7 + ShieldRechargeRateptrOffset7).ToString();
            treeView1.Nodes[0].Nodes[2].Nodes[0].Nodes[0].Text = mem.ReadInteger((IntPtr)RankEXPOffset7 + RankEXPptrOffset7).ToString();
            treeView1.Nodes[0].Nodes[2].Nodes[1].Nodes[0].Text = mem.ReadInteger((IntPtr)GardianEXPOffset7 + GardianEXPptrOffset7).ToString();
            treeView1.Nodes[0].Nodes[3].Nodes[0].Nodes[0].Text = mem.ReadInteger((IntPtr)PlayerCurrencyOffset7 + MoneyptrOffset).ToString();
            treeView1.Nodes[0].Nodes[3].Nodes[1].Nodes[0].Text = mem.ReadInteger((IntPtr)PlayerCurrencyOffset7 + EDptrOffset).ToString();
            treeView1.Nodes[0].Nodes[4].Nodes[0].Text = mem.ReadInteger((IntPtr)BPSOffset5 + BPSptrOffset5).ToString();
            treeView1.Nodes[0].Nodes[5].Nodes[0].Text = mem.ReadFloat((IntPtr)FOVOffset7 + FOVptrOffset7).ToString();
            treeView1.Nodes[1].Nodes[0].Nodes[0].Nodes[0].Text = mem.ReadFloat((IntPtr)PlayerCorddinatesOffset7 + PlayerXaxisptrOffset).ToString();
            treeView1.Nodes[1].Nodes[0].Nodes[1].Nodes[0].Text = mem.ReadFloat((IntPtr)PlayerCorddinatesOffset7 + PlayerYaxisptrOffset).ToString();
            treeView1.Nodes[1].Nodes[0].Nodes[2].Nodes[0].Text = mem.ReadFloat((IntPtr)PlayerCorddinatesOffset7 + PlayerZaxisptrOffset).ToString();
            treeView1.Nodes[1].Nodes[1].Nodes[0].Nodes[0].Text = mem.ReadFloat((IntPtr)CarCorddinatesOffset7 + CarXptrOffset).ToString();
            treeView1.Nodes[1].Nodes[1].Nodes[1].Nodes[0].Text = mem.ReadFloat((IntPtr)CarCorddinatesOffset7 + 0xC8).ToString();
            treeView1.Nodes[1].Nodes[1].Nodes[2].Nodes[0].Text = mem.ReadFloat((IntPtr)CarCorddinatesOffset7 + CarZptrOffset).ToString();
            treeView1.Nodes[1].Nodes[2].Nodes[0].Nodes[0].Text = mem.ReadFloat((IntPtr)WayCorddinatesOffset7 + WayXaxisptrOffset).ToString();
            treeView1.Nodes[1].Nodes[2].Nodes[1].Nodes[0].Text = mem.ReadFloat((IntPtr)WayCorddinatesOffset7 + WayYaxisptrOffset).ToString();
            treeView1.Nodes[1].Nodes[2].Nodes[2].Nodes[0].Text = mem.ReadFloat((IntPtr)WayCorddinatesOffset7 + WayZaxisptrOffset).ToString();
            treeView1.Nodes[2].Nodes[0].Nodes[0].Text = mem.ReadFloat((IntPtr)WeaponPropertiesOffset7 + AccuracyptrOffset).ToString();
            treeView1.Nodes[2].Nodes[1].Nodes[0].Text = mem.ReadFloat((IntPtr)WeaponPropertiesOffset7 + DamageptrOffset).ToString();
            treeView1.Nodes[2].Nodes[2].Nodes[0].Text = mem.ReadFloat((IntPtr)WeaponPropertiesOffset7 + FRptrOffset).ToString();
            treeView1.Nodes[2].Nodes[3].Nodes[0].Text = mem.ReadInteger((IntPtr)WeaponPropertiesOffset7 + ProjectileptrOffset).ToString();
            treeView1.Nodes[3].Nodes[0].Nodes[0].Nodes[0].Text = mem.ReadFloat((IntPtr)CarPropertiesOffset7 + CarPropertiesBoostptrOffset).ToString();
            treeView1.Nodes[3].Nodes[0].Nodes[1].Nodes[0].Text = mem.ReadFloat((IntPtr)CarPropertiesOffset7 + CarPropertiesMaxBoostptrOffset).ToString();
            treeView1.Nodes[3].Nodes[1].Nodes[0].Nodes[0].Text = mem.ReadFloat((IntPtr)CarPropertiesOffset7 + CarPropertiesHealthptrOffset).ToString();
            treeView1.Nodes[3].Nodes[1].Nodes[1].Nodes[0].Text = mem.ReadFloat((IntPtr)CarPropertiesOffset7 + CarPropertiesMaxHealthptrOffset).ToString();
        }

        public void GetFov()
        {
            FOVOffset1 = mem.ReadUInt64((IntPtr)(FOVpAddress + (UInt64)processes.Modules[0].BaseAddress));
            FOVOffset2 = mem.ReadUInt64((IntPtr)FOVOffset1 + FOVptrOffset1);
            FOVOffset3 = mem.ReadUInt64((IntPtr)FOVOffset2 + FOVptrOffset2);
            FOVOffset4 = mem.ReadUInt64((IntPtr)FOVOffset3 + FOVptrOffset3);
            FOVOffset5 = mem.ReadUInt64((IntPtr)FOVOffset4 + FOVptrOffset4);
            FOVOffset6 = mem.ReadUInt64((IntPtr)FOVOffset5 + FOVptrOffset5);
            FOVOffset7 = mem.ReadUInt64((IntPtr)FOVOffset6 + FOVptrOffset6);
        }

        public void GetHealth()
        {
            HealthOffset1 = mem.ReadUInt64((IntPtr)(HealthpAddress + (UInt64)processes.Modules[0].BaseAddress));
            HealthOffset2 = mem.ReadUInt64((IntPtr)HealthOffset1 + HealthptrOffset1);
            HealthOffset3 = mem.ReadUInt64((IntPtr)HealthOffset2 + HealthptrOffset2);
            HealthOffset4 = mem.ReadUInt64((IntPtr)HealthOffset3 + HealthptrOffset3);
            HealthOffset5 = mem.ReadUInt64((IntPtr)HealthOffset4 + HealthptrOffset4);
            HealthOffset6 = mem.ReadUInt64((IntPtr)HealthOffset5 + HealthptrOffset5);
            HealthOffset7 = mem.ReadUInt64((IntPtr)HealthOffset6 + HealthptrOffset6);
        }

        public void GetMaxHealth()
        {
            MaxHealthOffset1 = mem.ReadUInt64((IntPtr)(MaxHealthpAddress + (UInt64)processes.Modules[0].BaseAddress));
            MaxHealthOffset2 = mem.ReadUInt64((IntPtr)MaxHealthOffset1 + MaxHealthptrOffset1);
            MaxHealthOffset3 = mem.ReadUInt64((IntPtr)MaxHealthOffset2 + MaxHealthptrOffset2);
            MaxHealthOffset4 = mem.ReadUInt64((IntPtr)MaxHealthOffset3 + MaxHealthptrOffset3);
            MaxHealthOffset5 = mem.ReadUInt64((IntPtr)MaxHealthOffset4 + MaxHealthptrOffset4);
            MaxHealthOffset6 = mem.ReadUInt64((IntPtr)MaxHealthOffset5 + MaxHealthptrOffset5);
            MaxHealthOffset7 = mem.ReadUInt64((IntPtr)MaxHealthOffset6 + MaxHealthptrOffset6);
        }

        public void GetShieldCapacity()
        {
            ShieldCapacityOffset1 = mem.ReadUInt64((IntPtr)(ShieldCapacitypAddress + (UInt64)processes.Modules[0].BaseAddress));
            ShieldCapacityOffset2 = mem.ReadUInt64((IntPtr)ShieldCapacityOffset1 + ShieldCapacityptrOffset1);
            ShieldCapacityOffset3 = mem.ReadUInt64((IntPtr)ShieldCapacityOffset2 + ShieldCapacityptrOffset2);
            ShieldCapacityOffset4 = mem.ReadUInt64((IntPtr)ShieldCapacityOffset3 + ShieldCapacityptrOffset3);
            ShieldCapacityOffset5 = mem.ReadUInt64((IntPtr)ShieldCapacityOffset4 + ShieldCapacityptrOffset4);
            ShieldCapacityOffset6 = mem.ReadUInt64((IntPtr)ShieldCapacityOffset5 + ShieldCapacityptrOffset5);
            ShieldCapacityOffset7 = mem.ReadUInt64((IntPtr)ShieldCapacityOffset6 + ShieldCapacityptrOffset6);
        }

        public void GetMaxShieldCapacity()
        {
            MaxShieldCapacityOffset1 = mem.ReadUInt64((IntPtr)(MaxShieldCapacitypAddress + (UInt64)processes.Modules[0].BaseAddress));
            MaxShieldCapacityOffset2 = mem.ReadUInt64((IntPtr)MaxShieldCapacityOffset1 + MaxShieldCapacityptrOffset1);
            MaxShieldCapacityOffset3 = mem.ReadUInt64((IntPtr)MaxShieldCapacityOffset2 + MaxShieldCapacityptrOffset2);
            MaxShieldCapacityOffset4 = mem.ReadUInt64((IntPtr)MaxShieldCapacityOffset3 + MaxShieldCapacityptrOffset3);
            MaxShieldCapacityOffset5 = mem.ReadUInt64((IntPtr)MaxShieldCapacityOffset4 + MaxShieldCapacityptrOffset4);
            MaxShieldCapacityOffset6 = mem.ReadUInt64((IntPtr)MaxShieldCapacityOffset5 + MaxShieldCapacityptrOffset5);
            MaxShieldCapacityOffset7 = mem.ReadUInt64((IntPtr)MaxShieldCapacityOffset6 + MaxShieldCapacityptrOffset6);
        }

        public void GetShieldRechargeDelay()
        {
            ShieldRechargeDelayOffset1 = mem.ReadUInt64((IntPtr)(ShieldRechargeDelaypAddress + (UInt64)processes.Modules[0].BaseAddress));
            ShieldRechargeDelayOffset2 = mem.ReadUInt64((IntPtr)ShieldRechargeDelayOffset1 + ShieldRechargeDelayptrOffset1);
            ShieldRechargeDelayOffset3 = mem.ReadUInt64((IntPtr)ShieldRechargeDelayOffset2 + ShieldRechargeDelayptrOffset2);
            ShieldRechargeDelayOffset4 = mem.ReadUInt64((IntPtr)ShieldRechargeDelayOffset3 + ShieldRechargeDelayptrOffset3);
            ShieldRechargeDelayOffset5 = mem.ReadUInt64((IntPtr)ShieldRechargeDelayOffset4 + ShieldRechargeDelayptrOffset4);
            ShieldRechargeDelayOffset6 = mem.ReadUInt64((IntPtr)ShieldRechargeDelayOffset5 + ShieldRechargeDelayptrOffset5);
        }

        public void GetShieldRechargeRate()
        {
            ShieldRechargeRateOffset1 = mem.ReadUInt64((IntPtr)(ShieldRechargeRatepAddress + (UInt64)processes.Modules[0].BaseAddress));
            ShieldRechargeRateOffset2 = mem.ReadUInt64((IntPtr)ShieldRechargeRateOffset1 + ShieldRechargeRateptrOffset1);
            ShieldRechargeRateOffset3 = mem.ReadUInt64((IntPtr)ShieldRechargeRateOffset2 + ShieldRechargeRateptrOffset2);
            ShieldRechargeRateOffset4 = mem.ReadUInt64((IntPtr)ShieldRechargeRateOffset3 + ShieldRechargeRateptrOffset3);
            ShieldRechargeRateOffset5 = mem.ReadUInt64((IntPtr)ShieldRechargeRateOffset4 + ShieldRechargeRateptrOffset4);
            ShieldRechargeRateOffset6 = mem.ReadUInt64((IntPtr)ShieldRechargeRateOffset5 + ShieldRechargeRateptrOffset5);
            ShieldRechargeRateOffset7 = mem.ReadUInt64((IntPtr)ShieldRechargeRateOffset6 + ShieldRechargeRateptrOffset6);
        }

        public void GetRankEXP()
        {
            RankEXPOffset1 = mem.ReadUInt64((IntPtr)(RankEXPpAddress + (UInt64)processes.Modules[0].BaseAddress));
            RankEXPOffset2 = mem.ReadUInt64((IntPtr)RankEXPOffset1 + RankEXPptrOffset1);
            RankEXPOffset3 = mem.ReadUInt64((IntPtr)RankEXPOffset2 + RankEXPptrOffset2);
            RankEXPOffset4 = mem.ReadUInt64((IntPtr)RankEXPOffset3 + RankEXPptrOffset3);
            RankEXPOffset5 = mem.ReadUInt64((IntPtr)RankEXPOffset4 + RankEXPptrOffset4);
            RankEXPOffset6 = mem.ReadUInt64((IntPtr)RankEXPOffset5 + RankEXPptrOffset5);
            RankEXPOffset7 = mem.ReadUInt64((IntPtr)RankEXPOffset6 + RankEXPptrOffset6);
        }

        public void GetGardianEXP()
        {
            GardianEXPOffset1 = mem.ReadUInt64((IntPtr)(GardianEXPpAddress + (UInt64)processes.Modules[0].BaseAddress));
            GardianEXPOffset2 = mem.ReadUInt64((IntPtr)GardianEXPOffset1 + GardianEXPptrOffset1);
            GardianEXPOffset3 = mem.ReadUInt64((IntPtr)GardianEXPOffset2 + GardianEXPptrOffset2);
            GardianEXPOffset4 = mem.ReadUInt64((IntPtr)GardianEXPOffset3 + GardianEXPptrOffset3);
            GardianEXPOffset5 = mem.ReadUInt64((IntPtr)GardianEXPOffset4 + GardianEXPptrOffset4);
            GardianEXPOffset6 = mem.ReadUInt64((IntPtr)GardianEXPOffset5 + GardianEXPptrOffset5);
            GardianEXPOffset7 = mem.ReadUInt64((IntPtr)GardianEXPOffset6 + GardianEXPptrOffset6);
        }

        public void GetPlayerCorddinates()
        {
            PlayerCorddinatesOffset1 = mem.ReadUInt64((IntPtr)(PlayerCorddinatespAddress + (UInt64)processes.Modules[0].BaseAddress));
            PlayerCorddinatesOffset2 = mem.ReadUInt64((IntPtr)PlayerCorddinatesOffset1 + PlayerCorddinatesptrOffset1);
            PlayerCorddinatesOffset3 = mem.ReadUInt64((IntPtr)PlayerCorddinatesOffset2 + PlayerCorddinatesptrOffset2);
            PlayerCorddinatesOffset4 = mem.ReadUInt64((IntPtr)PlayerCorddinatesOffset3 + PlayerCorddinatesptrOffset3);
            PlayerCorddinatesOffset5 = mem.ReadUInt64((IntPtr)PlayerCorddinatesOffset4 + PlayerCorddinatesptrOffset4);
            PlayerCorddinatesOffset6 = mem.ReadUInt64((IntPtr)PlayerCorddinatesOffset5 + PlayerCorddinatesptrOffset5);
            PlayerCorddinatesOffset7 = mem.ReadUInt64((IntPtr)PlayerCorddinatesOffset6 + PlayerCorddinatesptrOffset6);
        }

        public void GetPlayerCurrency()
        {
            PlayerCurrencyOffset1 = mem.ReadUInt64((IntPtr)(PlayerCurrencypAddress + (UInt64)processes.Modules[0].BaseAddress));
            PlayerCurrencyOffset2 = mem.ReadUInt64((IntPtr)PlayerCurrencyOffset1 + PlayerCurrencyptrOffset1);
            PlayerCurrencyOffset3 = mem.ReadUInt64((IntPtr)PlayerCurrencyOffset2 + PlayerCurrencyptrOffset2);
            PlayerCurrencyOffset4 = mem.ReadUInt64((IntPtr)PlayerCurrencyOffset3 + PlayerCurrencyptrOffset3);
            PlayerCurrencyOffset5 = mem.ReadUInt64((IntPtr)PlayerCurrencyOffset4 + PlayerCurrencyptrOffset4);
            PlayerCurrencyOffset6 = mem.ReadUInt64((IntPtr)PlayerCurrencyOffset5 + PlayerCurrencyptrOffset5);
            PlayerCurrencyOffset7 = mem.ReadUInt64((IntPtr)PlayerCurrencyOffset6 + PlayerCurrencyptrOffset6);
        }

        public void GetWayCorddinates()
        {
            WayCorddinatesOffset1 = mem.ReadUInt64((IntPtr)(WayCorddinatespAddress + (UInt64)processes.Modules[0].BaseAddress));
            WayCorddinatesOffset2 = mem.ReadUInt64((IntPtr)WayCorddinatesOffset1 + WayCorddinatesptrOffset1);
            WayCorddinatesOffset3 = mem.ReadUInt64((IntPtr)WayCorddinatesOffset2 + WayCorddinatesptrOffset2);
            WayCorddinatesOffset4 = mem.ReadUInt64((IntPtr)WayCorddinatesOffset3 + WayCorddinatesptrOffset3);
            WayCorddinatesOffset5 = mem.ReadUInt64((IntPtr)WayCorddinatesOffset4 + WayCorddinatesptrOffset4);
            WayCorddinatesOffset6 = mem.ReadUInt64((IntPtr)WayCorddinatesOffset5 + WayCorddinatesptrOffset5);
            WayCorddinatesOffset7 = mem.ReadUInt64((IntPtr)WayCorddinatesOffset6 + WayCorddinatesptrOffset6);
        }

        public void GetBackpackSpace()
        {
            BPSOffset1 = mem.ReadUInt64((IntPtr)(BPSpAddress + (UInt64)processes.Modules[0].BaseAddress));
            BPSOffset2 = mem.ReadUInt64((IntPtr)BPSOffset1 + BPSptrOffset1);
            BPSOffset3 = mem.ReadUInt64((IntPtr)BPSOffset2 + BPSptrOffset2);
            BPSOffset4 = mem.ReadUInt64((IntPtr)BPSOffset3 + BPSptrOffset3);
            BPSOffset5 = mem.ReadUInt64((IntPtr)BPSOffset4 + BPSptrOffset4);
        }

        public void GetWeaponProperties()
        {
            WeaponPropertiesOffset1 = mem.ReadUInt64((IntPtr)(WeaponPropertiespAddress + (UInt64)processes.Modules[0].BaseAddress));
            WeaponPropertiesOffset2 = mem.ReadUInt64((IntPtr)WeaponPropertiesOffset1 + WeaponPropertiesptrOffset1);
            WeaponPropertiesOffset3 = mem.ReadUInt64((IntPtr)WeaponPropertiesOffset2 + WeaponPropertiesptrOffset2);
            WeaponPropertiesOffset4 = mem.ReadUInt64((IntPtr)WeaponPropertiesOffset3 + WeaponPropertiesptrOffset3);
            WeaponPropertiesOffset5 = mem.ReadUInt64((IntPtr)WeaponPropertiesOffset4 + WeaponPropertiesptrOffset4);
            WeaponPropertiesOffset6 = mem.ReadUInt64((IntPtr)WeaponPropertiesOffset5 + WeaponPropertiesptrOffset5);
            WeaponPropertiesOffset7 = mem.ReadUInt64((IntPtr)WeaponPropertiesOffset6 + WeaponPropertiesptrOffset6);
        }

        public void GetCarCorrdinates()
        {
            CarCorddinatesOffset1 = mem.ReadUInt64((IntPtr)(CarCorddinatespAddress + (UInt64)processes.Modules[0].BaseAddress));
            CarCorddinatesOffset2 = mem.ReadUInt64((IntPtr)CarCorddinatesOffset1 + CarCorddinatesptrOffset1);
            CarCorddinatesOffset3 = mem.ReadUInt64((IntPtr)CarCorddinatesOffset2 + CarCorddinatesptrOffset2);
            CarCorddinatesOffset4 = mem.ReadUInt64((IntPtr)CarCorddinatesOffset3 + CarCorddinatesptrOffset3);
            CarCorddinatesOffset5 = mem.ReadUInt64((IntPtr)CarCorddinatesOffset4 + CarCorddinatesptrOffset4);
            CarCorddinatesOffset6 = mem.ReadUInt64((IntPtr)CarCorddinatesOffset5 + CarCorddinatesptrOffset5);
            CarCorddinatesOffset7 = mem.ReadUInt64((IntPtr)CarCorddinatesOffset6 + CarCorddinatesptrOffset6);
        }

        public void GetCarProperties()
        {
            CarPropertiesOffset1 = mem.ReadUInt64((IntPtr)(CarPropertiespAddress + (UInt64)processes.Modules[0].BaseAddress));
            CarPropertiesOffset2 = mem.ReadUInt64((IntPtr)CarPropertiesOffset1 + CarPropertiesptrOffset1);
            CarPropertiesOffset3 = mem.ReadUInt64((IntPtr)CarPropertiesOffset2 + CarPropertiesptrOffset2);
            CarPropertiesOffset4 = mem.ReadUInt64((IntPtr)CarPropertiesOffset3 + CarPropertiesptrOffset3);
            CarPropertiesOffset5 = mem.ReadUInt64((IntPtr)CarPropertiesOffset4 + CarPropertiesptrOffset4);
            CarPropertiesOffset6 = mem.ReadUInt64((IntPtr)CarPropertiesOffset5 + CarPropertiesptrOffset5);
            CarPropertiesOffset7 = mem.ReadUInt64((IntPtr)CarPropertiesOffset6 + CarPropertiesptrOffset6);
        }

        public void GetMainText()
        {
            MainTextOffset1 = mem.ReadUInt64((IntPtr)(MainTextpAddress + (UInt64)processes.Modules[0].BaseAddress));
            MainTextOffset2 = mem.ReadUInt64((IntPtr)MainTextOffset1 + MainTextptrOffset1);
            MainTextOffset3 = mem.ReadUInt64((IntPtr)MainTextOffset2 + MainTextptrOffset2);
            MainTextOffset4 = mem.ReadUInt64((IntPtr)MainTextOffset3 + MainTextptrOffset3);
            MainTextOffset5 = mem.ReadUInt64((IntPtr)MainTextOffset4 + MainTextptrOffset4);
            MainTextOffset6 = mem.ReadUInt64((IntPtr)MainTextOffset5 + MainTextptrOffset5);
        }

        public void GetInText()
        {
            InTextOffset1 = mem.ReadUInt64((IntPtr)(InTextpAddress + (UInt64)processes.Modules[0].BaseAddress));
            InTextOffset2 = mem.ReadUInt64((IntPtr)InTextOffset1 + InTextptrOffset1);
            InTextOffset3 = mem.ReadUInt64((IntPtr)InTextOffset2 + InTextptrOffset2);
            InTextOffset4 = mem.ReadUInt64((IntPtr)InTextOffset3 + InTextptrOffset3);
            InTextOffset5 = mem.ReadUInt64((IntPtr)InTextOffset4 + InTextptrOffset4);
            InTextOffset6 = mem.ReadUInt64((IntPtr)InTextOffset5 + InTextptrOffset5);
            InTextOffset7 = mem.ReadUInt64((IntPtr)InTextOffset6 + InTextptrOffset6);

        }

        private void metroSetLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroSetTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroSetTrackBar1_Scroll(object sender)
        {
            metroSetLabel9.Text = metroSetTrackBar1.Value.ToString();
            mem.WriteFloat((IntPtr)HealthOffset7 + HealthptrOffset7, (float)metroSetTrackBar1.Value);
        }

        private void metroSetTrackBar3_Scroll(object sender)
        {
            metroSetLabel11.Text = metroSetTrackBar3.Value.ToString();
            mem.WriteFloat((IntPtr)ShieldCapacityOffset7 + ShieldCapacityptrOffset7, (float)metroSetTrackBar3.Value);
        }

        private void metroSetTrackBar5_Scroll(object sender)
        {
            metroSetLabel13.Text = metroSetTrackBar5.Value.ToString();
            mem.WriteFloat((IntPtr)ShieldRechargeDelayOffset6 + ShieldRechargeDelayptrOffset6, (float)metroSetTrackBar5.Value);
        }

        private void metroSetTrackBar6_Scroll(object sender)
        {
            metroSetLabel14.Text = metroSetTrackBar6.Value.ToString();
            mem.WriteFloat((IntPtr)ShieldRechargeRateOffset7 + ShieldRechargeRateptrOffset7, (float)metroSetTrackBar6.Value);
        }

        private void metroSetTrackBar7_Scroll(object sender)
        {
            metroSetLabel15.Text = metroSetTrackBar7.Value.ToString();
            mem.WriteFloat((IntPtr)FOVOffset7 + FOVptrOffset7, (float)metroSetTrackBar7.Value);
        }

        private void metroSetButton2_Click(object sender, EventArgs e)
        {
            int value = int.Parse(metroSetTextBox1.Text);
            mem.WriteFloat((IntPtr)MaxHealthOffset7 + MaxHealthptrOffset7, (float)value);
        }

        private void metroSetButton3_Click(object sender, EventArgs e)
        {
            int value = int.Parse(metroSetTextBox2.Text);
            mem.WriteFloat((IntPtr)MaxShieldCapacityOffset7 + MaxShieldCapacityptrOffset7, (float)value);
        }

        private void metroSetButton4_Click(object sender, EventArgs e)
        {
            int value = int.Parse(metroSetTextBox3.Text);
            mem.WriteInteger((IntPtr)PlayerCurrencyOffset7 + MoneyptrOffset, value);
        }

        private void metroSetButton5_Click(object sender, EventArgs e)
        {
            int value = int.Parse(metroSetTextBox4.Text);
            mem.WriteInteger((IntPtr)PlayerCurrencyOffset7 + EDptrOffset, value);
        }

        private void metroSetButton6_Click(object sender, EventArgs e)
        {
            float Z = mem.ReadFloat((IntPtr)WayCorddinatesOffset7 + WayZaxisptrOffset);
            float Y = mem.ReadFloat((IntPtr)WayCorddinatesOffset7 + WayYaxisptrOffset);
            float X = mem.ReadFloat((IntPtr)WayCorddinatesOffset7 + WayXaxisptrOffset);
            mem.WriteFloat((IntPtr)PlayerCorddinatesOffset7 + PlayerZaxisptrOffset, Z);
            mem.WriteFloat((IntPtr)PlayerCorddinatesOffset7 + PlayerYaxisptrOffset, Y);
            mem.WriteFloat((IntPtr)PlayerCorddinatesOffset7 + PlayerXaxisptrOffset, X);
        }

        private void metroSetButton7_Click(object sender, EventArgs e)
        {
            int value = int.Parse(metroSetTextBox5.Text);
            mem.WriteInteger((IntPtr)BPSOffset5 + BPSptrOffset5, value);
        }

        private void metroSetTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void metroSetButton8_Click(object sender, EventArgs e)
        {
            int value = int.Parse(metroSetTextBox6.Text);
            mem.WriteInteger((IntPtr)WeaponPropertiesOffset7 + ProjectileptrOffset, value);
        }

        private void metroSetButton9_Click(object sender, EventArgs e)
        {
            int value = int.Parse(metroSetTextBox7.Text);
            mem.WriteFloat((IntPtr)WeaponPropertiesOffset7 + DamageptrOffset, (float)value);
        }

        private void metroSetButton10_Click(object sender, EventArgs e)
        {
            int value = int.Parse(metroSetTextBox8.Text);
            mem.WriteFloat((IntPtr)WeaponPropertiesOffset7 + AccuracyptrOffset, (float)value);
        }

        private void metroSetButton11_Click(object sender, EventArgs e)
        {
            int value = int.Parse(metroSetTextBox9.Text);
            mem.WriteFloat((IntPtr)WeaponPropertiesOffset7 + FRptrOffset, (float)value);
        }

        private void metroSetTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                this.Height = 507;
                DebugPage = 1;
            }
            else
            {
                this.Height = 295;
                DebugPage = 0;
            }
        }

        private void metroSetDivider3_Click(object sender, EventArgs e)
        {

        }

        private void metroSetButton16_Click(object sender, EventArgs e)
        {
            float Z = mem.ReadFloat((IntPtr)CarCorddinatesOffset7 + CarZptrOffset);
            float Y = mem.ReadFloat((IntPtr)CarCorddinatesOffset7 + CarYptrOffset);
            float X = mem.ReadFloat((IntPtr)CarCorddinatesOffset7 + CarXptrOffset);
            mem.WriteFloat((IntPtr)PlayerCorddinatesOffset7 + PlayerZaxisptrOffset, Z + (200));
            mem.WriteFloat((IntPtr)PlayerCorddinatesOffset7 + PlayerYaxisptrOffset, Y + (200));
            mem.WriteFloat((IntPtr)PlayerCorddinatesOffset7 + PlayerXaxisptrOffset, X + (200));
        }

        private void metroSetButton17_Click(object sender, EventArgs e)
        {
            float Z = mem.ReadFloat((IntPtr)PlayerCorddinatesOffset7 + PlayerZaxisptrOffset);
            float Y = mem.ReadFloat((IntPtr)PlayerCorddinatesOffset7 + PlayerYaxisptrOffset);
            float X = mem.ReadFloat((IntPtr)PlayerCorddinatesOffset7 + PlayerXaxisptrOffset);
            mem.WriteFloat((IntPtr)CarCorddinatesOffset7 + CarZptrOffset, Z + (200));
            mem.WriteFloat((IntPtr)CarCorddinatesOffset7 + CarYptrOffset, Y + (200));
            mem.WriteFloat((IntPtr)CarCorddinatesOffset7 + CarXptrOffset, X + (200));
        }

        private void metroSetTrackBar4_Scroll(object sender)
        {
            int value = metroSetTrackBar4.Value;
            mem.WriteFloat((IntPtr)CarPropertiesOffset7 + CarPropertiesBoostptrOffset, (float)value);
        }

        private void metroSetButton18_Click(object sender, EventArgs e)
        {
            int value = int.Parse(metroSetTextBox10.Text);
            mem.WriteFloat((IntPtr)CarPropertiesOffset7 + CarPropertiesMaxBoostptrOffset, (float)value);
        }

        private void metroSetTrackBar2_Scroll(object sender)
        {
            int value = metroSetTrackBar2.Value;
            mem.WriteFloat((IntPtr)CarPropertiesOffset7 + CarPropertiesHealthptrOffset, (float)value);
        }

        private void metroSetButton19_Click(object sender, EventArgs e)
        {
            int value = int.Parse(metroSetTextBox11.Text);
            mem.WriteFloat((IntPtr)CarPropertiesOffset7 + CarPropertiesMaxHealthptrOffset, (float)value);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                GetCarCorrdinates();
                mem.WriteFloat((IntPtr)CarCorddinatesOffset7 + CarYptrOffset,(float)4000.000);
                mem.WriteFloat((IntPtr)CarCorddinatesOffset7 + 0xC8,(float)4000.000);
                Thread.Sleep(25);
            }
        }

        private void metroSetSwitch1_SwitchedChanged(object sender)
        {
            byte[] playBytes = { 0x4F, 0x00, 0x58, 0x00, 0x59, 0x00, 0x5F, 0x00 };
            byte[] socialBytes = { 0x50, 0x00, 0x52, 0x00, 0x49, 0x00, 0x56, 0x00, 0x41, 0x00, 0x54, 0x00, 0x45, 0x00 };
            byte[] optionBytes = { 0x54, 0x00, 0x52, 0x00, 0x41, 0x00, 0x49, 0x00, 0x4E, 0x00, 0x45, 0x00, 0x52, 0x00 };
            byte[] qgBytes = { 0x42, 0x00, 0x49, 0x00, 0x49, 0x00, 0x43, 0x00, 0x48, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            mem.WriteByteArray((IntPtr)MainTextOffset6 + MainPlayptrOffset, playBytes);
            mem.WriteByteArray((IntPtr)MainTextOffset6 + MainSocialptrOffset, socialBytes);
            mem.WriteByteArray((IntPtr)MainTextOffset6 + MainOptionsptrOffset, optionBytes);
            mem.WriteByteArray((IntPtr)MainTextOffset6 + MainQGptrOffset, qgBytes);
        }
    }
}
