using Microsoft.VisualBasic.FileIO;
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
using System.Xml.Linq;

namespace Azur_Lane_Helper
{
    public partial class Ships : Form
    {
        public Ships()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public class Ship
        {
            public string ship_name { get; set; } = "";
            public string type { get; set; } = "";
            public string rarity { get; set; } = "";
            public string nation { get; set; } = "";
            public int HP { get; set; } = 0;
            public int FP { get; set; } = 0;
            public int TRP { get; set; } = 0;
            public int AVI { get; set; } = 0;
            public int AA { get; set; } = 0;
            public int RLD { get; set; } = 0;
            public int EVA { get; set; } = 0;
            public string Armor { get; set; } = "";
            public int SPD { get; set; } = 0;
            public int ACC { get; set; } = 0;
            public int LCK { get; set; } = 0;
            public int ASW { get; set; } = 0;
            public int OIL { get; set; } = 0;
            public int OXY { get; set; } = 0;
            public int AMMO { get; set; } = 0;

            public string GetImagePath(string name)
            {
                name = name.Replace(" ", "_");
                name = name.Replace("µ", "mu");
                string path_to_images = "Resources/Ships/Standard Ships";
                string filename = name + ".png";
                string image_path = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, path_to_images, filename);
                if (File.Exists(image_path))
                    return image_path;
                else
                    return null;
            }

            public string GetImagePathKai(string name)
            {
                name = name.Replace(" ", "_");
                name = name.Replace("µ", "mu");
                string path_to_images = "Resources/Ships/Retrofit Ships";
                string filename = name + ".png";
                string image_path = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, path_to_images, filename);
                if (File.Exists(image_path))
                    return image_path;
                else
                    return null;
            }

