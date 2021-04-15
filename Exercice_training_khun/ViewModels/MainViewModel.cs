using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using ToolBox.MVVM.Base;
using ToolBox.MVVM.Commands;

namespace Exercice_training_khun.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string _entry;

        public string Entry
        {
            get
            {
                return _entry;
            }

            set
            {
                _entry = value;
                OnPropertyChanged();
                //prévenir le bouton que mon entry a changé et qu'il doit se mettre à jour
                AddCommand.OnCanExecuteChanged();
            }
        }

        private ObservableCollection<string> _list;

        public ObservableCollection<string> List
        {
            get { return _list; }
            set { _list = value; OnPropertyChanged(); }
        }


        public CommandBase AddCommand { get; set; }


        public MainViewModel()
        {

            AddCommand = new CommandBase(Add,CanAdd);
            List = new ObservableCollection<string>() { "Fulcrum ", "Obiwan Kenobi", "Ahsoka tano" };
        }

        private void Add()
        {
            List.Add(Entry);
            //permet de vider le textBox , uniquement si on retrouve la methode OnPropertyChanged() au niveau du entry.
            Entry = null;
        }
        
        private bool CanAdd()
        {
            return !string.IsNullOrEmpty(Entry);
        }
        

    }
}
