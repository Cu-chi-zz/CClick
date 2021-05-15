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
        public bool InitializeSettingsFormParameters(SettingsForm f, bool p, bool p2, bool p3)
        {
            try
            {
                f.soundEffectCheckBox.Checked = p;
                f.saveLogsCheckBox.Checked = p2;
                f.progressBarCheckbox.Checked = p3;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}