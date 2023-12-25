namespace Aoc2023Day20;

public class Broadcaster : PulseSender, IPulseReceiver
{
    public Broadcaster(string name) : base(name)
    {
    }

    public IList<IPulseReceiver> Process()
    {
        var pending = new Queue<IPulseReceiver>();
        foreach (var output in _outputs)
            pending.Enqueue(output);

        while (pending.Count > 0)
        {
            var next = pending.Dequeue();

            var nextOutputs = next.Process();

            foreach (var output in nextOutputs)
                pending.Enqueue(output);
        }

        return new List<IPulseReceiver>();
    }

    public void Receive(Pulse pulse, IPulseReceiver? sender)
    {
        SendOthers(pulse);
    }
}
