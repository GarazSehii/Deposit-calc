using Deposit_calc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Deposit_calc.ViewModels
{
    public class DepositViewModel : INotifyPropertyChanged
    {
        private readonly DepositModel _model;

        private Dictionary<string, double> currencies = new Dictionary<string, double>
        {
            { "USD", 36.21 }, 
            { "EUR", 42.11 }, 
            { "UAH", 1 }   
        };
        public DepositViewModel()
        {
            _model = new DepositModel();
            Currencies = new ObservableCollection<string> { "USD", "EUR", "UAH" };
            SelectedCurrency = Currencies[0];
            Capitalization = true;

        }

        public double DepositAmount
        {
            get => _model.DepositAmount;
            set
            {
                _model.DepositAmount = value;
                OnPropertyChanged();
                CalculateTotalAmount();
            }
        }

        public double AnnualInterestRate
        {
            get => _model.AnnualInterestRate;
            set
            {
                _model.AnnualInterestRate = value;
                OnPropertyChanged();
                CalculateTotalAmount();
            }
        }

        public int DepositTermInMonths
        {
            get => _model.DepositTermInMonths;
            set
            {
                _model.DepositTermInMonths = value;
                OnPropertyChanged();
                CalculateTotalAmount();
            }
        }

        public double InterestRate => _model.InterestRate;

        public string SelectedCurrency
        {
            get => _model.Currency;
            set
            {
                _model.Currency = value;
                OnPropertyChanged();
                CalculateTotalAmount();
            }
        }

        public ObservableCollection<string> Currencies { get; }

        public double TotalAmount
        {
            get => _model.TotalAmount;
            set
            {
                _model.TotalAmount = value;
                OnPropertyChanged();
            }
        }
        public double TotalAmountExchange
        {
            get => _model.TotalAmountExchange;
            set
            {
                _model.TotalAmountExchange = value;
                OnPropertyChanged();
            }
        }
        
        public bool Capitalization
        {
            get => _model.Capitalization;
            set
            {
                _model.Capitalization = value;
                OnPropertyChanged();
                CalculateTotalAmount();
            }
        }

        public void CalculateTotalAmount()
        {
            double currencyExchangeCource = currencies[SelectedCurrency];

            if (Capitalization)
            {
                TotalAmount = DepositAmount * Math.Pow(1 + InterestRate / 100, DepositTermInMonths);
                TotalAmountExchange = TotalAmount * currencyExchangeCource;
            }
            else
            {
                double monthlyPayment = DepositAmount * (InterestRate / 100 / (1 - Math.Pow(1 + InterestRate / 100, -DepositTermInMonths)));
                TotalAmount = monthlyPayment * DepositTermInMonths;
                TotalAmountExchange = TotalAmount * currencyExchangeCource;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
