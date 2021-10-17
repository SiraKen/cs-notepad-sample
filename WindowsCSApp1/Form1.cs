using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsCSApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /**
         * メニューバー操作：フォーマット
         * フォント設定
         */
        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            if (dialog.ShowDialog() != DialogResult.Cancel)
            {
                mainTextBox.Font = dialog.Font;
            }
        }

        /**
         * フォーム：閉じる
         * 終了時の動作
         */
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mainTextBox.Text != "")
            {
                MessageBox.Show("終了します。");
            }
        }

        /**
         * メニューバー操作：ファイル
         * アプリケーション終了
         */
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /**
         * メニューバー操作：ファイル => 新規作成
         * 
         */
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        /**
         * メニューバー操作：ファイル => 保存
         * ファイル保存
         */
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = false;
            
            if (dialog.ShowDialog() != DialogResult.Cancel)
            {
                var filename = dialog.FileName;
                if (File.Exists(filename))
                {
                    Console.WriteLine("The file exists.");
                    File.WriteAllText(filename, mainTextBox.Text);
                }
                else
                {
                    Console.WriteLine("The file does not exist. Creating...");
                    using (FileStream fileStream = File.Create(filename))
                    {
                        fileStream.Close();
                    }
                    File.WriteAllText(filename, mainTextBox.Text);
                }
                //File.WriteAllText("", mainTextBox.Text);
            }
            
        }

        /**
         * メニューバー操作：ファイル => 開く
         * ファイルを開く
         */
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() != DialogResult.Cancel)
            {
                var filename = dialog.FileName;
                using (FileStream fileStream = File.Open(filename, FileMode.Open))
                {
                    byte[] bytes = new byte[fileStream.Length];
                }
                
            }
        }
    }
}
