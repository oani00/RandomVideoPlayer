namespace VideoP
{
    public partial class FORM : Form
    {
        private Configs Configs;
        private Player Player;

        public FORM()
        {
            InitializeComponent();
            Configs = new Configs();
            Player = new Player(Configs);

            textBox1.Text = Configs.ConfigsPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Player.PlayRandomVideo();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { }
    }
}