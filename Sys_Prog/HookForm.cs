using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Sys_Prog
{
    public partial class HookForm : Form
    {
        private const int WM_KEYDOWN = 0x0100; //номер события клавиатуры(нажатие)
        private const int WM_KEYBOARD_LL = 13; //номер хука (клавиатура, LowLevel)

        private delegate IntPtr HookProc(    //"Наш" код, встраиваемый как хук
            int nCode,                       // код события 
            IntPtr wParam,                   // параметры: числовой
            IntPtr lParam);                  // адресный

        #region Import Dll
        [DllImport ("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(
            int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport ("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hHook);

        [DllImport ("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(String lpModuleName);
        #endregion

        public HookForm()
        {
            InitializeComponent();
            list1 = listBox1;
            kbHook = (IntPtr)null;
        }

        private static HookProc kbProc = KbHookCallback; // "адрес" нашего обрабртчика
        private static IntPtr kbHook; // здесь будет сохранен исходный адрес обработчика
        private static ListBox list1; //статическая ссылка на динамический обьект
        //хуки только статики, обязаны нахоидться в модуле(в EXE)
        private static IntPtr KbHookCallback (int nCode, IntPtr wParam, IntPtr lParam)
        {
            if(nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                //перехвачено событие нажатия клавиатуры
                //извлекаем код клавиши, поскольку событие системное. переносим данные
                //из неуправляемой памяти
                int keyCode = Marshal.ReadInt32(lParam);//считать 32 бита по адресу lParam
                //переводим в С# enum
                Keys keyEnum = (Keys)keyCode;
                list1.Items.Add(keyEnum.ToString());
                if (keyEnum == Keys.Space)          //Возврат 1 вместо CallNextHookEx приводит к
                    return (IntPtr) 1;              //  игнорированию события - пробел не работает
            }
            return CallNextHookEx(                  //Возврат к сохраненному обработчику
                kbHook,                             // сохраненный адрес (при старте хука0
                nCode, wParam, lParam);             // проброс принятых параметров
        }

        private void buttonStartKB_Click(object sender, EventArgs e)
        {
            if (kbHook == (IntPtr)null)
            {
                using (Process process = Process.GetCurrentProcess())
                using (ProcessModule module = process.MainModule)
                {
                    kbHook                          //сохраняем адрес предыдущего хука
                        = SetWindowsHookEx(         //по принципу "выталкивания" - новый пишется. старый возвращается
                        WM_KEYBOARD_LL,              // Номер хука (см. документацию WinAPI)
                        kbProc,                      // новый адрес
                        GetModuleHandle(             // указание на модуль, в котором статиком реализована
                            module.ModuleName),     // kbProc
                        0);                          // доп.параметры - нет
                }
                listBox1.Items.Add("Kb start");
            }
            else
            {
                listBox1.Items.Add("Already started");
                return;
            }
        }
        //Задание: предотвратить повторное включение хука, а также выключение несуществующего хука
        private void buttonStopKB_Click(object sender, EventArgs e)
        {
            if (kbHook != (IntPtr)null)
            {
                UnhookWindowsHookEx(kbHook); //Удаление хука - процедура выводится из цепочки
                listBox1.Items.Add("Kb Stop");
                kbHook = (IntPtr)null;
            }
            else
            {
                listBox1.Items.Add("Already stopped");
                return;
            }
        }
    }
    

}

/*Hook (Системные хуки)
 * Хуки - (дословно - крюки) - технологии, позволяющие встаривать собственные
 * коды в системную работу. Обычно, хуки применяются для перехвата событий на подобие
 * клавиатуры или мыши.
 * 
 * 
 * клавиша  ---- BIOS ----Intr ----OS |Intr0|Intr1|Intr2|.....|Intr255|
 *                                              /
 *                                             / 
 *                                            /     (Keyboard Handler)
 *                                           /          /
 *                                       (Наша процедура)
 * Суть хука: подменить адрес стандартного обработчика (intr1) на наш (intrH),
 * запомнив его (intr1). После наших действий вернуть управление, переведя работу
 * по сохраненному адресу
 * 
 *  клавиша  ---- BIOS ----Intr ----OS |Intr0|Intr1|Intr2|.....|Intr255|
 *                                                      /
 *                                                     / 
 *                                                    /     (Keyboard Handler)
 *                                                   /          /
 *                                                (Наша процедура)
 *                                                
 *   Хуков может быть сколько угодно. Нужно предотвращать повторные создания хуков
 *   (несколько раз стартовать хуки)
 * */
