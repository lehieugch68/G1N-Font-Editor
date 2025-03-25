using System;
using System.Windows.Forms;

namespace G1N_Font_Editor.Components
{
    public partial class NewG1NForm : Form
    {
        private int _totalPage;
        public int TotalPage { get { return _totalPage; } }
        private bool _is8Bpp;
        public bool Is8Bpp { get { return _is8Bpp; } }
        public NewG1NForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.AppIcon;
        }

        private void buttonNewG1NCreate_Click(object sender, EventArgs e)
        {
            _totalPage = (int)numericNewG1NTotalPage.Value;
            _is8Bpp = checkBox8Bpp.Checked;
            DialogResult = DialogResult.OK;
        }

        private void NewG1NForm_Load(object sender, EventArgs e)
        {
            numericNewG1NTotalPage.Focus();
        }
    }
}
