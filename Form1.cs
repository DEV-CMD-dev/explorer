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
                    UpdateDirectory();
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            UpdateDirectory();
            DirectoryChanged += () => UpdateDirectory();
        }

        private void UpdateDirectory()
        {
            DirectoryTextBox.Text = CurrenDirectory;
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
