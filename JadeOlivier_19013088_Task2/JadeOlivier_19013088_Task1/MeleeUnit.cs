﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JadeOlivier_19013088_Task1
{
    class MeleeUnit : Unit
    {
        Map mapTracker = new Map(10,6);

        //Constructor intialiser for unit takes in created values and sends them to parent class Unit
        public MeleeUnit(int meleeX, int meleeY, string meleeName,string meleeTeam, char meleeSymb, bool meleeAttacking) : base(meleeX, meleeY, meleeName, 6, 3, 2, 1, meleeTeam, meleeSymb, meleeAttacking)
        {

        }

        //Overloaded Constructor intialiser for unit takes in created values and sends them to parent class Unit, including the MaxHp
        public MeleeUnit(int meleeX, int meleeY, string meleeName, int meleeHp, int meleeMaxHP, string meleeTeam, char meleeSymb, bool meleeAttacking) : base(meleeX, meleeY, meleeName, meleeHp, meleeMaxHP, 3, 2, 1, meleeTeam, meleeSymb, meleeAttacking)
        {

        }

        //Movement takes in the enemy unit the current unit needs to move to and finds the shortest way of getting to that unit without moviong diagonally
        public override string Move(Unit unitToEngage)
        {
            string returnVal = "";
            string typeCheck = unitToEngage.GetType().ToString();
            string[] splitArray = typeCheck.Split('.');
            typeCheck = splitArray[splitArray.Length - 1];

            if (typeCheck == "MeleeUnit")
            {
                MeleeUnit m = (MeleeUnit)unitToEngage;
                if ((Math.Abs(m.XPos - this.XPos) > Math.Abs(m.YPos - this.YPos)))
                {
                    if ((m.XPos - this.XPos) > 0)
                    {
                        if (mapTracker.mapVisuals[this.YPos, this.XPos + 1] == 'U' || mapTracker.mapVisuals[this.YPos, this.XPos + 1] == 'u' || mapTracker.mapVisuals[this.YPos, this.XPos + 1] == 'W' || mapTracker.mapVisuals[this.YPos, this.XPos + 1] == 'w')
                        {
                            this.YPos++;
                            this.XPos++;
                            returnVal = "Right";
                        }
                        else
                        {
                            this.XPos++;
                            returnVal = "Right";
                        }
                    }
                    else if ((m.XPos - this.XPos) < 0)
                    {
                        if (mapTracker.mapVisuals[this.YPos, this.XPos - 1] == 'U' || mapTracker.mapVisuals[this.YPos, this.XPos - 1] == 'u' || mapTracker.mapVisuals[this.YPos, this.XPos - 1] == 'W' || mapTracker.mapVisuals[this.YPos, this.XPos - 1] == 'w')
                        {
                            this.YPos++;
                            this.XPos--;
                            returnVal = "Left";
                        }
                        else
                        {
                            this.XPos--;
                            returnVal = "Left";
                        }


                    }
                }
                else
                {
                    if ((m.YPos - this.YPos) > 0)
                    {
                        if (mapTracker.mapVisuals[this.YPos + 1, this.XPos] == 'U' || mapTracker.mapVisuals[this.YPos + 1, this.XPos] == 'u' || mapTracker.mapVisuals[this.YPos + 1, this.XPos - 1] == 'W' || mapTracker.mapVisuals[this.YPos + 1, this.XPos] == 'w')
                        {
                            this.YPos++;
                            this.XPos++;
                            returnVal = "Up";
                        }
                        else
                        {
                            this.YPos++;
                            returnVal = "Up";
                        }
                    }
                    else if ((m.YPos - this.YPos) < 0)
                    {
                        if (mapTracker.mapVisuals[this.YPos - 1, this.XPos] == 'U' || mapTracker.mapVisuals[this.YPos - 1, this.XPos] == 'u' || mapTracker.mapVisuals[this.YPos - 1, this.XPos - 1] == 'W' || mapTracker.mapVisuals[this.YPos - 1, this.XPos] == 'w')
                        {
                            this.YPos--;
                            this.XPos++;
                            returnVal = "Down";
                        }
                        else
                        {
                            this.YPos--;
                            returnVal = "Down";
                        }
                    }
                }
            }
            else
            {
                RangedUnit r = (RangedUnit)unitToEngage;
                if ((Math.Abs(r.XPos - this.XPos) > Math.Abs(r.YPos - this.YPos)))
                {
                    if ((r.XPos - this.XPos) > 0)
                    {
                        if (mapTracker.mapVisuals[this.YPos, this.XPos + 1] == 'U' || mapTracker.mapVisuals[this.YPos, this.XPos + 1] == 'u' || mapTracker.mapVisuals[this.YPos, this.XPos + 1] == 'W' || mapTracker.mapVisuals[this.YPos, this.XPos + 1] == 'w')
                        {
                            this.YPos++;
                            this.XPos++;
                            returnVal = "Right";
                        }
                        else
                        {
                            this.XPos++;
                            returnVal = "Right";
                        }
                    }
                    else if ((r.XPos - this.XPos) < 0)
                    {
                        if (mapTracker.mapVisuals[this.YPos, this.XPos - 1] == 'U' || mapTracker.mapVisuals[this.YPos, this.XPos - 1] == 'u' || mapTracker.mapVisuals[this.YPos, this.XPos - 1] == 'W' || mapTracker.mapVisuals[this.YPos, this.XPos - 1] == 'w')
                        {
                            this.YPos++;
                            this.XPos--;
                            returnVal = "Left";
                        }
                        else
                        {
                            this.XPos--;
                            returnVal = "Left";
                        }


                    }
                }
                else
                {
                    if ((r.YPos - this.YPos) > 0)
                    {
                        if (mapTracker.mapVisuals[this.YPos + 1, this.XPos] == 'U' || mapTracker.mapVisuals[this.YPos + 1, this.XPos] == 'u' || mapTracker.mapVisuals[this.YPos + 1, this.XPos - 1] == 'W' || mapTracker.mapVisuals[this.YPos + 1, this.XPos] == 'w')
                        {
                            this.YPos++;
                            this.XPos++;
                            returnVal = "Up";
                        }
                        else
                        {
                            this.YPos++;
                            returnVal = "Up";
                        }
                    }
                    else if ((r.YPos - this.YPos) < 0)
                    {
                        if (mapTracker.mapVisuals[this.YPos - 1, this.XPos] == 'U' || mapTracker.mapVisuals[this.YPos - 1, this.XPos] == 'u' || mapTracker.mapVisuals[this.YPos - 1, this.XPos - 1] == 'W' || mapTracker.mapVisuals[this.YPos - 1, this.XPos] == 'w')
                        {
                            this.YPos--;
                            this.XPos++;
                            returnVal = "Down";
                        }
                        else
                        {
                            this.YPos--;
                            returnVal = "Down";
                        }
                    }
                }
            }

            return returnVal;
        }

        //Distance formula used to determine closest unit. If distance of the opponent unit currently being tested is less than the
        //distance of the previously tested opponent unit, the current unit then becomes the closest unit. Once all units in the 
        //array have been tested, the closest enemy unit is passed back to GameEngine
        public override Unit ClosestUnit(Unit[] unitClosetCheck)
        {
            int workingOut, xDis, yDis;
            int closest = 1000;
            Unit returnVal = this;
            foreach (Unit temp in unitClosetCheck)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "MeleeUnit")
                {
                    MeleeUnit m = (MeleeUnit)temp;
                    if (m.XPos != this.XPos && m.YPos != this.YPos)
                    {
                        if (m.Faction != this.Faction)
                        { 
                           xDis = Math.Abs(this.XPos - m.XPos);
                            yDis = Math.Abs(this.YPos - m.YPos);
                            workingOut = Convert.ToInt32(Math.Sqrt((xDis * xDis) + (yDis * yDis)));

                            if (workingOut < closest)
                            {
                                closest = workingOut;
                                returnVal = m;
                            }
                        }
                    }
                }
                else
                {
                    RangedUnit r = (RangedUnit)temp;
                    if (r.XPos != this.XPos && r.YPos != this.YPos)
                    {
                        if (r.Faction != this.Faction)
                        { 
                           xDis = Math.Abs(this.XPos - r.XPos);
                            yDis = Math.Abs(this.YPos - r.YPos);
                            workingOut = Convert.ToInt32(Math.Sqrt((xDis * xDis) + (yDis * yDis)));
                                
                           if (workingOut < closest)
                           {
                                closest = workingOut;
                                returnVal = r;
                           }
                        }
                    }
                }
            }

            return returnVal;
        }

        //Method to deal with combatting the enemy unit once it is in range. Lowers enemy hp using current units attack value
        public override void Combat(Unit attackingUnit)
        {
            string typeCheck = attackingUnit.GetType().ToString();
            string[] splitArray = typeCheck.Split('.');
            typeCheck = splitArray[splitArray.Length - 1];

            if (typeCheck == "MeleeUnit")
            {
                MeleeUnit mu = (MeleeUnit)attackingUnit;
                mu.Health -= this.Attk;
                this.isAttacking = false;
            }
            else
            {
                RangedUnit ru = (RangedUnit)attackingUnit;
                ru.Health -= this.Attk;
                this.IsAttacking = false;
            }
        }

        //Tests if current units health is <= 0 and removes it from the map 
        public override bool IsDead()
        {
            bool unitDead;

            if (this.Health <= 0)
            {
                unitDead = true;
            }
            else
            {
                unitDead = false;
            }

            return unitDead;
        }

        //Tests if closest enemy unit is within 1 blocks of the current unit 
        public override bool IsInRange(Unit unitInRange)
        {
            bool inRange = false; ;
            string typeCheck = unitInRange.GetType().ToString();
            string[] splitArray = typeCheck.Split('.');
            typeCheck = splitArray[splitArray.Length - 1];

            if (typeCheck == "MeleeUnit")
            {
                MeleeUnit mu = (MeleeUnit)unitInRange;
                if ((mu.YPos == this.YPos && Math.Abs(mu.XPos - this.XPos) == 1) || (mu.XPos == this.XPos && Math.Abs(mu.YPos - this.YPos) == 1))
                {
                    inRange = true;
                }
                else
                {
                    inRange = false;
                }
            }
            else
            {
                RangedUnit ru = (RangedUnit)unitInRange;
                if ((ru.YPos == this.YPos && Math.Abs(ru.XPos - this.XPos) == 1) || (ru.XPos == this.XPos && Math.Abs(ru.YPos - this.YPos) == 1))
                {
                    inRange = true;
                }
                else
                {
                    inRange = false;
                }
            }

            return inRange;
        }
       
        //If the unit is low on health it will runaway in any random direction
        public string RandomMove()
        {
            Random rgn = new Random();
            int move = rgn.Next(0, 4);
            string moveDirect = "";

            switch (move)
            {
                case 0:
                    {
                        moveDirect = "Right";
                        break;
                    }
                case 1:
                    {
                        moveDirect = "Left";
                        break;
                    }
                case 2:
                    {
                        moveDirect = "Up";
                        break;
                    }
                case 3:
                    {
                        moveDirect = "Down";
                        break;
                    }
            }

            return moveDirect;
        }

        //For displaying stats of this unit
        public override string ToString()
        {
            string returnVal = "";
            returnVal += "A new Melee Unit enters the battlefield" + Environment.NewLine;
            returnVal += "Their x position is: " + this.XPos + Environment.NewLine;
            returnVal += "Their y position is: " + this.YPos + Environment.NewLine;
            returnVal += "Their name is: " + this.Name + Environment.NewLine;
            returnVal += "Their current hp is: " + this.Health + Environment.NewLine;
            returnVal += "Their max hp is: " + this.Health + Environment.NewLine;
            returnVal += "Their attack damage is: " + this.Attk + Environment.NewLine;
            returnVal += "Their range is: " + this.AttkRange + Environment.NewLine;
            returnVal += "Their speed is: " + this.Speed + Environment.NewLine;
            returnVal += "Their team is: " + this.Faction + Environment.NewLine;
            returnVal += "Their symbol is: " + this.Symbol + Environment.NewLine;
            returnVal += "----------------------------------------" + Environment.NewLine;
            returnVal += Environment.NewLine;

            return returnVal; 
        }

        //Saves the current units information into a textfile.
        public override void Save()
        {
            string savedString = "";
            savedString += "Melee,";
            savedString += XPos + ",";
            savedString += YPos + ",";
            savedString += Name + ",";
            savedString += Health + ",";
            savedString += MaxHealth + ",";
            savedString += Speed + ",";
            savedString += Attk + ",";
            savedString += AttkRange + ",";
            savedString += Faction + ",";
            savedString += Symbol + ",";
            savedString += IsAttacking;

            FileStream fs = new FileStream("SavedUnits/unitTextFile", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);

            writer.WriteLine(savedString);

            writer.Close();
            fs.Close();
        }

        public int XPos { get => base.xPos; set => base.xPos = value; }
        public int YPos { get => base.yPos; set => base.yPos = value; }
        public int Health { get => base.health; set => base.health = value; }
        public int MaxHealth { get => base.maxHealth;}
        public int Speed { get => base.speed;}
        public int Attk { get => base.attk;}
        public int AttkRange { get => base.attkRange;}
        public string Faction { get => base.faction;}
        public char Symbol { get => base.symbol;}
        public bool IsAttacking { get => base.isAttacking; set => base.isAttacking = value; }
        public string Name { get => base.name;}

    }
}
