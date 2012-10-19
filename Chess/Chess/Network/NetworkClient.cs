using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Chess.Network
{
	public class NetworkClient: BaseNetwork
	{

		public NetworkClient (INetworkSupport isuppport): base(isuppport)
		{
		}

		public void ConnetcToServer (string ip)
		{
			if( IsConnected ) {
				throw new SocketException(255);
			}

			IPAddress serverIP = IPAddress.Parse (ip);
			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Connect(serverIP, NetworkDef.PORT );


			//invoke intrerface notify
			connected = true;
			thread = new Thread( SocketIO );
			thread.IsBackground = true;
			thread.Priority = ThreadPriority.BelowNormal;
			thread.Name = "ClientThread";
			thread.Start ();
		}

		protected override void SocketIO ()
		{
				
			string r = ReceiveCommand ();

			if (r.Equals( NetworkDef.VERSION )) {
				SendCommand (NetworkDef.OK);
				iNetwork.Connected();
			}
			else
			{
				SendCommand (NetworkDef.ERROR);
				Disconnect();
				return;
			}

		}
	}
}
