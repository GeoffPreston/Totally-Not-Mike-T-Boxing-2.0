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

/* Title: Totally Not Mike Tyson Punchout
    Authors: Marek Slabicki(100296189), Phillip Ta(100327123), Geoff Preston(100328302)
    Purpose: Try your luck in the ring with the Champion!!!! A game that is both fun and demonstrates
             skills learned in class. Totally Not Mike Tyson Punch-Out is a game of chance.  Each attack 
             option represents various risks and rewards in your battle for the belt
    Assignment : INFO1112 Final Project
    Instructor: Dr.Abhijit Sen
    Date: November 15, 2015*/

namespace Totally_Not_Mike_T_Boxing_2._0
{
    public partial class Form1 : Form
    {

        //variables referencing .wav resources
        System.Media.SoundPlayer gameMusic = new System.Media.SoundPlayer();//Game Music
        System.Media.SoundPlayer cheering = new System.Media.SoundPlayer();//Crowd cheers when player wins
        System.Media.SoundPlayer booing = new System.Media.SoundPlayer();//Crowd boo's when player looses


        public Form1()
        {
            InitializeComponent();

            //Show instructions before form opens
            MessageBox.Show("Welcome to totally not mike tyson punchout.");

            //initialize and loop game music
            gameMusic.SoundLocation = "01 A Night Of Dizzy Spells.wav";
            gameMusic.PlayLooping();

            //reference cheer and boo .wav files
            cheering.SoundLocation = "cheer.wav";
            booing.SoundLocation = "boo.wav";
        }

        //Variables holding starting hitpoints
        int mikeHitPoints = 50; //Variable to track hits on Mike
        int playerHitPoints = 50; //Tracks hits on Player
        string PlayerNickname; // Players sets their own nickname



        private void buttonFight_Click(object sender, EventArgs e)
        {
            labelPlayerHP.Text = playerHitPoints.ToString(); //Show P1 HP in label
            labelMikeHP.Text = mikeHitPoints.ToString();//Show Mike HP in label

            if (playerHitPoints > 0 && mikeHitPoints > 0)
            {
                //Methods that determine damage to hitpoints
                Punch();
                PlayerPunch();


                //else if else statements changing pictures visible and messages to player
                if (mikeHitPoints > 40 && mikeHitPoints <= 49)
                {
                    Mike1();
                }
                else if (mikeHitPoints > 30 && mikeHitPoints < 39)
                {
                    Mike2();
                }
                else if (mikeHitPoints > 20 && mikeHitPoints < 29)
                {
                    Mike3();
                }
                else if (mikeHitPoints < 20 && mikeHitPoints > 0 && playerHitPoints > 0)
                {
                    Mike4();
                }
                else if (mikeHitPoints <= 0 && playerHitPoints > mikeHitPoints)
                {
                    PlayerWins();
                }
                else if (playerHitPoints <= 0 && mikeHitPoints > playerHitPoints)
                {
                    MikeWins();
                }
                else if (playerHitPoints == mikeHitPoints && playerHitPoints <= 0)
                {
                    labelMessage.Text = "Tie!!!";
                }
            }
        }



        private void bttnReset_Click(object sender, EventArgs e)//Resets game variables to starting values
        {
            Reset();
        }

        private void bttnExit_Click(object sender, EventArgs e)
        {
            this.Close(); //Exit the game
        }

        private void bttnJab_Click(object sender, EventArgs e) // One in two chance of landing a jab. If missed mike counters
        {
            Jab();
        }
        private void buttonSave_Click(object sender, EventArgs e) // Calls upon save method to save
        {
            Save();
        }

        private void bttnHook_Click(object sender, EventArgs e) // Calls upon hook method
        {
            Hook();
        }

        private void bttnCombo_Click(object sender, EventArgs e) // Calls upon combo method
        {

            Combo();

        }
        private void buttonGo_Click(object sender, EventArgs e) // This button sets player nickname and hides groupbox control
        {
            groupBoxNickname.Visible = false;
            try
            {
                PlayerNickname = textBoxNickname.Text;
            }
            catch
            {
                PlayerNickname = "Player 1";
            }
        }
        private void Punch() //Determines how many hitpoints removed from Mike
        {
            Random mikeHpChange = new Random();
            int mikePunch = mikeHpChange.Next(6);

            mikeHitPoints = mikeHitPoints - mikePunch;
        }

