using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Net.Sockets;
using System;
using System.Text;
using System.Net;

namespace TablicaClient
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        string ServerIP = "192.168.99.100";
        readonly int ServerPort = 59011;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            FindViewById<Button>(Resource.Id.button2);
            FindViewById<Button>(Resource.Id.button2).Click += Team1PointsUP;
            FindViewById<Button>(Resource.Id.button1);
            FindViewById<Button>(Resource.Id.button1).Click += Team1PointsDown;

            FindViewById<Button>(Resource.Id.button4);
            FindViewById<Button>(Resource.Id.button4).Click += Team1WinningSetUp;
            FindViewById<Button>(Resource.Id.button3);
            FindViewById<Button>(Resource.Id.button3).Click += Team1WinningSetDown;

            FindViewById<Button>(Resource.Id.button6);
            FindViewById<Button>(Resource.Id.button6).Click += Team2PointsUP;
            FindViewById<Button>(Resource.Id.button5);
            FindViewById<Button>(Resource.Id.button5).Click += Team2PointsDown;

            FindViewById<Button>(Resource.Id.button8);
            FindViewById<Button>(Resource.Id.button8).Click += Team2WinningSetUp;
            FindViewById<Button>(Resource.Id.button7);
            FindViewById<Button>(Resource.Id.button7).Click += Team2WinningSetDown;

            FindViewById<Button>(Resource.Id.button10);
            FindViewById<Button>(Resource.Id.button10).Click += SetNumberUp;
            FindViewById<Button>(Resource.Id.button9);
            FindViewById<Button>(Resource.Id.button9).Click += SetNumberDown;

            // start stop stopwatch
            FindViewById<Button>(Resource.Id.button11);
            FindViewById<Button>(Resource.Id.button11).Click += StopWatchStart;
            
            // stop stop Stopwatch
            FindViewById<Button>(Resource.Id.button12);
            FindViewById<Button>(Resource.Id.button12).Click += StopWatchStop;

            // stop Reset reset stopwatch
            FindViewById<Button>(Resource.Id.button14);
            FindViewById<Button>(Resource.Id.button14).Click += StopWatchReset;

            // change stopwatch clock
            FindViewById<Button>(Resource.Id.button13);
            FindViewById<Button>(Resource.Id.button13).Click += StopWatchClock;

            // Pauza
            FindViewById<Button>(Resource.Id.button16);
            FindViewById<Button>(Resource.Id.button16).Click += StopWatchPause;

            // Wznowienie
            FindViewById<Button>(Resource.Id.button17);
            FindViewById<Button>(Resource.Id.button17).Click += StopWatchResume;

            // Ustawienie nazwy dla t1
            FindViewById<Button>(Resource.Id.button18);
            FindViewById<Button>(Resource.Id.button18).Click += SetT1Name;

            // Ustawienie nazwy dla t2
            FindViewById<Button>(Resource.Id.button19);
            FindViewById<Button>(Resource.Id.button19).Click += SetT2Name;

            // Ustawienie nazwy dla t2
            FindViewById<Button>(Resource.Id.button20);
            FindViewById<Button>(Resource.Id.button20).Click += SetIP;

            //Toast.MakeText(ApplicationContext, "tekst", ToastLength.Long).Show();
        }

        public void SetIP(object sender, EventArgs e)
        {
            string txt = FindViewById<EditText>(Resource.Id.editText4).Text;
            ServerIP = txt;

            Toast.MakeText(ApplicationContext, "IP set: " + txt, ToastLength.Long).Show();
        }

        public void SetT2Name(object sender, EventArgs e)
        {
            string txt = FindViewById<EditText>(Resource.Id.editText3).Text;
            string toSend = "SetT2Name"+txt;

            Toast.MakeText(ApplicationContext, "info "+txt, ToastLength.Long).Show();

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();
        }

        public void SetT1Name(object sender, EventArgs e)
        {
            string txt = FindViewById<EditText>(Resource.Id.editText2).Text;
            string toSend = "SetT1Name"+txt;

            Toast.MakeText(ApplicationContext, "t1", ToastLength.Long).Show();

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();
        }

        public void StopWatchResume(object sender, EventArgs e)
        {
            string toSend = "StopWatchResume";

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();
        }

        public void StopWatchPause(object sender, EventArgs e)
        {
            string toSend = "StopWatchPause";

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();
        }

        public void StopWatchClock(object sender, EventArgs e)
        {
            string toSend = "StopWatchClock";

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();
        }

        public void StopWatchStart(object sender, EventArgs e)
        {
            string toSend = "StopWatchStart";
            
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();
        }

        public void StopWatchStop(object sender, EventArgs e)
        {
            string toSend = "StopWatchStop";

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();
        }

        public void StopWatchReset(object sender, EventArgs e)
        {
            string toSend = "StopWatchReset";

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();
        }


        public void SetNumberDown(object sender, EventArgs e)
        {
            string toSend = "SetNumberDown";

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();
        }

        public void SetNumberUp(object sender, EventArgs e)
        {
            string toSend = "SetNumberUp";

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();
        }

        public void Team2WinningSetDown(object sender, EventArgs e)
        {
            string toSend = "Team2WinningSetDown";

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();
        }

        public void Team2WinningSetUp(object sender, EventArgs e)
        {
            string toSend = "Team2WinningSetUp";

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();
        }

        public void Team1WinningSetDown(object sender, EventArgs e)
        {
            string toSend = "Team1WinningSetDown";

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();
        }

            public void Team1WinningSetUp(object sender, EventArgs e)
        {
            string toSend = "Team1WinningSetUp";

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();
        }

        public void Team1PointsUP(object sender, EventArgs e)
        {
            string toSend = "Team1PointsUP";

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();

        }

        public void Team1PointsDown(object sender, EventArgs e)
        {
            string toSend = "Team1PointsDown";

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();
        }

        public void Team2PointsUP(object sender, EventArgs e)
        {
            string toSend = "Team2PointsUP";

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();

        }

        public void Team2PointsDown(object sender, EventArgs e)
        {
            string toSend = "Team2PointsDown";

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            clientSocket.Close();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}