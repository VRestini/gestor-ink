using AppGestorInk.MVVM.Models;
using AppGestorInk.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AppGestorInk.MVVM.ViewModels
{
    [QueryProperty(nameof(Sessao), "SessaoObject")]
    public partial class EditarSessaoViewModel : ObservableObject
    {
        private readonly ISessaoService _sessaoService;
        private readonly AgendaViewModel _agendaViewModel;

        [ObservableProperty]
        private Sessao _sessao;

        [ObservableProperty]
        public DateTime _dataAtual;

        private FileResult SessaoImage { get; set; }

        // Propriedade para exibir a imagem na interface
        [ObservableProperty]
        private ImageSource _imageSource;

        public EditarSessaoViewModel(ISessaoService sessaoService, AgendaViewModel agendaViewModel)
        {
            _sessaoService = sessaoService;
            _agendaViewModel = agendaViewModel;
            DataAtual = DateTime.Now;

            // Carrega a imagem atual da sessão
            if (!string.IsNullOrEmpty(Sessao?.Foto))
            {
                ImageSource = ImageSource.FromFile(Sessao.Foto);
            }
        }

        [RelayCommand]
        private async Task UpdateSessao()
        {
            if (!string.IsNullOrEmpty(Sessao.NomeSessao))
            {
                try
                {
                    string imagePath = Sessao.Foto; // Preserva o caminho atual da imagem

                    if (SessaoImage != null)
                    {
                        // Atualiza a imagem se o usuário selecionar uma nova
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

                    Sessao.Foto = imagePath; // Atualiza o caminho da foto na sessão

                    await _sessaoService.InitializeAsync();
                    await _sessaoService.UpdateSessaoAsync(Sessao); // Atualiza a sessão no banco de dados

                    await Shell.Current.GoToAsync(".."); // Volta para a página anterior após a edição
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Erro", "Nome da Sessão não pode ser vazio", "OK");
            }
        }

        [RelayCommand]
        private async Task DeleteSessao()
        {
            bool option = await Shell.Current.DisplayAlert("Deletar Sessão", "Tem certeza que deseja deletar esta sessão?", "Sim", "Não");
            if (option)
            {
                try
                {
                    await _sessaoService.InitializeAsync();
                    await _sessaoService.DeleteSessaoAsync(Sessao); // Deleta a sessão no banco de dados

                    await Shell.Current.DisplayAlert("Sucesso", "Sessão excluída", "OK");
                    await Shell.Current.GoToAsync(".."); // Volta para a página anterior após a exclusão
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
                }
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
