namespace Explorer_app
{
    public partial class Form1 : Form
    {
        public event Action DirectoryChanged;

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

        public Form1()
        {
            InitializeComponent();
            UpdateDirectory();
            DirectoryChanged += () => UpdateDirectory();
        }

        private void UpdateFileList()
        {
            FileList.Items.Clear();
            if (CurrenDirectory != null)
            {
                var entries = Directory.GetFileSystemEntries(CurrenDirectory);
                foreach (var e in entries)
                {
                    var fi = new FileInfo(e);
                    FileList.Items.Add(fi.Name);
                }
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
    }
}
