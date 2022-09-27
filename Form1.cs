using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Colore = Corale.Colore.Core.Color;
using Color = System.Drawing.Color;
using static RazerKeyboardRecoloring.Extentions;
using System.Data.Common;
using System.Text.RegularExpressions;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;

namespace RazerKeyboardRecoloring
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start();
        }

        public static DateTime startTime;
        public static Button[,] keyboardButtons;
        public static Colore[][] keyboardColores = new Colore[6][];
        private static bool buttonsInitiated;
        private static bool running;
        private static bool toggleRainbowHue;
        public void Start()
        {
            InitControl();
            startTime = DateTime.Now;
            Console.WriteLine("Razer keyboard recoloring started");
            Corale.Colore.Core.Chroma._instance = new Corale.Colore.Core.Chroma();
            running = true;
            Thread.Sleep(1000);
            Thread colorsUpdate = new Thread(() =>
            {
                while (!buttonsInitiated)
                    Thread.Sleep(100);

                while (running)
                {
                    Thread.Sleep(50);
                    try
                    {
                        if (toggleRainbowHue)
                        {
                            List<Colore> coloresList = new List<Colore>();
                            Colore[] columns;
                            coloresList.Clear();
                            columns = Extentions.GetAnimatedGradient(22, rainbowHUE, false, 2, 0.5f).ToColore().Reverse().ToArray();
                            //columns = new Colore[6] { Colore.White, Colore.White, Colore.White, Colore.White, Colore.White, Colore.White };
                            var hueColors = new Colore[][] { columns, columns, columns, columns, columns, columns };

                            for (int row = 0; row < 6; row++)
                            {
                                var tempColores = new Colore[22];
                                for (int column = 0; column < 22; column++)
                                {
                                    keyboardButtons[row, column].BackColor = hueColors[row][column].ToColor();
                                }
                            }

                            Keyboard.Instance.Set(hueColors);
                            Mouse.Instance.Set(columns[12]);     //6 element from 6 [5] and 12 [11] el from 22 where 11 for each part of keyboard
                        }
                        else
                        {
                            Keyboard.Instance.Set(keyboardColores);
                            Mouse.Instance.Set(keyboardColores[0][21]);
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show($"Exception: {exc.Message}");
                    }
                }
            });
            colorsUpdate.IsBackground = true;
            colorsUpdate.Start();
        }

        public void InitControl()
        {
            keyboardButtons = new Button[6, 22];
            int rows = 6;
            int columns = 22;
            this.SuspendLayout();
            for (int row = 0; row < rows; row++)
            {
                var tempColores = new Colore[22];
                for (int column = 0; column < columns; column++)
                {
                    var button = new Button();
                    button.Location = new System.Drawing.Point(50 * column, 100 + (50 * row));
                    button.Name = $"button_row{row}_column{column}";
                    button.Size = new System.Drawing.Size(50, 50);
                    button.TabIndex = 0;
                    button.UseVisualStyleBackColor = true;
                    button.BackColor = Color.White;
                    button.MouseDown += Button_MouseClick;
                    this.Controls.Add(button);
                    keyboardButtons[row,column] = button;
                    tempColores[column] = Colore.White;
                }
                keyboardColores[row] = tempColores;
            }
            this.ResumeLayout(false);
            buttonsInitiated = true;
        }


        private void lmbColorBtn_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var button = ((Button)sender);
            var name = button.Name;
            var mouseButton = e.Button;
            if (mouseButton == MouseButtons.Left)
            {
                ColorDialog col = new ColorDialog();
                if (col.ShowDialog() == DialogResult.OK)
                {
                    button.BackColor = col.Color;
                }
            }
            else
                button.BackColor = name.StartsWith("lmb") ? Color.Red :
                                    name.StartsWith("rmb") ? Color.Yellow :
                                    name.StartsWith("mmb") ? Color.Green :
                                    name.StartsWith("mb4") ? Color.Cyan :
                                    name.StartsWith("mb5") ? Color.Purple : Color.White;
        }

        private void Button_MouseClick(object sender, MouseEventArgs e)
        {
            var mouseButton = e.Button;
            Color finalColor = Color.White;
            switch (mouseButton)
            {
                case MouseButtons.Left:
                    finalColor = lmbColorBtn.BackColor;
                    break;
                case MouseButtons.Right:
                    finalColor = rmbColorBtn.BackColor;
                    break;
                case MouseButtons.Middle:
                    finalColor = mmbColorBtn.BackColor;
                    break;
                case MouseButtons.XButton1:
                    finalColor = mb5ColorBtn.BackColor;
                    break;
                case MouseButtons.XButton2:
                    finalColor = mb4ColorBtn.BackColor;
                    break;
                default:
                    break;
            }

            var name = ((Button)sender).Name;
            var row = int.Parse(Regex.Split(Regex.Split(name, "row")[1], "_")[0]);
            var column = int.Parse(Regex.Split(name, "column")[1]);


            keyboardColores[row][column] = finalColor.ToColore();
            keyboardButtons[row, column].BackColor = finalColor;



            /*MessageBox.Show($"{mouseButton} ({(int)mouseButton}");

            var currentColor = Color.White;
            switch (currentKey)
            {
                case 0:
                    currentColor = Color.White;
                    break;
                case 1:
                    currentColor = Color.Red;
                    break;
                case 2:
                    currentColor = Color.Green;
                    break;
                case 3:
                    currentColor = Color.Blue;
                    break;
                case 4:
                    currentColor = Color.Magenta;
                    break;
                case 5:
                    currentColor = Color.Yellow;
                    break;
                case 6:
                    currentColor = Color.Cyan;
                    break;
                default:
                    currentColor = Color.White;
                    break;
            }
            keyboardColores[row][column] = currentColor.ToColore();
            keyboardButtons[row, column].BackColor = currentColor;
            return;
            //MessageBox.Show($"name: {name} row: {row} column: {column}");
            ColorDialog col = new ColorDialog();
            //var oldColore = keyboardColores[row][column];
            //coloreSelecting = true;
            if (col.ShowDialog() == DialogResult.OK)
            {
                var color = col.Color;
                //MessageBox.Show($"{color.R}, {color.G}, {color.B}");
                keyboardColores[row][column] = color.ToColore();
                keyboardButtons[row, column].BackColor = color;
            }
            //var newColore = keyboardColores[row][column];
            //MessageBox.Show($"old colore: {oldColore.R}, {oldColore.G}, {oldColore.B}\nnew colore: {newColore.R}, {newColore.G}, {newColore.B}");
            //coloreSelecting = false;*/
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
        }

        private void RecolorKeyboard_Click(object sender, MouseEventArgs e)
        {
            var button = e.Button;
            if (button == MouseButtons.Left)
            {
                ColorDialog col = new ColorDialog();
                if (col.ShowDialog() == DialogResult.OK)
                {
                    var color = col.Color;

                    for (int row = 0; row < 6; row++)
                    {
                        var tempColores = new Colore[22];
                        for (int column = 0; column < 22; column++)
                        {
                            tempColores[column] = color.ToColore();
                            keyboardButtons[row, column].BackColor = color;
                        }
                        keyboardColores[row] = tempColores;
                    }
                }
            }
            else
            {
                toggleRainbowHue = !toggleRainbowHue;
                if (!toggleRainbowHue)
                {

                    for (int row = 0; row < 6; row++)
                    {
                        var tempColores = new Colore[22];
                        for (int column = 0; column < 22; column++)
                        {
                            keyboardButtons[row, column].BackColor = keyboardColores[row][column].ToColor();
                        }
                    }
                }
            }
        }

        private void recolorKeyboard_MouseDown(object sender, MouseEventArgs e) => RecolorKeyboard_Click(sender, e);
    }
}
