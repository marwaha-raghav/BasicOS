﻿using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.HAL;
using System.Drawing;
using CMouse = Cosmos.System.MouseManager;
using Point = Cosmos.System.Graphics.Point;


namespace CosmosKernel1.Drivers
{
    public static class Mouse
    {
        public static readonly int ScreenWidth = 800;
        public static readonly int ScreenHeight = 600;
        public static Sys.MouseState PrevMouseState = CMouse.MouseState;
        
        /// <summary>
        /// This function will draw the mouse on the Sceen. It is advisable to not call this function directly, but use the MouseAction function. 
        /// </summary>
        /// <param name="C">Canvas onto which mouse is to be drawn</param>
        /// <param name="pen">Pen with which mouse is to be drawn</param>
        public static void DrawMouse(Canvas C, Pen pen, Point CurMouse)
        {
            //CurMouse = MouseLimit((int)CurMouse.X, (int)CurMouse.Y);
            //Mouse Traingle Points are Below
            C.DrawPoint(pen, CurMouse.X, CurMouse.Y);
            C.DrawPoint(pen, new Point(CurMouse.X + 1, CurMouse.Y));
            C.DrawPoint(pen, new Point(CurMouse.X + 2, CurMouse.Y));
            C.DrawPoint(pen, new Point(CurMouse.X + 3, CurMouse.Y));
            C.DrawPoint(pen, new Point(CurMouse.X + 4, CurMouse.Y));
            C.DrawPoint(pen, new Point(CurMouse.X + 5, CurMouse.Y));

            C.DrawPoint(pen, new Point(CurMouse.X, CurMouse.Y + 1));
            C.DrawPoint(pen, new Point(CurMouse.X + 1, CurMouse.Y + 1));
            C.DrawPoint(pen, new Point(CurMouse.X + 2, CurMouse.Y + 1));
            C.DrawPoint(pen, new Point(CurMouse.X + 3, CurMouse.Y + 1));
            C.DrawPoint(pen, new Point(CurMouse.X + 4, CurMouse.Y + 1));

            C.DrawPoint(pen, new Point(CurMouse.X, CurMouse.Y + 2));
            C.DrawPoint(pen, new Point(CurMouse.X + 1, CurMouse.Y + 2));
            C.DrawPoint(pen, new Point(CurMouse.X + 2, CurMouse.Y + 2));
            C.DrawPoint(pen, new Point(CurMouse.X + 3, CurMouse.Y + 2));

            C.DrawPoint(pen, new Point(CurMouse.X, CurMouse.Y + 3));
            C.DrawPoint(pen, new Point(CurMouse.X + 1, CurMouse.Y + 3));
            C.DrawPoint(pen, new Point(CurMouse.X + 2, CurMouse.Y + 3));

            C.DrawPoint(pen, new Point(CurMouse.X, CurMouse.Y + 4));
            C.DrawPoint(pen, new Point(CurMouse.X + 1, CurMouse.Y + 4));

            C.DrawPoint(pen, new Point(CurMouse.X, CurMouse.Y + 5));
            // Mouse Triangle Over

            //Mouse Tail points are below
            C.DrawPoint(pen, new Point(CurMouse.X + 3, CurMouse.Y + 3));
            C.DrawPoint(pen, new Point(CurMouse.X + 4, CurMouse.Y + 4));
            C.DrawPoint(pen, new Point(CurMouse.X + 5, CurMouse.Y + 5));
            C.DrawPoint(pen, new Point(CurMouse.X + 6, CurMouse.Y + 6));
            C.DrawPoint(pen, new Point(CurMouse.X + 7, CurMouse.Y + 7));
            
        }

        /// <summary>
        /// Thsi function ensures that the Mouse stays within the screen bounds.
        /// </summary>
        /// <param name="x">X coordinate of the Mouse</param>
        /// <param name="y">Y coordinate of the Mouse</param>
        /// <returns></returns>
        public static Point MouseLimit(int x, int y)
        {
            if (x < 0)
            {
                x = 0;
            }
            if (x > (ScreenWidth - 8))
            {
                x = (ScreenWidth - 8);
            }
            if (y < 0)
            {
                y = 0;
            }
            if (y > (ScreenHeight - 8))
            {
                y = (ScreenHeight - 8);
            }

            return new Point(x, y);
        }

        public static bool Click()
        {
            if (Sys.MouseState.Left == CMouse.MouseState)
            {
                return true;
            }
            return false;
        }

        public static void MouseForDraw(Canvas C, Pen mousePen, Point CurMouse, Point PrevMouse)
        {
            C.DrawLine(mousePen, PrevMouse, CurMouse);
        }
        

    }
}