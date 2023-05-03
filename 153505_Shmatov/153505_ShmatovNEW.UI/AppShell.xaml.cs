using _153505_ShmatovNEW.UI.Pages;

namespace _153505_ShmatovNEW.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AuthorsManager), typeof(AuthorsManager));
            Routing.RegisterRoute(nameof(BookDetails), typeof(BookDetails));
            Routing.RegisterRoute(nameof(AddingAuthor), typeof(AddingAuthor));
            Routing.RegisterRoute(nameof(AddingBook), typeof(AddingBook));
            Routing.RegisterRoute(nameof(EditingBook), typeof(EditingBook));

        }
    }
}