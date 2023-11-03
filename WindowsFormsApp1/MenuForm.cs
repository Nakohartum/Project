using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MenuForm : Form
    {
        public event Func<string> OnScoreShow;
        public MenuForm()
        {
            InitializeComponent();
            OnScoreShow?.Invoke();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Hide();
            new Form1(this).ShowDialog();
            Show();
            lblScore.Text = OnScoreShow.Invoke();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
