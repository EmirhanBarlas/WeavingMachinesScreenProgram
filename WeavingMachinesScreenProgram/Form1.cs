using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeavingMachinesScreenProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            makinecek();
        }

        async void makinecek()
        {
            Dictionary<string, string> ipMachineMap = new Dictionary<string, string>
            {
                { "192.168.1.207", "JAKAR 1"},
                { "192.168.1.206", "JAKAR 2"},
                { "192.168.1.203", "JAKAR 3"},
                { "192.168.1.202", "JAKAR 4"},
                { "192.168.1.205", "JAKAR 5"},
                { "192.168.1.204", "JAKAR 6" },
                { "192.168.1.208", "JAKAR 10" },
                { "192.168.1.209", "JAKAR 11" },
                { "192.168.1.200", "JAKAR 12" },
                { "192.168.1.201", "JAKAR 13" },
                { "192.168.1.210", "JAKAR 14" },
                { "192.168.1.211", "JAKAR 15" },
            };

            foreach (var entry in ipMachineMap)
            {
                string ip = entry.Key;
                string machineName = entry.Value;
                string url = $"http://{ip}/report.html";
                (string result, string result2) = await FetchDataFromUrl(url);
                if (!string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(result2))
                {
                    bool isRunning = result2.Contains("Running forward");
                    string status = isRunning ? "Çalýþýyor" : result2;
                    AddStatusPanel(machineName, result, status, isRunning ? Color.Green : Color.Red);
                }
                else
                {
                    AddStatusPanel(machineName, "Zaman aþýmý veya veri alýnamadý.", "", Color.Yellow);
                }
            }
        }

        private async Task<(string, string)> FetchDataFromUrl(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.Timeout = TimeSpan.FromMilliseconds(200);
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                    document.LoadHtml(responseBody);
                    var tdNode = document.DocumentNode.SelectSingleNode("//td[@rowspan='4']");
                    var h3Node = document.DocumentNode.SelectSingleNode("//h3");

                    string result = tdNode != null ? tdNode.InnerText.Trim() : "";
                    string result2 = h3Node != null ? h3Node.InnerText.Trim() : "";
                    return (result, result2);
                }
                catch (TaskCanceledException)
                {
                    return ("", "");
                }
                catch (HttpRequestException e)
                {
                    return ($"Veri Gelmiyor: {e.Message}", $"Veri Gelmiyor: {e.Message}");
                }
                catch (Exception error)
                {
                    return ("", $"Hata: {error.Message}");
                }
            }
        }

        private void AddStatusPanel(string machineName, string pattern, string status, Color backgroundColor)
        {
            Panel panel = new Panel
            {
                Size = new Size(200, 100),
                Margin = new Padding(10),
                BackColor = backgroundColor
            };

            Label nameLabel = new Label
            {
                Text = machineName,
                Location = new Point(10, 10),
                Font = new Font("Tahoma", 10, FontStyle.Bold)
            };

            Label patternLabel = new Label
            {
                Text = pattern,
                Location = new Point(10, 40),
                Font = new Font("Tahoma", 10)
            };

            Label statusLabel = new Label
            {
                Text = status,
                Location = new Point(10, 70),
                Font = new Font("Tahoma", 10)
            };

            panel.Controls.Add(nameLabel);
            panel.Controls.Add(patternLabel);
            panel.Controls.Add(statusLabel);
            flowLayoutPanel4.Controls.Add(panel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://buferatextile.com.tr/");
        }
    }
}
