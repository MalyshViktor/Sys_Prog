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
            treeView1.Nodes.Clear();    //очищаем наше дерево
            var root = new TreeNode("Active processes"); //корневой элемент дерева и текст узла ("Active processes")
            foreach (var grp in processes       //Процессы
                .GroupBy(p=> p.ProcessName)     //группируем по имени
                .OrderBy(x=>x.Key))             // сортируем по ключу группировки - по имени
            {
                var node = new TreeNode();
                node.Text = $"{grp.Key} ({grp.Count()})";            //группа, содержащая ключ (имя) и итерирующаяся
                foreach (var process in grp)    //элемен итерирования - процесс, сгруппированный GroupBy
                {
                    var subnode = new TreeNode();   
                    subnode.Text = $"{process.ProcessName} ( {process.Id})";
                    node.Nodes.Add(subnode);
                    //foreach (var t in process.Threads)
                    //{
                       
                    //}
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


    /*
     * Процессы - сделать диспетчер задач - форму, отображающую список
     * активных процессов
     * Знакомство с элементом TreeView
     * Основные инструменты по работе с процессами предоставляет класс процесс 
     * из пространства имен
     * using System.Diagnostics;
     * 
     * 
     * */
}
