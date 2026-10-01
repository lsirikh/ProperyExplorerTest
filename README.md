# WPF Property Explorer Test

Canvas 위 도형을 선택·이동하고 속성 편집 UI와 연결하는 WPF 실험 프로젝트입니다. 도형별 ViewModel과 화면 동작을 분리합니다.

## 구성

- [PropertyExplorerTest/ViewModels](PropertyExplorerTest/ViewModels): 속성 편집과 도형 상태
- [PropertyExplorerTest/Controls](PropertyExplorerTest/Controls): 도형 이동·표시 컨트롤
- [PropertyExplorerTest/Converters](PropertyExplorerTest/Converters): 화면 값 변환
- [PropertyExplorerTest.sln](PropertyExplorerTest.sln): 솔루션

## 개발 환경

Windows / .NET Framework 4.8 / WPF를 사용합니다. Extended.Wpf.Toolkit, MvvmLight, PropertyChanged.Fody와 Behaviors 관련 NuGet 패키지를 복원한 뒤 실행합니다.

편집기 UI를 실험하는 예제이며 완성된 범용 CAD 또는 지도 편집 제품은 아닙니다. 저장소 이름의 `Propery` 표기는 기존 이름을 유지합니다.
