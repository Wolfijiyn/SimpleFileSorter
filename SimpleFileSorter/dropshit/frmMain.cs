using System;
using System.IO;
using System.Windows.Forms;

namespace dropshit
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            //Allow the drop feature
            AllowDrop = true;
            InitializeComponent();
        }
        

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            //If you drag files into the application it reacts with a DragDropEffect
            //https://msdn.microsoft.com/en-us/library/system.windows.forms.dragdropeffects(v=vs.110).aspx
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            //Create a string array to keep all the files in when dropped into the listBox aka lBox
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            lBox.Items.AddRange(files);

            #region AllFiles
            //This is where you would add and or modify all the file extensions it can sort.
            //So far it supports .txt .exe .PNG .jpg .lnk .rar

                #region TextFiles

            #region FolderPaths
            //Define a two folderpaths 
            string txtFolderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string txtPathFolder = System.IO.Path.Combine(txtFolderPath, "Text Files");
            #endregion

            //Create a Messagebox with 3 options - Yes, No, Cancel.
            DialogResult dr = MessageBox.Show("Would you like to sort the files", "Option", MessageBoxButtons.YesNoCancel);
            //if the user presses "Yes"
            if (dr == DialogResult.Yes)
            {
                //For each Text file in the ListBox
                foreach (var txtFile in lBox.Items)
                {
                    //Create a string variable that grabs and holds the file extension
                    string fileExtension = Path.GetExtension(txtFile.ToString());

                    //if the FileExtension is equal to .txt then we want to do something
                    if (fileExtension == Path.GetExtension(".txt"))
                    {
                        //Create a string and combine the two parameters;
                        //first being the txtFolderPath and the second being the name of the folder Line: 38
                        string folderPath = System.IO.Path.Combine(txtFolderPath, "Textfiles");

                        //create the folder with the name "Textfiles"
                        System.IO.Directory.CreateDirectory(folderPath);

                        //If the file extension is equal to .txt
                        if (fileExtension == Path.GetExtension(".txt"))
                        {
                            //create a string to hold the txtFile name
                            string fileName = txtFile.ToString();

                            //get the file path
                            string filePath = System.IO.Path.GetFileName(fileName);
                            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Textfiles";

                            //Manipulate the two paths together
                            string targetPath = System.IO.Path.Combine(path, filePath);

                            //And finally move the file from the original destination to the newly created folder.

                            //Now rinse and repeat everything for a new File Extension. You can just copy the "exeFiles" region below
                            //to use as a template, although Keep in mind that it does not have the MessageBox Dialog in it
                            //Because there is no need to.
                            if (!File.Exists(targetPath))
                            {
                                System.IO.File.Move(fileName, targetPath);
                            }
                        }
                    }
                }
                #endregion
                
                #region exeFiles

                #region FolderPaths
                string exeFolderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string exePathFolder = System.IO.Path.Combine(exeFolderPath, "Executables");
                #endregion

                foreach (var exeFile in lBox.Items)
                {
                    string fileExtension = Path.GetExtension(exeFile.ToString());

                    if (fileExtension == Path.GetExtension(".exe"))
                    {
                        string folderPath = System.IO.Path.Combine(exeFolderPath, "Executables");
                        System.IO.Directory.CreateDirectory(folderPath);

                        if (fileExtension == Path.GetExtension(".exe"))
                        {
                            string fileName = exeFile.ToString();
                            string filePath = System.IO.Path.GetFileName(fileName);
                            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Executables";
                            string targetPath = System.IO.Path.Combine(path, filePath);

                            if (!File.Exists(targetPath))
                            {
                                System.IO.File.Move(fileName, targetPath);
                            }

                        }
                    }
                }
                #endregion

                #region imgFiles

                #region FolderPaths
                string imgFolderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string imgPathFolder = System.IO.Path.Combine(imgFolderPath, "AllImages");
                #endregion

                foreach (var imgFile in lBox.Items)
                {
                    string fileExtension = Path.GetExtension(imgFile.ToString());
                    if (fileExtension == Path.GetExtension(".PNG"))
                    {
                        string folderPath = System.IO.Path.Combine(imgFolderPath, "Images");
                        System.IO.Directory.CreateDirectory(imgPathFolder);

                        if (fileExtension == Path.GetExtension(".PNG"))
                        {
                            string fileName = imgFile.ToString();
                            string filePath = System.IO.Path.GetFileName(fileName);
                            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\AllImages";
                            string targetPath = System.IO.Path.Combine(path, filePath);

                            if (!File.Exists(targetPath))
                            {
                                System.IO.File.Move(fileName, targetPath);
                            }

                        }
                    }
                }

                foreach (var imgFile in lBox.Items)
                {
                    string fileExtension = Path.GetExtension(imgFile.ToString());
                    if (fileExtension == Path.GetExtension(".jpg"))
                    {
                        string folderPath = System.IO.Path.Combine(imgFolderPath, "AllImages");
                        System.IO.Directory.CreateDirectory(imgPathFolder);

                        if (fileExtension == Path.GetExtension(".jpg"))
                        {
                            string fileName = imgFile.ToString();
                            string filePath = System.IO.Path.GetFileName(fileName);
                            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\AllImages";
                            string targetPath = System.IO.Path.Combine(path, filePath);

                            if (!File.Exists(targetPath))
                            {
                                System.IO.File.Move(fileName, targetPath);
                            }

                        }
                    }
                }

                #endregion

                #region lnkFiles

                #region FolderPaths
                string lnkFolderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string lnkPathFolder = System.IO.Path.Combine(lnkFolderPath, "Shortcuts");
                #endregion

                foreach (var lnkFile in lBox.Items)
                {
                    string fileExtension = Path.GetExtension(lnkFile.ToString());

                    if (fileExtension == Path.GetExtension(".lnk"))
                    {
                        string folderPath = System.IO.Path.Combine(lnkFolderPath, "Shortcuts");
                        System.IO.Directory.CreateDirectory(folderPath);

                        if (fileExtension == Path.GetExtension(".lnk"))
                        {
                            string fileName = lnkFile.ToString();
                            string filePath = System.IO.Path.GetFileName(fileName);
                            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Shortcuts";
                            string targetPath = System.IO.Path.Combine(path, filePath);

                            if (!File.Exists(targetPath))
                            {
                                System.IO.File.Move(fileName, targetPath);
                            }

                        }
                    }
                }
                #endregion

                #region rarFiles

                #region FolderPaths
                string rarFolderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string rarPathFolder = System.IO.Path.Combine(rarFolderPath, "RarFiles");
                #endregion

                foreach (var rarFile in lBox.Items)
                {
                    string fileExtension = Path.GetExtension(rarFile.ToString());

                    if (fileExtension == Path.GetExtension(".rar"))
                    {
                        string folderPath = System.IO.Path.Combine(rarFolderPath, "RarFiles");
                        System.IO.Directory.CreateDirectory(folderPath);

                        if (fileExtension == Path.GetExtension(".rar"))
                        {
                            string fileName = rarFile.ToString();
                            string filePath = System.IO.Path.GetFileName(fileName);
                            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\RarFiles";
                            string targetPath = System.IO.Path.Combine(path, filePath);

                            if (!File.Exists(targetPath))
                            {
                                System.IO.File.Move(fileName, targetPath);
                            }

                        }
                    }
                }
                #endregion

                #endregion
                MessageBox.Show("Sorted " + files.Length + " Files");
            }
            lBox.Items.Clear();
        }

        private void frmMain_Move(object sender, EventArgs e)
        {
            //When minimized we create a BallonTip at the bottom right of our screen
            //with a title and a message
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(5000, "Title", "Your Message", ToolTipIcon.Info);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            //When the icon is double clicked we bring the form back up.
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            //When the balloonTip is clicked then we bring the form back up.
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}


