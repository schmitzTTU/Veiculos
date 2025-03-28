namespace VeiculoAlertasMVVMApp.ViewModels;

using System.ComponentModel;

using System.Windows.Input;
public class VeiculoViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged; private string marca; public string Marca { get => marca; set { marca = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Marca))); } }
    private string modelo; public string Modelo { get => modelo; set { modelo = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Modelo))); } }
    public ICommand ExibirDetalhesCommand { get; }
    public VeiculoViewModel() { ExibirDetalhesCommand = new Command(ExibirDetalhes); }
    private void ExibirDetalhes()
    {
        if (string.IsNullOrWhiteSpace(Marca) || string.IsNullOrWhiteSpace(Modelo)) { Application.Current.MainPage.DisplayAlert("Erro", "Preencha marca e modelo.", "OK"); return; }

        Application.Current.MainPage.DisplayAlert("Detalhes", $"Marca: {Marca}\nModelo: {Modelo}", "OK");
    }
}