namespace Aoc2023Day20;

public interface IPulseReceiver
{
    void Receive(Pulse pulse, IPulseReceiver? sender);
}