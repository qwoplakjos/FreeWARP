using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leaf.xNet;

namespace Free_WARP_
{
    public partial class Form1 : Form
    {
        List<Proxy> proxiesList = new List<Proxy>();
        List<ProxyCheck> proxyThreads = new List<ProxyCheck>();
        List<Task> tasks = new List<Task>();

        static int totalGood = 0;
        static int totalBad = 0;
        int threads = 100;
        static string referCode = "";
        private static Random rnd = new Random();

        bool scraping = false;
        bool running = false;

        public Form1()
        {
            InitializeComponent();
            CreateScrapeList();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            running = !running;

            if (running)
            {
                CreateListsForThreads();
                startButton.ForeColor = Color.FromArgb(242, 48, 55);
                startButton.Text = "Stop";
            }
            else
            {
                startButton.ForeColor = Color.FromArgb(29, 209, 93);
                startButton.Text = "Start";
            }
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            scraping = true;

            Task.Run(() =>
            {
                while (scraping)
                {
                    Invoke(new Action(() =>
                    {
                        if (getButton.Text == "Get...") getButton.Text = "Get";
                        getButton.Text += ".";
                    }));
                    Thread.Sleep(500);
                }

                Invoke(new Action(() =>
                {
                    getButton.Text = "Get";
                }));
            });

            Task.Run(() =>
            {
                ScrapeProxies();
                Invoke(new Action(() =>
                {
                    proxyCountLabel.Text = "Proxies loaded: " + proxiesList.Count;
                }));

            });
        }




