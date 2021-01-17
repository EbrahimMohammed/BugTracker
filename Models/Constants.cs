namespace BugTracker.Models
{
    public static class StatusName
    {
        
        public const string Pending = "Pending"; 

        public const string Assigned = "Assigned";

        public const string InProgress = "In Progress";

        public const string Fixed = "Fixed";

        public const string Tested = "Tested";

        public const string Closed = "Closed";

        


    }


    public static class TicketTypes
    {

        public const string Bugs = "Bug/Error";

        public const string ChangeRequest = "Change Request";

        public const string NewFunctionality = "New Functionality";
    }



    public static class Priorities
    {
        public const string High = "High";

        public const string Medium = "Medium";

        public const string Low = "Low";


    }


    public static class Roles
    {

        public const string CanManageUsers = "Admin";

        public const string CanManageProjects = "Project Manager";

        public const string CanChangeFixedStated = "Developer";

        public const string CanChangeTestedState = "Tester";



    }
}