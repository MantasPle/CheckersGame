using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers.Classes
{
    public class Board
    {
        private Panel[,] CheckersBoard { get; set; }

        private Panel ClickedPanel { get; set; }

        private Panel _temp { get; set; }

        private Form _form;

        private bool _isWhiteTurn { get; set; }

        public Board()
        {
            _isWhiteTurn = true;
            CheckersBoard = new Panel[8, 8];
        }


        public void CreateBoard(Form form)
        {
            _form = form;
            for (var n = 0; n < 8; n++)
            {

                for (var m = 0; m < 8; m++)
                {
                    var newPanel = new Panel
                    {
                        Size = new Size(100, 100),
                        Location = new Point(100 * n, 100 * m),
                        BackgroundImageLayout = ImageLayout.Center

                    };

                    Label label = new Label();
                    label.Text = $"{n},{m}";
                    newPanel.Click += Panel_Click;
                    newPanel.Controls.Add(label);

                    if ((n + m) % 2 != 0 && m < 3)
                    {
                        newPanel.Name = "black";
                        newPanel.BackgroundImage = ResizePicture("BlackChecker.png");
                        newPanel.Controls.Add(label);
                    }
                    else if ((n + m) % 2 != 0 && m > 4)
                    {
                        newPanel.Name = "white";
                        newPanel.BackgroundImage = ResizePicture("WhiteChecker.png");
                        newPanel.Controls.Add(label);
                    }

                    form.Controls.Add(newPanel);
                    Checker checker = new Checker(newPanel);
                    CheckersBoard[n, m] = checker.Panel;

                    if (n % 2 == 0)
                    {
                        newPanel.BackColor = m % 2 != 0 ? Color.SaddleBrown : Color.SandyBrown;
                    }
                    else
                    {
                        newPanel.BackColor = m % 2 != 0 ? Color.SandyBrown : Color.SaddleBrown;
                    }

                }
            }
        }


        private void Panel_Click(object sender, EventArgs e)
        {

            ClickedPanel = sender as Panel;
            Color availableMove = Color.LightYellow;
            bool isKill;

            if (ClickedPanel.BackColor == availableMove)
            {
                isKill = Move();
                if (isKill)
                {
                    BackToNormalColors();
                    isKill = KillCheck();
                    if (!isKill)
                    {
                        _isWhiteTurn = !_isWhiteTurn;
                        CheckForWin();
                    }
                }
                else
                {
                    _isWhiteTurn = !_isWhiteTurn;
                    BackToNormalColors();

                }

            }
            else if (ClickedPanel.Name != "white" && ClickedPanel.Name != "black")
            {
                BackToNormalColors();
            }
            else if (ClickedPanel.Name == "white" && !_isWhiteTurn || ClickedPanel.Name == "black" && _isWhiteTurn)
            {
                BackToNormalColors();
            }
            else
            {
                BackToNormalColors();
                MoveCheck();
            }
        }
        private void MoveCheck()
        {
            int n = ClickedPanel.Location.X / 100;
            int m = ClickedPanel.Location.Y / 100;
            Color availableMove = Color.LightYellow;


            if (_isWhiteTurn)
            {

                KillCheck();

                try
                {
                    if (CheckersBoard[n + 1, m - 1].BackgroundImage == null)
                    {
                        CheckersBoard[n + 1, m - 1].BackColor = availableMove;
                        _temp = CheckersBoard[n, m];
                    }
                }
                catch (Exception) { }

                try
                {
                    if (CheckersBoard[n - 1, m - 1].BackgroundImage == null)
                    {
                        CheckersBoard[n - 1, m - 1].BackColor = availableMove;
                        _temp = CheckersBoard[n, m];
                    }
                }
                catch (Exception) { }

                return;
            }
            else
            {
                KillCheck();

                try
                {
                    if (CheckersBoard[n + 1, m + 1].BackgroundImage == null)
                    {
                        CheckersBoard[n + 1, m + 1].BackColor = availableMove;
                        _temp = CheckersBoard[n, m];
                    }
                }
                catch (Exception) { }

                try
                {
                    if (CheckersBoard[n - 1, m + 1].BackgroundImage == null)
                    {
                        CheckersBoard[n - 1, m + 1].BackColor = availableMove;
                        _temp = CheckersBoard[n, m];
                    }
                }
                catch (Exception) { }

                return;
            }
        }

        private bool KillCheck()
        {
            int n = ClickedPanel.Location.X / 100;
            int m = ClickedPanel.Location.Y / 100;
            Color availableMove = Color.LightYellow;
            bool isKill = false;

            if (_isWhiteTurn)
            {


                try
                {
                    if (CheckersBoard[n + 1, m - 1].Name == "black" && CheckersBoard[n + 2, m - 2].BackgroundImage == null)
                    {
                        CheckersBoard[n + 2, m - 2].BackColor = availableMove;
                        _temp = CheckersBoard[n, m];
                        isKill = true;
                    }
                }
                catch (Exception) { }

                try
                {
                    if (CheckersBoard[n - 1, m - 1].Name == "black" && CheckersBoard[n - 2, m - 2].BackgroundImage == null)
                    {
                        CheckersBoard[n - 2, m - 2].BackColor = availableMove;
                        _temp = CheckersBoard[n, m];
                        isKill = true;
                    }
                }
                catch (Exception) { }

                try
                {
                    if (CheckersBoard[n + 1, m + 1].Name == "black" && CheckersBoard[n + 2, m + 2].BackgroundImage == null)
                    {
                        CheckersBoard[n + 2, m + 2].BackColor = availableMove;
                        _temp = CheckersBoard[n, m];
                        isKill = true;
                    }
                }
                catch (Exception) { }

                try
                {
                    if (CheckersBoard[n - 1, m + 1].Name == "black" && CheckersBoard[n - 2, m + 2].BackgroundImage == null)
                    {
                        CheckersBoard[n - 2, m + 2].BackColor = availableMove;
                        _temp = CheckersBoard[n, m];
                        isKill = true;
                    }
                }
                catch (Exception) { }

                return isKill;

            }
            else
            {

                try
                {
                    if (CheckersBoard[n + 1, m + 1].Name == "white" && CheckersBoard[n + 2, m + 2].BackgroundImage == null)
                    {
                        CheckersBoard[n + 2, m + 2].BackColor = availableMove;
                        _temp = CheckersBoard[n, m];
                        isKill = true;
                    }
                }
                catch (Exception) { }

                try
                {
                    if (CheckersBoard[n - 1, m + 1].Name == "white" && CheckersBoard[n - 2, m + 2].BackgroundImage == null)
                    {
                        CheckersBoard[n - 2, m + 2].BackColor = availableMove;
                        _temp = CheckersBoard[n, m];
                        isKill = true;
                    }
                }
                catch (Exception) { }

                try
                {
                    if (CheckersBoard[n + 1, m - 1].Name == "white" && CheckersBoard[n + 2, m - 2].BackgroundImage == null)
                    {
                        CheckersBoard[n + 2, m - 2].BackColor = availableMove;
                        _temp = CheckersBoard[n, m];
                        isKill = true;
                    }
                }
                catch (Exception) { }

                try
                {
                    if (CheckersBoard[n - 1, m - 1].Name == "white" && CheckersBoard[n - 2, m - 2].BackgroundImage == null)
                    {
                        CheckersBoard[n - 2, m - 2].BackColor = availableMove;
                        _temp = CheckersBoard[n, m];
                        isKill = true;
                    }
                }
                catch (Exception) { }

                return isKill;

            }

        }

        public bool Move()
        {
            int startX = ClickedPanel.Location.X / 100;
            int startY = ClickedPanel.Location.Y / 100;

            int locX = _temp.Location.X / 100;
            int locY = _temp.Location.Y / 100;
            bool isKill = false;

            if (startX == locX - 2 && startY == locY - 2)
            {
                CheckersBoard[locX - 1, locY - 1].BackgroundImage = null;
                CheckersBoard[locX - 1, locY - 1].Name = "";
                isKill = true;
            }

            if (startX == locX + 2 && startY == locY - 2)
            {
                CheckersBoard[locX + 1, locY - 1].BackgroundImage = null;
                CheckersBoard[locX + 1, locY - 1].Name = "";
                isKill = true;
            }

            if (startX == locX - 2 && startY == locY + 2)
            {
                CheckersBoard[locX - 1, locY + 1].BackgroundImage = null;
                CheckersBoard[locX - 1, locY + 1].Name = "";
                isKill = true;
            }

            if (startX == locX + 2 && startY == locY + 2)
            {
                CheckersBoard[locX + 1, locY + 1].BackgroundImage = null;
                CheckersBoard[locX + 1, locY + 1].Name = "";
                isKill = true;
            }



            CheckersBoard[startX, startY].BackgroundImage = CheckersBoard[locX, locY].BackgroundImage;
            CheckersBoard[startX, startY].Name = CheckersBoard[locX, locY].Name;

            CheckersBoard[locX, locY].BackgroundImage = null;
            CheckersBoard[locX, locY].Name = "";



            return isKill;
        }

        private Image ResizePicture(string name)
        {
            Image NotResizedPicture = Image.FromFile($"Images\\{name}");
            Image image = new Bitmap(NotResizedPicture, 50, 50);

            return image;
        }

        private void BackToNormalColors()
        {
            for (int n = 0; n < 8; n++)
            {
                for (int m = 0; m < 8; m++)
                {
                    if (n % 2 == 0)
                    {
                        CheckersBoard[n, m].BackColor = m % 2 != 0 ? Color.SaddleBrown : Color.SandyBrown;
                    }
                    else
                    {
                        CheckersBoard[n, m].BackColor = m % 2 != 0 ? Color.SandyBrown : Color.SaddleBrown;
                    }
                }
            }
        }


        public void ResetBoard(Form form)
        {
            form.Controls.Clear();
            _isWhiteTurn = true;
            CreateBoard(form);
        }

        private void CheckForWin()
        {
            int whiteCount = 0;
            int blackCount = 0;

            foreach (var item in CheckersBoard)
            {
                if (item.Name == "white")
                {
                    whiteCount++;
                }
                else if (item.Name == "black")
                {
                    blackCount++;
                }
            }

            if (whiteCount == 0)
            {
                MessageBox.Show("Black wins!");
                _isWhiteTurn = true;
                ResetBoard(_form);
            }
            else if (blackCount == 0)
            {
                MessageBox.Show("White wins!");
                _isWhiteTurn = true;
                ResetBoard(_form);
            }



        }

    }
}
