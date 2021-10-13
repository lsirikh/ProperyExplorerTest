using PropertyChanged;
using PropertyExplorerTest.Defines;
using PropertyExplorerTest.Defines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.Models.PropertyModels
{
    public class PropertyContainer : BaseNotifier, IPropertyContainer
    {
        /// <summary>
        /// PropertyName 필드
        /// get Implement
        /// set 부분 설정
        /// </summary>
        public string PropertyName { get; private set; }

        /// <summary>
        /// 검색시 사용할 명칭
        /// </summary>
        public string LowerPropertyName { get; private set; }

        /// <summary>
        /// Show 상태
        /// </summary>
        private bool _isShow;

        [DoNotNotify]
        public bool IsShow
        {
            get { return _isShow; }
            set 
            { 
                _isShow = value;
                this.NofityPropertyChanged();
                this.Set(this.ParentCategory);
            }
        }

        /// <summary>
        /// 실제 속성이 저장되는 값
        /// </summary>
        public IPropertySet Property { get; set; }

        /// <summary>
        /// 해당 속성이 속한 카테고리 값
        /// </summary>
        public IPropertyCategory ParentCategory { get; private set; }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="propertySet">저장 속성 실제 값</param>
        /// <param name="parentCategory">속한 카테고리</param>
        /// <param name="propertyName">속성 명</param>
        public PropertyContainer(IPropertySet propertySet, IPropertyCategory parentCategory, string propertyName = "")
        {
            this.Property = propertySet;
            this.Init(parentCategory, propertyName);
        }

        /// <summary>
        /// 생성시 Init 메소드를 실행하여 초기 세팅을 함
        /// </summary>
        /// <param name="parentCategory"></param>
        /// <param name="propertyName"></param>
        private void Init(IPropertyCategory parentCategory, string propertyName = "")
        {
            //PropertyName이 별도로 세팅되어 있지 않다면, Property의 네임을 가져와 등록
            this.PropertyName = string.IsNullOrWhiteSpace(propertyName) ? this.Property.Name : propertyName;
            //소문자화
            this.LowerPropertyName = this.PropertyName.ToLower();
            //무조건 처음은 보이게
            this.IsShow = true;
            //상위 속성 구분그룹(?) 속성 등록
            this.ParentCategory = parentCategory;

        }
    }
}
