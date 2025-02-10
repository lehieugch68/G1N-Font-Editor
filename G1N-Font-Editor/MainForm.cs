using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Net.Http;
using System.Web.Script.Serialization;
using G1N_Font_Editor.Helpers;
using G1N_Font_Editor.Components;
using G1N_Font_Editor.Components.Singleton;
using System.Text.RegularExpressions;

namespace G1N_Font_Editor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.AppIcon;
            contextMenuSelectedGlyph.Items.Insert(0, new ToolStripLabel(Global.LABEL_NOT_AVAILABLE));
        }

        private void SetControlsEnabled(bool enabled)
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = enabled;
            }
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
                MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
            }
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            if (Global.G1N_FILE == null) return;
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else if (Global.TTF_FONT_FAMILY == null || comboBoxOptFontStyle.SelectedIndex < 0)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["NoFontChosen"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                Global.IS_BUSY = true;
                SetControlsEnabled(false);
                labelStatusText.Text = Global.PROGRESS_MESSAGES["Building"];
                var fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), comboBoxOptFontStyle.SelectedItem.ToString());
                var fontSize = (float)numericOptFontSize.Value;
                var chars = checkBoxASCII.Checked ? 
                    textBoxCharsOpt.Text.ToCharArray().Concat(Utils.GetNonControlASCIICharacters()).ToArray() : 
                    textBoxCharsOpt.Text.ToCharArray();
                Task.Run(() =>
                {
                    try
                    {
                        var glyphTypeface = FontHelper.GetGlyphTypeface(Global.TTF_FONT_FAMILY_NAME, fontStyle);
                        var font = new Font(Global.TTF_FONT_FAMILY, fontSize, fontStyle);
                        var glyphTable = Global.G1N_FILE.GlyphTables.Find(table => table.Index == Global.SELECTED_G1N_FONT_ID);
                        glyphTable.Build(glyphTypeface, font, chars);
                        handleUpdateProgressFromTask(Global.PROGRESS_MESSAGES["PreparingBMP"]);
                        var totalPage = glyphTable.CalculatePageCount();
                        handleReloadTablePage(glyphTable, null, totalPage);
                        Bitmap palettePic = glyphTable.GetPaletteImage();
                        pictureBoxOptPalette.BeginInvoke((MethodInvoker)delegate
                        {
                            pictureBoxOptPalette.BackColor = Color.Transparent;
                            pictureBoxOptPalette.Image = palettePic;
                        });

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                    }
                }).GetAwaiter().OnCompleted(() =>
                {
                    Global.IS_BUSY = false;
                    SetControlsEnabled(true);
                    labelStatusText.Text = Global.PROGRESS_MESSAGES["Done"];
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
                        string chars = Utils.RemoveDuplicates(File.ReadAllText(filePath));
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
                    MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                }
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Global.G1N_FILE == null || pictureBox.Image == null) return;
            try
            {
                var table = Global.G1N_FILE.GlyphTables.Find(t => t.Index == Global.SELECTED_G1N_FONT_ID);
                var tablePage = table.TablePages[Global.CURRENT_TEX_PAGE - 1];
                var picture = tablePage.GetTextureImage();
                var scaleX = (float)pictureBox.Width / picture.Width;
                var scaleY = (float)pictureBox.Height / picture.Height;
                var point = new Point((int)(e.X / scaleX), (int)(e.Y / scaleY));
                var glyph = tablePage.Glyphs.Find(g => g.Rect.Contains(point));
                var pos = (sender as Control).PointToScreen(e.Location);
                if (glyph != null)
                {
                    Global.CONTEXT_MENU_SELECTED_GLYPH = glyph;
                    switch (e.Button)
                    {
                        case MouseButtons.Left:
                            handleGlyphMetricDialog();
                            break;
                        case MouseButtons.Right:
                            contextMenuSelectedGlyph.Items[0].Text = $"{glyph.Character} ({string.Format(@"0x{0:X2}", (ushort)glyph.Character)})";
                            contextMenuSelectedGlyph.Show(pos.X, pos.Y);
                            break;
                        default: break;
                    }
                }
                else
                {
                    Global.CONTEXT_MENU_SELECTED_GLYPH = null;
                    if (e.Button == MouseButtons.Right)
                    {
                        contextMenuGlyph.Show(pos.X, pos.Y);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
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
                string filePath = Utils.FileBrowser("", Global.PNG_FILE_FILTER);
                if (!string.IsNullOrEmpty(filePath))
                {
                    Global.IS_BUSY = true;
                    SetControlsEnabled(false);
                    labelStatusText.Text = Global.PROGRESS_MESSAGES["Importing"];
                    Task.Run(() =>
                    {
                        try
                        {
                            var currBmp = Global.CONTEXT_MENU_SELECTED_GLYPH.GetBitmap();
                            int currX = currBmp.Width, 
                                currY = currBmp.Height;
                            var bmp = Global.CONTEXT_MENU_SELECTED_GLYPH.SetBimap(filePath);
                            var table = Global.G1N_FILE.GlyphTables.Find(t => t.Index == Global.SELECTED_G1N_FONT_ID);
                            handleUpdateProgressFromTask(Global.PROGRESS_MESSAGES["PreparingBMP"]);
                            var isReloadNeeded = bmp.Width != currX || bmp.Height != currY;
                            if (isReloadNeeded)
                            {
                                var totalPage = table.CalculatePageCount();
                                handleReloadTablePage(table, null, totalPage);
                            } 
                            else
                            {
                                handleReloadTablePage(table, null, null);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                        }
                    }).GetAwaiter().OnCompleted(() =>
                    {
                        Global.IS_BUSY = false;
                        SetControlsEnabled(true);
                        labelStatusText.Text = Global.PROGRESS_MESSAGES["Done"];
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
                    labelStatusText.Text = Global.PROGRESS_MESSAGES["Exporting"];
                    var bmp = Global.CONTEXT_MENU_SELECTED_GLYPH.GetBitmap();
                    bmp.Save(filePath, ImageFormat.Png);
                    labelStatusText.Text = Global.PROGRESS_MESSAGES["Done"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
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
                        Global.CONTEXT_MENU_SELECTED_GLYPH.XOffset  = Convert.ToSByte(glyphForm.XOffset);
                        Global.CONTEXT_MENU_SELECTED_GLYPH.XAdvance = Convert.ToByte(glyphForm.XAdvance);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
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
                    var isError = false;
                    Global.IS_BUSY = true;
                    SetControlsEnabled(false);
                    comboBoxPage.Items.Clear();
                    comboBoxPage.SelectedIndex = -1;
                    Global.SELECTED_G1N_FONT_ID = comboBoxPage.SelectedIndex;
                    Global.G1N_FILE = null;
                    labelStatusText.Text = Global.PROGRESS_MESSAGES["Reading"];
                    Task.Run(() =>
                    {
                        try
                        {
                            Global.G1N_FILE = new G1N(filePath);
                            comboBoxPage.BeginInvoke((MethodInvoker)delegate
                            {
                                foreach (var fontId in Global.G1N_FILE.GlyphTables)
                                {
                                    var item = $"{Global.LABEL_PAGE} {fontId.Index}";
                                    comboBoxPage.Items.Add(item);
                                }
                            });
                        }
                        catch (Exception ex)
                        {
                            isError = true;
                            MessageBox.Show(ex.ToString(), Global.MESSAGEBOX_TITLE);
                        }
                    }).GetAwaiter().OnCompleted(() =>
                    {
                        Global.IS_BUSY = false;
                        SetControlsEnabled(true);
                        labelStatusText.Text = Global.PROGRESS_MESSAGES["Done"];
                        if (isError) return;
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
                if (Global.G1N_FILE.GlyphTables.Any(table => table.Glyphs.Count <= 0))
                {
                    MessageBox.Show(Global.MESSAGEBOX_MESSAGES["EmptyPage"], Global.MESSAGEBOX_TITLE);
                    return;
                }
                string filePath = Utils.SaveFile("", Global.G1N_FILE_FILTER);
                if (!string.IsNullOrEmpty(filePath))
                {
                    Global.IS_BUSY = true;
                    var isError = false;
                    SetControlsEnabled(false);
                    labelStatusText.Text = Global.PROGRESS_MESSAGES["Saving"];
                    Task.Run(() =>
                    {
                        try
                        {
                            var glyphCustomValue = new GlyphCustomValue(
                                Convert.ToInt32(numericOptCustomBaseline.Value),
                                Convert.ToInt32(numericOptCustomXOffset.Value),
                                Convert.ToInt32(numericOptCustomXAdv.Value)
                            );
                            var result = Global.G1N_FILE.Build(glyphCustomValue);
                            File.WriteAllBytes(filePath, Global.G1N_FILE.RawData);
                        }
                        catch (Exception ex)
                        {
                            isError = true;
                            MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                        }
                    }).GetAwaiter().OnCompleted(() =>
                    {
                        Global.IS_BUSY = false;
                        SetControlsEnabled(true);
                        labelStatusText.Text = Global.PROGRESS_MESSAGES["Saved"];
                        if (isError) return;
                        Global.G1N_FILE.RootFile = filePath;
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
                if (Global.G1N_FILE.GlyphTables.Any(table => table.Glyphs.Count <= 0))
                {
                    MessageBox.Show(Global.MESSAGEBOX_MESSAGES["EmptyPage"], Global.MESSAGEBOX_TITLE);
                    return;
                }
                if (Global.G1N_FILE.RootFile == null || Global.G1N_FILE.RootFile == string.Empty)
                {
                    toolStripMenuSaveAs_Click(new object(), new EventArgs());
                    return;
                }
                Global.IS_BUSY = true;
                SetControlsEnabled(false);
                labelStatusText.Text = Global.PROGRESS_MESSAGES["Saving"];
                Task.Run(() =>
                {
                    try
                    {
                        var glyphCustomValue = new GlyphCustomValue(
                            Convert.ToInt32(numericOptCustomBaseline.Value),
                            Convert.ToInt32(numericOptCustomXOffset.Value),
                            Convert.ToInt32(numericOptCustomXAdv.Value)
                        );
                        var result = Global.G1N_FILE.Build(glyphCustomValue);
                        File.WriteAllBytes(Global.G1N_FILE.RootFile, Global.G1N_FILE.RawData);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                    }
                }).GetAwaiter().OnCompleted(() =>
                {
                    Global.IS_BUSY = false;
                    SetControlsEnabled(true);
                    labelStatusText.Text = Global.PROGRESS_MESSAGES["Saved"];
                });
            }
        }

        private void toolStripMenuExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void comboBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pageIndex = comboBoxPage.SelectedIndex;
            if (Global.SELECTED_G1N_FONT_ID != -1 && pageIndex == Global.SELECTED_G1N_FONT_ID) return;
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                Global.IS_BUSY = true;
                SetControlsEnabled(false);
                labelStatusText.Text = Global.PROGRESS_MESSAGES["PreparingBMP"];
                Task.Run(() =>
                {
                    try
                    {
                        var glyphTable = Global.G1N_FILE.GlyphTables.Find(g => g.Index == pageIndex);
                        Global.CURRENT_TEX_PAGE = 1;
                        Global.TOTAL_TEX_PAGE = glyphTable.CalculatePageCount();
                        labelPage.BeginInvoke((MethodInvoker)delegate
                        {
                            labelPage.Text = $"{Global.CURRENT_TEX_PAGE} / {Global.TOTAL_TEX_PAGE}";
                        });
                        Bitmap texPic = glyphTable.TablePages[Global.CURRENT_TEX_PAGE - 1].GetTextureImage();
                        pictureBox.BeginInvoke((MethodInvoker)delegate
                        {
                            pictureBox.BackColor = Color.Black;
                            pictureBox.Image = texPic;
                        });
                        Bitmap palettePic = glyphTable.GetPaletteImage();
                        pictureBoxOptPalette.BeginInvoke((MethodInvoker)delegate
                        {
                            pictureBoxOptPalette.BackColor = Color.Transparent;
                            pictureBoxOptPalette.Image = palettePic;
                        });
                        Global.SELECTED_G1N_FONT_ID = pageIndex;
                    }
                    catch (Exception ex)
                    {
                        comboBoxPage.BeginInvoke((MethodInvoker)delegate
                        {
                            comboBoxPage.SelectedIndex = Global.SELECTED_G1N_FONT_ID;
                        });
                        MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                    }
                }).GetAwaiter().OnCompleted(() =>
                {
                    Global.IS_BUSY = false;
                    SetControlsEnabled(true);
                    labelStatusText.Text = Global.PROGRESS_MESSAGES["Done"];
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
                    SetControlsEnabled(false);
                    var isError = false;
                    labelStatusText.Text = Global.PROGRESS_MESSAGES["Initializing"];
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
                                    var item = $"{Global.LABEL_PAGE} {fontId.Index}";
                                    comboBoxPage.Items.Add(item);
                                }
                            });
                        }
                        catch (Exception ex)
                        {
                            isError = true;
                            MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                        }
                    }).GetAwaiter().OnCompleted(() =>
                    {
                        Global.IS_BUSY = false;
                        SetControlsEnabled(true);
                        labelStatusText.Text = Global.PROGRESS_MESSAGES["Done"];
                        if (isError) return;
                        comboBoxPage.SelectedIndex = 0;
                    });
                }
            }
        }

        private void toolStripMenuEditAddPage_Click(object sender, EventArgs e)
        {
            if (Global.G1N_FILE == null) return;
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                var isError = false;
                Global.IS_BUSY = true;
                SetControlsEnabled(false);
                labelStatusText.Text = Global.PROGRESS_MESSAGES["Adding"];
                Task.Run(() =>
                {
                    try
                    {
                        Global.G1N_FILE.AddGlyphTables();
                        var table = Global.G1N_FILE.GlyphTables.Last();
                        comboBoxPage.BeginInvoke((MethodInvoker)delegate
                        {
                            var item = $"{Global.LABEL_PAGE} {table.Index}";
                            comboBoxPage.Items.Add(item);
                        });
                    }
                    catch (Exception ex)
                    {
                        isError = true;
                        MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                    }
                }).GetAwaiter().OnCompleted(() =>
                {
                    Global.IS_BUSY = false;
                    SetControlsEnabled(true);
                    labelStatusText.Text = Global.PROGRESS_MESSAGES["Done"];
                    if (isError) return;
                    for (int i = 0; i < comboBoxPage.Items.Count; i++)
                    {
                        comboBoxPage.Items[i] = $"{Global.LABEL_PAGE} {i}";
                    }
                    comboBoxPage.SelectedIndex = comboBoxPage.Items.Count - 1;
                });
            }
        }

        private void toolStripMenuEditRemovePage_Click(object sender, EventArgs e)
        {
            if (Global.G1N_FILE == null || Global.SELECTED_G1N_FONT_ID == -1) return;
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                var isError = false;
                Global.IS_BUSY = true;
                SetControlsEnabled(false);
                labelStatusText.Text = Global.PROGRESS_MESSAGES["Removing"];
                Task.Run(() =>
                {
                    try
                    {
                        Global.G1N_FILE.RemoveGlyphTable(Global.SELECTED_G1N_FONT_ID);
                    }
                    catch (Exception ex)
                    {
                        isError = true;
                        MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                    }
                }).GetAwaiter().OnCompleted(() =>
                {
                    Global.IS_BUSY = false;
                    SetControlsEnabled(true);
                    labelStatusText.Text = Global.PROGRESS_MESSAGES["Done"];
                    if (isError) return;
                    var currIndex = Global.SELECTED_G1N_FONT_ID;
                    Global.SELECTED_G1N_FONT_ID = -1;
                    comboBoxPage.Items.RemoveAt(currIndex);
                    for (int i = 0; i < comboBoxPage.Items.Count; i++)
                    {
                        comboBoxPage.Items[i] = $"{Global.LABEL_PAGE} {i}";
                    }
                    comboBoxPage.SelectedIndex = comboBoxPage.Items.Count > 1 ? currIndex : 0;
                    
                });
            }
        }

        private void handleAddGlyph()
        {
            if (Global.G1N_FILE == null || Global.SELECTED_G1N_FONT_ID == -1) return;
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                var newGlyphForm = new NewGlyphForm();
                var result = newGlyphForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Global.IS_BUSY = true;
                    SetControlsEnabled(false);
                    labelStatusText.Text = Global.PROGRESS_MESSAGES["Adding"];
                    Task.Run(() =>
                    {
                        try
                        {
                            var table = Global.G1N_FILE.GlyphTables.Find(t => t.Index == Global.SELECTED_G1N_FONT_ID);
                            var baseline = Convert.ToSByte(newGlyphForm.Baseline);
                            var xAdv = Convert.ToByte(newGlyphForm.XAdvance);
                            var xOff = Convert.ToSByte(newGlyphForm.XOffset);
                            var glyph = new Glyph(newGlyphForm.Character, newGlyphForm.GlyphBitmap, baseline, xAdv, xOff);
                            table.AddGlyph(glyph);
                            handleUpdateProgressFromTask(Global.PROGRESS_MESSAGES["PreparingBMP"]);
                            table.CalculatePageCount();
                            var tablePage = table.TablePages[Global.CURRENT_TEX_PAGE - 1];
                            Bitmap texPic = tablePage.GetTextureImage();
                            pictureBox.BeginInvoke((MethodInvoker)delegate
                            {
                                pictureBox.BackColor = Color.Black;
                                pictureBox.Image = texPic;
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                        }
                    }).GetAwaiter().OnCompleted(() =>
                    {
                        SetControlsEnabled(true);
                        Global.IS_BUSY = false;
                        labelStatusText.Text = Global.PROGRESS_MESSAGES["Done"];
                    });
                }
            }
        }

        private void toolStripMenuGlyphAdd_Click(object sender, EventArgs e)
        {
            handleAddGlyph();
        }

        private void toolStripMenuEditAddGlyph_Click(object sender, EventArgs e)
        {
            handleAddGlyph();
        }

        private void toolStripMenuGlyphRemove_Click(object sender, EventArgs e)
        {
            if (Global.G1N_FILE == null || Global.SELECTED_G1N_FONT_ID == -1 || Global.CONTEXT_MENU_SELECTED_GLYPH == null) return;
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                Global.IS_BUSY = true;
                SetControlsEnabled(false);
                labelStatusText.Text = Global.PROGRESS_MESSAGES["Removing"];
                Task.Run(() =>
                {
                    try
                    {
                        var table = Global.G1N_FILE.GlyphTables.Find(t => t.Index == Global.SELECTED_G1N_FONT_ID);
                        table.RemoveGlyph(Global.CONTEXT_MENU_SELECTED_GLYPH.CharCode);
                        handleUpdateProgressFromTask(Global.PROGRESS_MESSAGES["PreparingBMP"]);
                        var totalPage = table.CalculatePageCount();
                        var currentPage = Global.CURRENT_TEX_PAGE;
                        if (currentPage > totalPage) currentPage = totalPage;
                        handleReloadTablePage(table, currentPage, totalPage);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                    }
                }).GetAwaiter().OnCompleted(() =>
                {
                    SetControlsEnabled(true);
                    Global.IS_BUSY = false;
                    labelStatusText.Text = Global.PROGRESS_MESSAGES["Done"];
                });
            }
        }

        private void handleUpdateProgressFromTask(string text)
        {
            labelStatusText.BeginInvoke((MethodInvoker)delegate
            {
                labelStatusText.Text = text;
            });
        }

        private void toolStripMenuGuide_Click(object sender, EventArgs e)
        {
            Utils.OpenUrl(Global.APP_URLS["Guide"]);
        }

        private void toolStripMenuAbout_Click(object sender, EventArgs e)
        {
            var form = AboutFormInstance.GetForm;
            form.Show();
        }

        private void toolStripMenuCheckUpdate_Click(object sender, EventArgs e)
        {
            string body = string.Empty;
            Task.Run(async () =>
            {
                try
                {
                    HttpClient client = new HttpClient();
                    var response = await client.GetAsync(Global.APP_URLS["Info"]);
                    response.EnsureSuccessStatusCode();
                    body = await response.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                }
            }).GetAwaiter().OnCompleted(() =>
            {
                if (body == string.Empty) return;
                Dictionary<string, string> json = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(body);
                long currentVer = long.Parse(Application.ProductVersion.Replace(".", ""));
                long latestVer = long.Parse(json["AppVersion"].Replace(".", ""));
                if (currentVer < latestVer)
                {
                    DialogResult confirm = MessageBox.Show(Global.MESSAGEBOX_MESSAGES["NewVer"], Global.MESSAGEBOX_TITLE, MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        Utils.OpenUrl(json["AppUrl"]);
                    }
                }
                else
                {
                    MessageBox.Show(Global.MESSAGEBOX_MESSAGES["LatestVer"], Global.MESSAGEBOX_TITLE);
                }
            });
        }

        private void handleReloadTablePage(GlyphTable glyphTable, int? currentPage, int? totalPage)
        {
            if (currentPage.HasValue) Global.CURRENT_TEX_PAGE = currentPage.Value > 0 ? currentPage.Value : 1;
            if (totalPage.HasValue) Global.TOTAL_TEX_PAGE = totalPage.Value > 0 ? totalPage.Value : 1;
            if (Global.CURRENT_TEX_PAGE > Global.TOTAL_TEX_PAGE) Global.CURRENT_TEX_PAGE = Global.TOTAL_TEX_PAGE;
            labelPage.BeginInvoke((MethodInvoker)delegate
            {
                labelPage.Text = $"{Global.CURRENT_TEX_PAGE} / {Global.TOTAL_TEX_PAGE}";
            });
            Bitmap texPic = glyphTable.TablePages[Global.CURRENT_TEX_PAGE - 1].GetTextureImage();
            pictureBox.BeginInvoke((MethodInvoker)delegate
            {
                pictureBox.BackColor = Color.Black;
                pictureBox.Image = texPic;
            });
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (Global.G1N_FILE == null || Global.SELECTED_G1N_FONT_ID == -1 || Global.TOTAL_TEX_PAGE <= 1) return;
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            } 
            else
            {
                Global.IS_BUSY = true;
                SetControlsEnabled(false);
                labelStatusText.Text = Global.PROGRESS_MESSAGES["PreparingBMP"];
                Task.Run(() =>
                {
                    try
                    {
                        var glyphTable = Global.G1N_FILE.GlyphTables.Find(g => g.Index == Global.SELECTED_G1N_FONT_ID);
                        var currentPage = Global.CURRENT_TEX_PAGE == Global.TOTAL_TEX_PAGE ? 1 : Global.CURRENT_TEX_PAGE + 1;
                        handleReloadTablePage(glyphTable, currentPage, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                    }
                }).GetAwaiter().OnCompleted(() =>
                {
                    Global.IS_BUSY = false;
                    SetControlsEnabled(true);
                    labelStatusText.Text = Global.PROGRESS_MESSAGES["Done"];
                });
            }
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (Global.G1N_FILE == null || Global.SELECTED_G1N_FONT_ID == -1 || Global.TOTAL_TEX_PAGE <= 1) return;
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                Global.IS_BUSY = true;
                SetControlsEnabled(false);
                labelStatusText.Text = Global.PROGRESS_MESSAGES["PreparingBMP"];
                Task.Run(() =>
                {
                    try
                    {
                        var glyphTable = Global.G1N_FILE.GlyphTables.Find(g => g.Index == Global.SELECTED_G1N_FONT_ID);
                        var currentPage = Global.CURRENT_TEX_PAGE == 1 ? Global.TOTAL_TEX_PAGE : Global.CURRENT_TEX_PAGE - 1;
                        handleReloadTablePage(glyphTable, currentPage, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                    }
                }).GetAwaiter().OnCompleted(() =>
                {
                    Global.IS_BUSY = false;
                    SetControlsEnabled(true);
                    labelStatusText.Text = Global.PROGRESS_MESSAGES["Done"];
                });
            }
        }

        private void pictureBoxOptPalette_Click(object sender, EventArgs e)
        {
            if (Global.G1N_FILE == null || Global.SELECTED_G1N_FONT_ID == -1) return;
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                var result = colorDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Global.IS_BUSY = true;
                    SetControlsEnabled(false);
                    labelStatusText.Text = Global.PROGRESS_MESSAGES["GeneratingColor"];
                    Task.Run(() =>
                    {
                        try
                        {
                            var rgb = new byte[] { colorDialog.Color.B, colorDialog.Color.G, colorDialog.Color.R };
                            var glyphTable = Global.G1N_FILE.GlyphTables.Find(g => g.Index == Global.SELECTED_G1N_FONT_ID);
                            glyphTable.Palettes = Utils.GeneratePalettes(rgb);
                            Bitmap palettePic = glyphTable.ReloadPaletteImage();
                            pictureBoxOptPalette.BeginInvoke((MethodInvoker)delegate
                            {
                                pictureBoxOptPalette.BackColor = Color.Transparent;
                                pictureBoxOptPalette.Image = palettePic;
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                        }
                    }).GetAwaiter().OnCompleted(() =>
                    {
                        Global.IS_BUSY = false;
                        SetControlsEnabled(true);
                        labelStatusText.Text = Global.PROGRESS_MESSAGES["Done"];
                    });
                }
            }
        }

        private void previewSizeToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                ToolStripItem clickedItem = e.ClickedItem;
                Match match = Global.IMAGE_SIZE_REGEX.Match(clickedItem.Text);
                if (match.Success)
                {
                    int width = int.Parse(match.Groups[1].Value);
                    int height = int.Parse(match.Groups[2].Value);
                    var isReloadNeeded = Global.DEFAULT_TEX_WIDTH != width || Global.DEFAULT_TEX_HEIGHT != height;
                    Global.DEFAULT_TEX_WIDTH = width;
                    Global.DEFAULT_TEX_HEIGHT = height;

                    if (isReloadNeeded && Global.G1N_FILE != null && Global.SELECTED_G1N_FONT_ID != -1)
                    {
                        Global.IS_BUSY = true;
                        SetControlsEnabled(false);
                        Task.Run(() =>
                        {
                            try
                            {
                                var glyphTable = Global.G1N_FILE.GlyphTables.Find(g => g.Index == Global.SELECTED_G1N_FONT_ID);
                                handleUpdateProgressFromTask(Global.PROGRESS_MESSAGES["PreparingBMP"]);
                                var totalPage = glyphTable.CalculatePageCount();
                                handleReloadTablePage(glyphTable, null, totalPage);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                            }
                        }).GetAwaiter().OnCompleted(() =>
                        {
                            Global.IS_BUSY = false;
                            SetControlsEnabled(true);
                            labelStatusText.Text = Global.PROGRESS_MESSAGES["Done"];
                        });
                    }
                }
                else
                {
                    MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InvalidSizeFormat"], Global.MESSAGEBOX_TITLE);
                }
            }    
                
        }

        private void buttonGotoPage_Click(object sender, EventArgs e)
        {
            if (Global.G1N_FILE == null || Global.SELECTED_G1N_FONT_ID == -1) return;
            if (Global.IS_BUSY)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["InProgress"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                var pageNum = (int)numericGotoPage.Value;
                if (pageNum > 0 && pageNum != Global.CURRENT_TEX_PAGE)
                {
                    Global.IS_BUSY = true;
                    SetControlsEnabled(false);
                    Task.Run(() =>
                    {
                        try
                        {
                            var glyphTable = Global.G1N_FILE.GlyphTables.Find(g => g.Index == Global.SELECTED_G1N_FONT_ID);
                            handleUpdateProgressFromTask(Global.PROGRESS_MESSAGES["PreparingBMP"]);
                            handleReloadTablePage(glyphTable, pageNum, null);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, Global.MESSAGEBOX_TITLE);
                        }
                    }).GetAwaiter().OnCompleted(() =>
                    {
                        Global.IS_BUSY = false;
                        SetControlsEnabled(true);
                        labelStatusText.Text = Global.PROGRESS_MESSAGES["Done"];
                    });
                }
            }
        }
    }
}
