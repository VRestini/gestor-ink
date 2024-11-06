using AppGestorInk.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppGestorInk.MVVM.Models;

namespace AppGestorInk.MVVM.ViewModels
{
    public partial class AddProdutoViewModel : ObservableObject
    {
        private readonly IProdutoService _produtoService;
        [ObservableProperty]
        public string _produtoName;
        [ObservableProperty]
        public string _produtoDescricao;
        [ObservableProperty]
        private ImageSource _imageSource;
        private FileResult ProdutoImage { get; set; }
        public AddProdutoViewModel(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        
        
        [RelayCommand]
        private async Task AddProduto()
        {
            try
            {
                if (!string.IsNullOrEmpty(ProdutoName)) // verifica se o nome foi informado
                {
                    string imagePath;

                    if (ProdutoImage != null)
                    {
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
                    else
                    {
                        imagePath = "foto01.png";
                    }
                    Produto produto = new()
                    {
                        Name = ProdutoName,
                        Descricao = ProdutoDescricao,
                        Foto = imagePath
                    };
                    await _produtoService.InitializeAsync();
                    await _produtoService.AddProdutoAsync(produto);

                    await Shell.Current.GoToAsync(".."); // voltar para a página anterior
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Livro sem Título", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
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
