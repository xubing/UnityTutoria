using System;
using System.Net.Sockets;

namespace MTexasPokerFrame.Connection
{
	class ConnectionInfo
	{
		protected string hostName = "";
		public string HostName 
		{
			get 
			{
				return hostName;
			}
			set 
			{
				hostName = value;
			}
		}

		protected short hostPort = 0;
		public short HostPort 
		{
			get 
			{
				return hostPort;
			}
			set 
			{
				hostPort = value;
			}
		}
	}

	class ConnectionInfoStatus : ConnectionInfo
	{
		public enum CONNECTION_STATUS
		{
			CONNECTION_STATUS_IDLE = 0,
			CONNECTION_STATUS_CONNECTING,
			CONNECTION_STATUS_CONNECTED,
			CONNECTION_STATUS_RECONNECTING,
			CONNECTION_STATUS_RECONNECTED,
			CONNECTION_STATUS_CLOSING,
			CONNECTION_STATUS_CLOSED
		};

		protected CONNECTION_STATUS connectionStatus = CONNECTION_STATUS.CONNECTION_STATUS_IDLE;
		public CONNECTION_STATUS ConnectionStatus
		{
			get
			{
				return connectionStatus;
			}
			set
			{
				connectionStatus = value;
			}
		}

		public ConnectionInfo GetConnectionInfo()
		{
			return this as ConnectionInfo;
		}
	}

	class Connection
	{
		private ConnectionInfoStatus connectionInfoStatus = new ConnectionInfoStatus();
		public Connection(string hostName, short hostPort)
		{
			connectionInfoStatus.HostName = hostName;
			connectionInfoStatus.HostPort = hostPort;
		}

		private Socket connectionSocket;

	}
}