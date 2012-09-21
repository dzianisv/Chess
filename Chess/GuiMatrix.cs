﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Chess.Figures;

namespace Chess
{
    public class Spot
    {
        public int X;
        public int Y;
        public Color sColor;
        public Image image;
        public bool Highlighted { get; set; }  // Для выделения возможных шагов
        public bool Focused { get; set; }      // Мышь наведена на эту клетку
        public bool Selected { get; set; }
        public Spot(int x, int y, Color clr, Image img)
        {
            X = x;
            Y = y;
            sColor = clr;
            image = img;
            Highlighted = false;
            Focused = false;
            Selected = false;
        }
    }

    public class GuiMatrix
    {
        private Point oldFocused;
        private Point oldSelected;
        private Spot [,] sMatrix;

        public Spot GetSpot(int i, int j)
        {
            return sMatrix[i, j];
        }
        public bool MakeFocused(int i, int j)
        {
            if (oldFocused.X == i && oldFocused.Y == j) return false;
            if (oldFocused.X != int.MaxValue) sMatrix[oldFocused.X, oldFocused.Y].Focused = false;
            oldFocused.X = i;
            oldFocused.Y = j;
            sMatrix[i, j].Focused = true;
            return true;
        }
        public bool MakeSelected(int i, int j)
        {
            if (oldSelected.X == i && oldSelected.Y == j)
            {
                sMatrix[i, j].Selected = !sMatrix[i, j].Selected;
                return true;
            }
            if (oldSelected.X != int.MaxValue) sMatrix[oldSelected.X, oldSelected.Y].Selected = false;
            oldSelected.X = i;
            oldSelected.Y = j;
            sMatrix[i, j].Selected = true;
            return true;
        }
        public bool SetImage(Image img, Position pos)
        {
            sMatrix[pos.X, pos.Y].image = img;
            return true;
        }
        public bool MoveImage(Position posOld, Position posNew)
        {
            sMatrix[posNew.X, posNew.Y].image = sMatrix[posOld.X, posOld.Y].image;
            sMatrix[posOld.X, posOld.Y].image = null;
            return true;
        }
        public GuiMatrix()
        {
            oldFocused = new Point(int.MaxValue, int.MaxValue);
            oldSelected = new Point(int.MaxValue, int.MaxValue);
            sMatrix = new Spot[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        sMatrix[i, j] = new Spot(i, j, Color.CadetBlue, null);
                    }
                    else
                    {
                        sMatrix[i, j] = new Spot(i, j, Color.White, null);
                    }
                }
            }
        }

    }
}