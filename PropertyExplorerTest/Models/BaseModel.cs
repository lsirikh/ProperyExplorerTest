using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PropertyExplorerTest.Models
{
    public class BaseModel
    {
        /// <summary>
        /// 아이디
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// 명칭
        /// </summary>
        public string Name { get; set; } = "Untitled";

        /// <summary>
        /// 제목 숨김/표지용
        /// </summary>
        public bool IsNameShow { get; set; } = true;

        /// <summary>
        /// 맵아이디
        /// </summary>
        public int MapId { get; set; } = 1;

        /// <summary>
        /// 소속 그룹
        /// </summary>
        public int Group { get; set; } = 1;

        /// <summary>
        /// 레이어 높이
        /// </summary>
        public int ZLevel { get; set; } = 1;

        /// <summary>
        /// 넓이 Width
        /// </summary>
        public double Width { get; set; } = 100;

        /// <summary>
        /// 높이 Height
        /// </summary>
        public double Height { get; set; } = 100;

        /// <summary>
        /// 좌표정보 X
        /// Canvas에 붙일 때 사용된다.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// 좌표정보 X
        /// Canvas에 붙일 때 사용된다.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// 위치 정보 숨김/표시 용
        /// </summary>
        public bool isLocationShow { get; set; } = true;

        /// <summary>
        /// FillColor 도형 내부의 컬러
        /// </summary>
        public Color FillColor { get; set; } = Color.FromRgb(0xff, 0x00, 0x00);

        /// <summary>
        /// 도형 선의 색깔
        /// </summary>
        public Color BorderColor { get; set; } = Color.FromRgb(0x24, 0x00, 0xff);

        /// <summary>
        /// 도형 선의 두께
        /// </summary>
        public double BorderThickness { get; set; } = 1;

        /// <summary>
        /// 마우스 팝업 설명을 위한 Tooltip
        /// </summary>
        public string ToolTip { get; set; }

        #region 생성자 및 생성자 오버라이드

        public BaseModel()
        {
        }

        /// <summary>
        /// 생성자 오버라이드 param 2개
        /// </summary>
        /// <param name="x">좌표정보 X</param>
        /// <param name="y">좌표정보 Y</param>
        public BaseModel(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// 생성자 오버라이드 param 4개
        /// </summary>
        /// <param name="w">넓이 Width</param>
        /// <param name="h">높이 Height</param>
        /// <param name="x">좌표정보 X</param>
        /// <param name="y">좌표정보 Y</param>
        public BaseModel(double w, double h, double x, double y)
        {
            this.Width = w;
            this.Height = h;

            this.X = x;
            this.Y = y;
        }
        #endregion
    }
}
