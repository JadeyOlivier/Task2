using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JadeOlivier_19013088_Task1
{
    public partial class frmBattlefield : Form
    {
        GameEngine ge = new GameEngine();
        int timerTicks;
        string battleInfo = "";

        public frmBattlefield()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            battleTimer.Start();
        }

        private void battleTimer_Tick(object sender, EventArgs e)
        {
            //map and stats are updated everytime the timer ticks 
            rtxProgress.Text = "";
            timerTicks++;
            lblRound.Text = timerTicks.ToString();
            //Game only runs if both teams still have units in them. If one team kills all the units on the other team, the game stops
            if (ge.MapTracker.NumDayWalkers > 0 && ge.MapTracker.NumNightRiders > 0)
            {
                ge.GameRun();
                lblMap.Text = ge.MapTracker.drawMap();
                Display();
            }
        }

        //Both units and buildings tostrings have been added to the rich text box to display stats
        private void Display()
        {
            battleInfo = "";
            foreach (Unit temp in ge.MapTracker.unitArray)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "MeleeUnit")
                {
                    MeleeUnit obj = (MeleeUnit)temp;
                    battleInfo += obj.ToString();
                }
                else
                {
                    RangedUnit obj = (RangedUnit)temp;
                    battleInfo += obj.ToString();
                }
            }

           foreach (Building temp in ge.MapTracker.buildingArray)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "ResourceBuilding")
                {
                    ResourceBuilding obj = (ResourceBuilding)temp;
                    battleInfo += obj.ToString();
                }
                else
                {
                    FactoryBuilding obj = (FactoryBuilding)temp;
                    battleInfo += obj.ToString();
                }
            }

            rtxProgress.Text = battleInfo;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            battleTimer.Stop();
        }

        private void frmBattlefield_Load(object sender, EventArgs e)
        {
            //Directories for both the building and unit textfiles are create when the form loads to be called later during the saving and reading processes
            if (!Directory.Exists("SavedUnits"))
            {
                Directory.CreateDirectory("SavedUnits");
            }

            if (!Directory.Exists("SavedBuildings"))
            {
                Directory.CreateDirectory("SavedBuildings");
            }

            ge.MapTracker.populateMap();
            lblMap.Text = ge.MapTracker.drawMap();
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Values from both the buildings and units are saved into seperate textfiles
            FileStream fsU = new FileStream("SavedUnits/unitTextFile", FileMode.Create, FileAccess.Write);
            fsU.Close();
            FileStream fsB = new FileStream("SavedBuildings/buildingTextFile", FileMode.Create, FileAccess.Write);
            fsB.Close();

            foreach (Unit temp in ge.MapTracker.unitArray)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "MeleeUnit")
                {
                    MeleeUnit obj = (MeleeUnit)temp;
                    obj.Save();
                }
                else
                {
                    RangedUnit obj = (RangedUnit)temp;
                    obj.Save();
                }
            }

            foreach (Building temp in ge.MapTracker.buildingArray)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "ResourceBuilding")
                {
                    ResourceBuilding obj = (ResourceBuilding)temp;
                    obj.Save();
                }
                else
                {
                    FactoryBuilding obj = (FactoryBuilding)temp;
                    obj.Save();
                }
            }

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //Saved values are called out of the textfile and displayed again, overwriting the current map
             FileStream fsU = new FileStream("SavedUnits/unitTextFile", FileMode.Open, FileAccess.Read);
            fsU.Close();
            FileStream fsB = new FileStream("SavedBuildings/buildingTextFile", FileMode.Open, FileAccess.Read);
            fsB.Close();

            ge.MapTracker.Read();
            lblMap.Text = ge.MapTracker.drawMap();
            Display();
        }
    }
}
