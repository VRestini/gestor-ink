using AppGestorInk.MVVM.Models;
using AppGestorInk.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppGestorInk.MVVM.ViewModels
{
    [QueryProperty(nameof(Produto), "ProdutoObject")]
    public partial class EditarProdutoViewModel : ObservableObject
    {
        private readonly IProdutoService _produtoService;
        private readonly EstoqueViewModel _estoqueViewModel;
        [ObservableProperty]
        private Produto _produto;
        [ObservableProperty]
        private Boolean _escolha;
        private FileResult ProdutoImage { get; set; }

        // Propriedade para exibir a imagem na interface
        [ObservableProperty]
        private ImageSource _imageSource;
        public EditarProdutoViewModel(IProdutoService produtoService, EstoqueViewModel estoqueViewModel)
        {
            _produtoService = produtoService;
            _estoqueViewModel = estoqueViewModel;
        }
        [RelayCommand]
        private async Task DeleteProduto(Produto produto)
        {
            bool option = await Shell.Current.DisplayAlert("Deletar", "a", "Sim", "Não");
            if (produto == null)
            {
                throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");
            }
            if (option is true)
            {
                try
                {
                    await _produtoService.InitializeAsync();
                    await _produtoService.DeleteProdutoAsync(produto);
                    await Shell.Current.DisplayAlert("Sucesso", "Produto excluido", "ok");
                    await Shell.Current.GoToAsync("..");
                }
                catch
                (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", ex.Message, "ok");
                }
            }
        }
        [RelayCommand]
        private async Task RefreshProduto()
        {
            if (!string.IsNullOrEmpty(Produto.Name))
            {

                try
                {
                    string imagePath = Produto.Foto; // Preserva o caminho atual da imagem

                    if (ProdutoImage != null)
                    {
                        // Atualiza a imagem se o usuário selecionar uma nova
                        var targetFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ImagensProdutos");
                        Directory.CreateDirectory(targetFolder);

                        var imageName = $"produto_{DateTime.Now:yyyyMMddHHmmss}.png";
                        imagePath = Path.Combine(targetFolder, imageName);

                        using (var stream = await ProdutoImage.OpenReadAsync())
                        using (var fileStream = File.Create(imagePath))
                        {
                            await stream.CopyToAsync(fileStream);
                        }
                    }

                    Produto.Foto = imagePath; // Atualiza o caminho da foto na sessão

                    await _produtoService.InitializeAsync();
                    await _produtoService.RefreshProdutoAsync(Produto); // Atualiza a sessão no banco de dados

                    await Shell.Current.GoToAsync(".."); // Volta para a página anterior após a edição
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Produto sem nome", "OK");
            }
        }
        [RelayCommand]
        public async Task SelecionarImagem()
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Selecione uma imagem"
            });

            if (result != null)
            {
                ProdutoImage = result; // Armazena o FileResult para salvar o arquivo depois

                // Exibe a imagem selecionada no controle de imagem
                var stream = await result.OpenReadAsync();
                ImageSource = ImageSource.FromStream(() => stream);
            }
        }
    }
}
