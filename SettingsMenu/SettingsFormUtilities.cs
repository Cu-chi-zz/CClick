using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CClick.SettingsMenu
{
    internal class SettingsFormUtilities
    {
        public bool InitializeSettingsFormParameters(SettingsForm f, bool p)
        {
            try
            {
                f.soundEffectCheckBox.Checked = p;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}