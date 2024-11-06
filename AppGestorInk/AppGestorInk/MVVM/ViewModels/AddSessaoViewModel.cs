using AppGestorInk.MVVM.Models;
using AppGestorInk.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace AppGestorInk.MVVM.ViewModels
{
    public partial class AddSessaoViewModel : ObservableObject
    {
        private readonly ISessaoService _sessaoService;

        [ObservableProperty]
        private string _sessaoNome;

        [ObservableProperty]
        private string _clienteNome;

        [ObservableProperty]
        private string _sessaoDescricao;

        [ObservableProperty]
        private DateTime _sessaoDate;

        private FileResult SessaoImage { get; set; }

        // Propriedade para exibir a imagem na interface
        [ObservableProperty]
        private ImageSource _imageSource;

        public DateTime Date { get; set; }

        public AddSessaoViewModel(ISessaoService sessaoService)
        {
            _sessaoService = sessaoService;
            Date = DateTime.Now;
        }

        [RelayCommand]
        private async Task AddSessao()
        {
            try
            {
                if (!string.IsNullOrEmpty(SessaoNome))
                {
                    string imagePath;

                    if (SessaoImage != null)
                    {
                        var targetFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ImagensSessoes");
                        Directory.CreateDirectory(targetFolder);

                        var imageName = $"sessao_{DateTime.Now:yyyyMMddHHmmss}.png";
                        imagePath = Path.Combine(targetFolder, imageName);

                        using (var stream = await SessaoImage.OpenReadAsync())
                        using (var fileStream = File.Create(imagePath))
                        {
                            await stream.CopyToAsync(fileStream);
                        }
                    }
                    else
                    {
                        imagePath = "foto01.png";
                    }

                    Sessao sessao = new()
                    {
                        NomeSessao = SessaoNome,
                        NomeCliente = ClienteNome,
                        Descricao = SessaoDescricao,
                        Data = SessaoDate,
                        statusSessao = StatusSessao.Agendado,
                        Foto = imagePath
                    };

                    await _sessaoService.InitializeAsync();
                    await _sessaoService.AddSessaoAsync(sessao);

                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Informe o nome da sessão", "OK");
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
                SessaoImage = result; // Armazena o FileResult para salvar o arquivo depois

                // Exibe a imagem selecionada no controle de imagem
                var stream = await result.OpenReadAsync();
                ImageSource = ImageSource.FromStream(() => stream);
            }
        }
    }
}