        private void PlayerPunch() //Determins how many hitpoints removed from player
        {

            Random playerHpChange = new Random();
            int punchP1 = playerHpChange.Next(4) + 1;

            playerHitPoints = playerHitPoints - punchP1;
        }
        // Methods start here
        //Game settings when mikeHitPoints > 40 && mikeHitPoints <= 49

        
        private void Mike1() // This method makes the "you hit mike" picture set to true
        {
            labelMessage.Text = "That's a clean hit!!!";
            pbPlayerWins.Visible = false;
            pbMikeWins.Visible = false;
            pbTysonHitYou.Visible = false;
            pbYouHitMike.Visible = true;
            pbMikeGoesApe.Visible = false;
            pbMikeCrazy.Visible = false;
        }

        //Game settings when mikeHitPoints > 30 && mikeHitPoints < 39
        private void Mike2() // This method makes the "tyson hit you" picture set to true
        {
            labelMessage.Text = "Yo Momma!!!";
            pbPlayerWins.Visible = false;
            pbMikeWins.Visible = false;
            pbTysonHitYou.Visible = true;
            pbYouHitMike.Visible = false;
            pbMikeGoesApe.Visible = false;
            pbMikeCrazy.Visible = false;
        }

        //Game settings when mikeHitPoints > 20 && mikeHitPoints < 29
        private void Mike3() // This method makes the "mike goes ape" picture set to true
        {
            labelMessage.Text = "Keep Fighting!!";
            pbPlayerWins.Visible = false;
            pbMikeWins.Visible = false;
            pbTysonHitYou.Visible = false;
            pbYouHitMike.Visible = false;
            pbMikeGoesApe.Visible = true;
            pbMikeCrazy.Visible = false;
        }

        //Game settings when mikeHitPoints < 20 && mikeHitPoints > 0 && playerHitPoints >0
        private void Mike4() // This method makes the "mike crazy" picture set to true
        {
            labelMessage.Text = "He's staggering!!!";
            pbPlayerWins.Visible = false;
            pbMikeWins.Visible = false;
            pbTysonHitYou.Visible = false;
            pbYouHitMike.Visible = false;
            pbMikeGoesApe.Visible = false;
            pbMikeCrazy.Visible = true;
            bttnCombo.Visible = true;
        }