            public string GetImagePathPR(string name)
            {
                name = name.Replace(" ", "_");
                name = name.Replace("µ", "mu");
                string path_to_images = "Resources/Ships/PR Ships";
                string filename = name + ".png";
                string image_path = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, path_to_images, filename);
                if (File.Exists(image_path))
                    return image_path;
                else
                    return null;
            }

            public string GetImagePathMETA(string name)
            {
                name = name.Replace(" ", "_");
                name = name.Replace("µ", "mu");
                string path_to_images = "Resources/Ships/META Ships";
                string filename = name + ".png";
                string image_path = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, path_to_images, filename);
                if (File.Exists(image_path))
                    return image_path;
                else
                    return null;
            }

            public string GetImagePathCollab(string name)
            {
                name = name.Replace(" ", "_");
                name = name.Replace("µ", "mu");
                string path_to_images = "Resources/Ships/Collab Ships";
                string filename = name + ".png";
                string image_path = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, path_to_images, filename);
                if (File.Exists(image_path))
                    return image_path;
                else
                    return null;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;

                string filePath = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, "ShipInfo", "Azur Lane - Standard Ships.csv");
                string shipName = comboBox1.SelectedItem.ToString();

                using (TextFieldParser parser = new TextFieldParser(filePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.ReadLine();
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        if (fields[2] == shipName)
                        {
                            string t = fields[1];
                            string r = fields[3];
                            int hp = int.Parse(fields[4]);
                            int fp = int.Parse(fields[5]);
                            int trp = int.Parse(fields[6]);
                            int avi = int.Parse(fields[7]);
                            int aa = int.Parse(fields[8]);
                            int rld = int.Parse(fields[9]);
                            int eva = int.Parse(fields[10]);
                            string armor = fields[11];
                            int spd = int.Parse(fields[12]);
                            int acc = int.Parse(fields[13]);
                            int lck = int.Parse(fields[14]);
                            int asw = int.Parse(fields[15]);
                            int oil = int.Parse(fields[16]);
                            int oxy = int.Parse(fields[17]);
                            int ammo = int.Parse(fields[18]);
                            string n = fields[19];

                            Ship ship = new Ship();
                            ship.ship_name = shipName;
                            ship.rarity = r;
                            ship.type = t;
                            ship.nation = n;
                            ship.HP = hp;
                            ship.FP = fp;
                            ship.TRP = trp;
                            ship.AVI = avi;
                            ship.AA = aa;
                            ship.RLD = rld;
                            ship.EVA = eva;
                            ship.Armor = armor;
                            ship.SPD = spd;
                            ship.ACC = acc;
                            ship.LCK = lck;
                            ship.ASW = asw;
                            ship.OIL = oil;
                            ship.OXY = oxy;
                            ship.AMMO = ammo;

                            ShipName.Text = ship.ship_name;
                            Nation.Image = Image.FromFile(Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, "Resources/Icons/Nations/", ship.nation + ".png"));
                            TypeIcon.Image = Image.FromFile(Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, "Resources/Icons/Ship Types/", ship.type + ".png"));
                            Rarity.Text = ship.rarity;
                            Health.Text = ship.HP.ToString();
                            Firepower.Text = ship.FP.ToString();
                            Torpedo.Text = ship.TRP.ToString();
                            Aviation.Text = ship.AVI.ToString();
                            AntiAir.Text = ship.AA.ToString();
                            Reload.Text = ship.RLD.ToString();
                            Evasion.Text = ship.EVA.ToString();
                            Armor.Text = ship.Armor;
                            Speed.Text = ship.SPD.ToString();
                            Accuracy.Text = ship.ACC.ToString();
                            Luck.Text = ship.LCK.ToString();
                            ASW.Text = ship.ASW.ToString();
                            Oil.Text = ship.OIL.ToString();
                            Oxygen.Text = ship.OXY.ToString();
                            Ammo.Text = ship.AMMO.ToString();
                            switch (ship.rarity)
                            {
                                case "Common":
                                    Rarity.ForeColor = Color.LightGray;
                                    break;
                                case "Rare":
                                    Rarity.ForeColor = Color.Cyan;
                                    break;
                                case "Elite":
                                    Rarity.ForeColor = Color.FromArgb(227, 3, 252);
                                    break;
                                case "Super Rare":
                                    Rarity.ForeColor = Color.Gold;
                                    break;
                                case "Ultra Rare":
                                    Rarity.ForeColor = Color.Pink;
                                    break;
                            }
                            switch (ship.type)
                            {
                                case "DD":
                                    Type.Text = "Destroyer";
                                    break;
                                case "DDG":
                                    Type.Text = "Guided-missile Destroyer";
                                    break;
                                case "CL":
                                    Type.Text = "Light Cruiser";
                                    break;
                                case "CA":
                                    Type.Text = "Heavy Cruiser";
                                    break;
                                case "CB":
                                    Type.Text = "Large Cruiser";
                                    break;
                                case "BC":
                                    Type.Text = "Battleship";
                                    break;
                                case "BB":
                                    Type.Text = "Battleship";
                                    break;
                                case "CV":
                                    Type.Text = "Aircraft Carrier";
                                    break;
                                case "CVL":
                                    Type.Text = "Light Aircraft Carrier";
                                    break;
                                case "AR":
                                    Type.Text = "Repair Ship";
                                    break;
                                case "SS":
                                    Type.Text = "Submarine";
                                    break;
                                case "SSV":
                                    Type.Text = "Submarine Carrier";
                                    break;
                                case "IX":
                                    Type.Text = "Frigate";
                                    break;
                                case "BM":
                                    Type.Text = "Monitor";
                                    break;
                                case "BBV":
                                    Type.Text = "Aviation Battleship";
                                    break;
                                case "AE":
                                    Type.Text = "Ammunition Ship";
                                    break;
                                default:
                                    Type.Text = "Hull Type";
                                    break;
                            }
                            if (File.Exists(ship.GetImagePath(shipName)))
                                ShipImage.Image = Image.FromFile(ship.GetImagePath(shipName));
                            break;
                        }
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                comboBox1.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;

                string filePath = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, "ShipInfo", "Azur Lane - Retrofit.csv");
                string shipName = comboBox2.SelectedItem.ToString();

                using (TextFieldParser parser = new TextFieldParser(filePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.ReadLine();
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        if (fields[2] == shipName)
                        {
                            string t = fields[1];
                            string r = fields[3];
                            int hp = int.Parse(fields[4]);
                            int fp = int.Parse(fields[5]);
                            int trp = int.Parse(fields[6]);
                            int avi = int.Parse(fields[7]);
                            int aa = int.Parse(fields[8]);
                            int rld = int.Parse(fields[9]);
                            int eva = int.Parse(fields[10]);
                            string armor = fields[11];
                            int spd = int.Parse(fields[12]);
                            int acc = int.Parse(fields[13]);
                            int lck = int.Parse(fields[14]);
                            int asw = int.Parse(fields[15]);
                            int oil = int.Parse(fields[16]);
                            int oxy = int.Parse(fields[17]);
                            int ammo = int.Parse(fields[18]);
                            string n = fields[19];

                            Ship ship = new Ship();
                            ship.ship_name = shipName;
                            ship.rarity = r;
                            ship.type = t;
                            ship.nation = n;
                            ship.HP = hp;
                            ship.FP = fp;
                            ship.TRP = trp;
                            ship.AVI = avi;
                            ship.AA = aa;
                            ship.RLD = rld;
                            ship.EVA = eva;
                            ship.Armor = armor;
                            ship.SPD = spd;
                            ship.ACC = acc;
                            ship.LCK = lck;
                            ship.ASW = asw;
                            ship.OIL = oil;
                            ship.OXY = oxy;
                            ship.AMMO = ammo;

                            ShipName.Text = ship.ship_name;
                            Nation.Image = Image.FromFile(Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, "Resources/Icons/Nations/", ship.nation + ".png"));
                            TypeIcon.Image = Image.FromFile(Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, "Resources/Icons/Ship Types/", ship.type + ".png"));
                            Rarity.Text = ship.rarity;
                            Health.Text = ship.HP.ToString();
                            Firepower.Text = ship.FP.ToString();
                            Torpedo.Text = ship.TRP.ToString();
                            Aviation.Text = ship.AVI.ToString();
                            AntiAir.Text = ship.AA.ToString();
                            Reload.Text = ship.RLD.ToString();
                            Evasion.Text = ship.EVA.ToString();
                            Armor.Text = ship.Armor;
                            Speed.Text = ship.SPD.ToString();
                            Accuracy.Text = ship.ACC.ToString();
                            Luck.Text = ship.LCK.ToString();
                            ASW.Text = ship.ASW.ToString();
                            Oil.Text = ship.OIL.ToString();
                            Oxygen.Text = ship.OXY.ToString();
                            Ammo.Text = ship.AMMO.ToString();
                            switch (ship.rarity)
                            {
                                case "Common":
                                    Rarity.ForeColor = Color.LightGray;
                                    break;
                                case "Rare":
                                    Rarity.ForeColor = Color.Cyan;
                                    break;
                                case "Elite":
                                    Rarity.ForeColor = Color.FromArgb(227, 3, 252);
                                    break;
                                case "Super Rare":
                                    Rarity.ForeColor = Color.Gold;
                                    break;
                                case "Ultra Rare":
                                    Rarity.ForeColor = Color.Pink;
                                    break;
                            }
                            switch (ship.type)
                            {
                                case "DD":
                                    Type.Text = "Destroyer";
                                    break;
                                case "DDG":
                                    Type.Text = "Guided-missile Destroyer";
                                    break;
                                case "CL":
                                    Type.Text = "Light Cruiser";
                                    break;
                                case "CA":
                                    Type.Text = "Heavy Cruiser";
                                    break;
                                case "CB":
                                    Type.Text = "Large Cruiser";
                                    break;
                                case "BC":
                                    Type.Text = "Battleship";
                                    break;
                                case "BB":
                                    Type.Text = "Battleship";
                                    break;
                                case "CV":
                                    Type.Text = "Aircraft Carrier";
                                    break;
                                case "CVL":
                                    Type.Text = "Light Aircraft Carrier";
                                    break;
                                case "AR":
                                    Type.Text = "Repair Ship";
                                    break;
                                case "SS":
                                    Type.Text = "Submarine";
                                    break;
                                case "SSV":
                                    Type.Text = "Submarine Carrier";
                                    break;
                                case "IX":
                                    Type.Text = "Frigate";
                                    break;
                                case "BM":
                                    Type.Text = "Monitor";
                                    break;
                                case "BBV":
                                    Type.Text = "Aviation Battleship";
                                    break;
                                case "AE":
                                    Type.Text = "Ammunition Ship";
                                    break;
                                default:
                                    Type.Text = "Hull Type";
                                    break;
                            }
                            if (File.Exists(ship.GetImagePathKai(shipName)))
                                ShipImage.Image = Image.FromFile(ship.GetImagePathKai(shipName));
                            break;
                        }
                    }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != -1)
            {
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;

                string filePath = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, "ShipInfo", "Azur Lane - PR.csv");
                string shipName = comboBox3.SelectedItem.ToString();

                using (TextFieldParser parser = new TextFieldParser(filePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.ReadLine();
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        if (fields[2] == shipName)
                        {
                            string t = fields[1];
                            string r = fields[3];
                            int hp = int.Parse(fields[4]);
                            int fp = int.Parse(fields[5]);
                            int trp = int.Parse(fields[6]);
                            int avi = int.Parse(fields[7]);
                            int aa = int.Parse(fields[8]);
                            int rld = int.Parse(fields[9]);
                            int eva = int.Parse(fields[10]);
                            string armor = fields[11];
                            int spd = int.Parse(fields[12]);
                            int acc = int.Parse(fields[13]);
                            int lck = int.Parse(fields[14]);
                            int asw = int.Parse(fields[15]);
                            int oil = int.Parse(fields[16]);
                            int oxy = int.Parse(fields[17]);
                            int ammo = int.Parse(fields[18]);
                            string n = fields[19];

                            Ship ship = new Ship();
                            ship.ship_name = shipName;
                            ship.rarity = r;
                            ship.type = t;
                            ship.nation = n;
                            ship.HP = hp;
                            ship.FP = fp;
                            ship.TRP = trp;
                            ship.AVI = avi;
                            ship.AA = aa;
                            ship.RLD = rld;
                            ship.EVA = eva;
                            ship.Armor = armor;
                            ship.SPD = spd;
                            ship.ACC = acc;
                            ship.LCK = lck;
                            ship.ASW = asw;
                            ship.OIL = oil;
                            ship.OXY = oxy;
                            ship.AMMO = ammo;

                            ShipName.Text = ship.ship_name;
                            Nation.Image = Image.FromFile(Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, "Resources/Icons/Nations/", ship.nation + ".png"));
                            TypeIcon.Image = Image.FromFile(Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, "Resources/Icons/Ship Types/", ship.type + ".png"));
                            Rarity.Text = ship.rarity;
                            Health.Text = ship.HP.ToString();
                            Firepower.Text = ship.FP.ToString();
                            Torpedo.Text = ship.TRP.ToString();
                            Aviation.Text = ship.AVI.ToString();
                            AntiAir.Text = ship.AA.ToString();
                            Reload.Text = ship.RLD.ToString();
                            Evasion.Text = ship.EVA.ToString();
                            Armor.Text = ship.Armor;
                            Speed.Text = ship.SPD.ToString();
                            Accuracy.Text = ship.ACC.ToString();
                            Luck.Text = ship.LCK.ToString();
                            ASW.Text = ship.ASW.ToString();
                            Oil.Text = ship.OIL.ToString();
                            Oxygen.Text = ship.OXY.ToString();
                            Ammo.Text = ship.AMMO.ToString();
                            switch (ship.rarity)
                            {
                                case "Priority":
                                    Rarity.ForeColor = Color.Gold;
                                    break;
                                case "Decisive":
                                    Rarity.ForeColor = Color.Pink;
                                    break;
                            }
                            switch (ship.type)
                            {
                                case "DD":
                                    Type.Text = "Destroyer";
                                    break;
                                case "DDG":
                                    Type.Text = "Guided-missile Destroyer";
                                    break;
                                case "CL":
                                    Type.Text = "Light Cruiser";
                                    break;
                                case "CA":
                                    Type.Text = "Heavy Cruiser";
                                    break;
                                case "CB":
                                    Type.Text = "Large Cruiser";
                                    break;
                                case "BC":
                                    Type.Text = "Battleship";
                                    break;
                                case "BB":
                                    Type.Text = "Battleship";
                                    break;
                                case "CV":
                                    Type.Text = "Aircraft Carrier";
                                    break;
                                case "CVL":
                                    Type.Text = "Light Aircraft Carrier";
                                    break;
                                case "AR":
                                    Type.Text = "Repair Ship";
                                    break;
                                case "SS":
                                    Type.Text = "Submarine";
                                    break;
                                case "SSV":
                                    Type.Text = "Submarine Carrier";
                                    break;
                                case "IX":
                                    Type.Text = "Frigate";
                                    break;
                                case "BM":
                                    Type.Text = "Monitor";
                                    break;
                                case "BBV":
                                    Type.Text = "Aviation Battleship";
                                    break;
                                case "AE":
                                    Type.Text = "Ammunition Ship";
                                    break;
                                default:
                                    Type.Text = "Hull Type";
                                    break;
                            }
                            if (File.Exists(ship.GetImagePathPR(shipName)))
                                ShipImage.Image = Image.FromFile(ship.GetImagePathPR(shipName));
                            break;
                        }
                    }
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex != -1)
            {
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;

                string filePath = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, "ShipInfo", "Azur Lane - META.csv");
                string shipName = comboBox4.SelectedItem.ToString();

                using (TextFieldParser parser = new TextFieldParser(filePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.ReadLine();
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        if (fields[2] == shipName)
                        {
                            string t = fields[1];
                            string r = fields[3];
                            int hp = int.Parse(fields[4]);
                            int fp = int.Parse(fields[5]);
                            int trp = int.Parse(fields[6]);
                            int avi = int.Parse(fields[7]);
                            int aa = int.Parse(fields[8]);
                            int rld = int.Parse(fields[9]);
                            int eva = int.Parse(fields[10]);
                            string armor = fields[11];
                            int spd = int.Parse(fields[12]);
                            int acc = int.Parse(fields[13]);
                            int lck = int.Parse(fields[14]);
                            int asw = int.Parse(fields[15]);
                            int oil = int.Parse(fields[16]);
                            int oxy = int.Parse(fields[17]);
                            int ammo = int.Parse(fields[18]);
                            string n = fields[19];

                            Ship ship = new Ship();
                            ship.ship_name = shipName;
                            ship.rarity = r;
                            ship.type = t;
                            ship.nation = n;
                            ship.HP = hp;
                            ship.FP = fp;
                            ship.TRP = trp;
                            ship.AVI = avi;
                            ship.AA = aa;
                            ship.RLD = rld;
                            ship.EVA = eva;
                            ship.Armor = armor;
                            ship.SPD = spd;
                            ship.ACC = acc;
                            ship.LCK = lck;
                            ship.ASW = asw;
                            ship.OIL = oil;
                            ship.OXY = oxy;
                            ship.AMMO = ammo;

                            ShipName.Text = ship.ship_name;
                            Nation.Image = Image.FromFile(Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, "Resources/Icons/Nations/", ship.nation + ".png"));
                            TypeIcon.Image = Image.FromFile(Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, "Resources/Icons/Ship Types/", ship.type + ".png"));
                            Rarity.Text = ship.rarity;
                            Health.Text = ship.HP.ToString();
                            Firepower.Text = ship.FP.ToString();
                            Torpedo.Text = ship.TRP.ToString();
                            Aviation.Text = ship.AVI.ToString();
                            AntiAir.Text = ship.AA.ToString();
                            Reload.Text = ship.RLD.ToString();
                            Evasion.Text = ship.EVA.ToString();
                            Armor.Text = ship.Armor;
                            Speed.Text = ship.SPD.ToString();
                            Accuracy.Text = ship.ACC.ToString();
                            Luck.Text = ship.LCK.ToString();
                            ASW.Text = ship.ASW.ToString();
                            Oil.Text = ship.OIL.ToString();
                            Oxygen.Text = ship.OXY.ToString();
                            Ammo.Text = ship.AMMO.ToString();
                            switch (ship.rarity)
                            {
                                case "Common":
                                    Rarity.ForeColor = Color.LightGray;
                                    break;
                                case "Rare":
                                    Rarity.ForeColor = Color.Cyan;
                                    break;
                                case "Elite":
                                    Rarity.ForeColor = Color.FromArgb(227, 3, 252);
                                    break;
                                case "Super Rare":
                                    Rarity.ForeColor = Color.Gold;
                                    break;
                                case "Ultra Rare":
                                    Rarity.ForeColor = Color.Pink;
                                    break;
                            }
                            switch (ship.type)
                            {
                                case "DD":
                                    Type.Text = "Destroyer";
                                    break;
                                case "DDG":
                                    Type.Text = "Guided-missile Destroyer";
                                    break;
                                case "CL":
                                    Type.Text = "Light Cruiser";
                                    break;
                                case "CA":
                                    Type.Text = "Heavy Cruiser";
                                    break;
                                case "CB":
                                    Type.Text = "Large Cruiser";
                                    break;
                                case "BC":
                                    Type.Text = "Battleship";
                                    break;
                                case "BB":
                                    Type.Text = "Battleship";
                                    break;
                                case "CV":
                                    Type.Text = "Aircraft Carrier";
                                    break;
                                case "CVL":
                                    Type.Text = "Light Aircraft Carrier";
                                    break;
                                case "AR":
                                    Type.Text = "Repair Ship";
                                    break;
                                case "SS":
                                    Type.Text = "Submarine";
                                    break;
                                case "SSV":
                                    Type.Text = "Submarine Carrier";
                                    break;
                                case "IX":
                                    Type.Text = "Frigate";
                                    break;
                                case "BM":
                                    Type.Text = "Monitor";
                                    break;
                                case "BBV":
                                    Type.Text = "Aviation Battleship";
                                    break;
                                case "AE":
                                    Type.Text = "Ammunition Ship";
                                    break;
                                default:
                                    Type.Text = "Hull Type";
                                    break;
                            }
                            if (File.Exists(ship.GetImagePathMETA(shipName)))
                                ShipImage.Image = Image.FromFile(ship.GetImagePathMETA(shipName));
                            break;
                        }
                    }
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex != -1)
            {
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;

                string filePath = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, "ShipInfo", "Azur Lane - Collab.csv");
                string shipName = comboBox5.SelectedItem.ToString();

                using (TextFieldParser parser = new TextFieldParser(filePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.ReadLine();
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        if (fields[2] == shipName)
                        {
                            string t = fields[1];
                            string r = fields[3];
                            int hp = int.Parse(fields[4]);
                            int fp = int.Parse(fields[5]);
                            int trp = int.Parse(fields[6]);
                            int avi = int.Parse(fields[7]);
                            int aa = int.Parse(fields[8]);
                            int rld = int.Parse(fields[9]);
                            int eva = int.Parse(fields[10]);
                            string armor = fields[11];
                            int spd = int.Parse(fields[12]);
                            int acc = int.Parse(fields[13]);
                            int lck = int.Parse(fields[14]);
                            int asw = int.Parse(fields[15]);
                            int oil = int.Parse(fields[16]);
                            int oxy = int.Parse(fields[17]);
                            int ammo = int.Parse(fields[18]);
                            string n = fields[19];

                            Ship ship = new Ship();
                            ship.ship_name = shipName;
                            ship.rarity = r;
                            ship.type = t;
                            ship.nation = n;
                            ship.HP = hp;
                            ship.FP = fp;
                            ship.TRP = trp;
                            ship.AVI = avi;
                            ship.AA = aa;
                            ship.RLD = rld;
                            ship.EVA = eva;
                            ship.Armor = armor;
                            ship.SPD = spd;
                            ship.ACC = acc;
                            ship.LCK = lck;
                            ship.ASW = asw;
                            ship.OIL = oil;
                            ship.OXY = oxy;
                            ship.AMMO = ammo;

                            ShipName.Text = ship.ship_name;
                            Nation.Image = Image.FromFile(Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, "Resources/Icons/Nations/Misc.png"));
                            TypeIcon.Image = Image.FromFile(Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, "Resources/Icons/Ship Types/", ship.type + ".png"));
                            Rarity.Text = ship.rarity;
                            Health.Text = ship.HP.ToString();
                            Firepower.Text = ship.FP.ToString();
                            Torpedo.Text = ship.TRP.ToString();
                            Aviation.Text = ship.AVI.ToString();
                            AntiAir.Text = ship.AA.ToString();
                            Reload.Text = ship.RLD.ToString();
                            Evasion.Text = ship.EVA.ToString();
                            Armor.Text = ship.Armor;
                            Speed.Text = ship.SPD.ToString();
                            Accuracy.Text = ship.ACC.ToString();
                            Luck.Text = ship.LCK.ToString();
                            ASW.Text = ship.ASW.ToString();
                            Oil.Text = ship.OIL.ToString();
                            Oxygen.Text = ship.OXY.ToString();
                            Ammo.Text = ship.AMMO.ToString();
                            switch (ship.rarity)
                            {
                                case "Common":
                                    Rarity.ForeColor = Color.LightGray;
                                    break;
                                case "Rare":
                                    Rarity.ForeColor = Color.Cyan;
                                    break;
                                case "Elite":
                                    Rarity.ForeColor = Color.FromArgb(227, 3, 252);
                                    break;
                                case "Super Rare":
                                    Rarity.ForeColor = Color.Gold;
                                    break;
                                case "Ultra Rare":
                                    Rarity.ForeColor = Color.Pink;
                                    break;
                            }
                            switch (ship.type)
                            {
                                case "DD":
                                    Type.Text = "Destroyer";
                                    break;
                                case "DDG":
                                    Type.Text = "Guided-missile Destroyer";
                                    break;
                                case "CL":
                                    Type.Text = "Light Cruiser";
                                    break;
                                case "CA":
                                    Type.Text = "Heavy Cruiser";
                                    break;
                                case "CB":
                                    Type.Text = "Large Cruiser";
                                    break;
                                case "BC":
                                    Type.Text = "Battleship";
                                    break;
                                case "BB":
                                    Type.Text = "Battleship";
                                    break;
                                case "CV":
                                    Type.Text = "Aircraft Carrier";
                                    break;
                                case "CVL":
                                    Type.Text = "Light Aircraft Carrier";
                                    break;
                                case "AR":
                                    Type.Text = "Repair Ship";
                                    break;
                                case "SS":
                                    Type.Text = "Submarine";
                                    break;
                                case "SSV":
                                    Type.Text = "Submarine Carrier";
                                    break;
                                case "IX":
                                    Type.Text = "Frigate";
                                    break;
                                case "BM":
                                    Type.Text = "Monitor";
                                    break;
                                case "BBV":
                                    Type.Text = "Aviation Battleship";
                                    break;
                                case "AE":
                                    Type.Text = "Ammunition Ship";
                                    break;
                                default:
                                    Type.Text = "Hull Type";
                                    break;
                            }
                            if (File.Exists(ship.GetImagePathCollab(shipName)))
                                ShipImage.Image = Image.FromFile(ship.GetImagePathCollab(shipName));
                            break;
                        }
                    }
                }
            }
        }
    }
}
