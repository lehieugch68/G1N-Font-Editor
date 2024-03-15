﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace G1N_Font_Editor.Components
{
    public partial class NewG1NForm : Form
    {
        private int _totalPage;
        public int TotalPage { get { return _totalPage; } }
        public NewG1NForm()
        {
            InitializeComponent();
        }

        private void buttonNewG1NCreate_Click(object sender, EventArgs e)
        {
            _totalPage = (int)numericNewG1NTotalPage.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
