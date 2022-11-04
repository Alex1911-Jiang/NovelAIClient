using NovelAIClient;

namespace NovelAi_Test
{
    public partial class FrmClientTest : Form
    {
        public FrmClientTest()
        {
            InitializeComponent();
        }
        private async void Naifu()
        {
            EasyNaifuClient easyNaifuClient = new EasyNaifuClient("http://127.0.0.1:6969/");
            byte[] imageBytes = await easyNaifuClient.PostAsync(txbTags.Text.Split(',').Select(s => s.Trim()).ToArray());
            Image bmp = Image.FromStream(new MemoryStream(imageBytes));
            pictureBox1.Image = bmp;
        }

        private async void WebUI()
        {
            WebUIClient webUIClient = new WebUIClient("http://127.0.0.1:7860/");
            byte[]? imageBytes = await webUIClient.PostAsync(txbTags.Text.Split(',').Select(s => s.Trim()).ToArray());
            if (imageBytes != null)
                pictureBox1.Image = new Bitmap(new MemoryStream(imageBytes));
        }

        private void btnWebUI_Click(object sender, EventArgs e)
        {
            WebUI();
        }

        private void btnNaifu_Click(object sender, EventArgs e)
        {
            Naifu();
        }
    }
}