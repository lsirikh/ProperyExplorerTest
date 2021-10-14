using GalaSoft.MvvmLight.Command;
using PropertyExplorerTest.Defines.Interfaces;
using PropertyExplorerTest.Models;
using PropertyExplorerTest.ViewModels.Shapes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PropertyExplorerTest.ViewModels
{
    /// <summary>
    /// Views > MainContainer.xaml에서 사용되는 ViewModel
    /// </summary>
    public class MainContainerViewModel : BaseViewModel
    {
        /// <summary>
        /// Model선택을 위한 RelayCommand 변수이며 타입은 IPropertyOperative
        /// 인터페이스 타입을 받는다.
        /// </summary>
        //private RelayCommand<IPropertyOperative> _selectModelCommand;

        /// <summary>
        /// 바인딩된 Command를 통해 SelectModelCommand가 수행되면 아래
        /// Command Method가 수행되고 Callback Method인 SelectModel이 수행된다.
        /// </summary>
        public ICommand SelectModelCommand => new RelayCommand<IPropertyOperative>(
                execute: SelectModel,
                canExecute: CanExecuteSelectModel);

        /*
         * # isPropertyCommandExecuted는 아래와 같이 동작한다.
         * 1. Shape의 속성(Property)를 클릭하면, true로 전환
         * 2. 다른 Shape을 클릭하여도, true로 유지
         * 3. 바탕화면을 클릭하면 false로 전환
         */

        private bool isPropertyCommandExecuted = false;

        private ICommand _createCircleCommand;

        public ICommand CreateCircleCommand
        {
            get 
            {
                return _createCircleCommand ?? (_createCircleCommand = new RelayCommand<Object>(
                execute: CreateCircleCmd,
                canExecute: CanCreateCircleCmd)
                );
            }
            //set { _testCommand = value; }
        }

        public bool CanCreateCircleCmd(Object arg)
        {
            Debug.WriteLine($">>>>>>>>>({arg.ToString()})CanCreateCircleCmd<<<<<<<<<<<<");
            return true;
        }

        public void CreateCircleCmd(Object arg)
        {
            var ellipseModel = new EllipseModel();
            this.Items.Add(new EllipseViewModel(ellipseModel));
        }

        /// <summary>
        /// ItemControl의 ItemSource로 활용되는 ObservableCollection 변수이다.
        /// BaseShapeViewModel의 Get할때, 새로운 인스턴스로 넘긴다.
        /// </summary>
        public ObservableCollection<BaseShapeViewModel> Items { get; } = new ObservableCollection<BaseShapeViewModel>();

        private BaseShapeViewModel _selectedShape;

        public BaseShapeViewModel SelectedShape
        {
            get => _selectedShape;
            set
            {
                //_selectedShape 갱신 및 이 메소드의 Initializer 역할
                this.SetProperty(ref this._selectedShape, value);

                //_selectedShape이 null이면, PropertyExplorer를 닫아준다.
                //그리고, isPropertyCommandExecuted의 속성도 false가 된다.
                //당연히 창이 닫혔는데 isPropertyCommandExecuted가 참 일 수 없다.
                if (_selectedShape == null)
                {
                    this.SetProperty(ref this._isPropertyShow, false, "IsPropertyShow");
                    isPropertyCommandExecuted = false;
                }

                //_selectedShape의 갱신 후,
                //PropertyCommand가 실행된 상태, 즉 isPropertyCommandExecuted가
                //true면 PropertyExplorer를 갱신해주기 위한 업데이트 메소드 수행
                if (isPropertyCommandExecuted)
                    this.SelectModel(this._selectedShape);

                Debug.WriteLine($"SelectedShape: {_selectedShape}");
                //this.SelectModel(this._selectedShape);
            }
        }

        //Visibility
        private bool _isPropertyShow;

        public bool IsPropertyShow
        {
            get => _isPropertyShow; 
            set 
            {
                this.SetProperty(ref this._isPropertyShow, value);
                Debug.WriteLine($"IsPropertyShow: {_isPropertyShow}");
            }
        }


        //this._selectModelCommand ?? (this._selectModelCommand = new RelayCommand<IPropertyOperative>(this.SelectModel));

        /// <summary>
        /// PropertyExplorer 인스턴스 생성 및 초기화
        /// </summary>
        public PropertyExplorerViewModel PropertyExplorer { get; set; } = new PropertyExplorerViewModel();

        
        /// <summary>
        /// 생성자를 통한 초기화
        /// 사각형, 타원(원), 선을 초기에 등록한다.
        /// </summary>
        public MainContainerViewModel()
        {
            //SelectModelCommand = this._selectModelCommand ?? (this._selectModelCommand = new RelayCommand<IPropertyOperative>(this.SelectModel));
            //SelectModelCommand = new SelectItemCommand<IPropertyOperative>(this);

            Random rand = new Random();
            var min = 1;
            var max = 600;
            var rectModel = new RectModel((double)rand.Next(min, max), (double)rand.Next(min, max));
            var ellipseModel = new EllipseModel((double)rand.Next(min, max), (double)rand.Next(min, max));
            var lineModel = new LineModel((double)rand.Next(min, max), (double)rand.Next(min, max));
            var lineModel1 = new LineModel((double)rand.Next(min, max), (double)rand.Next(min, max));
            this.Items.Add(new RectViewModel(rectModel));
            this.Items.Add(new EllipseViewModel(ellipseModel));
            this.Items.Add(new LineViewModel(lineModel));
            this.Items.Add(new LineViewModel(lineModel1));


        }
        
        /// <summary>
        /// SelectModel을 검증하기 위한 CanExecuteSelectModel,
        /// arg 즉 model의 내용이 null이면,
        /// SubMenu의 Property의 내용은 비활성화된다.
        /// Vice versa...
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool CanExecuteSelectModel(IPropertyOperative arg)
        {
            if (arg != null)
                return true;
            else
                return false;
        }

                
        /// <summary>
        /// Model 선택에 따른 해당 모델에 설정된 속성 정보를 
        /// Property를 PropertyChange를 위한 목록에 등록하는 과정
        /// </summary>
        /// <param name="model"></param>
        public void SelectModel(IPropertyOperative model)
        {
            Debug.WriteLine("SelectModel method was executed.");
            if (model != null)
            {
                isPropertyCommandExecuted = true;
                this.SetProperty(ref this._isPropertyShow, true, "IsPropertyShow");
                this.PropertyExplorer.SelectModel(model);
            }
        }
    }
}
