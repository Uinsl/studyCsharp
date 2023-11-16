using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace myLolTest
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        public Form1()
        {
            InitializeComponent();
            AllocConsole();
        }

        private void Test_Click(object sender, EventArgs e)
        {
            RunCmd();          
        }






        private static void RunCmd()
        {
            Console.WriteLine("***********************  RunCmd()   ***********************");
            string str = "wmic PROCESS WHERE name='LeagueClientUx.exe' GET commandline"; //"ipconfig";// Console.ReadLine();

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //�Ƿ�ʹ�ò���ϵͳshell����
            p.StartInfo.RedirectStandardInput = true;//�������Ե��ó����������Ϣ
            p.StartInfo.RedirectStandardOutput = true;//�ɵ��ó����ȡ�����Ϣ
            p.StartInfo.RedirectStandardError = true;//�ض����׼�������
            p.StartInfo.CreateNoWindow = true;//����ʾ���򴰿�
            p.Start();//��������

            //��cmd���ڷ���������Ϣ
            p.StandardInput.WriteLine(str + "&exit");

            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //���׼����д��Ҫִ�е����
            //����ʹ��&������������ķ��ţ���ʾǰ��һ��������Ƿ�ִ�гɹ���ִ�к���(exit)��������ִ��exit����������ReadToEnd()���������
            //ͬ��ķ��Ż���&&��||ǰ�߱�ʾ����ǰһ������ִ�гɹ��Ż�ִ�к����������߱�ʾ����ǰһ������ִ��ʧ�ܲŻ�ִ�к��������

            //��ȡcmd���ڵ������Ϣ
            string output = p.StandardOutput.ReadToEnd();
            //StreamReader reader = p.StandardOutput;
            //string line=reader.ReadLine();
            //while (!reader.EndOfStream)
            //{
            //    str += line + "  ";
            //    line = reader.ReadLine();
            //}

            p.WaitForExit();//�ȴ�����ִ�����˳����� p���߳�
            p.Close();


            Regex portRegex = new Regex("--app-port=([0-9]*)");
            Regex tokenRegex = new Regex("--remoting-auth-token=([\\w-]*)");
            string port = portRegex.Match(output).Value;
            string token = tokenRegex.Match(output).Value;

            Console.WriteLine(output); //
            Console.WriteLine(token); // 
            Console.WriteLine(port);

            /*
             * 
             * --remoting-auth-token=higAN_29VI3qBQAp_h_YSg
--app-port=51090
             * */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("*********************** httpGet()  ***********************");
            //httpGet2();
            //httpPost();
            httpGet3();
        }

        //http
        private static async void httpGet()
        {
            // �����֤ҳ���� https �ģ���ο�һ�� jwt ��֤�� HttpClientHandler
            // ����  client 
            HttpClient client = new HttpClient();
            string user = "riot";
            string password = "higAN_29VI3qBQAp_h_YSg";
            string url = "";

            // ���������֤
            // using System.Net.Http.Headers;
            AuthenticationHeaderValue authentication = new AuthenticationHeaderValue(
            "Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user}:{password}")
                ));


            client.DefaultRequestHeaders.Authorization = authentication;

            byte[] response = await client.GetByteArrayAsync(url);
            client.Dispose();
        }


        //http
        private static async void httpGet2()
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3;    //https ���������䣬http �����ʡ��
            //����ssl��֤
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            string authorize = token64();
            string url = "https://127.0.0.1:51090/lol-summoner/v1/current-summoner";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";

            req.Headers.Add("Accept", "application/json");
            req.Headers.Add("Content-Type", "application/json");
            req.Headers.Add("Authorization", authorize);

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            Stream stream = res.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
            string json = streamReader.ReadToEnd();

            streamReader.Close();
            stream.Close();
            res.Close();

            Console.WriteLine(json);
        }

        private static async void httpGet3()
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3;    //https ���������䣬http �����ʡ��
            //����ssl��֤
            //ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);
            //HttpClient client = new HttpClient();

            string authorize = token64();
            Console.WriteLine(authorize);

            string url = "https://127.0.0.1:51090/lol-summoner/v1/current-summoner";
            //string url = "https://www.baidu.com";
            client.DefaultRequestHeaders.Authorization =new AuthenticationHeaderValue("Basic", authorize);
            //HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Accept", "application/json");
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");

            //client.DefaultRequestHeaders.Add("Authorization", authorize);

            var content = await client.GetStringAsync(url);
            Console.WriteLine(content);
            Console.WriteLine();
        }




        private static async void httpPost()
        {
            var httpClient = new HttpClient();
            var url = "https://www.baidu.com/";
            var response = await httpClient.PostAsync(url, new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("name","С��"),
                new KeyValuePair<string, string>("age","20")
            }));

            var str = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Post �������� "+str);
        }

        private static string token64() {
            var token = "higAN_29VI3qBQAp_h_YSg";
            token = "riot:" + token;
            //string token_64 = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
            //string token_64 = "Basic " + "cmlvdDpoaWdBTl8yOVZJM3FCUUFwX2hfWVNn";
            string token_64 = "cmlvdDpoaWdBTl8yOVZJM3FCUUFwX2hfWVNn";
            return token_64;
        }


        protected static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {   // ���ǽ���  
            return true;
        }

        /// <summary>
        /// https��get����
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="heads">����ͷ����</param>
        /// <returns></returns>
        public string HttpsGet(string url, Dictionary<string, string> heads)
        {
            //1.������֤
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

            //2.��ʼ����
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";


            foreach (var head in heads)
            {
                req.Headers.Add(head.Key, head.Value);
            }


            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            Stream stream = res.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
            string json = streamReader.ReadToEnd();

            streamReader.Close();
            stream.Close();
            res.Close();
            return json;
        }



    }
}