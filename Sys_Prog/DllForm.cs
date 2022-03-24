using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MessageBoxes;

namespace Sys_Prog
{
    
    public partial class DllForm : Form
    {
        [DllImport("user32.dll")]
        private                         // Указываем из какой библиотеки берем функцию
            static                      //подключенные Dll называются модули
            extern                      // DLL подключение только статическое
            uint                        // указываем, что метод описан в другом модуле
            MessageBoxA(                // Имя функции - поиск по имени, должно быть как в модуле
            IntPtr hWnd,                //типы данных - "наши" 
            String caption,             // если нет прямого совпадения типов - 
            String message,             // выбирается наиболее близкое (char* --> string)
            uint type);                 //
        
        public DllForm()
        {
            InitializeComponent();
        }

        private void buttonAlert_Click(object sender, EventArgs e)
        {
            // 0x40 - (i) - Ok
            // 0x11 - (x) - Ok|Cancel
            // 0x22 - (?) - Abort|Retry|Ignore
            // 0x33 - (!) - Yes|No|Cancel
            // 0x34 - (!) - Yes|No
            MessageBoxA((IntPtr)0, "Message", "Alert", 0x40);
        }

        private void buttonError_Click(object sender, EventArgs e)
        {
            MessageBoxA((IntPtr)0, "Message", "Error", 0x10);
        }

        private void buttonWarning_Click(object sender, EventArgs e)
        {
            Alerts.Warning("From Dll", "Warning");
        }

        private void buttonQuestion_Click(object sender, EventArgs e)
        {
            Alerts.Question("From Dll", "Question");
        }
    }

}
/* DLL - библиотеки динамической компоновки
 * + уменьшение исполняемого кода за счет отделения общих функций
 * в Dll
 * - переносимость: при копировании программы нужно не забыть библиотеку
 * + возможность использования функций из Dll в разных языках
 * 
 * - (в .NET) - возможно придется подключать неуправляемый код
 * + улучшенная (по сравнению с открытым кодом) защита авторских прав
 *  + удобство обновления программ - замена некоторых Dll
 *  
 *  в .NET мы можем иметь дело с "управляемымм" Dll (библиотеки классов)
 *  и неуправляемыми (обычно, созданные при помощи других языков)
 * */
