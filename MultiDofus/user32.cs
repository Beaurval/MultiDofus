using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;
using System.Text;
using Microsoft.VisualBasic;
using System.Diagnostics;
using MultiDofus.Classes;

namespace MultiDofus
{
    /// <summary>
    /// EnumDesktopWindows Demo - shows the caption of all desktop windows.
    /// Authors: Svetlin Nakov, Martin Kulov
    /// Bulgarian Association of Software Developers - http://www.devbg.org/en/
    /// </summary>
    public class user32
    {

        /// <summary>
        /// filter function
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public delegate bool EnumDelegate(IntPtr hWnd, int lParam);



        /// <summary>
        /// check if windows visible
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>
        /// return windows text
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpWindowText"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowText",
        ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpWindowText, int nMaxCount);

        /// <summary>
        /// enumarator on all desktop windows
        /// </summary>
        /// <param name="hDesktop"></param>
        /// <param name="lpEnumCallbackFunction"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows",
        ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDelegate lpEnumCallbackFunction, IntPtr lParam);


        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern public bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool turnOn);

        /// <summary>
        /// entry point of the program
        /// </summary>
        public static List<Perso> RecupererLesPersonnagesEnJeu()
        {
            var collection = new List<Perso>();
            user32.EnumDelegate filter = delegate (IntPtr hWnd, int lParam)
            {
                StringBuilder strbTitle = new StringBuilder(255);
                int nLength = user32.GetWindowText(hWnd, strbTitle, strbTitle.Capacity + 1);
                string strTitle = strbTitle.ToString();

                if (user32.IsWindowVisible(hWnd) && string.IsNullOrEmpty(strTitle) == false)
                {
                    if(strTitle.Contains("Dofus 2"))
                    {
                        Debug.WriteLine(strTitle);
                        collection.Add(new Perso
                        {
                            Pseudo = strTitle.Split(" ")[0],
                            ProcessHandler = hWnd
                        });
                    }  
                }
                return true;
            };

            user32.EnumDesktopWindows(IntPtr.Zero, filter, IntPtr.Zero);

            return collection;
        }
    }

}