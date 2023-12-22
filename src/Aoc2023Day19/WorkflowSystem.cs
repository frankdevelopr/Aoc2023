
namespace Aoc2023Day19;

public class WorkflowSystem
{
    private const string Accepted = "A";
    private const string Rejected = "R";

    public Dictionary<string, Workflow> Workflows { get; }

    public WorkflowSystem(IEnumerable<Workflow> workflows)
    {
        Workflows = workflows.ToDictionary(w => w.Name);
    }

    public bool Eval(Part part)
    {
        var workflowName = "in";

        do
        {
            var workflow = Workflows[workflowName];
            workflowName = workflow.Eval(part);
        } while (!IsEnd(workflowName));

        return workflowName == Accepted;
    }

    private bool IsEnd(string name)
    {
        return name == Rejected || name == Accepted;
    }
}