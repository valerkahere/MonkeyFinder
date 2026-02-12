using MonkeyFinder.Model;
using MonkeyFinder.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MonkeyFinder.ViewModel
{
    public class MonkeyViewModel : BaseViewModel
    {
        public ObservableCollection<Monkey> Monkeys { get; } = new(); // initialized

        public Command GetMonkeysCommand { get; }

        // built-in DI in .NET

        MonkeyService monkeyService;
        public MonkeyViewModel(MonkeyService monkeyService)
        {
            Title = "Monkey Finder";
            this.monkeyService = monkeyService;
            GetMonkeysCommand = new Command(async () => await GetMonkeysAsync());
        }

        // now do sth with the service
        async Task GetMonkeysAsync()
        {
            if (IsBusy)
            {
                return;
            }
            try
            {
                IsBusy = true;

                var monkeys = await monkeyService.GetMonkeys();
                if (Monkeys.Count != 0)
                {
                    Monkeys.Clear();
                }

                foreach (var monkey in monkeys)
                {
                    Monkeys.Add(monkey);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get Monkeys: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

