using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopList.Gui.Models;
//using System;
//using System.Collections.Generic;
using System.Collections.ObjectModel;
/*using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;*/

namespace ShopList.Gui.ViewModels
{


    public partial class ShopListViewModel : ObservableObject 

    {

        [ObservableProperty]
        private string _nombreDelArticulo = string.Empty;
        [ObservableProperty]
        private int _cantidadAComprar = 1;



        public ObservableCollection<Item> Items { get; }


       



        public ShopListViewModel()
        {
            Items = new ObservableCollection<Item>();
            CargarDatos();
            //AgregarShopListItemCommand = new Command(AgregarShopListItem);
        }

        [RelayCommand]

        public void AgregarShopListItem()
        {
            if (string.IsNullOrEmpty(NombreDelArticulo) || CantidadAComprar <= 0)
            {
                return;
            }

            Random generador = new Random();    

            var item = new Item
            {
                Id =generador.Next(),
                Nombre = NombreDelArticulo,
                Cantidad = CantidadAComprar,
                Comprado =false,
            };

            Items.Add(item);
            NombreDelArticulo= string.Empty;
            CantidadAComprar = 1;
        }

        [RelayCommand]
        public void EliminarShopList()
        {

        }


        private void CargarDatos()
        {

            Items.Add(new Item()
            {
                Id = 1,
                Nombre = "LECHE",
                Cantidad = 2,
                Comprado = false,
            });

            Items.Add(new Item()
            {
                Id = 2,
                Nombre = "PAN DE CAJA",
                Cantidad = 2,
                Comprado = false,
            });

            Items.Add(new Item()
            {
                Id = 3,
                Nombre = "JAMON",
                Cantidad = 2,
                Comprado = false,
            });
        }


    }
}
