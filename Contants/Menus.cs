using System.Collections.Generic;

namespace BugTracker.Contants
{
    public static class Menus
    {
        public static readonly IDictionary<string, string> controllers = new Dictionary<string, string>()
        {
            { "dashboard", "More"},
            { "ui", "UI Elements" },
            { "icon", "Icons" },
            { "forms", "Forms" },
            { "table", "Tables" },
            { "maps", "Maps" },
            { "chart", "Charts" },
            { "email", "Email" },
            { "pages", "Pages" },
            {"project", "Project"}
        };

        public static readonly IDictionary<string, string> actions = new Dictionary<string, string>()
        {
            { "inbox", "Inbox" },
            { "email", "Email Read" },
            { "read", "Email Read" },
            { "compose", "Email Compose" },

            { "alerts", "Alerts" },
            { "buttons", "Buttons" },
            { "badges", "Badge" },
            { "cards", "Cards" },
            { "carousels", "Carousel" },
            { "dropdowns", "Dropdowns" },
            { "grid", "Grid" },
            { "images", "Images" },            
            { "lightbox", "Lightbox" },
            { "modals", "Modals" },
            { "pagination", "Pagination" },
            { "popovertooltips", "Popover & Tooltips" },
            { "progressbars", "Progress Bars" },
            { "sweetalerts", "Sweet-Alert" },
            { "tabaccordions", "Tabs & Accordions" },
            { "typography", "Typography" },
            { "video", "Video" },

            { "elements", "Forms Elements" },
            { "validation", "Forms Validation" },
            { "advanced", "Forms Advanced" },
            { "editors", "Form Editors" },
            { "uploads", "Form Upload" },
            { "xeditable", "Form Xeditable" },
                
            { "material", "Material Design" },
            { "ion", "Ion Icons" },
            { "fontawesome", "Font Awesome" },
            { "themify", "Themify Icons" },
            { "dripicons", "Dripicons" },
            { "typicons", "Typicons" },

            { "morris", "Morris Chart" },
            { "chartist", "Chartist Chart" },
            { "chartjs", "Chartjs" },
            { "flot", "Flot Chart" },
            { "c3", "C3 Chart" },
            { "other", "Jquery Knob Chart" },

            { "timeline", "Timeline" },
            { "invoice", "Invoice" },
            { "directory", "Directory" },

            { "rangeslider", "Range Slider" },
            { "sessiontimeout", "Session Timeout" },

            { "calendar", "Calendar" },

            { "basic", "Basic Tables" },
            { "datatable", "Data Tables" },
            { "responsive", "Responsive Tables" },
            { "editable", "Editable Tables" },
            { "google", "Google Maps" },
            { "vector", "Vector Maps" },

            {"project", "Projects"},

            { "blank", "Blank page"}
        };
    }
}