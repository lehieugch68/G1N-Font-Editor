using G1N_Font_Editor.Helpers;
using System;
using System.Windows.Forms;

namespace G1N_Font_Editor.Components
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.AppIcon;
            this.pictureBoxAboutImg.Image = Properties.Resources.AppLogo;
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            labelVersion.Text = $"Ver. {Application.ProductVersion}";
        }

        private void linkLabelPjRepository_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenUrl(Global.APP_URLS["Repository"]);
        }

        private void linkLabelVHGForum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenUrl(Global.APP_URLS["VHGForum"]);
        }

        private void AboutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
