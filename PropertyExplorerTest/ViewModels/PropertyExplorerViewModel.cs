using GalaSoft.MvvmLight.Command;
using PropertyExplorerTest.Defines.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PropertyExplorerTest.ViewModels
{
    public class PropertyExplorerViewModel : BaseViewModel
    {
        /// <summary>
        /// _searchCommand를 RelayCommand로 설정한다.
        /// </summary>
        private RelayCommand _searchCommand;

        /// <summary>
        /// IPropertyCategory는 Catergory가 참조하는 인터페이스로 
        /// </summary>
        public ObservableCollection<IPropertyCategory> Categories { get; } = new ObservableCollection<IPropertyCategory>();

        /// <summary>
        /// 
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// SearchCommand가 Binding된 View에서 호출이 되면,
        /// this._searchCommand가 null이 아니면,
        /// 새로운 RelayCommand로 excute는 SearchProperty로 설정한다. 
        /// </summary>
        public ICommand SearchCommand => this._searchCommand ?? (this._searchCommand = new RelayCommand(this.SearchProperty));

        /// <summary>
        /// 
        /// </summary>
        private void SearchProperty()
        {
            foreach (var category in this.Categories)
            {
                foreach (var container in category.Properties)
                {
                    container.IsShow = container.LowerPropertyName.Contains(this.SearchText.ToLower());
                }
            }

            foreach (var category in this.Categories)
            {
                this.Set(category, "IsShow");
            }
        }

        public void SelectModel(IPropertyOperative properties)
        {
            foreach (var category in this.Categories)
            {
                foreach (var container in category.Properties)
                {
                    container.IsShow = true;
                }
            }

            this.Categories.Clear();

            if (properties == null)
            {
                return;
            }

            foreach (var category in properties.GetCategories())
            {
                //GetCategories에서 카테고리 리스트를 가져오고
                //category는 단일 PropertyCategory를 가져옴
                //그리고 ObservableCollection<IPropertyCategory>타입에
                //담아준다.
                this.Categories.Add(category);
            }
        }
    }
}
