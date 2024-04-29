using System.ComponentModel;

namespace TaskManager.Enums
{
    public enum TaskStatus
    {
        [Description("To do")]
        ToDo = 1,
        [Description("Tracking")]
        Tracking = 2,
        [Description("Done")]
        Done = 3,
    }
}