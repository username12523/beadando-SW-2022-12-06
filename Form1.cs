using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Threading;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public static class Conn
        {

            public static readonly MySqlConnection conn = new MySqlConnection("server=localhost;user=root;port=3306;password=;database=foldrajz");
        }
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
            string connStr = "server=localhost;user=root;port=3306;password=";

            MySqlConnection connNoDB = new MySqlConnection(connStr);
            MySqlCommand drdatabase = new MySqlCommand("DROP DATABASE IF EXISTS foldrajz", connNoDB);
            connNoDB.Open();
            drdatabase.ExecuteNonQuery();
            connNoDB.Close();
            MySqlCommand crdatabase = new MySqlCommand("CREATE DATABASE foldrajz DEFAULT CHARACTER SET latin2 COLLATE latin2_hungarian_ci", connNoDB);
            connNoDB.Open();
            crdatabase.ExecuteNonQuery();
            connNoDB.Close();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.conn.Close();
                richTextBox1.Text += " \n DB kapcsolat bontva";
                button10.Enabled = false;
                button1.Enabled = true;
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                Conn.conn.Close();
                richTextBox1.Text += " \n DB kapcsolat bontva";
                richTextBox1.Text += " \n Kilépés...";
                Application.Exit();
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string sql_create = File.ReadAllText("tablak.sql");
                MySqlCommand cmd_create = new MySqlCommand(sql_create, Conn.conn);
                cmd_create.ExecuteNonQuery();
                richTextBox1.Text += " \n A táblák létrejöttek";
                Thread.Sleep(100);
                //SQL INSERT
                string sql_insert = File.ReadAllText("adatok.sql");


                MySqlCommand cmd_insert = new MySqlCommand(sql_insert, Conn.conn);
                cmd_insert.ExecuteNonQuery();
                richTextBox1.Text += " \n Az adatok feltöltődtek";
                button3.Enabled = false;
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text += " \n Connecting to MySQL...";
                Conn.conn.Open();
                button1.Enabled = false;
                button10.Enabled = true;
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
        }


        private void button10_Click_1(object sender, EventArgs e)
        {
            try
            {
                Conn.conn.Close();
                richTextBox1.Text += " \n DB kapcsolat bontva";
                button10.Enabled = false;
                button1.Enabled = true;
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //1-5.feladat
                
                //1.feladat
                string sql_select1 = "SELECT `fovaros` FROM `orszagok` WHERE `orszag`='Madagaszkár;";
                MySqlCommand cmd_select1 = new MySqlCommand(sql_select1, Conn.conn);
                MySqlDataReader rdr_select1 = cmd_select1.ExecuteReader();

                while (rdr_select1.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select1[0] + " -- " + rdr_select1[1];
                }
                rdr_select1.Close();
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //2.feladat
            try
            {
                string sql_select2 = "SELECT `orszag` FROM `orszagok` WHERE `fovaros` like 'OUAGADOUGOU';";
                MySqlCommand cmd_select2 = new MySqlCommand(sql_select2, Conn.conn);
                MySqlDataReader rdr_select2 = cmd_select2.ExecuteReader();

                while (rdr_select2.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select2[0] + " -- " + rdr_select2[1];
                }
                rdr_select2.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

            //3.feladat
            try
            {
                string sql_select3 = "SELECT `orszag` FROM `orszagok` WHERE `autojel` like 'TT';";
        MySqlCommand cmd_select3 = new MySqlCommand(sql_select3, Conn.conn);
        MySqlDataReader rdr_select3 = cmd_select3.ExecuteReader();

                while (rdr_select3.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select3[0] + " -- " + rdr_select3[1];
                }
                rdr_select3.Close();
            }

            catch (Exception err)
             {
                 richTextBox1.Text += " \n " + err.ToString();
             }
            //4.feladat
            try
            {
                string sql_select4 = "SELECT `orszag` FROM `orszagok` WHERE `penzjel` like 'SGD'; ";
                MySqlCommand cmd_select4 = new MySqlCommand(sql_select4, Conn.conn);
                MySqlDataReader rdr_select4 = cmd_select4.ExecuteReader();

                while (rdr_select4.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select4[0] + " -- " + rdr_select4[1];
                }
                rdr_select4.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //5.feladat
            try
            {
                string sql_select5 = "SELECT `fovaros` FROM `orszagok` WHERE `telefon` like '61';";
                MySqlCommand cmd_select5 = new MySqlCommand(sql_select5, Conn.conn);
                MySqlDataReader rdr_select5 = cmd_select5.ExecuteReader();

                while (rdr_select5.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select5[0] + " -- " + rdr_select5[1];
                }
                rdr_select5.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //6-10.feladat

                //6.feladat
                string sql_select6 = "SELECT `terulet` FROM `orszagok` WHERE `orszag` like 'Monaco'";
                MySqlCommand cmd_select6 = new MySqlCommand(sql_select6, Conn.conn);
                MySqlDataReader rdr_select6 = cmd_select6.ExecuteReader();

                while (rdr_select6.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select6[0] + " -- " + rdr_select6[1];
                }
                rdr_select6.Close();
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //7.feladat
            try
            {
                string sql_select7 = "SELECT `nepesseg` FROM `orszagok` WHERE `orszag` like 'Málta'";
                MySqlCommand cmd_select7 = new MySqlCommand(sql_select7, Conn.conn);
                MySqlDataReader rdr_select7 = cmd_select7.ExecuteReader();

                while (rdr_select7.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select7[0] + " -- " + rdr_select7[1];
                }
                rdr_select7.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

            //8.feladat
            try
            {
                string sql_select8 = "SELECT `nepesseg` FROM `orszagok` WHERE `orszag` like 'Japán';";
                MySqlCommand cmd_select8 = new MySqlCommand(sql_select8, Conn.conn);
                MySqlDataReader rdr_select8 = cmd_select8.ExecuteReader();

                while (rdr_select8.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select8[0] + " -- " + rdr_select8[1];
                }
                rdr_select8.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //9.feladat
            try
            {
                string sql_select9 = "9ELECT SUM(`nepesseg`) as 'Föld lakosainak száma' FROM `orszagok`; ";
                MySqlCommand cmd_select9 = new MySqlCommand(sql_select9, Conn.conn);
                MySqlDataReader rdr_select9 = cmd_select9.ExecuteReader();

                while (rdr_select9.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select9[0] + " -- " + rdr_select9[1];
                }
                rdr_select9.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //10.feladat
            try
            {
                string sql_select10 = "SELECT SUM(`terulet`) FROM `orszagok`;";
                MySqlCommand cmd_select10 = new MySqlCommand(sql_select10, Conn.conn);
                MySqlDataReader rdr_select10 = cmd_select10.ExecuteReader();

                while (rdr_select10.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select10[0] + " -- " + rdr_select10[1];
                }
                rdr_select10.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //11-15.feladat

                //11.feladat
                string sql_select11 = "SELECT AVG(`nepesseg`) FROM `orszagok`;";
                MySqlCommand cmd_select11 = new MySqlCommand(sql_select11, Conn.conn);
                MySqlDataReader rdr_select11 = cmd_select11.ExecuteReader();

                while (rdr_select11.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select11[0] + " -- " + rdr_select11[1];
                }
                rdr_select11.Close();
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //12.feladat
            try
            {
                string sql_select12 = "SELECT AVG(`terulet`) FROM `orszagok`;";
                MySqlCommand cmd_select12 = new MySqlCommand(sql_select12, Conn.conn);
                MySqlDataReader rdr_select12 = cmd_select12.ExecuteReader();

                while (rdr_select12.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select12[0] + " -- " + rdr_select12[1];
                }
                rdr_select12.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

            //13.feladat
            try
            {
                string sql_select13 = "SELECT Count(`nepesseg`) as 'Föld népsûrûsége' FROM `orszagok`;";
                MySqlCommand cmd_select13 = new MySqlCommand(sql_select13, Conn.conn);
                MySqlDataReader rdr_select13 = cmd_select13.ExecuteReader();

                while (rdr_select13.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select13[0] + " -- " + rdr_select13[1];
                }
                rdr_select13.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //14.feladat
            try
            {
                string sql_select14 = "SELECT COUNT(`orszag`) FROM `orszagok` WHERE `terulet`> 1000000; ";
                MySqlCommand cmd_select14 = new MySqlCommand(sql_select14, Conn.conn);
                MySqlDataReader rdr_select14 = cmd_select14.ExecuteReader();

                while (rdr_select14.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select14[0] + " -- " + rdr_select14[1];
                }
                rdr_select14.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //15.feladat
            try
            {
                string sql_select15 = "SELECT COUNT(`orszag`) FROM `orszagok` WHERE `terulet`< 100;";
                MySqlCommand cmd_select15 = new MySqlCommand(sql_select15, Conn.conn);
                MySqlDataReader rdr_select15 = cmd_select15.ExecuteReader();

                while (rdr_select15.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select15[0] + " -- " + rdr_select15[1];
                }
                rdr_select15.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //16-20.feladat

                //16.feladat
                string sql_select16 = "SELECT COUNT(`orszag`) FROM `orszagok` WHERE `nepesseg`< 20000;";
                MySqlCommand cmd_select16 = new MySqlCommand(sql_select16, Conn.conn);
                MySqlDataReader rdr_select16 = cmd_select16.ExecuteReader();

                while (rdr_select16.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select16[0] + " -- " + rdr_select16[1];
                }
                rdr_select16.Close();
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //17.feladat
            try
            {
                string sql_select17 = "SELECT COUNT(`orszag`) FROM `orszagok` WHERE `terulet`<100 or `nepesseg`<20000;";
                MySqlCommand cmd_select17 = new MySqlCommand(sql_select17, Conn.conn);
                MySqlDataReader rdr_select17 = cmd_select17.ExecuteReader();

                while (rdr_select17.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select17[0] + " -- " + rdr_select17[1];
                }
                rdr_select17.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

            //18.feladat
            try
            {
                string sql_select18 = "SELECT COUNT(`orszag`) FROM `orszagok` WHERE `terulet` BETWEEN 50000 and 150000;";
                MySqlCommand cmd_select18 = new MySqlCommand(sql_select18, Conn.conn);
                MySqlDataReader rdr_select18 = cmd_select18.ExecuteReader();

                while (rdr_select18.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select18[0] + " -- " + rdr_select18[1];
                }
                rdr_select18.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //19.feladat
            try
            {
                string sql_select19 = "SELECT COUNT(`orszag`) FROM `orszagok` WHERE `nepesseg` BETWEEN 8000000 and 1200000;";
                MySqlCommand cmd_select19 = new MySqlCommand(sql_select19, Conn.conn);
                MySqlDataReader rdr_select19 = cmd_select19.ExecuteReader();

                while (rdr_select19.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select19[0] + " -- " + rdr_select19[1];
                }
                rdr_select19.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //20.feladat
            try
            {
                string sql_select20 = "SELECT `fovaros` FROM `orszagok` WHERE `nepesseg`>20000000;";
                MySqlCommand cmd_select20 = new MySqlCommand(sql_select20, Conn.conn);
                MySqlDataReader rdr_select20 = cmd_select20.ExecuteReader();

                while (rdr_select20.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select20[0] + " -- " + rdr_select20[1];
                }
                rdr_select20.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //21-25.feladat

                //21.feladat
                string sql_select21 = "SELECT `orszag` FROM `orszagok` WHERE (`nepesseg`/`terulet`)>500";
                MySqlCommand cmd_select21 = new MySqlCommand(sql_select21, Conn.conn);
                MySqlDataReader rdr_select21 = cmd_select21.ExecuteReader();

                while (rdr_select21.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select21[0] + " -- " + rdr_select21[1];
                }
                rdr_select21.Close();
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //22.feladat
            try
            {
                string sql_select22 = "SELECT  COUNT(`orszag`) FROM `orszagok` WHERE `allamforma` like 'köztársaság'";
                MySqlCommand cmd_select22 = new MySqlCommand(sql_select22, Conn.conn);
                MySqlDataReader rdr_select22 = cmd_select22.ExecuteReader();

                while (rdr_select22.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select22[0] + " -- " + rdr_select22[1];
                }
                rdr_select22.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

            //23.feladat
            try
            {
                string sql_select23 = "SELECT  `orszag` FROM `orszagok` WHERE `penznem` like 'kelet-karib dollár'";
                MySqlCommand cmd_select23 = new MySqlCommand(sql_select23, Conn.conn);
                MySqlDataReader rdr_select23 = cmd_select23.ExecuteReader();

                while (rdr_select23.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select23[0] + " -- " + rdr_select23[1];
                }
                rdr_select23.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //24.feladat
            try
            {
                string sql_select24 = "SELECT `orszag` FROM `orszagok` WHERE `orszag` like '%ORSZÁG%';";
                MySqlCommand cmd_select24 = new MySqlCommand(sql_select24, Conn.conn);
                MySqlDataReader rdr_select24 = cmd_select24.ExecuteReader();

                while (rdr_select24.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select24[0] + " -- " + rdr_select24[1];
                }
                rdr_select24.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //25.feladat
            try
            {
                string sql_select25 = "SELECT `orszag` FROM `orszagok` WHERE `penznem` like '%korona%';";
                MySqlCommand cmd_select25 = new MySqlCommand(sql_select25, Conn.conn);
                MySqlDataReader rdr_select25 = cmd_select25.ExecuteReader();

                while (rdr_select25.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select25[0] + " -- " + rdr_select25[1];
                }
                rdr_select25.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //26-30.feladat

                //26.feladat
                string sql_select26 = "SELECT SUM(`terulet`) FROM `orszagok` WHERE `foldr_hely` like '%Európa%';";
                MySqlCommand cmd_select26 = new MySqlCommand(sql_select26, Conn.conn);
                MySqlDataReader rdr_select26 = cmd_select26.ExecuteReader();

                while (rdr_select26.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select26[0] + " -- " + rdr_select26[1];
                }
                rdr_select26.Close();
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //27.feladat
            try
            {
                string sql_select27 = "SELECT SUM(`nepesseg`) FROM `orszagok` WHERE `foldr_hely` like '%Európa%';";
                MySqlCommand cmd_select27 = new MySqlCommand(sql_select27, Conn.conn);
                MySqlDataReader rdr_select27 = cmd_select27.ExecuteReader();

                while (rdr_select27.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select27[0] + " -- " + rdr_select27[1];
                }
                rdr_select27.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

            //28.feladat
            try
            {
                string sql_select28 = "SELECT SUM(`nepesseg`)/`terulet` FROM `orszagok` WHERE `foldr_hely` like '%Európa%';";
                MySqlCommand cmd_select28 = new MySqlCommand(sql_select28, Conn.conn);
                MySqlDataReader rdr_select28 = cmd_select28.ExecuteReader();

                while (rdr_select28.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select28[0] + " -- " + rdr_select28[1];
                }
                rdr_select28.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //29.feladat
            try
            {
                string sql_select29 = "SELECT COUNT(`orszag`) FROM `orszagok` WHERE `foldr_hely` like '%Afrika%';";
                MySqlCommand cmd_select29 = new MySqlCommand(sql_select29, Conn.conn);
                MySqlDataReader rdr_select29 = cmd_select29.ExecuteReader();

                while (rdr_select29.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select29[0] + " -- " + rdr_select29[1];
                }
                rdr_select29.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //30.feladat
            try
            {
                string sql_select30 = "SELECT SUM(`nepesseg`) FROM `orszagok` WHERE `foldr_hely` like '%Afrika%';";
                MySqlCommand cmd_select30 = new MySqlCommand(sql_select30, Conn.conn);
                MySqlDataReader rdr_select30 = cmd_select30.ExecuteReader();

                while (rdr_select30.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select30[0] + " -- " + rdr_select30[1];
                }
                rdr_select30.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //31-35.feladat

                //31.feladat
                string sql_select31 = "SELECT SUM(`nepesseg`)/`terulet` FROM `orszagok` WHERE `foldr_hely` like '%Afrika%';";
                MySqlCommand cmd_select31 = new MySqlCommand(sql_select31, Conn.conn);
                MySqlDataReader rdr_select31 = cmd_select31.ExecuteReader();

                while (rdr_select31.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select31[0] + " -- " + rdr_select31[1];
                }
                rdr_select31.Close();
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //32.feladat
            try
            {
                string sql_select32 = "SELECT `orszag` FROM `orszagok` WHERE `foldr_hely` like '%szigetország%';";
                MySqlCommand cmd_select32 = new MySqlCommand(sql_select32, Conn.conn);
                MySqlDataReader rdr_select32 = cmd_select32.ExecuteReader();

                while (rdr_select32.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select32[0] + " -- " + rdr_select32[1];
                }
                rdr_select32.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

            //33.feladat
            try
            {
                string sql_select33 = "SELECT `orszag` FROM `orszagok` WHERE `allamforma` like '%királyság%'";
                MySqlCommand cmd_select33 = new MySqlCommand(sql_select33, Conn.conn);
                MySqlDataReader rdr_select33 = cmd_select33.ExecuteReader();

                while (rdr_select33.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select33[0] + " -- " + rdr_select33[1];
                }
                rdr_select33.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //34.feladat
            try
            {
                string sql_select34 = "SELECT count(`orszag`) FROM `orszagok` WHERE `autojel` is null";
                MySqlCommand cmd_select34 = new MySqlCommand(sql_select34, Conn.conn);
                MySqlDataReader rdr_select34 = cmd_select34.ExecuteReader();

                while (rdr_select34.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select34[0] + " -- " + rdr_select34[1];
                }
                rdr_select34.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //35.feladat
            try
            {
                string sql_select35 = "SELECT `valtopenz` FROM `orszagok` WHERE `valtopenz` not like 100";
                MySqlCommand cmd_select35 = new MySqlCommand(sql_select35, Conn.conn);
                MySqlDataReader rdr_select35 = cmd_select35.ExecuteReader();

                while (rdr_select35.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select35[0] + " -- " + rdr_select35[1];
                }
                rdr_select35.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                //36-40.feladat

                //36.feladat
                string sql_select36 = "SELECT COUNT(`orszag`) FROM `orszagok` WHERE `terulet`< 93025;";
                MySqlCommand cmd_select36 = new MySqlCommand(sql_select36, Conn.conn);
                MySqlDataReader rdr_select36 = cmd_select36.ExecuteReader();

                while (rdr_select36.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select36[0] + " -- " + rdr_select36[1];
                }
                rdr_select36.Close();
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //37.feladat
            try
            {
                string sql_select37 = "SELECT MAX(`terulet`),`orszag` FROM `orszagok` ";
                MySqlCommand cmd_select37 = new MySqlCommand(sql_select37, Conn.conn);
                MySqlDataReader rdr_select37 = cmd_select37.ExecuteReader();

                while (rdr_select37.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select37[0] + " -- " + rdr_select37[1];
                }
                rdr_select37.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

            //38.feladat
            try
            {
                string sql_select38 = "SELECT MIN(`terulet`),`orszag` FROM `orszagok` ";
                MySqlCommand cmd_select38 = new MySqlCommand(sql_select38, Conn.conn);
                MySqlDataReader rdr_select38 = cmd_select38.ExecuteReader();

                while (rdr_select38.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select38[0] + " -- " + rdr_select38[1];
                }
                rdr_select38.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //39.feladat
            try
            {
                string sql_select39 = "SELECT MAX(`nepesseg`),`orszag` FROM `orszagok` ";
                MySqlCommand cmd_select39 = new MySqlCommand(sql_select39, Conn.conn);
                MySqlDataReader rdr_select39 = cmd_select39.ExecuteReader();

                while (rdr_select39.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select39[0] + " -- " + rdr_select39[1];
                }
                rdr_select39.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //40.feladat
            try
            {
                string sql_select40 = "SELECT MIN(`nepesseg`),`orszag` FROM `orszagok` ";
                MySqlCommand cmd_select40 = new MySqlCommand(sql_select40, Conn.conn);
                MySqlDataReader rdr_select40 = cmd_select40.ExecuteReader();

                while (rdr_select40.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select40[0] + " -- " + rdr_select40[1];
                }
                rdr_select40.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                //41-45.feladat

                //41.feladat
                string sql_select41 = "SELECT MAX(`nepesseg`)/`terulet`,`orszag` FROM `orszagok`; ";
                MySqlCommand cmd_select41 = new MySqlCommand(sql_select41, Conn.conn);
                MySqlDataReader rdr_select41 = cmd_select41.ExecuteReader();

                while (rdr_select41.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select41[0] + " -- " + rdr_select41[1];
                }
                rdr_select41.Close();
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //42.feladat
            try
            {
                string sql_select42 = "SELECT MIN(`nepesseg`)/`terulet`,`orszag` FROM `orszagok` ; ";
                MySqlCommand cmd_select42 = new MySqlCommand(sql_select42, Conn.conn);
                MySqlDataReader rdr_select42 = cmd_select42.ExecuteReader();

                while (rdr_select42.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select42[0] + " -- " + rdr_select42[1];
                }
                rdr_select42.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

            //43.feladat
            try
            {
                string sql_select43 = "SELECT MAX(`terulet`),`orszag` FROM `orszagok`  WHERE `foldr_hely` like '%Afrika%'; ";
                MySqlCommand cmd_select43 = new MySqlCommand(sql_select43, Conn.conn);
                MySqlDataReader rdr_select43 = cmd_select43.ExecuteReader();

                while (rdr_select43.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select43[0] + " -- " + rdr_select43[1];
                }
                rdr_select43.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //44.feladat
            try
            {
                string sql_select44 = "SELECT `orszag`, MIN(`nepesseg`), MIN(`terulet`) FROM `orszagok` WHERE `foldr_hely` like '%Amerika%' ";
                MySqlCommand cmd_select44 = new MySqlCommand(sql_select44, Conn.conn);
                MySqlDataReader rdr_select44 = cmd_select44.ExecuteReader();

                while (rdr_select44.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select44[0] + " -- " + rdr_select44[1];
                }
                rdr_select44.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //45.feladat
            try
            {
                string sql_select45 = "SELECT `orszag` FROM `orszagok` order by `nepesseg` DESC limit 3";
                MySqlCommand cmd_select45 = new MySqlCommand(sql_select45, Conn.conn);
                MySqlDataReader rdr_select45 = cmd_select45.ExecuteReader();

                while (rdr_select45.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select45[0] + " -- " + rdr_select45[1];
                }
                rdr_select45.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                //51-55.feladat

                //51.feladat
                string sql_select51 = "SELECT LAST(`orszag`) FROM `orszagok` ORDER by `terulet` ASC limit 40; ";
                MySqlCommand cmd_select51 = new MySqlCommand(sql_select51, Conn.conn);
                MySqlDataReader rdr_select51 = cmd_select51.ExecuteReader();

                while (rdr_select51.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select51[0] + " -- " + rdr_select51[1];
                }
                rdr_select51.Close();
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //52.feladat
            try
            {
                string sql_select52 = "SELECT LAST(`terulet`/`nepesseg`) FROM `orszagok` ORDER by `terulet` ASC limit 40; ";
                MySqlCommand cmd_select52 = new MySqlCommand(sql_select52, Conn.conn);
                MySqlDataReader rdr_select52 = cmd_select52.ExecuteReader();

                while (rdr_select52.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select52[0] + " -- " + rdr_select52[1];
                }
                rdr_select52.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

            //53.feladat
            try
            {
                string sql_select53 = "SELECT `orszag` FROM `orszagok` WHERE `terulet` BETWEEN 90000 and 100000;";
                MySqlCommand cmd_select53 = new MySqlCommand(sql_select53, Conn.conn);
                MySqlDataReader rdr_select53 = cmd_select53.ExecuteReader();

                while (rdr_select53.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select53[0] + " -- " + rdr_select53[1];
                }
                rdr_select53.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //54.feladat
            try
            {
                string sql_select54 = "SELECT `orszag` FROM `orszagok`;";
                MySqlCommand cmd_select54 = new MySqlCommand(sql_select54, Conn.conn);
                MySqlDataReader rdr_select54 = cmd_select54.ExecuteReader();

                while (rdr_select54.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select54[0] + " -- " + rdr_select54[1];
                }
                rdr_select54.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //55.feladat
            try
            {
                string sql_select55 = "SELECT SUM(`terulet`)/17100000 FROM `orszagok`;";
                MySqlCommand cmd_select55 = new MySqlCommand(sql_select55, Conn.conn);
                MySqlDataReader rdr_select55 = cmd_select55.ExecuteReader();

                while (rdr_select55.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select55[0] + " -- " + rdr_select55[1];
                }
                rdr_select55.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                //61-65.feladat

                //61.feladat
                string sql_select61 = "SELECT DISTINCT(`allamforma`) FROM `orszagok` WHERE `foldr_hely` like '%Európa%'; ";
                MySqlCommand cmd_select61 = new MySqlCommand(sql_select61, Conn.conn);
                MySqlDataReader rdr_select61 = cmd_select61.ExecuteReader();

                while (rdr_select61.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select61[0] + " -- " + rdr_select61[1];
                }
                rdr_select61.Close();
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //62.feladat
            try
            {
                string sql_select62 = "SELECT COUNT(DISTINCT `allamforma`) FROM `orszagok`; ";
                MySqlCommand cmd_select62 = new MySqlCommand(sql_select62, Conn.conn);
                MySqlDataReader rdr_select62 = cmd_select62.ExecuteReader();

                while (rdr_select62.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select62[0] + " -- " + rdr_select62[1];
                }
                rdr_select62.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

            //63.feladat
            try
            {
                string sql_select63 = "SELECT COUNT(DISTINCT `penznem`) FROM `orszagok` WHERE `penznem` not like 'EURO';";
                MySqlCommand cmd_select63 = new MySqlCommand(sql_select63, Conn.conn);
                MySqlDataReader rdr_select63 = cmd_select63.ExecuteReader();

                while (rdr_select63.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select63[0] + " -- " + rdr_select63[1];
                }
                rdr_select63.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //64.feladat
            try
            {
                string sql_select64 = "SELECT COUNT(`penznem`) FROM `orszagok` HAVING COUNT(`penznem`) > 1;";
                MySqlCommand cmd_select64 = new MySqlCommand(sql_select64, Conn.conn);
                MySqlDataReader rdr_select64 = cmd_select64.ExecuteReader();

                while (rdr_select64.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select64[0] + " -- " + rdr_select64[1];
                }
                rdr_select64.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //65.feladat
            try
            {
                string sql_select65 = "SELECT `orszag` FROM `orszagok` WHERE `allamforma` like 'egyedi';";
                MySqlCommand cmd_select65 = new MySqlCommand(sql_select65, Conn.conn);
                MySqlDataReader rdr_select65 = cmd_select65.ExecuteReader();

                while (rdr_select65.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select65[0] + " -- " + rdr_select65[1];
                }
                rdr_select65.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                //56-60.feladat

                //56.feladat
                string sql_select56 = "SELECT COUNT(`nepesseg`) FROM `orszagok` WHERE `penznem` like 'EURO'; ";
                MySqlCommand cmd_select56 = new MySqlCommand(sql_select56, Conn.conn);
                MySqlDataReader rdr_select56 = cmd_select56.ExecuteReader();

                while (rdr_select56.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select56[0] + " -- " + rdr_select56[1];
                }
                rdr_select56.Close();
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //57.feladat
            try
            {
                string sql_select57 = "SELECT MAX(`gdp`) / MIn(`gdp`) FROM `orszagok` WHERE `gdp`>0; ";
                MySqlCommand cmd_select57 = new MySqlCommand(sql_select57, Conn.conn);
                MySqlDataReader rdr_select57 = cmd_select57.ExecuteReader();

                while (rdr_select57.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select57[0] + " -- " + rdr_select57[1];
                }
                rdr_select57.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

            //58.feladat
            try
            {
                string sql_select58 = "SELECT SUM(`gdp`) / 37300 FROM `orszagok` WHERE `gdp`>0;";
                MySqlCommand cmd_select58 = new MySqlCommand(sql_select58, Conn.conn);
                MySqlDataReader rdr_select58 = cmd_select58.ExecuteReader();

                while (rdr_select58.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select58[0] + " -- " + rdr_select58[1];
                }
                rdr_select58.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //59.feladat
            try
            {
                string sql_select59 = "SELECT SUM(`gdp`) / 49090 FROM `orszagok` WHERE `gdp`>0;";
                MySqlCommand cmd_select59 = new MySqlCommand(sql_select59, Conn.conn);
                MySqlDataReader rdr_select59 = cmd_select59.ExecuteReader();

                while (rdr_select59.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select59[0] + " -- " + rdr_select59[1];
                }
                rdr_select59.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //60.feladat
            try
            {
                string sql_select60 = "SELECT SUM(`terulet`) FROM `orszagok`;";
                MySqlCommand cmd_select60 = new MySqlCommand(sql_select60, Conn.conn);
                MySqlDataReader rdr_select60 = cmd_select60.ExecuteReader();

                while (rdr_select60.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select60[0] + " -- " + rdr_select60[1];
                }
                rdr_select60.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                //46-50.feladat

                //46.feladat
                string sql_select46 = "SELECT `nep_fovaros` FROM `orszagok` order by `nep_fovaros` DESC limit 6 ";
                MySqlCommand cmd_select46 = new MySqlCommand(sql_select46, Conn.conn);
                MySqlDataReader rdr_select46 = cmd_select46.ExecuteReader();

                while (rdr_select46.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select46[0] + " -- " + rdr_select46[1];
                }
                rdr_select46.Close();
            }
            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //47.feladat
            try
            {
                string sql_select47 = "SELECT `orszag`, MAX(`gdp`)/`nepesseg` FROM `orszagok`  ";
                MySqlCommand cmd_select47 = new MySqlCommand(sql_select47, Conn.conn);
                MySqlDataReader rdr_select47 = cmd_select47.ExecuteReader();

                while (rdr_select47.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select47[0] + " -- " + rdr_select47[1];
                }
                rdr_select47.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }

            //48.feladat
            try
            {
                string sql_select48 = "SELECT `orszag`, `gdp` FROM `orszagok` ORDER by `gdp` DESC limit 10 ";
                MySqlCommand cmd_select48 = new MySqlCommand(sql_select48, Conn.conn);
                MySqlDataReader rdr_select48 = cmd_select48.ExecuteReader();

                while (rdr_select48.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select48[0] + " -- " + rdr_select48[1];
                }
                rdr_select48.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //49.feladat
            try
            {
                string sql_select49 = "SELECT `orszag`, MIN(`gdp`) FROM `orszagok` ";
                MySqlCommand cmd_select49 = new MySqlCommand(sql_select49, Conn.conn);
                MySqlDataReader rdr_select49 = cmd_select49.ExecuteReader();

                while (rdr_select49.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select49[0] + " -- " + rdr_select49[1];
                }
                rdr_select49.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
            //50.feladat
            try
            {
                string sql_select50 = "SELECT `orszag` FROM `orszagok` WHERE   `gdp`>0 ORDER BY `gdp` asc limit 1";
                MySqlCommand cmd_select50 = new MySqlCommand(sql_select50, Conn.conn);
                MySqlDataReader rdr_select50 = cmd_select50.ExecuteReader();

                while (rdr_select50.Read())
                {
                    richTextBox1.Text += " \n " + rdr_select50[0] + " -- " + rdr_select50[1];
                }
                rdr_select50.Close();
            }

            catch (Exception err)
            {
                richTextBox1.Text += " \n " + err.ToString();
            }
        }

        
    }
}
    

