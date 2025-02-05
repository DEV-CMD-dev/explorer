using System.Diagnostics;
namespace Explorer_app
{
    public partial class Explorer : Form
    {
        public event Action DirectoryChanged;

        ImageList icons = new ImageList();
        
        

        string? PreviousDirectory;
        string? _CurrentDirectory = Directory.GetCurrentDirectory();

        public string? CurrentDirectory
        {
            get => _CurrentDirectory;
            set
            {
                if (Directory.Exists(value))
                {
                    Directory.SetCurrentDirectory(value);
                    _CurrentDirectory = value;
                    DirectoryChanged?.Invoke();
                }
            }
        }

        public Explorer()
        {
            InitializeComponent();
            UpdateDirectory();
            DirectoryChanged += () => UpdateDirectory();
            LoadIcons();
        }

        private void LoadIcons()
        {
            icons.ImageSize = new Size(32, 32);

            string basePath = Path.Combine(Application.StartupPath, "Icons");

            AddIcon(basePath, "folder.png");
            AddIcon(basePath, "exe.png");
            AddIcon(basePath, "mp3.png");
            AddIcon(basePath, "pdf-file.png");
            AddIcon(basePath, "txt.png");
            AddIcon(basePath, "dll.png");
            AddIcon(basePath, "dat.png");
            AddIcon(basePath, "png.png");
            //FileList.LargeImageList = icons;
            FileList.SmallImageList = icons;
        }
        private void AddIcon(string folderPath, string fileName)
        {
            string path = Path.Combine(folderPath, fileName);

            if (File.Exists(path))
            {
                icons.Images.Add(Image.FromFile(path));
            }
            else
            {
                MessageBox.Show($"Icon file not found: {path}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FileList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem? item = FileList.GetItemAt(e.X, e.Y);

                ContextMenuStrip menu = new ContextMenuStrip();
                if (item == null)
                {
                    menu.Items.Add("Add folder", Image.FromFile(Path.Combine(Application.StartupPath, @"Icons\add-folder.png")), (s, ev) => CreateNewFolder());
                    menu.Items.Add("Add file", Image.FromFile(Path.Combine(Application.StartupPath, @"Icons\new-file.png")), (s, ev) => CreateNewFile());
                    menu.Show(FileList, e.Location);
                    return;
                }

                item.Selected = true;

                menu.Items.Add("Open", Image.FromFile(Path.Combine(Application.StartupPath, @"Icons\open.png")), (s, ev) => GoToDirectory(Path.GetFullPath(item.Text)));
                menu.Items.Add("Delete", Image.FromFile(Path.Combine(Application.StartupPath, @"Icons\delete.png")), (s, ev) => Delete());
                
                

                menu.Show(FileList, e.Location);
            }
        }

        private void CreateNewFolder()
        {
            if (CurrentDirectory == null) return;

            string newFolderPath;
            int counter = 1;

            do
            {
                newFolderPath = Path.Combine(CurrentDirectory, $"NewFolder {counter}");
                counter++;
            }
            while (Directory.Exists(newFolderPath));

            try
            {
                Directory.CreateDirectory(newFolderPath);
                UpdateFileList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateNewFile()
        {
            if (CurrentDirectory == null) return;

            string newFilePath;
            int counter = 1;

            do
            {
                newFilePath = Path.Combine(CurrentDirectory, $"NewFile {counter}");
                counter++;
            } while (File.Exists(newFilePath));

            using (FileStream file = File.Create(newFilePath))
            {
                UpdateFileList();
            }
        }


        private void UpdateFileList()
        {
            FileList.Items.Clear();

            if (FileList.Columns.Count == 0)
            {
                FileList.Columns.Add("Name", 250);
                FileList.Columns.Add("Creation date", 200);
                FileList.Columns.Add("Size", 100, HorizontalAlignment.Right);
            }

            if (CurrentDirectory != null)
            {
                var entries = Directory.GetFileSystemEntries(CurrentDirectory);
                foreach (var e in entries)
                {
                    var fi = new FileInfo(e);
                    int iconIndex = 0;
                    CheckExtension(fi, out iconIndex);

                    var item = new ListViewItem(fi.Name, iconIndex);

                    item.SubItems.Add(fi.CreationTime.ToString());
                    item.SubItems.Add(fi.Exists ? (fi.Length / 1024).ToString() + " KB" : "-");

                    FileList.Items.Add(item);
                }
            }
        }


        private void CheckExtension(FileInfo fi, out int iconIndex)
        {
            var icons = new Dictionary<string, int>()
            {
                { ".exe", 1 },
                { ".mp3", 2 },
                { ".pdf", 3 },
                { ".txt", 4 },
                { ".dll", 5 },
                { ".dat", 6 },
                { ".png", 7 }
            };

            iconIndex = icons.GetValueOrDefault(fi.Extension, 0);
        }


        private void UpdateDirectory()
        {
            DirectoryTextBox.Text = CurrentDirectory;
            UpdateFileList();
        }

        private void DirectoryForward_Click(object sender, EventArgs e)
        {
            CurrentDirectory = PreviousDirectory;
        }

        private void DirectoryBackward_Click(object sender, EventArgs e)
        {
            if (CurrentDirectory != null)
            {
                string? path = Path.GetFullPath(Path.Combine(CurrentDirectory, ".."));
                PreviousDirectory = CurrentDirectory;
                CurrentDirectory = path;
            }
        }

        private void Delete()
        {
            string path = Path.Combine(CurrentDirectory!, FileList.SelectedItems[0].Text);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            else if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            UpdateFileList();
        }

        private void GoToDirectory(object sender, EventArgs e)
        {
            string path = Path.Combine(CurrentDirectory!, FileList.SelectedItems[0].Text);
            if (Directory.Exists(path))
            {
                CurrentDirectory = path;
            }
            else
            {
                Process.Start("explorer.exe",path);
            }
            
        }

        private void GoToDirectory(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    CurrentDirectory = path;
                }
                else
                {
                    Process.Start("explorer.exe", path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
