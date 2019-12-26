﻿using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using CMouse = Cosmos.System.MouseManager;
using Point = Cosmos.System.Graphics.Point;
using JackalOS.Drivers;

namespace JackalOS.Applications
{
    public class DrawApp
    {

        readonly int ScreenWidth = 800;
        readonly int ScreenHeight = 600;
        Pen MousePen = new Pen(Color.Black);
        static Color BackColor = Color.Beige;
        Pen GUIHomePen = new Pen(BackColor);
        Point PrevMouse = new Point(50,50);

        public DrawApp()
        {
        }
        /// <summary>
        /// Initialize the DrawApp.
        /// Not to be used outside the class.
        /// </summary>
        /// <param name="C">Canvas object</param>
        private void Initialize(Canvas C)
        {
            //Draw the bar above
            C.DrawFilledRectangle(new Pen(Color.LightCyan), 0, 0, ScreenWidth - 1, 20);
            C.DrawFilledRectangle(new Pen(Color.Red), ScreenWidth - 21, 0, 20, 20);
            C.DrawLine(new Pen(Color.Black,2), ScreenWidth - 21, 0, ScreenWidth - 1, 20);
            C.DrawLine(new Pen(Color.Black,2), ScreenWidth - 1, 0, ScreenWidth - 21, 20);
        }
        /// <summary>
        /// Local function to remove the mouse specifically for the DrawApp.
        /// Not to be used outside the class.
        /// </summary>
        /// <param name="C">Canvas Object</param>
        /// <param name="Remove">Point from which mouse is to be removed</param>
        private void RemoveMouse(Canvas C, Point Remove)
        {
            C.DrawFilledRectangle(GUIHomePen, Remove, 8, 8);
            if (Remove.Y <= 20)
            {
                Initialize(C);
            }
        }

        /// <summary>
        /// THis will launch the DrawApp on the current Canvas.
        /// </summary>
        /// <param name="C">Canvas on which DrawApp is to be launched.</param>
        public void Draw(Canvas C)
        {
            C.Clear(BackColor);
            Initialize(C);
            do
            {
                Point CurMouse = Mouse.MouseLimit((int)CMouse.X, (int)CMouse.Y);


                Mouse.DrawMouse(C, MousePen, CurMouse);

                if (Mouse.Click()){
                    //First Check Click on Power Button
                    if ((CurMouse.X > ScreenWidth - 21) && (CurMouse.X < ScreenWidth))
                    {
                        if (CurMouse.Y < 21)
                        {
                            return;
                        }
                    }

                    RemoveMouse(C, CurMouse);
                    do
                    {
                        CurMouse = Mouse.MouseLimit((int)CMouse.X, (int)CMouse.Y);
                        if ((PrevMouse.X != CurMouse.X) || (PrevMouse.Y != CurMouse.Y))
                        {
                            C.DrawLine(MousePen, CurMouse, PrevMouse);
                            PrevMouse = CurMouse;
                        }

                    } while (Mouse.Click());
                }
                else if ((PrevMouse.X != CurMouse.X) || (PrevMouse.Y != CurMouse.Y))
                {
                    RemoveMouse(C, PrevMouse);
                    PrevMouse = CurMouse;
                }

            } while (true);
        }
    }
}