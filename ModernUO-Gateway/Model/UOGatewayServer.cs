using System.Net;
using System.Net.Sockets;

namespace ModernUO_Gateway.Model;

public class UOGatewayServer : IHostedService
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly HashSet<TcpClient> _tcpClients = [];

    public UOGatewayServer(IHostApplicationLifetime hostApplicationLifetime) => _hostApplicationLifetime = hostApplicationLifetime;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _ = Task.Run(RunServer, cancellationToken);
        return Task.CompletedTask;
    }
    
    private async Task RunServer()
    {
        CancellationToken stoppingToken = _hostApplicationLifetime.ApplicationStopping;
        TcpListener tcpListener = new TcpListener(IPAddress.Any, 2593);
        tcpListener.Start();
        
        while (!stoppingToken.IsCancellationRequested)
        {
            TcpClient client = await tcpListener.AcceptTcpClientAsync(stoppingToken);
            client.NoDelay = true;
            if (stoppingToken.IsCancellationRequested)
            {
                break;
            }
            
            _tcpClients.Add(client);
            _ = Task.Run(() => HandleClientAsync(client, stoppingToken), stoppingToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        foreach (TcpClient client in _tcpClients)
        {
            client.Client.Shutdown(SocketShutdown.Both);
            client.Client.Close(); // Calls dispose
        }

        _tcpClients.Clear();

        return Task.CompletedTask;
    }

    private async Task HandleClientAsync(TcpClient client, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }
        
        // Implement your logic to handle the TCP client
        // You can use _myService here as needed
    }
}