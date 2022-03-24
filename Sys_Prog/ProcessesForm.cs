using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sys_Prog
{
    public partial class ProcessesForm : Form
    {
        public ProcessesForm()
        {
            InitializeComponent();
        }

        private void ShowProcesses()
        {
            Process [] processes = Process.GetProcesses();
            treeView1.Nodes.Clear();
            var root = new TreeNode("Active processes");//корень дерева
            foreach (var grp in processes.GroupBy(p=>p.ProcessName).OrderBy(x=>x.Key))
             {
                var node = new TreeNode();
                node.Text = $"{grp.Key} ({grp.Count()})";    //группа, содержащая ключ (имя) и итерирующаяся
                foreach (var process in grp)//элемент итерирования - процесс, сгруппированный
                {
                    var subnode = new TreeNode();
                    subnode.Text = $"{process.ProcessName} ({process.Id})";
                    node.Nodes.Add(subnode);
                }
                root.Nodes.Add(node);
             }
            treeView1.Nodes.Add(root);
        }
        private void buttonShow_Click(object sender, EventArgs e)
        {
            ShowProcesses();    
        }
    }
}

/* Процессы
 * Задание - сделать "диспетчер задач" - форму, отображающую список
 * активных процессов
 * Знакомство с элементом TreeView
 * 
 * Основные инструменты для работы с процессами предоставляет класс Process
 * из пространства имен using System.Diagnostics;
 * 
 * */
