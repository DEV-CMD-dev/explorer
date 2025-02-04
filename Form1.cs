using System.Diagnostics;
namespace Explorer_app
{
    public partial class Explorer : Form
    {
        public event Action DirectoryChanged;

        ImageList icons = new ImageList();
        
        

        string? PreviousDirectory;
        string? _CurrentDirectory = Directory.GetCurrentDirectory();

        public string? CurrenDirectory
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


        private void UpdateFileList()
        {
            FileList.Items.Clear();

            if (FileList.Columns.Count == 0)
            {
                FileList.Columns.Add("Name", 250);
                FileList.Columns.Add("Creation date", 200);
                FileList.Columns.Add("Size", 100, HorizontalAlignment.Right);
            }

            if (CurrenDirectory != null)
            {
                var entries = Directory.GetFileSystemEntries(CurrenDirectory);
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


        private void CheckExtension(FileInfo fi,out int iconIndex)
        {
            switch (fi.Extension)
            {
                case ".exe":
                    iconIndex = 1;
                    break;
                case ".mp3":
                    iconIndex = 2;
                    break;
                case ".pdf":
                    iconIndex = 3;
                    break;
                case ".txt":
                    iconIndex = 4;
                    break;
                case ".dll":
                    iconIndex = 5;
                    break;
                case ".dat":
                    iconIndex = 6;
                    break;
                case ".png":
                    iconIndex = 7;
                    break;
                default:
                    iconIndex = 0;
                    break;
            }
        }

        private void UpdateDirectory()
        {
            DirectoryTextBox.Text = CurrenDirectory;
            UpdateFileList();
        }

        private void DirectoryForward_Click(object sender, EventArgs e)
        {
            CurrenDirectory = PreviousDirectory;
        }

        private void DirectoryBackward_Click(object sender, EventArgs e)
        {
            if (CurrenDirectory != null)
            {
                string? path = Path.GetFullPath(Path.Combine(CurrenDirectory, ".."));
                PreviousDirectory = CurrenDirectory;
                CurrenDirectory = path;
            }
        }

        private void GoToDirectory(object sender, EventArgs e)
        {
            string path = Path.Combine(CurrenDirectory!, FileList.SelectedItems[0].Text);
            if (Directory.Exists(path))
            {
                CurrenDirectory = path;
            }
            else
            {
                Process.Start("explorer.exe",path);
            }
            
        }
        
    }
}
