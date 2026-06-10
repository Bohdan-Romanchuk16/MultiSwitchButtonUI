using NModbus;
using NModbus.IO;
using System.Net.Sockets;

namespace ArduinoAutomaticHeatingControl
{
   public class ArduinoFinderOptaModbusTcp(string ip, int port = 502) : IDisposable
   {
      private TcpClient? _tcpClient;
      private IModbusMaster _master;

      private const byte SlaveId = 1;

      public bool IsConnected => _tcpClient is { Connected: true };

      public void Connect()
      {
         if (IsConnected) 
            return;
         
         _tcpClient = new TcpClient();
         _tcpClient.Connect(ip, port);

         var factory = new ModbusFactory();
         var adapter = new TcpClientAdapter(_tcpClient);
         _master = factory.CreateIpMaster(adapter);
      }

      public void Disconnect()
      {
         _master.Dispose();
         _tcpClient?.Close();
      }

      /// <summary>
      /// Setzt ein Relais (Coil) auf TRUE/FALSE
      /// </summary>
      public void SetOutput(int coilAddress, bool state)
      {
         if (!IsConnected)
            throw new InvalidOperationException("Nicht verbunden");

         _master.WriteSingleCoil(SlaveId, (ushort)coilAddress, state);
      }

      /// <summary>
      /// Relais EIN
      /// </summary>
      public void SetOutputOn(int coilAddress)
      {
         SetOutput(coilAddress, true);
      }

      /// <summary>
      /// Relais AUS
      /// </summary>
      public void SetOutputOff(int coilAddress)
      {
         SetOutput(coilAddress, false);
      }

      /// <summary>
      /// Liest den Zustand eines Relais
      /// </summary>
      public bool GetOutput(int coilAddress)
      {
         if (!IsConnected)
            throw new InvalidOperationException("Nicht verbunden");

         var result = _master.ReadCoils(SlaveId, (ushort)coilAddress, 1);
         return result[0];
      }

      public void Dispose()
      {
         Disconnect();
      }
   }
}
