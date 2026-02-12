using MonkeyFinder.ViewModel;
namespace MonkeyFinder.View
{
    public partial class MainPage : ContentPage
    {
        // DI
        public MainPage(MonkeyViewModel monkeysViewModel)
        {
            InitializeComponent();

            BindingContext = monkeysViewModel;
        }

    }
}



