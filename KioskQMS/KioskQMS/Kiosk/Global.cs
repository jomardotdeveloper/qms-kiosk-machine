using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskQMS.Kiosk
{
    static class Global
    {
        public static bool IsFlag = true;
        public static bool IsDone = false;
        public static bool IsSuccess = false;


        public static void Reset()
        {
            IsFlag = true;
            IsDone = false;
            IsSuccess = false;
        }
    }
}
