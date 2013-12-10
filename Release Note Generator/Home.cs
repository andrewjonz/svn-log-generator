using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Release_Note_Generator
{
    /// <summary>
    /// Class for Home
    /// </summary>
    public partial class Home : Form
    {
        #region Private Members

        /// <summary>
        /// 
        /// </summary>
        private const string REVISION = "Revision:";

        /// <summary>
        /// 
        /// </summary>
        private const string AUTHOR = "Author:";

        /// <summary>
        /// 
        /// </summary>
        private const string DATE = "Date:";

        /// <summary>
        /// 
        /// </summary>
        private const string MESSAGE = "Message:";

        /// <summary>
        /// 
        /// </summary>
        private const string MODIFIED = "Modified :";

        /// <summary>
        /// 
        /// </summary>
        private const string ADDED = "Added :";

        /// <summary>
        /// 
        /// </summary>
        private const string DELETED = "Deleted :";

        /// <summary>
        /// 
        /// </summary>
        private const string MESSAGE_END = "----";

        private const string EDIT = "edit";

        private const string DELETE = "delete";

        private const string ADD = "add";

        private const string BRANCH = "branch";

        /// <summary>
        /// 
        /// </summary>
        private string data = null;

        /// <summary>
        /// 
        /// </summary>
        private bool IsModifiedFirst = false;

        /// <summary>
        /// 
        /// </summary>
        private bool IsDeletedFirst = false;

        /// <summary>
        /// 
        /// </summary>
        private bool IsAddedFirst = false;

        /// <summary>
        /// 
        /// </summary>
        private long revision_id;

        /// <summary>
        /// 
        /// </summary>
        private int totalLines = 0;

        /// <summary>
        /// 
        /// </summary>
        private int lineStartIndex = 0;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Home"/> class.
        /// </summary>
        public Home()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the text file data.
        /// </summary>
        /// <value>The text file data.</value>
        public DataSet TextFileData
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the text file.
        /// </summary>
        /// <value>The name of the text file.</value>
        public string TextFileName
        {
            get;

            set;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Handles the Click event of the BrowseButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (this.richTextBox.Visible)
            {
                this.EnterFreeTextButton.PerformClick();
            }

            TextFileOpenFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (TextFileOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!TextFileOpenFileDialog.Multiselect)
                {
                    long fileSize = 0;
                    totalLines = 0;
                    this.TextFileName = TextFileOpenFileDialog.FileName;
                    fileSize = new FileInfo(this.TextFileName).Length;
                    totalLines = File.ReadAllLines(this.TextFileName).Length;
                    FileDetailsLabel.Text = "File Name : " + this.TextFileName;
                    FileDetailsLabel1.Text = "Size : " + GetSize(fileSize);
                    FileDetailsLabel2.Text = "Lines : " + totalLines.ToString();
                    this.GenerateButton.Visible = true;
                    this.Size = this.Size.Height == 100 ? new Size(480, 200) : new Size(480, 100);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the EnterFreeTextButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void EnterFreeTextButton_Click(object sender, EventArgs e)
        {
            if (this.Size.Height == 400)
            {
                this.Size = this.Size.Height == 400 ? new Size(480, 100) : new Size(480, 400);
                this.ClearLabel.Visible = false;
                this.GenerateButton.Location = new Point(170, 120);
                this.progressBar1.Location = new Point(58, 150);
            }

            else if (this.Size.Height == 100)
            {
                this.Size = this.Size.Height == 100 ? new Size(480, 400) : new Size(480, 100);
                this.GenerateButton.Location = new Point(165, 340);
                this.progressBar1.Location = new Point(58, 366);
            }

            else if (this.Size.Height == 200)
            {
                this.Size = this.Size.Height == 200 ? new Size(480, 400) : new Size(480, 100);
                this.GenerateButton.Location = new Point(165, 340);
                this.progressBar1.Location = new Point(58, 366);
            }

            this.richTextBox.Visible = this.richTextBox.Visible == false ? true : false;

            if (this.TextFileName != null && this.TextFileName.Length > 0)
            {
                this.TextFileName = string.Empty;
                FileDetailsLabel.Text = string.Empty;
                FileDetailsLabel1.Text = string.Empty;
                FileDetailsLabel2.Text = string.Empty;
                this.GenerateButton.Visible = false;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the richTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.richTextBox.Text.Trim().Length > 0)
            {
                this.GenerateButton.Visible = true;
                this.ClearLabel.Visible = true;
            }
            else
            {
                this.GenerateButton.Visible = false;
                this.ClearLabel.Visible = false;
            }
        }

        /// <summary>
        /// Handles the 1 event of the ClearLabel_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ClearLabel_Click_1(object sender, EventArgs e)
        {
            this.richTextBox.Text = string.Empty;
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>Size</returns>
        private string GetSize(long source)
        {
            const int byteConversion = 1024;
            double bytes = Convert.ToDouble(source);

            if (bytes >= Math.Pow(byteConversion, 3)) //GB Range
            {
                return string.Concat(Math.Round(bytes / Math.Pow(byteConversion, 3), 2), " GB");
            }
            else if (bytes >= Math.Pow(byteConversion, 2)) //MB Range
            {
                return string.Concat(Math.Round(bytes / Math.Pow(byteConversion, 2), 2), " MB");
            }
            else if (bytes >= byteConversion) //KB Range
            {
                return string.Concat(Math.Round(bytes / byteConversion, 2), " KB");
            }
            else //Bytes
            {
                return string.Concat(bytes, " Bytes");
            }
        }

        /// <summary>
        /// Handles the Load event of the Home control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Home_Load(object sender, EventArgs e)
        {
            this.GenerateButton.Visible = false;
            string path = Directory.GetCurrentDirectory();
            try
            {
                object obj = new Microsoft.Office.Interop.Excel.Application();
                // System.Diagnostics.Process.Start("..\\..\\office2007piaredist\\o2007pia.msi");
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Handles the Click event of the GenerateButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (this.SvnRadioButton.Checked)
            {
                if (this.richTextBox.Text.Trim().Length > 0 && (this.TextFileName != null && this.TextFileName.Length > 0))
                {
                    MessageBox.Show("You cannot have two of the options selected, Please ignore any one");
                    this.TextFileName = string.Empty;
                    FileDetailsLabel.Text = string.Empty;
                    FileDetailsLabel1.Text = string.Empty;
                    FileDetailsLabel2.Text = string.Empty;
                    this.GenerateButton.Visible = false;
                    this.richTextBox.Text = string.Empty;
                    this.ClearLabel.Visible = false;
                    this.Size = this.Size.Height == 200 ? new Size(480, 100) : new Size(480, 100);
                }
                else if (this.richTextBox.Text.Trim().Length > 0)
                {
                    this.GenerateFromTextbox();
                }
                else if (this.TextFileName != null && this.TextFileName.Length > 0)
                {
                    this.GenerateNoteFromFile();
                }
            }
            else if (this.TFSRadioButton.Checked)
            {
                if (this.richTextBox.Text.Trim().Length > 0)
                {
                    this.GenerateForTFS();
                }
            }
        }

        /// <summary>
        /// Generates the note from file.
        /// </summary>
        private void GenerateNoteFromFile()
        {
            try
            {
                string fileName = this.TextFileName;

                if (fileName != null && fileName.Length > 0)
                {
                    using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(fileStream))
                        {
                            Revisions revisionList = new Revisions();
                            revisionList.RevisionList = new List<Revision>();
                            List<string> lines = new List<string>();
                            Revision revision = new Revision();

                            String line = null;
                            while ((line = streamReader.ReadLine()) != null || streamReader.EndOfStream)
                            {
                                if (line != null && line != string.Empty)
                                {
                                    if (line.Contains(REVISION))
                                    {
                                        if (revision != null && revision.Revision_ID > 0)
                                        {
                                            revisionList.RevisionList.Add(revision);
                                        }

                                        revision = new Revision();
                                        data = line.Substring(REVISION.Length, (line.Length - REVISION.Length));

                                        long.TryParse(data, out revision_id);
                                        revision.Revision_ID = revision_id;

                                        IsAddedFirst = false;
                                        IsModifiedFirst = false;
                                        IsDeletedFirst = false;
                                    }
                                    else if (line.Contains(AUTHOR))
                                    {
                                        data = line.Substring(AUTHOR.Length, (line.Length - AUTHOR.Length));
                                        revision.Author = data;
                                    }
                                    else if (line.Contains(DATE))
                                    {
                                        data = line.Substring(DATE.Length, (line.Length - DATE.Length));
                                        revision.Date = data;
                                    }
                                    else if (line.Contains(MESSAGE))
                                    {
                                        while ((line = streamReader.ReadLine()) != null)
                                        {
                                            if (!line.Contains(MESSAGE_END))
                                            {
                                                lines.Add(line);
                                                foreach (string msg in lines)
                                                {
                                                    revision.Message = msg;
                                                }
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    else if (line.Contains(MODIFIED))
                                    {
                                        data = line.Substring(MODIFIED.Length, (line.Length - MODIFIED.Length));
                                        if (!IsModifiedFirst)
                                        {
                                            revision.Modified = new List<string>();
                                        }

                                        revision.Modified.Add(data);
                                        IsModifiedFirst = true;
                                    }
                                    else if (line.Contains(ADDED))
                                    {
                                        data = line.Substring(ADDED.Length, (line.Length - ADDED.Length));
                                        if (!IsAddedFirst)
                                        {
                                            revision.Added = new List<string>();
                                        }

                                        revision.Added.Add(data);
                                        IsAddedFirst = true;
                                    }
                                    else if (line.Contains(DELETED))
                                    {
                                        data = line.Substring(DELETED.Length, (line.Length - DELETED.Length));
                                        if (!IsDeletedFirst)
                                        {
                                            revision.Deleted = new List<string>();
                                        }

                                        revision.Deleted.Add(data);
                                        IsDeletedFirst = true;
                                    }
                                }
                                else if (streamReader.EndOfStream)
                                {
                                    revisionList.RevisionList.Add(revision);
                                    break;
                                }
                            }
                            this.CreateExcel(revisionList);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Exception has encountered, We are sorry for the inconvenience");
            }
            finally
            {

            }
        }

        /// <summary>
        /// Generates from textbox.
        /// </summary>
        private void GenerateFromTextbox()
        {
            try
            {
                Revisions revisionList = new Revisions();
                revisionList.RevisionList = new List<Revision>();
                List<string> lines = new List<string>();
                Revision revision = new Revision();

                String line = null;
                int textboxLength = 0;
                textboxLength = this.richTextBox.Lines.Length + 1;
                for (int i = 0; i < textboxLength; i++)
                {
                    if (i < textboxLength - 1)
                    {
                        line = richTextBox.Lines[i];
                    }
                    if (line != null && line != string.Empty)
                    {
                        if (line.Contains(REVISION) || i == textboxLength - 1)
                        {
                            if (revision != null && revision.Revision_ID > 0)
                            {
                                revisionList.RevisionList.Add(revision);
                            }

                            revision = new Revision();
                            data = line.Substring(REVISION.Length, (line.Length - REVISION.Length));

                            long.TryParse(data, out revision_id);
                            revision.Revision_ID = revision_id;

                            IsAddedFirst = false;
                            IsModifiedFirst = false;
                            IsDeletedFirst = false;
                        }
                        else if (line.Contains(AUTHOR))
                        {
                            data = line.Substring(AUTHOR.Length, (line.Length - AUTHOR.Length));
                            revision.Author = data;
                        }
                        else if (line.Contains(DATE))
                        {
                            data = line.Substring(DATE.Length, (line.Length - DATE.Length));
                            revision.Date = data;
                        }
                        else if (line.Contains(MESSAGE))
                        {
                            for (int j = i; ; j++, i++)
                            {
                                line = richTextBox.Lines[i];
                                if (!line.Contains(MESSAGE_END))
                                {
                                    lines.Add(line);
                                    foreach (string msg in lines)
                                    {
                                        revision.Message = msg;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else if (line.Contains(MODIFIED))
                        {
                            if (line.Length > 0 && line.Length > MODIFIED.Length)
                            {
                                data = line.Substring(MODIFIED.Length, (line.Length - MODIFIED.Length));
                                if (!IsModifiedFirst)
                                {
                                    revision.Modified = new List<string>();
                                }

                                revision.Modified.Add(data);
                                IsModifiedFirst = true;
                            }
                        }
                        else if (line.Contains(ADDED))
                        {
                            if (line.Length > 0 && line.Length > ADDED.Length)
                            {
                                data = line.Substring(ADDED.Length, (line.Length - ADDED.Length));
                                if (!IsAddedFirst)
                                {
                                    revision.Added = new List<string>();
                                }

                                revision.Added.Add(data);
                                IsAddedFirst = true;
                            }
                        }
                        else if (line.Contains(DELETED))
                        {
                            if (line.Length > 0 && line.Length > DELETED.Length)
                            {
                                data = line.Substring(DELETED.Length, (line.Length - DELETED.Length));
                                if (!IsDeletedFirst)
                                {
                                    revision.Deleted = new List<string>();
                                }

                                revision.Deleted.Add(data);
                                IsDeletedFirst = true;
                            }
                        }
                    }
                }

                this.CreateExcel(revisionList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Exception has encountered, We are sorry for the inconvenience");
            }
        }

        /// <summary>
        /// Generates for TFS.
        /// </summary>
        private void GenerateForTFS()
        {
            if (this.TFSRadioButton.Checked)
            {
                if (this.richTextBox.Text.Trim().Length > 0)
                {
                    try
                    {
                        Changesets changesetList = new Changesets();
                        changesetList.ChangesetList = new List<Changeset>();
                        List<string> lines = new List<string>();
                        Changeset changeset = new Changeset();
                        bool IsEdit, IsDelete, IsAdd, IsBranch;

                        String line = null;
                        int textboxLength = 0;
                        textboxLength = this.richTextBox.Lines.Length + 1;
                        for (int i = 0; i < textboxLength; i++)
                        {
                            if (i < textboxLength - 1)
                            {
                                line = richTextBox.Lines[i];
                            }
                            if (line != null && line != string.Empty)
                            {
                                changeset = new Changeset();

                                // find the filename
                                data = line.Substring(lineStartIndex, line.IndexOf("\t"));
                                if (data == null)
                                {
                                    data = line.Substring(lineStartIndex, line.IndexOf(EDIT));
                                    if (data == null)
                                    {
                                        data = line.Substring(lineStartIndex, line.IndexOf(DELETE));
                                        if (data == null)
                                        {
                                            data = line.Substring(lineStartIndex, line.IndexOf(ADD));
                                            if (data == null)
                                            {
                                                data = line.Substring(lineStartIndex, line.IndexOf(BRANCH));
                                            }
                                        }
                                    }
                                }



                                // append the filename
                                if (data != null && data.Length > 0)
                                {
                                    line.Substring(data.Length, (line.Length - 1));
                                }

                                changesetList.ChangesetList.Add(changeset);
                            }
                        }

                        //this.CreateExcel(revisionList);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An Error has encountered, We are sorry for the inconvenience");
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the duplicate revisions.
        /// </summary>
        /// <param name="revisions">The revisions.</param>
        /// <returns></returns>
        private Revisions DeleteDuplicateRevisions(Revisions revisions)
        {

            return null;
        }

        /// <summary>
        /// Creates the excel.
        /// </summary>
        /// <param name="revisions">The revisions.</param>
        private void CreateExcel(Revisions revisions)
        {
            this.progressBar1.Visible = true;
            for (int i = 1; i < 101; i++)
            {
                System.Threading.Thread.Sleep(60);
                if (i < 101)
                {
                    this.progressBar1.Value = i;
                }
            }

            try
            {
                int count = 0, rowCount = 3;
                int fileFromSaveDialog = 0;

                Excel.Application excelApplication;
                Excel.Workbook excelWorkbook;
                Excel.Worksheet excelWorksheet;
                object misValue = System.Reflection.Missing.Value;

                excelApplication = new Excel.ApplicationClass();
                if (excelApplication == null)
                {
                    MessageBox.Show("Microsoft Interop Services is not available");
                }

                excelWorkbook = excelApplication.Workbooks.Add(misValue);
                excelWorksheet = (Excel.Worksheet)excelWorkbook.Worksheets.get_Item(1);

                if (revisions != null && revisions.RevisionList != null)
                {
                    foreach (Revision revision in revisions.RevisionList)
                    {
                        if (count < 1)
                        {
                            excelWorksheet.Cells[1, 3] = "Release Note";
                            excelWorksheet.Cells[2, 1] = "Revision ID";
                            excelWorksheet.Cells[2, 2] = "Author";
                            excelWorksheet.Cells[2, 3] = "Date";
                            excelWorksheet.Cells[2, 4] = "Files";
                            excelWorksheet.Cells[2, 5] = "Message";
                        }

                        count++;
                        excelWorksheet.Cells[rowCount, 1] = revision.Revision_ID;
                        excelWorksheet.Cells[rowCount, 2] = revision.Author;
                        excelWorksheet.Cells[rowCount, 3] = revision.Date;
                        excelWorksheet.Cells[rowCount, 5] = revision.Message;

                        if (revision != null && revision.Added != null)
                        {
                            foreach (string addedFileName in revision.Added)
                            {
                                excelWorksheet.Cells[rowCount, 4] = addedFileName;
                                rowCount++;
                            }
                        }

                        if (revision != null && revision.Modified != null)
                        {
                            foreach (string modifiedFileName in revision.Modified)
                            {
                                excelWorksheet.Cells[rowCount, 4] = modifiedFileName;
                                rowCount++;
                            }
                        }

                        if (revision != null && revision.Deleted != null)
                        {
                            foreach (string deletedFileName in revision.Deleted)
                            {
                                excelWorksheet.Cells[rowCount, 4] = deletedFileName;
                                rowCount++;
                            }
                        }
                    }
                }

                saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    excelWorkbook.SaveAs(saveFileDialog1.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    excelWorkbook.Close(true, misValue, misValue);
                    excelApplication.Quit();
                    fileFromSaveDialog = 1;
                }
                else if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    excelWorkbook.Close(false, misValue, misValue);
                    excelApplication.Quit();
                    fileFromSaveDialog = 3;
                }
                else
                {
                    excelWorkbook.SaveAs("release_note.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    excelWorkbook.Close(true, misValue, misValue);
                    excelApplication.Quit();
                    fileFromSaveDialog = 2;
                }

                releaseObject(excelWorksheet);
                releaseObject(excelWorkbook);
                releaseObject(excelApplication);
                if (fileFromSaveDialog == 1)
                {
                    MessageBox.Show("The Excel file has been created, in " + saveFileDialog1.FileName);
                }
                else if (fileFromSaveDialog == 2)
                {
                    MessageBox.Show("The Excel file has been created, you can find the file in your My Documents Folder");
                }
                else if (fileFromSaveDialog == 3)
                {
                    MessageBox.Show("The Excel file has not been created");
                }
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("0x800A03EC"))
                {
                    MessageBox.Show("Please close the excel file...");
                }
                else
                {
                    MessageBox.Show("An Exception has encountered, We are sorry for the inconvenience");
                }
            }

            this.progressBar1.Visible = false;
        }

        /// <summary>
        /// Releases the object.
        /// </summary>
        /// <param name="obj">The obj.</param>
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception occured " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the SvnRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SvnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SvnRadioButton.Checked && this.TFSRadioButton.Checked == false)
            {
                this.SvnRadioButton.Checked = true;
            }
            else if (this.SvnRadioButton.Checked == false && this.TFSRadioButton.Checked == true)
            {
                this.SvnRadioButton.Checked = false;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the TFSRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TFSRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (TFSRadioButton.Checked)
            {
                this.HeadingLabel.Visible = false;
                this.BrowseButton.Visible = false;
                this.OrLabel.Visible = false;
                this.EnterFreeTextButton.Location = new Point(190, 19);
                this.TextFileName = string.Empty;
                FileDetailsLabel.Text = string.Empty;
                FileDetailsLabel1.Text = string.Empty;
                FileDetailsLabel2.Text = string.Empty;
                this.GenerateButton.Visible = false;
                if (this.Size.Height == 200)
                {
                    this.Size = this.Size.Height == 200 ? new Size(480, 100) : new Size(480, 200);
                }
                else if (this.Size.Height == 400)
                {
                    this.EnterFreeTextButton.PerformClick();
                }
            }
            else
            {
                this.HeadingLabel.Visible = true;
                this.BrowseButton.Visible = true;
                this.OrLabel.Visible = true;
                this.EnterFreeTextButton.Location = new Point(338, 19);
            }
        }

        #endregion
    }
}