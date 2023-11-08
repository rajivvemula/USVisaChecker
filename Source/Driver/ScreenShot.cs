using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Threading;
using HitachiQA.Driver;
using TechTalk.SpecFlow.Infrastructure;

namespace HitachiQA
{
    public class ScreenShot
    {
        public static ThreadLocal<ScreenShotTaker> ScreenShotTakerLocal = new();
        private static ScreenShotTaker ScreenShotTaker=> ScreenShotTakerLocal.Value;
        
        /// <summary> Sets up a screen shot taker for DEBUG severity </summary>
        public static ScreenShotTaker Debug => ScreenShotTaker.Debug();
        /// <summary> Sets up a screen shot taker for INFO severity </summary>
        public static ScreenShotTaker Info => ScreenShotTaker.Info();
        /// <summary> Sets up a screen shot taker for WARN severity </summary>
        public static ScreenShotTaker Warn => ScreenShotTaker.Warn();
        /// <summary> Sets up a screen shot taker for ERROR severity </summary>
        public static ScreenShotTaker Error => ScreenShotTaker.Error();
        /// <summary> Sets up a screen shot taker for CRITICAL severity </summary>
        public static ScreenShotTaker Critical => ScreenShotTaker.Critical();
        
    }
}
