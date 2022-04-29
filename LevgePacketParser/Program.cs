// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Started");

var rawPacketsLines = File.ReadAllLines("sampleClientTcp.txt");

int intValue = 763;
byte[] intBytes = BitConverter.GetBytes(intValue);
Array.Reverse(intBytes);
byte[] result = intBytes;
Console.WriteLine(BAT(result));

foreach (var rawPacketLine in rawPacketsLines)
{
    var lineData = Encoding.UTF8.GetBytes(rawPacketLine);

    Console.Write("PacketId: ");
    Console.Write(BATS(lineData.Take(4).ToArray()[0]));

    Console.Write(" Status: ");
    Console.Write(TOS(lineData.Skip(4).Take(2).ToArray()));

    if (lineData.Length > 6)
    {
        Console.Write(" X: ");
        Console.Write(String.Format("{0:n0}", TOI(lineData.Skip(6).Take(8).ToArray())));

        Console.Write(" X: ");
        Console.Write(String.Format("{0:n0}", TOI(lineData.Skip(14).Take(8).ToArray())));

        //Console.Write(" Z: ");
        //Console.Write(TOF(lineData.Skip(24).Take(8).ToArray()));
    }
    Console.WriteLine("");

}





ConsoleKeyInfo cki;

Console.WriteLine("Press the Escape (Esc) key to quit: \n");
do
{
    cki = Console.ReadKey();
    // do something with each key press until escape key is pressed
} while (cki.Key != ConsoleKey.Escape);





string BAT(IEnumerable<byte> ba)
{
    return BitConverter.ToString(ba.ToArray()).Replace("-", "");
}

string BATS(byte ba)
{
    byte[] byteArray = { ba };
    return BitConverter.ToString(byteArray).Replace("-", "");
}

float TOF(IEnumerable<byte> ba)
{
    return BitConverter.ToSingle(ba.ToArray(), 0);
}

bool TOB(IEnumerable<byte> ba)
{
    return BitConverter.ToBoolean(ba.ToArray(), 0);
}

double TOD(IEnumerable<byte> ba)
{
    return BitConverter.ToDouble(ba.ToArray());
}

string TOS(IEnumerable<byte> ba)
{
    return BitConverter.ToString(ba.ToArray(), 0).Replace("-", "");
}

int TOI(IEnumerable<byte> ba)
{
    return BitConverter.ToInt32(ba.ToArray(), 0);
}