        //Player wins game settings
        private void PlayerWins() // This method makes the "player wins" picture set to true
        {
            labelMessage.Text = "You win";
            pbPlayerWins.Visible = true;
            pbMikeWins.Visible = false;
            pbTysonHitYou.Visible = false;
            pbYouHitMike.Visible = false;
            pbMikeGoesApe.Visible = false;
            pbMikeCrazy.Visible = false;
            cheering.Play();
        }
        //Mike wins game settings
        private void MikeWins() // This method makes the "mike wins" picture set to true
        {
            labelMessage.Text = "You Lose!!!";
            pbPlayerWins.Visible = false;
            pbMikeWins.Visible = true;
            pbTysonHitYou.Visible = false;
            pbYouHitMike.Visible = false;
            pbMikeGoesApe.Visible = false;
            pbMikeCrazy.Visible = false;
            booing.Play();
        }
        private void Combo() // Generates a one in four chance in landing a combo. If combo misses mike counters 
        {
            Random mikeHpChange = new Random();
            int mikePunch = mikeHpChange.Next(3);

            if (mikePunch == 1)
            {
                for (int count = 1; count < 3; count++)
                {
                    Random number = new Random();
                    int num = number.Next(5);
                    mikeHitPoints -= num;
                }
                labelMessage.Text = "Great combo!!!";
                bttnCombo.Visible = false;
                labelMikeHP.Text = mikeHitPoints.ToString();
            }
            else
            {
                playerHitPoints -= 5;
                labelMessage.Text = "You missed, Mike nailed you!!!";
                labelPlayerHP.Text = playerHitPoints.ToString();
            }

        }
        private void Hook() // Generates a one in four chance in landing a hook. If hook misses mike counters 
        {
            Random mikeHpChange = new Random();
            int mikePunch = mikeHpChange.Next(3);

            if (mikePunch == 1)
            {
                mikeHitPoints -= 15;
                labelMikeHP.Text = mikeHitPoints.ToString();
                labelMessage.Text = "You hit him hard, well done!!!";
            }
            else
            {
                playerHitPoints -= 5;
                labelPlayerHP.Text = playerHitPoints.ToString();
                labelMessage.Text = "Mike ducked and countered. You've been hit hard!!!";
            }

            if (mikeHitPoints > 40 && mikeHitPoints <= 49)
            {
                Mike1();
            }
            else if (mikeHitPoints > 30 && mikeHitPoints < 39)
            {
                Mike2();
            }
            else if (mikeHitPoints > 20 && mikeHitPoints < 29)
            {
                Mike3();
            }
            else if (mikeHitPoints < 20 && mikeHitPoints > 0 && playerHitPoints > 0)
            {
                Mike4();
            }
            else if (mikeHitPoints <= 0 && playerHitPoints > mikeHitPoints)
            {
                PlayerWins();
            }
            else if (playerHitPoints <= 0 && mikeHitPoints > playerHitPoints)
            {
                MikeWins();
            }
            else if (playerHitPoints == mikeHitPoints && playerHitPoints <= 0)
            {
                labelMessage.Text = "Tie!!!";
            }
        }
        private void Reset() // This resets all game values to the original settings 
        {
            mikeHitPoints = 50;
            playerHitPoints = 50;
            pbPlayerWins.Visible = false;
            pbMikeWins.Visible = false;
            pbTysonHitYou.Visible = false;
            pbYouHitMike.Visible = false;
            pbMikeGoesApe.Visible = false;
            pbMikeCrazy.Visible = false;
            labelMessage.Text = " ";
            labelMikeHP.Text = " ";
            labelPlayerHP.Text = " ";
            gameMusic.PlayLooping();
        }
        private void Save() // This appends all game values to a text file called "Hi-Scores" 
        {
            StreamWriter outputFile;
            outputFile = File.AppendText("Hi-Scores.txt");
            DateTime current = DateTime.Now;
            outputFile.WriteLine(PlayerNickname + " Hitpoints = " + playerHitPoints.ToString() + " " + current + " Mike Hitpoints = " + mikeHitPoints.ToString());
            outputFile.WriteLine("-");
            outputFile.Close();
            MessageBox.Show("Your Score Has Been Saved", "Save Score", MessageBoxButtons.OK);
        }

        private void Jab() //Generates 1 in 2 chance of landing a job, if missed mike counters
        {
            Random mikeHpChange = new Random();
            int mikePunch = mikeHpChange.Next(3);

            if (mikePunch == 0 || mikePunch == 1)
            {
                mikeHitPoints -= 3;
                labelMikeHP.Text = mikeHitPoints.ToString();
                labelMessage.Text = "Nice Jab!!!";
            }
            else
            {
                playerHitPoints -= 3;
                labelPlayerHP.Text = playerHitPoints.ToString();
                labelMessage.Text = "You missed. Mike countered with a left hook!!!";
            }

            if (mikeHitPoints > 40 && mikeHitPoints <= 49 && playerHitPoints > 0)
            {
                Mike1();
            }
            else if (mikeHitPoints > 30 && mikeHitPoints < 39 && playerHitPoints > 0)
            {
                Mike2();
            }
            else if (mikeHitPoints > 20 && mikeHitPoints < 29 && playerHitPoints > 0)
            {
                Mike3();
            }
            else if (mikeHitPoints < 20 && mikeHitPoints > 0 && playerHitPoints > 0)
            {
                Mike4();
            }
            else if (mikeHitPoints <= 0 && playerHitPoints > mikeHitPoints)
            {
                PlayerWins();
            }
            else if (playerHitPoints <= 0 && mikeHitPoints > playerHitPoints)
            {
                MikeWins();
            }
            else if (playerHitPoints == mikeHitPoints && playerHitPoints <= 0)
            {
                labelMessage.Text = "Tie!!!";
            }
        }
        // Methods end here

    }
}
