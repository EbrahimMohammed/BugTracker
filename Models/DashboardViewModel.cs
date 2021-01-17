namespace BugTracker.Models
{
    public class DashboardViewModel
    {

        public int TotalProjects { get; set; }

        public int ActiveTickets { get; set; }

        public int ClosedTickets { get; set; }

        public int TotalUsers { get; set; }

        public TicketByTypeModel TicketByTypeModel { get; set; }


        public TicketByPriorityModel TicketByPriorityModel { get; set; }


        public TicketByStatusModel TicketByStatusModel { get; set; }

        public UserRolesModel UserRolesModel { get; set; }

    }



    public class TicketByTypeModel
    {
        public int Bugs { get; set; }

        public int ChangeRequests { get; set; }

        public int NewFunctionalities { get; set; }

    }


    public class TicketByPriorityModel {

        public int High { get; set; }

        public int Medium { get; set; }

        public int Low { get; set; }
    }


    public class TicketByStatusModel
    {
        public int Pending { get; set; }

        public int Assigned { get; set; }

        public int Fixed { get; set; }

        public int Tested { get; set; }

        public int Closed { get; set; }

    }


    public class UserRolesModel
    {
        public int AdminsCount { get; set; }

        public int ProjectManagers { get; set; }

        public int TestersCount { get; set; }

        public int DevelopersCount { get; set; }

    }
}