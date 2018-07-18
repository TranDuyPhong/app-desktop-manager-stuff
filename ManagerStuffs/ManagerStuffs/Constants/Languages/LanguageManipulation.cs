using DevExpress.XtraEditors;
using MetroFramework.Controls;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerStuffs.Constants.Languages
{
    public static class LanguageManipulation
    {
        private static List<StranlateLanguage> Stranlates = new List<StranlateLanguage>();

        private static string PathFolderLanguage;

        // Method GetLanguages
        private static List<LanguageModel> GetLanguages()
        {
            string originalPath = Application.StartupPath;

            PathFolderLanguage = originalPath.Substring(0, originalPath.LastIndexOf("bin")) + @"Languages\";

            string fileLanguage = PathFolderLanguage + "Languages.json";

            if (!File.Exists(fileLanguage))
            {
                XtraMessageBox.Show("Bạn thiếu file Languages.json !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            List<LanguageModel> languages = null;

            using (StreamReader reader = new StreamReader(fileLanguage))
            {
                string json = reader.ReadToEnd();

                try
                {
                    languages = new List<LanguageModel>();

                    languages = JsonConvert.DeserializeObject<List<LanguageModel>>(json);
                }
                catch
                {
                    XtraMessageBox.Show("File Languages.json không đúng định dạng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    reader.Close();
                }
            };

            return languages;
        }

        // Method ListLanguages
        public static void ListLanguages(MetroComboBox cbb)
        {
            cbb.DataSource = null;

            List<LanguageModel> languages = GetLanguages();

            string standFor = languages.Where(p => p.Chosen == true).Select(p => p.StandFor).FirstOrDefault();

            cbb.DataSource = languages;

            cbb.DisplayMember = "Name";
            cbb.ValueMember = "StandFor";

            for(int i = 0; i < cbb.Items.Count; i++)
            {
                if((cbb.Items[i] as LanguageModel).StandFor == standFor)
                {
                    cbb.SelectedIndex = i;

                    break;
                }
            }
        }

        // Method GetListStranlatesByStandFor
        public static void GetStranlatesByStandFor(string standFor)
        {
            Stranlates.Clear();

            try
            {
                string fileStranlate = PathFolderLanguage + "Stranlates.xlsx";

                if(!File.Exists(fileStranlate) || string.IsNullOrEmpty(standFor))
                {
                    XtraMessageBox.Show("Bạn thiếu file Stranlates.xls !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                var package = new ExcelPackage(new FileInfo(fileStranlate));

                ExcelWorksheet workSheet = package.Workbook.Worksheets.Where(p => p.Name == standFor).FirstOrDefault();

                if(workSheet == null)
                {
                    return;
                }

                try
                {
                    for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                    {
                        if (workSheet.Cells[i, 1].Value != null && workSheet.Cells[i, 2].Value != null)
                        {
                            Stranlates.Add(new StranlateLanguage
                            {
                                ControlName = workSheet.Cells[i, 1].Value.ToString().Trim(),
                                Stranlate = workSheet.Cells[i, 2].Value.ToString().Trim()
                            });
                        } 
                    }
                }
                catch
                {
                    XtraMessageBox.Show("File Stranlate.xls không đúng định dạng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            { }
        }

        // Method SetStranlateForControlSingle
        public static void SetStranlateForControlSingle(this Control c)
        {
            StranlateLanguage getStranlate = Stranlates.Where(p => p.ControlName == c.Name.Trim()).FirstOrDefault();

            if (getStranlate != null)
            {
                c.Text = getStranlate.Stranlate;
            }
        }

        // Method SetStranlateForControlSingle
        public static void SetStranlateForItem(this ToolStripItem item)
        {
            StranlateLanguage getStranlate = Stranlates.Where(p => p.ControlName == item.Name.Trim()).FirstOrDefault();

            if (getStranlate != null)
            {
                item.Text = getStranlate.Stranlate;
            }
        }

        // Method SetStranlatesForTableLayout
        public static void SetStranlatesForTableLayout(this TableLayoutPanel table)
        {
            foreach(Control c in table.Controls)
            {
                SetStranlateForControlSingle(c);
            }
        }

        // Method SetStranlatesForTableLayout
        public static void SetStranlatesTitleForm(this Form form)
        {
            StranlateLanguage getStranlate = Stranlates.Where(p => p.ControlName == form.Name.Trim()).FirstOrDefault();

            if (getStranlate != null)
            {
                form.Text = getStranlate.Stranlate;
            }
        }

        // Method SetStranlatesForMenuStrip
        public static void SetStranlatesForMenuStrip(this MenuStrip menu)
        {
            foreach (ToolStripMenuItem item in menu.Items)
            {
                SetStranlateForItem(item);
            }
        }

        // Method SetStranlatesForToolStrip
        public static void SetStranlatesForToolStrip(this ToolStrip menu)
        {
            foreach (ToolStripItem item in menu.Items)
            {
                SetStranlateForItem(item);
            }
        }
    }
}
