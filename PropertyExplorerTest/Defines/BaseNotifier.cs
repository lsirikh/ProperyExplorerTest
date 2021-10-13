using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PropertyExplorerTest.Defines
{
    //[ImplementPropertyChanged] 사용 할 수 없음. Deprecated
    public class BaseNotifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 일종의 PropertyChange를 통한 갱신?...
        /// CallerMemberName을 사용하면 이 함수를 호출한 대상에 대한 이름을 인자로 받게됨
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NofityPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.FireNotification(this, propertyName);
        }

        /// <summary>
        /// 실질적으로 PropertyChanged 이벤트를 Invoke 시키는 Method이다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="propertyName"></param>
        private void FireNotification(object sender, string propertyName)
        {
            this.PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// BaseNotifier에서 Set을 통해서 PropertyChange를 변경 등록할 수 있다. 보통은 
        /// ex. handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        /// this 대신에 유니버셜하게 사용할 수 있다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="propertyName"></param>
        protected void Set(object sender, [CallerMemberName] string propertyName = "")
        {
            this.FireNotification(sender, propertyName);
        }

        /// <summary>
        /// 기존의 field의 값과 newValue의 값을 비교해서, 차이가 있으면
        /// propertyName을 갖고 최종적으로 PropertyChanged?.Invoke 작업을 수행함.
        /// </summary>
        /// <typeparam name="T">Generic 타입</typeparam>
        /// <param name="field">기존 데이터</param>
        /// <param name="newValue">새로 변경되었거나 이벤트시 입력된 데이터</param>
        /// <param name="propertyName">의존속성(xaml)에 연결할 명사적 단어 혹은 명칭</param>
        protected void SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return;
            }

            field = newValue;

            this.NofityPropertyChanged(propertyName);
        }
    }
}
