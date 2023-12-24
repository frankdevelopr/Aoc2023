namespace Aoc2023Day20;

public interface IPulseReceiver
{
    string Name { get;}
    void Receive(Pulse pulse, IPulseReceiver? sender);
    void Process();
}