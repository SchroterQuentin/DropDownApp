using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace CryptoManager
{
    public static class ScreenInfos
    {
        public static double Width
        {
            get
            {
                return System.Windows.SystemParameters.PrimaryScreenWidth;
            }
        }

        public static double Height
        {
            get
            {
                return System.Windows.SystemParameters.PrimaryScreenHeight;
            }
        }
    }

}
