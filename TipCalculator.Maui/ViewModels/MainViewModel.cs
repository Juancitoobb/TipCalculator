using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TipCalculator.Maui.Models;

namespace TipCalculator.Maui.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private ConsumoCompartido _consumo;

        [ObservableProperty]
        private string _importeDelConsumo = string.Empty;

        [ObservableProperty]
        private string _numeroDePersonas = string.Empty;

        [ObservableProperty]
        private string _procentajeDePropina = string.Empty;

        [ObservableProperty]
        private string _importeConsumoPorPersona = string.Empty;

        [ObservableProperty]
        private string _importePropina = string.Empty;

        [ObservableProperty]
        private string _importePropinaPorPeronsa = string.Empty;

        [ObservableProperty]
        private string _importeConsumoConPropina = string.Empty;

        [ObservableProperty]
        private string _importeConsumoConPropinaPorPersona = string.Empty;
        public MainViewModel()
        {
            _consumo = new ConsumoCompartido(0.0m, 10.0m);
            //CalcularCommand = new Command(CalcularPropina);
            //LimpiarCommand = new Command(LimpiarDatos);
            //PorcentajeDePropinaCommand = new Command<string>(ActulizarPorcentajeDePropina);
        }

        [RelayCommand]
        private void Calcular()
        {
            bool consumoEsValido = false;
            bool numeroDePersonasEsValido = false;
            bool porcentajeDePropinasEsValido = false;
            decimal importeDelConsumo;
            int numeroDePersonas;
            decimal porcenjeDePropina;
            consumoEsValido = decimal.TryParse(ImporteDelConsumo, out importeDelConsumo);
            numeroDePersonasEsValido = int.TryParse(NumeroDePersonas, out numeroDePersonas);
            porcentajeDePropinasEsValido = decimal.TryParse(PorcentajeDePropina, out porcenjeDePropina);
            if (consumoEsValido && numeroDePersonasEsValido && porcentajeDePropinasEsValido)
            {
                _consumo = new ConsumoCompartido(importeDelConsumo, porcenjeDePropina, numeroDePersonas);
                //ImporteDelConsumo = _consumo.ImporteDelConsumo.ToString("F2");
                ImporteConsumoPorPersona = _consumo.ImporteDelConsumoPorPersona.ToString("F2");
                ImportePropina = _consumo.ImporteDePropinas.ToString("F2");
                ImportePropinaPorPersona = _consumo.ImportePropinaPorPersona.ToString("F2");
                ImporteConsumoConPropina = _consumo.ImporteDelConsumoConPropina.ToString("F2");
                ImporteConsumoConPropinaPorPersona = _consumo.ImporteDelConsumoConPropinaPorPersona.ToString("F2");
            }

        }

        [RelayCommand]
        private void Limpiar()
        {
            ImporteDelConsumo = string.Empty;
            NumeroDePersonas = string.Empty;
            PorcentajeDePropina = string.Empty;
            ImporteConsumoPorPersona = string.Empty;
            ImportePropina = string.Empty;
            ImportePropinaPorPersona = string.Empty;
            ImporteConsumoConPropina = string.Empty;
            ImporteConsumoConPropinaPorPersona = string.Empty;
        }

        [RelayCommand]
        private void ActulizarPorcentajeDePropina(string numeroPorcentaje)
        {
            PorcentajeDePropina = numeroPorcentaje;
        }
    }
}
