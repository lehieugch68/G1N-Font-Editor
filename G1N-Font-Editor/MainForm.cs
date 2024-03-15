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
using System.Drawing.Imaging;
using G1N_Font_Editor.Helpers;
using G1N_Font_Editor.Components;

namespace G1N_Font_Editor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            contextMenuGlyph.Items.Insert(0, new ToolStripLabel(Global.LABEL_NOT_AVAILABLE));
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                numericOptFontSize.Value = Global.DEFAULT_TTF_FONT_SIZE;
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
                comboBoxOptFontStyle.Items.Clear();
                comboBoxOptFontStyle.Items.AddRange(FontHelper.GetFontStyles(Global.TTF_FONT_FAMILY));
                comboBoxOptFontStyle.SelectedIndex = 0;
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
            else if (Global.G1N_FILE == null || Global.TTF_FONT_FAMILY == null || comboBoxOptFontStyle.SelectedIndex < 0)
            {

            }
            else
            {
                Global.IS_BUSY = true;
                var fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), comboBoxOptFontStyle.SelectedItem.ToString());
                var fontSize = (float)numericOptFontSize.Value;
                var chars = textBoxCharsOpt.Text.ToCharArray();
                Task.Run(() =>
                {
                    try
                    {
                        var glyphTypeface = FontHelper.GetGlyphTypeface(Global.TTF_FONT_FAMILY_NAME, fontStyle);
                        var font = new Font(Global.TTF_FONT_FAMILY, fontSize, fontStyle);
                        var glyphTable = Global.G1N_FILE.GlyphTables.Find(table => table.Index == Global.SELECTED_G1N_FONT_ID);
                        glyphTable.Build(glyphTypeface, font, chars);
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
                    comboBoxOptFontStyle.Items.Clear();
                    comboBoxOptFontStyle.Items.AddRange(FontHelper.GetFontStyles(Global.TTF_FONT_FAMILY));
                    comboBoxOptFontStyle.SelectedIndex = 0;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), Global.MESSAGEBOX_TITLE);
                }
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Global.G1N_FILE == null || pictureBox.Image == null) return;
            try
            {
                var table = Global.G1N_FILE.GlyphTables.Find(t => t.Index == Global.SELECTED_G1N_FONT_ID);
                var scaleX = (float)pictureBox.Width / (float)table.TablePreview.Width;
                var scaleY = (float)pictureBox.Height / (float)table.TablePreview.Height;
                var point = new Point((int)(e.X / scaleX), (int)(e.Y / scaleY));
                var glyph = table.Glyphs.Find(g => g.Rect.Contains(point));
                if (glyph == null) return;
                Global.CONTEXT_MENU_SELECTED_GLYPH = glyph;
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        handleGlyphMetricDialog();
                        break;
                    case MouseButtons.Right:
                        var pos = (sender as Control).PointToScreen(e.Location);
                        contextMenuGlyph.Items[0].Text = $"{glyph.Character} ({string.Format(@"0x{0:X2}", (ushort)glyph.Character)})";
                        contextMenuGlyph.Show(pos.X, pos.Y);
                        break;
                    default: break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Global.MESSAGEBOX_TITLE);
            }
        }

        private void toolStripMenuGlyphImport_Click(object sender, EventArgs e)
        {
            if (Global.CONTEXT_MENU_SELECTED_GLYPH == null) return;
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                string filePath = Utils.FileBrowser("", Global.IMAGE_FILE_FILTER);
                if (!string.IsNullOrEmpty(filePath))
                {
                    Global.IS_BUSY = true;
                    Task.Run(() =>
                    {
                        try
                        {
                            var bmp = new Bitmap(filePath);
                            var currBmp = Global.CONTEXT_MENU_SELECTED_GLYPH.GetBitmap();
                            int currX = currBmp.Width, 
                                currY = currBmp.Height;
                            Global.CONTEXT_MENU_SELECTED_GLYPH.SetBimap(bmp);
                            var table = Global.G1N_FILE.GlyphTables.Find(t => t.Index == Global.SELECTED_G1N_FONT_ID);
                            Bitmap texPic = table.ReloadTablePreview(bmp.Width != currX || bmp.Height != currY);
                            pictureBox.BeginInvoke((MethodInvoker)delegate
                            {
                                pictureBox.BackColor = Color.Black;
                                pictureBox.Image = texPic;
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
        }

        private void toolStripMenuGlyphExport_Click(object sender, EventArgs e)
        {
            if (Global.CONTEXT_MENU_SELECTED_GLYPH == null) return;
            string fileName = string.Format(@"0x{0:X2}", (ushort)Global.CONTEXT_MENU_SELECTED_GLYPH.Character);
            string filePath = Utils.SaveFile(fileName, Global.PNG_FILE_FILTER);
            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    var bmp = Global.CONTEXT_MENU_SELECTED_GLYPH.GetBitmap();
                    bmp.Save(filePath, ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), Global.MESSAGEBOX_TITLE);
                }
            }
        }
        private void handleGlyphMetricDialog()
        {
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                try
                {
                    var glyphForm = new GlyphMetricForm(Global.CONTEXT_MENU_SELECTED_GLYPH);
                    var result = glyphForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Global.CONTEXT_MENU_SELECTED_GLYPH.Baseline = Convert.ToSByte(glyphForm.Baseline);
                        Global.CONTEXT_MENU_SELECTED_GLYPH.LeftSide = Convert.ToSByte(glyphForm.LeftSide);
                        Global.CONTEXT_MENU_SELECTED_GLYPH.XAdv = Convert.ToByte(glyphForm.AdvanceWidth);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), Global.MESSAGEBOX_TITLE);
                }
                Global.IS_BUSY = false;
            }
        }
        private void toolStripMenuGlyphMetrics_Click(object sender, EventArgs e)
        {
            handleGlyphMetricDialog();
        }

        private void toolStripMenuOpenG1N_Click(object sender, EventArgs e)
        {
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                string filePath = Utils.FileBrowser("", Global.G1N_FILE_FILTER);
                if (!string.IsNullOrEmpty(filePath))
                {
                    Global.IS_BUSY = true;
                    comboBoxPage.Items.Clear();
                    comboBoxPage.SelectedIndex = -1;
                    Global.SELECTED_G1N_FONT_ID = comboBoxPage.SelectedIndex;
                    Global.G1N_FILE = null;
                    Task.Run(() =>
                    {
                        try
                        {
                            Global.G1N_FILE = new G1N(filePath);
                            comboBoxPage.BeginInvoke((MethodInvoker)delegate
                            {
                                foreach (var fontId in Global.G1N_FILE.GlyphTables)
                                {
                                    ComboboxItem item = new ComboboxItem();
                                    item.Text = $"{Global.LABEL_PAGE} {fontId.Index}";
                                    item.Value = fontId.Index;
                                    comboBoxPage.Items.Add(item);
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
                        if (comboBoxPage.Items.Count > 0) comboBoxPage.SelectedIndex = 0;
                    });
                }
            }
        }

        private void toolStripMenuSaveAs_Click(object sender, EventArgs e)
        {
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                if (Global.G1N_FILE == null) return;
                string filePath = Utils.SaveFile("", Global.G1N_FILE_FILTER);
                if (!string.IsNullOrEmpty(filePath))
                {
                    Global.IS_BUSY = true;
                    Task.Run(() =>
                    {
                        try
                        {
                            var glyphCustomValue = new GlyphCustomValue(
                                Convert.ToInt32(numericOptCustomBaseline.Value),
                                Convert.ToInt32(numericOptCustomLeftSide.Value),
                                Convert.ToInt32(numericOptCustomXAdv.Value)
                            );
                            var result = Global.G1N_FILE.Build(glyphCustomValue);
                            File.WriteAllBytes(filePath, Global.G1N_FILE.RawData);
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
        }

        private void toolStripMenuSaveG1N_Click(object sender, EventArgs e)
        {
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                if (Global.G1N_FILE == null) return;
                if (Global.G1N_FILE.RootFile == null || Global.G1N_FILE.RootFile == string.Empty)
                {
                    toolStripMenuSaveAs_Click(new object(), new EventArgs());
                    return;
                }
                Global.IS_BUSY = true;
                Task.Run(() =>
                {
                    try
                    {
                        var glyphCustomValue = new GlyphCustomValue(
                            Convert.ToInt32(numericOptCustomBaseline.Value),
                            Convert.ToInt32(numericOptCustomLeftSide.Value),
                            Convert.ToInt32(numericOptCustomXAdv.Value)
                        );
                        var result = Global.G1N_FILE.Build(glyphCustomValue);
                        File.WriteAllBytes(Global.G1N_FILE.RootFile, Global.G1N_FILE.RawData);
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

        private void toolStripMenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int fontId = (int)((ComboboxItem)comboBoxPage.Items[comboBoxPage.SelectedIndex]).Value;
            if (Global.SELECTED_G1N_FONT_ID != -1 && fontId == Global.SELECTED_G1N_FONT_ID) return;
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                Global.IS_BUSY = true;
                comboBoxPage.Enabled = false;
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
                        Global.SELECTED_G1N_FONT_ID = fontId;
                    }
                    catch (Exception ex)
                    {
                        Global.IS_BUSY = false;
                        comboBoxPage.BeginInvoke((MethodInvoker)delegate
                        {
                            comboBoxPage.Enabled = true;
                        });
                        comboBoxPage.SelectedIndex = Global.SELECTED_G1N_FONT_ID;
                        MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                    }
                }).GetAwaiter().OnCompleted(() =>
                {
                    Global.IS_BUSY = false;
                    comboBoxPage.Enabled = true;
                });
            }
        }

        private void toolStripMenuNewG1N_Click(object sender, EventArgs e)
        {
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                var newForm = new NewG1NForm();
                var result = newForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Global.IS_BUSY = true;
                    comboBoxPage.Enabled = false;
                    Task.Run(() =>
                    {
                        try
                        {
                            var totalPage = newForm.TotalPage;
                            Global.G1N_FILE = new G1N(totalPage);
                            Global.SELECTED_G1N_FONT_ID = -1;
                            comboBoxPage.BeginInvoke((MethodInvoker)delegate
                            {
                                comboBoxPage.Items.Clear();
                                foreach (var fontId in Global.G1N_FILE.GlyphTables)
                                {
                                    ComboboxItem item = new ComboboxItem();
                                    item.Text = $"{Global.LABEL_PAGE} {fontId.Index}";
                                    item.Value = fontId.Index;
                                    comboBoxPage.Items.Add(item);
                                }
                            });
                        }
                        catch (Exception ex)
                        {
                            Global.IS_BUSY = false;
                            comboBoxPage.BeginInvoke((MethodInvoker)delegate
                            {
                                comboBoxPage.Enabled = true;
                            });
                            MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                        }
                    }).GetAwaiter().OnCompleted(() =>
                    {
                        Global.IS_BUSY = false;
                        comboBoxPage.Enabled = true;
                        comboBoxPage.SelectedIndex = 0;
                    });
                }
            }
        }
    }
}