        private void CreateListsForThreads()
        {
            if (!int.TryParse(threadTextbox.Text, out int count))
            {
                MessageBox.Show("Please enter correct number of threads.");
                return;
            }

            if (proxiesList.Count == 0)
            {
                MessageBox.Show("No proxies!");
                return;
            }

            var c = proxiesList.Count / threads;
            var chunked = proxiesList.ChunkBy(c > 0 ? c : 1);




            foreach (var item in chunked)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    ProxyCheck check = new ProxyCheck(item);
                    proxyThreads.Add(check);

                    while (running && check.Proxies.Count > 0)
                    {
                        check.StartChecking();
                        Thread.Sleep(10000);
                    }
                }));
            }

            Task.WhenAll(tasks.ToArray()).ContinueWith(t =>
            {
                MessageBox.Show("Done!");
            });
        }

        private List<ProxyScrapeLink> CreateScrapeList()
        {
            var list = new List<ProxyScrapeLink>();

            string link1 = "https://raw.githubusercontent.com/clarketm/proxy-list/master/proxy-list-raw.txt";
            string link2 = "https://raw.githubusercontent.com/TheSpeedX/PROXY-List/master/http.txt";
            string link3 = "https://api.proxyscrape.com/?request=getproxies&proxytype=http&timeout=10000&country=all&ssl=all&anonymity=all";
            string link4 = "https://raw.githubusercontent.com/TheSpeedX/PROXY-List/master/socks4.txt";
            string link5 = "https://api.proxyscrape.com/?request=getproxies&proxytype=socks4&timeout=10000&country=all&ssl=all&anonymity=all";
            string link6 = "https://raw.githubusercontent.com/TheSpeedX/PROXY-List/master/socks5.txt";
            string link7 = "https://raw.githubusercontent.com/clarketm/proxy-list/master/proxy-list-raw.txt";
            string link8 = "https://api.proxyscrape.com/?request=getproxies&proxytype=socks5&timeout=10000&country=all&ssl=all&anonymity=all";
            string link9 = "https://raw.githubusercontent.com/ShiftyTR/Proxy-List/master/http.txt";
            string link10 = "https://raw.githubusercontent.com/ShiftyTR/Proxy-List/master/socks4.txt";
            string link11 = "https://raw.githubusercontent.com/ShiftyTR/Proxy-List/master/socks5.txt";
            string link12 = "https://raw.githubusercontent.com/monosans/proxy-list/main/proxies/http.txt";
            string link13 = "https://raw.githubusercontent.com/monosans/proxy-list/main/proxies/socks4.txt";
            string link14 = "https://raw.githubusercontent.com/monosans/proxy-list/main/proxies/socks5.txt";
            string link15 = "https://raw.githubusercontent.com/hookzof/socks5_list/master/proxy.txt";
            string link16 = "https://raw.githubusercontent.com/mertguvencli/http-proxy-list/main/proxy-list/data.txt";
            string link17 = "https://raw.githubusercontent.com/mmpx12/proxy-list/master/http.txt";
            string link18 = "https://raw.githubusercontent.com/mmpx12/proxy-list/master/socks4.txt";
            string link19 = "https://raw.githubusercontent.com/mmpx12/proxy-list/master/socks5.txt";
            string link20 = "https://www.proxyscan.io/download?type=http";
            string link21 = "https://www.proxyscan.io/download?type=socks4";
            string link22 = "https://www.proxyscan.io/download?type=socks5";
            string link23 = "https://raw.githubusercontent.com/jetkai/proxy-list/main/online-proxies/txt/proxies-http.txt";
            string link24 = "https://raw.githubusercontent.com/jetkai/proxy-list/main/online-proxies/txt/proxies-socks4.txt";
            string link25 = "https://raw.githubusercontent.com/jetkai/proxy-list/main/online-proxies/txt/proxies-socks5.txt";

            list.Add(new ProxyScrapeLink(link1, ProxyType.HTTP));
            list.Add(new ProxyScrapeLink(link2, ProxyType.HTTP));
            list.Add(new ProxyScrapeLink(link3, ProxyType.HTTP));
            list.Add(new ProxyScrapeLink(link4, ProxyType.Socks4));
            list.Add(new ProxyScrapeLink(link5, ProxyType.Socks4));
            list.Add(new ProxyScrapeLink(link6, ProxyType.Socks5));
            list.Add(new ProxyScrapeLink(link7, ProxyType.HTTP));
            list.Add(new ProxyScrapeLink(link8, ProxyType.Socks5));
            list.Add(new ProxyScrapeLink(link9, ProxyType.HTTP));
            list.Add(new ProxyScrapeLink(link10, ProxyType.Socks4));
            list.Add(new ProxyScrapeLink(link11, ProxyType.Socks5));
            list.Add(new ProxyScrapeLink(link12, ProxyType.HTTP));
            list.Add(new ProxyScrapeLink(link13, ProxyType.Socks4));
            list.Add(new ProxyScrapeLink(link14, ProxyType.Socks5));
            list.Add(new ProxyScrapeLink(link15, ProxyType.Socks5));
            list.Add(new ProxyScrapeLink(link16, ProxyType.HTTP));
            list.Add(new ProxyScrapeLink(link17, ProxyType.HTTP));
            list.Add(new ProxyScrapeLink(link18, ProxyType.Socks4));
            list.Add(new ProxyScrapeLink(link19, ProxyType.Socks5));
            list.Add(new ProxyScrapeLink(link20, ProxyType.HTTP));
            list.Add(new ProxyScrapeLink(link21, ProxyType.Socks4));
            list.Add(new ProxyScrapeLink(link22, ProxyType.Socks5));
            list.Add(new ProxyScrapeLink(link23, ProxyType.HTTP));
            list.Add(new ProxyScrapeLink(link24, ProxyType.Socks4));
            list.Add(new ProxyScrapeLink(link25, ProxyType.Socks5));


            return list;
        }

        private void ScrapeProxies()
        {

            var scrapeLinks = CreateScrapeList();

            string httpString = "";
            string socks4String = "";
            string socks5String = "";

            foreach (var link in scrapeLinks)
            {
                switch (link.proxyType)
                {
                    case ProxyType.HTTP:
                        httpString += link.GetProxyAsString() + "\n";
                        break;
                    case ProxyType.Socks4:
                        socks4String += link.GetProxyAsString() + "\n";
                        break;
                    case ProxyType.Socks5:
                        socks5String += link.GetProxyAsString() + "\n";
                        break;
                }
            }

            httpString = httpString.RemoveEmptyLines();
            socks4String = socks4String.RemoveEmptyLines();
            socks5String = socks5String.RemoveEmptyLines();

            httpString = httpString.RemoveDupes();
            socks4String = socks4String.RemoveDupes();
            socks5String = socks5String.RemoveDupes();


            foreach (var p in httpString.Split('\n'))
            {
                proxiesList.Add(new Proxy(p, ProxyType.HTTP));
            }

            foreach (var p in socks4String.Split('\n'))
            {
                proxiesList.Add(new Proxy(p, ProxyType.Socks4));
            }

            foreach (var p in socks5String.Split('\n'))
            {
                proxiesList.Add(new Proxy(p, ProxyType.Socks5));
            }

            scraping = false;

            MessageBox.Show("Downloaded " + proxiesList.Count + " proxies!");

        }


        public class ProxyCheck
        {
            public ConcurrentDictionary<Proxy, int> Proxies { get; protected set; } = new ConcurrentDictionary<Proxy, int>();
            private int timeOut = 3000;

            public ProxyCheck(List<Proxy> proxies)
            {

                for (int i = 0; i < proxies.Count; i++)
                {
                    Proxies.TryAdd(proxies[i], i);
                }
            }

            public virtual ProxyCheck SetTimeout(int timeout)
            {
                timeOut = timeout;
                return this;
            }

            public void StartChecking()
            {
                var list = new ConcurrentDictionary<Proxy, int>(Proxies);

                foreach (var item in list)
                {
                    Check(item);
                }

                Thread.Sleep(20000);
            }

            private ProxyClient GetProxy(Proxy proxy)
            {
                switch (proxy.type)
                {
                    case ProxyType.HTTP: return HttpProxyClient.Parse(proxy.adress);
                    case ProxyType.Socks4: return Socks4ProxyClient.Parse(proxy.adress);
                    case ProxyType.Socks5: return Socks5ProxyClient.Parse(proxy.adress);
                    default: return HttpProxyClient.Parse(proxy.adress);
                }
            }


            private void Check(KeyValuePair<Proxy, int> proxy)
            {

                using (var request = new HttpRequest())
                {

                    try
                    {
                        string install_id = this.GenerateUniqueCode(22);
                        string key = this.GenerateUniqueCode(43) + "=";
                        string tos = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fff") + "+07:00";
                        string fcm_token = install_id + ":APA91b" + this.GenerateUniqueCode(134);
                        string referer = referCode;
                        string json = $"{{'install_id': '{install_id}', 'key': '{key}', 'tos': '{tos}', 'fcm_token': '{fcm_token}','referrer': '{referer}','warp_enabled': false, 'type': 'Android','locale': 'en_GB'}}".Replace("'", "\"");

                        request.Proxy = GetProxy(proxy.Key);

                        request.AddHeader("Accept-Encoding", "gzip");
                        request.AddHeader("Host", "api.cloudflareclient.com");
                        request.KeepAlive = true;
                        request.UserAgent = "okhttp/3.12.1";

                        var url = "https://api.cloudflareclient.com/v0a" + GenerateInt(3) + "/reg";

                        request.Post(url, json, "application/json; charset=UTF-8");
                        Interlocked.Increment(ref totalGood);
                    }
                    catch
                    {
                        //Proxies.TryRemove(proxy.Key, out int _);
                        Interlocked.Increment(ref totalBad);
                    }
                }
            }
            private string GenerateInt(int len)
            {
                StringBuilder output = new StringBuilder();

                for (int i = 0; i < len; i++)
                {
                    output.Append(rnd.Next(0, 10));
                }

                return output.ToString();
            }

            private string GenerateUniqueCode(int len)
            {
                string _allstring = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                string _re = "";
                while (_re.Length < len)
                {
                    _re += _allstring[rnd.Next(0, _allstring.Length - 1)].ToString();
                }
                return _re;
            }
        }

        public class Proxy
        {
            public string adress;
            public ProxyType type = ProxyType.HTTP;

            public Proxy(string adress, ProxyType proxyType)
            {
                this.adress = adress;
                this.type = proxyType;
            }
        }

        public class ProxyScrapeLink
        {
            string url;
            public ProxyType proxyType { get; private set; }

            public ProxyScrapeLink(string url, ProxyType proxyType)
            {
                this.url = url;
                this.proxyType = proxyType;
            }

            public string GetProxyAsString()
            {
                try
                {
                    HttpRequest req = new HttpRequest();
                    req.ConnectTimeout = 3000;
                    HttpResponse resp = req.Get(url);
                    using (var sr = new StreamReader(resp.ToMemoryStream())) return sr.ReadToEnd();
                }
                catch
                {
                    return "";
                }
            }
        }

        private void threadTextbox_TextChanged(object sender, EventArgs e)
        {
            if (threadTextbox.Text == "") return;

            if (!int.TryParse(threadTextbox.Text, out int n))
            {
                threadTextbox.Text = "100";
            }
            else
            {
                threads = n;
            }
        }

        private void idTextbox_TextChanged(object sender, EventArgs e)
        {
            referCode = idTextbox.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            goodLabel.Text = "Good: " + totalGood.ToString();
            badLabel.Text = "Bad: " + totalBad.ToString();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            using (var frm = new FileLoader())
            {
                frm.ShowDialog();

                if (frm.file == "") return;

                var res = File.ReadAllLines(frm.file);

                foreach (var item in res)
                {
                    proxiesList.Add(new Proxy(item, frm.type));
                }
                MessageBox.Show("Loaded " + res.Count() + " proxies!");
            }

            proxyCountLabel.Text = "Loaded proxies: " + proxiesList.Count.ToString();
        }


    }

    public static class ListExtensions
    {
        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }

    public static class StringExtensions
    {
        public static string RemoveDupes(this string str)
        {
            var arr = str.Split('\n');
            arr = arr.Distinct().ToArray();

            str = string.Join("\n", arr);
            return str;
        }

        public static string RemoveEmptyLines(this string str)
        {
            return Regex.Replace(str, @"^\s*$\n|\r", string.Empty, RegexOptions.Multiline).TrimEnd();
        }

        public static string RemoveLetters(this string str)
        {
            return new string(str.Where(c => char.IsNumber(c)).ToArray());
        }
    }
}
