using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

using MySqlConnector;

using Rifoms.Domain.Infrastructure.Config;
using Rifoms.Domain.Infrastructure.Helper;

namespace Rifoms.WF
{
    public partial class FrmUpdater : Form
    {
        public string WebImagesPath;
        public string MySqlConnStr;
        public FrmUpdater()
        {
            InitializeComponent();
            WebImagesPath = PathConfig.WebImagesPath;
            MySqlConnStr = DebugConfig.IsDebug ? ConnectionConfig.DevLocalConnection : ConnectionConfig.DevServerConnection;

            //WwwRootPath = Environment.CurrentDirectory + $"/{PathConfig.WwwRootPath}";
        }

        private void btnMysql_Click(object sender, EventArgs e)
        {
            //string MySqlConn = DebugConfig.IsDebug ? ConnectionConfig.DevLocalConnection : ConnectionConfig.DevServerConnection;
            //if (!string.IsNullOrEmpty(MySqlConn))
            //{
            //    var Connection = new MySqlConnection(MySqlConn);
            //    Connection.Open();
            //    if (Connection.State == System.Data.ConnectionState.Open)
            //    {
            //          MessageBox.Show($"Подключение установлено: {MySqlConnStr}");
            //    }
            //}
        }

        private void btnConvertImage_Click(object sender, EventArgs e)
        {
            //Convert IMAGE's from JPG, GIF, PNG to WEBP
            var ImageFiles = Directory.GetFiles(WebImagesPath).ToList().OrderByDescending(c => c);
            var pathWebP = $"{WebImagesPath}webp";
            if (!Directory.Exists(pathWebP))
                Directory.CreateDirectory(pathWebP);

            Regex regex = new Regex(@"(\d{1,3})");
            foreach (var ImageFile in ImageFiles)
            {
                if (regex.IsMatch(ImageFile))
                    File.Delete(ImageFile);

                //var ImageFileInfo = new FileInfo(ImageFile);
                //var webpFileName = string.Empty;
                //using (var image = Image.Load(Path.Combine(WebImagesPath, ImageFile)))
                //{
                //    var exportOptions = new WebPOptions();

                //    if (ImageFileInfo.Name.EndsWith(".jpg"))
                //        webpFileName = ImageFileInfo.Name.Replace(".jpg", "");
                //    else if (ImageFileInfo.Name.EndsWith(".png"))
                //        webpFileName = ImageFileInfo.Name.Replace(".png", "");
                //    else
                //        webpFileName = ImageFileInfo.Name.Replace(".gif", "");

                //    image.Save($"{pathWebP}\\{webpFileName}.webp", exportOptions);
                //}
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = Translit.RusToEng(rcbTranslit.Text);
            rcbTranslitResult.ResetText();
            rcbTranslitResult.AppendText($"{result}");
        }

        private async void btnAddContent_Click(object sender, EventArgs e)
        {
            string pattern = @"\p{IsCyrillic}";

            if (Regex.IsMatch(txbTitle.Text, pattern, RegexOptions.Multiline))
            {
                MessageBox.Show("кирилыч и мифодий!!!!");
            }

            var seolink = Translit.RusToEng(txbTitle.Text);

            var InsertCommandText = SQL.InsertContent.Replace("{category_id}", "8").Replace("{user_id}", "1").Replace("{pubdate}", dtpPubDate.Value.ToString("yyyy-MM-dd HH:MM:ss"))
                .Replace("{enddate}", dtpEndDate.Value.ToString("yyyy-MM-dd")).Replace("{is_end}", chbIsEnd.Checked ? "1" : "0").Replace("{title}", txbTitle.Text).Replace("{description}", rcbDescription.Text)
                .Replace("{content}", rcbContent.Text).Replace("{published}", "1").Replace("{hits}", "540").Replace("{rating}", "1").Replace("{meta_desc}", txbTitle.Text).Replace("{meta_keys}", txbTitle.Text)
                .Replace("{meta_keys}", rcbDescription.Text);

            using var mySqlConnect = new MySqlConnection(MySqlConnStr);
            await mySqlConnect.OpenAsync();
            var mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mySqlConnect;
            mySqlCommand.CommandText = InsertCommandText;
            await mySqlCommand.ExecuteNonQueryAsync();
            await mySqlConnect.CloseAsync();
        }
    }
}