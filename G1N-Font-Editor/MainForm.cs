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
using System.Drawing.Text;

namespace G1N_Font_Editor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadSytemFonts()
        {
            try
            {
                using (InstalledFontCollection col = new InstalledFontCollection())
                {
                    comboBoxOptFont.BeginInvoke((MethodInvoker)delegate
                    {
                        comboBoxOptFont.Items.Clear();
                        foreach (FontFamily fa in col.Families)
                        {
                            comboBoxOptFont.Items.Add(fa.Name);
                        }
                    });
                }
            }
            catch (Exception ex) { }
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                Global.IS_BUSY = true;
                string filePath = Utils.FileBrowser("", Global.G1N_FILE_FILTER);
                if (!string.IsNullOrEmpty(filePath))
                {
                    textBoxFilePath.Text = filePath;
                }
                Task.Run(() =>
                {
                    try
                    {
                        Global.G1N_FILE = new G1N(textBoxFilePath.Text);
                        comboBoxFont.BeginInvoke((MethodInvoker)delegate
                        {
                            comboBoxFont.Items.Clear();
                            foreach (var fontId in Global.G1N_FILE.GlyphTables)
                            {
                                ComboboxItem item = new ComboboxItem();
                                item.Text = $"Font {fontId.Index}";
                                item.Value = fontId.Index;
                                comboBoxFont.Items.Add(item);
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        Global.IS_BUSY = false;
                        MessageBox.Show(ex.ToString(), Global.MESSAGEBOX_TITLE);
                    }
                }).GetAwaiter().OnCompleted(() =>
                {
                    Global.IS_BUSY = false;
                    if (comboBoxFont.Items.Count > 0) comboBoxFont.SelectedIndex = 0;
                });
            }
        }
        private void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                Global.IS_BUSY = true;
                int fontId = (int)((ComboboxItem)comboBoxFont.Items[comboBoxFont.SelectedIndex]).Value;
                Task.Run(() =>
                {
                    try
                    {
                        var glyphTable = Global.G1N_FILE.GlyphTables.Find(g => g.Index == fontId);
                        Bitmap texPic = glyphTable.GetTablePreview();
                        pictureBox.BeginInvoke((MethodInvoker)delegate
                        {
                            pictureBox.BackColor = Color.Black;
                            pictureBox.Image = texPic;
                        });
                        Bitmap palettePic = glyphTable.GetPalettePreview();
                        pictureBoxOptPalette.BeginInvoke((MethodInvoker)delegate
                        {
                            pictureBoxOptPalette.BackColor = Color.Transparent;
                            pictureBoxOptPalette.Image = palettePic;
                        });
                    }
                    catch (Exception ex)
                    {
                        Global.IS_BUSY = false;
                        MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                    }
                }).GetAwaiter().OnCompleted(() =>
                {
                    Global.IS_BUSY = false;
                });
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                textBoxOptFontSize.Text = Global.DEFAULT_TTF_FONT_SIZE.ToString();
                Task.Run(() =>
                {
                    LoadSytemFonts();
                });
            }
            catch (Exception ex) { }
        }

        private void comboBoxOptFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOptFont.SelectedIndex == -1) return;
            try
            {
                textBoxOptFontPath.Text = string.Empty;
                Global.TTF_FONT_FAMILY_NAME = comboBoxOptFont.SelectedItem.ToString();
                Global.TTF_FONT_FAMILY = new FontFamily(Global.TTF_FONT_FAMILY_NAME);
                updateOptFontStyle();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString(), Global.MESSAGEBOX_TITLE);
            }
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else if (Global.G1N_FILE == null || Global.TTF_FONT_FAMILY == null || textBoxOptFontSize.Text.Length <= 0 || comboBoxOptFontStyle.SelectedIndex < 0)
            {

            }
            else
            {
                Global.IS_BUSY = true;
                var fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), comboBoxOptFontStyle.SelectedItem.ToString());
                var fontSize = int.Parse(textBoxOptFontSize.Text);
                var fontId = (int)((ComboboxItem)comboBoxFont.Items[comboBoxFont.SelectedIndex]).Value;
                var chars = textBoxCharsOpt.Text.ToCharArray();
                int addCustomBaseLine = 0, addCustomLeftSide = 0, addCustomAdvWidth = 0;
                int.TryParse(textBoxOptBaseline.Text, out addCustomBaseLine);
                int.TryParse(textBoxOptLeftSide.Text, out addCustomLeftSide);
                int.TryParse(textBoxOptAdvWidth.Text, out addCustomAdvWidth);
                var glyphCustomValue = new GlyphCustomValue(addCustomBaseLine, addCustomLeftSide, addCustomAdvWidth);
                Task.Run(() =>
                {
                    try
                    {
                        var glyphTypeface = FontHelper.GetGlyphTypeface(Global.TTF_FONT_FAMILY_NAME, fontStyle);
                        var font = new Font(Global.TTF_FONT_FAMILY, fontSize, fontStyle);
                        var glyphTable = Global.G1N_FILE.GlyphTables.Find(table => table.Index == fontId);
                        glyphTable.Build(glyphTypeface, font, chars);
                        var newData = Global.G1N_FILE.Build(glyphCustomValue);
                        glyphTable.ReloadTablePreview();
                        Bitmap texPic = glyphTable.GetTablePreview();
                        pictureBox.BeginInvoke((MethodInvoker)delegate
                        {
                            pictureBox.BackColor = Color.Black;
                            pictureBox.Image = texPic;
                        });
                        Bitmap palettePic = glyphTable.GetPalettePreview();
                        pictureBoxOptPalette.BeginInvoke((MethodInvoker)delegate
                        {
                            pictureBoxOptPalette.BackColor = Color.Transparent;
                            pictureBoxOptPalette.Image = palettePic;
                        });

                    }
                    catch (Exception ex)
                    {
                        Global.IS_BUSY = false;
                        MessageBox.Show(ex.ToString(), Global.MESSAGEBOX_TITLE);
                    }
                }).GetAwaiter().OnCompleted(() =>
                {
                    Global.IS_BUSY = false;
                });
            }
        }

        private void buttonCharsFromFile_Click(object sender, EventArgs e)
        {
            string filePath = Utils.FileBrowser("", Global.TXT_FILE_FILTER);
            if (!string.IsNullOrEmpty(filePath))
            {
                Task.Run(() =>
                {
                    try
                    {
                        string chars = Utils.RemoveDuplicates(File.ReadAllText(filePath).Replace("\r", string.Empty).Replace("\n", string.Empty));
                        textBoxCharsOpt.BeginInvoke((MethodInvoker)delegate
                        {
                            textBoxCharsOpt.Text = chars;
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                    }
                });
            }
        }

        private void buttonOptFontFromFile_Click(object sender, EventArgs e)
        {
            string filePath = Utils.FileBrowser("", Global.FONT_FILE_FILTER);
            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    textBoxOptFontPath.Text = filePath;
                    comboBoxOptFont.SelectedIndex = -1;
                    PrivateFontCollection collection = new PrivateFontCollection();
                    collection.AddFontFile(filePath);
                    Global.TTF_FONT_FAMILY = new FontFamily(collection.Families.LastOrDefault().Name, collection);
                    Global.TTF_FONT_FAMILY_NAME = Path.Combine(Path.GetDirectoryName(filePath), $"#{Global.TTF_FONT_FAMILY.Name}");
                    updateOptFontStyle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), Global.MESSAGEBOX_TITLE);
                }
            }
        }

        private void updateOptFontStyle()
        {
            Task.Run(() =>
            {
                try
                {
                    comboBoxOptFontStyle.BeginInvoke((MethodInvoker)delegate
                    {
                        comboBoxOptFontStyle.Items.Clear();
                        foreach (FontStyle style in Enum.GetValues(typeof(FontStyle)))
                        {
                            if (Global.TTF_FONT_FAMILY.IsStyleAvailable(style))
                            {
                                comboBoxOptFontStyle.Items.Add(Enum.GetName(typeof(FontStyle), style));
                            }
                        }
                        if (comboBoxOptFontStyle.Items.Count > 0)
                        {
                            comboBoxOptFontStyle.SelectedIndex = 0;
                        }
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                }
            });
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string filePath = Utils.SaveFile("", Global.G1N_FILE_FILTER);
            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    File.WriteAllBytes(filePath, Global.G1N_FILE.RawData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), Global.MESSAGEBOX_TITLE);
                }
            }
        }
    }
}
