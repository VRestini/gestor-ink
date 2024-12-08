using AppGestorInk.MVVM.Models;
using AppGestorInk.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Syncfusion.Maui.Popup;
using System.ComponentModel;
using AppGestorInk.MVVM.Views;

namespace AppGestorInk.MVVM.ViewModels
{
    public partial class HomeViewModel : ObservableObject, INotifyPropertyChanged
    {
        SfPopup popup;
        [ObservableProperty]
        private Sessao _selectedSessao;
        [ObservableProperty]
        private bool isPopupOpen;
        public readonly IServiceItem _serviceItem;
        public readonly ISessaoService _sessaoService;
        public ObservableCollection<Sessao> sessaoList { get; set; } = new();
        public ObservableCollection<Sessao> sessaoListByDate { get; set; } = new();
        [ObservableProperty]
        private ObservableCollection<string> _imagePaths = new();
        [ObservableProperty]
        private string _selectedImagePath;
        [ObservableProperty]
        public DateTime dateTime;
        public HomeViewModel(IServiceItem serviceItem, ISessaoService sessaoService)
        {
            _serviceItem = serviceItem;
            _sessaoService = sessaoService;
            AtualizarData();
            GetSessoesHome();

            
        }
        [RelayCommand]
        public async Task AtualizarData()
        {
            dateTime = DateTime.Now;
        }

        public async Task GetAvisos()
        {
            await _serviceItem.InitializeAsync();
            var itens = await _serviceItem.GetItemProdutoAsync();
           
        }
        [RelayCommand]
        public async Task GetSessoesHome()
        {
            await _sessaoService.InitializeAsync();

            var sessoes = await _sessaoService.GetAllSessoesAsync();
            foreach (var sessao in sessoes)
            {
                sessaoList.Add(sessao);
            }
            var sessoesFiltradas = sessoes.Where(x => x.Data.Date == DateTime.Now.Date).ToList().OrderBy(x => x.Data);
            sessaoListByDate.Clear();
            ImagePaths.Clear();
            foreach (var sessao in sessoesFiltradas)
            {
                sessaoListByDate.Add(sessao);
                ImagePaths.Add(sessao.Foto);
            }
        }
       
        [RelayCommand]
        public void OpenPopup(string imageSource)
        {
            // Encontrar a sessão correspondente à imagem clicada
            SelectedSessao = sessaoList.FirstOrDefault(sessao => sessao.Foto == imageSource);

            if (SelectedSessao != null)
            {
                IsPopupOpen = true;
            }
        }

        [RelayCommand]
        public void ClosePopup()
        {
            IsPopupOpen = false;
        }
    }
}
