namespace Explorer_app
{
    public partial class Form1 : Form
    {
        public event Action DirectoryChanged;

        string? PreviousDirectory;
        string? _CurrentDirectory;

        public string CurrenDirectory
        {
            get => Directory.GetCurrentDirectory();
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
            if (PreviousDirectory != null)
            {
                CurrenDirectory = PreviousDirectory;
                UpdateDirectory();
            }
        }

        private void DirectoryBackward_Click(object sender, EventArgs e)
        {
            string parentDirectory = Path.Combine(CurrenDirectory, "..");
            if (Directory.Exists(parentDirectory))
            {
                PreviousDirectory = _CurrentDirectory;
                CurrenDirectory = parentDirectory;
            }
        }
    }
}
