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
