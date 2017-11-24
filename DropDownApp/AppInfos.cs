using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace DropDownApp
{
    public static class AppInfos
    {

        private static double coeff = AppSettings.Default.CoeffOccupation;

        public static Key GlobalHotKey
        {
            get
            {
                try
                {
                    return (Key)Enum.Parse(typeof(Key), AppSettings.Default.HotKey, true);
                }
                catch
                {
                    return Key.F9;
                }
            }
        }


        public static double Height
        {
            get
            {
                return coeff * ScreenInfos.Height;
            }
        }

        public static double Width
        {
            get
            {
                return ScreenInfos.Width;
            }
        }

        public static double NegAppHeight
        {
            get
            {
                return -Height;
            }
        }

        public static KeyTime DureeAnim
        {
            get
            {
                return KeyTime.FromTimeSpan(AppSettings.Default.DureeAnim);
            }
        }

        public static TimeSpan HalfDureeAnim
        {
            get
            {
                return TimeSpan.FromMilliseconds(AppSettings.Default.DureeAnim.TotalMilliseconds / 2.0);
            }
        }

        public static double Opacity
        {
            get
            {
                return AppSettings.Default.OpacityMax;
            }
        }

    }
}
