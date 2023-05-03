using _153505_Shmatov.Applications.Abstractions;
using _153505_Shmatov.Applications.Services;
using _153505_Shmatov.Domain.Abstractions;
using _153505_Shmatov.Domain.Entities;
using _153505_Shmatov.Persistense.Repository;
using _153505_ShmatovNEW.UI.ViewModels;

namespace _153505_ShmatovNEW.UI.Pages;

public partial class AuthorsManager : ContentPage
{   
    public AuthorsManager(AuthorsViewModel authorsViewModel)
	{
        BindingContext = authorsViewModel;
        InitializeComponent();

    }
}