using System.Runtime.InteropServices;

namespace BugTracker.Core.Domain
{
    public class Priority: BaseEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }

    }
}