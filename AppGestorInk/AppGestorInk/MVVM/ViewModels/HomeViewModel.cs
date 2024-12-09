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
        private bool isPopupOpen = false;
        public readonly IServiceItem _serviceItem;
        public readonly ISessaoService _sessaoService;

        public ObservableCollection<ItemProduto> vencimentoTotalList { get; set; } = new();
        public ObservableCollection<Sessao> sessaoList { get; set; } = new();
        public ObservableCollection<Sessao> sessaoListByDate { get; set; } = new();
        [ObservableProperty]
        private ObservableCollection<Aviso> _avisos = new();
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
            GetAvisos();

        }
        [RelayCommand]
        public async Task AtualizarData()
        {
            dateTime = DateTime.Now;
        }
        [RelayCommand]

        public async Task GetAvisos()
        {
            await _serviceItem.InitializeAsync();
            var itens = await _serviceItem.GetItemProdutoAsync();
            vencimentoTotalList.Clear();
            foreach (var item in itens)
            {
                if (item.DataValidade.Date <= DateTime.Now.AddDays(10) && item.DataValidade.Date >= DateTime.Now.Date)
                {
                    vencimentoTotalList.Add(item);
                }
            }
            var itensValidados = vencimentoTotalList
                .GroupBy(item => item.Name)
                .Select(group => new Aviso
                {
                    Id = group.First().Id,
                    Name = group.Key,
                    Qtd = group.Count()
                })
                .ToList();
            _avisos.Clear();
            foreach (var aviso in itensValidados)
            {
                _avisos.Add(aviso);
            }
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
        public void OpenPopup()
        {
            popup.Show();
        }

        [RelayCommand]
        public void ClosePopup()
        {
            IsPopupOpen = false;
        }
    }
}