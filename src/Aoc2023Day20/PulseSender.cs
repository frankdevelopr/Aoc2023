using System.Diagnostics;

namespace Aoc2023Day20;

public abstract class PulseSender
{
    protected readonly List<IPulseReceiver> _outputs = new();

    public string Name { get; protected set; }
    public Queue<Pulse> PendingPulses { get; }

    protected PulseSender(string name)
    {
        Name = name;
        PendingPulses = new Queue<Pulse>();
    }

    public void Receive(Pulse pulse)
    {
        PendingPulses.Enqueue(pulse);
    }

    public PulseSender Connect(IPulseReceiver module)
    {
        _outputs.Add(module);

        return this;
    }

    public void SendOthers(Pulse pulse)
    {
        foreach(var module in _outputs)
        {
            Debug.WriteLine($"{Name} -{pulse.ToString()}-> {module.Name}");

            module.Receive(pulse, this as IPulseReceiver);
        }

        foreach (var module in _outputs)
        {
            module.Process();
        }
    }
}
