using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Intertechno.ITGW433Gateway
{
    public enum LetterCodes
    {
        LetterA = 0x0,
        LetterB = 0x1,
        LetterC = 0x2,
        LetterD = 0x3,
        LetterE = 0x4,
        LetterF = 0x5,
        LetterG = 0x6,
        LetterH = 0x7,
        LetterI = 0x8,
        LetterJ = 0x9,
        LetterK = 0xA,
        LetterL = 0xB,
        LetterM = 0xC,
        LetterN = 0xD,
        LetterO = 0xE,
        LetterP = 0xF,
    };

    public enum NumberCodes
    {
        Number1 = 0x0,
        Number2 = 0x1,
        Number3 = 0x2,
        Number4 = 0x3,
        Number5 = 0x4,
        Number6 = 0x5,
        Number7 = 0x6,
        Number8 = 0x7,
        Number9 = 0x8,
        Number10 = 0x9,
        Number11 = 0xA,
        Number12 = 0xB,
        Number13 = 0xC,
        Number14 = 0xD,
        Number15 = 0xE,
        Number16 = 0xF,
    };
    
    public enum ControlCodes
    {
        ControlUp = 0xE,
        ControlDown = 0x6,
    };

    public class CMR500
    {
        private static string startCode = "TXP:0,0,5,11125,89,26,0,";
        private static string endCode = "4,125,0";
        private static string[] numberCodes =
                {
                    //        TRANSMITT CODE STRING:		   //   HEX VALUE
                    "4,12,4,12,4,12,4,12,4,12,4,12,4,12,4,12", //	= 0
                    "4,12,12,4,4,12,4,12,4,12,4,12,4,12,4,12", //	= 1
                    "4,12,4,12,4,12,12,4,4,12,4,12,4,12,4,12", //	= 2
                    "4,12,12,4,4,12,12,4,4,12,4,12,4,12,4,12", //	= 3
                    "4,12,4,12,4,12,4,12,4,12,12,4,4,12,4,12", //	= 4
                    "4,12,12,4,4,12,4,12,4,12,12,4,4,12,4,12", //	= 5
                    "4,12,4,12,4,12,12,4,4,12,12,4,4,12,4,12", //	= 6
                    "4,12,12,4,4,12,12,4,4,12,12,4,4,12,4,12", //	= 7
                    "4,12,4,12,4,12,4,12,4,12,4,12,4,12,12,4", //	= 8
                    "4,12,12,4,4,12,4,12,4,12,4,12,4,12,12,4", //	= 9
                    "4,12,4,12,4,12,12,4,4,12,4,12,4,12,12,4", //	= A
                    "4,12,12,4,4,12,12,4,4,12,4,12,4,12,12,4", //	= B
                    "4,12,4,12,4,12,4,12,4,12,12,4,4,12,12,4", //	= C
                    "4,12,12,4,4,12,4,12,4,12,12,4,4,12,12,4", //	= D
                    "4,12,4,12,4,12,12,4,4,12,12,4,4,12,12,4", //	= E
                    "4,12,12,4,4,12,12,4,4,12,12,4,4,12,12,4", //	= F
                };

        public static string GetCode(LetterCodes letter, NumberCodes number, ControlCodes control)
        {
            return string.Format("{0}{1},{2},{3},{4}", startCode, numberCodes[(int)letter],
                                 numberCodes[(int)number], numberCodes[(int)control], endCode);
        }
        
        public IPEndPoint Gateway;

        public CMR500(IPAddress address)
        {
            Gateway = new IPEndPoint(address, 49880);
        }

        public CMR500(string gatewayIpAddress)
        {
            Gateway = new IPEndPoint(IPAddress.Parse(gatewayIpAddress), 49880);
        }

        public void Send(LetterCodes letter, NumberCodes number, ControlCodes control)
        {
            using (Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                byte[] buffer = Encoding.ASCII.GetBytes(GetCode(letter, number, control));
                sock.SendTo(buffer, Gateway);

            }
        }
    }
}
